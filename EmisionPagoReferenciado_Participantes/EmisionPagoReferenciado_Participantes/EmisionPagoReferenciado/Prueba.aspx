﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="EmisionPagoReferenciado.Prueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        LISS<asp:ScriptManager 
            ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                  <div class="pasos">
                <img src="../Images/Paso5.png" class="img-responsive" alt="Responsive image" />
            </div>
            <div class="titulo" align="left">
                <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="PAGO CON TARJETA"></asp:Label>
            </div>
            <br />
            <br />
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblEtReference" runat="server" Text="Referencia" Width="100px"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblReference" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblEtAmount" runat="server" Text="Importe" Width="100px"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="contenedor_botones" align="center">
                <asp:Label ID="lblMsj" runat="server" Text="Label" Font-Bold="True" ForeColor="Maroon"></asp:Label>
            </div>
            <div align="center">
                <br />
                <asp:Button ID="btnPago"  runat="server" CssClass="btn btn-primary bt-xs"
            Text="Limpiar Registro"/>
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
