using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Entity;

namespace BusinessLayer
{
    public class RolesActionBUS
    {
        RolesActionDAL myDal=new RolesActionDAL();
        public DataTable GetTrue(int id)
        {
            return myDal.GetAllTrue(id);
        }
        public DataTable Get()
        {
            return myDal.Get();
        }

        public int Add(RolesAction obj)
        {
            return myDal.Add(obj);
        }
        public int Delete(int id)
        {
            return myDal.Delete(id);
        }

        public int Update(RolesAction[] obj)
        {
            return myDal.Update(obj);
        }
    }
}
