using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    public class Active
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <param name="name">The name<see cref="string"/></param>
        public Active(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
