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

namespace DataAccessLayer
{
    interface IEmployee
    {
        bool Login(string UserName, string Password);
    }

    public class EmployeeDao : IEntities<Employee>,IEmployee
    {
        SqlHelpers sql = new SqlHelpers();
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
                int count = 0;
                OracleParameter[] myParameters=new OracleParameter[]
                {
                    new OracleParameter("UserNamee",UserName),
                    new OracleParameter("Password",Password),
                    new OracleParameter("Count",count) 
                };
                sql.ExcuteNonQuery("Login", CommandType.StoredProcedure, con, myParameters);
                return count != 0;
            }
        }
    }
}
