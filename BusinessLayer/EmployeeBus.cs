﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entity;
using Entity.DTO;

namespace BusinessLayer
{
    public class EmployeeBus
    {
        private readonly EmployeeDao employeeDao =new EmployeeDao();

        public bool Login(string UserName, string Password)
        {
            return employeeDao.Login(UserName, Password);
        }

        public List<EmployeeDTO> GetAll()
        {
            return employeeDao.GetAll();
        }

        public int Insert(Employee employee)
        {
            return employeeDao.Add(employee);
        }

        public int Update(Employee employee)
        {
            return employeeDao.Update(employee);
        }

        public int Delete(int employeeId)
        {
            return employeeDao.Delete(employeeId);
        }
    }
}
