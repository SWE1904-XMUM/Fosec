using Fosec.Database;
using Fosec.Session;
using Fosec.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fosec.WebPage
{
    public partial class SignupAndLogin : System.Web.UI.Page
    {
        // Login column
        string loginUnameTxt, loginPwdTxt;

        // Signup column
        string signupEmailTxt, signupUnameTxt, signupPwdTxt, signupConfirmPwdTxt;

        protected void Page_Load(object sender, EventArgs e)
        {
            pillsSignUpTab.ServerClick += ActivateSignup;
            pillsLoginTab.ServerClick += ActivateLogin;
            string action = HttpContext.Current.Request["action"];

            if (action == "signup")
            {
                ActivateSignup(sender, e);
            }

            else
            {
                ActivateLogin(sender, e);
            }
        }

        protected void ActivateLogin(object sender, EventArgs e)
        {
            pillsLoginTab.Attributes["class"] = pillsLoginTab.Attributes["class"] + " active";
            pillsSignUpTab.Attributes["class"] = pillsSignUpTab.Attributes["class"].Replace("active", "").Trim();
            pillsLogin.Visible = true;
            pillsSignup.Visible = false;
        }

        protected void ActivateSignup(object sender, EventArgs e)
        {
            pillsSignUpTab.Attributes["class"] = pillsLoginTab.Attributes["class"] + " active";
            pillsLoginTab.Attributes["class"] = pillsSignUpTab.Attributes["class"].Replace("active", "").Trim();
            pillsSignup.Visible = true;
            pillsLogin.Visible = false;
        }

        protected void SignupBtn_Click(object sender, EventArgs e)
        {
            GetSignupInputText();

            string uname = ValidationUtil.ValidateUname(signupUnameTxt);
            string pwd = ValidationUtil.ValidatePassword(signupPwdTxt);
            string email = ValidationUtil.ValidateEmail(signupEmailTxt); //TODO validate whether email already exist

            if (email.Equals("pass") && uname.Equals("pass") && pwd.Equals("pass") && signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                bool checkExistingUser = UserDb.CheckExistingUser(signupUnameTxt);

                if (checkExistingUser.Equals(false))
                {
                    bool insertUser = UserDb.InsertUsers(signupUnameTxt, signupEmailTxt, signupPwdTxt);

                    if (insertUser.Equals(true))
                    {
                        ClearSignupFields();
                        WebPageUtil.DisplayMessageAndRedirect("Signup successfully! Please login.", "/WebPage/SignupAndLogin.aspx?action=login", this.Page);
                    }

                    else
                    {
                        WebPageUtil.DisplayMessage("Fail to signup.");
                    }
                }

                else
                {
                    WebPageUtil.DisplayMessage("Username already existed, please try for another.");
                }
            }

            else if (email != "pass")
            {
                WebPageUtil.DisplayMessage(email);
                signupEmail.BackColor = System.Drawing.Color.LightCoral;
            }

            else if (uname != "pass")
            {
                WebPageUtil.DisplayMessage(uname);
                signupUname.BackColor = System.Drawing.Color.LightCoral;
            }

            else if (pwd != "pass")
            {
                WebPageUtil.DisplayMessage(pwd);
                signupPwd.BackColor = System.Drawing.Color.LightCoral;
            }

            else if (!signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                WebPageUtil.DisplayMessage("Please enter same password!");
                signupConfirmPwd.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            GetLoginInputText();

            bool checkExistingUser = UserDb.CheckExistingUser(loginUnameTxt);
            bool checkPassword = UserDb.CheckUserPassword(loginUnameTxt, loginPwdTxt);

            if (checkExistingUser.Equals(true))
            {
                if (checkPassword.Equals(true))
                {
                    SessionManager.SetLogin(true);
                    SessionManager.SetUsername(loginUnameTxt);
                    ClearLoginFields();
                    WebPageUtil.DisplayMessageAndRedirect("Login successful", "/WebPage/Home.aspx", this.Page);
                }

                else
                {
                    WebPageUtil.DisplayMessage("Invalid password!");
                    loginPwd.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            else
            {
                WebPageUtil.DisplayMessage("Not an existing user, please signup!");
            }
        }

        private void GetLoginInputText()
        {
            loginUnameTxt = loginUname.Text;
            loginPwdTxt = loginPwd.Text;
        }

        private void GetSignupInputText()
        {
            signupEmailTxt = signupEmail.Text;
            signupUnameTxt = signupUname.Text;
            signupPwdTxt = signupPwd.Text;
            signupConfirmPwdTxt = signupConfirmPwd.Text;
        }

        private void ClearLoginFields()
        {
            loginUname.Text = "";
            loginPwd.Text = "";
        }

        private void ClearSignupFields()
        {
            signupEmail.Text = "";
            signupUname.Text = "";
            signupPwd.Text = "";
            signupConfirmPwd.Text = "";
        }
    }
}