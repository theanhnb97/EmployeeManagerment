using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Helpers;
using Entity;
using log4net;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

namespace DataAccessLayer
{
    interface IEmployee:IEntities<Employee>
    {
        int Login(string UserName, string Password);
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

        public int Login(string username, string password)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                try
                {
                    String cmd = "Loginn";
                    OracleParameter[] myParameters = new OracleParameter[]
                    {
                        new OracleParameter("usernames",username),
                        new OracleParameter("passwords",password),
                        new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                    };
                    DataTable dt = sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                    int a = int.Parse(dt.Rows[0][1].ToString());
                    return a;
                }
                catch (Exception e)
                {
                    return 0;
                }
                
            }
        }
       
    }
}
