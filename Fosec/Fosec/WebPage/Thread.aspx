<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Fosec.WebPage.Thread" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <style>
        div {
            justify-content: center;
            align-content: center;
        }
    </style>

    <!-- TODO thread page content -->
    <div class="container" style="margin: auto auto auto auto; width: 1000px">
        <div id="mainThreadContainer">
            <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="ThreadData">
                <ItemTemplate>
                    <itemtemplate>
                        <div class="threadContainer row">
                            <div class="userInformation col-3">
                                <asp:Label CssClass="threadUserId row" runat="server" Text='<%# "Userid: " + Eval("userId") %>' />
                            </div>
                            <div class="threadInformation col-9">
                                <a class="threadInformation link-text-view">
                                    <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                    <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                </a>
                                <hr />
                                <div>
                                    <div class="row">
                                        <div class="tagName col-8">
                                            <asp:Label CssClass="btn no-hover" runat="server" Text='<%# Eval("tagName") %>' />
                                        </div>
                                        <asp:Label CssClass="threadDate col-4" runat="server" Text='<%# Eval("date") %>' />
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </itemtemplate>
                </ItemTemplate>
            </asp:Repeater>

            <!--get threadComments here -->
            <asp:Repeater ID="threadCommentRepeater" runat="server" DataSourceID="ThreadComment">
                <ItemTemplate>
                    <itemtemplate>
                        <div class="threadContainer row">
                            <div class="userInformation col-3">
                                <asp:Label CssClass="threadUserId row" runat="server" Text='<%# "Userid: " + Eval("userId") %>' />
                            </div>
                            <div class="threadInformation col-9">
                                <a class="threadInformation link-text-view ">
                                    <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("comment") %>' />
                                </a>
                                <hr />
                                <div>
                                    <div class="row">
                                        <asp:Label CssClass="threadDate col-4" runat="server" Text='<%# Eval("commentdate") %>' />
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </itemtemplate>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- Insert comment -->
        <asp:TextBox ID="ReplyThread" TextMode="MultiLine" type="text" placeHolder="reply here" runat="server" Height="100px" Width="880px"></asp:TextBox>
        <asp:Button ID="ReplyBtn" runat="server" Text="Reply" CssClass="mt-0" OnClick="ReplyBtn_Click" />
    </div>

    <!-- Data Sources -->
    <asp:SqlDataSource ID="ThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId as threadid, Threads.userId as userid, Threads.title as title, Threads.[content] as content, Threads.threadDate AS date, Tag.tagName as tagname, Users.profileImage as profileimage, Users.username as username FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId left outer join users on users.userid=threads.userid where threads.threadid=@threadid">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ThreadComment" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ThreadComment.userId as userid, Users.username as username, Users.profileimage as profileimage, ThreadComment.comment as comment, ThreadComment.commentDate as commentdate FROM ThreadComment LEFT OUTER JOIN Users ON ThreadComment.userId = Users.userId WHERE (ThreadComment.threadId = @threadId)">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
