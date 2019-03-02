<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="ZonaIntegritas.aspx.cs" Inherits="Info_DPO" Title="Undang-Undang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script lang="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-info">
        <div class="content-inner">
            <div id="main-content" role="main">
                <div id="content">
                    <div id="content">
                        <div class="view view-info view-id-info view-display-id-page_2 ">
                            <div class="view-content">
                                <asp:HiddenField ID="RowCountHidden" runat="server" />
                                <table style="width:100%">
                                    <tr class="headerTable" style="border-style:none !important;">
                                        <td style="width:10%;"> No
                                        </td>
                                        <td style="width:80%; text-align:center;"> Undang - Undang 
                                        </td>
                                        <td style="width:20%;">Download 
                                        </td>
                                    </tr>
                                    <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound"
                                        OnItemCommand="ListRepeater_ItemCommand">
                                        <ItemTemplate>
                                            <tr id="RepeaterItemTemplate" runat="server">
                                                <td>
                                                    <asp:Literal ID="NoLiteral" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:Literal ID="NamaUULiteral" runat="server"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="UULinkButton" runat="server" Text="Download" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <table border="0">
                                                <tr>
                                                    <td>
                                                        <asp:Panel DefaultButton="DataPagerBottomButton" ID="Panel3" runat="server">
                                                            <table border="0">
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
                                                                            &nbsp;
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
