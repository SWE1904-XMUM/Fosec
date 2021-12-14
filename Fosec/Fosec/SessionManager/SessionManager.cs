using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.SessionManager
{
    public class SessionManager
    {
        public void SetLogin(bool login)
        {
            HttpContext.Current.Session["login"] = login;
        }

        public void SetUsername(string uname)
        {
            HttpContext.Current.Session["uname"] = uname;
        }

        public string GetUsername()
        {
            return HttpContext.Current.Session["uname"].ToString();
        }
    }
}