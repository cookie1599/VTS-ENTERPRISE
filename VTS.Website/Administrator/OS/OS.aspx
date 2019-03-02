<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="OS.aspx.cs" Inherits="Reskrimsus.Website.Administrator.OS" Title="OS" %>

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
        <div>
            <table cellpadding="3" cellspacing="0" width="100%" border="0">
                <tr>
                    <td class="pageLiteral">
                        Bagan Struktur Organisasi
                    </td>
                </tr>
            </table>
        </div>
        <fieldset style="width: 600px; margin-top: 40px;">
            <table cellpadding="3" cellspacing="0" width="100%" border="0">
                <tr>
                    <td class="style2">
                        <asp:Label ID="WarningLabel" runat="server" CssClass="warning"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table border="0" cellpadding="3" cellspacing="0" width="0">
                            <tr valign="top">
                                <td>
                                    Gambar :
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                    <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                    <asp:Image ID="PhotoImage" runat="server" Width="50%" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ukuran terbaik 1360 x 600. Klik Gambar untuk melihat dalam ukuran halaman penuh
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
                        <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="Simpan" />
                    </td>
                </tr>
            </table>
        </fieldset>
        <%--<div id="main-content" role="main">
            <div id="content">
                <asp:Panel runat="server" ID="PanelView">
                    
                </asp:Panel>
            </div>
        </div>--%>
    </div>
</asp:Content>
