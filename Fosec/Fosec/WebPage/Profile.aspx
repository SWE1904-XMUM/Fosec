<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fosec.WebPage.Profile" %>

<%@ Import Namespace="Fosec.Utils" %>

<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
    Profile - Fosec
</asp:Content>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container d-flex flex-column align-items-center my-5" id="errorContainer" runat="server" visible="false">
        <img src="/Resources/Image/error-icon.png" />
        <p class="display-3 text-uppercase">Error!</p>
        <p class="display-6">This page does not exist</p>
        <asp:LinkButton CssClass="btn" runat="server" PostBackUrl="/WebPage/Home.aspx" Text="Go back to Home"></asp:LinkButton>
    </div>
    <div class="container" id="profileContainer" runat="server">
        <div class="row" id="profile-container">
            <div id="userInformationContainer" class="col-3 p-2">
                <asp:ListView ID="userProfile" runat="server" DataSourceID="LoggedInUserProfileData">
                    <ItemTemplate>
                        <div class="image-holder mb-3">
                            <asp:Image CssClass="userProfileImage" runat="server" ImageUrl='<%#ImageUtil.GetBase64PathByByteArray(Eval("profileImage"))%>' />
                        </div>
                        <h4>
                            <asp:Label runat="server"><%#Eval("username") %></asp:Label></h4>
                    </ItemTemplate>
                </asp:ListView>

                <!-- TODO improve ui -->
            </div>

            <div id="homeThreadContainer" class="col-9 p-1">
                <div class="profile-container">
                    <div class="title-container">
                        <h2>Profile</h2>
                    </div>
                    <div class="profile-info-container">
                        <asp:ListView ID="userProfileDetail" runat="server" DataSourceID="LoggedInUserProfileData">
                            <ItemTemplate>
                                <table class="profile">
                                    <tr>
                                        <td class="fixed-column-width">Username: </td>
                                        <td>
                                            <asp:Label runat="server"><%#Eval("username") %></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="fixed-column-width">Email: </td>
                                        <td>
                                            <asp:Label runat="server"><%#Eval("email") %></asp:Label></td>
                                    </tr>
                                </table>

                            </ItemTemplate>
                        </asp:ListView>
                        <!-- TODO separate edit function -->
                        <table class="profile">
                            <tr>
                                <td class="fixed-column-width">Profile Picture: </td>
                                <td>
                                    <asp:FileUpload ID="uploadProfileImage" runat="server" /></td>
                            </tr>
                        </table>
                        <asp:Button Text="Submit" ID="submitProfileBtn" CssClass="btn" runat="server" OnClick="SubmitProfileImage" />
                    </div>
                </div>
                <div class="profile-container">
                    <div class="title-container">
                        <h2>Asked Questions</h2>
                    </div>
                    <div class="profile-info-container">
                        <asp:Repeater ID="userThreadRepeater" runat="server" DataSourceID="LoggedInUserThreadData">
                            <ItemTemplate>
                                <itemtemplate>
                                    <div class="threadContainer row">
                                        <a class="link-text-view px-4 py-2" href='<%# @"/WebPage/Thread.aspx?threadid=" + Eval("threadId") %>'>
                                            <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                            <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                        </a>
                                        <div class="row">
                                            <div class="tagName col-8">
                                                <asp:Label CssClass="btn tag-btn" runat="server" Text='<%# Eval("tagName") %>' />
                                            </div>
                                            <asp:Label CssClass="threadDate col-4 text-right" runat="server" Text='<%# Eval("date") %>' />
                                        </div>
                                    </div>
                                    <br />
                                </itemtemplate>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Datasources for logged in users -->
    <asp:SqlDataSource ID="LoggedInUserProfileData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [email], [profileImage] FROM [Users] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="LoggedInUserThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId as threadid, Threads.title as title, Tag.tagName as tagname, Threads.[content] as content, Threads.threadDate as date FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = tag.tagid LEFT OUTER JOIN Users ON Threads.userId = Users.userId WHERE (Users.username = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" />
        </SelectParameters>
    </asp:SqlDataSource>

    <!-- Datasources for other users -->
    <asp:SqlDataSource ID="OtherUserProfileData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [email], [profileImage] FROM [Users] WHERE (userid = @userid)">
        <SelectParameters>
            <asp:QueryStringParameter Name="userid" QueryStringField="userid" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="OtherUserThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId as threadid, Threads.title as title, Tag.tagName as tagname, Threads.[content] as content, Threads.threadDate as date FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = tag.tagid LEFT OUTER JOIN Users ON Threads.userId = Users.userId WHERE (Users.userid = @userid)">
        <SelectParameters>
            <asp:QueryStringParameter Name="userid" QueryStringField="userid" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


