<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="DPO.aspx.cs" Inherits="DPO" Title="DPO"  EnableEventValidation="true" %>
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
                                    <asp:Image ID="PhotoImage" runat="server" Style="max-width: 300px; max-height: 300px;" />
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
    </div> </div>
</asp:Content>
