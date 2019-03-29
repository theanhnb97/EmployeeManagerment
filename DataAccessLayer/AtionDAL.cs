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

        public List<Action> GetList()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQueryDataReader(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

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
                List<Action> myList= sql.ExcuteQueryDataReader(cmd, CommandType.StoredProcedure, con, myParameters);
                if (myList != null)
                    return myList[0];
                return null;
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
                try
                {
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
                            return 0;
                        }
                    }
                    return -1;
                }
                catch (Exception e)
                {
                    logger.Debug(e.Message);
                    return 0;
                }
            }

        }
    }
}
