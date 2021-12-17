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
        string threadid = HttpContext.Current.Request.QueryString["threadid"];

        protected void Page_Load(object sender, EventArgs e)
        {
            // display error instead of thread if no threadid is given
            errorContainer.Visible = (threadid == null); //or threadid does not exist
            threadContainer.Visible = !errorContainer.Visible;

            if (threadid != null)
            {
                //display delete button if the current user is the author of current thread
                editBtn.Visible = deleteBtn.Visible = (UserDb.GetUserIdByUsername(SessionManager.GetUsername()) == ThreadDb.GetUserID(threadid));

                //disable reply button if not logged in
                //TODO add block to replace the comment area
                if (SessionManager.GetUsername() == "")
                {
                    ReplyThread.Enabled = false;
                    ReplyBtn.Enabled = false;
                }
            }
        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            GetThreadReply();

            if (!reply.Trim().Equals(""))
            {
                int userId = UserDb.GetUserIdByUsername(SessionManager.GetUsername());
                bool insertComment = ThreadCommentDb.InsertThreadComment(userId, threadid, reply);

                if (insertComment)
                {
                    WebPageUtil.DisplayMessage("Your comment has been submitted");
                }
                else
                {
                    WebPageUtil.DisplayMessage("Your comment has failed to be submit, please try again");
                }
            }
            else
            {
                WebPageUtil.DisplayMessage("Please write a reply in the text box before replying to the thread");
            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            if (UserDb.GetUserIdByUsername(SessionManager.GetUsername()) == ThreadDb.GetUserID(threadid))
            {
                bool result = ThreadDb.DeleteThread(threadid);
                //TODO delete comments for this thread
                if (result)
                {
                    WebPageUtil.DisplayMessageAndRedirect("Thread has been deleted", "/WebPage/Home.aspx", this.Page);
                }
                else
                {
                    WebPageUtil.DisplayMessage("Thread deletion has failed, please try again");
                }
            }
        }

        private void GetThreadReply()
        {
            reply = ReplyThread.Text;
        }
    }
}

