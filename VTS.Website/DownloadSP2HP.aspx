<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DownloadSP2HP.aspx.cs" Inherits="DownloadSP2HP" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>
        <rsweb:ReportViewer ID="ReportViewer" Width="100%" runat="server" ShowToolBar="false" Visible="false">
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
