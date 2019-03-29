using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Entity;
using log4net;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    
    public class DepartmentDAL : Connection, IEntities<Department>
    {
        /// <summary>/// Hàm thêm mới phòng ban.
        /// </summary>
        /// <param name=”departmentName”>Tên phòng ban</param>

        /// <param name=”status”>Status</param>

        /// <param name=”isDelete”>isDelete</param>

        /// <param name=”description”>Mô tả phòng ban</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
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
        /// <summary>/// Xóa phòng ban.
        /// </summary>
        /// <param name=”p_departmentID”>Mã phòng ban</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
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
        
        public List<Department> Get()
        {
            throw new NotImplementedException();
        }
        /// <summary>/// Hiển thị danh sách phòng ban.
        /// </summary>
        /// <param name=”p_isDelete”>Mã phòng ban</param>
        /// <param name=”cursorParam”>Cursor</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        ///Modified by (BuiCongDai) – (28/3/2019 , 1)
        /// <remarks></remarks>
        public DataTable GetAll()
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleParameter[] parameters=new OracleParameter[]
                    {
                        new OracleParameter("p_isDelete",1), 
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
        /// <summary>/// Hiển thị danh sách phòng ban theo mã phòng ban.
        /// </summary>
        /// <param name=”p_departmentID”>Mã phòng ban</param>
        /// <param name=”cursorParam”>Cursor</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        /// Created by (BuiCongDai) – (25/3/2019)
        ///Modified by (BuiCongDai) – (28/3/2019 , 1)
        /// <remarks></remarks>

        public DataTable GetById(int id)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleParameter[] parameters=new OracleParameter[]
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
       
        public List<Department> Search(string keyword)
        {
            throw new NotImplementedException();
        }
        /// <summary>/// Sửa phòng ban.
        /// </summary>
        /// <param name=”p_departmentID”>Mã phòng ban</param>
        /// <param name=”p_departmentName”>Tên phòng ban</param>
        /// <param name=”p_status"”>Status</param>
        /// <param name=”p_isDelete”>isDelete</param>
        /// <param name=”p_description”>Cursor</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>

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
        /// <summary>/// Tìm kiếm phòng ban.
        /// </summary>
        /// <param name=”p_departmentID”>Mã phòng ban</param>
        /// <param name=”p_departmentName”>Tên phòng ban</param>
        /// <param name=”p_status"”>Status</param>
        /// <param name=”p_isDelete”>isDelete</param>
        /// <param name=”p_description”>Mô tả phòng ban</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>

        public DataTable SearchDepartment(string keyword,int currPage,int recodperpage,int Pagesize)
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
                    cmd.Parameters.Add("Pagesize", Pagesize);
                    
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
        /// <summary>///Xóa phòng ban danh sách.
        /// </summary>
        /// <param name=”p_departmentID”>Mã phòng ban</param>
        /// <param name=”p_isDelete”>isDelete</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>

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
                    new OracleParameter("p_isDelete",'0')


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
        /// <summary>/// Tìm kiếm phòng ban.
        /// </summary>
        /// <param name=”currPage”>Thứ tự trang</param>
        /// <param name=”recodperpage”>Số dòng trên 1 trang</param>
        /// <param name=”Pagesize"”>Trang tối đa</param>
        /// <param name=”p_isDelete”>isDelete</param>
        /// <param name=”cursorParam”>Cursor</param>
        /// Created by (BuiCongDai) – (25/3/2019)
        /// <remarks></remarks>
        public DataTable GetAllPage(int currPage, int recodperpage, int Pagesize)
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
                    cmd.Parameters.Add("Pagesize", Pagesize);
                    cmd.Parameters.Add("p_isDelete", 1);
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
        public DataTable GetDepartmentAll()
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
            catch (Exception e)
            {
                ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                logger.Debug(e.Message);
                return null;

            }
        }
        // Created by (BuiCongDai) – (25/3/2019)
        DataTable IEntities<Department>.Get()
        {
            throw new NotImplementedException();
        }

        DataTable IEntities<Department>.Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<Department> TranferDataTableToDepartmentList(DataTable dataTable)
        {
            List<Department> employees = new List<Department>();
            foreach (DataRow dr in dataTable.Rows)
            {
                try
                {
                    Department department = new Department();
                    department.DepartmentName = dr["DEPARTMENTNAME"].ToString();
                    employees.Add(department);
                }
                catch (Exception ex)
                {
                    ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Debug(ex.Message);
                    return null;
                }
            }
            return employees;
        }
    }
}
