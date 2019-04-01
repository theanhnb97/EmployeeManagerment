namespace Entity.DTO
{
    using System;

    /// <summary>
    /// Defines the <see cref="EmployeeDTO" />
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// Gets or sets the EMPLOYEEID
        /// </summary>
        public Int64 EMPLOYEEID { get; set; }

        /// <summary>
        /// Gets or sets the DEPARTMENTID
        /// </summary>
        public Int64 DEPARTMENTID { get; set; }

        /// <summary>
        /// Gets or sets the DepartmentName
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the RANK
        /// </summary>
        public Int16 RANK { get; set; }

        /// <summary>
        /// Gets or sets the RankName
        /// </summary>
        public string RankName { get; set; }

        /// <summary>
        /// Gets or sets the FULLNAME
        /// </summary>
        public string FULLNAME { get; set; }

        /// <summary>
        /// Gets or sets the USERNAME
        /// </summary>
        public string USERNAME { get; set; }

        /// <summary>
        /// Gets or sets the IDENTITY
        /// </summary>
        public string IDENTITY { get; set; }

        /// <summary>
        /// Gets or sets the PHONE
        /// </summary>
        public string PHONE { get; set; }

        /// <summary>
        /// Gets or sets the EMAIL
        /// </summary>
        public string EMAIL { get; set; }
    }
}
