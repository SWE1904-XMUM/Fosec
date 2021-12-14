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
    public partial class Thread : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ThreadDb threadDb = new ThreadDb();
            SqlDataReader th = threadDb.DisplayThreadContent(); 

            if (th.HasRows)
            {
                TextBox text = new TextBox();
                text.Text = th["content"].ToString();
                ThreadContent.Controls.Add(text);
            }
            else
            {
                ConnectionProvider.CloseDatabaseConnection();
            }
        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {

        }
    }
}