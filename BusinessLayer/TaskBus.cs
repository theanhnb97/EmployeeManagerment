using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    interface ITaskBus
    {
        DataTable GetAll();
        DataTable Filter(string taskName, int department, DateTime dueDate);

    }
    /// <summary>
    /// 
    /// </summary>
    public class TaskBus : ITaskBus
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            
            TaskDao objTaskDao = new TaskDao();
            return objTaskDao.GetAll();
        }

        public DataTable Filter(string taskName, int department, DateTime dueDate)
        {
             TaskDao objTaskDao = new TaskDao();
             return objTaskDao.Filter(taskName, department, dueDate);
        }
    }
}

