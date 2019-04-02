using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Enum
{
    public class Enumeration
    {
        public enum Status
        {
            [Description("Chính thức")]
            AMember = 1,

            [Description("Thực tập")]
            BIntern = 2,

            [Description("Học việc")]
            CFresher = 3,

            [Description("Có kinh nghiệm")]
            DJunior = 4,

        }

        public enum Rank
        {
            [Description("Giám đốc")]
            DPresident = 1,

            [Description("Phó giám đốc")]
            CVicePrecedent = 2,

            [Description("Trưởng phòng")]
            BManager = 3,

            [Description("Nhân viên")]
            AMember = 4,

        }
        public enum BasicSalary
        {
            [Description("3")]
            Basic1 = 1,
            [Description("4")]
            Basic2 = 2,
            [Description("5")]
            Basic3 = 3,
            [Description("6")]
            Basic4 = 4
        }
        public enum BussinessSalary
        {
            [Description("5")]
            Bussiness1 = 1,
            [Description("6")]
            Bussiness2 = 2,
            [Description("7")]
            Bussiness3 = 3,
            [Description("8")]
            Bussiness4 = 4
        }
       public enum Coefficient
        {
            [Description("2.34")]
            Coe1 =1,
            [Description("2.67")]
            Coe2=2,
            [Description("3.00")]
            Coe3=3,
            [Description("3.33")]
            Coe4=4
        }
    } 
}
