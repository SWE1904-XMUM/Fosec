<%@ Page Title="" Language="C#" MasterPageFile="~/WebPage/Fosec.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Fosec.WebPage.Home" %>

<asp:Content ContentPlaceHolderID="PageContent" runat="server">
    <!-- TODO home page content -->
    <div id="tagContainer">
        <asp:ListView runat="server" DataSourceID="TagDataSource" DataKeyNames="tagId">
            <GroupTemplate>
                <div id="itemPlaceholderContainer" runat="server">
                    <div id="itemPlaceholder" runat="server"></div>
                </div>
            </GroupTemplate>
            <ItemTemplate>
                <div class="btn tag-btn" runat="server">
                    <asp:Label ID="tagNameLabel" runat="server" Text='<%# Eval("tagName") %>' />
                </div>
            </ItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="TagDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Tag]"></asp:SqlDataSource>
    </div>
    <script type="text/javascript">
        let tagBtnList = document.querySelectorAll(".tag-btn");
        for (let i = 0; i < tagBtnList.length; i++) {
            tagBtnList[i].onclick = tagBtnClick;
        }

        function tagBtnClick(e) {
            clearAllTagBtn();
            if (e.target.classList.contains("tag-btn") == false) {
                e.target.closest(".tag-btn").setAttribute("selected", true);
            }
            else {
                e.target.setAttribute("selected", true);
            }
        }

        function clearAllTagBtn() {
            for (let i = 0; i < tagBtnList.length; i++) {
                tagBtnList[i].setAttribute("selected", false);
            }
        }


    </script>
</asp:Content>


