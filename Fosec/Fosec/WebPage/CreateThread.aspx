<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Fosec.WebPage.CreateThread" %>

<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
    Create Thread - Fosec
</asp:Content>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container" id="thread-container">
        <div class="row">
            <div class="mb-2">
                <label for="threadTitle" class="form-label thread-label">Title</label>
                <p class="thread-description">Be specific and imagine you're asking a question to another person</p>
                <asp:TextBox CssClass="form-control" id="threadTitle" type="text" placeholder="Title" runat="server"></asp:TextBox>
            </div>
            <div id="tagContainer">
                <asp:PlaceHolder ID="tagPlaceHolder" runat="server"></asp:PlaceHolder>
            </div>
            <div class="mb-2">
                <label for="content" class="form-label thread-label">Content</label>
                <p class="thread-description">Please include all the informations of your question</p>
                <asp:TextBox id="content" CssClass="form-control" TextMode="MultiLine" type="text" placeholder="Content" runat="server" Rows="6"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" ID="submitThread" runat="server" Text="Submit" OnClick="submitThread_Click" />
        </div>
    </div>
</asp:Content>
