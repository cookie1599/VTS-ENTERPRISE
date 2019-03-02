<%@ Page Title="Gallery" Language="C#" MasterPageFile="~/DefaultFrondEnd.master"
    AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Reskrimsus.Website.Gallery.Video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../Content/calendar/calendar.js" type="text/javascript"></script>

    <script src="../Content/JScript.js" type="text/javascript"></script>

    <script src="../../Content/jquery-3.1.1.min.js" type="text/javascript"></script>

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script src="../Content/Js/custom.js" type="text/javascript"></script>

    <style type="text/css">
        #GaleryScroll {
            overflow-y: scroll;
            width: 100%;
            height: 500px;
        }

        .videorepeater {
            width: 50%;
            float: left;
        }

            .videorepeater video {
                width: 100% !important;
            }

        @media (min-width: 480px) and (max-width: 768px) {
            .videorepeater {
                width: 100%;
            }
        }

        @media (max-width: 480px) {
            .videorepeater {
                width: 100%;
            }
        }

        @media (min-width: 768px) {
            .videorepeater {
                width: 50%;
                padding: 0 10px;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="galery">
        <h1 id="page-title">GALLERY VIDEO</h1>
        <asp:HiddenField ID="URLFileHiddenField" runat="server" />
        <div>
            <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                <ItemTemplate>
                    <div id="RepeaterItemTemplate" runat="server">
                        <div>
                            <div id="GaleryScroll">
                                <table>
                                    <tr>
                                        <td id="YearTd" runat="server">
                                            <h3>
                                                <asp:Literal ID="YearLiteral" runat="server"></asp:Literal>
                                            </h3>
                                            <hr />
                                        </td>
                                    </tr>
                                </table>
                                <div>
                                    <asp:Repeater ID="ListDetailRepeater" runat="server" OnItemDataBound="ListDetailRepeater_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="videorepeater">
                                                <asp:Literal ID="VideoLiteral" runat="server"></asp:Literal>
                                                <br />
                                                <asp:Literal ID="VideoNameLiteral" runat="server"></asp:Literal>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <%-- <table>
            <tr>
                <asp:Repeater ID="ListRepeater" runat="server" OnItemDataBound="ListRepeater_ItemDataBound">
                    <ItemTemplate>
                        <td align="center">
                            <asp:Literal ID="VideoLiteral" runat="server"></asp:Literal>
                            <br />
                            <asp:Literal ID="VideoNameLiteral" runat="server"></asp:Literal>
                        </td>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        </table>--%>
    </div>
</asp:Content>
