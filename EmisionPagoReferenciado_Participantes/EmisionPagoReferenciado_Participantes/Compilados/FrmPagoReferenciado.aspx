<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmPagoReferenciado.aspx.cs" Inherits="EmisionPagoReferenciado.FrmPagoReferenciado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Pago Referenciado</title>
    <link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
     <link href="Styles/media-queries.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/grid.css" rel="stylesheet" type="text/css" />
    <link href="~/dist/css/bootstrap.css" rel="stylesheet" />    
    <script src="Scripts/Reportes.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
       <div class="header">
			
			<div class="nombre_sistema label-dorado" >SISTEMAS ADMINISTRATIVOS EN LINE@</div>                        
        </div>
             <div align="left">
                 <br />
                 <br />
        <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="FICHA REFERENCIADA"></asp:Label>
                 <br />
                 <br />
        <asp:Label ID="lblMsj" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
    </div>
    <asp:Panel ID="pnlDatos" runat="server">
      <div class="bancos alert alert-danger">
            Para realizar el pago presentar en el banco la referencia y el importe.
        </div>
        <div class="bancos">
            <img src="Images/bancos.png" class="img-responsive" alt="Responsive image" />                    
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" Width="100px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblNombre_l" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblReferencia" runat="server" Text="Referencia" Width="100px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblReferencia_l" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblImporte" runat="server" Text="Importe" Width="100px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblImporte_l" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblVigencia" runat="server" Text="Vigencia" Width="100px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblVigencia_l" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <asp:Label ID="lblConcepto" runat="server" Text="Concepto" Width="100px"></asp:Label>
                </div>
                <div class="col-md-7">
                    <asp:Label ID="lblConcepto_l" runat="server" Height="100%" Width="100%"></asp:Label>
                </div>
            </div>
        </div>
    </asp:Panel>
  
    <div class="contenedor_botones" align="center">      
        &nbsp;<asp:Button ID="btnImprime_Ficha" runat="server" CssClass="btn btn-primary bt-xs"
            Text="Imprimir Ficha" OnClick="btnImprime_Ficha_Click" />
        &nbsp;
    </div>
 
  
    </form>
</body>
</html>
