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
using Action = Entity.Action;

namespace DataAccessLayer
{
    interface IAction : IEntities<Action>
    {
        Action GetByName(string name);
    }
    public class ActionDAL : IAction
    {
        protected SqlHelpers<Action> sql = new SqlHelpers<Action>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DataTable Get()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }
        public Action GetByName(string name)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_Get";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("names",name),
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                DataTable myList = sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                if (myList.Rows.Count < 1)
                    return null;
                return new Action
                {
                    ActionID = int.Parse(myList.Rows[0][0].ToString()),
                    ActionName = myList.Rows[0][1].ToString(),
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
                String cmd = "Action_Delete";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionids",id)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public int Update(Action obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_Update";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionids",obj.ActionID),
                    new OracleParameter("actionnames",obj.ActionName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        public int Add(Action obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                //OracleTransaction transaction = con.BeginTransaction();

                String cmd = "Action_Insert";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                        new OracleParameter("actionnames", obj.ActionName),
                        new OracleParameter("isdeletes", obj.IsDelete),
                        new OracleParameter("descriptions", obj.Description)
                };
                sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                Action newActionAdd = GetByName(obj.ActionName);
                DataTable listRoles = new DataTable();
                RolesDAL myRoles = new RolesDAL();
                RolesActionDAL myRolesAction = new RolesActionDAL();
                listRoles = myRoles.Get();
                foreach (DataRow item in listRoles.Rows)
                {
                    RolesAction myRolesActionAdd = new RolesAction
                    {
                        ID = 0,
                        ActionID = newActionAdd.ActionID,
                        IsTrue = 0,
                        RolesID = int.Parse(item[0].ToString())
                    };
                    if (myRolesAction.Add(myRolesActionAdd) != -1)
                    {
                        //transaction.Rollback();
                        return 0;
                    }
                }
                //transaction.Commit();
                return -1;
            }

        }
    }
}
