<%@ Page Title="" Language="C#" MasterPageFile="~/Site4.Master" AutoEventWireup="true"
    CodeBehind="Registro_Participantes_P2.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes_P2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 174px;
            height: 129px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                            <li class="active">
                                <a href="#!">
                                    <span class="circle"><i class="fa fa-cog" aria-hidden="true"></i></span>
                                    <span class="label" style="color: #5f5f5f">Servicios</span>
                                </a>
                            </li>

                            <!-- Third Step -->
                            <%--<li class="disabled">
                                <a href="#!">
                                    <span class="circle">3</span>
                                    <span class="label">Comprobante Fiscal</span>
                                </a>
                            </li>--%>

                            <li class="disabled">
                                <a href="#!">
                                    <span class="circle">3</span>
                                    <span class="label">Método de Pago</span>
                                </a>
                            </li>

                        </ul>
                    </div>
                </div>
                <div class="row  d-md-none">
                    <ul class="nav nav-tabs step-anchor">
                        <li class="nav-item disabled"><a href="" class="nav-link">Paso 1<br>
                            <small>Usuario</small></a></li>
                        <li class="nav-item active font-weight-bold" style="background-color: #d2d2d2"><a href="" class="nav-link">Paso 2<br>
                            <small>Servicios</small></a></li>
                        <%--<li class="nav-item disabled"><a href="" class="nav-link">Paso 3<br>
                            <small>Comprobante Fiscal</small></a></li>--%>
                        <li class="nav-item disabled"><a href="" class="nav-link">Paso 3<br>
                            <small>Método de Pago</small></a></li>
                    </ul>
                </div>
                <div class="row">
                    <div class="col text-dark">
                        <h5>
                            <asp:Label ID="lblEvento" runat="server" Text=""></asp:Label>
                        </h5>
                    </div>
                </div>
                <div style="position: fixed; right: 50px; bottom: 10px; background-color: #fff; border-radius: 13px 13px 13px 13px; -moz-border-radius: 13px 13px 13px 13px; -webkit-border-radius: 13px 13px 13px 13px; border: 0px solid #000000; padding: 10px; -webkit-box-shadow: 0px 0px 6px 3px rgba(150,142,150,1); -moz-box-shadow: 0px 0px 6px 3px rgba(150,142,150,1); box-shadow: 0px 0px 6px 3px rgba(150,142,150,1);">
                    <asp:Label ID="lblCostoMat0" runat="server" Text="Total:  " Font-Bold="True" Font-Size="30px"></asp:Label>
                    <asp:Label ID="lblImporteTotal" runat="server" Font-Bold="True" ForeColor="#3483fa"
                        Font-Size="30px">0.00</asp:Label>
                    <b>MXN</b>
                </div>
                <div class="row">
                    <div class="col-md-9">
                        <p class="note note-warning">
                            <strong>
                                <asp:Label ID="lblTitulo0" runat="server" Text="CONCEPTOS DE PAGO"></asp:Label></strong>
                        </p>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9">
                        <asp:ListBox ID="lstMaterias_Disponibles" CssClass="custom-select" runat="server" Height="200px"
                            Width="100%" OnSelectedIndexChanged="lstMaterias_Disponibles_SelectedIndexChanged"
                            AutoPostBack="True" ValidationGroup="MateriaDis"></asp:ListBox>
                        <br />
                        <div class="alert alert-dark" role="alert">
                            <asp:Label ID="lblDescMatDisp" runat="server"></asp:Label>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lstMaterias_Disponibles"
                            ErrorMessage="*Seleccionar elemento de la lista" ForeColor="Red"
                            ValidationGroup="MateriaDis" InitialValue="0"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="col-md-3">
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblImporteAdd" runat="server" Font-Bold="True" ForeColor="#194169"
                                    Text="Ingresa importe indicado por tu Facultad ó Dependencia" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtImporteAdd" runat="server" CausesValidation="True" Visible="false"
                                    Width="100px">0</asp:TextBox><br />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <%--<asp:Button ID="btnAgregar_Materia" runat="server" Text="Agregar" CssClass="btn btn-grey" OnClick="btnAgregar_Materia_Click" ValidationGroup="MateriaDis" ToolTip="AGREGAR" />--%>
                                <asp:LinkButton ID="linkBttnAgregar" runat="server" CssClass="btn btn-grey" ValidationGroup="MateriaDis" ToolTip="AGREGAR" OnClick="linkBttnAgregar_Click"><i class="fa fa-plus"></i> Agregar</asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblMsj" runat="server" CssClass="alert alert-danger" Width="100%"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtImporteAdd"
                                    ErrorMessage="*Agregar Importe" ForeColor="Red" SetFocusOnError="True" ValidationGroup="MateriaDis"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9">
                        <asp:ListBox ID="lstMaterias_Asignadas" runat="server" CssClass="custom-select" Height="200px" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="lstMaterias_Asignadas_SelectedIndexChanged"></asp:ListBox>
                        <br />
                        <div class="alert alert-dark" role="alert">
                            <asp:Label ID="lblDescMatAsig" runat="server"></asp:Label>
                        </div>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lstMaterias_Asignadas"
                            ErrorMessage="*Seleccionar elemento de la lista" ForeColor="Red" ValidationGroup="MateriaAsig"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <%--<asp:Button ID="btnEliminar_Materia" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                            OnClick="btnEliminar_Materia_Click" ValidationGroup="MateriaAsig" ToolTip="ELIMINAR" />--%>
                        <asp:LinkButton ID="linkBttnEliminar_Materia" runat="server" CssClass="btn btn-danger" ValidationGroup="MateriaAsig" OnClick="linkBttnEliminar_Materia_Click"><i class="fa fa-trash"></i> Eliminar</asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label10" runat="server" CssClass="font-weight-bold" Text="Especificar requerimientos(OPCIONAL)"></asp:Label>
                    </div>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtObservaciones2" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:Button ID="btnAnterior" runat="server" CssClass="btn btn-light" Text="Anterior"
                            OnClick="btnAnterior_Click" />
                        &nbsp;<asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente"
                            OnClick="btnSiguiente_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="container-fluid">
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="Image13" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>
</asp:Content>
