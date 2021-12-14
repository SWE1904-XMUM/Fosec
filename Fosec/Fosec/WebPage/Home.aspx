<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Fosec.WebPage.Home" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO home page content -->
    <div id="tagContainer">
        <asp:ListView runat="server" DataSourceID="TagDataSource" DataKeyNames="tagId">
            <grouptemplate>
                <div id="itemPlaceholderContainer" runat="server">
                    <div id="itemPlaceholder" runat="server"></div>
                </div>
            </grouptemplate>
            <itemtemplate>
                <div class="btn" runat="server">
                    <asp:Label ID="tagNameLabel" runat="server" Text='<%# Eval("tagName") %>' />
                </div>
            </itemtemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="TagDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Tag]"></asp:SqlDataSource>

    </div>
</asp:Content>

