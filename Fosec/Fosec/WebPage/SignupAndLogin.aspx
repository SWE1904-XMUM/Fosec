<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="SignupAndLogin.aspx.cs" Inherits="Fosec.WebPage.SignupAndLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-sm-12" id="login-col">
                <input id="loginUname" type="text" placeholder="Your username"/>
                <br />
                <input id="loginPwd" type="password" placeholder="Your password"/>
                <br />
                <asp:Button ID="loginBtn" runat="server" Text="Login"/>
            </div>
            <div class="col-lg-6 col-sm-12" id="signup-col">
                <input id="signupEmail" type="text" placeholder="Email"/>
                <br />
                <input id="signupUname" type="text" placeholder="Username"/>
                <br />
                <input id="signupPwd" type="password" placeholder="Password"/>
                <br />
                <input id="signupConfirmPwd" type="password" placeholder="Re-type password"/>
                <br />
                <asp:Button ID="signupBtn" runat="server" Text="Signup"/>
            </div>
        </div>
    </div>
</asp:Content>