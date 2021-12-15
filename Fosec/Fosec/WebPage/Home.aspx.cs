using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            string newTag = ((Button)sender).CommandArgument;
            if(newTag != selectedTagName.Text)
            {
                selectedTagName.Text = newTag;
                threadRepeater.DataSourceID = "FilteredThreadDataSource";
            }
            else
            {
                selectedTagName.Text = "All";
                threadRepeater.DataSourceID = "AllThreadDataSource";
            }
        }
    }
}