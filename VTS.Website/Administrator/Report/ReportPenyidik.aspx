<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="ReportPenyidik.aspx.cs" Inherits="ReportPenyidik" Title="Report Penyidik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link href="../../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../../Content/JScript.js" type="text/javascript"></script>

    <script src="../../Content/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script language="javascript" src="../../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="content-inner">
        <div id="main-content" role="main">
            <div id="content">
                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="tahoma_14_black">
                            <b>
                                <asp:Literal ID="PageTitleLiteral" runat="server" />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td class="warning">
                            <asp:Literal ID="Literal1" runat="server" Text="* This Report is Best Printed on Legal Size Paper" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel runat="server" ID="MenuPanel">
                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td>
                                            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="WarningLabel" runat="server" CssClass="warning"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="3" cellspacing="0" width="0">
                                                <tr>
                                                    <td>
                                                        Division
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DivisionDropDownList" runat="server" OnSelectedIndexChanged="DivisionDropDownList_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Division harus di isi"
                                                            Display="Dynamic" Text="*" ControlToValidate="DivisionDropDownList"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Jabatan
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="JabatanDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="JabatanDropDownList_SelectedIndexChanged">
                                                            <asp:ListItem Text="[Pilih]" Value=""></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Jabatan harus di isi"
                                                            Display="Dynamic" Text="*" ControlToValidate="JabatanDropDownList"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="left">
                                                                        <table>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:CheckBox runat="server" ID="AllCheckBox" Text="Check All" />
                                                                                    <asp:CheckBox runat="server" ID="GrabAllCheckBox" Text="Grab All" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:HiddenField ID="CheckHidden" runat="server" />
                                                                                    <asp:HiddenField ID="TempHidden" runat="server" />
                                                                                    <asp:HiddenField ID="AllHidden" runat="server" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="DataPagerButton" runat="server" CausesValidation="false" OnClick="DataPagerButton_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td valign="middle">
                                                                                    <b>Page :</b>
                                                                                </td>
                                                                                <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater" runat="server" OnItemCommand="DataPagerTopRepeater_ItemCommand"
                                                                                    OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="PageNumberLinkButton" runat="server" CausesValidation="false"></asp:LinkButton>
                                                                                            <asp:TextBox Visible="false" ID="PageNumberTextBox" runat="server" Width="30px"></asp:TextBox>
                                                                                        </td>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td class="note">
                                                        * Use Check All to select all checkbox visible on this page<br />
                                                        * Use Grab All to get all data regarding filter selected
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td>
                                                        Anggota
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:CheckBoxList ID="AnggotaCheckBoxList" RepeatColumns="3" runat="server" RepeatDirection="Vertical">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table border="0" cellpadding="3" cellspacing="0" width="0">
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="ViewButton" runat="server" OnClick="ViewButton_Click" />
                                                                </td>
                                                                <td>
                                                                    <%--<asp:ImageButton ID="ResetButton" runat="server" CausesValidation="false" OnClick="ResetButton_Click" />--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowPrintButton="true"
                                ShowZoomControl="true" ZoomMode="Percent" ZoomPercent="100">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
