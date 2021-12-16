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

        public bool InsertThread(int userId, string title, int tagNo, string content)
        {
            string query = "insert into Threads (userId, title, tagNo, content) values (@0,@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", userId);
            cmd.Parameters.AddWithValue("@1", title);
            cmd.Parameters.AddWithValue("@2", tagNo);
            cmd.Parameters.AddWithValue("@3", content);
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

        public bool EditThread(int threadId, string title, int tagNo, string content)
        {
            string query = "update Threads set title = @0 ,tagNo = @1, content = @2 where threadId = @ 3";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", title);
            cmd.Parameters.AddWithValue("@1", tagNo);
            cmd.Parameters.AddWithValue("@2", content);
            cmd.Parameters.AddWithValue("@3", threadId);
            int update = cmd.ExecuteNonQuery();
            ConnectionProvider.CloseDatabaseConnection();

            if (update > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public SqlDataReader DisplayThreadContent()
        {
            string query = "select content from Threads";
            SqlCommand cmd = new SqlCommand(query, connection);
            return cmd.ExecuteReader();
        }
    }
}