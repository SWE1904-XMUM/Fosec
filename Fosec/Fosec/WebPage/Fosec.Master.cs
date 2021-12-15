using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fosec.Database;
using Fosec.Session;
using Fosec.Utils;

namespace Fosec
{
    public partial class Fosec : System.Web.UI.MasterPage
    {
        string unameTxt, pwdTxt;

        // Class initialization
        MessageBoxUtil messageBox = new MessageBoxUtil();
        UserDb userDb = new UserDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = SessionManager.GetUsername();

            guestActionBar.Visible = (username == "");
            loggedInActionBar.Visible = (username != "");
            
            if(username != "")
            {
                loggedInUsername.InnerText = username;
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            GetLoginTxt();

            bool checkExistingUser = userDb.CheckExistingUser(unameTxt);
            bool checkPassword = userDb.CheckUserPassword(unameTxt, pwdTxt);

            if (checkExistingUser.Equals(true))
            {
                if (checkPassword.Equals(true))
                {
                    // TODO -> link to Home page
                    //Response.Redirect("Home.aspx");
                    SessionManager.SetLogin(true);
                    SessionManager.SetUsername(unameTxt);
                }

                else
                {
                    messageBox.MessageBox("Invalid password!");
                    pwd.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            else
            {
                messageBox.MessageBox("Not an existing user, please signup!");
            }
        }

        private void GetLoginTxt()
        {
            unameTxt = uname.Text;
            pwdTxt = pwd.Text;
        }
    }
}