using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class EmployeeMapper
    {
        public List<Employee> CreateMappingList(List<EmployeeDTO> employeeDtos)
        {
            List<Employee> employees = new List<Employee>();
            foreach (var employeeDto in employeeDtos)
            {
                Employee employee = new Employee
                {
                    EmployeeId = employeeDto.EMPLOYEEID,
                    Email = employeeDto.EMAIL,
                    Identity = employeeDto.IDENTITY,
                    //Password = employeeDto.PASSWORD,
                    Phone = employeeDto.PHONE,
                    Rank = employeeDto.RANK,
                    //RolesId = employeeDto.ROLESID,
                    //Status = employeeDto.STATUS,
                    UserName = employeeDto.USERNAME,
                    //Address = employeeDto.ADDRESS,
                    DepartmentId = employeeDto.DEPARTMENTID,
                    //IsDelete = employeeDto.ISDELETE,
                    FullName = employeeDto.FULLNAME
                };
                employees.Add(employee);
            }

            return employees;
        }

        public Employee CreateMapping(EmployeeDTO employeeDto)
        {
            Employee employee = new Employee();
            if (employeeDto == null) return employee;
            employee.EmployeeId = employeeDto.EMPLOYEEID;
            employee.Email = employeeDto.EMAIL;
            employee.Identity = employeeDto.IDENTITY;
            //employee.Password = employeeDto.PASSWORD;
            employee.Phone = employeeDto.PHONE;
            employee.Rank = employeeDto.RANK;
            //employee.RolesId = employeeDto.ROLESID;
            //employee.Status = employeeDto.STATUS;
            employee.UserName = employeeDto.USERNAME;
            //employee.Address = employeeDto.ADDRESS;
            employee.DepartmentId = employeeDto.DEPARTMENTID;
            //employee.IsDelete = employeeDto.ISDELETE;
            employee.FullName = employeeDto.FULLNAME;

            return employee;
        }
    }
}
