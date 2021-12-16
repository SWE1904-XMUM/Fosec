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
using Fosec.Session;


namespace Fosec.WebPage
{
    public partial class Thread : System.Web.UI.Page
    {
        ThreadCommentDb threadComment = new ThreadCommentDb();
        UserDb userDb = new UserDb();
        String reply;

        protected void Page_Load(object sender, EventArgs e)
        {
            //get threadid from link
            string threadid = HttpContext.Current.Request.QueryString["threadid"];

        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            GetThreadReply();

            if (!reply.Equals(""))
            {
                string uname = SessionManager.GetUsername();
                int userId = userDb.GetUserIdByUsername(uname);
                string TID = HttpContext.Current.Request.QueryString["threadid"];
                bool insertComment = threadComment.InsertThreadComment(userId, TID, reply);

                if (insertComment.Equals(true))
                {
                    // Code is provided in MessageBoxUtil class, just need to call
                    MessageBoxUtil.DisplayMessage("Data inserted successfully");
                }

                else
                {
                    MessageBoxUtil.DisplayMessage("Data insert fail");
                }
            }
            else
            {
                MessageBoxUtil.DisplayMessage("Please write a reply in the text box before replying to the thread");
            }
        }

        private void GetThreadReply()
        {
            reply = ReplyThread.Text;
        }
    }
}

