using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;


namespace DataAccessLayer
{
    public class Connection
    {
        public static OracleConnection GetConnection
        {
            get
            {
                String conString = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                return new OracleConnection(conString);
            }
        }
    }
}
