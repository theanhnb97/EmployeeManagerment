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
        protected SqlHelpers<RolesAction> sql = new SqlHelpers<RolesAction>();

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
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The GetByName
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <returns>The <see cref="Roles"/></returns>
        public Roles GetByName(string name)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Get";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("names",name),
                    new OracleParameter("listReturn",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                DataTable myList = sql.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                if (myList.Rows.Count < 1)
                    return null;
                return new Roles
                {
                    RolesID = int.Parse(myList.Rows[0][0].ToString()),
                    RolesName = myList.Rows[0][1].ToString(),
                    IsDelete = int.Parse(myList.Rows[0][2].ToString()),
                    Description = myList.Rows[0][3].ToString()
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
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Delete";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesids",id)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Roles"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Roles obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Update";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesids",obj.RolesID),
                    new OracleParameter("rolesnames",obj.RolesName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Roles"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Roles obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Roles_Insert";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("rolesnames",obj.RolesName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                Roles newAdd = GetByName(obj.RolesName);
                DataTable listRoles = new DataTable();
                ActionDAL myActionDal = new ActionDAL();
                RolesActionDAL myRolesAction = new RolesActionDAL();
                listRoles = myActionDal.Get();
                foreach (DataRow item in listRoles.Rows)
                {
                    RolesAction myRolesActionAdd = new RolesAction
                    {
                        ID = 0,
                        ActionID = int.Parse(item[0].ToString()),
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
