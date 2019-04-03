namespace DataAccessLayer
{
    using DataAccessLayer.Helpers;
    using Entity;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="IRoles" />
    /// </summary>
    interface IRoles : IEntities<Roles>
    {
    }

    /// <summary>
    /// Defines the <see cref="RolesDAL" />
    /// </summary>
    public class RolesDAL : IRoles
    {
        /// <summary>
        /// Defines the sql
        /// </summary>
        protected SqlHelpers<RolesAction> sqlHelpers = new SqlHelpers<RolesAction>();

        /// <summary>
        /// Defines the logger
        /// </summary>
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Roles_GetAll";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("roles",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sqlHelpers.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The GetByName
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <returns>The <see cref="Roles"/></returns>
        public Roles GetByName(string name)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Roles_Get";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("name",name),
                    new OracleParameter("role",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                var myList = sqlHelpers.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                if (myList.Rows.Count < 1)
                    return null;
                return new Roles
                {
                    RolesID = int.Parse(myList.Rows[0]["RolesID"].ToString()),
                    RolesName = myList.Rows[0]["RolesName"].ToString(),
                    IsDelete = int.Parse(myList.Rows[0]["IsDelete"].ToString()),
                    Description = myList.Rows[0]["Description"].ToString()
                };
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
            using (var con = Connection.GetConnection)
            {
                string cmd = "Roles_Delete";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesId",id)
                };
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Roles"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Roles obj)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Roles_Update";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesId",obj.RolesID),
                    new OracleParameter("rolesName",obj.RolesName),
                    new OracleParameter("isDelete",obj.IsDelete),
                    new OracleParameter("description",obj.Description)
                };
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Roles"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Roles obj)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Roles_Insert";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("_rolesName",obj.RolesName),
                    new OracleParameter("_isDelete",obj.IsDelete),
                    new OracleParameter("_description",obj.Description)
                };
                sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                var newAdd = GetByName(obj.RolesName);
                var myActionDal = new ActionDAL();
                var myRolesAction = new RolesActionDAL();
                var listRoles = myActionDal.Get();
                foreach (DataRow item in listRoles.Rows)
                {
                    var myRolesActionAdd = new RolesAction
                    {
                        ID = 0,
                        ActionID = int.Parse(item["ActionID"].ToString()),
                        IsTrue = 0,
                        RolesID = newAdd.RolesID
                    };
                    if (myRolesAction.Add(myRolesActionAdd) != -1)
                        return 0;
                }
                return -1;
            }
        }
    }
}
