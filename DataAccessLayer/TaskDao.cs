using System;
using System.Collections.Generic;
using System.Data;
using DataAccessLayer.Helpers;
using Oracle.ManagedDataAccess.Client;
using CommonLibrary.Model;
using log4net;
using Entity;

namespace DataAccessLayer
{
    /// <summary>
    /// interface for Task
    /// </summary>
    interface ITaskDao
    {
        //Get All Task
        DataTable GetAll();
        /// <summary>
        /// Search task
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="department"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        DataTable Filter(string taskName, Int64 department, string dueDate);

        // get all Department
        DataTable LoadDepartment();
        // get employee follow department
        DataTable LoadEmployeeByDpt(Int64 departmentId);
        // insert task
        int Insert(Entity.Task objTask);
        // get all employees
        DataTable GetAllEmployee();
        // get priority
        List<Level> GetAlLevel();
        //delete task
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
        private readonly SqlHelpers<Entity.Task> objSqlHelpers = new SqlHelpers<Entity.Task>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                {
                    new OracleParameter("cursorParam", OracleDbType.RefCursor, ParameterDirection.Output)
                };

                return objSqlHelpers.ExcuteQuery("TASK_GETALL", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
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
        /// 
        /// </summary>
        /// <param name="taskName"></param>
        /// <param name="department"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        public DataTable Filter(string taskName, Int64 department, string dueDate)
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
                return objSqlHelpers.ExcuteQuery("Department_GetAll", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
