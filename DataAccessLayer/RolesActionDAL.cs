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
using Action = System.Action;

namespace DataAccessLayer
{
    interface IRolesAction : IEntities<RolesAction>
    {
        DataTable GetAllTrue(int id);
        int DeleteAll();
    }
    public class RolesActionDAL : IRolesAction
    {
        protected SqlHelpers<RolesAction> sql = new SqlHelpers<RolesAction>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DataTable GetAllTrue(int id)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_GetAllTrue";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("ids",id),
                    new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public int DeleteAll()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_Scan";
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, null);
            }
        }


        public DataTable Get()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public DataTable Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(RolesAction obj)
        {
            throw new NotImplementedException();
        }

        public int Update(List<RolesAction> obj)
        {
            String cmd = "RolesAction_Update";
            foreach (RolesAction item in obj)
            {

                OracleParameter[] myParameters = new OracleParameter[]
                {
                        new OracleParameter("ids",item.ID),
                        new OracleParameter("istrues",item.IsTrue)
                };
                using (OracleConnection con = Connection.GetConnection)
                    sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
            return -1;
        }

        public int Add(RolesAction obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_Insert";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionids",obj.ActionID),
                    new OracleParameter("rolesids",obj.RolesID),
                    new OracleParameter("istrues",obj.IsTrue)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }
    }
}
