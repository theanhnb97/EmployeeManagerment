namespace DataAccessLayer
{
    using Entity;
    using Entity.DTO;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="ISalary" />
    /// </summary>
    public interface ISalary
    {
        /// <summary>
        /// The GetData
        /// </summary>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> GetData();

        /// <summary>
        /// The SearchSalary
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="dept">The dept<see cref="string"/></param>
        /// <param name="fDate">The fDate<see cref="DateTime?"/></param>
        /// <param name="tDate">The tDate<see cref="DateTime?"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> SearchSalary(string name, string dept, DateTime? fDate, DateTime? tDate);
        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Salary"/></returns>
        Salary GetById(int id);

        /// <summary>
        /// The Paging
        /// </summary>
        /// <param name="size">The Size<see cref="int"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> Paging(int size, int index);
    }

    /// <summary>
    /// Defines the <see cref="SalaryDAO" />
    /// </summary>
    public class SalaryDAO : IEntities<Salary>, ISalary
    {
        /// <summary>
        /// Defines the Connect
        /// </summary>
        internal string Connect = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

        /// <summary>
        /// Defines the logger
        /// </summary>
        internal ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="salary">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Salary salary)
        {

            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_ADD";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("EMPLOYEEID", OracleDbType.Decimal).Value = salary.EmployeeId;
                Cmd.Parameters.Add("CREATEDATE", OracleDbType.Date).Value = salary.CreateDate;
                Cmd.Parameters.Add("BASIC", OracleDbType.Decimal).Value = salary.BasicSalary;
                Cmd.Parameters.Add("BUSSINESS", OracleDbType.Decimal).Value = salary.BussinessSalary;
                Cmd.Parameters.Add("COEFFICIENT", OracleDbType.Double).Value = salary.Coefficient;
                try
                {
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_DELETE";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("ID", OracleDbType.Decimal).Value = id;
                try
                {
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// The GetData
        /// </summary>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        public List<SalaryView> GetData()
        {
            List<SalaryView> salaryViews = new List<SalaryView>();
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_GETALL";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    Conn.Open();
                    OracleDataReader objReader = Cmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        SalaryView salaryView = new SalaryView();
                        salaryView.FullName = objReader["FULLNAME"].ToString();
                        salaryView.Identity = objReader["IDENTITY"].ToString();
                        salaryView.Rank = objReader["RANK"].ToString();
                        salaryView.Dept = objReader["DEPARTMENTNAME"].ToString();
                        salaryView.Basic = int.Parse(objReader["BASICSALARY"].ToString());
                        salaryView.Bussiness = int.Parse(objReader["BUSINESSSALARY"].ToString());
                        salaryView.Coefficient = float.Parse(objReader["COEFFICIENT"].ToString());
                        salaryView.Total = double.Parse(objReader["TOTAL"].ToString());
                        salaryView.SalaryId = int.Parse(objReader["SALARYID"].ToString());
                        salaryViews.Add(salaryView);
                    }
                    objReader.Close();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return null;
                }
            }
            return salaryViews;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="salary">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Salary salary)
        {
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_EDIT";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("ID", OracleDbType.Decimal).Value = salary.SalaryId;
                Cmd.Parameters.Add("BASIC", OracleDbType.Decimal).Value = salary.BasicSalary;
                Cmd.Parameters.Add("BUSSINESS", OracleDbType.Decimal).Value = salary.BussinessSalary;
                Cmd.Parameters.Add("COFFI", OracleDbType.Decimal).Value = salary.Coefficient;
                try
                {
                    Conn.Open();
                    Cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return 0;
                }
            }
            return 1;
        }

        /// <summary>
        /// The SearchSalary
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <param name="dept">The dept<see cref="string"/></param>
        /// <param name="fDate">The fDate<see cref="DateTime?"/></param>
        /// <param name="tDate">The tDate<see cref="DateTime?"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        public List<SalaryView> SearchSalary(string name, string dept, DateTime? fDate, DateTime? tDate)
        {
            List<SalaryView> salaryViews = new List<SalaryView>();
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_SEARCH";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("NAME", OracleDbType.Varchar2).Value = name;
                Cmd.Parameters.Add("DEPT", OracleDbType.Varchar2).Value = dept;
                Cmd.Parameters.Add("FDATE", OracleDbType.Date).Value = fDate;
                Cmd.Parameters.Add("TDATE", OracleDbType.Date).Value = tDate;
                Cmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    Conn.Open();
                    OracleDataReader objReader = Cmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        SalaryView salaryView = new SalaryView();
                        salaryView.FullName = objReader["FULLNAME"].ToString();
                        salaryView.Identity = objReader["IDENTITY"].ToString();
                        salaryView.Rank = objReader["RANK"].ToString();
                        salaryView.Dept = objReader["DEPARTMENTNAME"].ToString();
                        salaryView.Basic = int.Parse(objReader["BASICSALARY"].ToString());
                        salaryView.Bussiness = int.Parse(objReader["BUSINESSSALARY"].ToString());
                        salaryView.Coefficient = float.Parse(objReader["COEFFICIENT"].ToString());
                        salaryView.Total = double.Parse(String.Format("{0:0.00}", objReader["TOTAL"]));
                        salaryView.SalaryId = int.Parse(objReader["SALARYID"].ToString());
                        salaryViews.Add(salaryView);
                    }
                    objReader.Close();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return null;
                }
            }
            return salaryViews;
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Salary"/></returns>
        public Salary GetById(int idSalary)
        {
            Salary salary = new Salary();
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_GETBYID";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("ID", OracleDbType.Decimal).Value = idSalary;
                Cmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    Conn.Open();
                    OracleDataReader objReader = Cmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        salary.EmployeeId = int.Parse(objReader["EMPID"].ToString());
                        salary.CreateDate = DateTime.Parse(objReader["CREATEDATE"].ToString());
                        salary.BasicSalary = int.Parse(objReader["BASIC"].ToString());
                        salary.BussinessSalary = int.Parse(objReader["BUSSINESS"].ToString());
                        salary.Coefficient = float.Parse(objReader["COEFFI"].ToString());
                        salary.IsDelete = bool.Parse(objReader["ISDELETE"].ToString());
                    }
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return null;
                }
            }
            return salary;
        }

        /// <summary>
        /// The GetByIdDeptAndRank
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="rank">The rank<see cref="int"/></param>
        /// <returns>The <see cref="List{Employee}"/></returns>
        public List<Employee> GetByIdDeptAndRank(int id, int rank)
        {
            List<Employee> result = new List<Employee>();
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "EMPLOYEE_GETBYDEPTID_ANDRANK";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("IDS", OracleDbType.Decimal).Value = id;
                Cmd.Parameters.Add("RANKS", OracleDbType.Decimal).Value = rank;
                Cmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    Conn.Open();
                    OracleDataReader objReader = Cmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        Employee employee = new Employee();
                        employee.EmployeeId = int.Parse(objReader["EMPLOYEEID"].ToString());
                        employee.Address = objReader["ADDRESS"].ToString();
                        employee.DepartmentId = int.Parse(objReader["DEPARTMENTID"].ToString());
                        employee.Email = objReader["EMAIL"].ToString();
                        employee.FullName = objReader["FULLNAME"].ToString();
                        employee.Identity = objReader["IDENTITY"].ToString();
                        employee.IsDelete = Convert.ToInt16(objReader["ISDELETE"].ToString());
                        employee.Status = Convert.ToInt16(objReader["STATUS"].ToString());
                        employee.Phone = objReader["PHONE"].ToString();
                        result.Add(employee);
                    }
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return null;
                }
            }
            return result;
        }

        /// <summary>
        /// The Paging
        /// </summary>
        /// <param name="size">The size<see cref="int"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        public List<SalaryView> Paging(int size, int index)
        {
            List<SalaryView> salaryViews = new List<SalaryView>();
            using (OracleConnection Conn = new OracleConnection(Connect))
            {
                OracleCommand Cmd = new OracleCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "SALARY_PAGING";
                Cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Cmd.Parameters.Add("PageSize", OracleDbType.Decimal).Value = size;
                Cmd.Parameters.Add("PageIndex", OracleDbType.Decimal).Value = index;
                Cmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    Conn.Open();
                    OracleDataReader objReader = Cmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        SalaryView salaryView = new SalaryView();
                        salaryView.FullName = objReader["FULLNAME"].ToString();
                        salaryView.Identity = objReader["IDENTITY"].ToString();
                        salaryView.Rank = objReader["RANK"].ToString();
                        salaryView.Dept = objReader["DEPARTMENTNAME"].ToString();
                        salaryView.Basic = int.Parse(objReader["BASICSALARY"].ToString());
                        salaryView.Bussiness = int.Parse(objReader["BUSINESSSALARY"].ToString());
                        salaryView.Coefficient = float.Parse(objReader["COEFFICIENT"].ToString());
                        salaryView.Total = double.Parse(String.Format("{0:0.00}", objReader["TOTAL"]));
                        salaryView.SalaryId = int.Parse(objReader["SALARYID"].ToString());
                        salaryViews.Add(salaryView);
                    }
                    objReader.Close();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                    return null;
                }
            }
            return salaryViews;
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="List{Salary}"/></returns>
        public List<Salary> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            throw new NotImplementedException();
        }


    }
}
