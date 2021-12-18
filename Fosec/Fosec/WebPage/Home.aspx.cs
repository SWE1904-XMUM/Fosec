using Fosec.Session;
using System;
using System.Web;
using System.Web.UI.WebControls;
using Fosec.Utils;
using Fosec.Database;

namespace Fosec.WebPage
{
    public partial class Home : System.Web.UI.Page
    {
        string tagName = HttpContext.Current.Request.QueryString["tagName"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (tagName != null)
            {
                selectedTagName.Text = tagName;
                threadRepeater.DataSourceID = (tagName == "All") ? "AllThreadDataSource" : "FilteredThreadDataSource";
            }

            if (SessionManager.GetLogin().Equals("true"))
            {
                createNewThreadBtn.Visible = true;
            }

            else
            {
                createNewThreadBtn.Visible = false;
            }
        }

        protected void TagButtonClick(object sender, EventArgs e)
        {
            string newTag = ((Button)sender).Text;
            selectedTagName.Text = newTag;
            threadRepeater.DataSourceID = (newTag == "All") ? "AllThreadDataSource" : "FilteredThreadDataSource";
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            bool result = ThreadDb.DeleteThread(((Button)sender).CommandArgument);
            if (result)
            {
                WebPageUtil.DisplayMessageAndRedirect("Thread has been deleted", Request.RawUrl, this.Page);
            }
            else
            {
                WebPageUtil.DisplayMessage("ERROR: Thread was not deleted, please try again");
            }
        }
    }
}