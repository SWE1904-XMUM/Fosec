<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Fosec.WebPage.CreateThread" %>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:TextBox id="threadTitle" type="text" placeholder="Title" runat="server"></asp:TextBox>
            <asp:PlaceHolder ID="tag" runat="server"></asp:PlaceHolder>
            <asp:TextBox id="content" TextMode="MultiLine" type="text" placeholder="Content" runat="server"></asp:TextBox>
            <asp:Button ID="submitThread" runat="server" Text="Submit" />
        </div>
    </div>
</asp:Content>
