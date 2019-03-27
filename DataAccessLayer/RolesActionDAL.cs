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
    }
    public class RolesActionDAL: IRolesAction
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
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        

        public DataTable Get()
        {
            throw new NotImplementedException();
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
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_Update";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("ids",obj.ID),
                    new OracleParameter("actionids",obj.ActionID),
                    new OracleParameter("rolesids",obj.RolesID),
                    new OracleParameter("istrues",obj.IsTrue)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
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
