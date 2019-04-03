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
        /// The Get All Action Checked
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        DataTable GetAllTrue(int id);

        /// <summary>
        /// The Delete All RolesAction to Scan new Table
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        int DeleteAll();
    }


    public class RolesActionDAL : IRolesAction
    {
        /// <summary>
        /// Defines the sql
        /// </summary>
        protected SqlHelpers<RolesAction> sqlHelpers = new SqlHelpers<RolesAction>();

        /// <summary>
        /// Defines the logger to write Log when bug
        /// </summary>
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The GetAllTrue
        /// </summary>
        /// <param name="id">The id<see cref="int"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable GetAllTrue(int id)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "RolesAction_GetAllTrue";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("id",id),
                    new OracleParameter("actionsChecked",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sqlHelpers.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The DeleteAll
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int DeleteAll()
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "RolesAction_Scan";
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, null);
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
                    new OracleParameter("rolesActions",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sqlHelpers.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
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
        public int Update(RolesAction model)
        {
            string cmd = "RolesAction_Update";
            var myParameters = new OracleParameter[]
            {
                new OracleParameter("id",model.ID),
                new OracleParameter("checked",model.IsTrue)
            };
            using (var con = Connection.GetConnection)
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="List{RolesAction}"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(List<RolesAction> models)
        {
            foreach (var item in models)
                Update(item);
            return -1;
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="RolesAction"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(RolesAction obj)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "RolesAction_Insert";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionId",obj.ActionID),
                    new OracleParameter("rolesId",obj.RolesID),
                    new OracleParameter("isTrue",obj.IsTrue)
                };
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }
    }
}
