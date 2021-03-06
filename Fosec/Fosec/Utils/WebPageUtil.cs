using System.Web;
using System.Web.UI;

namespace Fosec.Utils
{
    public static class WebPageUtil
    {
        public static void DisplayMessage(string message)
        {
            HttpContext.Current.Response.Write("<script>alert('" + message + "')</script>");
        }

        public static void DisplayMessageAndRedirect(string message, string location, Page page)
        {
            string cScript = @"<script type='text/javascript'>alert( '" + message + "');location.href='" + location + "';</script>";
            page.ClientScript.RegisterStartupScript(typeof(Page), "", cScript);
        }

        public static void Redirect(string location, Page page)
        {
            string cScript = @"<script type='text/javascript'>location.href='" + location + "';</script>";
            page.ClientScript.RegisterStartupScript(typeof(Page), "", cScript);
        }
    }
}