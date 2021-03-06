using System;
using System.Data.SqlClient;

namespace Fosec.Database
{
    public static class ThreadDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();
        public readonly static int MAX_CONTENT_LENGTH = 999;
        public readonly static int MAX_TITLE_LENGTH = 150;

        public static int InsertThread(int userId, string title, int tagNo, string content)
        {
            string query = "insert into Threads (userId, title, tagNo, content) values (@0,@1,@2,@3); select scope_identity()";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", userId);
            cmd.Parameters.AddWithValue("@1", title);
            cmd.Parameters.AddWithValue("@2", tagNo);
            cmd.Parameters.AddWithValue("@3", content);
            int insert = Convert.ToInt32(cmd.ExecuteScalar());

            return insert;
        }

        public static bool EditThread(int threadId, string title, int tagNo, string content)
        {
            string query = "update Threads set title = @0 ,tagNo = @1, content = @2 where threadId = @3";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", title);
            cmd.Parameters.AddWithValue("@1", tagNo);
            cmd.Parameters.AddWithValue("@2", content);
            cmd.Parameters.AddWithValue("@3", threadId);
            int update = cmd.ExecuteNonQuery();

            if (update > 0)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteThread(string threadId)
        {
            string query = "delete Threads where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            int delete = cmd.ExecuteNonQuery();

            if (delete > 0)
            {
                bool deleteComment = ThreadCommentDb.DeleteThreadComment(threadId);

                if (deleteComment.Equals(true))
                {
                    return true;
                }
            }
            return false;
        }

        public static (string, string, int) GetThreadContentByThreadId(int threadId)
        {
            string query = "select title, tagNo, content from Threads where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows && r.Read())
            {
                return (r.GetString(0), r.GetString(2), r.GetInt32(1));
            }
            return ("", "", -1);
        }

        public static int GetUserIdByThreadId(String threadId)
        {
            string query = "select userId from Threads where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                return r.GetInt32(0);
            }
            return -1;
        }

        public static bool CheckThreadExistence(int threadId)
        {
            string query = "select threadId from threads where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            return cmd.ExecuteReader().HasRows;
        }
    }
}