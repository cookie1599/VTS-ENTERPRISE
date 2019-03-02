<%@ Page Title="Event" Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="Event.aspx.cs" Inherits="Reskrimsus.Website.Gallery.Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

    <script type="text/javascript">
        function LoadDiv(url) {
            var img = new Image();
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("ctl00_ContentPlaceHolder1_imgFull");
            var imgLoader = document.getElementById("imgLoader");

            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }

            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("ctl00_ContentPlaceHolder1_imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }
    </script>

    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            height: 100%;
            overflow-y: auto;
        }

        .modal {
            background-color: black;
            display: none;
            left: 0;
            min-height: 100%;
            opacity: 0.8;
            position: fixed;
            top: 0;
            z-index: 999;
        }

        #divImage {
            display: none;
            z-index: 1000;
            position: fixed;
            top: 0;
            left: 0;
            background-color: White;
            height: 550px;
            width: 600px;
            padding: 3px;
            border: solid 1px black;
        }

        #divImage {
            position: fixed;
        }

        .galery img {
            cursor: pointer;
        }

        #btnClose {
            -moz-user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
            cursor: pointer;
            display: inline-block;
            font-size: 14px;
            font-weight: normal;
            line-height: 1.42857;
            margin-bottom: 0;
            padding: 6px 12px;
            text-align: center;
            vertical-align: middle;
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="galery">
        <asp:HiddenField ID="URLFileHiddenField" runat="server" />
        <h1 id="page-title">GALLERY EVENT</h1>
        <table width="100%">
            <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                <ItemTemplate>
                    <tr id="RepeaterItemTemplate" runat="server">
                        <td width="750px">
                            <div class="GaleryScroll" style="overflow-x: scroll; width: 100%; height: 500px;">
                                <table>
                                    <tr>
                                        <td id="YearTd" runat="server">
                                            <h3>
                                                <asp:Literal ID="YearLiteral" runat="server"></asp:Literal>
                                            </h3>
                                            <hr />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Repeater ID="ListDetailRepeater" runat="server" OnItemDataBound="ListDetailRepeater_ItemDataBound">
                                                <ItemTemplate>
                                                    <asp:Panel ID="RepeaterPanel" runat="server" Style="float: left; height: 200px; width: 250px; margin: 10px;">
                                                        <asp:ImageButton ID="PhotoEventImage" runat="server" Width="250px" Height="150px"
                                                            OnClientClick="return LoadDiv(this.src);" />
                                                        <p style="text-align: center; width: 100%;">
                                                            <asp:Literal ID="DescLiteral" runat="server"></asp:Literal>
                                                        </p>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%-- <asp:Panel DefaultButton="DataPagerButton" ID="DataPagerPanel" runat="server">
                            <table border="0" cellpadding="2" cellspacing="0">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="DataPagerButton" runat="server" OnClick="DataPagerButton_Click" />
                                                    <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater" runat="server" OnItemCommand="DataPagerTopRepeater_ItemCommand"
                                                        OnItemDataBound="DataPagerTopRepeater_ItemDataBound">
                                                        <ItemTemplate>
                                                            <td>
                                                                <asp:LinkButton ID="PageNumberLinkButton" runat="server" CssClass="PageNumberLinkButton2"></asp:LinkButton>
                                                                <asp:TextBox Visible="false" ID="PageNumberTextBox" runat="server" Width="20px"></asp:TextBox>
                                                            </td>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>--%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="divBackground" class="modal">
    </div>
    <div id="divImage" class="info">
        <table style="height: 100%; width: 100%">
            <tr>
                <td valign="middle" align="center">
                    <img id="imgLoader" alt="" src="../Content/Css/Images/loader.gif" />
                    <asp:Image ID="imgFull" runat="server" alt="" src="" Style="display: none; width: 100%;" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
