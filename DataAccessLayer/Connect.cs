using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Dynamic;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;


namespace DataAccessLayer
{
    public class Connect
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
