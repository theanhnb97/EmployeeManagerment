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
        /// <param name="Size">The Size<see cref="int"/></param>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="List{SalaryView}"/></returns>
        List<SalaryView> Paging(int Size, int index);
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
        /// <param name="obj">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Salary obj)
        {
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_ADD";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("EMPLOYEEID", OracleDbType.Decimal).Value = obj.EmployeeId;
                Ocmd.Parameters.Add("CREATEDATE", OracleDbType.Date).Value = obj.CreateDate;
                Ocmd.Parameters.Add("BASIC", OracleDbType.Decimal).Value = obj.BasicSalary;
                Ocmd.Parameters.Add("BUSSINESS", OracleDbType.Decimal).Value = obj.BussinessSalary;
                Ocmd.Parameters.Add("COEFFICIENT", OracleDbType.Double).Value = obj.Coefficient;
                try
                {
                    objConn.Open();
                    Ocmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                }
                objConn.Close();
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
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_DELETE";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("ID", OracleDbType.Decimal).Value = id;
                try
                {
                    objConn.Open();
                    Ocmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                }
                objConn.Close();
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
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_GETALL";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader objReader = Ocmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        SalaryView salaryView = new SalaryView();
                        salaryView.FullName = objReader["FULLNAME"].ToString();
                        salaryView.Identity = objReader["IDENTITY"].ToString();
                        salaryView.Rank = int.Parse(objReader["RANK"].ToString());
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
                }
                objConn.Close();
            }
            return salaryViews;
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Salary"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Salary obj)
        {
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_EDIT";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("ID", OracleDbType.Decimal).Value = obj.SalaryId;
                Ocmd.Parameters.Add("BASIC", OracleDbType.Decimal).Value = obj.BasicSalary;
                Ocmd.Parameters.Add("BUSSINESS", OracleDbType.Decimal).Value = obj.BussinessSalary;
                Ocmd.Parameters.Add("COFFI", OracleDbType.Decimal).Value = obj.Coefficient;
                try
                {
                    objConn.Open();
                    Ocmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                }
                objConn.Close();
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
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_SEARCH";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("NAME", OracleDbType.Varchar2).Value = name;
                Ocmd.Parameters.Add("DEPT", OracleDbType.Varchar2).Value = dept;
                Ocmd.Parameters.Add("FDATE", OracleDbType.Date).Value = fDate;
                Ocmd.Parameters.Add("TDATE", OracleDbType.Date).Value = tDate;
                Ocmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader objReader = Ocmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        SalaryView salaryView = new SalaryView();
                        salaryView.FullName = objReader["FULLNAME"].ToString();
                        salaryView.Identity = objReader["IDENTITY"].ToString();
                        salaryView.Rank = int.Parse(objReader["RANK"].ToString());
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
                }
                objConn.Close();
            }
            return salaryViews;
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="Salary"/></returns>
        public Salary GetById(int id)
        {
            Salary salary = new Salary();
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_GETBYID";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("ID", OracleDbType.Decimal).Value = id;
                Ocmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader objReader = Ocmd.ExecuteReader();
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
                }
                objConn.Close();
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
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "EMPLOYEE_GETBYDEPTID_ANDRANK";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("IDS", OracleDbType.Decimal).Value = id;
                Ocmd.Parameters.Add("RANK", OracleDbType.Decimal).Value = rank;
                Ocmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader objReader = Ocmd.ExecuteReader();
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
                }
                objConn.Close();
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
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_PAGING";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("PageSize", OracleDbType.Decimal).Value = size;
                Ocmd.Parameters.Add("PageIndex", OracleDbType.Decimal).Value = index;
                Ocmd.Parameters.Add("P_RESULT", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                try
                {
                    objConn.Open();
                    OracleDataReader objReader = Ocmd.ExecuteReader();
                    while (objReader.Read())
                    {
                        SalaryView salaryView = new SalaryView();
                        salaryView.FullName = objReader["FULLNAME"].ToString();
                        salaryView.Identity = objReader["IDENTITY"].ToString();
                        salaryView.Rank = int.Parse(objReader["RANK"].ToString());
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
                }
                objConn.Close();
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

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable IEntities<Salary>.Search(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
