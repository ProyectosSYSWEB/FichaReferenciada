<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagoExclusivoSIAE.aspx.cs" Inherits="EmisionPagoReferenciado.Form.PagoExclusivoSIAE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 412px;
            height: 323px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div id="InfPagoRef" runat="server">
        <div class="row">
            <div class="col text-center">
                <asp:Label ID="lblMsj" runat="server" Style="text-align: center" Font-Bold="True" ForeColor="#3166A2"></asp:Label>
            </div>
        </div>
        <div class="container d-md-none">
            <div class="row">
                <div class="col-md-2">
                    Para realizar el pago presentar en el banco la referencia y el importe.            
                </div>
                <div class="col-md-10 text-center">
                    <img src="../Images/bancos.png" class="img-responsive" alt="Responsive image" />
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:Label ID="lblNombre_l" runat="server" CssClass="form-control" ForeColor="#5d5d62"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblReferencia" runat="server" Text="Referencia"></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:Label ID="lblReferencia_l" runat="server" CssClass="form-control text-dark font-weight-bold"></asp:Label>
                </div>

                <div class="col-md-2">
                    <asp:Label ID="lblImporte" runat="server" Text="Importe"></asp:Label>
                </div>
                <div class="col-md-3">
                    <div class="input-group">
                        <asp:Label ID="lblImporte_l" runat="server" CssClass="form-control text-dark font-weight-bold"></asp:Label>
                        <div class="input-group-append">
                            <span class="input-group-text" id="basic-addon2">MXN</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblConcepto" runat="server" Text="Concepto"></asp:Label>
                </div>
                <div class="col-md-10">
                    <asp:Label ID="lblConcepto_l" runat="server" CssClass="form-control text-dark" Height="100%" Width="100%"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblVigencia" runat="server" Text="Vigencia"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="lblVigencia_l" runat="server" CssClass="form-control text-dark font-weight-bold"></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblForma_Pago" runat="server" Text="Forma de Pago"></asp:Label>
                </div>

                <div class="col-md-10">
                    <div class=" alert alert-warning">

                        <asp:Label ID="lblTextformpago" runat="server" Text="Todas las transacciones son seguras y encriptadas. La información de tu tarjeta de crédito o débito nunca es almacenada."></asp:Label>
                    </div>


                </div>
            </div>
        </div>
        <div class="container" id="divExpiroFecha" runat="server" visible="false">
            <div class="row alert alert-danger">
                <div class="col text-center font-weight-bold">
                    La vigencia de la referencia ya expiro.
                </div>
            </div>
        </div>
        <div class="container" id="divPagoTDC" runat="server">
            <div class="row text-center">
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                    <asp:ImageButton ID="imgBttnPagoEfec" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/formaPago_Efectivo.png" OnClick="imgBttnPagoEfec_Click" />
                    <h5>PAGO EN EFECTIVO</h5>
                </div>
                <div class="col-md-3">
                    <asp:ImageButton ID="imgBttnPagoTDC" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/formaPago_TDC.png" OnClick="imgBttnPagoTDC_Click" />
                    <h5>PAGO CON TARJETA</h5>
                </div>
                <div class="col-md-3">
                </div>
            </div>

        </div>
        <br />
    </div>
    <div id="AccesoDen" runat="server" visible="false">
        <div class="container">
            <div class="row">
                <div class="col-md-5">
                    <img src="../Images/pngocean.com.PNG" class="auto-style1" />
                    <%--<img src="../Images/acceso_denegado.PNG" class="auto-style1" />--%>
                </div>
                <div class="col-md-7">
                    <br />
                    <br />
                    <br />
                    <br />
                    <h1>
                        <p class="font-weight-bold blue-grey-text">ACCESO</p>
                        <h1></h1>
                        <h1>
                            <p class="font-weight-bold blue-grey-text">
                                DENEGADO
                            </p>
                            <h1></h1>
                        </h1>
                    </h1>
                </div>
            </div>
        </div>
        <br />
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>
    --%>
</asp:Content>
