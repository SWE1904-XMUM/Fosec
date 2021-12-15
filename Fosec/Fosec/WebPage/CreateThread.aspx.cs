using Fosec.Database;
using System;
using System.Collections.Generic;
using System.Data;
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
        TagDb tagDb = new TagDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayTagsFromDb();
        }

        private void DisplayTagsFromDb()
        {   
            SqlDataReader r = tagDb.DisplayTags();
            int i = 0;

            if (r.HasRows)
            {
                while (r.Read())
                {
                    Button tagLabel = new Button();
                    tagLabel.CssClass = "btn tag-btn";
                    tagLabel.ID = "tag" + i;
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