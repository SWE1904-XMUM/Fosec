<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="CreateThread.aspx.cs" Inherits="Fosec.WebPage.CreateThread" %>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container">
        <div class="row">
            <input id="threadTitle" type="text" placeholder="Title"/>
            <div class="col-lg-3">
                <!--TODO create multiple tag-->
                <asp:Button ID="tag" runat="server" Text="Chinese" />
            </div>
            <textarea id="content" cols="20" rows="2" placeholder="Content"></textarea>
            <asp:Button ID="submitThread" runat="server" Text="Submit" />
        </div>
    </div>
</asp:Content>
