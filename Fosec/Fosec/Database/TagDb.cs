using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public static class TagDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public static List<string> GetAllTags()
        {
            List<string> tagList = new List<string>();
            string query = "select tagName from Tag";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    tagList.Add(r.GetString(0));
                }
            }
            return tagList;
        }

        public static int GetTagIdByTagName(string tagName)
        {
            string query = "select tagId from Tag where tagName = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", tagName);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                return r.GetInt32(0);
            }
            return -1;
        }

        public static string GetTagNameByTagId(int tagId)
        {
            string query = "select tagName from Tag where tagId = @0";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@0", tagId);
            SqlDataReader r = cmd.ExecuteReader();

            if (r.HasRows)
            {
                r.Read();
                return r.GetString(0);
            }

            else
            {
                return "nothing";
            }
        }
    }
}