<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fosec.WebPage.Profile" %>
<%@ Import Namespace="Fosec.Utils" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO profile page content -->
    <div class="container">
        <div class="row" id="profile-container">
            <div id="userInformationContainer" class="col-3 p-2">
                <asp:ListView ID="ListView1" runat="server" DataSourceID="UserProfileData">
                    <ItemTemplate>
                        <div class="image-holder mb-3">
                            <asp:Image CssClass="userProfileImage" runat="server" ImageUrl='<%#ImageUtil.GetBase64PathByByteArray(Eval("profileImage"))%>' />
                        </div>
                        <h4><asp:Label runat="server"><%#Eval("username") %></asp:Label></h4>
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
                        <asp:ListView ID="ListView2" runat="server" DataSourceID="UserProfileData">
                            <ItemTemplate>
                                <table class="profile">
                                    <tr>
                                        <td class="fixed-column-width">Username: </td>
                                        <td><asp:Label runat="server"><%#Eval("username") %></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="fixed-column-width">Email: </td>
                                        <td><asp:Label runat="server"><%#Eval("email") %></asp:Label></td>
                                    </tr>
                                  </table>
                                    
                            </ItemTemplate>
                        </asp:ListView>
                        <table class="profile">
                            <tr>
                                <td class="fixed-column-width">Profile Picture: </td>
                                <td><asp:FileUpload ID="uploadProfileImage" runat="server"/></td>
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
                        <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="UserThreadData">
                            <ItemTemplate>
                                <itemtemplate>
                                    <div class="threadContainer row">
                                        <%--<div class="col-3">
                                            <asp:Label CssClass="threadId row" runat="server" Text='<%# Eval("threadId") %>' />
                                        </div>--%>
                                        <%--<div class="col-9">--%>
                                            <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                            <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                            <div class="row">
                                                <div class="tagName col-8">
                                                    <asp:Label CssClass="btn tag-btn" runat="server" Text='<%# Eval("tagName") %>' />
                                                </div>
                                                <asp:Label CssClass="threadDate col-4" runat="server" Text='<%# Eval("date") %>' />
                                            </div>
                                        </div>
                                        <br />
                                   <%-- </div>--%>
                                </itemtemplate>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Datasources -->
    <asp:SqlDataSource ID="UserProfileData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [email], [profileImage] FROM [Users] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="UserThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId as threadid, Threads.title as title, Tag.tagName as tagname, Threads.[content] as content, Threads.threadDate as date FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = tag.tagid LEFT OUTER JOIN Users ON Threads.userId = Users.userId WHERE (Users.username = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

