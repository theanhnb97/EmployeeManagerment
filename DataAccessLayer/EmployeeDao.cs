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
    interface IEmployee
    {
        bool Login(string UserName, string Password);
    }

    public class EmployeeDao : IEntities<Employee>, IEmployee
    {
        SqlHelpers<Employee> sql = new SqlHelpers<Employee>();
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<Employee> Get()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "Employee_GetAll";
                    DataTable data = sql.ExcuteQuery(storeName, CommandType.StoredProcedure, oracleConnection, null);
                }
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
            }
            return employees;
        }

        public List<Employee> Search(string keyword)
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

        public bool Login(string UserName, string Password)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Select login(:usernames,:passwords) from dual";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("usernames",UserName),
                    new OracleParameter("passwords",Password),
                };
                DataTable dt = sql.ExcuteQuery(cmd, CommandType.Text, con, myParameters);
                bool a= dt.Rows[0][0].ToString()!="";
                return a;
            }
        }
       
    }
}
