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

        public bool InsertUsers(string username, string email, string pwd)
        {
            string query = "insert into Users (username, email, pwd) values (@0,@1,@2)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", username);
            cmd.Parameters.AddWithValue("@1", email);
            cmd.Parameters.AddWithValue("@2", HashUtil.GetHashedStringByInput(pwd));
            int insert = cmd.ExecuteNonQuery();
            ConnectionProvider.CloseDatabaseConnection();

            if (insert > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public int GetUserIdWithUsername(string uname)
        {
            string query = "select userId from Users where username = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", uname);
            SqlDataReader r = cmd.ExecuteReader();

            if(r.HasRows)
            {
                return r.GetInt32(0);
            }

            else
            {
                return -1;
            }
        }

        public bool CheckExistingUser(string uname)
        {
            string query = "select username from Users where username = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", uname);
            SqlDataReader r = cmd.ExecuteReader();

            if(r.HasRows)
            { 
                return true; 
            }

            else
            {
                return false;
            }
        }

        public bool CheckUserPassword(string uname, string pwd)
        {
            string query = "select pwd from Users where username = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", uname);
            SqlDataReader r = cmd.ExecuteReader();

            if(r.HasRows)
            {
                bool compare = HashUtil.CompareHash(r.GetOrdinal("pwd").ToString(), pwd);

                if(compare.Equals(true))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }
    }
}