using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
    interface IEmployee
    {
        bool Login(string UserName, string Password);
    }

    public class EmployeeDao : IEntities<Employee>,IEmployee
    {

        public List<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public List<Employee> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee obj)
        {
            throw new NotImplementedException();
        }

        public int Add(Employee obj)
        {
            throw new NotImplementedException();
        }

        public bool Login(string UserName, string Password)
        {
            
        }
    }
}
