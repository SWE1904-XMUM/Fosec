<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fosec.WebPage.Profile" %>
<%@ Import Namespace="Fosec.SessionManager" %>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO profile page content -->
    <div id="profileContainer" class="row">
        <asp:ListView ID="ListView1" runat="server" DataSourceID="UserProfileData">
            <ItemTemplate>
                <p><%#Eval("username") %></p>
                <p><%#Eval("email") %></p>
            </ItemTemplate>
        </asp:ListView>
        <asp:ListView ID="ListView2" runat="server" DataSourceID="UserThreadData" DataKeyNames="threadId">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="threadIdLabel" runat="server" Text='<%# Eval("threadId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="userIdLabel" runat="server" Text='<%# Eval("userId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tagNoLabel" runat="server" Text='<%# Eval("tagNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tagNameLabel" runat="server" Text='<%# Eval("tagName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    </td>
                    <td>
                        <asp:Label ID="threadDateLabel" runat="server" Text='<%# Eval("threadDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:Label ID="threadIdLabel1" runat="server" Text='<%# Eval("threadId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="userIdTextBox" runat="server" Text='<%# Bind("userId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="tagNoTextBox" runat="server" Text='<%# Bind("tagNo") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="tagNameTextBox" runat="server" Text='<%# Bind("tagName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="contentTextBox" runat="server" Text='<%# Bind("content") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="threadDateTextBox" runat="server" Text='<%# Bind("threadDate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="usernameTextBox" runat="server" Text='<%# Bind("username") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="userIdTextBox" runat="server" Text='<%# Bind("userId") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="tagNoTextBox" runat="server" Text='<%# Bind("tagNo") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="tagNameTextBox" runat="server" Text='<%# Bind("tagName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="contentTextBox" runat="server" Text='<%# Bind("content") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="threadDateTextBox" runat="server" Text='<%# Bind("threadDate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="usernameTextBox" runat="server" Text='<%# Bind("username") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="threadIdLabel" runat="server" Text='<%# Eval("threadId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="userIdLabel" runat="server" Text='<%# Eval("userId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tagNoLabel" runat="server" Text='<%# Eval("tagNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tagNameLabel" runat="server" Text='<%# Eval("tagName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    </td>
                    <td>
                        <asp:Label ID="threadDateLabel" runat="server" Text='<%# Eval("threadDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                                <tr runat="server" style="">
                                    <th runat="server">threadId</th>
                                    <th runat="server">userId</th>
                                    <th runat="server">title</th>
                                    <th runat="server">tagNo</th>
                                    <th runat="server">tagName</th>
                                    <th runat="server">content</th>
                                    <th runat="server">threadDate</th>
                                    <th runat="server">username</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style=""></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="threadIdLabel" runat="server" Text='<%# Eval("threadId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="userIdLabel" runat="server" Text='<%# Eval("userId") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tagNoLabel" runat="server" Text='<%# Eval("tagNo") %>' />
                    </td>
                    <td>
                        <asp:Label ID="tagNameLabel" runat="server" Text='<%# Eval("tagName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
                    </td>
                    <td>
                        <asp:Label ID="threadDateLabel" runat="server" Text='<%# Eval("threadDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>
    <!-- Datasources -->
    <asp:SqlDataSource ID="UserProfileData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [username], [email] FROM [Users] WHERE ([username] = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="UserThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId, Threads.userId, Threads.title, Threads.tagNo, Tag.tagName, Threads.[content], Threads.threadDate, Users.username FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = tag.tagid LEFT OUTER JOIN Users ON Threads.userId = Users.userId WHERE (Users.username = @username)">
        <SelectParameters>
            <asp:SessionParameter Name="username" SessionField="uname" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

