<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_P8.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .overlay  
        {
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
        .overlayContent
        {
          z-index: 99;
          margin: 250px auto;
          width: 80px;
          height: 80px;
        }
        .overlayContent h2
        {
            font-size: 18px;
            font-weight: bold;
            color: #000;
        }
        .overlayContent img
        {
          width: 30px;
          height: 30px;
        }
        .auto-style1 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 58.333333333333336%;
            left: 0px;
            top: 0px;
            padding-left: 5px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="titulo" align="left">
        <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="VINCULACIÓN DE REFERENCIA"></asp:Label>
        <br />
         <div align="center">
     <br /><asp:Button ID="btnLimpiar"  runat="server" CssClass="btn btn-primary bt-xs"
                Text="Limpiar Registro" OnClick="btnLimpiar_Click" /></div>
        <asp:Label ID="lblMsj" runat="server" Style="text-align: center" Font-Bold="True"
            ForeColor="#3166A2"></asp:Label>
            <br />
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="lblTerminal" runat="server" Text="Terminal"></asp:Label>
            </div>
            <div class="col-md-7">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblTerminal_l" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="container" >
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblConvenio" runat="server" Text="Convenio"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblConvenio_l" runat="server" CssClass="letra_movil"></asp:Label>
                </div>
            </div>
        </div>
    <div class="container" >
            <div class="row">
                <div class="col-md-4">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                </div>
                <div class="auto-style1">
                    <asp:Label ID="lblFecha_l" runat="server" CssClass="letra_movil"></asp:Label>
                </div>
            </div>
        </div>
    <div class="container" >
            <div class="row">
                <div class="col-md-4" >
                    <asp:Label ID="lblReferencia" runat="server" Text="Referencia" ></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblReferencia_l1" runat="server" CssClass="letra_movil"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container" >
            <div class="row" >
                <div class="col-md-4" >
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" ></asp:Label>
                </div>
                <div class="col-md-7" >
                    <asp:Label ID="lblNombre_l" runat="server" CssClass="letra_movil"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container" >
            <div class="row" >
                <div class="col-md-4" >
                    <asp:Label ID="lblImporte" runat="server" Text="Importe" ></asp:Label>
                </div>
                <div class="col-md-7" >
                    <asp:Label ID="lblImporte_l" runat="server" CssClass="letra_movil"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container" >
            <div class="row" >
                <div class="col-md-4" >
                    <asp:Label ID="lblNotas" runat="server" Text="Notas" ></asp:Label>
                </div>
                <div class="col-md-7" >
                    <asp:Label ID="lblNotas_l" runat="server" CssClass="letra_movil"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container" >
            <div class="row" >
                <div class="col-md-4" >
                    <asp:Label ID="lblBanco" runat="server" Text="Banco" ></asp:Label>
                </div>
                <div class="col-md-7" >
                    <asp:DropDownList ID="ddlBanco" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="container" >
                <div class="row" >
                    <div class="col-md-4" >
                        <asp:Label ID="lblTipoTarjeta" runat="server" Text="Tarjeta" ></asp:Label>
                    </div>
                    <div class="col-md-7" >
                        <asp:DropDownList ID="ddlTipoTarjeta" runat="server">
                            <asp:ListItem Value="D">DEBITO</asp:ListItem>
                            <asp:ListItem Value="C">CREDITO</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
        </div>
    <div  class="container">
        <div  class="row">
            <div  class="col-md-4">
                <asp:Label ID="lblNumTarjeta" runat="server" Text="Últimos 4 Dígitos de la Tarjeta" Width="200px"></asp:Label>
            </div>
            <div  class="col-md-7">
                <asp:TextBox ID="txtNumTarjeta" runat="server" MaxLength="4"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVNumTarjeta" runat="server" ControlToValidate="txtNumTarjeta" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="validaCampos">*Requerido</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator103" runat="server" ControlToValidate="txtNumTarjeta" ErrorMessage="*Solo Números" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d+" ValidationGroup="Poliza"></asp:RegularExpressionValidator>
            </div>
        </div>
    </div>
    <div class="container" >
            <div class="row" >
                <div class="col-md-4">
                    <asp:Label ID="lblNumAutorizacion" runat="server" Text="Número de Autorización" Width="200px"></asp:Label>
                </div>
                <div class="col-md-7" >
                    <asp:TextBox ID="txtNumAutorizacion" runat="server" MaxLength="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVNumAutorizacion" runat="server" ControlToValidate="txtNumAutorizacion" ErrorMessage="RequiredFieldValidator" ForeColor="Red" ValidationGroup="validaCampos">*Requerido</asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator104" runat="server" ControlToValidate="txtNumAutorizacion" ErrorMessage="*Solo Números" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\d+" ValidationGroup="Poliza"></asp:RegularExpressionValidator>
                </div>
            </div>
        </div>
    <div class="container" >
            <div class="row" >
                <div class="col-md-12" >
                    <asp:Label ID="lblNota" runat="server" Text="El recibo emitido estará sujeto a validación por parte del Departamento de Finanzas, el día que haga la conciliación con la institución bancaria; de no proceder este pago se deberá cancelar y tendrá que hacer las aclaraciones correspondientes con las autoridades de finanzas." Width="90%" Height="100%"></asp:Label>
                </div>
            </div>
    </div>
    <br />
    <br />
    <div align="center">
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
            <ProgressTemplate>
                <div class="overlay">
                <div class="overlayContent">
                <asp:Image ID="Image13" runat="server" Height="19px" ImageUrl="~/Images/loader.gif" Width="220px" />
                </div>
               </div>
            </ProgressTemplate>
        </asp:UpdateProgress>                
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate> 
                <div class="contenedor_botones" align="center">
                    <asp:Button ID="btnAceptar" runat="server" Text="Imprimir Recibo" CssClass="btn btn-primary bt-xs" OnClick="btnAceptar_Click" ValidationGroup="validaCampos" CausesValidation="true"  OnClientClick="return validate();" />                
                    <script type="text/javascript" language="javascript" >
                        function validate() {
                            if (Page_ClientValidate())
                            return confirm('¿Los datos son correctos?');
                        }
                    </script> 
                    &nbsp;<iframe id="Iframe1" runat="server" frameborder="0" marginheight="0" marginwidth="0" name="miniContenedor" style="height: 500px" width="100%"></iframe>               
            </ContentTemplate>
        </asp:UpdatePanel>                
    </div>           
</asp:Content>
