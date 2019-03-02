<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="HubungiKami.aspx.cs" Inherits="HubungiKami_HubungiKami" Title="Lokasi Kami" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />--%>
    <%--
    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>--%>

    <script src="../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-hubungi-kami container">
        <div class="content-inner">
            <div id="main-content">
                <div id="content">
                    <div class="view view-form view-id-form view-display-id-page_1">
                        <div class="view-content">
                            <div class="views-row-unformatted views-row views-row-1 views-row-odd views-row-first views-row-last">
                                <div class="title">
                                    <div class="left">
                                        <div class="image">
                                            <%--<img class="imagecache imagecache-ScaleCrop_350x240 imagecache-default imagecache-ScaleCrop_350x240_default"
                                                width="350" height="240" title="" alt="" src="../Content/Images/depan krimsus.jpg.png">--%>
                                            <asp:Image ID="Foto" Width="350" Height="240" runat="server" />
                                        </div>
                                    </div>
                                    <div class="right" style="height: 244px;">
                                        <div class="title">
                                            <%--DIREKTORAT RESERSE KRIMINAL KHUSUS POLDA METRO JAYA--%>
                                            <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal>
                                        </div>
                                        <div class="body">
                                            <p>
                                                <%--Jl.Jenderal Sudirman Kav. 55
                                                <br>
                                                Jakarta Selatan 12190
                                                <br>
                                                Telp. : +62215234077
                                                <br>
                                                email : <a href="mailto:info@reskrimsus.org">info@reskrimsus.org</a>--%>
                                                <asp:Literal ID="BodyLiteral" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="map">
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d6670.509268584322!2d106.81294222510797!3d-6.222986056757325!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x2e69f156a6972fd3%3A0xb67e105f8f8164e4!2sPolda+Metro+Jaya!5e0!3m2!1sid!2sid!4v1479371736158"
                width="800" height="400" frameborder="0" style="border: 0" allowfullscreen></iframe>
        </div>
    </div>
</asp:Content>
