using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class ConnectionProvider
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Fosec.mdf;Integrated Security=True; MultipleActiveResultSets=true;");

        private ConnectionProvider() { }

        public static SqlConnection GetDatabaseConnection()
        {
            if(connection.State != System.Data.ConnectionState.Open)
            {
                OpenDatabaseConnection();
            }
            return connection;
        }

        public static void OpenDatabaseConnection()
        {
            connection.Open();
        }

        public static void CloseDatabaseConnection()
        {
            connection.Close();
        }
    }
}