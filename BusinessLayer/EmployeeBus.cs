using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class EmployeeBus
    {
        private readonly EmployeeDao myEmployeeDao=new EmployeeDao();
        public bool Login(string UserName, string Password)
        {
            return myEmployeeDao.Login(UserName, Password);
        }
    }
}
