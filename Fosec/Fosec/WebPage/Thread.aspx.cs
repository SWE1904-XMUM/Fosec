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
        String reply;

        protected void Page_Load(object sender, EventArgs e)
        {
            //get threadid from link
            string threadid = HttpContext.Current.Request.QueryString["threadid"];


            //TODO disable reply if not logged in
            
           // ReplyBtn.Enabled = false;
        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            GetThreadReply();

            if (!reply.Equals(""))
            {
                string uname = SessionManager.GetUsername();
                int userId = UserDb.GetUserIdByUsername(uname);
                string TID = HttpContext.Current.Request.QueryString["threadid"];
                bool insertComment = ThreadCommentDb.InsertThreadComment(userId, TID, reply);

                if (insertComment.Equals(true))
                {
                    // Code is provided in WebPageUtil class, just need to call
                    WebPageUtil.DisplayMessage("Data inserted successfully");
                }

                else
                {
                    WebPageUtil.DisplayMessage("Data insert fail");
                }
            }
            else
            {
                WebPageUtil.DisplayMessage("Please write a reply in the text box before replying to the thread");
            }
        }

        private void GetThreadReply()
        {
            reply = ReplyThread.Text;
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            // need session manager to ensure only owner can delete
            string uname = SessionManager.GetUsername();
            int userId = UserDb.GetUserIdByUsername(uname);
            string threadid = HttpContext.Current.Request.QueryString["threadid"];
            int UID = ThreadDb.GetUserID(threadid);
            if (!userId.Equals(UID))
            {
             //   WebPageUtil.DisplayMessage("not the creator of this thread, no permission to delete");
                DelBtn.Enabled = false;
            }
            else
            ThreadDb.DeleteThread(threadid);
            DelBtn.Enabled = true;
        }

    }
}

