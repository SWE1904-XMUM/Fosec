﻿using Fosec.Database;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*    ThreadDb threadDb = new ThreadDb();
                SqlDataReader th = threadDb.DisplayThreadContent(); 

                if (th.HasRows)
                {
                    TextBox text = new TextBox();
                    text.Text = th["content"].ToString();
                    ThreadContent.Controls.Add(text);
                }
                else
                {
                    ConnectionProvider.CloseDatabaseConnection();
                } */
        }

        protected void ReplyBtn_Click(object sender, EventArgs e)
        {
            getThreadReply();
            
            
            bool insertComment = threadComment.insertThreadComment( 4, 1, reply );
            if (insertComment.Equals(true))
            {
                Response.Write("<script>alert('Data inserted successfully')</script>");
            }

            else
            {
                Response.Write("<script>alert('Data insert fail')</script>");
            }
        }
        private void getThreadReply()
        {
            reply = ReplyThread.Text;
        }
    }
}

