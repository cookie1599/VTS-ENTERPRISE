<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="Account.aspx.cs" Inherits="Reskrimsus.Website.Administrator.Account"
    Title="Account" %>

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
            <div>
                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td class="pageLiteral">
                            <asp:Literal ID="PageTitleLiteral" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="content" >
                <div style="margin-top:40px; margin-bottom:54px;">
                    <asp:Panel runat="server" ID="PanelView" DefaultButton="SaveButton">
                        <fieldset style="width: 500px;">
                            <legend>Akun</legend>
                            <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="3" cellspacing="0" width="0">
                                            <tr>
                                                <td>
                                                    Nama User
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:Literal ID="NameLiteral" runat="server"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Password Baru
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox"
                                                        Text="*" ErrorMessage="Password Baru Harus Diisi."></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Konfirmasi Password Baru
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password2TextBox" runat="server" TextMode="Password"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Password2TextBox"
                                                        Text="*" ErrorMessage="Konfirmasi Password Baru Harus Diisi."></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                    Foto
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td id="ChangePhotoTable" runat="server">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:FileUpload ID="FileNameFileUpload" runat="server" Width="200" />
                                                                <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                                                <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Best resolution is 240px 240px
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Simpan" />
                                    </td>
                                </tr>
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
                            </table>
                        </fieldset>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
