using System;
using Fosec.Database;
using Fosec.Session;
using Fosec.Utils;

namespace Fosec
{
    public partial class Fosec : System.Web.UI.MasterPage
    {
        string unameTxt, pwdTxt;

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = SessionManager.GetUsername();

            guestActionBar.Visible = (username == "");
            loggedInActionBar.Visible = (username != "");

            if (username != "")
            {
                loggedInUsername.InnerText = username;
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            GetLoginTxt();

            bool checkExistingUser = UserDb.CheckExistingUser(unameTxt);
            bool checkPassword = UserDb.CheckUserPassword(unameTxt, pwdTxt);

            if (checkExistingUser.Equals(true))
            {
                if (checkPassword.Equals(true))
                {
                    SessionManager.SetLogin("true");
                    SessionManager.SetUsername(unameTxt);
                    WebPageUtil.DisplayMessageAndRedirect("Login successful", "/WebPage/Home.aspx", this.Page);
                }

                else
                {
                    WebPageUtil.DisplayMessage("Invalid password!");
                    pwd.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            else
            {
                WebPageUtil.DisplayMessageAndRedirect("Not an existing user, please signup!", "/WebPage/SignupAndLogin.aspx?action=signup", this.Page);
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            SessionManager.RemoveUsername();
            SessionManager.SetLogin("false");
            Response.Redirect("/WebPage/Home.aspx");
        }

        private void GetLoginTxt()
        {
            unameTxt = uname.Text;
            pwdTxt = pwd.Text;
        }
    }
}