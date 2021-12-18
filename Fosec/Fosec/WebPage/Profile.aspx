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
            </div>

            <div id="homeThreadContainer" class="col-9 p-1">
                <div class="profile-container">
                    <div class="title-container">
                        <h2><span><i class="bi bi-person-fill me-1"></i></span>Profile</h2>
                    </div>
                    <div class="profile-info-container mx-2">
                        <asp:ListView ID="userProfileDetail" runat="server" DataSourceID="LoggedInUserProfileData">
                            <ItemTemplate>
                                <table class="profile">
                                    <thead>
                                        <tr>
                                            <th class="col-4"></th>
                                            <th class="col-4"></th>
                                        </tr>
                                    </thead>
                                    <tr>
                                        <td class="fw-bold">Username: </td>
                                        <td>
                                            <asp:Label runat="server"><%#Eval("username") %></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="fw-bold">Email: </td>
                                        <td>
                                            <asp:Label runat="server"><%#Eval("email") %></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:ListView>

                        <div id="editProfileContainer" class="m-2" runat="server" visible="false">
                            <div class="m-1">
                                <asp:Button ID="openEditProfileImageContainerBtn" CssClass="btn" runat="server" Text="Change Profile Image" OnClick="DisplayProfileImageUploadForm" />
                                <asp:Button ID="openEditPasswordContainerBtn" CssClass="btn" runat="server" Text="Change Password" OnClick="DisplayChangePasswordForm" />
                            </div>
                            <div>
                                <div id="editProfileImageContainer" class="my-3 d-flex align-content-center flex-row flex-nowrap justify-content-center align-items-center" runat="server" visible="false">
                                    <asp:FileUpload ID="uploadProfileImage" runat="server" CssClass="form-control mx-2" />
                                    <asp:Button ID="submitProfileImageBtn" runat="server" OnClick="SubmitProfileImage" CssClass="btn mx-2" Text="Upload" />
                                </div>
                                <div id="editPasswordContainer" class="m-1" runat="server" visible="false">
                                    <asp:Table runat="server">
                                        <asp:TableHeaderRow>
                                            <asp:TableHeaderCell CssClass="col-4"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell CssClass="col-5"></asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label Text="Current Password: " CssClass="form-label" runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="currentPasswordField" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label Text="New password: " CssClass="form-label" runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="newPasswordField" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label Text="Confirm New Password: " CssClass="form-label" runat="server"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:TextBox ID="confirmNewPasswordField" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                    <asp:Button Text="Update Password" ID="updatePasswordBtn" runat="server" CssClass="btn" OnClick="UpdatePassword" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="profile-container">
                    <div class="title-container">
                        <h2><i class="bi bi-patch-question me-2"></i>Asked Questions</h2>
                    </div>
                    <div class="profile-info-container">
                        <asp:Repeater ID="userThreadRepeater" runat="server" DataSourceID="LoggedInUserThreadData">
                            <ItemTemplate>
                                <itemtemplate>
                                    <div class="threadContainer-profile row">
                                        <a class="link-text-view px-4 py-2" href='<%# @"/WebPage/Thread.aspx?threadid=" + Eval("threadId") %>'>
                                            <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                            <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                        </a>
                                        <div class="row">
                                            <div class="tagName col-8">
                                                <asp:Label CssClass="btn tag-btn no-hover tag-in-thread" runat="server" Text='<%# Eval("tagName") %>' />
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


