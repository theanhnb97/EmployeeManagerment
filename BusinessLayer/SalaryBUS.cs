using DataAccessLayer;
using Entity;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public interface ISalaryBUS
    {
        List<SalaryView> GetData();
        List<SalaryView> SearchSalary(string name, string dept, DateTime fDate, DateTime tDate);
        int Add(Salary obj);
        int Delete(int id);
        int Update(Salary obj);
        Salary GetById(int id);
    }
    public class SalaryBUS : ISalaryBUS
    {
        SalaryDAO SalaryDAO = new SalaryDAO();
        public int Add(Salary obj)
        {
            return SalaryDAO.Add(obj);
        }

        public int Delete(int id)
        {
            return SalaryDAO.Delete(id);
        }

        public Salary GetById(int id)
        {
            return SalaryDAO.GetById(id);
        }

        public List<SalaryView> GetData()
        {
            return SalaryDAO.GetData();
        }

        public List<SalaryView> SearchSalary(string name, string dept, DateTime fDate, DateTime tDate)
        {
            return SalaryDAO.SearchSalary(name, dept, fDate, tDate);
        }

        public int Update(Salary obj)
        {
            return SalaryDAO.Update(obj);
        }
    }
}
