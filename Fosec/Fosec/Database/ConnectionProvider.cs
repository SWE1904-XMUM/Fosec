using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class ConnectionProvider
    {
        private static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Fosec.mdf;Integrated Security=True");

        public static SqlConnection InitCon()
        {
            con.Open();
            return con;
        }
    }
}