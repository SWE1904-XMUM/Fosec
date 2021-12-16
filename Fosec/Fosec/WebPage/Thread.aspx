<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Thread.aspx.cs" Inherits="Fosec.WebPage.Thread" %>


<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <style>
        div {
            justify-content: center;
            align-content: center;
        }
    </style>
    <!-- TODO thread page content -->
    <div style="margin: auto auto auto auto; width: 1000px">
        <br />

        <asp:SqlDataSource ID="AllThreadDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT Threads.threadId, Threads.userId, Threads.title, Threads.[content], Threads.threadDate AS date,
            Tag.tagName FROM Threads LEFT OUTER JOIN Tag ON Threads.tagNo = Tag.tagId WHERE (Threads.threadid = @threadId) ORDER BY date DESC">
            <SelectParameters>
                <asp:QueryStringParameter QueryStringField="threadid" Name="threadId" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <div id="homeThreadContainer">
            <asp:Repeater ID="threadRepeater" runat="server" DataSourceID="AllThreadDataSource">
                <ItemTemplate>
                    <itemtemplate>
                        <div class="threadContainer row">
                            <div class="userInformation col-3">
                                <asp:Label CssClass="threadUserId row" runat="server" Text='<%# "Userid: " + Eval("userId") %>' />
                            </div>
                            <div class="threadInformation col-9">
                                <a class="threadInformation link-text-view ">
                                    <asp:Label CssClass="threadTitle row" runat="server" Text='<%# Eval("title") %>' />
                                    <asp:Label CssClass="threadContent row" runat="server" Text='<%# Eval("content") %>' />
                                </a>
                                <hr />
                                <div>
                                    <div class="row">
                                        <div class="tagName col-8">
                                            <asp:Label CssClass="btn no-hover" runat="server" Text='<%# Eval("tagName") %>' />
                                        </div>
                                        <asp:Label CssClass="threadDate col-4" runat="server" Text='<%# Eval("date") %>' />
                                    </div>
                                </div>
                            </div>
                            <br />
                        </div>
                    </itemtemplate>
                </ItemTemplate>
            </asp:Repeater>
            <!--get threadComments here -->
            <asp:TextBox ID="ReplyThread" TextMode="MultiLine" type="text" placeHolder="reply here" runat="server" Height="100px" Width="880px"></asp:TextBox>
            <asp:Button ID="ReplyBtn" runat="server" Text="Reply" CssClass="mt-0" OnClick="ReplyBtn_Click" />
        </div>
    </div>
</asp:Content>
