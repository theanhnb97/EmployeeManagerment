namespace CommonLibrary.Model
{
    using System;

    /// <summary>
    /// Defines the <see cref="TaskDTO" />
    /// </summary>
    public static class TaskDTO
    {
        /// <summary>
        /// Gets or sets the TaskId
        /// </summary>
        public static Int64 TaskId { get; set; }

        /// <summary>
        /// Gets or sets the TaskName
        /// </summary>
        public static string TaskName { get; set; }

        /// <summary>
        /// Gets or sets the Assign
        /// </summary>
        public static Int64 Assign { get; set; }

        /// <summary>
        /// Gets or sets the DueDate
        /// </summary>
        public static string DueDate { get; set; }

        /// <summary>
        /// Gets or sets the Priority
        /// </summary>
        public static int Priority { get; set; }

        /// <summary>
        /// Gets or sets the Files
        /// </summary>
        public static string Files { get; set; }

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public static int Status { get; set; }

        /// <summary>
        /// Gets or sets the IsDelete
        /// </summary>
        public static int IsDelete { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public static string Description { get; set; }

        /// <summary>
        /// Gets or sets the Department
        /// </summary>
        public static int Department { get; set; }
    }
}
