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
        string threadId = HttpContext.Current.Request.QueryString["threadid"];

        // Server control's functions
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayTagsFromDb();
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
            if(Request.QueryString.Keys.Count > 0)
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
                MessageBoxUtil.DisplayMessage("No tag found.");
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
                        MessageBoxUtil.DisplayMessage("Submitted successfully.");
                    }

                    else
                    {
                        MessageBoxUtil.DisplayMessage("Fail to submit thread, please try again.");
                    }
                }

                else
                {
                    MessageBoxUtil.DisplayMessage("No userId or tagNo found.");
                }
            }

            else
            {
                MessageBoxUtil.DisplayMessage("Please fill in all field.");
            }
        }

        private void DisplayThreadContent()
        {
            SqlDataReader r = ThreadDb.GetThreadContent(int.Parse(threadId));

            if (r.HasRows)
            {
                r.Read();

                threadTitle.Text = r["title"].ToString();
                content.Text = r["content"].ToString();
                string tagNoFromDb = r["tagNo"].ToString();

                if (!tagNoFromDb.Equals("-1"))
                {
                    string tagNameFromDb = TagDb.GetTagNameByTagId(int.Parse(tagNoFromDb));

                    if(!tagNameFromDb.Equals("nothing"))
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

            else
            {
                MessageBoxUtil.DisplayMessage("No content found.");
            }
        }

        private void UpdateThreadContent()
        {
            GetThreadText();

            string tagName = SessionManager.GetTag();
            int tagNo = TagDb.GetTagIdByTagName(tagName);

            if(tagNo != -1)
            {
                bool editThread = ThreadDb.EditThread(int.Parse(threadId), titleTxt, tagNo, contentTxt);

                if(editThread.Equals(true))
                {
                    MessageBoxUtil.DisplayMessage("Updated successfully.");
                }

                else
                {
                    MessageBoxUtil.DisplayMessage("Fail to update, please try again.");
                }
            }

            else
            {
                MessageBoxUtil.DisplayMessage("No tagNo found.");
            }
        }

        private void GetThreadText()
        {
            titleTxt = threadTitle.Text;
            contentTxt = content.Text;
        }
    }
}