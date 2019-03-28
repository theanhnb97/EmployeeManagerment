using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Entity;
using Entity.DTO;
using log4net;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    interface IEmployee:IEntities<Employee>
    {
        bool Login(string UserName, string Password);

        List<EmployeeDTO> GetAll();

        List<EmployeeDTO> Search(Employee employee);
    }

    public class EmployeeDao : IEmployee
    {
        protected SqlHelpers<Employee> sql = new SqlHelpers<Employee>();
        protected SqlHelpers<EmployeeDTO> sqlHelpersDto = new SqlHelpers<EmployeeDTO>();

        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DataTable Get()
        {
            throw new NotImplementedException();
        }

        public DataTable Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Delete(int employeeId)
        {
            int result = 0;
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_DELETE";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        new OracleParameter("employeeIdPara",employeeId)
                    };
                    result = sql.ExcuteNonQuery(storeName, CommandType.StoredProcedure, oracleConnection, oracleParameters);
                }
            }
            catch (Exception e)
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
            }
            return result;
        }

        public int Update(Employee employee)
        {
            int result = 0;
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_UPDATE";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        // because parameter in store dont in "" then it upper case automaticlly, then must rename different with column name
                        // but in oracleParameter c# upper case and lower case are the same things
                        new OracleParameter("employeeIdPara",employee.EmployeeId),
                        new OracleParameter("rolesIdPara",employee.RolesId),
                        new OracleParameter("departmentIdPara",employee.DepartmentId),
                        new OracleParameter("rankPara",employee.Rank),
                        new OracleParameter("fullNamePara",employee.FullName),
                        new OracleParameter("userNamePara",employee.UserName),
                        new OracleParameter("passwordPara",employee.FullName),
                        new OracleParameter("identityPara",employee.Identity),
                        new OracleParameter("addressPara",employee.Address),
                        new OracleParameter("phonePara",employee.Phone),
                        new OracleParameter("emailPara",employee.Email),
                        new OracleParameter("statusPara",employee.Status),
                        new OracleParameter("isDeletePara", employee.IsDelete)

                    };
                    result = sql.ExcuteNonQuery(storeName, CommandType.StoredProcedure, oracleConnection, oracleParameters);
                }
            }
            catch (Exception e)
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
            }
            return result;
        }

        public int Add(Employee employee)
        {
            int result = 0;
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    //OracleCommand oracleCommand = new OracleCommand();
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
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                    employees = sqlHelpersDto.ExcuteQueryList(storeName, CommandType.StoredProcedure, oracleConnection, myParameters);

                }
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
            }
            return employees;
        }

        public List<EmployeeDTO> Search(Employee employee)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_SEARCH";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        new OracleParameter("cursor",OracleDbType.RefCursor,ParameterDirection.Output),
                        new OracleParameter("departmentIdPara",employee.DepartmentId),
                        new OracleParameter("fullNamePara",employee.FullName),
                        new OracleParameter("userNamePara",employee.UserName),
                        new OracleParameter("identityPara",employee.Identity),

                    };
                    employees = sqlHelpersDto.ExcuteQueryList(storeName, CommandType.StoredProcedure, oracleConnection, oracleParameters);
                }
            }
            catch (Exception e)
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
            }
            return employees;
        }
    }
}
