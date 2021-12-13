<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Fosec.WebPage.Thread" %>


<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <style>
        div{
            justify-content:center;
            align-content:center;
               
        }
    </style>
    <!-- TODO thread page content -->
    <div style="margin: auto auto auto auto; width: 700px">
    <asp:TextBox ID="TextBox1" runat="server" Height="134px" Width="565px"></asp:TextBox>
    <br /><br /> 
    <asp:TextBox ID="TextBox2" TextMode="MultiLine" type="text" placeHolder="reply here" runat="server" Height="100px" Width="581px"></asp:TextBox>
    <asp:Button ID="ReplyBtn" runat="server" Text="Reply" CssClass="mt-0" OnClick="ReplyBtn_Click" />
    </div>
</asp:Content>
