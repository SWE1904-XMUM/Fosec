using Fosec.Utils;
using System.Data.SqlClient;

namespace Fosec.Database
{
    public static class UserDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public static bool InsertUser(string username, string email)
        {
            string query = "insert into Users (username, email) values (@0,@1)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", username);
            cmd.Parameters.AddWithValue("@1", email);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool InsertPassword(string uname, string pwd)
        {
            string userId = GetUserIdByUsername(uname).ToString();
            string query = "update Users set pwd = @0 where username = @1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", HashUtil.GetHashedStringByInput(string.Concat(pwd, userId)));
            cmd.Parameters.AddWithValue("@1", uname);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static int GetUserIdByUsername(string uname)
        {
            string query = "select userId from Users where username = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", uname);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                return r.GetInt32(0);
            }
            return -1;
        }

        public static bool CheckExistingUser(string uname)
        {
            string query = "select username from Users where username = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", uname);
            SqlDataReader r = cmd.ExecuteReader();

            return (r.HasRows && r.Read());
        }

        public static bool CheckExistingEmail(string email)
        {
            string query = "select email from Users where email = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", email);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool CheckUserPassword(string uname, string pwd)
        {
            string userId = GetUserIdByUsername(uname).ToString();
            string query = "select pwd from Users where username = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", uname);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                bool compare = HashUtil.CompareHash(r.GetString(0), string.Concat(pwd, userId));
                return compare.Equals(true);
            }
            return false;
        }

        public static bool UpdateUserProfileImage(int userid, byte[] profileImage)
        {
            string query = "update Users set profileImage = @0 where userId = @1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", profileImage);
            cmd.Parameters.AddWithValue("@1", userid);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool UpdateUserPassword(int userid, string pwd)
        {
            string query = "update users set pwd=@0 where userid=@1";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", HashUtil.GetHashedStringByInput(string.Concat(pwd, "2")));
            cmd.Parameters.AddWithValue("@1", userid);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool CheckUserIdExistence(int userid)
        {
            string query = "select username from users where userid=@0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", userid);
            SqlDataReader r = cmd.ExecuteReader();

            return (r.HasRows && r.Read());
        }
    }
}