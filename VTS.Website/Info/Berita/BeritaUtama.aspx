<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="BeritaUtama.aspx.cs" Inherits="Berita" Title="Berita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="../../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-info">
        <div class="content-inner">
            <div id="main-content">
                <div id="content">
                    <div class="view view-info view-id-info view-display-id-page_2 ">
                        <div class="view-content">
                            <div class="views-row-unformatted views-row views-row-1 views-row-odd views-row-first views-row-last">
                                <asp:HiddenField ID="IDHidden" runat="server" />
                                <asp:HiddenField ID="PhotoURLHidden" runat="server" />
                                <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
                                <div class="title">
                                    <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal>
                                </div>
                                <div class="field-image-berita-fid">
                                    <asp:Image ID="PhotoImage" runat="server" />
                                </div>
                                <div class="body">
                                    <asp:Literal ID="BodyLiteral" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
