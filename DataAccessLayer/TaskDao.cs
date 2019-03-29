using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DataAccessLayer.Helpers;
using Oracle.ManagedDataAccess.Client;
using CommonLibrary.Model;
using log4net;

namespace DataAccessLayer
{
    interface ITaskDao
    {

        DataTable GetAll();
        DataTable Filter(string taskName, int department, string dueDate);
        DataTable LoadDepartment();
        DataTable LoadEmployeeByDpt(int departmentId);
        int Insert(Entity.Task objTask);
        DataTable GetAllEmployee();
        List<Level> GetAlLevel();
        int Delete(int id);
        int Update(int taskId, string taskName, int assign, string dueDate, int priority, string file, int status, int isDelete, string description);
    }
    public class TaskDao : ITaskDao
    {
        private readonly SqlHelpers<Task> objSqlHelpers = new SqlHelpers<Task>();
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public DataTable Filter(string taskName, int department, string dueDate)
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

        public DataTable LoadEmployeeByDpt(int departmentId)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                {
                    new OracleParameter("IDS", OracleDbType.Int32,departmentId,ParameterDirection.Input),
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

        public int Insert(Entity.Task objTask)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                          {
                new OracleParameter("taskNames",OracleDbType.NVarchar2,objTask.TaskName,ParameterDirection.Input),
                new OracleParameter("assigns",OracleDbType.Int32,objTask.Assign,ParameterDirection.Input),
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

        public DataTable GetAllEmployee()
        {
            OracleParameter[] listParameters = new OracleParameter[]
            {
                new OracleParameter("CURSOR_", OracleDbType.RefCursor,ParameterDirection.Output)
            };
            return objSqlHelpers.ExcuteQuery("Employee_GetAll", CommandType.StoredProcedure, Connection.GetConnection, listParameters);
        }


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

        public int Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    OracleParameter[] listParameters = new OracleParameter[]
               {
                            new OracleParameter("ID", OracleDbType.Int32,id,ParameterDirection.Input),
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

        public int Update(int taskId, string taskName, int assign, string dueDate, int priority, string file, int status, int isDelete, string description)
        {
            try
            {
                OracleParameter[] listParameters = new OracleParameter[]
                          {
                new OracleParameter("ID", OracleDbType.Int32,taskId,ParameterDirection.Input),
                new OracleParameter("TaskNames", OracleDbType.NVarchar2,taskName,ParameterDirection.Input),
                new OracleParameter("Assigns", OracleDbType.Int32,assign,ParameterDirection.Input),
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
