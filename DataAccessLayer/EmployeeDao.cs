using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Entity;
using log4net;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

namespace DataAccessLayer
{
    interface IEmployee:IEntities<Employee>
    {
        bool Login(string UserName, string Password);
    }

    public class EmployeeDao : IEmployee
    {
        protected SqlHelpers<Employee> sql = new SqlHelpers<Employee>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DataTable Get()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "Employee_GetAll";
                    return sql.ExcuteQuery(storeName, CommandType.StoredProcedure, oracleConnection, null);
                }
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                return null;
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

        public int Update(Employee obj)
        {
            throw new NotImplementedException();
        }

        public int Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public bool Login(string username, string password)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Select login(:usernames,:passwords) from dual";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("usernames",username),
                    new OracleParameter("passwords",password),
                };
                DataTable dt = sql.ExcuteQuery(cmd, CommandType.Text, con, myParameters);
                bool a= dt.Rows[0][0].ToString()!="";
                return a;
            }
        }
       
    }
}
