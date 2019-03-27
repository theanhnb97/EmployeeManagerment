using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Entity;
using Entity.DTO;
using log4net;
using Oracle.ManagedDataAccess.Client;
//using Oracle.DataAccess.Client;

namespace DataAccessLayer
{
    interface IEmployee:IEntities<Employee>
    {
        bool Login(string UserName, string Password);
        List<EmployeeDTO> GetAll();
    }

    public class EmployeeDao : IEmployee
    {
        protected SqlHelpers<Employee> sql = new SqlHelpers<Employee>();
        protected SqlHelpers<EmployeeDTO> sqlHelpersDto = new SqlHelpers<EmployeeDTO>();

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

        public int Add(Employee employee)
        {
            int result = 0;
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    OracleCommand oracleCommand = new OracleCommand();
                    string storeName = "EMPLOYEE_INSERT";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        //(OracleParameter) (oracleCommand.Parameters.Add("RolesId",OracleDbType.Int32,ParameterDirection.Input).Value = employee.RolesId),
                        new OracleParameter("RolesId",employee.RolesId),
                        new OracleParameter("DepartmentId",employee.DepartmentId),
                        new OracleParameter("Rank",employee.Rank),
                        new OracleParameter("FullName",employee.FullName),
                        new OracleParameter("UserName",employee.UserName),
                        new OracleParameter("Password",employee.FullName),
                        new OracleParameter("Identity",employee.Identity),
                        new OracleParameter("Address",employee.Address),
                        new OracleParameter("Phone",employee.Phone),
                        new OracleParameter("Email",employee.Email),
                        new OracleParameter("Status",employee.Status),
                        new OracleParameter("IsDelete", employee.IsDelete)

                    };
                    result = sql.ExcuteNonQuery(storeName,CommandType.StoredProcedure,oracleConnection, oracleParameters);
                }
            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
            }
            return result;
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

        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {

                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_GETALL";
                    OracleParameter oraP = new OracleParameter();
                    oraP.OracleDbType = OracleDbType.RefCursor;
                    oraP.Direction = System.Data.ParameterDirection.Output;
                    OracleParameter[] myParameters = new OracleParameter[1];
                    myParameters[0] = oraP;
                    //dt = sql.ExcuteQuery(storeName, CommandType.StoredProcedure, oracleConnection, myParameters);
                    employees = sqlHelpersDto.ExcuteQueryList(storeName, CommandType.StoredProcedure, oracleConnection, myParameters);

                }
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
            }
            return employees;
        }

    }
}
