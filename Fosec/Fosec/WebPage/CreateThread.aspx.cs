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

            StringBuilder label = new StringBuilder();

            // TODO 
            //< asp:Label ID = "Label1" runat = "server" Text = "Label" ></ asp:Label >

            /*label.Append("")

            if(r.Read())
            {
                tag.Text = r["tagName"].ToString();
            }
            
            else
            {
                ConnectionProvider.InitCon().Close();
            }*/
        }
    }
}