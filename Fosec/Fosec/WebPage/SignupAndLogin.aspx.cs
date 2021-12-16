﻿using Fosec.Database;
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

        // Class initialization
        MessageBoxUtil messageBox = new MessageBoxUtil();
        UserDb userDb = new UserDb();

        // TODO -> solve connection close error occured when directly login after signup

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

            ValidationUtil validationUtil = new ValidationUtil();
            string uname = validationUtil.ValidateUname(signupUnameTxt);
            string pwd = validationUtil.ValidatePassword(signupPwdTxt);
            string email = validationUtil.ValidateEmail(signupEmailTxt);

            if (email.Equals("pass") && uname.Equals("pass") && pwd.Equals("pass") && signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                bool checkExistingUser = userDb.CheckExistingUser(signupUnameTxt);

                if (checkExistingUser.Equals(false))
                {
                    bool insertUser = userDb.InsertUsers(signupUnameTxt, signupEmailTxt, signupPwdTxt);

                    if (insertUser.Equals(true))
                    {
                        MessageBoxUtil.DisplayMessage("Signup successfully! Please login.");
                    }

                    else
                    {
                        MessageBoxUtil.DisplayMessage("Fail to signup.");
                    }
                }

                else
                {
                    MessageBoxUtil.DisplayMessage("Username already existed, please try for another.");
                }

                ConnectionProvider.CloseDatabaseConnection();
            }

            else if (email != "pass")
            {
                MessageBoxUtil.DisplayMessage(email);
                signupEmail.BackColor = System.Drawing.Color.LightCoral;
            }

            else if (uname != "pass")
            {
                MessageBoxUtil.DisplayMessage(uname);
                signupUname.BackColor = System.Drawing.Color.LightCoral;
            }

            else if (pwd != "pass")
            {
                MessageBoxUtil.DisplayMessage(pwd);
                signupPwd.BackColor = System.Drawing.Color.LightCoral;
            }

            else if (!signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                MessageBoxUtil.DisplayMessage("Please enter same password!");
                signupConfirmPwd.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            GetLoginInputText();

            bool checkExistingUser = userDb.CheckExistingUser(loginUnameTxt);
            bool checkPassword = userDb.CheckUserPassword(loginUnameTxt, loginPwdTxt);

            if (checkExistingUser.Equals(true))
            {
                if (checkPassword.Equals(true))
                {
                    Response.Redirect("Home.aspx");
                    SessionManager.SetLogin(true);
                    SessionManager.SetUsername(signupUnameTxt);
                }

                else
                {
                    MessageBoxUtil.DisplayMessage("Invalid password!");
                    loginPwd.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            else
            {
                MessageBoxUtil.DisplayMessage("Not an existing user, please signup!");
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
    }
}