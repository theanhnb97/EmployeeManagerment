using System;

namespace Entity
{
    public class Task
    {
        /// <summary>
        /// 
        /// </summary>
        public int  TaskId { get; set; }    

        /// <summary>
        /// 
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Assign { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Files { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
    }
}
