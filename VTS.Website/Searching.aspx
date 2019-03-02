<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="Searching.aspx.cs" Inherits="Reskrimsus.Website.Searching" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="URLFileHiddenField" runat="server" />
    <asp:HiddenField ID="RowCountHidden" runat="server" />
    <div style="width: 15%; float: left;">
        &nbsp;
    </div>
    <div style="width: 70%; float: left;">
        <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
            <ItemTemplate>
                <div id="searchcontent">
                    <div style="float: left; width: 20%;">
                        <asp:HyperLink ID="PhotoHyperlink" runat="server">
                            <asp:Image ID="PhotoImage" runat="server" />
                        </asp:HyperLink>
                    </div>
                    <div style="width: 80%;">
                        <div>
                            <b>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="CategoryHyperLink" Style="text-decoration: none; color: #603813;
                                                font-size: 14px;" runat="server"></asp:HyperLink>
                                        </td>
                                        <td>
                                            <asp:Image ID="WatchImage" runat="server" ImageUrl="~/Content/Images/watch.png" Height="20"
                                                Width="20" />
                                        </td>
                                        <td>
                                            <asp:Literal ID="CreatedDateLiteral" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                </table>
                            </b>
                        </div>
                        <div>
                            <b>
                                <asp:HyperLink ID="TitleHyperLink" Style="text-decoration: none; color: Black;" runat="server"></asp:HyperLink></b></div>
                        <div class="ContentSearch" style="width: 75%;">
                            <asp:Literal ID="ContentLiteral" runat="server"></asp:Literal>
                            <asp:Label ID="ContentLabel" EnableViewState="false" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <table cellpadding="3" cellspacing="0" width="100%" border="0">
            <tr>
                <td align="center">
                    <asp:Panel DefaultButton="DataPagerBottomButton" ID="Panel3" runat="server">
                        <table border="0" cellpadding="2" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Button ID="DataPagerBottomButton" runat="server" OnClick="DataPagerBottomButton_Click" />
                                </td>
                                <td>
                                    <b>Halaman :</b>
                                </td>
                                <asp:Repeater EnableViewState="true" ID="DataPagerBottomRepeater" runat="server"
                                    OnItemCommand="DataPagerTopRepeater_ItemCommand" OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                    <ItemTemplate>
                                        <td>
                                            <asp:LinkButton ID="PageNumberLinkButton" runat="server" CssClass="PageNumberLinkButton"></asp:LinkButton>
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
    <div style="width: 15%; float: left;">
        &nbsp;
    </div>
</asp:Content>
