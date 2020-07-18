<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registro_Participantes_P2.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P2" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
        <div class="container">
            <div class="row">
                <div class="col text-center">
                    <img src="https://sysweb.unach.mx/resources/imagenes/paso2.PNG" class="img-responsive" alt="Responsive image" />
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col text-dark">
                    <%--<p class="note note-warning"><strong>--%>
                    <h5>
                    <asp:Label ID="lblEvento"  runat="server" Text=""></asp:Label>
                        </h5>
                    <%--</strong></p>--%>
                </div>
            </div>
        </div>         

            <div style="position:fixed; right:50px; bottom:10px; background-color:#fff; border-radius: 13px 13px 13px 13px;
-moz-border-radius: 13px 13px 13px 13px;
-webkit-border-radius: 13px 13px 13px 13px;
border: 0px solid #000000; padding:10px;"
                -webkit-box-shadow: 0px 0px 6px 3px rgba(150,142,150,1);
-moz-box-shadow: 0px 0px 6px 3px rgba(150,142,150,1);
box-shadow: 0px 0px 6px 3px rgba(150,142,150,1);

                >
                <asp:Label ID="lblCostoMat0" runat="server" Text="Total:  " Font-Bold="True" Font-Size="30px"></asp:Label>
                <asp:Label ID="lblImporteTotal" runat="server" Font-Bold="True" ForeColor="#3483fa"
                   Font-Size="30px">0.00</asp:Label>
                <b>MXN</b>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-sm-9">
                        <p class="note note-warning"><strong>
                        <asp:Label ID="lblTitulo0" runat="server" Text="CONCEPTOS DE PAGO"></asp:Label></strong></p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-9">
                        <asp:ListBox ID="lstMaterias_Disponibles" CssClass="custom-select" runat="server" Height="200px"
                            Width="100%" OnSelectedIndexChanged="lstMaterias_Disponibles_SelectedIndexChanged"
                            AutoPostBack="True" ValidationGroup="MateriaDis"></asp:ListBox>
                        <br />
                        <div class="alert alert-info" role="alert">
                            <asp:Label ID="lblDescMatDisp" runat="server"></asp:Label>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lstMaterias_Disponibles"
                            ErrorMessage="*Seleccionar elemento de la lista" ForeColor="Red" 
                            ValidationGroup="MateriaDis" InitialValue="0"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-sm-3">
                        
                        <asp:Label ID="lblImporteAdd" runat="server" Font-Bold="True" ForeColor="#194169"
                            Text="Ingresa importe indicado por tu Facultad ó Dependencia" Visible="false"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtImporteAdd" runat="server" CausesValidation="True" Visible="false"
                            Width="100px">0</asp:TextBox><br /><br />
                        <asp:Button ID="btnAgregar_Materia" runat="server" Text="Agregar" CssClass="btn btn-blue-grey"
                            OnClick="btnAgregar_Materia_Click" ValidationGroup="MateriaDis" ToolTip="AGREGAR"/><br />
                  <asp:Label ID="lblMsj" runat="server"  ForeColor="Red" Font-Size="Small"></asp:Label>
         
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtImporteAdd"
                            ErrorMessage="*Agregar Importe" ForeColor="Red" SetFocusOnError="True" ValidationGroup="MateriaDis"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-9">
                        <asp:ListBox ID="lstMaterias_Asignadas" runat="server" CssClass="custom-select" Height="200px" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="lstMaterias_Asignadas_SelectedIndexChanged">
                        </asp:ListBox>
                        <br />
                        <div class="alert alert-info" role="alert">
                            <asp:Label ID="lblDescMatAsig" runat="server"></asp:Label>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lstMaterias_Asignadas"
                            ErrorMessage="*Seleccionar elemento de la lista" ForeColor="Red" ValidationGroup="MateriaAsig"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-3">
                        <asp:Button ID="btnEliminar_Materia" runat="server" Text="Eliminar" CssClass="btn btn-light"
                            OnClick="btnEliminar_Materia_Click" ValidationGroup="MateriaAsig" ToolTip="ELIMINAR" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Label ID="Label10" runat="server" Text="Especificar requerimientos(OPCIONAL)"></asp:Label>
                    </div>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtObservaciones2" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div align="center">
                    <div class="row">
                        <div class="auto-style1">
                            <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior"
                                OnClick="btnAnterior_Click" />
                            <br />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente"
                                OnClick="btnSiguiente_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div align="center">
        <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
            <ProgressTemplate>
                <asp:Image ID="Image13" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
    </div>
</asp:Content>
