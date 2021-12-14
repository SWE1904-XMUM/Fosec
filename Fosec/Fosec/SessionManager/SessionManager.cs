using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.SessionManager
{
    public class SessionManager
    {
        public static void SetLogin(bool login)
        {
            HttpContext.Current.Session["login"] = login;
        }

        public static void SetUsername(string uname)
        {
            HttpContext.Current.Session["uname"] = uname;
        }

        public static string GetUsername()
        {
            return HttpContext.Current.Session["uname"].ToString();
        }
    }
}