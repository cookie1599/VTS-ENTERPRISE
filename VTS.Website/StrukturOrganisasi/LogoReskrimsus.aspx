<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="LogoReskrimsus.aspx.cs" Inherits="_Default" Title="Polda Metropolitan Jakarta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--  <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />--%>
    <%--
    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>--%>

    <script src="../Content/Js/custom.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Content/Css/Style.css" />
    <style type="text/css">
        h2 {
            text-align: center;
        }

        .logoreskrim {
            margin: auto;
            width: 50%;
        }

            .logoreskrim img {
                width: 100%;
            }

        @media (max-width:480px) {
            .logoreskrim {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="center">
        <h2>LOGO RESKRIMSUS</h2>
        <div class="logoreskrim">
            <img class="imagecache imagecache-ScaleCrop_350x240 imagecache-default imagecache-ScaleCrop_350x240_default" title="" alt="" src="../Content/Images/logo_reskrimsus.png">
        </div>
    </div>

</asp:Content>

