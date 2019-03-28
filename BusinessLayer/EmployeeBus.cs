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
        private readonly EmployeeDao myEmployeeDao=new EmployeeDao();

        public int Login(string UserName, string Password)
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
        public Employee GetBId(int id)
        {
            return employeeDao.GetById(id);
        }

        public List<EmployeeDTO> GetAll()
        {
            return myEmployeeDao.GetAll();
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
    }
}
