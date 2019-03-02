<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="StrukturOrganisasi.aspx.cs" Inherits="StrukturOrganisasi"
    Title="Dir Reskrimsus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="section-struktur-organisasi">
            <div class="content-inner">
                <div id="main-content">
                    <div id="main-content-header">
                    </div>
                    <div id="content">
                        <div class="view view-struktur view-id-struktur view-display-id-page_1 ">
                            <div class="view-content" style="margin:inherit;">
                                <%--<div class="views-row-unformatted views-row views-row-1 views-row-odd views-row-first views-row-last">--%>
                                <div class="title">
                                    <div class="left">
                                        <div class="title">
                                            <asp:Literal ID="NameLiteral" runat="server"></asp:Literal>
                                            <asp:HiddenField ID="IDHidden" runat="server" />
                                            <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                            <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                        </div>
                                        <div class="image">
                                            <%--<img class="imagecache imagecache-ScaleCrop_200x275 imagecache-default imagecache-ScaleCrop_200x275_default"
                                                width="200" height="275" title="" alt="" src="../Content/Images/Tampil 1 - Dir Reskrimsus.JPG.png">--%>
                                            <asp:Image ID="Image" runat="server" class="imagecache imagecache-ScaleCrop_200x275 imagecache-default imagecache-ScaleCrop_200x275_default" Width="200" Height="275" />
                                        </div>
                                    </div>
                                    <div class="right">
                                        <div class="title">
                                            TUGAS POKOK
                                            <asp:Literal ID="SubTitleLiteral" runat="server"></asp:Literal>
                                        </div>
                                        <div class="body">
                                            <p style="text-align: left">
                                                <asp:Literal ID="BodyLiteral" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <%--</div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
