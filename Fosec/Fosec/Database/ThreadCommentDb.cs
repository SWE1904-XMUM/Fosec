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

        public bool insertThreadComment(int UserID, int threadID, String comment)
        {
            string query = "insert into ThreadComment (userID,threadID,comment) values (@2,@3,@4)"; //no idea how to insert without adding a date manually
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@2", UserID);
            cmd.Parameters.AddWithValue("@3", threadID);
            cmd.Parameters.AddWithValue("@4", comment);
           // cmd.Parameters.AddWithValue("@5", Date);
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
