using Fosec.Database;
using Fosec.Utils;
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
        ThreadCommentDb threadComment = new ThreadCommentDb();
        String reply;
        MessageBoxUtil messageBox = new MessageBoxUtil();

        protected void Page_Load(object sender, EventArgs e)
        {
            //get threadid from link
            string threadid = HttpContext.Current.Request.QueryString["threadid"];

        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            getThreadReply();
            string TID = HttpContext.Current.Request.QueryString["threadid"];

            bool insertComment = threadComment.InsertThreadComment( 4,TID, reply );
            if (insertComment.Equals(true))
            {
                // Code is provided in MessageBoxUtil class, just need to call
                messageBox.MessageBox("Data inserted successfully");
            }

            else
            {
                messageBox.MessageBox("Data insert fail");
            }
        }

        private void getThreadReply()
        {
            reply = ReplyThread.Text;
        }
    }
}

