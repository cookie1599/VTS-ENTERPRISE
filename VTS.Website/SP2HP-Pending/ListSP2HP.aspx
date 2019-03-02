<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="ListSP2HP.aspx.cs" Inherits="SP2HP_ListSP2HP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="~/Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="~/Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin-left: 10%; width: 80%; margin-right: 10%; margin-bottom: 20px;">
        <div style="width: 100%;">
            <div style="margin-left: 15%; width: 70%; margin-right: 15%;">
                <table width="100%">
                    <tr align="center">
                        <td valign="middle" align="center" width="90%">
                            <asp:TextBox ID="SearchingTextBox" Width="100%" Height="100%" runat="server"></asp:TextBox>
                        </td>
                        <td width="35">
                            <asp:ImageButton ID="GoImageButton" runat="server" ImageUrl="~/Content/Images/loop_searching.png"
                                Width="32px" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Repeater ID="ListRepeater" runat="server" 
                        onitemcommand="ListRepeater_ItemCommand" 
                        onitemdatabound="ListRepeater_ItemDataBound">
                        <ItemTemplate>
                             
                             
                            
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
