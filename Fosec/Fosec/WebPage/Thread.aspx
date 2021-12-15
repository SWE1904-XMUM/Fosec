<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Fosec.WebPage.Thread" %>


<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <style>
        div{
            justify-content:center;
            align-content:center;
               
        }
    </style>
    <!-- TODO thread page content -->
    <div style="margin: auto auto auto auto; width: 1000px">
    <br />
        
        <asp:SqlDataSource ID="ThreadData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Threads] WHERE (Threads.threadID=1)"></asp:SqlDataSource>
        <br /> 
                <div id="homeThreadContainer">
            <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="ThreadData">
                <ItemTemplate>
                    <itemtemplate>
                        <div class="threadContainer row">
                            <div class="col-3">
                                <asp:Label CssClass="threadId row" runat="server" Text='<%# Eval("threadId") %>' />
                                <asp:Label CssClass="threadUserId row" runat="server" Text='<%# Eval("userId") %>' />
                            </div>
                            <div class="col-9">
                                <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                
                            </div>
                            <br />
                        </div>
                    </itemtemplate>
                </ItemTemplate>
            </asp:Repeater>
    <asp:TextBox ID="ReplyThread" TextMode="MultiLine" type="text" placeHolder="reply here" runat="server" Height="100px" Width="581px"></asp:TextBox>
    <asp:Button ID="ReplyBtn" runat="server" Text="Reply" CssClass="mt-0" OnClick="ReplyBtn_Click" />
    </div>
</asp:Content>
