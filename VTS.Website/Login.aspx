<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="RequestKunjungan" Title="Login Account" %>

<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="Content/Js/custom.js" type="text/javascript"></script>

    <style type="text/css">
        select
        {
            padding-left: 5px;
            padding-right: 5px;
            height: 30px;
            border: solid 1px #ABADB3;
            border-radius: 4px;
        }
        select:focus
        {
            border-color: #FEBD5E;
            border: solid 1px #FEBD5E;
            border-radius: 4px;
        }
        input[type=text]:focus, textarea:focus, input[type=password]:focus
        {
            border-color: #FEBD5E;
            border: solid 1px# FEBD5E;
            border-radius: 4px;
            width: 250px;
        }
        input[type=text], textarea, input[type=password]
        {
            border: solid 1px #ABADB3;
            border-radius: 4px;
            height: 30px;
            padding-left: 10px;
            padding-right: 10px;
            width: 200px;
            -webkit-transition: width .35s ease-in-out;
            transition: width .35s ease-in-out;
            font-family: segoe ui;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="ContentPanel" runat="server" DefaultButton="LoginButton">
        <div class="content-inner" style="margin-bottom: 100px;">
            <div id="main-content" role="main">
                <div id="content">
                    <fieldset style="width: 400px; margin: auto; float: none !important; margin-top: 35px;
                        border: solid 1px #8B4513; border-radius: 8px;">
                        <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; border-radius: 8px;
                            padding: 6px; color: White; text-align: center; font-weight: bold; width: 150px;">
                            Admin Akses</legend>
                        <table cellpadding="3" cellspacing="0" width="0" border="0" style="padding-left: 10px;">
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
                                <td>
                                    <table style="margin-left: 88px;">
                                        <tr>
                                            <td style="margin-left: 10px;" align="left">
                                                <b>Nama User :</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="IDTextBox" runat="server" placeholder="Username"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                &nbsp
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="margin-left: 10px;" align="left">
                                                <b>Password :</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="margin-left: 30px;">
                                        <tr>
                                            <td align="center">
                                                <br />
                                                <recaptcha:RecaptchaControl ID="recaptcha" runat="server" PublicKey="6LcJcCkTAAAAAN1aTDGTym_0eJ__HLFccsIG46KP"
                                                    PrivateKey="6LcJcCkTAAAAAKx-JgHvv1cuxJbC3sAGCmzBww0S" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Masuk"
                                                    Width="318px" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
