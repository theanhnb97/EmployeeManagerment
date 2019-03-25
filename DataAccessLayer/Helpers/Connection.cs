using System;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;


namespace DataAccessLayer.Helpers
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
