using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    public class EmployeeDTO
    {
        /// <summary>
        /// Gets or sets the EmployeeId
        /// </summary>
        public Int64 EMPLOYEEID { get; set; }

        /// <summary>
        /// Gets or sets the RolesId
        /// </summary>
        ///public Int64 ROLESID { get; set; }

        /// <summary>
        /// Gets or sets the DepartmentId
        /// </summary>
        public Int64 DEPARTMENTID { get; set; }

        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the Rank
        /// </summary>
        public Int16 RANK { get; set; }

        public string RankName { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FULLNAME { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string USERNAME { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        ///public string PASSWORD { get; set; }

        /// <summary>
        /// Gets or sets the Identity
        /// </summary>
        public string IDENTITY { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        ///public string ADDRESS { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        public string PHONE { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string EMAIL { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        ///public Int16 STATUS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDelete
        /// </summary>
        ///public Int16 ISDELETE { get; set; }
    }
}
