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

        // Class initialization
        TagDb tagDb = new TagDb();
        MessageBoxUtil messageBox = new MessageBoxUtil();
        ThreadDb threadDb = new ThreadDb();
        UserDb userDb = new UserDb();

        protected void Page_Load(object sender, EventArgs e)
        {
            switch(GetPreviousPageName())
            {
                case "Home.aspx":
                    DisplayTagsFromDb();
                    break;

                case "Thread.aspx":
                    //TODO
                    break;

                case "nothing":
                    MessageBoxUtil.DisplayMessage("No previous page.");
                    break;

                default:
                    MessageBoxUtil.DisplayMessage("Error!");
                    break;
            }
        }

        private void DisplayTagsFromDb()
        {   
            SqlDataReader r = tagDb.DisplayTags();

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
                ConnectionProvider.CloseDatabaseConnection();
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
            GetThreadText();

            if(GetPreviousPageName().Equals("Home.aspx"))
            {
                InsertNewThread();
            }

            else if (GetPreviousPageName().Equals("Thread.aspx"))
            {
                string threadId = HttpContext.Current.Request.QueryString["threadid"];
                //threadTitle = ;
                //content = threadDb.GetThreadContent();
            }
        }

        private string GetPreviousPageName()
        {
            if (Request.UrlReferrer != null)
            {
                return System.IO.Path.GetFileName(Request.UrlReferrer.AbsolutePath);
                //System.Diagnostics.Debug.WriteLine(previousPage);
            }

            else
            {
                return "nothing";
            }
        }

        private void InsertNewThread()
        {
            if (!titleTxt.Equals("") && !contentTxt.Equals(""))
            {
                string uname = SessionManager.GetUsername();
                int userId = userDb.GetUserIdByUsername(uname);

                string tagName = SessionManager.GetTag();
                int tagNo = tagDb.GetTagIdByTagName(tagName);

                if (!userId.Equals(-1) && !tagNo.Equals(-1))
                {
                    bool insertThread = threadDb.InsertThread(userId, titleTxt, tagNo, contentTxt);

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

        private void UpdateThreadContent()
        {

        }

        private void GetThreadText()
        {
            titleTxt = threadTitle.Text;
            contentTxt = content.Text;
        }
    }
}