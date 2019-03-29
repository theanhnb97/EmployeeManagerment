using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccessLayer;

namespace BusinessLayer
{
    public class DepartmentBUS
    {
        //Khai báo DepartmentDAL
        DepartmentDAL departmentDal=new DepartmentDAL();
        //Thêm phòng ban
        public int Add(Department department)
        {
            return departmentDal.Add(department);

        }
        //Hiển thị danh sách phòng ban
        public DataTable GetAll()
        {
            return departmentDal.GetAll();

        }
        //Delete phòng ban

        public int Delete(int id)
        {
            return departmentDal.Delete(id);
        }
        //Hiển thị phòng ban theo mã phòng ban
        public DataTable GetById(int id)
        {
            return departmentDal.GetById(id);

        }
        //Sửa phòng ban
        public int Update(Department department)
        {
            return departmentDal.Update(department);
        }
        //Tìm kiếm phòng ban
        public DataTable SearchDepartment(string keyword)
        {
            return departmentDal.SearchDepartment(keyword);
        }
        //Xóa phòng ban
        public int DeleteNoRemove(int id)
        {
            return departmentDal.DeleteNoRemove(id);
        }
        //hiển thị phòng ban có phân trang
        public DataTable GetAllPage(int currPage, int recodperpage, int Pagesize)
        {
            return departmentDal.GetAllPage(currPage, recodperpage, Pagesize);
        }

    }
}
