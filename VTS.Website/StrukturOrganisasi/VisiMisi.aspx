<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="VisiMisi.aspx.cs" Inherits="_Default" Title="Polda Metropolitan Jakarta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />--%>
    <%--
    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>--%>

    <script src="../Content/Js/custom.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Content/Css/Style.css" />
    <style type="text/css">
        .maincontent {
            width: 80%;
            margin: auto;
            padding: 30px 0;
        }

        h2 {
            text-align: center;
        }

        p {
            text-align: justify;
            margin: 0 0 10px 0;
            line-height: 20px;
        }

        ol li {
            text-align: justify;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="maincontent">
        <h2>VISI DAN MISI</h2>

        <p>
            Visi Dit Reskrimsus Polda Metro Jaya :
        </p>

        <ul>
            <li>Terwujudnya pelayanan penyelidikan dan penyidikan yang profesional, prosedural, proposional, transparan, akuntabel dan dapat dipercaya masyarakat, guna tegaknya hukum dan keamanan di wilayah hukum Polda Metro Jaya.</li>
        </ul>
        <p>
            Misi Dit Reskrimsus Polda Metro Jaya :
        </p>

        <ol type="1">
            <li>Memberikan perlindungan, pengayoman dan pelayanan kepada masyarakat secara profesional, prosedural, proposional, cepat, tepat, transparan, akuntabel dan tanpa imbalan.</li>
            <li>Membangun kemitraan dengan segenap elemen masyarakat guna meningkatkan partisipasi masyarakat, khususnya dalam hal memberikan informasi tentang telah, sedang atau akan terjadinya suatu kejahatan. </li>
            <li>Melakukan upaya-upaya untuk membangun solidaritas anggota dan kesatuan.</li>
            <li>Terus menerus melakukan peningkatan profesionalisme dan kesejahteraan anggota Dit Reskrimsus Polda Metro Jaya dan fungsi reskrim jajaran Polda Metro Jaya.</li>
            <li>Melakukan kerjasama dengan segenap komponen masyarakat dan instansi/lembaga terkait, baik pemerintah maupun swasta.</li>
            <li>Menegakan hukum dalam rangka menjamin tegak dan tertibnya hukum, guna memberikan kepastian hukum dan keadilan secara profesional.</li>
            <li>Menjujung tinggi supremasi hukum dan hak asasi manusia.</li>
        </ol>
    </div>
</asp:Content>

