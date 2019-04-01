namespace Entity
{
    using System;

    /// <summary>
    /// Defines the <see cref="Task" />
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the TaskId
        /// </summary>
        public Int64 TaskId { get; set; }

        /// <summary>
        /// Gets or sets the TaskName
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or sets the Assign
        /// </summary>
        public int Assign { get; set; }

        /// <summary>
        /// Gets or sets the DueDate
        /// </summary>
        public string DueDate { get; set; }

        /// <summary>
        /// Gets or sets the Priority
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the Files
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the IsDelete
        /// </summary>
        public int IsDelete { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}
