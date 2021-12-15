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
        string loginUnameTxt,loginPwdTxt;

        // Signup column
        string signupEmailTxt, signupUnameTxt, signupPwdTxt, signupConfirmPwdTxt;

        // Class initialization
        MessageBoxUtil messageBox = new MessageBoxUtil();
        UserDb userDb = new UserDb();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            GetSignupInputText();

            ValidationUtil validationUtil = new ValidationUtil();
            string uname = validationUtil.ValidateUname(signupUnameTxt);
            string pwd = validationUtil.ValidatePassword(signupPwdTxt);
            string email = validationUtil.ValidateEmail(signupEmailTxt);

            if(email.Equals("pass") && uname.Equals("pass") && pwd.Equals("pass") && signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                bool checkExistingUser = userDb.CheckExistingUser(signupUnameTxt);

                if(checkExistingUser.Equals(false))
                {
                    bool insertUser = userDb.InsertUsers(signupUnameTxt, signupEmailTxt, signupPwdTxt);

                    if (insertUser.Equals(true))
                    {
                        messageBox.MessageBox("Signup successfully! Please login.");
                    }

                    else
                    {
                        messageBox.MessageBox("Fail to signup.");
                    }
                }
                
                else
                {
                    messageBox.MessageBox("Username already existed, please try for another.");
                }

                ConnectionProvider.CloseDatabaseConnection();
            }

            else if(email != "pass")
            {
                messageBox.MessageBox(email);
                signupEmail.BackColor = System.Drawing.Color.LightCoral;
            }

            else if(uname != "pass")
            {
                messageBox.MessageBox(uname);
                signupUname.BackColor = System.Drawing.Color.LightCoral;
            }

            else if(pwd != "pass")
            {
                messageBox.MessageBox(pwd);
                signupPwd.BackColor = System.Drawing.Color.LightCoral;
            }

            else if(!signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                messageBox.MessageBox("Please enter same password!");
                signupConfirmPwd.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            GetLoginInputText();

            bool checkExistingUser = userDb.CheckExistingUser(loginUnameTxt);
            bool checkPassword = userDb.CheckUserPassword(loginUnameTxt, loginPwdTxt);

            if(checkExistingUser.Equals(true))
            {
                if(checkPassword.Equals(true))
                {
                    Response.Redirect("Home.aspx");
                    SessionManager.SetLogin(true);
                    SessionManager.SetUsername(signupUnameTxt);
                }

                else
                {
                    messageBox.MessageBox("Invalid password!");
                    loginPwd.BackColor = System.Drawing.Color.LightCoral;
                }
            }

            else
            {
                messageBox.MessageBox("Not an existing user, please signup!");
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