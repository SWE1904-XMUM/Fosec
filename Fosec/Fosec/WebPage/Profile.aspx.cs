using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fosec.Session;

namespace Fosec.WebPage
{
    public partial class Profile : System.Web.UI.Page
    {
        // Class initialization
        SessionManager sessionManager = new SessionManager();

        string uname;

        protected void Page_Load(object sender, EventArgs e)
        {
            uname = sessionManager.GetUsername();
        }
    }
}