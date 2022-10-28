<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="RespuestaPagoPayPal.aspx.cs" Inherits="EmisionPagoReferenciado.Form.RespuestaPagoPayPal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center" id="divPagoConf" runat="server">
        <div class="row">
            <div class="col green-text">
                <h2 class="font-weight-bold">Gracias!</h2>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <img src="../Images/PagoConfirmado.png" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <strong>
                    <h4 class="font-weight-bold">Su pago fue realizado con éxito</h4>
                </strong>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlDependencia" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDependencia" runat="server" Text="--"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        ID de Transacción:
                        <asp:Label ID="lblIdTransaccion" runat="server" Text="Label"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>        
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlReferencia" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblReferencia" runat="server" Text="--"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>       
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlNombre" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblNombre" runat="server" Text="--"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlImporte" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblImporte" runat="server" Text="--"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="upPnlFechaPago" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblFechaPago" runat="server" Text="--"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="linkBttnRegresar" runat="server" CssClass="btn btn-info" OnClick="linkBttnRegresar_Click">Ir a página principal SYSWEB</asp:LinkButton>
                        <asp:LinkButton ID="linkBttnRecibo" runat="server" CssClass="btn btn-primary" OnClick="linkBttnRecibo_Click" Visible="False"><i class="fa fa-file"></i> Ver Recibo</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="updPnlRecibo" runat="server">
                    <ContentTemplate>
                        <iframe id="Iframe1" runat="server" frameborder="0" marginheight="0" marginwidth="0"
                            name="miniContenedor" style="height: 500px; width:100%"></iframe>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </div>
            </div>
    </div>
</asp:Content>
