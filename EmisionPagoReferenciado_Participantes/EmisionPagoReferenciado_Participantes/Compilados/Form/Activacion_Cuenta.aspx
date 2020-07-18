<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activacion_Cuenta.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Activacion_Cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <asp:Panel ID="pnlMsjReg" runat="server">
                        <div class="mensaje_rojo" role="alert">
                            <asp:Label ID="lblMsjError" runat="server"></asp:Label>
                        </div>                        
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="lblMsjActivacion" runat="server" Width="100%"></asp:Label>
                </div>                
            </div>
        </div></p>
    
</asp:Content>
