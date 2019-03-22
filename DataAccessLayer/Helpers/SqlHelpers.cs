namespace DataAccessLayer
{
    using log4net;
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;

    /// <summary>
    /// Defines the <see cref="SqlHelpers" />
    /// </summary>
    internal class SqlHelpers
    {
        /// <summary>
        /// Defines the _logger
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The ExcuteQuery
        /// </summary>
        /// <param name="queryString">The queryString<see cref="String"/></param>
        /// <param name="commandType">The commandType<see cref="CommandType"/></param>
        /// <param name="con">The con<see cref="OracleConnection"/></param>
        /// <param name="sP">The sP<see cref="OracleParameter[]"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public DataTable ExcuteQuery(String queryString, CommandType commandType, OracleConnection con, OracleParameter[] sP)
        {
            try
            {
                OracleCommand cmd = new OracleCommand(queryString, con);
                cmd.CommandType = commandType;
                if (sP != null)
                    cmd.Parameters.AddRange(sP);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (OracleException e)
            {
                _logger.Debug(e.Message);
                return null;
            }
        }

        /// <summary>
        /// The ExcuteNonQuery
        /// </summary>
        /// <param name="queryString">The queryString<see cref="String"/></param>
        /// <param name="commandType">The commandType<see cref="CommandType"/></param>
        /// <param name="con">The con<see cref="OracleConnection"/></param>
        /// <param name="sP">The sP<see cref="OracleParameter[]"/></param>
        /// <returns>The <see cref="int"/></returns>
        public int ExcuteNonQuery(String queryString, CommandType commandType, OracleConnection con, OracleParameter[] sP)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(queryString, con);
                cmd.CommandType = commandType;
                if (sP != null)
                    cmd.Parameters.AddRange(sP);
                return cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                _logger.Debug(e.Message);
                return 0;
            }
        }
    }
}
