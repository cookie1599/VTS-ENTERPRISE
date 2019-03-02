<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="Peraturan.aspx.cs" Inherits="Peraturan" Title="Peraturan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-info">
        <div class="content-inner">
            <div id="main-content" role="main">
                <div id="content">
                    <asp:HiddenField ID="RowCountHidden" runat="server" />
                    <table>
                        <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound"
                            OnItemCommand="ListRepeater_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="UULinkButton" runat="server">
                                            <asp:Literal ID="NamaUULiteral" runat="server"></asp:Literal></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <%-- <img id="Img1" runat="server" src="~/Content/Images/coming soon.jpg" />--%>
                    <table cellpadding="3" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td align="right">
                                <asp:Panel DefaultButton="DataPagerBottomButton" ID="Panel3" runat="server">
                                    <table border="0" cellpadding="2" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Button ID="DataPagerBottomButton" runat="server" OnClick="DataPagerBottomButton_Click" />
                                            </td>
                                            <td>
                                                <b>Page :</b>
                                            </td>
                                            <asp:Repeater EnableViewState="true" ID="DataPagerBottomRepeater" runat="server"
                                                OnItemCommand="DataPagerTopRepeater_ItemCommand" OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                <ItemTemplate>
                                                    <td>
                                                        <asp:LinkButton ID="PageNumberLinkButton" runat="server"></asp:LinkButton>
                                                        <asp:TextBox Visible="false" ID="PageNumberTextBox" runat="server" Width="30px"></asp:TextBox>
                                                    </td>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
