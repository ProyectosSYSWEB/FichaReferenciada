<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true" CodeBehind="Registro_Participantes_Extra.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_Extra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <br />
        <div class="row">
            <div class="col">
                <asp:Panel ID="pnlExtras" runat="server" ScrollBars="Vertical" Height="450px">
                    <p class="note note-warning">
                        <strong>
                            <asp:Label ID="lblTitulo0" runat="server" Text="INFORMACIÓN ADICIONAL"></asp:Label>
                        </strong>
                    </p>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:ValidationSummary ID="valCamposExtras" CssClass="alert alert-danger" runat="server" ValidationGroup="next" HeaderText="Estos campos son requeridos:" />
            </div>
            <div class="col-md-4 text-center">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior" OnClick="btnAnterior_Click" />
                        &nbsp;<asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente"
                            OnClick="btnSiguiente_Click" ValidationGroup="next" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
</asp:Content>
