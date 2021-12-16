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
            // TODO remove
            SessionManager.SetUsername("pjou00");
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
                    MessageBoxUtil.DisplayMessage("Profile Image has been updated");
                }

                else
                {
                    MessageBoxUtil.DisplayMessage("Error in uploading profile image, please try again");
                }
            }
        }
    }
}