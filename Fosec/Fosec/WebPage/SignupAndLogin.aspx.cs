using Fosec.Database;
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

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            GetSignupInputText();

            ValidationUtil validationUtil = new ValidationUtil();
            string uname = validationUtil.ValidateUname(signupUnameTxt);
            string pwd = validationUtil.ValidatePassword(signupPwdTxt);
            string email = validationUtil.ValidateEmail(signupEmailTxt);

            if(email.Equals("pass") && uname.Equals("pass") && pwd.Equals("pass") && signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                //valid -> store into db
            }

            // TODO -> display right error message
            else if(email != "pass")
            {
                //display error message for email
                Response.Write("invalid email");
            }

            else if(uname != "pass")
            {
                //display error message for uname
                Response.Write("invalid uname");
            }

            else if(pwd != "pass")
            {
                //display error message for pwd
                Response.Write("invalid pwd");
            }

            else if(!signupConfirmPwdTxt.Equals(signupPwdTxt))
            {
                //display error message for confirm pwd
                Response.Write("not same pwd");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            GetLoginInputText();
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