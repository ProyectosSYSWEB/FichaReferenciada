<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registro_Participantes.aspx.cs" Inherits="EmisionPagoReferenciado.Form.Registro_Participantes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" language="javascript">
        function MensajeExtraordinario() {
            jAlert("Si tienes más de 8 ordinarios reprobados en los 2 primeros semestres o 10 ordinarios reprobados en toda la carrera, NO efectuar el pago y pasar a control escolar para verificar tu situación académica, caso contrario NO habrá devolución del importe pagado.", "INFORMACIÓN");
            //jAlert('close');

        }

        function MensajeAlumnos() {
            //jAlert("Con el objetivo de salvaguardar la salud del personal y de los estudiantes que realizan trámites ante la Dirección de Servicios Escolares, se les informa que por instrucciones superiores, se suspenderá la atención al público del 11 al 22 de enero del presente, para reanudar el día 25 de enero, si nuestras autoridades así lo permiten. Los invitamos a estar pendientes de los avisos a través de nuestros medios electrónicos. Agradecemos su comprensión.", "INFORMACIÓN");
            $(document).ready(function () {
                $('#myModal').modal('toggle')
            });

        }


        function MensajeCaja() {
            jAlert("A partir del 01 de febrero del 2018 todas las transferencias/depósitos de las Retenciones de Impuestos y Rendimientos de las cuentas bancarias efectuadas por las Unidades Académicas y Dependencias de Administración Central de la Universidad, se deben realizar mediante el Sistema de Ingresos en el módulo de fichas referenciadas con opción única de Cargo a Cuenta Bancaria.", "INFORMACIÓN");
            //jAlert('close');

        }

        function Informativa() {
            jAlert("SI ERES ASPIRANTE Y NECESITAS PAGAR EL CONCEPTO DE CERTIFICADO DE DOCUMENTOS, CON EL NUMERO DE FICHA DEBES INGRESAR AL SISTEMA.", "INFORMACIÓN");
            //jAlert('close');

        }
        function setFocus() {

            document.getElementById("MainContent_txtNombreReg").focus();
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 25%;
            flex: 0 0 25%;
            max-width: 25%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }

        .btnBuscar {
            color: #ffffff;
            word-wrap: break-word;
            white-space: normal;
            cursor: pointer;
            border: 0;
            border-radius: 0.125rem;
            /*box-shadow: 0 2px 5px 0 rgba(0, 0, 0, 0.16), 0 2px 10px 0 rgba(0, 0, 0, 0.12);*/
            transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out, border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
            /* padding: 0.84rem 2.14rem; */
            font-size: 0.81rem;
        }

        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Vertical Steppers -->
    <div class="container d-md-none">
        <div class="row">
            <div class="col">
                <img src="../Images/MovilPaso1.png" class="img-responsive" alt="Responsive image" />
            </div>
        </div>
    </div>
    <div class="container d-none d-sm-none d-md-block">
        <div class="row">
            <div class="col text-center">
                <img src="https://sysweb.unach.mx/resources/imagenes/paso1.PNG" class="img-responsive" alt="Responsive image" />
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-9 text-dark">
                <h5>
                    <asp:Label ID="lblEvento" runat="server"></asp:Label></h5>
            </div>

            <div class="col-md-3 text-center">
                <asp:Button ID="btnLimpiar" runat="server" CssClass="btn" style="background-color:#d2af47; color:#fff" Text="Borrar Datos"
                    OnClick="btnLimpiar_Click" />
            </div>
        </div>
    </div>
    <div class="container">
        <div class="content_main">
            <div class="row" runat="server" id="rowEspecificaciones">
                <div class="col">
                    <div class="note note-warning" style="font-size: 14px">
                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblEspecificaciones" runat="server" Style="font-weight: bold; font-size: smaller" Width="100%"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                        </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
                    <div id="rowError" runat="server">
                        <div class="row alert alert-danger" role="alert">
                            <asp:Label ID="lblMsj" runat="server" Font-Bold="True"></asp:Label>
                        </div>
                    </div>
                </ContentTemplate>

            </asp:UpdatePanel>

        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="lblTipo_Participante" runat="server" Text="Tipo de participante (*)"></asp:Label>
            </div>
            <div class="col-md-9">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlTipo_Participante" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_Participante_SelectedIndexChanged" CausesValidation="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="reqExterno" runat="server" ErrorMessage="*Tipo de Participante" ForeColor="Red" ControlToValidate="ddlTipo_Participante" InitialValue="0" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="reqInternoSM" runat="server" ErrorMessage="*Tipo de Participante" ForeColor="Red" ControlToValidate="ddlTipo_Participante" InitialValue="0" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="reqInterno" runat="server" ErrorMessage="*Tipo de Participante" ForeColor="Red" ControlToValidate="ddlTipo_Participante" InitialValue="0" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
            </div>
        </div>
        <asp:UpdatePanel ID="updPnlEmpUNACH" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlEmpUNACH" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblNumPlaza" runat="server" Text="# de Plaza"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group">
                                <asp:TextBox ID="txtNumPlaza" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="bttnBuscaPlaza" runat="server" CssClass="btn-outline-secondary" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="bttnBuscaPlaza_Click" Height="35px" Width="35px" />
                            </div>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="lblTipoPersonal" runat="server" Text="Tipo de Personal"></asp:Label>
                        </div>
                        <div class="col-md-5">
                            <asp:ListBox ID="lstTipoPersonal" CssClass="custom-select" runat="server" OnSelectedIndexChanged="lstTipoPersonal_SelectedIndexChanged" AutoPostBack="True">
                                <asp:ListItem Value="Z">--NINGUNO--</asp:ListItem>
                            </asp:ListBox>

                            <asp:UpdatePanel ID="updPnlpnlMsjReg2" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pnlMsjReg2" runat="server" Visible="False">
                                        <div class="mensaje_rojo" role="alert">
                                            <asp:Label ID="lblMsjReg2" runat="server"></asp:Label>&nbsp;
                                        </div>
                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="updProgEmpUNACH" AssociatedUpdatePanelID="updPnlEmpUNACH" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image88" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." AlternateText="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server">
                    <ProgressTemplate>
                        <div class="centro">
                            <asp:Image ID="Image23" runat="server" alt="Responsive image" class="img-responsive" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlParticipante_Gral" runat="server">
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblNombre" runat="server" Text="Nombre(s)"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtNombre_Gral" runat="server" TabIndex="200" AutoPostBack="True" OnTextChanged="txtNombre_Gral_TextChanged" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre_Gral"
                                ErrorMessage="*Nombre(s)" ForeColor="Red" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPaterno_Gral" runat="server" TabIndex="201" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaterno_Gral"
                                ErrorMessage="*Apellido Paterno" ForeColor="Red" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="lblMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMaterno_Gral" runat="server" OnTextChanged="txtMaterno_Gral_TextChanged"
                                AutoPostBack="True" TabIndex="202" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requeridoMaterno" runat="server" ControlToValidate="txtMaterno_Gral"
                                ErrorMessage="*Apellido Materno" ForeColor="Red" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblPeriodo_Pago_G" runat="server" Text="Periodo de Pago (Ciclo)"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlPeriodo_Pago__Gral" runat="server" TabIndex="203" CssClass="custom-select">
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="lblGenero" runat="server" Text="Género"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:RadioButtonList ID="rdoGenero_Gral" runat="server" RepeatDirection="Horizontal" TabIndex="204">
                                <asp:ListItem Value="F">Femenino</asp:ListItem>
                                <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rdoGenero_Gral"
                                ErrorMessage="*Genero" ForeColor="Red" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblCP" runat="server" Text="Código Postal"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtCP_Gral" runat="server" TabIndex="209" CssClass="form-control"></asp:TextBox>

                            </div>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="lblEdo_Provincia" runat="server" Text="Estado / Provincia"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlEdo_Provincia_Gral" runat="server" TabIndex="210" CssClass="custom-select">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlEdo_Provincia_Gral"
                                ErrorMessage="*Estado" ForeColor="Red" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtCiudad_Gral" runat="server" TabIndex="211" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtDomicilio_Gral" runat="server" TabIndex="212" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblColonia" runat="server" Text="Colonia"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtColonia_Gral" runat="server" TabIndex="213" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtTelefono_Gral" runat="server" TabIndex="214" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="lblCel" runat="server" Text="Celular"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCel_Gral" runat="server" TabIndex="215" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblInstitucion" runat="server" Text="Institución"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtInstitucion_Gral" runat="server" TabIndex="216" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblCargo_Puesto" runat="server" Text="Cargo o Puesto"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtCargo_Puesto" runat="server" TabIndex="217" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblGrado_Max_Est" runat="server" Text="Grado Máximo de Estudios"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlGrado_Max_Est_Gral" runat="server" TabIndex="218" CssClass="custom-select">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-1">
                            <asp:Label ID="lblCorreo" runat="server" Text="EMail"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCorreo_Gral" runat="server" TabIndex="219" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtCorreo_Gral" ErrorMessage="*Correo" ForeColor="Red" ValidationGroup="gpoExterno">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlEstudianteUNACH_RegMatricula" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblMatricula" runat="server"
                                Text="No. de Ficha / Matricula / Id Sysweb" Font-Bold="False"></asp:Label>
                        </div>

                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"
                                    TabIndex="2" MaxLength="8" CausesValidation="True"
                                    ValidationGroup="gpoBusca" OnTextChanged="txtMatricula_TextChanged"></asp:TextBox>
                                <asp:UpdatePanel ID="UpdMatricula" runat="server">
                                    <ContentTemplate>
                                        <span class="input-group-addon">
                                            <%--<asp:LinkButton ID="linkBttnBuscar" runat="server" Height="40px" CssClass="btnBuscar btn-blue-grey" OnClick="linkBttnBuscar_Click">
                                                                    <i class="fa fa-search" aria-hidden="true"></i>
                                                                    </asp:LinkButton>--%>
                                            <asp:ImageButton ID="imgBttnBuscar" CssClass="btnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                        </span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="alert alert-warning font-smaller">
                                <asp:Label ID="lblMsjUsu" runat="server" Text="Si no tienes no. de ficha, matricula o id sysweb, click en el icono de la lupa, y registrate."></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col text-center">
                            <asp:UpdateProgress ID="UpdProMatricula" AssociatedUpdatePanelID="UpdMatricula" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="imgMatricula" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        class="img-responsive" alt="Responsive image" ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <%--<asp:UpdatePanel ID="UpdMatricula" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control"
                                                                TabIndex="2" MaxLength="8" CausesValidation="True"
                                                                ValidationGroup="gpoBusca" placeholder="Ingresa matricula y click en buscar" Width="100%" OnTextChanged="txtMatricula_TextChanged"></asp:TextBox>
                                                            <div class="alert alert-warning font-smaller">
                                                                <asp:Label ID="lblMsjUsu" runat="server" Text="Si no tienes no. de ficha, matricula o id sysweb, click en el icono de la lupa, y registrate."></asp:Label>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>--%>
                            <%--<asp:UpdateProgress ID="UpdProMatricula" AssociatedUpdatePanelID="UpdMatricula" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="imgMatricula" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                                                class="img-responsive" alt="Responsive image" ToolTip="Espere un momento, por favor.." />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>--%>

                            <asp:Panel ID="pnlMsjReg" runat="server">
                                <div class="alert alert-danger" role="alert">
                                    <div class="row">
                                        <div class="col">
                                            <asp:Label ID="lblMsjReg" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col">
                                            <asp:LinkButton ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click"
                                                Visible="False">Dato no encontrado, si deseas registralo dar click por única vez AQUI</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <br />
                            <asp:Label ID="lblMatRe" runat="server" ForeColor="#2B5D95" Text="Si tienes matrícula ingrésala, en caso contrario continúa con tu registro."
                                Font-Bold="True" Visible="False"></asp:Label>
                        </div>
                        <%--<div class="col-md-1">
                                                            <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblNivel" runat="server" Text="Nivel de Estudios" Visible="False"></asp:Label></td>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-9">
                            <asp:UpdatePanel ID="updPnlNivel" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="ddlNivel" runat="server" CssClass="custom-select" AutoPostBack="True" CausesValidation="True" Height="100px" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" ValidationGroup="gpoBusca" Visible="False"></asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="updProgNivel" AssociatedUpdatePanelID="updPnlNivel" runat="server">
                                <ProgressTemplate>
                                    <asp:Image ID="imgNivel" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        class="img-responsive" alt="Responsive image" ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlNivel" Display="Dynamic" ErrorMessage="Seleccionar Nivel" ForeColor="Red" InitialValue="Z" ValidationGroup="gpoBusca">* Seleccionar Nivel</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <asp:Panel ID="pnlEstudianteUNACH" runat="server" Visible="False">
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblNombreReg" runat="server" Text="Nombre"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtNombreReg" runat="server" CssClass="form-control" Enabled="False" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNombreReg"
                                    ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblPaternoReg" runat="server" Text="Paterno"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtPaternoReg" runat="server" CssClass="form-control" TabIndex="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqPatAlum" runat="server" ControlToValidate="txtPaternoReg" ErrorMessage="*Apellido Paterno" ForeColor="Red" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="lblMaternoReg" runat="server" Text="Materno"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtMaternoReg" runat="server" CssClass="form-control"
                                    AutoPostBack="True" TabIndex="5" OnTextChanged="txtMaternoReg_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblEscuela" runat="server" Text="Escuela"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlDependencia_D" Enabled="False" runat="server" CssClass="custom-select" TabIndex="6"
                                    ClientIDMode="Predictable" OnSelectedIndexChanged="ddlDependencia_D_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                    ControlToValidate="ddlDependencia_D" ErrorMessage="*Depependencia" ForeColor="Red"
                                    InitialValue="0" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtEscuela" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblCarrera" runat="server" Text="Carrera"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:DropDownList ID="ddlCarrera" runat="server" CssClass="custom-select" ClientIDMode="Predictable" Enabled="False"
                                    TabIndex="7" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged">
                                </asp:DropDownList>


                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblOtraCarrera" runat="server" Text="Especificar:" Visible="False"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtCarrera" runat="server" CssClass="form-control" Visible="false" Enabled="False" placeholder="Escriba el nombre de la carrera"></asp:TextBox>

                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblSemestre" runat="server" Text="Semestre"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtSemestre" runat="server" CssClass="form-control" Enabled="False" TabIndex="8"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequreqPatAlumiredFieldValidator13" runat="server" ControlToValidate="txtSemestre"
                                    ErrorMessage="*Semestre" ForeColor="Red" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSemestre"
                                    ForeColor="Red" ErrorMessage="*Semestre numerico" ValidationGroup="gpoInterno" ValidationExpression="\d+">*Solo números</asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="lblGrupo0" runat="server" Text="Grupo"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtGrupo" runat="server" CssClass="form-control" Enabled="False" TabIndex="9"
                                    MaxLength="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtGrupo"
                                    ErrorMessage="*Grupo" ForeColor="Red" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblPeriodo_Pago_I" runat="server" Text="Periodo de Pago (Ciclo)"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlPeriodo_Pago_I" runat="server" CssClass="custom-select" TabIndex="10">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlPeriodo_Pago_I" ErrorMessage="*Periodo Pago" ForeColor="Red" InitialValue="0" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-1">
                                <asp:Label ID="Label4" runat="server" Text="Género"></asp:Label>
                            </div>
                            <div class="col-md-4">
                                <asp:RadioButtonList ID="rdoGeneroI" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="11">
                                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                                    <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <asp:Label ID="lblCorreo0" runat="server" Text="EMail"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtCorreo0" runat="server" CssClass="form-control" TabIndex="12"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CampoReqCorreo0" runat="server" ControlToValidate="txtCorreo0" ErrorMessage="*Correo" ForeColor="Red" ValidationGroup="gpoInterno">*Requerido</asp:RequiredFieldValidator>
                                &nbsp;<asp:RegularExpressionValidator runat="server" ControlToValidate="txtCorreo0" ErrorMessage="*Este correo no es válido"
                                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ValidationGroup="gpoInterno" ForeColor="Red" ID="ExpRegCorreo" />
                            </div>
                        </div>
                    </asp:Panel>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlEstudianteExterno" runat="server" Visible="False">
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtNombreEst_Ext" CssClass="form-control" runat="server" TabIndex="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNombreEst_Ext"
                                ErrorMessage="*Nombre" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="Label12" runat="server" Text="Paterno"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtPaternoEst_Ext" CssClass="form-control" runat="server" TabIndex="101"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtPaternoEst_Ext" ErrorMessage="*Apellido Paterno" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label13" runat="server" Text="Materno"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtMaternoEst_Ext" CssClass="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtMaternoEst_Ext_TextChanged"
                                TabIndex="102"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requeridoMaternoExt" runat="server" ControlToValidate="txtMaternoEst_Ext" ErrorMessage="*Apellido Materno" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-1">
                            <asp:Label ID="Label11" runat="server" Text="Genero"></asp:Label></td>
                        </div>
                        <div class="col-md-4">
                            <asp:RadioButtonList ID="rdoGeneroEst_Ext" CssClass="custom-control custom-radio" runat="server" RepeatDirection="Horizontal"
                                TabIndex="103">
                                <asp:ListItem Value="F">Femenino</asp:ListItem>
                                <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                            </asp:RadioButtonList>
                            </td>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="Escuela"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtNombreEscuela_Ext" CssClass="form-control" runat="server" TabIndex="104"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtNombreEscuela_Ext" ErrorMessage="*Nombre de la Escuela" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblNivel_Ext" runat="server" Text="Grado Máximo de Estudios"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="ddlNivel_Ext" CssClass="custom-select" runat="server" TabIndex="105">
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label5" runat="server" Text="Semestre"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtSemestreEst_Ext" CssClass="form-control" runat="server" TabIndex="106"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSemestreEst_Ext"
                                ForeColor="Red" ErrorMessage="* Solo Números" ValidationGroup="gpoInternoSM"
                                ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtSemestreEst_Ext"
                                ErrorMessage="*Semestre" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label6" runat="server" Text="Grupo"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtGrupoEst_Ext" CssClass="form-control" runat="server" TabIndex="107" MaxLength="10"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtGrupoEst_Ext"
                                ErrorMessage="*Grupo" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label7" runat="server" Text="Periodo de Pago (Ciclo)"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="ddlPeriodo_Pago_ISM" CssClass="custom-select" runat="server" TabIndex="108">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblCel_Ext" runat="server" Text="Celular"></asp:Label>
                        </div>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCel_Ext" CssClass="form-control" runat="server" TabIndex="109"></asp:TextBox>
                        </div>

                        <div class="col-md-2">
                            <asp:Label ID="Label8" runat="server" Text="EMail"></asp:Label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtCorreoEst_Ext" CssClass="form-control" runat="server" TabIndex="110"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtCorreoEst_Ext" ErrorMessage="*Correo" ForeColor="Red" ValidationGroup="gpoInternoSM">*Requerido</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlPonente" runat="server" Visible="False">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblPonencia1" runat="server" Text="Ponencia 1"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtPonencia1" runat="server" CssClass="form-control" TextMode="MultiLine" TabIndex="501"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblPonencia2" runat="server" Text="Ponencia 2" Visible="False"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtPonencia2" runat="server" CssClass="form-control" TextMode="MultiLine" TabIndex="502" Visible="False"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel8" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlConstancia" runat="server" Visible="false">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="lblConstancia" runat="server" Text="Nombre para Constancia"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtConstancia" runat="server" CssClass="form-control" TabIndex="17"></asp:TextBox>
                        </div>
                    </div>
                </asp:Panel>
                &nbsp;
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="updPnlExtras" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlExtras" runat="server" CssClass="alert alert-warning" Visible="false">
                    <div class="font-weight-bold">Información Adicional</div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblMsj2" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        </div>
                    <div class="col-md-4">
                        <asp:ValidationSummary ID="valInterno" CssClass="aler alert-danger" runat="server" ValidationGroup="gpoInterno" HeaderText="Estos campos son requeridos:" />
                        <asp:ValidationSummary ID="valExterno" CssClass="aler alert-danger" runat="server" ValidationGroup="gpoExterno" HeaderText="Estos campos son requeridos:"/>
                        <asp:ValidationSummary ID="valInternoSM" CssClass="aler alert-danger" runat="server" ValidationGroup="gpoInternoSM"  HeaderText="Estos campos son requeridos:" />
                    </div>
                    <div class="col-md-4 text-center">
                        </div>
                </div>
                <div class="row">
                    <div class="col text-center">
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-light" Text="Cancelar" OnClick="btnCancelar_Click" />
                        &nbsp;<asp:Button ID="btnSiguiente" runat="server" CssClass="btn btn-primary" Text="Siguiente"
                            OnClick="btnSiguiente_Click" Visible="False" TabIndex="900" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="text-center">
            <asp:UpdateProgress ID="UpdateProgress3" AssociatedUpdatePanelID="UpdatePanel6" runat="server">
                <ProgressTemplate>
                    <asp:Image ID="Image13" runat="server" Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>


     <div id="myModal" class="modal fade">
            <div class="modal-dialog modal-login">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Aviso</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    </div>
                    <div class="modal-body">
                        Con el objetivo de salvaguardar la salud del personal y de los estudiantes que realizan trámites en la Dirección de Servicios Escolares, quedan suspendidos los <strong> PAGOS DE CERTIFICACIÓN DE DOCUMENTOS </strong> hasta nuevo aviso. Agradecemos su comprensión.
                    </div>
                    <div class="modal-footer"><button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true">Cerrar</button></div>
                </div>
            </div>
        </div>
    <script src="../Scripts/jCodigoPostal.js"></script>
</asp:Content>


