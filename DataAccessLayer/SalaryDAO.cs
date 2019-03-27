using DataAccessLayer.Helpers;
using Entity;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Entity.DTO;
using System.Data;

namespace DataAccessLayer
{
    public interface ISalary 
    {
        List<SalaryView> GetData();
        List<SalaryView> SearchSalary(string name, string dept, DateTime fDate, DateTime tDate);
        Salary GetById(int id);
    }
    public class SalaryDAO : IEntities<Salary>, ISalary
    {       
        string Connect = "DATA SOURCE=192.168.35.210:1521/orcl;PASSWORD=theanh;PERSIST SECURITY INFO=True;USER ID=GDP";
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                Ocmd.Parameters.Add("ISDELETE", OracleDbType.Decimal).Value = obj.IsDelete;
                try
                {
                    objConn.Open();
                    Ocmd.ExecuteNonQuery();
                }
                catch
                {
                    return 0;
                }
                objConn.Close();
            }
            return 1;
        }

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
                catch
                {
                    return 0;
                }
                objConn.Close();
            }
            return 1;
        }
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
                        salaryViews.Add(salaryView);
                    }
                    objReader.Close();
                }
                catch
                {
                    return null;
                }
                objConn.Close();
            }
            return salaryViews;

        }
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
                catch
                {
                    return 0;
                }
                objConn.Close();
            }
            return 1;
        }

        public List<SalaryView> SearchSalary(string name, string dept, DateTime? fDate, DateTime? tDate)
        {
            List<SalaryView> salaryViews = new List<SalaryView>();
            using (OracleConnection objConn = new OracleConnection(Connect))
            {
                OracleCommand Ocmd = new OracleCommand();
                Ocmd.Connection = objConn;
                Ocmd.CommandText = "SALARY_SEARCH";
                Ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                Ocmd.Parameters.Add("NAME", OracleDbType.Decimal).Value = name;
                Ocmd.Parameters.Add("DEPT", OracleDbType.Decimal).Value = dept;
                Ocmd.Parameters.Add("FDATE", OracleDbType.Decimal).Value = fDate;
                Ocmd.Parameters.Add("TDATE", OracleDbType.Decimal).Value = tDate;
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
                        salaryViews.Add(salaryView);
                    }
                    objReader.Close();
                }
                catch
                {
                    return null;
                }
                objConn.Close();
            }
            return salaryViews;
        }
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
                catch
                {
                    return null;
                }
                objConn.Close();
            }
            return salary;
        }

        public List<Salary> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public DataTable Get()
        {
            throw new NotImplementedException();
        }

        DataTable IEntities<Salary>.Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<SalaryView> SearchSalary(string name, string dept, DateTime fDate, DateTime tDate)
        {
            throw new NotImplementedException();
        }
    }
}
