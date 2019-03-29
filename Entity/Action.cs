using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Action
    {
        public Int64 ActionID { get; set; }
        public string ActionName { get; set; }
        public Int64 IsDelete { get; set; }
        public string Description { get; set; }
    }
}
