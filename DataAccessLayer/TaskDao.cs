namespace DataAccessLayer
{
    using CommonLibrary.Model;
    using DataAccessLayer.Helpers;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;

    /// <summary>
    /// interface for Task
    /// </summary>
    interface ITaskDao
    {
        //Get All Task
        /// <summary>
        /// The GetAll
        /// </summary>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetAll(int page);

        /// <summary>
        /// Search task
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="department"></param>
        /// <param name="dueDate"></param>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns></returns>
        DataTable Filter(string taskName, Int64 department, string dueDate, int page);

        // get all Department
        /// <summary>
        /// The LoadDepartment
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable LoadDepartment();

        // get employee follow department
        /// <summary>
        /// The LoadEmployeeByDpt
        /// </summary>
        /// <param name="departmentId">The departmentId<see cref="Int64"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable LoadEmployeeByDpt(Int64 departmentId);

        // insert task
        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="objTask">The objTask<see cref="Entity.Task"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Insert(Entity.Task objTask);

        // get all employees
        /// <summary>
        /// The GetAllEmployee
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetAllEmployee();

        // get priority
        /// <summary>
        /// The GetAlLevel
        /// </summary>
        /// <returns>The <see cref="List{Level}"/></returns>
        List<Level> GetAlLevel();

        //delete task
        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="Int64"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(Int64 id);

        /// <summary>
        /// update task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <param name="assign"></param>
        /// <param name="dueDate"></param>
        /// <param name="priority"></param>
        /// <param name="file"></param>
        /// <param name="status"></param>
        /// <param name="isDelete"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        int Update(Int64 taskId, string taskName, Int64 assign, string dueDate, int priority, string file, int status, int isDelete, string description);
    }

    /// <summary>
    /// class TaskDao inheritance interface ITaskDao
    /// </summary>
    public class TaskDao : ITaskDao
    {
        /// <summary>
        /// Defines the objSqlHelpers
        /// </summary>
        private readonly SqlHelpers<Entity.Task> objSqlHelpers = new SqlHelpers<Entity.Task>();

        /// <summary>
        /// Defines the logger
        /// </summary>
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns></returns>
        public DataTable GetAll(int page)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                {
                    new OracleParameter("cursorParam", OracleDbType.RefCursor, ParameterDirection.Output)
                };
                if (page != 0)
                {
                    int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
                    listParameters = new OracleParameter[]
                    {
                        new OracleParameter("numberpage",page),
                        new OracleParameter("pagesize",pageSize),
                        new OracleParameter("cursorParam", OracleDbType.RefCursor, ParameterDirection.Output)
                    };
                    return objSqlHelpers.ExcuteQuery("TASK_GETALL", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
                }
                return objSqlHelpers.ExcuteQuery("TASK_GETALL1", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (OracleException e)
            {
                logger.Debug(e);
                return null;
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return null;
            }
            finally
            {
                Connection.GetConnection.Close();
            }
        }

        /// <summary>
        /// The Filter
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="department"></param>
        /// <param name="dueDate"></param>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns></returns>
        public DataTable Filter(string taskName, Int64 department, string dueDate, int page)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                  {

                            new OracleParameter("taskNames", OracleDbType.NVarchar2,taskName,ParameterDirection.Input),
                            new OracleParameter("departments", OracleDbType.Int32,department, ParameterDirection.Input),
                            new OracleParameter("dueDates", OracleDbType.Varchar2,dueDate, ParameterDirection.Input),
                            new OracleParameter("cursorParam",OracleDbType.RefCursor,ParameterDirection.Output)
                 };
                if (page != 0)
                {
                    int pageSize = int.Parse(ConfigurationManager.AppSettings["pageSize"]);
                    listParameters = new OracleParameter[]
                    {
                        new OracleParameter("numberpage",page),
                        new OracleParameter("pagesize",pageSize),
                        new OracleParameter("taskNames", OracleDbType.NVarchar2,taskName,ParameterDirection.Input),
                        new OracleParameter("departments", OracleDbType.Int32,department, ParameterDirection.Input),
                        new OracleParameter("dueDates", OracleDbType.Varchar2,dueDate, ParameterDirection.Input),
                        new OracleParameter("cursorParam",OracleDbType.RefCursor,ParameterDirection.Output)
                    };
                    return objSqlHelpers.ExcuteQuery("TASK_FILTER_PAGING", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
                }
                return objSqlHelpers.ExcuteQuery("TASK_FILTER", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return null;
            }
        }

        /// <summary>
        /// get all department
        /// </summary>
        /// <returns> DataTable</returns>
        public DataTable LoadDepartment()
        {
            try
            {

                OracleParameter[] listParameters = new OracleParameter[]
                {
                    new OracleParameter("cursorParam", OracleDbType.RefCursor, ParameterDirection.Output)
                };
                return objSqlHelpers.ExcuteQuery("Department_Getall", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (OracleException e)
            {
                logger.Debug(e);
                return null;
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return null;
            }
            finally
            {
                Connection.GetConnection.Close();
            }
        }

        /// <summary>
        /// The LoadEmployeeByDpt
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns> DataTable</returns>
        public DataTable LoadEmployeeByDpt(Int64 departmentId)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                {
                    new OracleParameter("IDS", OracleDbType.Int64,departmentId,ParameterDirection.Input),
                    new OracleParameter("cursorParam", OracleDbType.RefCursor,ParameterDirection.Output),
                };
                return objSqlHelpers.ExcuteQuery("DEPARTMENT_GETEMPLOYEEBYDEPARTMENT", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return null;

            }
            finally
            {
                Connection.GetConnection.Close();
            }
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="objTask"></param>
        /// <returns>number</returns>
        public int Insert(Entity.Task objTask)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                          {
                new OracleParameter("taskNames",OracleDbType.NVarchar2,objTask.TaskName,ParameterDirection.Input),
                new OracleParameter("assigns",OracleDbType.Int64,objTask.Assign,ParameterDirection.Input),
                new OracleParameter("dueDates",OracleDbType.Varchar2, objTask.DueDate,ParameterDirection.Input),
                new OracleParameter("priorities", OracleDbType.Int32,objTask.Priority,ParameterDirection.Input),
                new OracleParameter("filess",OracleDbType.Varchar2,objTask.Files,ParameterDirection.Input),
                new OracleParameter("Statuses", OracleDbType.Int32,objTask.Status,ParameterDirection.Input),
                new OracleParameter("isDeletes", OracleDbType.Int32, objTask.IsDelete,ParameterDirection.Input),
                new OracleParameter("descriptions",OracleDbType.NVarchar2,objTask.Description,ParameterDirection.Input)
                          };
                return objSqlHelpers.ExcuteNonQuery("Task_Insert", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return 0;
            }
            finally
            {
                Connection.GetConnection.Close();
            }
        }

        /// <summary>
        /// The GetAllEmployee
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllEmployee()
        {
            OracleParameter[] listParameters = new OracleParameter[]
            {
                new OracleParameter("CURSOR_", OracleDbType.RefCursor,ParameterDirection.Output)
            };
            return objSqlHelpers.ExcuteQuery("Employee_GetAll", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
        }

        /// <summary>
        /// The GetAlLevel
        /// </summary>
        /// <returns>list priority</returns>
        public List<Level> GetAlLevel()
        {
            List<Level> list = new List<Level>
            {
                new Level(1,"High"),
                new Level(2,"Medium"),
                new Level(3,"Low")
            };
            return list;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns>number</returns>
        public int Delete(Int64 id)
        {
            try
            {
                if (id != 0)
                {
                    OracleParameter[] listParameters = new OracleParameter[]
               {
                            new OracleParameter("ID", OracleDbType.Int64,id,ParameterDirection.Input),
               };
                    return objSqlHelpers.ExcuteNonQuery("Task_Delete", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return 0;
            }
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <param name="assign"></param>
        /// <param name="dueDate"></param>
        /// <param name="priority"></param>
        /// <param name="file"></param>
        /// <param name="status"></param>
        /// <param name="isDelete"></param>
        /// <param name="description"></param>
        /// <returns>number</returns>
        public int Update(Int64 taskId, string taskName, Int64 assign, string dueDate, int priority, string file, int status, int isDelete, string description)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                          {
                new OracleParameter("ID", OracleDbType.Int64,taskId,ParameterDirection.Input),
                new OracleParameter("TaskNames", OracleDbType.NVarchar2,taskName,ParameterDirection.Input),
                new OracleParameter("Assigns", OracleDbType.Int64,assign,ParameterDirection.Input),
                new OracleParameter("DueDates", OracleDbType.Varchar2,dueDate,ParameterDirection.Input),
                new OracleParameter("Priorities", OracleDbType.Int32,priority,ParameterDirection.Input),
                new OracleParameter("Filess", OracleDbType.Varchar2,file,ParameterDirection.Input),
                new OracleParameter("Statuses", OracleDbType.Int32,status,ParameterDirection.Input),
                new OracleParameter("IsDeletes", OracleDbType.Int32,isDelete,ParameterDirection.Input),
                new OracleParameter("Descriptions", OracleDbType.NVarchar2,description,ParameterDirection.Input),
                          };
                return objSqlHelpers.ExcuteNonQuery("Task_Update", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
            }
            catch (Exception e)
            {
                logger.Debug(e);
                return 0;
            }
        }
    }
}
