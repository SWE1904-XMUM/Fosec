using Fosec.Database;
using Fosec.Utils;
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
        MessageBoxUtil messageBox = new MessageBoxUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayTagsFromDb();
        }

        protected void DisplayTagsFromDb()
        {   
            SqlDataReader r = tagDb.DisplayTags();

            if (r.HasRows)
            {
                while (r.Read())
                {
                    Button tagBtn = new Button();
                    string tagName = r["tagName"].ToString();
                    tagBtn.CommandArgument = tagName;
                    tagBtn.CssClass = "btn tag-btn";
                    tagBtn.Text = tagName;
                    tagBtn.Click += new EventHandler(tag_Click);
                    tag.Controls.Add(tagBtn);
                }
            }

            else
            {
                ConnectionProvider.CloseDatabaseConnection();
            }
        }

        private void tag_Click(object sender, EventArgs e)
        {
            messageBox.MessageBox("button clicked " + ((Button)sender).CommandArgument);
            //TODO -> connect with db
        }
    }
}