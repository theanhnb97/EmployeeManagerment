namespace BusinessLayer
{
    using DataAccessLayer;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="ActionBUS" />
    /// </summary>
    public class ActionBUS
    {
        /// <summary>
        /// Defines the myAtionDal
        /// </summary>
        internal ActionDAL myAtionDal = new ActionDAL();

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            return myAtionDal.Get();
        }

        /// <summary>
        /// The GetList
        /// </summary>
        /// <returns>The <see cref="List{Entity.Action}"/></returns>
        public List<Entity.Action> GetList()
        {
            return myAtionDal.GetList();
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Entity.Action"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Entity.Action obj)
        {
            return myAtionDal.Add(obj);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            return myAtionDal.Delete(id);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Entity.Action"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Entity.Action obj)
        {
            return myAtionDal.Update(obj);
        }
    }
}
