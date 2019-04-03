namespace DataAccessLayer
{
    using Helpers;
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


    public class ActionDAL : IAction
    {

        protected SqlHelpers<Action> sqlHelpers = new SqlHelpers<Action>();
        protected ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The GetList
        /// </summary>
        /// <returns>The <see cref="List{Action}"/></returns>
        public List<Action> GetList()
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Action_GetAll";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("listAction",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sqlHelpers.ExcuteQueryDataReader(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable Get()
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Action_GetAll";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("Actions",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                return sqlHelpers.ExcuteQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }


        public Action GetByName(string name)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Action_Get";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("name",name),
                    new OracleParameter("Actions",OracleDbType.RefCursor,ParameterDirection.Output)
                };
                var myList = sqlHelpers.ExcuteQueryDataReader(cmd, CommandType.StoredProcedure, con, myParameters);
                return myList[0];
            }
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
                string cmd = "Action_Delete";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionId",id)
                };
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Update
        /// </summary>
        /// <param name="obj">The obj<see cref="Action"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Update(Action model)
        {
            using (var con = Connection.GetConnection)
            {
                string cmd = "Action_Update";
                var myParameters = new OracleParameter[]
                {
                    new OracleParameter("actionId",model.ActionID),
                    new OracleParameter("actionName",model.ActionName),
                    new OracleParameter("isDelete",model.IsDelete),
                    new OracleParameter("descriptions",model.Description)
                };
                return sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
            }
        }

        /// <summary>
        /// The Add
        /// </summary>
        /// <param name="obj">The obj<see cref="Action"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int Add(Action model)
        {
            using (var con = Connection.GetConnection)
            {
                try
                {
                    string cmd = "Action_Insert";
                    var myParameters = new OracleParameter[]
                    {
                        new OracleParameter("actionName", model.ActionName),
                        new OracleParameter("isDelete", model.IsDelete),
                        new OracleParameter("description", model.Description)
                    };
                    sqlHelpers.ExcuteNonQuery(cmd, CommandType.StoredProcedure, con, myParameters);
                    var newActionAdd = GetByName(model.ActionName);
                    var myRoles = new RolesDAL();
                    var myRolesAction = new RolesActionDAL();
                    var listRoles = myRoles.Get();
                    foreach (DataRow item in listRoles.Rows)
                    {
                        var myRolesActionAdd = new RolesAction
                        {
                            ID = 0,
                            ActionID = newActionAdd.ActionID,
                            IsTrue = 0,
                            RolesID = int.Parse(item[0].ToString())
                        };
                        if (myRolesAction.Add(myRolesActionAdd) != -1)
                            return 0;
                    }
                    return -1;
                }
                catch (Exception e)
                {
                    _logger.Debug(e.Message);
                    return 0;
                }
            }
        }
    }
}
