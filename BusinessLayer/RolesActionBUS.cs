namespace BusinessLayer
{
    using DataAccessLayer;
    using Entity;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="RolesActionBUS" />
    /// </summary>
    public class RolesActionBUS
    {
        /// <summary>
        /// Defines the myDal
        /// </summary>
        internal RolesActionDAL myDal = new RolesActionDAL();

        /// <summary>
        /// The GetTrue
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetTrue(int id)
        {
            return myDal.GetAllTrue(id);
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            return myDal.Get();
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="RolesAction"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(RolesAction obj)
        {
            return myDal.Add(obj);
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            return myDal.Delete(id);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="List{RolesAction}"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(List<RolesAction> obj)
        {
            return myDal.Update(obj);
        }

        /// <summary>
        /// The DeleteAll
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteAll()
        {
            return myDal.DeleteAll();
        }
    }
}
