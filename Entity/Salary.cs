using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreateDate { get; set; }
        public int BasicSalary { get; set; }
        public int BussinessSalary { get; set; }
        public float Coefficient { get; set; }
        public Boolean IsDelete { get; set; }
    }
}
