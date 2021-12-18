<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Fosec.WebPage.CreateThread" %>

<asp:Content ContentPlaceHolderID="PageTitle" runat="server">
    Create Thread - Fosec
</asp:Content>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container d-flex flex-column align-items-center my-5" id="errorContainer" runat="server" visible="false">
        <img src="/Resources/Image/error-icon.png" />
        <p class="display-3 text-uppercase">Error!</p>
        <p class="display-6">This page does not exist</p>
        <asp:LinkButton CssClass="btn" runat="server" PostBackUrl="/WebPage/Home.aspx" Text="Go back to Home"></asp:LinkButton>
    </div>
    <div class="container my-4" id="threadContainer" runat="server">
        <div class="row">
            <div class="mb-2">
                <label for="threadTitle" class="form-label thread-label">Title</label>
                <p class="thread-description">Be specific and imagine you're asking a question to another person</p>
                <div class="row">
                    <asp:Label class="text-right" ID="titleCharacterCount" runat="server"></asp:Label>
                </div>
                <asp:TextBox CssClass="form-control" ID="threadTitle" type="text" placeholder="Title" runat="server"></asp:TextBox>
            </div>
            <div class="mb-2">
                <label class="form-label thread-label">Subject</label>
                <div id="tagContainer">
                    <asp:PlaceHolder ID="tagPlaceHolder" runat="server"></asp:PlaceHolder>
                </div>
            </div>
            <div class="mb-2">
                <label for="content" class="form-label thread-label">Content</label>
                <p class="thread-description">Please include all the informations of your question</p>
                <div class="row">
                    <asp:Label class="text-right" ID="contentCharacterCount" runat="server"></asp:Label>
                </div>
                <asp:TextBox ID="content" CssClass="form-control" TextMode="MultiLine" type="text" placeholder="Content" runat="server" Rows="6"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" ID="submitThread" runat="server" Text="Submit" OnClick="submitThread_Click" />
        </div>
    </div>

    <script type="text/javascript">
        UpdateTitleCharacterCount();
        UpdateContentCharacterCount();

        document.querySelector("#PageContent_threadTitle").onkeyup = UpdateTitleCharacterCount;
        document.querySelector("#PageContent_content").onkeyup = UpdateContentCharacterCount;

        function UpdateTitleCharacterCount()
        {
            UpdateCharacterCount(
                document.querySelector("#PageContent_titleCharacterCount"),
                document.querySelector("#PageContent_threadTitle").value.length,
                150
            );
        }

        function UpdateContentCharacterCount()
        {
            UpdateCharacterCount(
                document.querySelector("#PageContent_contentCharacterCount"),
                document.querySelector("#PageContent_content").value.length,
                999
            )
        }
    </script>
</asp:Content>
