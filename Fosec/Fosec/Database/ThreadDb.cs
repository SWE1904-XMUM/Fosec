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
    }
}