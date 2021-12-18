using System;
using System.IO;
using System.Web;
using Fosec.Session;
using Fosec.Database;
using Fosec.Utils;

namespace Fosec.WebPage
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = HttpContext.Current.Request.QueryString["userid"];

            if ((userid == null && SessionManager.GetUsername() != "") || (userid != null && userid.ToString() == UserDb.GetUserIdByUsername(SessionManager.GetUsername()).ToString()))
            {
                userProfile.DataSourceID = "LoggedInUserProfileData";
                userProfileDetail.DataSourceID = "LoggedInUserProfileData";
                userThreadRepeater.DataSourceID = "LoggedInUserThreadData";
                editProfileContainer.Visible = true;
            }
            else if (userid != null && UserDb.CheckUserIdExistence(Int32.Parse(userid)))
            {
                userProfile.DataSourceID = "OtherUserProfileData";
                userProfileDetail.DataSourceID = "OtherUserProfileData";
                userThreadRepeater.DataSourceID = "OtherUserThreadData";
                editProfileContainer.Visible = false;
            }
            else
            {
                errorContainer.Visible = true;
                profileContainer.Visible = false;
            }
        }

        protected void SubmitProfileImage(object sender, EventArgs e)
        {
            // validation
            if (!uploadProfileImage.HasFile)
            {
                WebPageUtil.DisplayMessage("Please upload an image");
                return;
            }

            // check file type
            string fileType = uploadProfileImage.PostedFile.ContentType.ToLower();
            if (fileType != "image/jpeg" && fileType != "image/png")
            {
                WebPageUtil.DisplayMessage("Please upload image in jpeg or png type");
                return;
            }

            try
            {
                // convert uploaded file into bytes
                BinaryReader br = new BinaryReader(uploadProfileImage.PostedFile.InputStream);
                byte[] uploadedImage = br.ReadBytes(uploadProfileImage.PostedFile.ContentLength);
                bool result = UserDb.UpdateUserProfileImage(UserDb.GetUserIdByUsername(SessionManager.GetUsername()), uploadedImage);

                // upload image to database
                if (result == true)
                {
                    WebPageUtil.DisplayMessage("Profile Image has been updated");
                    Server.Transfer(Request.RawUrl);
                }
                else
                {
                    WebPageUtil.DisplayMessage("Error in uploading profile image, please try again");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }

        protected void UpdatePassword(object sender, EventArgs e)
        {
            if (UserDb.CheckUserPassword(SessionManager.GetUsername(), currentPasswordField.Text))
            {
                if (newPasswordField.Text == confirmNewPasswordField.Text)
                {
                    string validateResult = ValidationUtil.ValidatePassword(newPasswordField.Text);
                    if (validateResult != ValidationUtil.RESULT_PASS)
                    {
                        WebPageUtil.DisplayMessage(validateResult);
                        return;
                    }

                    bool result = UserDb.UpdateUserPassword(UserDb.GetUserIdByUsername(SessionManager.GetUsername()), newPasswordField.Text);
                    if (result)
                    {
                        WebPageUtil.DisplayMessageAndRedirect("Password has been updated", Request.RawUrl, this.Page);
                    }
                    else
                    {
                        WebPageUtil.DisplayMessage("Error, please try again");
                    }
                }
                else
                {
                    WebPageUtil.DisplayMessage("New password does not match");
                }
            }
            else
            {
                WebPageUtil.DisplayMessage("Sorry, current password is incorrect");
            }
        }

        protected void DisplayProfileImageUploadForm(object sender, EventArgs e)
        {
            editProfileImageContainer.Visible = !editProfileImageContainer.Visible;
        }

        protected void DisplayChangePasswordForm(object sender, EventArgs e)
        {
            editPasswordContainer.Visible = !editPasswordContainer.Visible;
        }
    }
}