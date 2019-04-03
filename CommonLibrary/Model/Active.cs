using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Model
{
    public class Active
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Active(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
