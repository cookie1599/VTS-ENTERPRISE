<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="MasterRole.aspx.cs" Inherits="Reskrimsus.Website.Administrator.MasterRole"
    Title="Role" %>

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
                                            Role
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
                                                                                            <asp:TextBox ID="KeywordValueTextBox" Width="300px" runat="server" placeholder="[Masukan nomor role atau nama role disini]"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <%--<asp:ImageButton ID="GoImageButton" runat="server" OnClick="GoImageButton_Click"
                                                                                            CausesValidation="false" />--%>
                                                                                            <asp:Button ID="GoButton" runat="server" Text="Cari" OnClick="GoButton_Click" CausesValidation="false" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:RadioButtonList ID="FgActiveRadioButtonList" runat="server" RepeatDirection="Horizontal" Width="240px"
                                                                                                AutoPostBack="True" OnSelectedIndexChanged="FgActiveRadioButtonList_SelectedIndexChanged">
                                                                                                <asp:ListItem Value="Y" Text=" Aktif" Selected="True"></asp:ListItem>
                                                                                                <asp:ListItem Value="N" Text=" Tidak Aktif"></asp:ListItem>
                                                                                                <asp:ListItem Value="" Text=" Semua"></asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </fieldset>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <table cellpadding="3" cellspacing="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <%-- <asp:ImageButton runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" CausesValidation="false" />--%>
                                                                                                <asp:Button runat="server" ID="DeleteButton" OnClick="DeleteButton_Click" CausesValidation="false"
                                                                                                    Text="Hapus" />
                                                                                                    <asp:HiddenField runat="server" ID="AskYouFirst" /></asp>
                                                                                                &nbsp
                                                                                                <%-- <asp:ImageButton runat="server" ID="AddButton" CausesValidation="false" OnClick="AddButton_Click" />--%>
                                                                                                <asp:Button runat="server" ID="AddButton" OnClick="AddButton_Click" CausesValidation="false"
                                                                                                    Text="Tambah" />
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
                                                                                            <td colspan="2">
                                                                                                <asp:HiddenField ID="TempHidden" runat="server" />
                                                                                                <asp:HiddenField ID="RoleIdHidden" runat="server" />
                                                                                                <asp:HiddenField ID="RowCountHidden" runat="server" />
                                                                                                <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                                                                                <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                                                                                <asp:HiddenField ID="CheckHidden" runat="server" />
                                                                                                <table cellpadding="3" cellspacing="1" width="0" border="0" width="100%">
                                                                                                    <tr class="headerTable">
                                                                                                        <td style="width: 5px">
                                                                                                            <asp:CheckBox runat="server" ID="AllCheckBox" Enabled="false" />
                                                                                                        </td>
                                                                                                        <td style="width: 5px" class="tahoma_11_white" align="center">
                                                                                                            <b>No</b>
                                                                                                        </td>
                                                                                                        <td style="width: 120px" class="tahoma_11_white" align="center">
                                                                                                            <b>Pilihan</b>
                                                                                                        </td>
                                                                                                        <td style="width: 50px" class="tahoma_11_white" align="center">
                                                                                                            <b>Id</b>
                                                                                                        </td>
                                                                                                        <td style="width: 200px" class="tahoma_11_white" align="center">
                                                                                                            <b>Nama Role</b>
                                                                                                        </td>
                                                                                                        <td style="width: 50px" class="tahoma_11_white" align="center">
                                                                                                            <b>Aktif</b>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <asp:Repeater runat="server" ID="ListRepeater" OnItemCommand="ListRepeater_ItemCommand"
                                                                                                        OnItemDataBound="ListRepeater_ItemDataBound">
                                                                                                        <ItemTemplate>
                                                                                                            <tr id="RepeaterItemTemplate" runat="server">
                                                                                                                <td align="center">
                                                                                                                    <asp:CheckBox runat="server" ID="ListCheckBox" />
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    <asp:Literal runat="server" ID="NoLiteral"></asp:Literal>
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    <asp:Button runat="server" ID="ViewImageButton" Text="Lihat" CausesValidation="false" />
                                                                                                                    <asp:Button runat="server" ID="EditImageButton" Text="Ubah" CausesValidation="false" />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Literal runat="server" ID="IdLiteral"></asp:Literal>
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    <asp:Literal runat="server" ID="NamaLiteral"></asp:Literal>
                                                                                                                </td>
                                                                                                                <td align="center">
                                                                                                                    <asp:Literal runat="server" ID="FgActiveLiteral"></asp:Literal>
                                                                                                                    <%--<asp:Image ID = "PhotoImageList" runat = "server" />--%>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:Repeater>
                                                                                                </table>
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
                <div style="float: left; margin-bottom: 54px; margin-top: 279px;">
                    <asp:Panel runat="server" ID="PanelView">
                        <fieldset style="width: 600px; margin-left: 94px; margin-top: -78px;">
                            <legend>Data Detail</legend>
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
                                        <table border="0" cellpadding="3" cellspacing="0" width="0">
                                            <tr>
                                                <td>
                                                    Id
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="IdTextBox" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Nama Role
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NameTextBox"
                                                        Text="*" ErrorMessage="Nama Role
                                                         Harus Diisi."></asp:RequiredFieldValidator>
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
                                        <asp:Button ID="BackButton" runat="server" OnClick="BackButton_Click" Text="Kembali" CausesValidation="false"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <%--<asp:CheckBoxList ID="ListMenuCheckBox" runat="server" RepeatDirection="Vertical"
                                                        RepeatColumns="3">--%>
                                                    <asp:CheckBoxList ID="ListMenuCheckBox" runat="server">
                                                    </asp:CheckBoxList>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <%--<asp:Repeater runat="server" ID="ListRepeaterDetail" OnItemCommand="ListRepeaterDetail_ItemCommand"
                                                OnItemDataBound="ListRepeaterDetail_ItemDataBound">
                                                <ItemTemplate>
                                                    <tr id="RepeaterItemTemplate" runat="server">
                                                        <td align="center">
                                                            <asp:Literal runat="server" ID="NoLiteral"></asp:Literal>
                                                        </td>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="SaveImageButton" Text="Simpan" CausesValidation="false" />
                                                            <asp:Button runat="server" ID="DeleteImageButton" Text="Hapus" CausesValidation="false" />
                                                        </td>
                                                        <td align="left">
                                                            <asp:Literal runat="server" ID="NamaLiteral"></asp:Literal>
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="AddCheckBox" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="EditCheckBox" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="ViewCheckBox" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:CheckBox ID="DeleteCheckBox" runat="server" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>--%>
                                        </table>
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
