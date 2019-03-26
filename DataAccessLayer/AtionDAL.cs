using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using log4net;
using Oracle.ManagedDataAccess.Client;
using Action = Entity.Action;

namespace DataAccessLayer
{
    interface IAction : IEntities<Action>
    {

    }
    public class AtionDAL : IAction
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
                String cmd = "Action_Insert";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionnames",obj.ActionName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }
    }
}
