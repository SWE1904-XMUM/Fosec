<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Fosec.WebPage.Profile" %>
<%@ Import Namespace="Fosec.SessionManager" %>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO profile page content -->
   <%= SessionManager.GetUsername() %>
</asp:Content>

