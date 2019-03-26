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
        DepartmentDAL departmentDal=new DepartmentDAL();
        public int Add(Department department)
        {
            return departmentDal.Add(department);

        }
        public DataTable GetAll()
        {
            return departmentDal.GetAll();

        }

        public int Delete(int id)
        {
            return departmentDal.Delete(id);
        }

    }
}
