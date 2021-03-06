<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fosec.WebPage.Profile" %>

<%@ Import Namespace="Fosec.Utils" %>
<%@ Import Namespace="Fosec.Database" %>
<%@ Import Namespace="Fosec.Session" %>

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
                                    <asp:FileUpload ID="uploadProfileImage" runat="server" CssClass="form-control mx-2 mb-2" />
                                    <asp:Button ID="submitProfileImageBtn" runat="server" OnClick="SubmitProfileImage" CssClass="btn mx-2 mb-2" Text="Upload" />
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
                                    <asp:Button Text="Update Password" ID="updatePasswordBtn" runat="server" CssClass="btn mt-2" OnClick="UpdatePassword" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="profile-container">
                    <div class="title-container">
                        <h2><span><i class="bi bi-patch-question me-2"></i></span>Thread</h2>
                    </div>
                    <div class="profile-info-container">
                        <asp:ListView ID="userThreadRepeater" runat="server" DataSourceID="LoggedInUserThreadData">
                            <GroupTemplate>
                                <div runat="server" id="itemPlaceholderContainer">
                                    <div runat="server" id="itemPlaceholder"></div>
                                </div>
                            </GroupTemplate>
                            <LayoutTemplate>
                                <div runat="server" id="groupPlaceholderContainer">
                                    <div runat="server" id="groupPlaceholder"></div>
                                </div>
                                <hr />
                                <div runat="server" id="pagerContainer" class="d-flex align-items-center justify-content-around">
                                    <asp:DataPager runat="server" PageSize="10" ID="pager">
                                        <Fields>
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                ShowNextPageButton="false" ButtonCssClass="mx-2 btn primaryBtn" />
                                            <asp:NumericPagerField ButtonType="Button" NumericButtonCssClass="mx-2 btn primaryBtn" CurrentPageLabelCssClass="btn no-hover" />
                                            <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" ButtonCssClass="mx-2 btn primaryBtn" />
                                        </Fields>
                                    </asp:DataPager>
                                </div>
                            </LayoutTemplate>

                            <ItemTemplate>
                                <itemtemplate>
                                    <div class="threadContainer-profile row">
                                        <a class="link-text-view px-4 py-2" href='<%# @"/WebPage/Thread.aspx?threadid=" + Eval("threadId") %>'>
                                            <div class="d-flex flex-row justify-content-between">
                                                <asp:Label CssClass="threadTitle" runat="server" Text='<%# Eval("title") %>' />
                                                <div class="dropdown">
                                                    <asp:LinkButton ID="threadDropdown" runat="server" CssClass="btn primaryBtn" data-bs-toggle="dropdown" aria-expanded="false" Visible='<%# int.Parse(Eval("userid").ToString()) == UserDb.GetUserIdByUsername(SessionManager.GetUsername()) %>'>
                                        <i class="bi bi-three-dots-vertical"></i>
                                                    </asp:LinkButton>
                                                    <ul class="dropdown-menu dropdown-menu-end" runat="server" aria-labelledby="threadDropdown">
                                                        <li>
                                                            <asp:LinkButton ID="editBtn" runat="server" CssClass="dropdown-item" href='<%# @"/WebPage/CreateThread.aspx?threadid=" + Eval("threadId") %>' Text="Edit"></asp:LinkButton><li>
                                                        <li>
                                                            <asp:Button ID="deleteBtn" CssClass="dropdown-item" runat="server" OnClick="DelBtn_Click" Text="Delete" CommandArgument='<%#Eval("threadid") %>' /></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                        </a>
                                        <div class="row">
                                            <div class="tagName col-8">
                                                <asp:LinkButton ID="TagButton" CssClass="btn tag-btn no-hover tag-in-thread" runat="server" href='<%# @"/WebPage/Home.aspx?tagName=" + Eval("tagName") %>'><%# Eval("tagName") %></asp:LinkButton>
                                            </div>
                                            <asp:Label CssClass="threadDate col-4 text-right" runat="server" Text='<%# Eval("date") %>' />
                                        </div>
                                    </div>
                                    <br />
                                </itemtemplate>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Datasources for logged in users -->
    <asp:SqlDataSource ID="LoggedInUserProfileData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT username, email, profileImage FROM Users WHERE (username = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="LoggedInUserThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Users.userId as userid, Threads.threadId as threadid, Threads.title as title, Tag.tagName as tagname, Threads.[content] as content, Threads.threadDate as date FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = tag.tagid LEFT OUTER JOIN Users ON Threads.userId = Users.userId WHERE (Users.username = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" />
        </SelectParameters>
    </asp:SqlDataSource>

    <!-- Datasources for other users -->
    <asp:SqlDataSource ID="OtherUserProfileData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT username as username, email as email, profileImage FROM Users WHERE (userid = @userid)">
        <SelectParameters>
            <asp:QueryStringParameter Name="userid" QueryStringField="userid" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="OtherUserThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Users.userId as userid, Threads.threadId as threadid, Threads.title as title, Tag.tagName as tagname, Threads.[content] as content, Threads.threadDate as date FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = tag.tagid LEFT OUTER JOIN Users ON Threads.userId = Users.userId WHERE (Users.userid = @userid)">
        <SelectParameters>
            <asp:QueryStringParameter Name="userid" QueryStringField="userid" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


