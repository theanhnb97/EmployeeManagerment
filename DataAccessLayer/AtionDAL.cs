using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IAction:IEntities<Action>
    {
        
    }
    public class AtionDAL:DALBase,IAction
    {
        public List<Action> Get()
        {
            throw new NotImplementedException();
        }

        public List<Action> Search(string keyword)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Action obj)
        {
            throw new NotImplementedException();
        }

        public int Add(Action obj)
        {
            throw new NotImplementedException();
        }
    }
}
