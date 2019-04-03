namespace DataAccessLayer
{
    using DataAccessLayer.Helpers;
    using Entity;
    using Entity.DTO;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="IEmployee" />
    /// </summary>
    interface IEmployee : IEntities<Employee>
    {
        /// <summary>
        /// The Login
        /// </summary>
        /// <param name="UserName">The UserName<see cref="string"/></param>
        /// <param name="Password">The Password<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Login(string UserName, string Password);

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
        List<EmployeeDTO> GetAll();

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
        List<EmployeeDTO> Search(Employee employee);

        /// <summary>
        /// The GetByEmployeeId
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <returns>The <see cref="Employee"/></returns>
        Employee GetByEmployeeId(int employeeId);
    }

    /// <summary>
    /// Defines the <see cref="EmployeeDao" />
    /// </summary>
    public class EmployeeDao : IEmployee
    {
        /// <summary>
        /// Defines the sql
        /// </summary>
        protected SqlHelpers<Employee> sql = new SqlHelpers<Employee>();

        /// <summary>
        /// Defines the sqlHelpersDto
        /// </summary>
        protected SqlHelpers<EmployeeDTO> sqlHelpersDto = new SqlHelpers<EmployeeDTO>();

        /// <summary>
        /// Defines the logger
        /// </summary>
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
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

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="int"/></returns>
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

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="int"/></returns>
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

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
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

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="employee">The employee<see cref="Employee"/></param>
        /// <returns>The <see cref="List{EmployeeDTO}"/></returns>
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

        /// <summary>
        /// The GetByEmployeeId
        /// </summary>
        /// <param name="employeeId">The employeeId<see cref="int"/></param>
        /// <returns>The <see cref="Employee"/></returns>
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

        /// <summary>
        /// The TranferDataTableToEmployeeList
        /// </summary>
        /// <param name="dataTable">The dataTable<see cref="DataTable"/></param>
        /// <returns>The <see cref="List{Employee}"/></returns>
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

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Login
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
                    if (dt == null) return -1;
                    if (dt.Rows.Count < 1) return 0;
                    return int.Parse(dt.Rows[0]["ROLESID"].ToString());
                }
                catch (FormatException e)
                {
                    logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return -1;
                }

            }
        }

        /// <summary>
        /// The GetByUsername
        /// </summary>
        /// <param name="username">The username<see cref="string"/></param>
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
        /// The GetByIdentity
        /// </summary>
        /// <param name="identity">The identity<see cref="string"/></param>
        /// <returns>The <see cref="Employee"/></returns>
        public Employee GetByIdentity(string identity)
        {
            Employee employee = new Employee();
            try
            {
                using (OracleConnection oracleConnection = Connection.GetConnection)
                {
                    string storeName = "EMPLOYEE_GETBYIDENTITY";
                    OracleParameter[] oracleParameters = new OracleParameter[]
                    {
                        new OracleParameter("identityPara",identity),
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
        /// The UpdateProfile
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

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Search(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
