<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Fosec.WebPage.Thread" %>

<%@ Import Namespace="Fosec.Utils" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO remove internal style -->
    <style>
        div {
            justify-content: center;
            align-content: center;
        }
    </style>

    <!-- TODO thread page content -->
    <!-- TODO remove internal style -->
    <div class="container" style="margin: auto auto auto auto; width: 1000px">
        <div id="mainThreadContainer">
            <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="ThreadData">
                <ItemTemplate>
                    <div class="threadContainer row">
                        <a class="userInformation link-text-view col-3" href='<%# @"/WebPage/Profile.aspx?userid=" + Eval("userid") %>'>
                            <div class="image-holder mb-3">
                                <asp:Image CssClass="userProfileImage" runat="server" ImageUrl='<%#ImageUtil.GetBase64PathByByteArray(Eval("profileImage"))%>' />
                            </div>
                            <asp:Label runat="server" Text='<%# Eval("username") %>' />
                        </a>
                        <div class="threadInformation col-9 d-flex flex-column justify-content-between">
                            <div class="threadInformation link-text-view">
                                <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                            </div>
                            <div>
                                <hr />
                                <div class="row">
                                    <div class="tagName col-8">
                                        <asp:Label CssClass="btn no-hover tag-in-thread" runat="server" Text='<%# Eval("tagName") %>' />
                                    </div>
                                    <asp:Label CssClass="threadDate col-4" runat="server" Text='<%# Eval("date") %>' />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <!--get threadComments here -->
            <div class="row">
                <div class="col-1"></div>
                <div class="col-11">
                    <asp:Repeater ID="threadCommentRepeater" runat="server" DataSourceID="ThreadCommentData">
                        <ItemTemplate>
                            <div class="threadContainer row">
                                <a class="userInformation link-text-view col-3" href='<%# @"/WebPage/Profile.aspx?userid=" + Eval("userid") %>'>
                                    <div class="image-holder mb-3">
                                        <asp:Image CssClass="userProfileImage" runat="server" ImageUrl='<%#ImageUtil.GetBase64PathByByteArray(Eval("profileImage"))%>' />
                                    </div>
                                    <asp:Label runat="server" Text='<%# Eval("username") %>' />
                                </a>
                                <div class="threadInformation col-9 d-flex flex-column justify-content-between">
                                    <div class="threadInformation link-text-view">
                                        <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("comment") %>' />
                                    </div>
                                    <div>
                                        <hr />
                                        <div class="row">
                                            <div class="col-8"></div>
                                            <asp:Label CssClass="threadDate col-4" runat="server" Text='<%# Eval("commentdate") %>' />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <!-- Insert comment -->
        <!-- TODO remove internal style -->
        <asp:TextBox ID="ReplyThread" TextMode="MultiLine" type="text" placeHolder="reply here" runat="server" Height="100px" Width="880px"></asp:TextBox>
        <asp:Button ID="ReplyBtn" runat="server" Text="Reply" CssClass="mt-0" OnClick="ReplyBtn_Click" />
    </div>

    <!-- Data Sources -->
    <asp:SqlDataSource ID="ThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId as threadid, Threads.userId as userid, Threads.title as title, Threads.[content] as content, Threads.threadDate AS date, Tag.tagName as tagname, Users.profileImage as profileimage, Users.username as username FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId left outer join users on users.userid=threads.userid where threads.threadid=@threadid">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ThreadCommentData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ThreadComment.userId as userid, Users.username as username, Users.profileimage as profileimage, ThreadComment.comment as comment, ThreadComment.commentDate as commentdate FROM ThreadComment LEFT OUTER JOIN Users ON ThreadComment.userId = Users.userId WHERE (ThreadComment.threadId = @threadId)">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
