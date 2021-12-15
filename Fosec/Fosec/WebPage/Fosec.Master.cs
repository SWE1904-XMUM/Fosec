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
            //TODO get login status
            guestActionBar.Visible = (SessionManager.GetUsername() == "");
            loggedInActionBar.Visible = (SessionManager.GetUsername() != "");
        }
    }
}