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
        string titleTxt, contentTxt, tagTxt;
        string threadId = HttpContext.Current.Request.QueryString["threadid"];

        // Server control's functions
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManager.GetUsername() == "")
            {
                WebPageUtil.DisplayMessageAndRedirect("Please login before create thread", "/WebPage/SignupAndLogin.aspx?action=login", this.Page);
            }

            DisplayTagsFromDb();

            if (threadId != null && !IsPostBack)
            {
                DisplayThreadContent();
            }
        }

        private void tag_Click(object sender, EventArgs e)
        {
            tagTxt = ((Button)sender).CommandArgument;
            SessionManager.SetTag(tagTxt);

            foreach (Button button in tagPlaceHolder.Controls.OfType<Button>())
            {
                if (button.Text != SessionManager.GetTag())
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
            //TODO change order
            if (!titleTxt.Equals("") && !contentTxt.Equals(""))
            {
                string uname = SessionManager.GetUsername();
                int userId = UserDb.GetUserIdByUsername(uname);

                string tagName = SessionManager.GetTag();
                int tagNo = TagDb.GetTagIdByTagName(tagName);

                if (!userId.Equals(-1) && !tagNo.Equals(-1))
                {
                    bool insertThread = ThreadDb.InsertThread(userId, titleTxt, tagNo, contentTxt);

                    if (insertThread.Equals(true))
                    {
                        WebPageUtil.DisplayMessageAndRedirect("Submitted successful", "/WebPage/Home.aspx", this.Page);
                        //clear field
                        //TODO direct to the thread page?
                    }

                    else
                    {
                        WebPageUtil.DisplayMessage("Fail to submit thread, please try again.");
                    }
                }

                else
                {
                    WebPageUtil.DisplayMessage("No userId or tagNo found.");
                }
            }

            else
            {
                WebPageUtil.DisplayMessage("Please fill in all field.");
            }
        }

        private void DisplayThreadContent()
        {
            SqlDataReader r = ThreadDb.GetThreadContentByThreadId(int.Parse(threadId));

            if (r.HasRows)
            {
                while (r.Read())
                {
                    threadTitle.Text = r.GetString(0);
                    content.Text = r.GetString(2);
                    int tagNoFromDb = r.GetInt32(1);

                    if (!tagNoFromDb.Equals(-1))
                    {
                        string tagNameFromDb = TagDb.GetTagNameByTagId(tagNoFromDb);
                        SessionManager.SetTag(tagNameFromDb);

                        if (!tagNameFromDb.Equals("nothing"))
                        {
                            foreach (Button button in tagPlaceHolder.Controls.OfType<Button>())
                            {
                                if (button.Text.Equals(tagNameFromDb))
                                {
                                    button.Attributes.Add("style", "background-color: #05767B; color:#FFFFFF;");
                                }
                            }
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
            string tagName = SessionManager.GetTag();
            int tagNo = TagDb.GetTagIdByTagName(tagName);

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