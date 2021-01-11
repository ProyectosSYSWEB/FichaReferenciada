<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_P5.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript" type="text/javascript">
        function PagBancomer() {
            $('#<%= mp_account.ClientID %>').attr("name", "mp_account");
            $('#<%= mp_product.ClientID %>').attr("name", "mp_product");
            $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
            $('#<%= mp_reference.ClientID %>').attr("name", "mp_reference");
            $('#<%= mp_node.ClientID %>').attr("name", "mp_node");
            $('#<%= mp_concept.ClientID %>').attr("name", "mp_concept");
            $('#<%= mp_order.ClientID %>').attr("name", "mp_order");
            $('#<%= mp_amount.ClientID %>').attr("name", "mp_amount");
            $('#<%= mp_customername.ClientID %>').attr("name", "mp_customername");
            $('#<%= mp_currency.ClientID %>').attr("name", "mp_currency");
            $('#<%= mp_signature.ClientID %>').attr("name", "mp_signature");
            $('#<%= mp_urlsuccess.ClientID%>').attr("name", "mp_urlsuccess");
            $('#<%= mp_urlfailure.ClientID %>').attr("name", "mp_urlfailure");
            //document.getElementById("form1").action = "//mgg.unach.mx/pruebas_bancomer.php"; //Setting form action to "success.php" page        
            //document.getElementById("form1").action = "ttps://prepro.adquiracloud.mx/clb/endpoint/unach/";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').action = "https://www.adquiramexico.com.mx/clb/endpoint/unach/";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').method = "POST";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').submit();
        }
    </script>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 98;
            top: 0px;
            left: 0px;
            right: 0px;
            bottom: 0px;
            background-color: #aaa;
            filter: alpha(opacity=80);
            opacity: 0.8;
        }

        .overlayContent {
            z-index: 99;
            margin: 250px auto;
            width: 80px;
            height: 80px;
        }

            .overlayContent h2 {
                font-size: 18px;
                font-weight: bold;
                color: #000;
            }

            .overlayContent img {
                width: 30px;
                height: 30px;
            }

        .auto-style1 {
            width: 110px;
            height: 45px;
        }

        .auto-style2 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 83.333333%;
            flex: 0 0 83.333333%;
            max-width: 83.333333%;
            left: -11px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col text-center">
                <img src="https://sysweb.unach.mx/resources/imagenes/Paso4.png" class="img-responsive" alt="Responsive image" />
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col text-center">
                <asp:Button ID="btnPago" runat="server" CssClass="btn btn-blue-grey" Text="Nueva Referencia" OnClick="btnPago_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:Label ID="lblMsj" runat="server" Style="text-align: center" Font-Bold="True" ForeColor="#3166A2"></asp:Label>
            </div>
        </div>
        <asp:Panel ID="pnlDatos" runat="server">
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
                <div class="row">
                    <div class="col-md-11">
                        <asp:RadioButtonList ID="rbtFormaPago" runat="server" RepeatDirection="Horizontal" Width="100%" Height="105px" CssClass="font-weight-bold" Font-Bold="True">
                            <asp:ListItem Value="1" Selected="True">Efectivo   <img src="../Images/efectivo.png"  /></asp:ListItem>
                            <asp:ListItem Value="2">Pago con tarjeta de Crédito  <img src="https://sysweb.unach.mx/resources/imagenes/visa-master.png"  /></asp:ListItem>
                            <asp:ListItem Value="3">Pago con tarjeta de Débito  <img src="https://sysweb.unach.mx/resources/imagenes/visa-master.png"  /></asp:ListItem>
                            <asp:ListItem Value="4">Cargo a Cuenta Bancaria (48 hrs)</asp:ListItem>
                            <asp:ListItem Value="5">CIE Interbancario</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:HiddenField ID="hddnObservaciones" runat="server" />
                        <asp:HiddenField ID="hddnConceptos" runat="server" />
                    </div>
                    <div class="col-md-1">
                        <button type="button" class="btn-floating btn-primary" style="border-color: #4285f4;border-style: solid;" data-toggle="modal" data-target="#exampleModal" data-whatever="@mdo"><i class="fa fa-question-circle" aria-hidden="true"></i>
</i></button>

                    </div>
                </div>
                <div class="row">
                    <div class="col" id="divMensajeEventos" runat="server" visible="false">
                        <div class="card text-white bg-info mb-3" style="max-width: 20rem;">
                            <div class="card-header">Comprobante Oficial</div>
                            <div class="card-body">
                                <p class="card-text text-white">
                                    Ingresar a https://sysweb.unach.mx/ingresos/, en
                                <div class="font-weight-bold">REFERENCIA BANCARIA</div>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                </p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </asp:Panel>
        <asp:Panel ID="pnlCorreo" runat="server" CssClass="card text-white bg-dark mb-3" Width="45%">
            <table width="100%">
                <tr>
                    <td class="auto-style1" colspan="3">
                        <div class="titulo_pop">
                            Enviar Ficha Referenciada
                        </div>
                        <div>
                            <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblMensajeCorreo" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top" width="33%">
                        <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" valign="top" width="67%">
                        <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCorreo" runat="server" Width="90%"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCorreo" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="correo"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td align="left" valign="top" width="67%"></td>
                </tr>
                <tr>
                    <td align="center" class="auto-style1" colspan="3">
                        <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel37">
                            <ProgressTemplate>
                                <div class="overlay">
                                    <div class="overlayContent">
                                        <asp:Image ID="Image13" runat="server" Height="100px" ImageUrl="~/Images/loader2.gif" Width="100px" />
                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="bttnCorreo" runat="server" CssClass="btn btn-info" OnClick="bttnCorreo_Click" Text="Enviar" ValidationGroup="correo" />
                                &nbsp;<asp:Button ID="bttnCancelarCorreo" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnCancelarCorreo_Click" Text="Salir" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td width="33%">&nbsp;</td>
                    <td width="67%">&nbsp;</td>
                    <td width="67%">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:CheckBox ID="chkCorreo" runat="server" Text="¿Enviar referencia al correo?" OnCheckedChanged="chkCorreo_CheckedChanged" Visible="False" AutoPostBack="True" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <ajaxToolkit:ModalPopupExtender ID="modalCorreo" runat="server" BackgroundCssClass="modalBackground_Proy" TargetControlID="hddnModal" PopupControlID="pnlCorreo">
        </ajaxToolkit:ModalPopupExtender>
        <asp:HiddenField ID="hddnModal" runat="server" />
        <div class="contenedor_botones" align="center">
            <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior"
                OnClick="btnAnterior_Click" />
            &nbsp;<asp:Button ID="btnImprimir" runat="server" CssClass="btn btn-secondary"
                Text="1" OnClick="btnImprimir_Click" Visible="False" />
            &nbsp;<asp:Button ID="btnPagoBancomer" runat="server"
                CssClass="btn btn-secondary" OnClick="btnPagoBancomer_Click"
                Text="2" Visible="False" />

            &nbsp;<asp:Button ID="btnForma_Pago" runat="server" CssClass="btn" style="background-color:#d2af47; color:#fff" Text="Siguiente"
                OnClick="btnForma_Pago_Click" />
            <br />

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
            <br />

        </div>
        <iframe id="Iframe1" runat="server" frameborder="0" marginheight="0" marginwidth="0"
            name="miniContenedor" style="height: 500px" width="100%"></iframe>
        <br />
        <br />

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
        <form>
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
        </form>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-light" data-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
    </div>
</asp:Content>
