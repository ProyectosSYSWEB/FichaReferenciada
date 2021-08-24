<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registro_Participantes_P3.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById('<%=chkValidado.ClientID %>').checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                    <li class="active">
                        <a href="#!">
                            <span class="circle"><i class="fa fa-sticky-note" aria-hidden="true"></i></span>
                            <span class="label"  style="color:#5f5f5f">Comprobante Fiscal</span>
                        </a>
                    </li>

                    <li class="disabled">
                        <a href="#!">
                            <span class="circle">4</span>
                            <span class="label">Método de Pago</span>
                        </a>
                    </li>

                </ul>
            </div>
        </div>
        <div class="row  d-md-none">
            <ul class="nav nav-tabs step-anchor">
                <li class="nav-item disabled"><a href="" class="nav-link">Paso 1<br><small>Usuario</small></a></li>
                <li class="nav-item disabled"><a href="" class="nav-link">Paso 2<br><small>Servicios</small></a></li>
                <li class="nav-item active font-weight-bold" style="background-color:#d2d2d2"><a href="" class="nav-link">Paso 3<br><small>Comprobante Fiscal</small></a></li>
                <li class="nav-item disabled"><a href="" class="nav-link">Paso 4<br><small>Método de Pago</small></a></li>
            </ul>
        </div>
        <br />
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <h4>
                            <asp:Label ID="lblEvento" runat="server"></asp:Label></h4>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                ¿Desea factura con valor fiscal?
            </div>
            <div class="col-md-8">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rdoBttnFactFis" runat="server" CssClass="custom-control custom-radio" AutoPostBack="True"
                            OnSelectedIndexChanged="rdoBttnFactFis_SelectedIndexChanged"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="N">No&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="S">Si</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlDatos" runat="server" Visible="False">
                            <div class="container">
                                <div class="row">
                                    <div class="col">
                                        <div class="note note-info" style="font-size: 14px">
                                            Favor de proporcionar los datos fiscales correctos para la elaboración de la factura, <strong>ya que con la reforma del SAT no habrá cancelación de facturas.</strong> Por ser una institución pública SIN FINES DE LUCRO, no retiene IVA
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblRFC" runat="server" Text="R.F.C."></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control" MaxLength="13" TabIndex="1" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valRFC" runat="server" ControlToValidate="txtRFC" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-1">
                                        <asp:Label ID="lblTipoPersonaFiscal" runat="server" Text="Persona"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:RadioButtonList ID="rdoBttnTipoPersonaFiscal" runat="server" onkeypress="if (event.keyCode==13) return false;" TabIndex="2" CssClass="form-control" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoBttnTipoPersonaFiscal_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="F">Fisica&nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Selected="True" Value="M">Moral</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>


                                </div>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblRazon_Social" runat="server" Text="Razón Social"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtRazon_Social" runat="server" CssClass="form-control" MaxLength="500" TabIndex="3" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valRazon_Social" runat="server" ControlToValidate="txtRazon_Social" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="container">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblCalle_Fiscal" runat="server" Text="Calle"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtCalle_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="4" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtCalle_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-1">
                                        <asp:Label ID="lblColonia_Fiscal" runat="server" Text="Colonia"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtColonia_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="5" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtColonia_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblEstado_Fiscal" runat="server" Text="Estado"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlEstado_Fiscal" runat="server" CssClass="custom-select" onkeypress="if (event.keyCode==13) return false;" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="6">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="valEstado_Fiscal" runat="server" ControlToValidate="ddlEstado_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-2">
                                        Municipio
                                    </div>
                                    <div class="col-md-3">
                                        <asp:DropDownList ID="ddlMunicipio_Fiscal" runat="server" CssClass="custom-select" TabIndex="7" onkeypress="if (event.keyCode==13) return false;"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valMunicipio_Fiscal" runat="server" ControlToValidate="ddlMunicipio_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-1">
                                        CP
                                    </div>
                                    <div class="col-md-1">
                                        <asp:TextBox ID="txtCP_Fiscal" runat="server" CssClass="form-control" TabIndex="8" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtCP_Fiscal" ForeColor="Red" ValidationGroup="DatosFiscales" Text="*Requerido"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Metodo de Pago
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="custom-select" TabIndex="9" onkeypress="if (event.keyCode==13) return false;">
                                            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                            <asp:ListItem Value="PUE">[PUE] Pago en una sola exhibicion</asp:ListItem>
                                            <asp:ListItem Value="PPD">[PPD] Pago en parcialidades o diferido</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlMetodoPago" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2">
                                        Uso de CFDI
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlCFDI" runat="server" CssClass="custom-select" TabIndex="10" onkeypress="if (event.keyCode==13) return false;">
                                            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                            <asp:ListItem Value="G01">Adquisición de mercancias</asp:ListItem>
                                            <asp:ListItem Value="G02">Devolución, descuento o bonificaciones</asp:ListItem>
                                            <asp:ListItem Value="G03">Gastos en general</asp:ListItem>
                                            <asp:ListItem Value="D04">Donativos</asp:ListItem>
                                            <asp:ListItem Value="P01">Por definir</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="valCFDI" runat="server" ControlToValidate="ddlCFDI" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblTelefono_Fiscal" runat="server" Text="Teléfono"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtTelefono_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="11" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                    </div>


                                    <div class="col-md-2">
                                        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico"></asp:Label>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:TextBox ID="txtCorreo_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="12" onkeypress="if (event.keyCode==13) return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valCorreo_Fiscal" runat="server" ControlToValidate="txtCorreo_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        Descripción
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtDescConcepto" runat="server" CssClass="form-control" MaxLength="500" TabIndex="13" onkeypress="if (event.keyCode==13) return false;" PlaceHolder="Detalle del concepto que se requiera en la factura"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="valDescConcepto" runat="server" ControlToValidate="txtDescConcepto" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col">
                                        <div class="alert alert-warning">
                                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                <ContentTemplate>
                                                    <asp:CheckBox ID="chkValidado" runat="server" Font-Bold="False" CssClass="alert alert-warning" Text=" * Estás de acuerdo que los datos capturados son correctos y serán utilizados para utilizar la factura correspondiente. " ValidationGroup="DatosFiscales" />
                                                    <asp:CustomValidator ID="valCheck" runat="server" ErrorMessage="*Requerido" ClientValidationFunction="ValidateCheckBox" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:CustomValidator><br />

                                                    <br />
                                                    <strong>NOTA:</strong> La solicitud de la factura será validada cuando este confirmado el pago (comprobante oficial).
                                                    &nbsp;
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior"
                    OnClick="btnAnterior_Click" />
                &nbsp;<asp:Button ID="btnSiguiente" runat="server" CssClass="btn" Style="background-color: #d2af47; color: #fff" Text="Siguiente"
                    OnClick="btnSiguiente_Click" TabIndex="10" ValidationGroup="DatosFiscales" />
            </div>
        </div>
    </div>
</asp:Content>
