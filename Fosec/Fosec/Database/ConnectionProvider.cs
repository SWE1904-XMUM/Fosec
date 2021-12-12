using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class ConnectionProvider
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Fosec.mdf;Integrated Security=True");

        public void sqlQuery(string query)
        {
            con.Open();
            SqlCommand com = new SqlCommand(query,con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}