namespace Entity
{
    /// <summary>
    /// Defines the <see cref="Employee" />
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the EmployeeId
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the RolesId
        /// </summary>
        public int RolesId { get; set; }

        /// <summary>
        /// Gets or sets the DepartmentId
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the Rank
        /// </summary>
        public byte Rank { get; set; }

        /// <summary>
        /// Gets or sets the FullName
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Identity
        /// </summary>
        public string Identity { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDelete
        /// </summary>
        public bool IsDelete { get; set; }
    }
}
