using Fosec.Database;
using Fosec.Session;
using Fosec.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Fosec.WebPage
{
    public partial class CreateThread : System.Web.UI.Page
    {
        // Thread page txt
        string titleTxt, contentTxt;
        string threadId = HttpContext.Current.Request.QueryString["threadid"];
        private static string selectedTag = "";

        // Server control's functions
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManager.GetUsername() == "")
            {
                WebPageUtil.DisplayMessageAndRedirect("ERROR: Please login first", "/WebPage/SignupAndLogin.aspx?action=login", this.Page);
                return;
            }

            DisplayTagsFromDb();

            // TODO -> debug for update
            if (ThreadDb.CheckThreadExistence(int.Parse(threadId)) && !IsPostBack)
            {
                DisplayThreadContent();
            }

            else if (ThreadDb.CheckThreadExistence(int.Parse(threadId)) && IsPostBack)
            {
                threadContainer.Visible = true;
            }

            else
            {
                threadContainer.Visible = false;
            }

            errorContainer.Visible = !threadContainer.Visible;
        }

        private void tag_Click(object sender, EventArgs e)
        {
            selectedTag = ((Button)sender).CommandArgument;

            foreach (Button button in tagPlaceHolder.Controls.OfType<Button>())
            {
                if (button.Text != selectedTag)
                {
                    button.Attributes.Add("style", "background-color: #C8EDEF; color:#000000;");
                }

                else
                {
                    button.Attributes.Add("style", "background-color: #05767B; color:#FFFFFF;");
                }
            }
        }

        protected void submitThread_Click(object sender, EventArgs e)
        {
            if (threadTitle.Text.Length > ThreadDb.MAX_TITLE_LENGTH)
            {
                WebPageUtil.DisplayMessage("The thread title has exceeded maximum length");
                return;
            }

            if (content.Text.Length > ThreadDb.MAX_CONTENT_LENGTH)
            {
                WebPageUtil.DisplayMessage("The content has exceeded maximum length");
                return;
            }

            if (threadId != null)
            {
                GetThreadText();
                UpdateThreadContent();
            }

            else
            {
                InsertNewThread();
            }
        }

        // Other functions
        private void DisplayTagsFromDb()
        {
            List<string> tagList = TagDb.GetAllTags();

            if (tagList.Count > 0)
            {
                foreach (string tag in tagList)
                {
                    Button tagBtn = new Button();
                    tagBtn.CommandArgument = tag;
                    tagBtn.CssClass = "btn tag-btn";
                    tagBtn.Text = tag;
                    tagBtn.Click += new EventHandler(tag_Click);
                    tagPlaceHolder.Controls.Add(tagBtn);
                }
            }
        }

        private void InsertNewThread()
        {
            GetThreadText();

            int userId = UserDb.GetUserIdByUsername(SessionManager.GetUsername());
            int tagNo = TagDb.GetTagIdByTagName(SessionManager.GetTag());

            if (userId <= 0)
            {
                WebPageUtil.DisplayMessageAndRedirect("Please login before create thread", "/WebPage/SignupAndLogin.aspx?action=login", this.Page);
            }

            else if (titleTxt.Equals(""))
            {
                WebPageUtil.DisplayMessage("Please enter thread title");
            }

            else if (tagNo == -1)
            {
                WebPageUtil.DisplayMessage("Please select a subject");
            }

            else if (contentTxt.Equals(""))
            {
                WebPageUtil.DisplayMessage("Please enter thread content");
            }

            else
            {
                int result = ThreadDb.InsertThread(userId, titleTxt, tagNo, contentTxt);

                if (result > 0)
                {
                    threadTitle.Text = "";
                    SessionManager.RemoveTag();
                    content.Text = "";
                    WebPageUtil.DisplayMessageAndRedirect("Submitted successful", "/WebPage/Thread.aspx?threadid=" + result, this.Page);
                }

                else
                {
                    WebPageUtil.DisplayMessage("Fail to submit thread, please try again." + result);
                }
            }
        }

        private void DisplayThreadContent()
        {
            (string d_title, string d_content, int d_tagNo) = ThreadDb.GetThreadContentByThreadId(int.Parse(threadId));
            if (!d_tagNo.Equals(-1))
            {
                string tagNameFromDb = TagDb.GetTagNameByTagId(d_tagNo);
                SessionManager.SetTag(tagNameFromDb);
                threadTitle.Text = d_title;
                content.Text = d_content;

                if (!tagNameFromDb.Equals("nothing"))
                {
                    foreach (Button button in tagPlaceHolder.Controls.OfType<Button>())
                    {
                        if (button.Text.Equals(tagNameFromDb))
                        {
                            button.Attributes.Add("style", "background-color: #05767B; color:#FFFFFF;");
                            break;
                        }
                    }
                }
            }

            else
            {
                WebPageUtil.DisplayMessage("No content found.");
            }
        }

        private void UpdateThreadContent()
        {
            int tagNo = TagDb.GetTagIdByTagName(selectedTag);

            if (tagNo != -1)
            {
                bool editThread = ThreadDb.EditThread(int.Parse(threadId), titleTxt, tagNo, contentTxt);

                if (editThread.Equals(true))
                {
                    WebPageUtil.DisplayMessageAndRedirect("Your thread has been uploaded", "/WebPage/Thread.aspx?threadid=" + threadId, this.Page);
                }

                else
                {
                    WebPageUtil.DisplayMessage("ERROR: Update Failed, please try again");
                }
            }

            else
            {
                WebPageUtil.DisplayMessage("ERROR: Please try again");
            }
        }

        private void GetThreadText()
        {
            titleTxt = threadTitle.Text;
            contentTxt = content.Text;
        }
    }
}