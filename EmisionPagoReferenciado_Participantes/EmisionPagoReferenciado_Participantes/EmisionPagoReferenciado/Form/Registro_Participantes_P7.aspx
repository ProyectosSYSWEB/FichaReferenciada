<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_P7.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: left;
            width: 46%;
        }
        .style2
        {
            width: 46%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
            Text="Limpiar Registro" OnClick="btnPago_Click" />
        </div>           
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
