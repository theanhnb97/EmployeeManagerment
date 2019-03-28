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
    public class RolesBUL
    {
        RolesDAL myDal = new RolesDAL();
        public DataTable Get()
        {
            return myDal.Get();
        }

        public int Add(Roles obj)
        {
            return myDal.Add(obj);
        }
        public int Delete(int id)
        {
            return myDal.Delete(id);
        }

        public int Update(Roles obj)
        {
            return myDal.Update(obj);
        }
    }
}
