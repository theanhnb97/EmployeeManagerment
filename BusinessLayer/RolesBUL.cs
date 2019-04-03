namespace BusinessLayer
{
    using DataAccessLayer;
    using Entity;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="RolesBUL" />
    /// </summary>
    public class RolesBUL
    {
        /// <summary>
        /// Defines the myDal
        /// </summary>
        internal RolesDAL myDal = new RolesDAL();

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
        /// <param name="obj">The obj<see cref="Roles"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Roles obj)
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
        /// <param name="obj">The obj<see cref="Roles"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Roles obj)
        {
            return myDal.Update(obj);
        }
    }
}
