<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_P6.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<script language="javascript" type="text/javascript">
    alert("as");
    //recargar pagina con javascript
</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pasos">
        <img alt="Responsive image" class="img-responsive" src="https://sysweb.unach.mx/resources/imagenes/Paso5.png" />
    </div>
    <div class="titulo" align="left" style="padding-left: 40px;">
        <strong>
            <asp:Label ID="lblTitulo" runat="server" Text="PAGO CON TARJETA"></asp:Label>
        </strong>
        <br />
        <asp:Label ID="lblContador" runat="server"></asp:Label>
    </div>
    <br />
    <div class="container" style="padding-left: 40px;">

        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtFecha" runat="server" Text="FECHA DE PAGO" Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblFecha" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="padding-left: 40px;">
        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtReferencia" runat="server" Text="REFERENCIA" Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblReferencia" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="padding-left: 40px;">
        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtFolio" runat="server" Text="FOLIO" Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblFolio" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="padding-left: 40px;">
        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtMedioPago" runat="server" Text="MEDIO DE PAGO"
                        Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblMedioPago" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="padding-left: 40px;">
        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtNumTarjeta" runat="server" Text="Número de Tarjeta"
                        Width="150px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblNumTarjeta" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="padding-left: 40px;">
        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtAutorizacion" runat="server" Text="AUTORIZACIÓN"
                        Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblAutorizacion" runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container" style="padding-left: 40px;">
        <div class="row">
            <div class="col-md-3">
                <strong>
                    <asp:Label ID="lblEtImporte" runat="server" Text="IMPORTE" Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblImporte" runat="server"></asp:Label>
            </div>
        </div>
    </div>

    <div class="contenedor_botones alert-info" align="center">
        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Navy"></asp:Label>
        <br />
        <div style="border-radius: 10px 10px 10px 10px;
-moz-border-radius: 10px 10px 10px 10px;
-webkit-border-radius: 10px 10px 10px 10px;
border: 1px solid #18386b;">
            <asp:Label ID="lblmensaje2" runat="server"></asp:Label>
        </div>
    </div>
    <div align="center">
        <br />

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnRecibo" runat="server" CssClass="btn btn-primary bt-xs"
                    Text="Imprimir Recibo" OnClick="btnRecibo_Click" Visible="False" />
                &nbsp;
                    <asp:Button ID="btnPago" runat="server" CssClass="btn btn-primary bt-xs"
                        Text="Finalizar" OnClick="btnPago_Click" Visible="False" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />

        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image23" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                    class="img-responsive" alt="Responsive image" ToolTip="Espere un momento, por favor.." />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <iframe id="Iframe1" runat="server" frameborder="0" marginheight="0" marginwidth="0"
                    name="miniContenedor" style="height: 500px" width="100%"></iframe>
            </ContentTemplate>
        </asp:UpdatePanel>

        <br />
    </div>
</asp:Content>
