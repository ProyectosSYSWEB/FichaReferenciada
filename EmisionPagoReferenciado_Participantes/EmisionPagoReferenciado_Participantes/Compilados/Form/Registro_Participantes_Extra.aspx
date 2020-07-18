<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_Extra.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_Extra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 50%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
<div class="container">
    <div class="content_main">
        <div class="panel panel-default">
  <div class="panel-heading">
    <h3 class="panel-title"><asp:Label ID="lblEvento"  runat="server"></asp:Label>
            INFORMACIÓN EXTRA PARA EL EVENTO</h3>
  </div>
  <div class="panel-body">
      <asp:Panel ID="pnlExtras" runat="server">

    <asp:PlaceHolder ID="placeHolderDin" runat="server"></asp:PlaceHolder>
    <div align="center">
        <div class="row">
            <div class="auto-style1">
                <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-secondary" Text="Anterior" OnClick="btnAnterior_Click" />
                <br />
            </div>
            <div class="auto-style1">
                <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente" OnClick="btnSiguiente_Click" />
            </div>
        </div>
        </div>
          </asp:Panel>
    </div>
    </div>
    </div>
</div>
</asp:Content>
