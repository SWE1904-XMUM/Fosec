using Fosec.Database;
using Fosec.Session;
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
        // Thread page txt
        string titleTxt, contentTxt, tagTxt;

        // Server control's functions
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayTagsFromDb();

            if (!String.IsNullOrEmpty(Request.QueryString["threadid"]))
            {
                DisplayThreadContent();
            }
        }

        private void tag_Click(object sender, EventArgs e)
        {
            tagTxt = ((Button)sender).CommandArgument;
            SessionManager.SetTag(tagTxt);

            foreach (Button button in tag.Controls.OfType<Button>())
            {
                if (button.Text != SessionManager.GetTag())
                {
                    button.Attributes.Add("style", "background-color: #C8EDEF");
                }

                else
                {
                    button.Attributes.Add("style", "background-color: #05767B");
                }
            }
        }

        protected void submitThread_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Request.QueryString["threadid"]))
            {
                DisplayThreadContent();
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
            SqlDataReader r = TagDb.DisplayTags();

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
                WebPageUtil.DisplayMessage("No tag found.");
            }
        }

        private void InsertNewThread()
        {
            GetThreadText();

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
                        WebPageUtil.DisplayMessage("Submitted successfully.");
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
            string threadId = Request.QueryString["threadid"];
            SqlDataReader r = ThreadDb.GetThreadContent(int.Parse(threadId));

            if (r.HasRows)
            {
                while(r.Read())
                {
                    threadTitle.Text = r.GetString(0);
                    content.Text = r.GetString(2);
                    int tagNoFromDb = r.GetInt32(1);

                    if (!tagNoFromDb.Equals(-1))
                    {
                        string tagNameFromDb = TagDb.GetTagNameByTagId(tagNoFromDb);

                        if (!tagNameFromDb.Equals("nothing"))
                        {
                            foreach (Button button in tag.Controls.OfType<Button>())
                            {
                                if (button.Text.Equals(tagNameFromDb))
                                {
                                    button.Attributes.Add("style", "background-color: #05767B");
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
            GetThreadText();

            string threadId = Request.QueryString["threadid"];
            string tagName = SessionManager.GetTag();
            int tagNo = TagDb.GetTagIdByTagName(tagName);

            if(tagNo != -1)
            {
                bool editThread = ThreadDb.EditThread(int.Parse(threadId), titleTxt, tagNo, contentTxt);

                if(editThread.Equals(true))
                {
                    WebPageUtil.DisplayMessage("Updated successfully.");
                }

                else
                {
                    WebPageUtil.DisplayMessage("Fail to update, please try again.");
                }
            }

            else
            {
                WebPageUtil.DisplayMessage("No tagNo found.");
            }
        }

        private void GetThreadText()
        {
            titleTxt = threadTitle.Text;
            contentTxt = content.Text;
        }
    }
}