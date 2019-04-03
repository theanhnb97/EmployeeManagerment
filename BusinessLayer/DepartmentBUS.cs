using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccessLayer;
using CommonLibrary.Model;

namespace BusinessLayer
{
    public class DepartmentBUS
    {
        DepartmentDAL departmentDal=new DepartmentDAL();
        public int Add(Department department)
        {
            return departmentDal.Add(department);

        }
        public DataTable GetAll()
        {
            return departmentDal.GetAll();

        }

        public DataTable GetDepartmentByStatusAndIsDelete(int status, int isDeleted)
        {
            return departmentDal.GetDepartmentByStatusAndIsDelete(status, isDeleted);
        }


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

        public int Delete(int id)
        {
            return departmentDal.Delete(id);
        }
        public DataTable GetById(int id)
        {
            return departmentDal.GetById(id);

        }

        public int Update(Department department)
        {
            return departmentDal.Update(department);
        }

        

        public int DeleteNoRemove(int id)
        {
            return departmentDal.DeleteNoRemove(id);
        }

        public DataTable GetAllPage(int currPage, int recodperpage)
        {
            return departmentDal.GetAllPage(currPage, recodperpage);
        }

       public  DataTable SearchDepartment(string keyword)
        {
            return departmentDal.SearchDepartment(keyword );
        }

        public DataTable GetDepartmentAll()
        {
            return departmentDal.GetDepartmentAll();
        }

        public List<Active> GetAllActive()
        {
            return departmentDal.GetAllActive();
        }
    }
}
