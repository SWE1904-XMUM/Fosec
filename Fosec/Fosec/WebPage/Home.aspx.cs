using System;
using System.Web.UI.WebControls;

namespace Fosec.WebPage
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TagButtonClick(object sender, EventArgs e)
        {
            string newTag = ((Button)sender).Text;
            selectedTagName.Text = newTag;
            threadRepeater.DataSourceID = (newTag == "All") ? "AllThreadDataSource" : "FilteredThreadDataSource";
        }
    }
}