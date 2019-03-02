<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/DefaultFrondEnd.master" AutoEventWireup="true"
    CodeFile="LaporanMasyarakat.aspx.cs" Inherits="LayananMasyarakat_LaporanMasyarakat"
    Title="Layanan Masyarakat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" href="../Content/Css/menu.css" rel="Stylesheet" />

    <script src="../Content/Js/flux.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Content/Css/jquery-ui.css">
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="../Content/Js/jquery-ui.js"></script>
    <script src="../Content/Js/custom.js" type="text/javascript"></script>
    <script src="../Content/JScript.js" type="text/javascript"></script>
    <script>
        $(function () {
            $("#accordion").accordion();
        });
    </script>
    <style type="text/css">
        .laporan-group {
            margin: 30px auto;
            width: 60%;
        }

        .laporan {
            margin: 5px 0;
        }

            .laporan input, textarea {
                width: 100%;
            }

                .laporan input[type=submit] {
                    background-color: white;
                    border: 2px solid #007FFF;
                    color: #007FFF;
                    margin: auto;
                    font-weight: 700;
                }

                    .laporan input[type=submit]:hover, input[type=submit]:active {
                        background-color: #007FFF;
                        color: white;
                    }

            .laporan textarea {
                min-height: 100px;
            }

        .background-accordion {
            padding: 30px;
            background-color: #eaeaea;
            margin-bottom: 50px;
        }

            .background-accordion .mainaccordion {
                margin: 0 0 10px;
            }

        div.panel {
            padding: 0 18px;
            display: none;
            background-color: white;
        }

        .datetime {
            text-align: right;
            margin: 10px 0 0 0;
            font-size: 10px;
            color: red;
        }

        .content-inner {
            margin: auto;
            width: 70%;
        }

        .maincontent {
            float: left;
            margin-right: -105px;
            width: 70%;
        }

        .mainlaporan {
            overflow-x: auto;
        }

        @media screen and (max-width: 480px) {
            .content-inner {
                width: 100%;
            }

            .maincontent {
                width: 100%;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-inner">
        <%-- <div id="main-content">--%>
        <div class="maincontent">
            <div id="main-content-header">
                <h1 id="page-title">
                    <%--Laporan Masyarakat--%>
                    <asp:Literal ID="TitleLiteral" runat="server"></asp:Literal></h1>
            </div>
            <div id="Div1">
                <%--<div id="article-395" class="article article-promoted page-article">--%>
                <%--<p>
                        <font id="yui_3_2_0_17_13154523502377444" size="2">Bagi masyarakat yang ingin mengirimkan
                            informasi laporan bisa </font>
                    </p>
                    <p>
                        email : <a href="mailto:info@reskrimsus.org">info@reskrimsus.org</a>
                    </p>
                    <p>
                        <font size="2">Terima kasih atas perhatian dan kerjasamanya</font>
                    </p>
                    <p>
                    </p>--%>
                <asp:Literal ID="BodyLiteral" runat="server" Visible="false"></asp:Literal>
                <%--</div>--%>
            </div>
            <div class="row" style="color: red;">
                <asp:ValidationSummary runat="server" ID="CUVS" />
                <asp:Label ID="LabelWarning" runat="server"></asp:Label>
            </div>
            <div>
                <div class="laporan-group">
                    <div class="form-group laporan">
                        <asp:TextBox runat="server" type="text" name="name" placeholder="Nama" class="contact-name form-control textinput"
                            ID="contactname"></asp:TextBox>
                    </div>
                    <div class="form-group laporan">
                        <asp:TextBox runat="server" type="text" name="email" placeholder="Email" class="contact-email form-control textinput"
                            ID="contactemail"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="contactemail"
                            ErrorMessage="Email harus valid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group laporan">
                        <asp:TextBox runat="server" placeholder="No. Handphone" class="contact-phone form-control textinput"
                            ID="Contactphone"></asp:TextBox>
                    </div>
                    <div class="form-group laporan">
                        <asp:TextBox runat="server" type="text" name="subject" placeholder="Perihal" class="contact-subject form-control textinput"
                            ID="contactsubject"></asp:TextBox>
                    </div>
                    <div class="form-group laporan">
                        <asp:TextBox name="message" runat="server" TextMode="MultiLine" placeholder="Isi" class="contact-message form-control textinput"
                            ID="contactmessage"></asp:TextBox>
                    </div>
                    <div class="form-group laporan">
                        <asp:Button runat="server" class="btn-send" ID="SendButton" CausesValidation="true" Text="KIRIM" OnClick="SendButton_Click" />
                    </div>
                </div>
                <p>
                    Atau bisa melalui email <a href="mailto:info@reskrimsus.org">info@reskrimsus.org</a>
                </p>
            </div>
            <div class="background-accordion">
                <h2 style="color: #007FFF;">Laporan Masyarakat</h2>
                <div id="accordion">
                    <asp:Repeater runat="server" ID="ListRepeater" OnItemDataBound="ListRepeater_ItemDataBound">
                        <ItemTemplate>
                            <h1 style="font-size: 14px; font-weight: 900;">
                                <asp:Literal ID="PerihalLiteral" Visible="true" runat="server"></asp:Literal></h1>
                            <div class="mainlaporan" style="overflow-x: scroll !important">
                                <h2 style="font-size: 14px;">Pelapor :
                                    <asp:Literal ID="NamaLiteral" Visible="true" runat="server"></asp:Literal></h2>
                                <p class="datetime">
                                    <asp:Literal ID="CreatedDateLiteral" Visible="true" runat="server"></asp:Literal>
                                </p>
                                <p>
                                    <asp:Literal ID="PesanLiteral" Visible="true" runat="server"></asp:Literal>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
