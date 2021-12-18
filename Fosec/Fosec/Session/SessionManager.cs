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
        private static readonly string TAG = "TAG";

        public static void SetLogin(string login)
        {
            HttpContext.Current.Session[LOGIN] = login;
        }

        public static string GetLogin()
        {
            if(HttpContext.Current.Session[LOGIN] != null)
            {
                return HttpContext.Current.Session[LOGIN].ToString();
            }
            return "";
        }

        public static void SetUsername(string uname)
        {
            HttpContext.Current.Session[UNAME] = uname;
        }

        public static string GetUsername()
        {
            if (HttpContext.Current.Session[UNAME] != null)
            {
                return HttpContext.Current.Session[UNAME].ToString();
            }
            return "";
        }

        public static void RemoveUsername()
        {
            if(HttpContext.Current.Session[UNAME] != null)
            {
                HttpContext.Current.Session.Remove(UNAME);
            }
        }

        public static void SetTag(string tagName)
        {
            HttpContext.Current.Session[TAG] = tagName;
        }

        public static string GetTag()
        {
            if(HttpContext.Current.Session[TAG] != null)
            {
                return HttpContext.Current.Session[TAG].ToString();
            }

            return "";
        }
    }
}