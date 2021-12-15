using Fosec.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class ThreadCommentDb
    {
        private static SqlConnection connection = ConnectionProvider.GetDatabaseConnection();

        public bool insertThreadComment(int UserID, String threadID, String comment)
        {
            string query = "insert into ThreadComment (userID,threadID,comment) values (@2,@3,@4)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@2", UserID);
            cmd.Parameters.AddWithValue("@3", threadID);
            cmd.Parameters.AddWithValue("@4", comment);
           
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
    }
}
