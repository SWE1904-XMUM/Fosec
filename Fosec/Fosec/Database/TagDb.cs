using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class TagDb
    {
<<<<<<< HEAD
        public SqlDataReader DisplayTags()
        {
            string query = "select tagName from Tag";
            SqlCommand cmd = new SqlCommand(query, ConnectionProvider.InitCon());
            SqlDataReader r = cmd.ExecuteReader();
            return r;
        }
=======
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();
>>>>>>> e9e837f0d4900471d806bb79819f1c52c235aa7c
    }
}