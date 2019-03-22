using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer
{
    class SqlHelp
    {
        /// <summary>
        /// Excute Query return DataTable
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="con"></param>
        /// <param name="sP"></param>
        /// <returns></returns>
        /// 
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
        /// Excute query non return sqldata
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="commandType"></param>
        /// <param name="con"></param>
        /// <param name="sP"></param>
        /// <returns></returns>
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
