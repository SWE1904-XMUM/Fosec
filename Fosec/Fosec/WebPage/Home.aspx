<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Fosec.WebPage.Home" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO home page content -->
    <div class="container">
        <div id="tagContainer">
            <asp:Button class="btn tag-btn" runat="server" Text='All' OnClick="TagButtonClick"/>
            <asp:Repeater ID="tagRepeater" runat="server" DataSourceID="TagDataSource">
                <ItemTemplate>
                    <asp:Button class="btn tag-btn" runat="server" Text='<%# Eval("tagname") %>' OnClick="TagButtonClick" />
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="row">
            <asp:HyperLink CssClass="text-right" NavigateUrl="/WebPage/CreateThread.aspx" runat="server">
            <asp:Label CssClass="btn" Text="Create New Thread" runat="server" />
            </asp:HyperLink></div><!-- TODO selected tag --><div class="sectionTitle row p-2">
            <asp:Label Text="All" ID="selectedTagName" class="text-center" runat="server"></asp:Label></div><!-- TODO threads --><div id="homeThreadContainer">
            <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="AllThreadDataSource">
                <ItemTemplate>
                    <itemtemplate>
                        <div class="threadContainer row">
                            <div class="userInformation col-3">
                                <asp:Label CssClass="threadUserId row" runat="server" Text='<%# "Userid: " + Eval("userId") %>' />
                            </div>
                            <div class="threadInformation col-9">
                                <a class="threadInformation link-text-view" href='<%# @"/Webpage/Thread.aspx?threadid=" + Eval("threadId") %>'>
                                    <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                    <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                </a>
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

            <%--Data Sources--%>
            <asp:SqlDataSource ID="TagDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Tag]"></asp:SqlDataSource>
            <asp:SqlDataSource ID="AllThreadDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId, Threads.userId, Threads.title, Threads.[content], Threads.threadDate AS date, Tag.tagName FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId ORDER BY date DESC"></asp:SqlDataSource>
            <asp:SqlDataSource ID="FilteredThreadDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId, Threads.userId, Threads.title, Threads.[content], Threads.threadDate AS date, Tag.tagName FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId WHERE (Tag.tagName = @tagName) ORDER BY date DESC"><SelectParameters>
                    <asp:ControlParameter ControlID="selectedTagName" DefaultValue="" Name="tagName" PropertyName="Text" Type="Object" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>


