<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_P5.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .btn {
            display: inline-block;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            cursor: pointer;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }


        .btn-app {
            color: white;
            box-shadow: none;
            border-radius: 3px;
            position: relative;
            padding: 10px 15px;
            margin: 0;
            min-width: 40px;
            /*max-width: 60px;*/
            text-align: center;
            border: 1px solid #ddd;
            background-color: #f4f4f4;
            font-size: 10px;
            transition: all .2s;
            background-color: steelblue !important;
        }

            .btn-app > .fa, .btn-app > .glyphicon, .btn-app > .ion {
                font-size: 20px;
                display: block;
            }

            .btn-app:hover {
                border-color: #aaa;
                transform: scale(1.1);
            }

        .pdf {
            background-color: #5e5e5e !important;
            /*background-color: #dc2f2f !important;*/
        }

        .excel {
            background-color: #3ca23c !important;
        }

        .csv {
            background-color: #ffc107 !important;
        }

        .imprimir {
            background-color: #8766b1 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hddnModal" runat="server" />
    <asp:HiddenField ID="mp_account" runat="server" Value="MPACCO" />
    <asp:HiddenField ID="mp_product" runat="server" Value="mpproduct" />
    <asp:HiddenField ID="mp_order" runat="server" Value="mporder" />
    <asp:HiddenField ID="mp_reference" runat="server" Value="mpreference" />
    <asp:HiddenField ID="mp_node" runat="server" Value="mpnode" />
    <asp:HiddenField ID="mp_concept" runat="server" Value="mpconcept" />
    <asp:HiddenField ID="mp_amount" runat="server" Value="mpamount" />
    <asp:HiddenField ID="mp_customername" runat="server" Value="mpcustomername" />
    <asp:HiddenField ID="mp_currency" runat="server" />
    <asp:HiddenField ID="mp_signature" runat="server" />
    <asp:HiddenField ID="mp_urlsuccess" runat="server" />
    <asp:HiddenField ID="mp_urlfailure" runat="server" />
    <div class="container-fluid">
        <div class="row d-none d-sm-none d-md-block">
            <div class="col">
                <ul class="stepper stepper-horizontal">
                    <!-- First Step -->
                    <li class="disabled">
                        <a href="#!">
                            <span class="circle">1</span>
                            <span class="label">Usuario</span>
                        </a>
                    </li>

                    <!-- Second Step -->
                    <li class="disabled">
                        <a href="#!">
                            <span class="circle">2</span>
                            <span class="label">Servicios</span>
                        </a>
                    </li>

                    <!-- Third Step -->
                    <%-- <li class="disabled">
                        <a href="#!">
                            <span class="circle">3</span>
                            <span class="label">Comprobante Fiscal</span>
                        </a>
                    </li>--%>

                    <li class="active">
                        <a href="#!">
                            <span class="circle"><i class="fa fa-credit-card" aria-hidden="true"></i></span>
                            <span class="label" style="color: #5f5f5f">Método de Pago</span>
                        </a>
                    </li>

                </ul>
            </div>
        </div>
        <div class="row  d-md-none">
            <ul class="nav nav-tabs step-anchor">
                <li class="nav-item disabled"><a href="" class="nav-link">Paso 1<br>
                    <small>Usuario</small></a></li>
                <li class="nav-item disabled"><a href="" class="nav-link">Paso 2<br>
                    <small>Servicios</small></a></li>
                <li class="nav-item active font-weight-bold" style="background-color: #d2d2d2"><a href="" class="nav-link">Paso 3<br>
                    <small>Método de Pago</small></a></li>
            </ul>
        </div>
    </div>
    <div class="container-fluid d-block d-sm-block d-md-none">
        <div class="row">
            <div class="col alert alert-warning">
                Para realizar el pago presentar en el banco la referencia y el importe.            
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <img src="../Images/bancos.png" class="img-responsive" alt="Responsive image" />
            </div>
        </div>
    </div>
    <div class="container-fluid" id="divDatosPago" runat="server">
        <div class="row">
            <div class="col text-center">
                <asp:Label ID="lblMsj" runat="server" Style="text-align: center" Font-Bold="True" ForeColor="#3166A2"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 font-weight-bold">Datos de la Referencia</div>
            <div class="col-md-2">
                <asp:Button ID="btnPago" runat="server" CssClass="btn btn-blue-grey" Text="Nueva Referencia" OnClick="btnPago_Click" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:Label ID="lblNombre_l" runat="server" CssClass="form-control" ForeColor="#5d5d62"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                Referencia
            </div>
            <div class="col-md-4">
                <asp:Label ID="lblReferencia_l" runat="server" CssClass="form-control text-dark font-weight-bold"></asp:Label>
            </div>
            <div class="col-md-1">
                Importe
            </div>
            <div class="col-md-3">
                <div class="input-group">
                    <asp:Label ID="lblImporte_l" runat="server" CssClass="form-control text-dark font-weight-bold"></asp:Label>
                    <div class="input-group-append">
                        <span class="input-group-text" id="basic-addon2">MXN</span>
                    </div>
                </div>
            </div>
            <div class="col-md-1">
                Vigencia
            </div>
            <div class="col-md-2">
                <asp:Label ID="lblVigencia_l" runat="server" CssClass="form-control text-dark font-weight-bold"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-1">
                <asp:Label ID="lblConcepto" runat="server" Text="Concepto"></asp:Label>
            </div>
            <div class="col-md-11">
                <asp:Label ID="lblConcepto_l" runat="server" CssClass="form-control text-dark" Height="100%" Width="100%"></asp:Label>
            </div>
        </div>
        <br />
        <div class="row" id="divGenLink" runat="server">
            <div class="col-md-1">
                Generar link
            </div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="linkGen" runat="server" Width="100%" CssClass="btn btn-primary" Text="Agregar" OnClick="linkGen_Click"><i class="fa fa-credit-card" aria-hidden="true"></i> Pago en linea
                        </asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-9">
                <asp:UpdatePanel ID="updPnlPagoo" runat="server">
                    <ContentTemplate>
                        <asp:HyperLink ID="linkPago" runat="server"></asp:HyperLink>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class=" alert alert-warning">
                    <asp:Label ID="lblTextformpago" runat="server" Text="Todas las transacciones son seguras y encriptadas. La información de tu tarjeta de crédito o débito nunca es almacenada."></asp:Label>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblInfFormaPago" runat="server" Text="Label"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgrFormaPago" runat="server"
                    AssociatedUpdatePanelID="updPnlFormaPago">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="Image2q" runat="server"
                                    AlternateText="Espere un momento, por favor.." Height="30px"
                                    ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                    ToolTip="Espere un momento, por favor.." Width="30px" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col font-weight-bold">Formas de Pago</div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updPgrFormasPago" runat="server" AssociatedUpdatePanelID="updPnlFormaPago">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="imgFormasPago" runat="server" ImageUrl="~/images/loader2.gif" Height="100px" Width="100px" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row text-center">
            <div class="col">
                <asp:UpdatePanel ID="updPnlFormaPago" runat="server">
                    <ContentTemplate>
                        <div class="text-center">
                            <asp:RadioButtonList ID="rbtFormaPago" runat="server" OnSelectedIndexChanged="rbtFormaPago_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1"><img src="~/Images/p_efectivo.png"  /></asp:ListItem>
                                <asp:ListItem Value="2">Pago con tarjeta de Crédito  <img src="https://sysweb.unach.mx/resources/imagenes/visa-master.png"  /></asp:ListItem>
                                <asp:ListItem Value="3">Pago con tarjeta de Débito  <img src="https://sysweb.unach.mx/resources/imagenes/visa-master.png"  /></asp:ListItem>
                                <asp:ListItem Value="4">Cargo a Cuenta Bancaria (48 hrs)</asp:ListItem>
                                <asp:ListItem Value="5">CIE Interbancario</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:HiddenField ID="hddnObservaciones" runat="server" />
                <asp:HiddenField ID="hddnConceptos" runat="server" />
            </div>
        </div>
        <hr />

    </div>

    <div class="container-fluid" id="divRep" runat="server">
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="chkCorreo" runat="server" Text="¿Enviar referencia al correo?" OnCheckedChanged="chkCorreo_CheckedChanged" Visible="False" AutoPostBack="True" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <iframe id="Iframe1" runat="server" frameborder="0" marginheight="0" marginwidth="0"
                    name="miniContenedor" style="height: 500px; width: 100%"></iframe>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row text-center">
            <div class="col">
                <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior"
                    OnClick="btnAnterior_Click" />
                &nbsp;<asp:Button ID="btnImprimir" runat="server" CssClass="btn btn-secondary"
                    Text="1" OnClick="btnImprimir_Click" Visible="False" />
                &nbsp;<asp:Button ID="btnPagoBancomer" runat="server"
                    CssClass="btn btn-secondary" OnClick="btnPagoBancomer_Click"
                    Text="2" Visible="False" />
                &nbsp;<asp:Button ID="btnForma_Pago" runat="server" CssClass="btn" Style="background-color: #d2af47; color: #fff" Text="Siguiente"
                    OnClick="btnForma_Pago_Click" />
            </div>
        </div>
    </div>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ayuda</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body text-center">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Cargo a cuenta bancaria</label>
                        <br />
                        <a href="https://sysweb.unach.mx/resources/Ayuda/MANUAL_PAGO_CLABE_INTERBANCARIA.pdf" target="_blank">Ver Manual</a>

                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">CIE</label>
                        <br />
                        <a href="https://sysweb.unach.mx/resources/Ayuda/MANUAL_PAGO_CIE.pdf" target="_blank">Manual</a>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="myModal" class="modal fade">
        <div class="modal-dialog modal-login">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Información</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblInformacion" runat="server" Text="Label"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalCorreo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalCorreoLabel">Enviar Ficha Referenciada</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMensajeCorreo" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                Correo
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCorreo" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="correo"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel37">
                                    <ProgressTemplate>
                                        <div class="overlay">
                                            <div class="overlayContent">
                                                <asp:Image ID="Image13" runat="server" Height="100px" ImageUrl="~/Images/loader2.gif" Width="100px" />
                                            </div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="bttnCorreo" runat="server" CssClass="btn btn-info" OnClick="bttnCorreo_Click" Text="Enviar" ValidationGroup="correo" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalError">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Error</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblError" runat="server" Text="--"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary">Save changes</button>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalFormaPago">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Aviso</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <asp:UpdatePanel ID="UpdatePanel7" runat="server">
              <ContentTemplate>
                  <asp:Label ID="lblMsjFP" runat="server" Text="--"></asp:Label>
              </ContentTemplate>
          </asp:UpdatePanel>
      </div>
      <div class="modal-footer">
          <asp:UpdatePanel ID="UpdatePanel8" runat="server">
              <ContentTemplate>
                  <asp:LinkButton ID="linkBttnPagar" CssClass="btn btn-primary" runat="server" OnClick="linkBttnPagar_Click">Pagar</asp:LinkButton>
              </ContentTemplate>
          </asp:UpdatePanel>
        <button type="button" class="btn btn-grey" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
    <script src="../Scripts/jFormasPago.js"></script>
    <%--<script language="javascript" type="text/javascript">


    </script>--%>
</asp:Content>


