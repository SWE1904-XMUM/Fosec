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
                <div class="row">
                    <asp:Label class="text-right" ID="titleCharacterCount" runat="server"></asp:Label>
                </div>
                <asp:TextBox CssClass="form-control" ID="threadTitle" type="text" placeholder="Title" runat="server"></asp:TextBox>
            </div>
            <div id="tagContainer">
                <asp:PlaceHolder ID="tagPlaceHolder" runat="server"></asp:PlaceHolder>
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

        function UpdateTitleCharacterCount() {
            UpdateCharacterCount(
                document.querySelector("#PageContent_titleCharacterCount"),
                document.querySelector("#PageContent_threadTitle").value.length,
                150
            );
        }

        function UpdateContentCharacterCount() {
            UpdateCharacterCount(
                document.querySelector("#PageContent_contentCharacterCount"),
                document.querySelector("#PageContent_content").value.length,
                999
            )
        }

        function UpdateCharacterCount(characterCountTextHolder, targetText_length, maxLength) {
            characterCountTextHolder.innerHTML = targetText_length + "/" + maxLength + " characters";
            if (targetText_length > maxLength) {
                characterCountTextHolder.style.color = "#FF0000";
            }
            else {
                characterCountTextHolder.style.color = "#000000";
            }
        }
    </script>
</asp:Content>
