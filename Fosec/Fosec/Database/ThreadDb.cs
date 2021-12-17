using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public static class ThreadDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public static bool InsertThread(int userId, string title, int tagNo, string content)
        {
            string query = "insert into Threads (userId, title, tagNo, content) values (@0,@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", userId);
            cmd.Parameters.AddWithValue("@1", title);
            cmd.Parameters.AddWithValue("@2", tagNo);
            cmd.Parameters.AddWithValue("@3", content);
            int insert = cmd.ExecuteNonQuery();

            if (insert > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
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

            else
            {
                return false;
            }
        }

        public static bool DeleteThread(string threadId)
        {
            string query = "delete Threads where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            int delete = cmd.ExecuteNonQuery();

            if (delete > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static SqlDataReader GetThreadContent(int threadId)
        {
            string query = "select title, tagNo, content from Threads where threadId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", threadId);
            return cmd.ExecuteReader();
        }

        public int GetUserID(String threadId)
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

            else
            {
                return -1;
            }
        }
    }
}