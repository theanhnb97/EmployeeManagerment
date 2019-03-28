using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Enumerator;
using DataAccessLayer;
using DataAccessLayer.Enum;
using Entity;
using Entity.DTO;

namespace BusinessLayer
{
    public class EmployeeBus
    {
        private readonly EmployeeDao myEmployeeDao=new EmployeeDao();

        public int Login(string UserName, string Password)
        {
            return myEmployeeDao.Login(UserName, Password);
        }

        public List<EmployeeDTO> GetAll()
        {

            return MapperEmployeeDtos(myEmployeeDao.GetAll());
        }

        public int Insert(Employee employee)
        {
            return myEmployeeDao.Add(employee);
        }

        public int Update(Employee employee)
        {
            return myEmployeeDao.Update(employee);
        }

        public int Delete(int employeeId)
        {
            return myEmployeeDao.Delete(employeeId);
        }

        public List<EmployeeDTO> Search(Employee employee)
        {
            return myEmployeeDao.Search(employee);
        }

        public Employee GetByEmployeeId(int employeeId)
        {
            return myEmployeeDao.GetByEmployeeId(employeeId);
        }

        public List<EmployeeDTO> MapperEmployeeDtos(List<EmployeeDTO> employeeDtos)
        {
            foreach (var employeeDto in employeeDtos)
            {
                employeeDto.RankName = Enumerator.GetDescription((Enumeration.Rank) employeeDto.RANK);
            }

            return employeeDtos;
        }
        
    }
}
