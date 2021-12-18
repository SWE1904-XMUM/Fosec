using System;
using System.Data.SqlClient;

namespace Fosec.Database
{
    public static class ThreadCommentDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();
        public readonly static int MAX_CONTENT_LENGTH = 999;

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
            if (GetThreadCommentCount(threadId) <= 0)
            {
                return true;
            }

            string query = "delete ThreadComment where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            int delete = cmd.ExecuteNonQuery();

            return delete > 0;
        }

        public static int GetThreadCommentCount(string threadId)
        {
            string query = "select count(commentid) from threadComment where threadid = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            SqlDataReader r = cmd.ExecuteReader();
            return (r.Read()) ? r.GetInt32(0) : 0;
        }
    }
}
