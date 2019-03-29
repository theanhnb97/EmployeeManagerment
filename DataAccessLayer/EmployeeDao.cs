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
        int Login(string UserName, string Password);
        List<EmployeeDTO> GetAll();

        List<EmployeeDTO> Search(Employee employee);

        Employee GetByEmployeeId(int employeeId);
    }

    public class EmployeeDao : IEmployee
    {
        protected SqlHelpers<Employee> sql = new SqlHelpers<Employee>();
        protected SqlHelpers<EmployeeDTO> sqlHelpersDto = new SqlHelpers<EmployeeDTO>();

        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public Employee GetByEmployeeId(int employeeId)
        {
            Employee employee = new Employee();
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_GETBYEMPLOYEEID";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        new OracleParameter("employeeIdInput",employeeId),
                        new OracleParameter("cursor",OracleDbType.RefCursor,ParameterDirection.Output)
                    };
                    DataTable data = sql.ExcuteQuery(storeName, CommandType.StoredProcedure, oracleConnection, oracleParameters);
                    employee = TranferDataTableToEmployeeList(data)[0];
                }
            }
            catch (Exception e)
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
            }
            return employee;
        }

        public List<Employee> TranferDataTableToEmployeeList(DataTable dataTable)
        {
            List<Employee> employees = new List<Employee>();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    Employee employee = new Employee();
                    employee.RolesId = Convert.ToInt32(dr["ROLESID"].ToString());
                    employee.DepartmentId = Convert.ToInt32(dr["DEPARTMENTID"].ToString());
                    employee.Rank = Convert.ToInt16(dr["RANK"].ToString());
                    employee.FullName = dr["FULLNAME"].ToString();
                    employee.UserName = dr["USERNAME"].ToString();
                    employee.Password = dr["PASSWORD"].ToString();
                    employee.Identity = dr["IDENTITY"].ToString();
                    employee.Address = dr["ADDRESS"].ToString();
                    employee.Phone = dr["PHONE"].ToString();
                    employee.Email = dr["EMAIL"].ToString();
                    employee.Status = Convert.ToInt16(dr["STATUS"].ToString());
                    employee.IsDelete = Convert.ToInt16(dr["ISDELETE"].ToString());
                    employee.EmployeeId = Convert.ToInt32(dr["EMPLOYEEID"].ToString());
                    employees.Add(employee);
                }
                catch (Exception e)
                {
                    logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                }
            }
            return employees;
        }

        public DataTable Get()
        {
            throw new NotImplementedException();
        }

   



        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetByUsername(string username)
        {
            Employee employee = new Employee();
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_GETBYUSERNAME";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        new OracleParameter("usernames",username),
                        new OracleParameter("cursor",OracleDbType.RefCursor,ParameterDirection.Output)
                    };
                    DataTable data = sql.ExcuteQuery(storeName, CommandType.StoredProcedure, oracleConnection, oracleParameters);
                    employee = TranferDataTableToEmployeeList(data)[0];
                }
            }
            catch (Exception e)
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
            }
            return employee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int UpdateProfile(Employee employee)
        {
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "Employee_UpdateByUserName";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        new OracleParameter("userNames",employee.UserName),
                        new OracleParameter("fullNames",employee.FullName),
                        new OracleParameter("identitys",employee.Identity),
                        new OracleParameter("addresss",employee.Address),
                        new OracleParameter("phones",employee.Phone),
                        new OracleParameter("emails",employee.Email),
                    };
                    return sql.ExcuteNonQuery(storeName, CommandType.StoredProcedure, oracleConnection, oracleParameters);
                }
            }
            catch (Exception e)
            {
                logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return 0;
            }
        }

    }
}
