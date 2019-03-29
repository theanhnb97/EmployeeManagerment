using System;
using System.Collections.Generic;
using System.Data;
using CommonLibrary.Model;
using DataAccessLayer;

namespace BusinessLayer
{
    /// <summary>
    /// 
    /// </summary>
    interface ITaskBus
    {
        DataTable GetAll(int page);
        DataTable Filter(string taskName, Int64 department, string dueDate,int page);
        DataTable LoadDepartment();
        int Insert(Entity.Task objTask);
        DataTable LoadEmployeeByDpt(Int64 departmentId);
        DataTable GetAllEmployee();
        List<Level> GetAlLevel();
        int Delete(Int64 id);
        int Update(Int64 taskId, string taskName, Int64 assign, string dueDate, int priority, string file, int status, int isDelete, string description);
    }
    /// <summary>
    /// 
    /// </summary>
    public class TaskBus : ITaskBus
    {
        private readonly TaskDao objTaskDao = new TaskDao();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll(int page)
        {
            return objTaskDao.GetAll(page);
        }

        public DataTable Filter(string taskName, Int64 department, string dueDate, int page)
        {
            return objTaskDao.Filter(taskName, department, dueDate, page);
        }

        public DataTable LoadDepartment()
        {
            return objTaskDao.LoadDepartment();
        }

        public int Insert(Entity.Task objTask)
        {
            return objTaskDao.Insert(objTask);
        }

        public DataTable LoadEmployeeByDpt(Int64 departmentId)
        {
            return objTaskDao.LoadEmployeeByDpt(departmentId);
        }

        public DataTable GetAllEmployee()
        {
            return objTaskDao.GetAllEmployee();
        }

        public List<Level> GetAlLevel()
        {
            return objTaskDao.GetAlLevel();
        }

        public int Delete(Int64 id)
        {
            return objTaskDao.Delete(id);
        }

        public int Update(Int64 taskId, string taskName, Int64 assign, string dueDate,
            int priority, string file, int status, int isDelete, string description)
        {
            return objTaskDao.Update(taskId, taskName, assign, dueDate, priority, file, status, isDelete, description);
        }


    }

}

