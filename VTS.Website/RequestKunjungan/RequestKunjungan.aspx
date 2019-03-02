<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="RequestKunjungan.aspx.cs" Inherits="RequestKunjungan" Title="Request Kunjungan" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../Content/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

    <style type="text/css">
        .warning
        {
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="content-inner" style="margin: auto; width: 70%;">
        <div id="main-content" role="main">
            <div id="content">
                <fieldset>
                    <legend style="font-size: 14px; font-weight: bold;">Registrasi Kunjungan</legend>
                    <table>
                        <tr>
                            <td colspan="5">
                                <asp:Literal ID="PageTitleLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" class="warning">
                                <asp:Literal ID="WarningLabelLiteral" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:ValidationSummary ID="ValidationSubmit" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 120px;">
                                Tanggal Kunjungan
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="VisitDateTextBox" CssClass="input" runat="server" Width="80" BackColor="#CCCCCC"></asp:TextBox>&nbsp;
                                <input id="button1" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_VisitDateTextBox,'yyyy-mm-dd',this)"
                                    value="..." style="width: -moz-min-content; background-color: inherit;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Jenis Identitas
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:RadioButtonList ID="JenisIdentitasRadioButtonList" runat="server" RepeatDirection="Horizontal"
                                    Width="100%">
                                    <asp:ListItem Value="KTP" Text="KTP" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="SIM" Text="SIM"></asp:ListItem>
                                    <asp:ListItem Value="PASSPORT" Text="PASSPORT"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nomor Identitas
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="NomorIdentitasTextBox" runat="server" CssClass="input" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nomor identitas harus diisi"
                                    Text="*" ControlToValidate="NomorIdentitasTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nama Lengkap
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="NamaLengkapTextBox" runat="server" CssClass="input" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nama Lengkap harus diisi"
                                    Text="*" ControlToValidate="NamaLengkapTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nomor Handphone
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="NomorHandPhoneTextBox" runat="server" CssClass="input" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Nomor Handphone harus diisi"
                                    Text="*" ControlToValidate="NomorHandPhoneTextBox" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nama Yang Dikunjungi
                            </td>
                            <td>
                                :&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="NamaPenyidikTextBox" runat="server" CssClass="input" AutoPostBack="true"
                                    OnTextChanged="NamaPenyidikTextBox_TextChanged" placeholder="masukan nama penyidik disini"
                                    Width="200px"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Nama Penyidik harus diisi"
                                Text="*" ControlToValidate="NamaPenyidikTextBox" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:RadioButtonList ID="PenyidikList" runat="server" RepeatDirection="Vertical"
                                    RepeatColumns="2">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <br />
                                <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LcJcCkTAAAAAN1aTDGTym_0eJ__HLFccsIG46KP"
                                    PrivateKey="6LcJcCkTAAAAAKx-JgHvv1cuxJbC3sAGCmzBww0S" />
                                <br />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ImageButton ID="SubmitImageButton" runat="server" OnClick="SubmitImageButton_Click" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <br />
                <fieldset>
                    <legend>Data Kunjungan</legend>
                    <table>
                        <tr>
                            <td>
                                <asp:Panel runat="server" ID="MenuPanel" Visible="true">
                                    <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                        <tr>
                                            <td class="style2">
                                                <asp:ValidationSummary ID="ValidationSummary" runat="server" />
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
                                                    <tr>
                                                        <td>
                                                            Date Range
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <table border="0" cellpadding="3" cellspacing="0" width="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="StartDateTextBox" runat="server" Width="80" BackColor="#CCCCCC"
                                                                            AutoPostBack="True"></asp:TextBox>
                                                                        <input id="button2" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_StartDateTextBox,'yyyy-mm-dd',this)"
                                                                            value="..." style="width: inherit;" />
                                                                    </td>
                                                                    <td>
                                                                        to
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="EndDateTextBox" runat="server" Width="80" BackColor="#CCCCCC" AutoPostBack="True"></asp:TextBox>
                                                                        <input id="button3" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_EndDateTextBox,'yyyy-mm-dd',this)"
                                                                            value="..." style="width: inherit;" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Type
                                                        </td>
                                                        <td>
                                                            :
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="TypeDDL" runat="server">
                                                                <asp:ListItem Text="Not Yet CheckOut" Value="1"></asp:ListItem>
                                                                <asp:ListItem Text="Already CheckOut" Value="0"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
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
                                                            <asp:DropDownList ID="FotoDDL" runat="server">
                                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <%--<asp:ImageButton ID="ViewButton" runat="server" OnClick="ViewButton_Click" />--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="ViewButton" runat="server" CausesValidation="false" Text="Lihat" OnClick="ViewButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="3" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td>
                                <rsweb:reportviewer id="ReportViewer1" runat="server" width="100%" visible="false">
                            </rsweb:reportviewer>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
