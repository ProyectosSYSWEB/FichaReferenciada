<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="RespuestaPagoenLinea.aspx.cs" Inherits="EmisionPagoReferenciado.Form.RespuestaPagoenLinea" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pasos">
        &nbsp;</div>
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
                    <asp:Label ID="lblEtFecha" runat="server" Text="Fecha de Pago" Width="100px"></asp:Label>
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
                    <asp:Label ID="lblEtReferencia" runat="server" Text="Referencia" Width="100px"></asp:Label>
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
                    <asp:Label ID="lblEtFolio" runat="server" Text="Folio" Width="100px"></asp:Label>
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
                    <asp:Label ID="lblEtMedioPago" runat="server" Text="Medio de Pago"
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
                    <asp:Label ID="lblEtAutorizacion" runat="server" Text="Autorizacion"
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
                    <asp:Label ID="lblEtImporte" runat="server" Text="Importe" Width="100px"></asp:Label>
                </strong>
            </div>
            <div class="col-md-7">
                <asp:Label ID="lblImporte" runat="server"></asp:Label>
            </div>
        </div>
    </div>

    <div class="contenedor_botones" align="center">
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
