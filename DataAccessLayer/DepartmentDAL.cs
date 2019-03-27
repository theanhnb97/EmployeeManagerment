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
        public int Add(Department department)
        {
            try
            {
                SqlHelpers<Department> sqlHelp=new SqlHelpers<Department>();
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

        public DataTable GetAll()
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_GetAllDeltete", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
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

        public DataTable GetById(int id)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_GetById", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_departmentID", id);
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

        public List<Department> Search(string keyword)
        {
            throw new NotImplementedException();
        }

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
        public DataTable SearchDepartment(string keyword)
        {
            try
            {
                SqlHelpers<Department> sqlHelp = new SqlHelpers<Department>();
                using (OracleConnection connection = Connection.GetConnection)
                {
                    OracleDataAdapter da = new OracleDataAdapter();
                    OracleCommand cmd = new OracleCommand();

                    cmd = new OracleCommand("Department_Search", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("p_departmentName", keyword);
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
        public DataTable GetAllPage(int currPage,int recodperpage,int Pagesize)
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
        DataTable IEntities<Department>.Get()
        {
            throw new NotImplementedException();
        }

        DataTable IEntities<Department>.Search(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
