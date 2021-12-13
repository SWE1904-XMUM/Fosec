using Fosec.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fosec.WebPage
{
    public partial class CreateThread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TagDb tagDb = new TagDb();
            SqlDataReader r = tagDb.DisplayTags();
            int i = 0;

            if(r.HasRows)
            {
                while(r.Read())
                {
                    // TODO -> <div class="col-lg-3">
                    Label tagLabel = new Label();
                    tagLabel.ID = "Label " + i.ToString();
                    tagLabel.Text = r["tagName"].ToString();
                    tag.Controls.Add(tagLabel);
                    i++;
                }
            }

            else
            {
                ConnectionProvider.CloseDatabaseConnection();
            }
        }
    }
}