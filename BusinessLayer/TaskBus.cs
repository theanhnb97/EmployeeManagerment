namespace BusinessLayer
{
    using CommonLibrary.Model;
    using DataAccessLayer;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="ITaskBus" />
    /// </summary>
    interface ITaskBus
    {
        /// <summary>
        /// The GetAll
        /// </summary>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetAll(int page);

        /// <summary>
        /// The Filter
        /// </summary>
        /// <param name="taskName">The taskName<see cref="string"/></param>
        /// <param name="department">The department<see cref="Int64"/></param>
        /// <param name="dueDate">The dueDate<see cref="string"/></param>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable Filter(string taskName, Int64 department, string dueDate, int page);

        /// <summary>
        /// The LoadDepartment
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable LoadDepartment();

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="objTask">The objTask<see cref="Entity.Task"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Insert(Entity.Task objTask);

        /// <summary>
        /// The LoadEmployeeByDpt
        /// </summary>
        /// <param name="departmentId">The departmentId<see cref="Int64"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable LoadEmployeeByDpt(Int64 departmentId);

        /// <summary>
        /// The GetAllEmployee
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetAllEmployee();

        /// <summary>
        /// The GetAlLevel
        /// </summary>
        /// <returns>The <see cref="List{Level}"/></returns>
        List<Level> GetAlLevel();

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="Int64"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Delete(Int64 id);

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="taskId">The taskId<see cref="Int64"/></param>
        /// <param name="taskName">The taskName<see cref="string"/></param>
        /// <param name="assign">The assign<see cref="Int64"/></param>
        /// <param name="dueDate">The dueDate<see cref="string"/></param>
        /// <param name="priority">The priority<see cref="int"/></param>
        /// <param name="file">The file<see cref="string"/></param>
        /// <param name="status">The status<see cref="int"/></param>
        /// <param name="isDelete">The isDelete<see cref="int"/></param>
        /// <param name="description">The description<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        int Update(Int64 taskId, string taskName, Int64 assign, string dueDate, int priority, string file, int status, int isDelete, string description);
    }

    /// <summary>
    /// Defines the <see cref="TaskBus" />
    /// </summary>
    public class TaskBus : ITaskBus
    {
        /// <summary>
        /// Defines the objTaskDao
        /// </summary>
        private readonly TaskDao objTaskDao = new TaskDao();

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns></returns>
        public DataTable GetAll(int page)
        {
            return objTaskDao.GetAll(page);
        }

        /// <summary>
        /// The Filter
        /// </summary>
        /// <param name="taskName">The taskName<see cref="string"/></param>
        /// <param name="department">The department<see cref="Int64"/></param>
        /// <param name="dueDate">The dueDate<see cref="string"/></param>
        /// <param name="page">The page<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Filter(string taskName, Int64 department, string dueDate, int page)
        {
            return objTaskDao.Filter(taskName, department, dueDate, page);
        }

        /// <summary>
        /// The LoadDepartment
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable LoadDepartment()
        {
            return objTaskDao.LoadDepartment();
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="objTask">The objTask<see cref="Entity.Task"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Insert(Entity.Task objTask)
        {
            return objTaskDao.Insert(objTask);
        }

        /// <summary>
        /// The LoadEmployeeByDpt
        /// </summary>
        /// <param name="departmentId">The departmentId<see cref="Int64"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable LoadEmployeeByDpt(Int64 departmentId)
        {
            return objTaskDao.LoadEmployeeByDpt(departmentId);
        }

        /// <summary>
        /// The GetAllEmployee
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAllEmployee()
        {
            return objTaskDao.GetAllEmployee();
        }

        /// <summary>
        /// The GetAlLevel
        /// </summary>
        /// <returns>The <see cref="List{Level}"/></returns>
        public List<Level> GetAlLevel()
        {
            return objTaskDao.GetAlLevel();
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="Int64"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(Int64 id)
        {
            return objTaskDao.Delete(id);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="taskId">The taskId<see cref="Int64"/></param>
        /// <param name="taskName">The taskName<see cref="string"/></param>
        /// <param name="assign">The assign<see cref="Int64"/></param>
        /// <param name="dueDate">The dueDate<see cref="string"/></param>
        /// <param name="priority">The priority<see cref="int"/></param>
        /// <param name="file">The file<see cref="string"/></param>
        /// <param name="status">The status<see cref="int"/></param>
        /// <param name="isDelete">The isDelete<see cref="int"/></param>
        /// <param name="description">The description<see cref="string"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Int64 taskId, string taskName, Int64 assign, string dueDate,
            int priority, string file, int status, int isDelete, string description)
        {
            return objTaskDao.Update(taskId, taskName, assign, dueDate, priority, file, status, isDelete, description);
        }
    }
}
