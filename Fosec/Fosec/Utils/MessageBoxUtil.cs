using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.Utils
{
    public static class MessageBoxUtil
    {
        public static void DisplayMessage(string message)
        {
            HttpContext.Current.Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}