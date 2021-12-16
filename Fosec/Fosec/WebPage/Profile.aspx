<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fosec.WebPage.Profile" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO profile page content -->
    <div id="container" class="row">
        <div id="userInformationContainer" class="col-3 p-2">
            <asp:ListView ID="ListView1" runat="server" DataSourceID="UserProfileData">
                <ItemTemplate>
                    <asp:Image CssClass="userProfileImage" runat="server" ImageUrl='<%# Eval("profileImage").GetType() != typeof(System.DBNull) ? @"data:image/png;base64," + Convert.ToBase64String((byte[]) Eval("profileImage")) : @"/Resources/Image/defaultProfileImage.png"%>' />
                    <asp:Label runat="server"><%#Eval("username") %></asp:Label>
                    <asp:Label runat="server"><%#Eval("email") %></asp:Label>
                </ItemTemplate>
            </asp:ListView>
            <!-- TODO improve ui -->
            <hr />
            <p>Upload Profile Image</p>
            <asp:FileUpload ID="uploadProfileImage" runat="server" />
            <asp:Button Text="Submit" ID="submitProfileBtn" runat="server" OnClick="SubmitProfileImage" />
        </div>

        <div id="homeThreadContainer" class="col-9 p-1">
            <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="UserThreadData">
                <ItemTemplate>
                    <itemtemplate>
                        <div class="threadContainer row">
                            <div class="col-3">
                                <asp:Label CssClass="threadId row" runat="server" Text='<%# Eval("threadId") %>' />
                            </div>
                            <div class="col-9">
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
                        </div>
                    </itemtemplate>
                </ItemTemplate>
            </asp:Repeater>
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

