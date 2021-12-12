<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="SignupAndLogin.aspx.cs" Inherits="Fosec.WebPage.SignupAndLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button runat="server" Text="Test" OnClick="Unnamed_Click"/>
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-sm-12">
                <h1>login</h1>
                <input id="loginUname" type="text" placeholder="Your username"/>
                <input id="loginPwd" type="password" placeholder="Your password"/>
                <asp:Button ID="loginBtn" runat="server" Text="Login" /> 
            </div>
            <div class="col-lg-6 col-sm-12">
                <h1>signup</h1>
                <input id="signupEmail" type="text" placeholder="Your username"/>
                <input id="signupUname" type="text" placeholder="Your username"/>
                <input id="signupPwd" type="password" placeholder="Your password"/>
                <input id="signupConfirmPwd" type="password" placeholder="Your password"/>
                <asp:Button ID="signupBtn" runat="server" Text="Login" />
            </div>
        </div>
    </div>
</asp:Content>
