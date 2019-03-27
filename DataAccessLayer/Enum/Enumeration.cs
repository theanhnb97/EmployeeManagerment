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
    }
}
