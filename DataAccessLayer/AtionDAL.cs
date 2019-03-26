using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using log4net;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    interface IAction:IEntities<Action>
    {
        
    }
    public class AtionDAL:IAction
    {
    protected SqlHelpers<Action> sql = new SqlHelpers<Action>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DataTable Get()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Select * from Action";
                return sql.ExcuteQuery(cmd, CommandType.Text, con, null);
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

        public int Update(Action obj)
        {
            throw new NotImplementedException();
        }

        public int Add(Action obj)
        {
            throw new NotImplementedException();
        }
    }
}
