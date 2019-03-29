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
        private readonly EmployeeDao employeeDao = new EmployeeDao();
        private readonly DepartmentBUS departmentBus = new DepartmentBUS();
        private  readonly DepartmentDAL departmentDal = new DepartmentDAL();


        public int Login(string UserName, string Password)
        {
            return myEmployeeDao.Login(UserName, Password);
        }

        public List<EmployeeDTO> GetAll()
        {
            return MapperEmployeeDtos(employeeDao.GetAll());
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
        public Employee GetBId(int id)
        {
            return employeeDao.GetById(id);
        }


        public List<EmployeeDTO> Search(Employee employee)
        {
            return employeeDao.Search(employee);
        }

        public Employee GetByEmployeeId(int employeeId)
        {
            return employeeDao.GetByEmployeeId(employeeId);
        }

        public List<EmployeeDTO> MapperEmployeeDtos(List<EmployeeDTO> employeeDtos)
        {
            foreach (var employeeDto in employeeDtos)
            {
                employeeDto.RankName = Enumerator.GetDescription((Enumeration.Rank)employeeDto.RANK);
                employeeDto.DepartmentName =
                    departmentDal.TranferDataTableToDepartmentList(
                        departmentBus.GetById(Convert.ToInt32(employeeDto.DEPARTMENTID)))[0].DepartmentName;
            }

            return employeeDtos;
        }
    }
}
