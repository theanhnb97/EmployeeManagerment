namespace DataAccessLayer
{
    using System.Data;

    /// <summary>
    /// Defines the <see cref="IEntities{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntities<T>
    {

        /// <summary>
        /// Delete and return result
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// Update and return result
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Update(T obj);

        /// <summary>
        /// Add and return result
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Add(T obj);
    }
}
