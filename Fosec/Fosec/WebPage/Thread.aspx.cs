using Fosec.Database;
using Fosec.Utils;
using System;
using System.Web;
using Fosec.Session;
using System.Web.UI.WebControls;

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
                ViewState["btn"] = (UserDb.GetUserIdByUsername(SessionManager.GetUsername()) == ThreadDb.GetUserIdByThreadId(threadid));

                //disable reply button if not logged in
                commentEnabledContainer.Visible = (SessionManager.GetUsername() != "");
                commentDisabledContainer.Visible = !commentEnabledContainer.Visible;
            }
        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            GetThreadReply();

            if (reply.Length > ThreadCommentDb.MAX_CONTENT_LENGTH)
            {
                WebPageUtil.DisplayMessage("The reply content has exceeded maximum length");
            }

            else if (reply.Equals(""))
            {
                WebPageUtil.DisplayMessage("Please write a reply in the text box before replying to the thread");
            }

            else
            {
                int userId = UserDb.GetUserIdByUsername(SessionManager.GetUsername());
                bool insertComment = ThreadCommentDb.InsertThreadComment(userId, threadid, reply);

                if (insertComment)
                {
                    WebPageUtil.Redirect(Request.RawUrl, this.Page);
                }

                else
                {
                    WebPageUtil.DisplayMessage("ERROR: Error occurs when submitting the comment, please try again");
                }
            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            if (UserDb.GetUserIdByUsername(SessionManager.GetUsername()) == ThreadDb.GetUserIdByThreadId(threadid))
            {
                bool result = ThreadDb.DeleteThread(threadid);

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
            reply = ReplyThread.Text.Trim();
        }
    }
}

