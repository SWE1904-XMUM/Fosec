<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Fosec.WebPage.Thread" %>

<%@ Import Namespace="Fosec.Utils" %>

<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
    Thread - Fosec
</asp:Content>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container d-flex flex-column align-items-center my-5" id="errorContainer" runat="server">
        <img src="/Resources/Image/error-icon.png" />
        <p class="display-3 text-uppercase">Error!</p>
        <p class="display-6">This page does not exist</p>
        <asp:LinkButton CssClass="btn" runat="server" PostBackUrl="/WebPage/Home.aspx" Text="Go back to Home"></asp:LinkButton>
    </div>
    <div class="container px-5" id="threadContainer" runat="server">
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
                                <div class="d-flex flex-row justify-content-between">
                                    <asp:Label CssClass="threadTitle" runat="server" Text='<%# Eval("title") %>' />
                                    <div class="dropdown">
                                        <asp:LinkButton ID="threadDropdown" runat="server" CssClass="btn primaryBtn" data-bs-toggle="dropdown" aria-expanded="false" Visible='<%# ViewState["btn"] %>'>
                                        <i class="bi bi-three-dots-vertical"></i>
                                        </asp:LinkButton>
                                        <ul class="dropdown-menu dropdown-menu-end" runat="server" aria-labelledby="threadDropdown">
                                            <li>
                                                <asp:LinkButton ID="editBtn" runat="server" CssClass="dropdown-item" href='<%# @"/WebPage/CreateThread.aspx?threadid=" + Eval("threadId") %>' Text="Edit"></asp:LinkButton><li>
                                            <li>
                                                <asp:Button ID="deleteBtn" CssClass="dropdown-item" runat="server" OnClick="DelBtn_Click" Text="Delete" /></li>
                                        </ul>
                                    </div>
                                </div>
                                <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                            </div>
                            <div>
                                <hr />
                                <div class="row">
                                    <div class="tagName col-8">
                                        <asp:LinkButton ID="TagButton" CssClass="btn no-hover tag-in-thread" runat="server" href='<%# @"/WebPage/Home.aspx?tagName=" + Eval("tagName") %>'><%# Eval("tagName") %></asp:LinkButton>
                                    </div>
                                    <asp:Label CssClass="threadDate col-4 text-right" runat="server" Text='<%# Eval("date") %>' />
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
                                            <asp:Label CssClass="threadDate col-4 text-right" runat="server" Text='<%# Eval("commentdate") %>' />
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
        <div class="row d-flex justify-content-end mb-3 mx-5">
            <div id="commentEnabledContainer" runat="server" visible="false">
                <div class="row">
                    <asp:Label class="text-right" ID="commentCharacterCount" runat="server"></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox ID="ReplyThread" CssClass="form-control" TextMode="MultiLine" type="text" placeHolder="Reply here" runat="server" Rows="6"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button ID="ReplyBtn" runat="server" Text="Reply" CssClass="btn px-5 my-3" OnClick="ReplyBtn_Click" />
                </div>
            </div>
            <div id="commentDisabledContainer" class="d-flex justify-content-center text-center my-5" runat="server">
                <div>
                    <p>Please Login before comment this thread.</p>
                    <asp:LinkButton runat="server" PostBackUrl="/WebPage/SignupAndLogin.aspx?action=login" Text="Login" CssClass="btn"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <!-- Data Sources -->
    <asp:SqlDataSource ID="ThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT Threads.threadId as threadid, Threads.userId as userid, Threads.title as title, Threads.[content] as content,
        Threads.threadDate AS date, Tag.tagName as tagname, Users.profileImage as profileimage, 
        Users.username as username FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId left outer 
        join users on users.userid=threads.userid where threads.threadid=@threadid">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="ThreadCommentData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ThreadComment.userId as userid, Users.username as username, Users.profileimage as profileimage, ThreadComment.comment as comment, ThreadComment.commentDate as commentdate FROM ThreadComment LEFT OUTER JOIN Users ON ThreadComment.userId = Users.userId WHERE (ThreadComment.threadId = @threadId)">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
        </SelectParameters>
    </asp:SqlDataSource>

    <script type="text/javascript">
        UpdateCommentCharacterCount();

        document.querySelector("#PageContent_ReplyThread").onkeyup = UpdateCommentCharacterCount;

        function UpdateCommentCharacterCount() {
            UpdateCharacterCount(
                document.querySelector("#PageContent_commentCharacterCount"),
                document.querySelector("#PageContent_ReplyThread").value.length,
                999
            );
        }
    </script>

</asp:Content>
