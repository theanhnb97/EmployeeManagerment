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
        ActionDAL myAtionDal=new ActionDAL();  
        public DataTable Get()
        {
            return myAtionDal.Get();
        }

        public int Add(Entity.Action obj)
        {
            return myAtionDal.Add(obj);
        }
        public int Delete(int id)
        {
            return myAtionDal.Delete(id);
        }

        public int Update(Entity.Action obj)
        {
            return myAtionDal.Update(obj);
        }
    }
}
