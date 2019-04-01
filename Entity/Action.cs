namespace Entity
{
    using System;

    /// <summary>
    /// Defines the <see cref="Action" />
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Gets or sets the ActionID
        /// </summary>
        public Int64 ActionID { get; set; }

        /// <summary>
        /// Gets or sets the ActionName
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// Gets or sets the IsDelete
        /// </summary>
        public Int64 IsDelete { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
    }
}
