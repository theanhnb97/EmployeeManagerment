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
        DataTable GetAll();
        DataTable Filter(string taskName, int department, string dueDate);
        DataTable LoadDepartment();
        int Insert(Entity.Task objTask);
        DataTable LoadEmployeeByDpt(int departmentId);
        DataTable GetAllEmployee();
        List<Level> GetAlLevel();
        int Delete(int id);
        int Update(int taskId, string taskName, int assign, string dueDate, int priority, string file, int status, int isDelete, string description);
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
        public DataTable GetAll()
        {

            return objTaskDao.GetAll();
        }

        public DataTable Filter(string taskName, int department, string dueDate)
        {
            return objTaskDao.Filter(taskName, department, dueDate);
        }

        public DataTable LoadDepartment()
        {
            return objTaskDao.LoadDepartment();
        }

        public int Insert(Entity.Task objTask)
        {
            return objTaskDao.Insert(objTask);
        }

        public DataTable LoadEmployeeByDpt(int departmentId)
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

        public int Delete(int id)
        {
            return objTaskDao.Delete(id);
        }

        public int Update(int taskId, string taskName, int assign, string dueDate,
            int priority, string file, int status, int isDelete, string description)
        {
            return objTaskDao.Update(taskId, taskName, assign, dueDate, priority, file, status, isDelete, description);
        }


    }

}

