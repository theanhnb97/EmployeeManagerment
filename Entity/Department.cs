using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public  int Status { get; set; }
        public int IsDelete { get; set; }
        public string Description { get; set; }
    }
}
