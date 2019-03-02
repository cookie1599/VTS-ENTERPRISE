<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" Title="Polda Metropolitan Jakarta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--    <link href="Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="Content/calendar/calendar.js" type="text/javascript"></script>--%>
    <%--<script src="Content/jquery-3.1.1.min.js" type="text/javascript"></script--%>
    <script src="Content/Js/flux.min.js" type="text/javascript"></script>
    <link type="text/css" rel="stylesheet" href="Content/Css/styles2.css" />
    <script type="text/javascript" src="Content/Js/jquery.flexslider-min.js"></script>
    <script src="Content/Js/custom.js" type="text/javascript"></script>
    <%--    <link rel="stylesheet" href="Content/bootstrap_css/bootstrap.min.css" />
    <script type="text/javascript" src="Content/bootstrap_js/bootstrap.min.js"></script>--%>
    <script type="text/javascript" charset="utf-8">
        var $ = jQuery.noConflict();
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "fade"
            });

            $(function () {
                $('.show_menu').click(function () {
                    $('.menu').fadeIn();
                    $('.show_menu').fadeOut();
                    $('.hide_menu').fadeIn();
                });
                $('.hide_menu').click(function () {
                    $('.menu').fadeOut();
                    $('.show_menu').fadeIn();
                    $('.hide_menu').fadeOut();
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sosmed container">
        <div id="twitter" class="widgets">
            <a class="twitter-timeline" <%--data-width="300"--%> data-height="300" href="https://twitter.com/ditkrimsusPMJ">Tweets by ditkrimsusPMJ</a>
            <script async src="//platform.twitter.com/widgets.js" charset="utf-8"></script>
        </div>
        <div id="facebook" class="widgets">
            <div id="fb-root"></div>
            <script>
                (function (d, s, id) {
                    var js, fjs = d.getElementsByTagName(s)[0];
                    if (d.getElementById(id)) return;
                    js = d.createElement(s); js.id = id;
                    js.src = "//connect.facebook.net/id_ID/sdk.js#xfbml=1&version=v2.8";
                    fjs.parentNode.insertBefore(js, fjs);
                }(document, 'script', 'facebook-jssdk'));
            </script>
            <div class="fb-page"
                data-href="https://www.facebook.com/cyberpoldametrojaya/"
                data-tabs="timeline,events"
                <%--data-width="300"--%>
                data-height="300"
                data-small-header="true"
                data-adapt-container-width="true"
                data-hide-cover="true"
                data-show-facepile="false">
                <blockquote cite="https://www.facebook.com/cyberpoldametrojaya/" class="fb-xfbml-parse-ignore">
                    <a href="https://www.facebook.com/cyberpoldametrojaya/">Subdit Cyber Crime Polda Metro Jaya</a>
                </blockquote>
            </div>
        </div>
        <div id="berita" class="widgets">
            <p style="text-align: center; margin: -12px 0; font-weight: 900; font-size: 18px;">Berita Terbaru</p>
            <div class="slider_container">
                <div class="flexslider">
                    <ul class="slides">
                        <asp:Repeater runat="server" ID="ListRepeater" OnItemCommand="ListRepeater_ItemCommand"
                            OnItemDataBound="ListRepeater_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <%--<a href="http://www.freshdesignweb.com">
                                        <img src="Content/Images/Slider/polri1.png" alt="" title="" /></a>--%>
                                    <asp:HyperLink ID="NewsHyperLink" runat="server">
                                        <asp:Image Width="250px" Height="300px" ID="ImageBerita" runat="server" />
                                    </asp:HyperLink>
                                    <div class="flex-caption">
                                        <div class="caption_title_line">
                                            <p>
                                                <asp:Literal ID="NewsNameLiteral" Visible="true" runat="server"></asp:Literal>
                                            </p>
                                        </div>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%-- <li>
                                    <a href="http://www.freshdesignweb.com">
                                        <img src="Content/Images/Slider/pmj1.png" alt="" title="" /></a>
                                    <div class="flex-caption">
                                        <div class="caption_title_line">
                                            <h4>POLDA METRO JAYA</h4>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <a href="http://www.freshdesignweb.com">
                                        <img src="Content/Images/Slider/reskrim1.png" alt="" title="" /></a>
                                    <div class="flex-caption">
                                        <div class="caption_title_line">
                                            <h4>RESKRIMSUS</h4>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <a href="http://www.freshdesignweb.com">
                                        <img src="Content/Images/Slider/humas1.png" alt="" title="" /></a>
                                    <div class="flex-caption">
                                        <div class="caption_title_line">
                                            <h4>HUMAS POLRI</h4>
                                        </div>
                                    </div>
                                </li>--%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="content-inner">
        <asp:HiddenField ID="PageLinkHidden" runat="server" />
        <asp:HiddenField ID="RowCountLinkHidden" runat="server" />
        <asp:HiddenField ID="IdInformationHiddenField" runat="server" />
        <asp:HiddenField ID="ImageURLHidden" runat="server" />
        <%--<div id="main-content">
            <div id="content" style="display: none;">
                <div class="view-home">
                    <div class="Title">
                        <div class="left">
                            <asp:HiddenField ID="PageLinkHidden" runat="server" />
                            <asp:HiddenField ID="RowCountLinkHidden" runat="server" />
                            <asp:Image ID="Foto" Width="300" Height="235" runat="server" />
                        </div>
                        <div class="right">
                            <div class="title">
                                <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal>
                            </div>
                            <div class="body">
                                <p>
                                    <asp:Label ID="BodyLabel" CssClass="body" runat="server"></asp:Label>
                                </p>
                            </div>
                            <div class="link">
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Lebih Lanjut" OnClick="LinkButton1_Click"></asp:LinkButton>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        <%-- <div id="content-bottom">
            <div id="block-views-home-block_2">
                <div class="block-inner">
                    <h2>
                        Berita Terbaru
                    </h2>
                    <div class="Content">
                        <div class="view-home">
                            <div class="view-content">
                                <table class="views-view-grid">
                                    <tbody>
                                        <tr class="row-1 row-first">
                                            <asp:Repeater runat="server" ID="ListRepeaterBeritaTerbaru" OnItemCommand="ListRepeaterBeritaTerbaru_ItemCommand"
                                                OnItemDataBound="ListRepeaterBeritaTerbaru_ItemDataBound">
                                                <ItemTemplate>
                                                    <td class="col-2">
                                                        <div class="title-1">
                                                            <div class="title">
                                                                <asp:Literal ID="TitleBeritaLiteral" runat="server"></asp:Literal></div>
                                                            <div class="image">
                                                                <asp:Image ID="ImageBerita" Width="125" Height="80" runat="server" />
                                                            </div>
                                                            <div class="body" style="height: 210px;">
                                                                <div class="body">
                                                                    <p>
                                                                        <asp:Literal ID="BodyBeritaLiteral" runat="server"></asp:Literal></p>
                                                                </div>
                                                                <div class="link">
                                                                    <asp:LinkButton ID="LinkButtonBerita" runat="server" Text="Selengkapnya"></asp:LinkButton>
                                                                </div>
                                                                <div class="clear">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="block-views-home-block_3" style="display: none;">
                <div class="block-inner">
                    <h2>
                        Kolom Artikel</h2>
                    <div class="content">
                        <div class="view view-home view-id-home view-display-id-block_3 views-processed">
                            <div class="views-messages">
                                <div class="view-content">
                                    <div class="views-row-unformatted views-row views-row-1 views-row-odd views-row-first views-row-last">
                                        <div class="title-1">
                                            <div class="title">
                                                <asp:Literal ID="InfoLiteral" runat="server"></asp:Literal>
                                            </div>
                                            <div class="left">
                                                <div class="image">
                                                  
                                                    <asp:Image ID="ImageInfo" Width="125" Height="80" runat="server" />
                                                </div>
                                            </div>
                                            <div class="right">
                                                <div class="body">
                                                    <p>
                                                        <asp:Literal ID="InfoBodyLiteral" runat="server"></asp:Literal>
                                             
                                                </div>
                                                <div class="link">
                                                    <asp:HiddenField ID="IdInformationHiddenField" runat="server" />
                                               
                                                    <asp:LinkButton ID="LinkButton7" runat="server" Text="Baca Selengkapnya" OnClick="LinkButton7_Click"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="clear">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="item-list">
                                    <ul class="pager" style="display: none;">
                                        <li class="pager-current even first">1</li>
                                        <li class="pager-item odd"><a class="active" title="Go to page 2" href="/home?page=1&js=1&view_name=home&view_display_id=block_3&view_path=home&view_base_path=home&view_dom_id=5&pager_element=0&view_args=">
                                            2</a> </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        <div id="ContentBottom">
            <div id="Content">
                <div id="SocialMedia">
                    <div class="icon">
                        <asp:HyperLink Target="_blank" runat="server" ID="HyperLink4" NavigateUrl="http://twitter.com/ditkrimsusPMJ/">
                        <asp:Image ImageUrl="~/Content/Css/Images/twitter.png" runat="server"/>
                        </asp:HyperLink>
                    </div>
                    <div class="icon">
                        <asp:HyperLink Target="_blank" runat="server" ID="HyperLink3" NavigateUrl="https://www.facebook.com/cyberpoldametrojaya/">
                        <asp:Image ImageUrl="~/Content/Css/Images/facebook.png" runat="server" /></asp:HyperLink>
                    </div>
                    <div class="icon">
                        <asp:HyperLink Target="_blank" runat="server" ID="HyperLink2">
                        <asp:ImageButton ImageUrl="~/Content/Css/Images/YouTube.png" runat="server" /></asp:HyperLink>
                    </div>
                    <div class="icon">
                        <asp:HyperLink Target="_blank" runat="server" ID="HyperLink1" NavigateUrl="http://www.instagram.com/ditreskrimsuspoldametrojaya/">
                            <asp:Image ID="ImageButton1" runat="server" ImageUrl="~/Content/Css/Images/instagram.png" />
                        </asp:HyperLink>
                    </div>
                    <div class="icon">
                        <%--<asp:ImageButton ImageUrl="~/Content/Css/Images/g_plus.png" runat="server" PostBackUrl="http://plus.google.com/103545519301947397936" />--%>
                        <asp:HyperLink Target="_blank" runat="server" ID="GplussHyperlink" NavigateUrl="http://plus.google.com/103545519301947397936">
                       <asp:Image ImageUrl="~/Content/Css/Images/g_plus.png" runat="server" />
                        </asp:HyperLink>
                    </div>
                </div>
                <div id="block-views-home-block_4">
                    <div class="block-inner" style="display: none;">
                        <h2>Links</h2>
                        <div class="content">
                            <div class="view view-home view-id-home view-display-id-block_4 views-processed">
                                <div class="views-messages">
                                    <div class="view-content">
                                        <%--<div class="views-row-unformatted views-row views-row-1 views-row-odd views-row-first">
                                        <div class="title">
                                            <a title="Kepolisian Negara RI" href="http://www.polri.go.id/">Kepolisian Negara RI</a>
                                        </div>
                                    </div>
                                    <div class="views-row-unformatted views-row views-row-2 views-row-even">
                                        <div class="title">
                                            <a title="Bareskrim POLRI" href="http://www.bareskrim.go.id/">Bareskrim POLRI</a>
                                        </div>
                                    </div>
                                    <div class="views-row-unformatted views-row views-row-3 views-row-odd">
                                        <div class="title">
                                            <a title="Depkumham" href="http://www.kemenkumham.go.id/">Depkumham</a>
                                        </div>
                                    </div>
                                    <div class="views-row-unformatted views-row views-row-4 views-row-even">
                                        <div class="title">
                                            <a title="Depkominfo" href="http://www.depkominfo.go.id/">Depkominfo</a>
                                        </div>
                                    </div>
                                    <div class="views-row-unformatted views-row views-row-5 views-row-odd views-row-last">
                                        <div class="title">
                                            <a title="Kejaksaan Agung RI" href="http://www.kejaksaan.go.id/">Kejaksaan Agung RI</a>
                                        </div>
                                    </div>--%>
                                        <asp:Repeater runat="server" ID="ListRepeaterLink" OnItemCommand="ListRepeaterLink_ItemCommand"
                                            OnItemDataBound="ListRepeaterLink_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="views-row-unformatted">
                                                    <div class="title">
                                                        <asp:LinkButton ID="LinkButton" runat="server">
                                                            <asp:Literal ID="NameLiteral" runat="server"></asp:Literal>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <asp:Button ID="DataPagerButton4" runat="server" OnClick="DataPagerButton4_Click" />
                                        <asp:Repeater EnableViewState="true" ID="DataPagerTopRepeater4" runat="server" OnItemCommand="DataPagerTopRepeater4_ItemCommand"
                                            OnItemDataBound="DataPagerTopRepeater4_ItemDataBound">
                                            <ItemTemplate>
                                                <td>
                                                    <asp:LinkButton ID="PageNumberLinkButton" runat="server" CssClass="PageNumberLinkButton2"></asp:LinkButton>
                                                    <asp:TextBox Visible="false" ID="PageNumberTextBox" runat="server" Width="20px"></asp:TextBox>
                                                </td>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="item-list">
                                        <ul class="pager" style="display: none;">
                                            <li class="pager-current even first">1</li>
                                            <li class="pager-item odd"><a class="active" title="Go to page 2" href="/home?page=1&js=1&view_name=home&view_display_id=block_4&view_path=home&view_base_path=home&view_dom_id=6&pager_element=0&view_args=">2</a> </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="Content">
                        <div class="divimg">
                            <a href="https://www.polri.go.id/">
                                <img src="Content/Images/LINK/POLRI.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="https://www.polri.go.id/">
                                <img src="Content/Images/LINK/BARESKRIM.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="http://lpse.metro.polri.go.id/eproc4">
                                <img src="Content/Images/LINK/LPSE.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="http://humaspoldametrojaya.blogspot.co.id/">
                                <img src="Content/Images/LINK/HUMAS.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="http://reskrimum.metro.polri.go.id/site/">
                                <img src="Content/Images/LINK/RESKRIMUM.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="http://resnarkoba.metrojaya.org/">
                                <img src="Content/Images/LINK/RESNARKOBA.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="http://penerimaan.polri.go.id/">
                                <img src="Content/Images/LINK/PENERIMAAN.png" class="linkimg" /></a>
                        </div>
                        <div class="divimg">
                            <a href="https://www.kejaksaan.go.id/">
                                <img src="Content/Images/LINK/KEJAKSAAN.png" class="linkimg" /></a>
                        </div>
                    </div>
                </div>
                <%--<div id="block-faceted_search_ui-1_keyword">
            <div class="block-inner">
                <h2>
                    Search</h2>
                <div class="content" style="border-radius: 5px;">
                    <form id="faceted-search-ui-form-1" method="post" accept-charset="UTF-8" action="/home">
                    <div align="center">
                        <asp:Panel DefaultButton="SearchButton" runat="server" ID="SearchingPanel">
                            <table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="KeywordTextBox" Width="130" CssClass="form-text" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="SearchButton" runat="server" ImageUrl="~/Content/Css/Images/btn_search.jpg"
                                            OnClick="SearchButton_Click" Style="margin-top: 10px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                    </form>
                </div>
            </div>
        </div>--%>
                <div id="block-hits_counter-0" class="block block-hits_counter odd block-region-content-bottom block-count-8">
                    <div class="block-inner">
                        <h2>Statistik Pengunjung</h2>
                        <div class="content">
                            <div class="label" style="color: #4FA0CA;">
                                Jumlah Pengunjung Website Ini :
                            </div>
                            <%--<div class="value">
                            329169</div>--%>
                            <script type="text/javascript" src="http://counter9.freecounter.ovh/private/counter.js?c=4e95ba710298ab2b04c83d682ccb7c98"></script>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
