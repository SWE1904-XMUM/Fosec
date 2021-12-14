using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class ThreadDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public SqlDataReader DisplayThreadContent()
        {
            string query = "select content from Threads";
            SqlCommand cmd = new SqlCommand(query, connection);
            return cmd.ExecuteReader();
        }
    }
   

}