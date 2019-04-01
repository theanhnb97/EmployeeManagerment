namespace CommonLibrary
{
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="DataTable2List{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTable2List<T>
    {
        /// <summary>
        /// The ConvertDataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The dt<see cref="DataTable"/></param>
        /// <returns>The <see cref="List{T}"/></returns>
        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        /// <summary>
        /// The GetItem
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The dr<see cref="DataRow"/></param>
        /// <returns>The <see cref="T"/></returns>
        public T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        /// <summary>
        /// The GetItem
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr">The dr<see cref="OracleDataReader"/></param>
        /// <returns>The <see cref="T"/></returns>
        public T GetItem<T>(OracleDataReader dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
