<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="SignupAndLogin.aspx.cs" Inherits="Fosec.WebPage.SignupAndLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6 col-sm-12" id="login-col">
                <asp:TextBox id="loginUname" type="text" placeholder="Your username" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox id="loginPwd" type="password" placeholder="Your password" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="loginBtn" runat="server" Text="Login" OnClick="loginBtn_Click"/>
            </div>
            <div class="col-lg-6 col-sm-12" id="signup-col">
                <asp:TextBox id="signupEmail" type="text" placeholder="Email" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox id="signupUname" type="text" placeholder="Username" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox id="signupPwd" type="text" placeholder="Password" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox id="signupConfirmPwd" type="password" placeholder="Re-type password" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="signupBtn" runat="server" Text="Signup"/>
            </div>
        </div>
    </div>
</asp:Content>