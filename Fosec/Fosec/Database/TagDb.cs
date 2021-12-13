using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class TagDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public SqlDataReader DisplayTags()
        {
            string query = "select tagName from Tag";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader r = cmd.ExecuteReader();
            return r;
        }
    }
}