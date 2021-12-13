using Fosec.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class UserDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public static void InsertUsers(string username, string email, string pwd)
        {
            string query = "insert into Users values (@0,@1,@2)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", username);
            cmd.Parameters.AddWithValue("@1", email);
            cmd.Parameters.AddWithValue("@2", HashUtil.GetHashedStringByInput(pwd));
            cmd.ExecuteNonQuery();
            ConnectionProvider.InitCon().Close();
        }
    }
}