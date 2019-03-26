using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class ActionBUS
    {
        AtionDAL myAtionDal=new AtionDAL();  
        public DataTable Get()
        {
            return myAtionDal.Get();
        }
    }
}
