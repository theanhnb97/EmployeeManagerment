namespace Entity
{
    using System;

    /// <summary>
    /// Defines the <see cref="Salary" />
    /// </summary>
    public class Salary
    {
        /// <summary>
        /// Gets or sets the SalaryId
        /// </summary>
        public int SalaryId { get; set; }

        /// <summary>
        /// Gets or sets the EmployeeId
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the BasicSalary
        /// </summary>
        public int BasicSalary { get; set; }

        /// <summary>
        /// Gets or sets the BussinessSalary
        /// </summary>
        public int BussinessSalary { get; set; }

        /// <summary>
        /// Gets or sets the Coefficient
        /// </summary>
        public float Coefficient { get; set; }

        /// <summary>
        /// Gets or sets the IsDelete
        /// </summary>
        public Boolean IsDelete { get; set; }
    }
}
