<%@ Page Language="C#" MasterPageFile="~/DefaultBackEnd.master" AutoEventWireup="true"
    CodeFile="AddSurat.aspx.cs" Inherits="Reskrimsus.Website.Administrator.AddSurat"
    Title="Surat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/calendar/calendar.css" rel="stylesheet" type="text/css" />

    <script src="../Content/calendar/calendar.js" type="text/javascript"></script>

    <%--<script src="../../Content/jquery-3.1.1.min.js" type="text/javascript"></script>--%>
    <link href="../Content/Css/Style.css" rel="stylesheet" type="text/css" />

    <script language="javascript" src="../../Content/Js/custom.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScripManager" runat="server">
    </asp:ScriptManager>
    <asp:HiddenField ID="PhotoURLHidden" runat="server" />
    <asp:HiddenField ID="PhotoDirectoryHidden" runat="server" />
    <asp:UpdateProgress ID="updateProgress" runat="server">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
                <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF;
                    font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div style="width: 500px; margin: auto;">
        <fieldset style="margin-bottom: 20px; border: solid 1px #8B4513; border-radius: 8px;
            padding: 10px; margin-top: 40px;">
            <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; border-radius: 8px;
                padding: 6px; color: White; text-align: center; font-weight: bold; width: 90%;">
                <asp:Literal ID="PageTitleLiteral" Text="Laporan Polisi" runat="server"></asp:Literal>
            </legend>
            <table width="400px;">
                <tr id="PelaporTr" runat="server">
                    <td>
                        <fieldset style="border: solid 1px #8B4513; border-radius: 8px; padding: 30px; width: 200px;">
                            <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; border-radius: 8px;
                                padding: 6px; color: White; text-align: center; font-weight: bold; width: 50%;">
                                Data Pelapor</legend>
                            <table>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Nomor Kartu Tanda Penduduk : </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="NoKTPTextBox" ValidationGroup="valPelapor" CssClass="customTextBox"
                                            Width="300px" runat="server" OnTextChanged="NoKTPTextBox_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <br />
                                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="valPelapor" ID="RequiredFieldValidator5"
                                            runat="server" ControlToValidate="NoKTPTextBox" Text="*" ErrorMessage="Nomor KTP harus diisi."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Nama Pelapor :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="NamaPelaporTextBox" ValidationGroup="valPelapor" CssClass="customTextBox"
                                            Width="300px" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="valPelapor" ID="RequiredFieldValidator2"
                                            runat="server" ControlToValidate="NamaPelaporTextBox" Text="*" ErrorMessage="<br>Nama Pelapor harus diisi."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Password Pelapor :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="PasswordPelaporTextBox" ValidationGroup="valPelapor" CssClass="customTextBox"
                                            Width="300px" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="valPelapor" ID="RequiredFieldValidator3"
                                            runat="server" ControlToValidate="PasswordPelaporTextBox" Text="*" ErrorMessage="<br>Password Pelapor harus diisi."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Email :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="EmailTextBox" ValidationGroup="valPelapor" CssClass="customTextBox"
                                            Width="300px" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="EmailTextBox" Text="*" ValidationGroup="valPelapor" ErrorMessage="<br>Email harus diisi."></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="validateEmail" ValidationGroup="valPelapor" runat="server"
                                            ErrorMessage="<br>Format email salah." ControlToValidate="EmailTextBox" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding: 10px;">
                                        <asp:Button ID="NextButton" runat="server" ValidationGroup="valPelapor" Text="Lanjutkan"
                                            OnClick="NextButton_Click" Width="50%" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr id="LaporTr" runat="server" visible="false">
                    <td>
                        <fieldset style="border: solid 1px #8B4513; border-radius: 8px; padding: 30px; width: 200px;">
                            <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; border-radius: 8px;
                                padding: 6px; color: White; text-align: center; font-weight: bold; width: 50%;">
                                Data Lapor</legend>
                            <table>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Laporan Polisi :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="NomorLPTextBox" ValidationGroup="ValDataLaporan" AutoPostBack="true"
                                            CssClass="customTextBox" Width="300px" runat="server" OnTextChanged="NomorLPTextBox_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RFVNomorLP" ValidationGroup="ValDataLaporan"
                                            runat="server" ControlToValidate="NomorLPTextBox" Text="*" ErrorMessage="<br>Nomor laporan polisi harus diisi."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Tanggal Laporan Polisi :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px; padding-left: 6px;">
                                        <asp:TextBox ID="TanggalLaporanPolisiTextBox" ValidationGroup="ValDataLaporan" runat="server"
                                            Width="80px" BackColor="#CCCCCC"></asp:TextBox>
                                        <asp:Literal ID="TanggalLaporanPolisiLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>No. SPRINDIK :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="NoSPRINDIKTextBox" ValidationGroup="ValDataLaporan" CssClass="customTextBox"
                                            Width="300px" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator1" ValidationGroup="ValDataLaporan"
                                            runat="server" ControlToValidate="NoSPRINDIKTextBox" Text="*" ErrorMessage="<br>Nomor SPRINDIK harus diisi."></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Tanggal SPRINDIK :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px; padding-left: 6px;">
                                        <asp:TextBox ID="TanggalSPRINDIKTextBox" ValidationGroup="ValDataLaporan" runat="server"
                                            Width="80" BackColor="#CCCCCC"></asp:TextBox>
                                        <asp:Literal ID="TanggalSPRINDIKLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding: 10px;">
                                        <asp:Button ID="LastNextButton" ValidationGroup="ValDataLaporan" runat="server" Text="Lanjutkan"
                                            OnClick="LastNextButton_Click" Width="50%" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
                <tr id="SuratLpDt" runat="server" visible="false">
                    <td>
                        <fieldset style="border: solid 1px #8B4513; border-radius: 8px; padding: 30px; width: 200px;">
                            <legend align="center" style="background: #8B4513; border: solid 1px #8B4513; border-radius: 8px;
                                padding: 6px; color: White; text-align: center; font-weight: bold; width: 50%;">
                                SP2HP</legend>
                            <%--<asp:Panel ID="AddSP2HPPanel" runat="server">--%>
                            <table>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>No. SP2HP :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="NoSP2HPTextBox" CssClass="customTextBox" Width="300px" runat="server"
                                            AutoPostBack="true" OnTextChanged="NoSP2HPTextBox_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator6" runat="server"
                                            ControlToValidate="NoSP2HPTextBox" Text="*" ErrorMessage="<br>Nomor SP2HP harus diisi."></asp:RequiredFieldValidator>
                                        <div style="text-align: right; margin-top:-20px; padding-right:5px;">
                                            <asp:HyperLink ID="SP2HPHyperlink" runat="server" Target="_blank" Visible="false">Lihat File dengan No.SP2HP ini</asp:HyperLink></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Tanggal SP2HP :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px; padding-left: 6px;">
                                        <asp:TextBox ID="TanggalSP2HPTextBox" runat="server" Width="80" BackColor="#CCCCCC"></asp:TextBox>
                                        <asp:Literal ID="TanggalSP2HPLiteral" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-left: 10px;">
                                        <b>Upload File Hasil Scan :</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-bottom: 20px; padding-left: 6px;">
                                        <asp:FileUpload ID="SP2HPFileUpload" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top: 30px;">
                                        <asp:Button ID="SubmitButton" Text="Simpan" runat="server" OnClick="SubmitButton_Click"
                                            Width="50%" />
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                        </fieldset>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="WarningLabel" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding: 20px;">
                        <asp:Button ID="Button1" runat="server" Text="Kembali" CausesValidation="false" OnClick="BackButton_Click"
                            Width="40%" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
