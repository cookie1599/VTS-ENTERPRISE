<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="ListSurat.aspx.cs" Inherits="Reskrimsus.Website.Administrator.ListSurat"
    Title="List Surat" %>

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
                <div style="float: left;">
                    <table cellpadding="3" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="pageLiteral">
                                            Daftar Surat Pemberitahuan Perkembangan Hasil Penyidikan
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 30px 0 0 50px;">
                                            <asp:Button ID="BackButton" Style="margin-top: 10px; margin-bottom: 10px; border-radius: 20%;"
                                                Width="70px" Height="40px" runat="server" OnClick="BackButton_Click" Text="Kembali"
                                                CausesValidation="false" Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel runat="server" ID="PanelList">
                                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table>
                                                                <tr>
                                                                    <td style="float: left">
                                                                        <fieldset style="width: 365px;">
                                                                            <legend>Pencarian</legend>
                                                                            <asp:Panel ID="SearchPanel" DefaultButton="GoButton" runat="server">
                                                                                <table cellpadding="3" cellspacing="0" width="0" border="0">
                                                                                    <tr>
                                                                                        <td style="width: 285px;">
                                                                                            <asp:TextBox ID="KeywordValueTextBox" Width="500px" runat="server" placeholder="[Masukkan Nomor Laporan Polisi, Nomor Surat Perintah Penyidikan, Nomor SP2HP…]"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="GoButton" runat="server" Text="Cari" OnClick="GoButton_Click" CausesValidation="false"
                                                                                                Width="85px" Height="38px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--<tr>
                                                                                        <td colspan="2">
                                                                                            <asp:RadioButtonList ID="FgActiveRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                                                                                Width="240px" AutoPostBack="True" OnSelectedIndexChanged="FgActiveRadioButtonList_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="Y" Text=" Aktif" Selected="True"></asp:ListItem>
                                                                                                <asp:ListItem Value="N" Text=" Tidak Aktif"></asp:ListItem>
                                                                                                <asp:ListItem Value="" Text=" Semua"></asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                </table>
                                                                                &nbsp;</asp:Panel>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <%--<asp:Button runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" CausesValidation="false"
                                                                                        Text="Hapus" />--%>
                                                                                    <asp:HiddenField runat="server" ID="AskYouFirst" />
                                                                                    &nbsp
                                                                                    <asp:Button runat="server" ID="AddButton" OnClick="AddButton_Click" CausesValidation="false"
                                                                                        Text="Tambah" Width="85px" Height="38px" />
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
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="WarningListLabel" runat="server" CssClass="warning"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <asp:HiddenField ID="TempHidden" runat="server" />
                                                                                    <asp:HiddenField ID="RowCountHidden" runat="server" />
                                                                                    <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                                                                    <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                                                                    <asp:HiddenField ID="CheckHidden" runat="server" />
                                                                                    <div id="Sp2hpDiv" align="left">
                                                                                        <asp:Repeater runat="server" ID="ListRepeater" OnItemCommand="ListRepeater_ItemCommand"
                                                                                            OnItemDataBound="ListRepeater_ItemDataBound">
                                                                                            <ItemTemplate>
                                                                                                <table style="float: left; border: solid 0.1px #8B4513; margin-left: 20px; width: 355px;
                                                                                                    height: 150px; border-collapse: collapse;">
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" style="padding-left: 5px; padding-bottom: 5px; padding-right: 10px;
                                                                                                            padding-top: 5px; width: 255px; font-weight: bold; font-size: 10px;">
                                                                                                            <asp:Literal ID="ReportNoLiteral" runat="server">XXX-XXXX-XXX</asp:Literal>
                                                                                                        </td>
                                                                                                        <td align="left" style="padding-right: 10px; padding-left: 10px; width: 195px; background-color: #8B4513;
                                                                                                            border: solid 2px #ffffff; color: White; font-size: 10px;">
                                                                                                            No. Laporan Polisi
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" style="padding-left: 5px; padding-bottom: 5px; padding-right: 10px;
                                                                                                            padding-top: 5px; width: 255px; font-weight: bold; font-size: 10px;">
                                                                                                            <asp:Literal ID="MessageNoLiteral" runat="server">YYY-YYYY-YYY</asp:Literal>
                                                                                                        </td>
                                                                                                        <td align="left" style="padding-right: 10px; padding-left: 10px; width: 195px; background-color: #8B4513;
                                                                                                            border: solid 2px #ffffff; color: White; font-size: 10px;">
                                                                                                            No. Surat Perintah Penyidikan
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="right" style="padding-left: 5px; padding-bottom: 5px; padding-right: 10px;
                                                                                                            padding-top: 5px; width: 255px; font-weight: bold; font-size: 10px;">
                                                                                                            <asp:Literal ID="NotifNoLiteral" runat="server">ZZZ-ZZZZ-ZZZ</asp:Literal>
                                                                                                        </td>
                                                                                                        <td align="left" style="padding-right: 10px; padding-left: 10px; width: 195px; background-color: #8B4513;
                                                                                                            border: solid 2px #ffffff; color: White; font-size: 10px;">
                                                                                                            No. SP2HP
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" colspan="2">
                                                                                                            <asp:Button ID="ShowDataButton" runat="server" CausesValidation="false" Text="Lihat Data Lengkap"
                                                                                                                Height="33px" Width="100%" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                &nbsp;
                                                                                            </ItemTemplate>
                                                                                        </asp:Repeater>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td>
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: left; margin-bottom: 54px;">
                    <asp:Panel runat="server" ID="PanelView">
                        <div id="Div">
                            <fieldset style="width: 300px; margin: 30px; border: solid 1px #8B4513; webkit-border-radius: 8px;
                                moz-border-radius: 8px; border-radius: 8px;">
                                <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; webkit-border-radius: 8px;
                                    moz-border-radius: 8px; border-radius: 8px; padding: 6px; color: White; text-align: center;
                                    font-weight: bold; width: 200px;">Data Pelapor</legend>
                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td class="style2">
                                            <asp:ValidationSummary ID="ValidationSummary" runat="server" />
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
                                            <table style="margin-left: 15px;" border="0" cellpadding="3" cellspacing="0" width="0">
                                                <tr>
                                                    <td valign="top">
                                                        NIK
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="NIKNoLiteral" runat="server"></asp:Literal>
                                                        <br />
                                                        &nbsp
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Nama
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="NamaLiteral" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="NamaTextBox" runat="server" Width="75%" Visible="false" ValidationGroup="valPelapor"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="valPelapor" ID="RequiredFieldValidator5"
                                                            runat="server" ControlToValidate="NamaTextBox" ErrorMessage="<br>*Nama harus diisi."></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Email
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="EmailLiteral" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="EmailTextBox" runat="server" Width="75%" Visible="false" ValidationGroup="valPelapor"></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server"
                                                            ValidationGroup="valPelapor" ControlToValidate="EmailTextBox" ErrorMessage="<br>*Email harus diisi."></asp:RequiredFieldValidator>--%>
                                                        <asp:RegularExpressionValidator ID="validateEmail" runat="server" ErrorMessage="<br>*Format email salah."
                                                            ValidationGroup="valPelapor" ControlToValidate="EmailTextBox" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Password
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Literal ID="PasswordLiteral" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="PasswordTextBox" runat="server" Width="75%" Visible="false" ValidationGroup="valPelapor"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="valPelapor" ID="RequiredFieldValidator1"
                                                            runat="server" ControlToValidate="PasswordTextBox" Text="*" ErrorMessage="<br>Password harus diisi."></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                <td>
                                                    File Hasil Scan SP2HP
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="FileImage" runat="server" Width="50%" Height="50%" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="FileImageUpload" runat="server" Width="270px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="UbahButton" Width="75%" runat="server" OnClick="UbahButton_Click"
                                                Text="Ubah" CausesValidation="false" />
                                            &nbsp
                                            <asp:Button ID="SaveButton" Width="75%" runat="server" ValidationGroup="valPelapor"
                                                OnClick="SaveButton_Click" Text="Simpan" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <fieldset style="width: 450px; margin: 30px; border: solid 1px #8B4513; webkit-border-radius: 8px;
                                moz-border-radius: 8px; border-radius: 8px;">
                                <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; webkit-border-radius: 8px;
                                    moz-border-radius: 8px; border-radius: 8px; padding: 6px; color: White; text-align: center;
                                    font-weight: bold; width: 200px;">Data Laporan Polisi</legend>
                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td class="style2">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="WarningLaporLabel" runat="server" CssClass="warning"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin-left: 15px;" border="0" cellpadding="3" cellspacing="0" width="0">
                                                <tr>
                                                    <td valign="top">
                                                        No. Laporan Polisi
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Literal ID="ReportNoLiteral" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Tanggal Laporan Polisi
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="TglReportTextBox" runat="server" Width="50%" Visible="false"></asp:TextBox>
                                                        <asp:Literal ID="TglReportLiteral" runat="server" Visible="false"></asp:Literal>
                                                        <asp:Literal ID="TglLaporanLiteral" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        No. Surat Perintah Penyidikan
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Literal ID="MessageNoLiteral" runat="server"></asp:Literal>
                                                        <asp:TextBox ID="MessageNoTextBox" runat="server" Width="75%" Visible="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="valPelapor" ID="RequiredFieldValidator2"
                                                            runat="server" ControlToValidate="MessageNoTextBox" Text="*" ErrorMessage="No.Sprindik harus diisi."></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Tanggal Surat Perintah Penyidikan
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="TglMessageTextBox" runat="server" Width="50%" Visible="false"></asp:TextBox>
                                                        <asp:Literal ID="TglMessageLiteral" runat="server" Visible="false"></asp:Literal>
                                                        <asp:Literal ID="TglSuratLiteral" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                <td>
                                                    File Hasil Scan SP2HP
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="FileImage" runat="server" Width="50%" Height="50%" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="FileImageUpload" runat="server" Width="270px" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="UbahLaporButton" Width="75%" runat="server" OnClick="UbahLaporButton_Click"
                                                Text="Ubah" CausesValidation="false" />
                                            &nbsp
                                            <asp:Button ID="SaveLaporButton" Width="75%" runat="server" OnClick="SaveLaporButton_Click"
                                                Text="Simpan" ValidationGroup="valPelapor" />
                                            <%-- &nbsp
                                        <asp:Button ID="BackButton" Width="200px" runat="server" OnClick="BackButton_Click"
                                            Text="Kembali" CausesValidation="false" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                            <fieldset style="width: 350px; margin: 30px; border: solid 1px #8B4513; webkit-border-radius: 8px;
                                moz-border-radius: 8px; border-radius: 8px;">
                                <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; webkit-border-radius: 8px;
                                    moz-border-radius: 8px; border-radius: 8px; padding: 6px; color: White; text-align: center;
                                    font-weight: bold; width: 200px;">Data SP2HP</legend>
                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td class="style2">
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" />
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            <asp:Label ID="WarningNotifLabel" runat="server" CssClass="warning"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="margin-left: 15px;" border="0" cellpadding="3" cellspacing="0" width="0">
                                                <tr>
                                                    <td valign="top">
                                                        No. SP2HP
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:Literal ID="NotifNoLiteral" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Tanggal SP2HP
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox ID="TglSpTextBox" runat="server" Width="50%" Visible="false"></asp:TextBox>
                                                        <asp:Literal ID="TglSpLiteral" runat="server" Visible="false"></asp:Literal>
                                                        <asp:Literal ID="TglButtonLiteral" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr style="padding-top: 10px;">
                                                    <td valign="top">
                                                        File Hasil Scan SP2HP
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:HyperLink ID="UrlFileDownload" Target="_blank" runat="server">Unduh</asp:HyperLink>
                                                        <br />
                                                        <asp:FileUpload ID="FileUpload" runat="server" Width="75%" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="UbahNotifButton" Width="75%" runat="server" OnClick="UbahNotifButton_Click"
                                                Text="Ubah" CausesValidation="false" />
                                            &nbsp
                                            <%--<asp:Button ID="UnduhNotifButton" Width="200px" runat="server" OnClick="UnduhNotifButton_Click"
                                            Text="Unduh" CausesValidation="false" />
                                        &nbsp--%>
                                            <asp:Button ID="SaveNotifButton" Width="75%" runat="server" OnClick="SaveNotifButton_Click"
                                                Text="Simpan" CausesValidation="false" />
                                            <%-- &nbsp
                                        <asp:Button ID="BackButton" Width="200px" runat="server" OnClick="BackButton_Click"
                                            Text="Kembali" CausesValidation="false" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
