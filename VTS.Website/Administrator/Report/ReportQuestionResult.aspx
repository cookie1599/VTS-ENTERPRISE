<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="ReportQuestionResult.aspx.cs" Inherits="ReportQuestionResult" Title="Report Question Result" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../../Content/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>

    <div class="content-inner">
        <div id="main-content" role="main">
            <div id="content">
                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="pageLiteral">
                                        <b>
                                            <asp:Literal ID="PageTitleLiteral" runat="server" />
                                        </b>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:65%;">
                            <fieldset style="width:100%;">
                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:Panel runat="server" ID="MenuPanel">
                                                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                                    <tr>
                                                        <td align="center">
                                                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        Tanggal
                                                                    </td>
                                                                    <td>
                                                                        :
                                                                    </td>
                                                                    <td>
                                                                        <table border="0" cellpadding="3" cellspacing="0" width="50%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox CssClass="buttonNoStyle" ID="StartDateTextBox" runat="server" Width="80"
                                                                                        BackColor="#CCCCCC" AutoPostBack="True"></asp:TextBox>
                                                                                    <input cssclass="buttonNoStyle" id="button1" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_StartDateTextBox,'yyyy-mm-dd',this)"
                                                                                        value="..." style="width: inherit;" />
                                                                                </td>
                                                                                <td>
                                                                                    to
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox CssClass="buttonNoStyle" ID="EndDateTextBox" runat="server" Width="80"
                                                                                        BackColor="#CCCCCC" AutoPostBack="True"></asp:TextBox>
                                                                                    <input cssclass="buttonNoStyle" id="button2" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_EndDateTextBox,'yyyy-mm-dd',this)"
                                                                                        value="..." style="width: inherit;" />
                                                                                </td>
                                                                                <td>
                                                                                    <%--   <asp:ImageButton ID="ViewButton" runat="server" OnClick="ViewButton_Click" />--%>
                                                                                    <asp:Button ID="ViewButton" runat="server" Text="Lihat" OnClick="ViewButton_Click" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" ShowToolBar="true">
                                            </rsweb:ReportViewer>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td style="width:50%;">
                            <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                <tr>
                                    <td align="center" style="font-size:20px;padding-top:30px;">
                                        TODAY
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:80px;">
                                        <rsweb:ReportViewer ID="ReportViewer2" Width="100%" runat="server" ShowToolBar="false">
                                        </rsweb:ReportViewer>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
