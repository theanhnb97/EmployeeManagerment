namespace DataAccessLayer
{
    using DataAccessLayer.Helpers;
    using Entity;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="IRolesAction" />
    /// </summary>
    interface IRolesAction : IEntities<RolesAction>
    {
        /// <summary>
        /// The GetAllTrue
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetAllTrue(int id);

        /// <summary>
        /// The DeleteAll
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        int DeleteAll();
    }

    /// <summary>
    /// Defines the <see cref="RolesActionDAL" />
    /// </summary>
    public class RolesActionDAL : IRolesAction
    {
        /// <summary>
        /// Defines the sql
        /// </summary>
        protected SqlHelpers<RolesAction> sql = new SqlHelpers<RolesAction>();

        /// <summary>
        /// Defines the logger
        /// </summary>
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The GetAllTrue
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAllTrue(int id)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_GetAllTrue";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("ids",id),
                    new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                List<RolesAction> myList = sql.ExcuteQueryList(cmd, CommandType.StoredProcedure, con, myParameters);
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The DeleteAll
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteAll()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_Scan";
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, null);
            }
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Search
        /// </summary>
        /// <param name="keyword">The keyword<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Search(string keyword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Delete
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="RolesAction"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(RolesAction obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="List{RolesAction}"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(List<RolesAction> obj)
        {
            String cmd = "RolesAction_Update";
            foreach (RolesAction item in obj)
            {
                OracleParameter[] myParameters = new OracleParameter[]
                {
                        new OracleParameter("ids",item.ID),
                        new OracleParameter("istrues",item.IsTrue)
                };
                using (OracleConnection con = Connection.GetConnection)
                    sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
            return -1;
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="RolesAction"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(RolesAction obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "RolesAction_Insert";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionids",obj.ActionID),
                    new OracleParameter("rolesids",obj.RolesID),
                    new OracleParameter("istrues",obj.IsTrue)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }
    }
}
