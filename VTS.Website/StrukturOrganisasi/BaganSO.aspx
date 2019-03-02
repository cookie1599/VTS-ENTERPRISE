<%@ Page Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="BaganSO.aspx.cs" Inherits="StrukturOrganisasi" Title="Bagan SO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>

    <script language="javascript" src="../Content/Js/custom.js" type="text/javascript"></script>

    <style type="text/css">
        .imageso {
            margin: auto;
            width: 79%;
        }

        @media (min-width: 480px) and (max-width: 768px) {
            .imageso {
                margin: 50px auto;
                width: 90%;
            }
        }

        @media (max-width: 480px) {
            .imageso {
                margin: 50px auto;
                width: 90%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="imageso">
        <asp:Image ID="PhotoImage" runat="server" Width="100%" />
        <asp:HiddenField ID="PhotoURLHidden" runat="server" />
    </div>
</asp:Content>
