using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DataAccessLayer
{
    public class EmployeeDao : IEntities<Employee>
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
    }
}
