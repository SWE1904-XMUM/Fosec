using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fosec.Session;

namespace Fosec
{
    public partial class Fosec : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionManager.SetUsername("testuser");
            string username = SessionManager.GetUsername();
            //TODO get login status
            guestActionBar.Visible = (username == "");
            loggedInActionBar.Visible = (username != "");
            
            if(username != "")
            {
                loggedInUsername.InnerText = username;
            }
        }
    }
}