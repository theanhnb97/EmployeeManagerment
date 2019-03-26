﻿using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using CommonLibrary;
using Oracle.ManagedDataAccess.Client;

namespace DataAccessLayer.Helpers
{
    /// <summary>
    /// Defines the <see cref="SqlHelpers" />
    /// </summary>
    public class SqlHelpers<T>
    {
        /// <summary>
        /// Defines the _logger
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DataTable2List<T> myDataTable2List = new DataTable2List<T>();


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


        /// <summary>
        /// The ExcuteQuery
        /// </summary>
        /// <param name="queryString">The queryString<see cref="String"/></param>
        /// <param name="commandType">The commandType<see cref="CommandType"/></param>
        /// <param name="con">The con<see cref="OracleConnection"/></param>
        /// <param name="sP">The sP<see cref="OracleParameter[]"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public List<T> ExcuteQueryList(String queryString, CommandType commandType, OracleConnection con, OracleParameter[] sP)
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

                List<T> myList = new List<T>();
                myList = myDataTable2List.ConvertDataTable<T>(dt);
                return myList;
            }
            catch (OracleException e)
            {
                _logger.Debug(e.Message);
                return null;
            }
        }




    }
}