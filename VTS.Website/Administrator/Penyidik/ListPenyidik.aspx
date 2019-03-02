<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="ListPenyidik.aspx.cs" Inherits="Reskrimsus.Website.Administrator.ListPenyidik"
    Title="Penyidik" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../../Content/JScript.js" type="text/javascript"></script>

    <script src="../../Content/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script language="javascript" src="../../Content/Js/custom.js" type="text/javascript"></script>

    <style type="text/css">
        .wrapper .text
        {
            top: 0px;
            background-color: rgba(192, 192, 192, 0.7);
            left: 0%;
            color: #202020; /*font-weight: bolder;*/
            font-family: Maiandra GD;
            font-size: 14px;
            min-height: 5px;
            height: 100%; /*height: 320px !important;
            width: 230px;*/
            height: 266px !important;
            width: 191px;
            border-radius: 0px;
            opacity: 0;
            z-index: 2;
            position: absolute;
            -webkit-transition: opacity 0.5s;
            -moz-transition: opacity 0.5s;
            -ms-transition: opacity 0.5s;
            -o-transition: opacity 0.5s;
            transition: opacity 0.5s;
            vertical-align: middle;
            margin-left: 0px;
            padding-left: 10px;
        }
        .wrapper:hover .text
        {
            opacity: 1;
        }
        .wrapper
        {
            position: relative;
            cursor: pointer;
        }
        .wrapper img
        {
            z-index: -9999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="content-inner">
        <div id="main-content" role="main">
            <div id="content">
                <%--<div style="float: left;width:100%;">--%>
                <div>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td class="pageLiteral">
                                            <asp:Literal ID="PageTitleLiteral" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel runat="server" ID="PanelList">
                                                <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                <tr>
                                                                    <td style="width: 100%;">
                                                                        <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td style="width: 25%">
                                                                                    <asp:Button runat="server" ID="AddButton" OnClick="AddButton_Click" CausesValidation="false"
                                                                                        Text="Tambah Baru" />
                                                                                </td>
                                                                                <td>
                                                                                    <fieldset style="width: 430px;">
                                                                                        <legend>Pencarian</legend>
                                                                                        <asp:Panel ID="SearchPanel" DefaultButton="GoButton" runat="server">
                                                                                            <table cellpadding="3" cellspacing="0" width="0" border="0">
                                                                                                <tr>
                                                                                                    <td style="width: 400px;">
                                                                                                        <asp:TextBox ID="KeywordValueTextBox" Width="400px" runat="server" placeholder="[Masukan nomor penyidik, nama penyidik, Division, Position disini]"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td>
                                                                                                        <asp:Button ID="GoButton" runat="server" Text="Cari" OnClick="GoButton_Click" CausesValidation="false" />
                                                                                                        <tr>
                                                                                                            <td colspan="2">
                                                                                                                <asp:RadioButtonList ID="FgActiveRadioBtn" runat="server" RepeatDirection="Horizontal"
                                                                                                                    Width="100%" Visible="true">
                                                                                                                    <asp:ListItem Text="Status Aktif" Selected="True" Value="Y"></asp:ListItem>
                                                                                                                    <asp:ListItem Text="Status Non Aktif" Value="N"></asp:ListItem>
                                                                                                                    <asp:ListItem Text="Semua Status" Value=""></asp:ListItem>
                                                                                                                </asp:RadioButtonList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <%--<tr style="visibility: hidden;">
                                                                                                                                <td style="width: 100%; text-align: center; height: 10px;" colspan="2">
                                                                                                                                    <asp:RadioButtonList ID="FgActiveRadioBtn" runat="server" RepeatDirection="Horizontal"
                                                                                                                                        Width="100%">
                                                                                                                                        <asp:ListItem Text="Semua Status" Selected="True" Value=""></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="Status Aktif" Value="Y"></asp:ListItem>
                                                                                                                                        <asp:ListItem Text="Status Non Aktif" Value="N"></asp:ListItem>
                                                                                                                                    </asp:RadioButtonList>
                                                                                                                                </td>
                                                                                                                            </tr>--%>
                                                                                            </table>
                                                                                        </asp:Panel>
                                                                                    </fieldset>
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                                                                                        <table border="0" cellpadding="2" cellspacing="0">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Button ID="DataPagerButton" runat="server" OnClick="DataPagerButton_Click" />
                                                                                                </td>
                                                                                                <td valign="middle">
                                                                                                    <b>Halaman :</b>
                                                                                                </td>
                                                                                                <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater" runat="server" OnItemCommand="DataPagerTopRepeater_ItemCommand"
                                                                                                    OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
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
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="WarningListLabel" runat="server" CssClass="warning"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:HiddenField ID="TempHidden" runat="server" />
                                                                        <asp:HiddenField ID="CurrentPageHiddenField" runat="server" />
                                                                        <asp:HiddenField ID="RowCountHidden" runat="server" />
                                                                        <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                                                        <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                                                        <asp:HiddenField ID="CheckHidden" runat="server" />
                                                                        <table cellpadding="3" cellspacing="3" border="0" width="100%">
                                                                            <tr>
                                                                                <td valign="top" align="center" style="width: 100%; text-align: center; padding-left: 70px;">
                                                                                    <asp:Repeater runat="server" ID="ListRepeater" OnItemCommand="ListRepeater_ItemCommand"
                                                                                        OnItemDataBound="ListRepeater_ItemDataBound">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="ViewLinkButton" runat="server">
                                                                                                <div style="float: left; color: Black; margin: 10px 10px 10px 10px;">
                                                                                                    <table cellpadding="5" cellspacing="0" border="0">
                                                                                                        <tr id="RepeaterItemTemplate" runat="server" valign="Top">
                                                                                                            <td>
                                                                                                                <table>
                                                                                                                    <tr>
                                                                                                                        <td align="left">
                                                                                                                            <asp:Literal runat="server" ID="NamaPenyidikLiteral"></asp:Literal>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <div class="wrapper">
                                                                                                                                <asp:Image ID="PhotoImage" runat="server" Width="200" Height="266" />
                                                                                                                                <div class="text">
                                                                                                                                    <table cellpadding="3" cellspacing="1" border="0" width="100%" style="vertical-align: bottom;">
                                                                                                                                        <tr>
                                                                                                                                            <td>
                                                                                                                                                <asp:Literal runat="server" ID="NoPenyidikLiteral"></asp:Literal>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td>
                                                                                                                                                <asp:Literal runat="server" ID="PosisiLiteral"></asp:Literal>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td>
                                                                                                                                                <asp:Literal runat="server" ID="NoTelpLiteral"></asp:Literal>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td>
                                                                                                                                                <asp:Literal runat="server" ID="EmailLiteral"></asp:Literal>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td>
                                                                                                                                                <asp:Literal runat="server" ID="BagianLiteral"></asp:Literal>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                        <tr>
                                                                                                                                            <td>
                                                                                                                                                <asp:Literal runat="server" ID="StatusLiteral"></asp:Literal>
                                                                                                                                            </td>
                                                                                                                                        </tr>
                                                                                                                                    </table>
                                                                                                                                </div>
                                                                                                                            </div>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                            </asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="right">
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
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
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
                <%-- <div style="float: left; margin-bottom: 55px; margin-top: 190px;">--%>
                <div style="margin-bottom: 55px;">
                    <asp:Panel runat="server" ID="PanelView">
                        <%--<fieldset style="width: 600px; margin-left: -100px; margin-top: -78px;">--%>
                        <fieldset style="width: 600px;">
                            <legend>Data Detail</legend>
                            <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <td class="style2">
                                        <%--<asp:ValidationSummary ID="ValidationSummary" runat="server" />--%>
                                        <asp:HiddenField ID="ActionHidden" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        <asp:Label ID="WarningLabel" runat="server" CssClass="warning"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="3" cellspacing="0" width="0">
                                            <tr id="IdTr" runat="server" visible="false">
                                                <td style="width: 100px;">
                                                    Id
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:Literal ID="IdLiteral" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nomor Penyidik
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="PenyidikNumberTextBox" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PenyidikNumberTextBox"
                                                        ErrorMessage="Wajib diisi." ForeColor="Red" Visible="false">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nama Penyidik
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NameTextBox"
                                                        ErrorMessage="Wajib diisi." ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Divisi
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="DivisiDDL" runat="server">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DivisiDDL"
                                                        ErrorMessage="Wajib diisi." ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Posisi
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="PositionTextBox" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PositionTextBox"
                                                        ErrorMessage="Wajib diisi." ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    No. Telp
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="PhoneTextBox" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PhoneTextBox"
                                                        ErrorMessage="Wajib diisi." ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    No. Telp Alternatif
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="PhoneAlternativeTextBox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ControlToValidate="EmailTextBox" ID="RateInitialRegularExpressionValidator"
                                                        runat="server" Text="" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="EmailTextBox"
                                                        ErrorMessage="Wajib diisi." ForeColor="Red">
                                                    </asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Email Alternatif
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="EmailAlternativeTextBox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Keterangan
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="RemarkTextBox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Foto
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="PhotoImage" runat="server" Width="50%" />
                                                                <br>
                                                                *Rekomendasi ukuran foto adalah 151pixel x 113pixel
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="PhotoUpload" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Aktif
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="FgActiveCheckBox" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--<asp:ImageButton ID="SaveButton" runat="server" OnClick="SaveButton_Click" />--%>
                                        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Simpan" />
                                        &nbsp
                                        <%-- <asp:ImageButton ID="BackButton" runat="server" OnClick="BackButton_Click" />--%>
                                        <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Kembali"
                                            CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
