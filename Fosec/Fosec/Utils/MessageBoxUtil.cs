using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Fosec.Utils
{
    public static class MessageBoxUtil
    {
        public static void DisplayMessage(string message)
        {
            HttpContext.Current.Response.Write("<script>alert('" + message + "')</script>");
        }

        public static void DisplayMessageAndRedirect(string message, string location, ClientScriptManager clientScript)
        {
            string cScript = @"<script type='text/javascript'>alert( '" + message + "');location.href='" + location + "';</script>";
            clientScript.RegisterStartupScript(typeof(Page), "", cScript);
        }

        public static void Redirect(string location, ClientScriptManager clientScript)
        {
            string cScript = @"<script type='text/javascript'>location.href='" + location + "';</script>";
            clientScript.RegisterStartupScript(typeof(Page), "", cScript);
        }
    }
}