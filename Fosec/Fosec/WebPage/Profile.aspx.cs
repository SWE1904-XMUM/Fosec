﻿using System;
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
            // if the userid belongs to the logged in user, display the user's profile (include edit field)
            // otherwise, display the user's profile (without edit field)

            // if no userid is passed, display the logged in user's profile
            // go back to homepage if not logged in

            string userid = HttpContext.Current.Request.QueryString["userid"];

            if ((userid == null && SessionManager.GetUsername() != "") || (userid != null && userid.ToString() == UserDb.GetUserIdByUsername(SessionManager.GetUsername()).ToString()))
            {
                userProfile.DataSourceID = "LoggedInUserProfileData";
                userProfileDetail.DataSourceID = "LoggedInUserProfileData";
                userThreadRepeater.DataSourceID = "LoggedInUserThreadData";
            }
            else if (userid != null && UserDb.CheckUserIdExistence(Int32.Parse(userid)))
            {
                userProfile.DataSourceID = "OtherUserProfileData";
                userProfileDetail.DataSourceID = "OtherUserProfileData";
                userThreadRepeater.DataSourceID = "OtherUserThreadData";
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
            }

            // check file type
            string fileType = uploadProfileImage.PostedFile.ContentType.ToLower();
            if (fileType != "image/jpeg" && fileType != "image/png")
            {
                WebPageUtil.DisplayMessage("Please upload image in jpeg or png type " + fileType);
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
    }
}