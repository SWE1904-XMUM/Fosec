using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.Database
{
    public class UserDb
    {
        ConnectionProvider con = new ConnectionProvider();

        public void insertUsers(string username, string email, string pwd)
        {
            con.sqlQuery("insert into Users values('"+username+"','"+email+"','"+pwd+"')");
        }
    }
}