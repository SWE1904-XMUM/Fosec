using System;
using System.Data.SqlClient;

namespace Fosec.Database
{
    public static class ThreadCommentDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public static bool InsertThreadComment(int UserID, String threadID, String comment)
        {
            string query = "insert into ThreadComment (userID,threadID,comment) values (@2,@3,@4)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@2", UserID);
            cmd.Parameters.AddWithValue("@3", threadID);
            cmd.Parameters.AddWithValue("@4", comment);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static bool DeleteThreadComment(string threadId)
        {
            string query = "delete ThreadComment where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            int delete = cmd.ExecuteNonQuery();

            if (delete > 0)
            {
                return true;
            }
            return false;
        }
    }
}
