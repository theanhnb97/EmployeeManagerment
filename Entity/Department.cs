using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Department
    {   //Mã phòng ban
        public Int64 DepartmentID { get; set; }
        //Tên phòng ban
        public string DepartmentName { get; set; }
        //Status phòng ban
        public  Int64 Status { get; set; }
        //Biến xóa phòng ban
        public Int64 IsDelete { get; set; }
        //Mô tả phòng ban
        public string Description { get; set; }
    }
}
