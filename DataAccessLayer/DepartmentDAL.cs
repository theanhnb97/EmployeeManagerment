using CommonLibrary.Model;

namespace DataAccessLayer
{
    using DataAccessLayer.Helpers;
    using Entity;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="DepartmentDAL" />
    /// </summary>
    public class DepartmentDAL : Connection, IEntities<Department>
    {
        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="department">The department<see cref="Department"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Department department)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {

                    string queryProcInsert = "Department_Insert";
                    CommandType conCommandType = CommandType.StoredProcedure;
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("departmentName",department.DepartmentName),
                        new OracleParameter("status",department.Status),
                        new OracleParameter("isDelete",department.IsDelete),
                        new OracleParameter("description",department.Description),

                    };

                    return sqlHelp.ExcuteNonQuery(queryProcInsert, conCommandType, connection, parameters);

                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {

                    string queryProcInsert = "Department_Delete";
                    CommandType conCommandType = CommandType.StoredProcedure;
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("p_departmentID",id),


                    };

                    return sqlHelp.ExcuteNonQuery(queryProcInsert, conCommandType, connection, parameters);

                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="List{Department}"/></returns>
        public List<Department> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAll()
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("cursorParam",OracleDbType.RefCursor,ParameterDirection.Output),
                    };
                    return sqlHelp.ExcuteQuery("Department_GetAllDeltete", CommandType.StoredProcedure, connection,
                        parameters);
                    //OracleDataAdapter da = new OracleDataAdapter();
                    //OracleCommand cmd = new OracleCommand();

                    //cmd = new OracleCommand("Department_GetAllDeltete", connection);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("p_isDelete", 1);
                    //cmd.Parameters.Add("cursorParam", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    //da.SelectCommand = cmd;
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //return dt;
                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return null;

            }
        }

        /// <summary>
        /// The GetDepartmentByStatusAndIsDelete
        /// </summary>
        /// <param name="status">The status<see cref="int"/></param>
        /// <param name="isDeleted">The isDeleted<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetDepartmentByStatusAndIsDelete(int status, int isDeleted)
        {
            try
            {
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_GetByStatusAndIsDelete", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("isDeletePara", isDeleted);
                    cmd.Parameters.Add("statusPara", status);
                    cmd.Parameters.Add("CURSOR_", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable data = new DataTable();
                    da.Fill(data);
                    return data;
                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return null;

            }
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetById(int id)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("p_departmentID",id),
                        new OracleParameter("cursorParam",OracleDbType.RefCursor,ParameterDirection.Output),
                    };
                    return sqlHelp.ExcuteQuery("Department_GetById", CommandType.StoredProcedure, connection, parameters);
                    //OracleDataAdapter da = new OracleDataAdapter();
                    //OracleCommand cmd = new OracleCommand();

                    //cmd = new OracleCommand("Department_GetById", connection);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("p_departmentID", id);
                    //cmd.Parameters.Add("cursorParam", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    //da.SelectCommand = cmd;
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //return dt;
                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return null;

            }
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="List{Department}"/></returns>
        public List<Department> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The SearchDepartment
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <param name="currPage">The currPage<see cref="int"/></param>
        /// <param name="recodperpage">The recodperpage<see cref="int"/></param>
        /// <param name="Pagesize">The Pagesize<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable SearchDepartment(string keyword, int currPage, int recodperpage, int Pagesize)
        {
            //try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_Search", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("currPage", currPage);
                    cmd.Parameters.Add("recodperpage", recodperpage);
                    cmd.Parameters.Add("Pagesize", Pagesize);
                    cmd.Parameters.Add(" p_departmentName", keyword);

                    cmd.Parameters.Add("cursorParam", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }

            }
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="department">The department<see cref="Department"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Department department)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {

                    string queryProcInsert = "Department_Update";
                    CommandType conCommandType = CommandType.StoredProcedure;
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                        new OracleParameter("p_departmentID",department.DepartmentID),
                        new OracleParameter("p_departmentName",department.DepartmentName),
                        new OracleParameter("p_status",department.Status),
                        new OracleParameter("p_isDelete",department.IsDelete),
                        new OracleParameter("p_description",department.Description),

                    };

                    return sqlHelp.ExcuteNonQuery(queryProcInsert, conCommandType, connection, parameters);

                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// The SearchDepartment
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable SearchDepartment(string keyword,int page)
        {
            int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
            
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
                using (OracleConnection connection = Connection.GetConnection)
                {
                  OracleParameter[] parameters=new OracleParameter[]
                  {
                      new OracleParameter("p_departmentName",keyword),
                      new OracleParameter("cursorParam",OracleDbType.RefCursor,ParameterDirection.Output),
                  };
                  return sqlHelp.ExcuteQuery("Department_SearchAll", CommandType.StoredProcedure, connection,
                      parameters);
                }

            
            

        }

        /// <summary>
        /// The DeleteNoRemove
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteNoRemove(int id)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {

                    string queryProcInsert = "Department_UpdateDelete";
                    CommandType conCommandType = CommandType.StoredProcedure;
                    OracleParameter[] parameters = new OracleParameter[]
                    {
                    new OracleParameter("p_departmentID",id),
                    new OracleParameter("p_isDelete",'1')


                    };

                    return sqlHelp.ExcuteNonQuery(queryProcInsert, conCommandType, connection, parameters);

                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return 0;
            }
        }

        /// <summary>
        /// The GetAllPage
        /// </summary>
        /// <param name="currPage">The currPage<see cref="int"/></param>
        /// <param name="recodperpage">The recodperpage<see cref="int"/></param>
        /// <param name="Pagesize">The Pagesize<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAllPage(int currPage, int recodperpage)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_Page", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("currPage", currPage);
                    cmd.Parameters.Add("recodperpage", recodperpage);
                    
                    cmd.Parameters.Add("cursorParam", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;

                }

            }
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return null;

            }
        }

        /// <summary>
        /// The GetDepartmentAll
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetDepartmentAll()
        {
            //try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleParameter[] parameters = new OracleParameter[]
                    {

                        new OracleParameter("cursorParam",OracleDbType.RefCursor,ParameterDirection.Output),
                    };
                    return sqlHelp.ExcuteQuery("Department_GetAll", CommandType.StoredProcedure, connection,
                        parameters);
                    //OracleDataAdapter da = new OracleDataAdapter();
                    //OracleCommand cmd = new OracleCommand();

                    //cmd = new OracleCommand("Department_GetAllDeltete", connection);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("p_isDelete", 1);
                    //cmd.Parameters.Add("cursorParam", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    //da.SelectCommand = cmd;
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //return dt;
                }

            }
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable IEntities<Department>.Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable IEntities<Department>.Search(string keyword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The TranferDataTableToDepartmentList
        /// </summary>
        /// <param name="dataTable">The dataTable<see cref="DataTable"/></param>
        /// <returns>The <see cref="List{Department}"/></returns>
        public List<Department> TranferDataTableToDepartmentList(DataTable dataTable)
        {
            List<Department> employees = new List<Department>();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    Department department = new Department();
                    department.DepartmentName = dr["DEPARTMENTNAME"].ToString();
                    department.DepartmentID = Convert.ToInt32(dr["DEPARTMENTID"].ToString());
                    department.Description = dr["DESCRIPTION"].ToString();
                    department.Status = Convert.ToInt32(dr["STATUS"].ToString());
                    department.IsDelete = Convert.ToInt32(dr["ISDELETE"].ToString());
                    employees.Add(department);
                }
                catch (Exception e)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(e.Message);
                }
            }
            return employees;
        }
        public List<Active> GetAllActive()
        {
            List<Active> list = new List<Active>
            {
                new Active(1,"Active"),
                new Active(0,"No Active"),

            };
            return list;
        }
    }
}
