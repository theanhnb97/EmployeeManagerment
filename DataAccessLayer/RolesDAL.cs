using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Entity;
using log4net;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    interface IRoles:IEntities<Roles>
    {
        
    }
    public class RolesDAL:IRoles
    {
        protected SqlHelpers<RolesAction> sql = new SqlHelpers<RolesAction>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DataTable Get()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public Roles GetByName(string name)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Get";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("names",name),
                    new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                DataTable myList = sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                if (myList.Rows.Count < 1)
                    return null;
                return new Roles
                {
                    RolesID = int.Parse(myList.Rows[0][0].ToString()),
                    RolesName = myList.Rows[0][1].ToString(),
                    IsDelete = int.Parse(myList.Rows[0][2].ToString()),
                    Description = myList.Rows[0][3].ToString()
                };
            }
        }


        public DataTable Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Delete";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesids",id)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public int Update(Roles obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Update";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesids",obj.RolesID),
                    new OracleParameter("rolesnames",obj.RolesName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public int Add(Roles obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Insert";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesnames",obj.RolesName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                Roles newAdd = GetByName(obj.RolesName);
                DataTable listRoles = new DataTable();
                ActionDAL myActionDal = new ActionDAL();
                RolesActionDAL myRolesAction = new RolesActionDAL();
                listRoles = myActionDal.Get();
                foreach (DataRow item in listRoles.Rows)
                {
                    RolesAction myRolesActionAdd = new RolesAction
                    {
                        ID = 0,
                        ActionID = int.Parse(item[0].ToString()),
                        IsTrue = 0,
                        RolesID = newAdd.RolesID
                    };
                    if (myRolesAction.Add(myRolesActionAdd) != -1)
                        return 0;
                }
                return -1;
            }
        }
    }
}
