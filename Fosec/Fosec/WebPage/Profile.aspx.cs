using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fosec.Session;
using Fosec.Database;
using System.Data.SqlClient;
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
            else if (userid != null)
            {
                userProfile.DataSourceID = "OtherUserProfileData";
                userProfileDetail.DataSourceID = "OtherUserProfileData";
                userThreadRepeater.DataSourceID = "OtherUserThreadData";
            }
            else
            {
                WebPageUtil.DisplayMessageAndRedirect("Error: This page does not exist", "/WebPage/Home.aspx", this.Page);
            }
        }

        protected void SubmitProfileImage(object sender, EventArgs e)
        {
            // TODO validation
            if (uploadProfileImage.HasFile)
            {
                BinaryReader br = new BinaryReader(uploadProfileImage.PostedFile.InputStream);
                byte[] uploadedImage = br.ReadBytes(uploadProfileImage.PostedFile.ContentLength);
                bool result = UserDb.UpdateUserProfileImage(1, uploadedImage);

                if (result == true)
                {
                    WebPageUtil.DisplayMessage("Profile Image has been updated");
                }

                else
                {
                    WebPageUtil.DisplayMessage("Error in uploading profile image, please try again");
                }
            }
        }
    }
}