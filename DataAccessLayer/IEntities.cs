using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public interface IEntities<T>
    {
        /// <summary>
        /// Get All Data from DB to List
        /// </summary>
        /// <returns></returns>
        DataTable Get();

        /// <summary>
        /// Search T From DB
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        DataTable Search(string keyword);
        
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
