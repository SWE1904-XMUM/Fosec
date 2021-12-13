<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Fosec.WebPage.CreateThread" %>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:TextBox id="threadTitle" type="text" placeholder="Title" runat="server"></asp:TextBox>
            <div class="col-lg-3">
                <!--TODO create multiple tag-->
                <asp:Button ID="tag" runat="server" Text="Chinese" />
            </div>
            <asp:TextBox id="content" TextMode="MultiLine" type="text" placeholder="Content" runat="server"></asp:TextBox>
            <asp:Button ID="submitThread" runat="server" Text="Submit" />
        </div>
    </div>
</asp:Content>
