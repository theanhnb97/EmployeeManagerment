namespace BusinessLayer
{
    using DataAccessLayer;
    using Entity;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="DepartmentBUS" />
    /// </summary>
    public class DepartmentBUS
    {
        /// <summary>
        /// Defines the departmentDal
        /// </summary>
        internal DepartmentDAL departmentDal = new DepartmentDAL();

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="department">The department<see cref="Department"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Department department)
        {
            return departmentDal.Add(department);
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAll()
        {
            return departmentDal.GetAll();
        }

        /// <summary>
        /// The GetDepartmentByStatusAndIsDelete
        /// </summary>
        /// <param name="status">The status<see cref="int"/></param>
        /// <param name="isDeleted">The isDeleted<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetDepartmentByStatusAndIsDelete(int status, int isDeleted)
        {
            return departmentDal.GetDepartmentByStatusAndIsDelete(status, isDeleted);
        }

        /// <summary>
        /// The GetDepartmentsForSearch
        /// </summary>
        /// <returns>The <see cref="List{Department}"/></returns>
        public List<Department> GetDepartmentsForSearch()
        {
            DataTable data = departmentDal.GetDepartmentByStatusAndIsDelete(1, 0);
            List<Department> departments = departmentDal.TranferDataTableToDepartmentList(data);
            departments.Add(new Department
            {
                DepartmentName = "",
                DepartmentID = 0,
                Description = "",
                Status = 1,
                IsDelete = 0
            });
            return departments;
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            return departmentDal.Delete(id);
        }

        /// <summary>
        /// The GetById
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetById(int id)
        {
            return departmentDal.GetById(id);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="department">The department<see cref="Department"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Department department)
        {
            return departmentDal.Update(department);
        }

        /// <summary>
        /// The SearchDepartment
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable SearchDepartment(string keyword)
        {
            return departmentDal.SearchDepartment(keyword);
        }

        /// <summary>
        /// The DeleteNoRemove
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteNoRemove(int id)
        {
            return departmentDal.DeleteNoRemove(id);
        }

        /// <summary>
        /// The GetAllPage
        /// </summary>
        /// <param name="currPage">The currPage<see cref="int"/></param>
        /// <param name="recodperpage">The recodperpage<see cref="int"/></param>
        /// <param name="Pagesize">The Pagesize<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAllPage(int currPage, int recodperpage, int Pagesize)
        {
            return departmentDal.GetAllPage(currPage, recodperpage, Pagesize);
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
            return departmentDal.SearchDepartment(keyword, currPage, recodperpage, Pagesize);
        }

        /// <summary>
        /// The GetDepartmentAll
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetDepartmentAll()
        {
            return departmentDal.GetDepartmentAll();
        }
    }
}
