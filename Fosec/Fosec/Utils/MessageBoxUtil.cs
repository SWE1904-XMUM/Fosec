using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fosec.Utils
{
    public class MessageBoxUtil
    {
        public void MessageBox(string message)
        {
            HttpContext.Current.Response.Write("<script>alert('" + message + "')</script>");
        }
    }
}