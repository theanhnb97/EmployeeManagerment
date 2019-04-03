namespace DataAccessLayer
{
    using DataAccessLayer.Helpers;
    using Entity;
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Action = Entity.Action;

    /// <summary>
    /// Defines the <see cref="IAction" />
    /// </summary>
    interface IAction : IEntities<Action>
    {
        /// <summary>
        /// The GetByName
        /// </summary>
        /// <param name="name">The name<see cref="string"/></param>
        /// <returns>The <see cref="Action"/></returns>
        Action GetByName(string name);
    }

    /// <summary>
    /// Defines the <see cref="ActionDAL" />
    /// </summary>
    public class ActionDAL : IAction
    {
        /// <summary>
        /// Defines the sql
        /// </summary>
        protected SqlHelpers<Action> sql = new SqlHelpers<Action>();

        /// <summary>
        /// Defines the logger
        /// </summary>
        protected ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The GetList
        /// </summary>
        /// <returns>The <see cref="List{Action}"/></returns>
        public List<Action> GetList()
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_GetAll";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sql.ExcuteQueryDataReader(cmd, CommandType.StoredProcedure, con, myParameters);
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
                String cmd = "Action_GetAll";
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
        /// <returns>The <see cref="Action"/></returns>
        public Action GetByName(string name)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_Get";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("names",name),
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                List<Action> myList = sql.ExcuteQueryDataReader(cmd, CommandType.StoredProcedure, con, myParameters);
                if (myList != null)
                    return myList[0];
                return null;
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
                String cmd = "Action_Delete";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionids",id)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Action"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Action obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                String cmd = "Action_Update";
                OracleParameter[] myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionids",obj.ActionID),
                    new OracleParameter("actionnames",obj.ActionName),
                    new OracleParameter("isdeletes",obj.IsDelete),
                    new OracleParameter("descriptions",obj.Description)
                };
                return sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Action"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Action obj)
        {
            using (OracleConnection con = Connection.GetConnection)
            {
                try
                {
                    String cmd = "Action_Insert";
                    OracleParameter[] myParameters = new OracleParameter[]
                    {
                        new OracleParameter("actionnames", obj.ActionName),
                        new OracleParameter("isdeletes", obj.IsDelete),
                        new OracleParameter("descriptions", obj.Description)
                    };
                    sql.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                    Action newActionAdd = GetByName(obj.ActionName);
                    DataTable listRoles = new DataTable();
                    RolesDAL myRoles = new RolesDAL();
                    RolesActionDAL myRolesAction = new RolesActionDAL();
                    listRoles = myRoles.Get();
                    foreach (DataRow item in listRoles.Rows)
                    {
                        RolesAction myRolesActionAdd = new RolesAction
                        {
                            ID = 0,
                            ActionID = newActionAdd.ActionID,
                            IsTrue = 0,
                            RolesID = int.Parse(item[0].ToString())
                        };
                        if (myRolesAction.Add(myRolesActionAdd) != -1)
                        {
                            return 0;
                        }
                    }
                    return -1;
                }
                catch (Exception e)
                {
                    logger.Debug(e.Message);
                    return 0;
                }
            }
        }
    }
}
