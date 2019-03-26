using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class SalaryView
    {
        public string FullName { get; set; }
        public string Identity { get; set; }
        public int Rank { get; set; }
        public string Dept { get; set; }
        public int Basic { get; set; }
        public int Bussiness { get; set; }
        public float Coefficient { get; set; }
        public double Total { get; set; }
    }
}
