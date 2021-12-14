<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Fosec.WebPage.Home" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO home page content -->
    <div id="tagContainer">
        <asp:Repeater ID="tagRepeater" runat="server" DataSourceID="TagDataSource">
            <ItemTemplate>
                <asp:Button class="btn tag-btn" runat="server" Text='<%# Eval("tagname") %>' OnClick="TagButtonClick" CommandArgument='<%# Eval("tagname") %>' />
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="TagDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Tag]"></asp:SqlDataSource>
    </div>

    <div class="row">
        <asp:HyperLink CssClass="text-right" NavigateUrl="/WebPage/CreateThread.aspx" runat="server">
            <asp:Label CssClass="btn" Text="Create New Thread" runat="server" />
        </asp:HyperLink>
    </div>

    <!-- TODO selected tag -->
    <asp:Label Text="All" ID="selectedTagName" runat="server"></asp:Label>

    <!-- TODO threads -->
    <div id="homeThreadContainer">
        <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="ThreadDataSource">
            <ItemTemplate>
                <itemtemplate>
                    <div class="threadContainer row">
                        <div class="col-3">
                            <asp:Label CssClass="threadId row" runat="server" Text='<%# Eval("threadId") %>' />
                            <asp:Label CssClass="threadUserId row" runat="server" Text='<%# Eval("userId") %>' />
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
        <asp:SqlDataSource ID="ThreadDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Threads.threadId as threadId, Threads.userId as userId, Threads.title as title, Threads.[content] as content, Threads.threadDate as date, Tag.tagName as tagName FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId WHERE (Tag.tagName = @tagName)">
            <SelectParameters>
                <asp:ControlParameter ControlID="selectedTagName" DefaultValue="" Name="tagName" PropertyName="Text" Type="Object" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>


