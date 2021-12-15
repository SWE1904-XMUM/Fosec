using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.Session
{
    public static class SessionManager
    {
        private static readonly string LOGIN = "login";
        private static readonly string UNAME = "UNAME";

        public static void SetLogin(bool login)
        {
            HttpContext.Current.Session[LOGIN] = login;
        }

        public static void SetUsername(string uname)
        {
            HttpContext.Current.Session[UNAME] = uname;
        }

        public static string GetUsername()
        {
            if (HttpContext.Current.Session[UNAME] != null)
            {
                return HttpContext.Current.Session["uname"].ToString();
            }
            return "";
        }
    }
}