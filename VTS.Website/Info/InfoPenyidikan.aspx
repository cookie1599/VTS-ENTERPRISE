<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="InfoPenyidikan.aspx.cs" Inherits="Info_DPO" Title="Info Penyidikan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="margin: auto; width: 70%;">
        <div class="content-inner" style="margin-left: 0px; float:left; margin-right: 60px;">
            <div id="main-content" role="main">
                <div id="content">
                    <div class="views-row-unformatted views-row views-row-1 views-row-odd views-row-first views-row-last">
                        <%--<div class="title">
                            <strong>Pengecekan SP2HP</strong>
                        </div>
                        <div class="body">
                            <p>
                                <b>Prosedur pengecekan SP2HP di Website Reskrimsus Polda Metro Jaya :
                                    <br>
                                </b>
                            </p>
                            <ol>
                                <li><b><b>Pelapor wajib mengisi alamat email pada saat melapor di SPK.</b> </b></li>
                                <li><b><b>Pelapor mendaftarkan akun kepada penyidik yang menangani laporan polisi.
                                    <br>
                                    Mohon periksa pada bulkmail atau spam folder jika email tidak masuk ke dalam Inbox
                                    Anda. </b></b></li>
                                <li><b><b>Silahkan login dengan User ID dan password yang dikirimkan ke alamat email
                                    Anda.</b> </b></li>
                            </ol>
                            <p>
                                <b>Jika email Anda belum ter-registrasi di Sentral Pelayanan Kepolisian, silahkan hubungi
                                    <a href="mailto:info@reskrimum-metro.org"></a>penyidik. </b>
                            </p>
                        </div>--%>
                        <asp:HiddenField ID="IDHidden" runat="server" />
                        <div class="title">
                            <b>
                                <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal></b>
                        </div>
                        <div class="body">
                            <asp:Literal ID="BodyLiteral" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
