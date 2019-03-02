<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="ReportVisitor.aspx.cs" Inherits="ReportVisitor" Title="Report Visitor" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../../Content/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
                                <tr>
                                    <td class="warning">
                                        <%--  <asp:Literal ID="Literal1" runat="server" Text="* This Report is Best Printed on Legal Size Paper" />--%>
                                    </td>
                                </tr>
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
                                                                                <input id="button1" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_StartDateTextBox,'yyyy-mm-dd',this)"
                                                                                    value="..." style="width: inherit;" />
                                                                            </td>
                                                                            <td>
                                                                                to
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="EndDateTextBox" runat="server" Width="80" BackColor="#CCCCCC" AutoPostBack="True"></asp:TextBox>
                                                                                <input id="button2" type="button" onclick="displayCalendar(ctl00_ContentPlaceHolder1_EndDateTextBox,'yyyy-mm-dd',this)"
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
                                                                    <asp:Button ID="ViewButton" runat="server" Text="Lihat" OnClick="ViewButton_Click" />
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
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
                <table cellpadding="3" cellspacing="0" width="100%" border="0">
                    <tr>
                        <td>
                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Visible="false">
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
