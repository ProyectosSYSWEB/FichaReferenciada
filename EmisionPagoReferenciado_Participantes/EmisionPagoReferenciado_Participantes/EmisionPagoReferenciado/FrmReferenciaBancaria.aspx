<%@ Page Title="" Language="C#" AutoEventWireup="true"
    CodeBehind="FrmReferenciaBancaria.aspx.cs" Inherits="EmisionPagoReferenciado.FrmReferenciaBancaria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Pago Referenciado</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/ReportesFicha.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
            <div class="header">
           </div>
    <div>
    <table style="width: 100%;">
        <tr>
            <td class="style1" colspan="3">
                <asp:Label ID="Label10" runat="server" CssClass="title" Text="REFERENCIA BANCARIA&nbsp; &nbsp; "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
      <%--  <tr>
            <td class="style1">
                &nbsp;<asp:Label ID="lblNombre" runat="server" Text="NOMBRE:" CssClass="bold"></asp:Label>
            </td>
            <td style="margin-left: 40px">
                <asp:Label ID="lblNombre_l" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="margin-left: 40px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;<asp:Label ID="lblReferencia" runat="server" Text="REFERENCIA:" CssClass="bold"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:Label ID="lblReferencia_l" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;<asp:Label ID="lblImporte" runat="server" Text="IMPORTE:" CssClass="bold"></asp:Label>
            </td>
            <td style="margin-left: 40px">
                <asp:Label ID="lblImporte_l" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td style="margin-left: 40px">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;<asp:Label ID="lblVigencia" runat="server" Text="VIGENCIA:" CssClass="bold"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblVigencia_l" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;<asp:Label ID="lblConcepto" runat="server" Text="CONCEPTO:" CssClass="bold"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblConcepto_l" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        
        <tr>
            <td class="style1" align="center" colspan="3">
                <asp:Button ID="btnImprime_Ficha" runat="server"  CssClass="boton" Text="IMPRIMIR FICHA REFERENCIADA"
                    OnClick="btnImprime_Ficha_Click" />
                &nbsp;<asp:Button ID="btnPago_Linea" runat="server" Visible="false" CssClass="boton" Text="PAGAR EN LINEA CON TARJETA BANCARIA"
                    OnClick="btnPago_Linea_Click" />
            </td>
        </tr>--%>
        <tr>
            <td class="style1" colspan="2" align="center">
                <asp:Label ID="lblMsj" runat="server" Style="text-align: center" Font-Bold="True"
                    ForeColor="#3166A2"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style1">
             <iframe id="Iframe1" runat="server" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor"
                                style="height: 800px" width="100%"></iframe>
            </td>
        </tr>
    </table>
   </div>
    </form>
</body>
</html>
