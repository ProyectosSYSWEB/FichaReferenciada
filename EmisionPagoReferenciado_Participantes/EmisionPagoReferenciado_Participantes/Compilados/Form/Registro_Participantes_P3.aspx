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
<div class="container">
    <div class="row">
        <div class="col-md-10 text-center">
            <img src="https://sysweb.unach.mx/resources/imagenes/Paso3.png" class="img-responsive" alt="Responsive image" />
        </div>
    </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <h4><asp:Label ID="lblEvento"  runat="server"></asp:Label></h4>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div> 
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label1" runat="server" Text="¿Desea factura con valor fiscal?" style="padding-left:40px;"></asp:Label>
            </div>
            <div class="col-md-8">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:RadioButtonList ID="rdoBttnFactFis" runat="server" CssClass="custom-control custom-radio" AutoPostBack="True" 
                            onselectedindexchanged="rdoBttnFactFis_SelectedIndexChanged" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="N">No&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Value="S">Si</asp:ListItem>
                        </asp:RadioButtonList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            
        </div>
    </div>       
    <div>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>                
    </div>      
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>   
    <asp:Panel ID="pnlDatos" runat="server" Visible="False">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="alert alert-info">                
                    Favor de proporcionar los datos fiscales correctos para la elaboración de la factura, <strong> ya que con la reforma del SAT no habrá cancelación de facturas.</strong> Por ser una institución pública SIN FINES DE LUCRO, no retiene IVA
                <br />
                </div>
            </div>        
        </div>
    </div>
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblTipoPersonaFiscal" runat="server" Text="Persona"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList ID="rdoBttnTipoPersonaFiscal" runat="server" CssClass="form-control" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdoBttnTipoPersonaFiscal_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="F">Fisica&nbsp;&nbsp;</asp:ListItem>
                            <asp:ListItem Selected="True" Value="M">Moral</asp:ListItem>
                    </asp:RadioButtonList>
                        </ContentTemplate>
                    </asp:UpdatePanel>    
                    </div>
                
                <div class="col-md-1">
                    <asp:Label ID="lblRFC" runat="server" Text="R.F.C."></asp:Label>
                </div>
                <div class="col-md-5">
                    <asp:TextBox ID="txtRFC" runat="server" CssClass="form-control" MaxLength="12" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valRFC" runat="server" ControlToValidate="txtRFC" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="txtRazon_Social" runat="server" CssClass="form-control" MaxLength="500" TabIndex="2"></asp:TextBox>
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
                    <asp:TextBox ID="txtCalle_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtCalle_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                </div>
            
                <div class="col-md-1">
                    <asp:Label ID="lblColonia_Fiscal" runat="server" Text="Colonia"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtColonia_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtColonia_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
           
                <div class="col-md-2">
                    <asp:Label ID="lblEstado_Fiscal" runat="server" Text="Estado"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlEstado_Fiscal" runat="server" CssClass="custom-select" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="5">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valEstado_Fiscal" runat="server" ControlToValidate="ddlEstado_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
           
                <div class="col-md-2">
                    <asp:Label ID="lblMunicipio_Fiscal" runat="server" Text="Municipio" TabIndex="6"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlMunicipio_Fiscal" runat="server" CssClass="custom-select" TabIndex="7"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valMunicipio_Fiscal" runat="server" ControlToValidate="ddlMunicipio_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                                <div class="col-md-2">
                    <asp:Label ID="lblCP_Fiscal" runat="server" Text="Código Postal"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtCP_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtCP_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-2">
                    <asp:Label ID="lblMetodoPago" runat="server" Text="Metodo de Pago"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="custom-select" TabIndex="9">
                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                        <asp:ListItem Value="01">Efectivo</asp:ListItem>
                        <asp:ListItem Value="02">Cheque Nominativo</asp:ListItem>
                        <asp:ListItem Value="03">Transferencia Electrónica de Fondos</asp:ListItem>
                        <asp:ListItem Value="04">Tarjeta de Crédito</asp:ListItem>
                        <asp:ListItem Value="05">Monedero Electrónico</asp:ListItem>
                        <asp:ListItem Value="06">Dinero Electrónico</asp:ListItem>
                        <asp:ListItem Value="08">Vales de Despensa</asp:ListItem>
                        <asp:ListItem Value="28">Tarjeta de Débito</asp:ListItem>
                        <asp:ListItem Value="29">Tarjeta de Servicio</asp:ListItem>
                        <asp:ListItem Value="99">Otro</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlMetodoPago" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblTelefono_Fiscal" runat="server" Text="Teléfono"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtTelefono_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="10"></asp:TextBox>
                </div>
           
        
                <div class="col-md-2">
                    <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico"></asp:Label>
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="txtCorreo_Fiscal" runat="server" CssClass="form-control" MaxLength="500" TabIndex="11"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valCorreo_Fiscal" runat="server" ControlToValidate="txtCorreo_Fiscal" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col">
                    <div class="alert alert-warning">
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:CheckBox ID="chkValidado" runat="server" Font-Bold="False" CssClass="alert alert-warning" Text=" * Estás de acuerdo que los datos capturados son correctos y serán utilizados para utilizar la factura correspondiente." ValidationGroup="DatosFiscales" />
                                &nbsp; <asp:CustomValidator ID="valCheck" runat="server" ErrorMessage="*Requerido" ClientValidationFunction = "ValidateCheckBox" ForeColor="Red" ValidationGroup="DatosFiscales"></asp:CustomValidator><br />
                            </ContentTemplate>
                        </asp:UpdatePanel>                             
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>
     </ContentTemplate>
                </asp:UpdatePanel>
    <div align="center">
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="height: 36px">
                    <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior"
                        OnClick="btnAnterior_Click" />
                    <br />
                </div>
                <div class="col-md-6">
                    <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente"
                        OnClick="btnSiguiente_Click" TabIndex="10" ValidationGroup="DatosFiscales" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
