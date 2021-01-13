using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion
namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        Comun ObjComun = new Comun();
        CN_Comun CNComun = new CN_Comun();
        Participante ObjParticipante = new Participante();
        CN_Participante CNParticipante = new CN_Participante();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        Componente ObjComponente = new Componente();

        private static List<Comun> ListTipoPartcipante = new List<Comun>();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            if (!IsPostBack)
            {
                Inicializar();
                
                if (SesionUsu.UsuEvento == "FINANZAS_2016" || SesionUsu.UsuEvento == "RENDIMIENTOS")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Mensaje", "MensajeCaja();", true);
                    reqPatAlum.ValidationGroup = string.Empty;
                }
                else if(SesionUsu.UsuEvento=="ALUMNO")
                {
                    ClientScript.RegisterStartupScript(GetType(), "MensajeAlumnos", "MensajeAlumnos();", true);

                }
                else
                    reqPatAlum.ValidationGroup = "gpoInterno";
            }

            if (SesionUsu != null)
            {
                if (SesionUsu.ComponentesExtras == "S")
                    CargarComponentesExtras();
                else
                    pnlExtras.Visible = false;
            }
            else
                Response.Redirect("https://sysweb.unach.mx/");


        }
        #region <Botones y Eventos>

        protected void ddlTipo_Participante_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnSiguiente.Visible = true;
            pnlPonente.Visible = false;
            txtNumPlaza.Text = string.Empty;
            lstTipoPersonal.Items.Clear();
            lstTipoPersonal.Items.Insert(0, new ListItem("NINGUNO", "0"));
            LimpiarDatosPublicoGral();

            pnlEstudianteUNACH_RegMatricula.Visible = false;
            pnlEmpUNACH.Visible = false;
            pnlParticipante_Gral.Visible = false;
            pnlEstudianteUNACH.Visible = false;
            pnlEstudianteExterno.Visible = false;
            pnlConstancia.Visible = false;
            txtConstancia.Text = string.Empty;
            txtNombre_Gral.Enabled = true;
            txtPaterno_Gral.Enabled = true;
            txtMaterno_Gral.Enabled = true;

            if (Session["ConfTipoPart"] != null)
            {
                ListTipoPartcipante = (List<Comun>)Session["ConfTipoPart"];
                SesionUsu.TipoParticipante = ListTipoPartcipante[ddlTipo_Participante.SelectedIndex].EtiquetaTres;
                SesionUsu.Ponente = ListTipoPartcipante[ddlTipo_Participante.SelectedIndex].EtiquetaCuatro;
                SesionUsu.RequiereConstancia = ListTipoPartcipante[ddlTipo_Participante.SelectedIndex].EtiquetaCinco;
                if (SesionUsu.TipoParticipante != "S" && SesionUsu.TipoParticipante != "E")
                {
                    if (SesionUsu.Ponente == "S")
                        pnlPonente.Visible = true;
                    else
                        pnlPonente.Visible = false;


                    if (SesionUsu.RequiereConstancia == "S")
                        pnlConstancia.Visible = true;
                }




                if (SesionUsu.TipoParticipante == "S") //Estudiante UNACH
                {
                    //lblNivel.Visible = false;
                    //ddlNivel.Visible = false;
                    //ddlNivel.Items.Clear();
                    txtMatricula.Text = string.Empty;
                    txtMatricula.Enabled = true;
                    imgBttnBuscar.Visible = true;
                    txtMatricula.Focus();
                    pnlEstudianteUNACH_RegMatricula.Visible = true;
                    btnSiguiente.Visible = false;
                    btnCancelar.Visible = false;
                    btnSiguiente.ValidationGroup = "gpoInterno";
                    SesionUsu.UsuWXI = "X";
                    CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Escuelas_Externos", ref ddlDependencia_D, "p_nivel", "p_evento", "p_usuario", ddlNivel.SelectedValue, SesionUsu.UsuEvento, SesionUsu.UsuWXI);
                    ddlDependencia_D_SelectedIndexChanged(null, null);
                    if (ddlCarrera.SelectedValue != string.Empty)
                    {
                        if (ddlCarrera.SelectedValue == "000000")
                        {
                            lblOtraCarrera.Visible = true;
                            txtCarrera.Visible = true;
                        }
                        else
                        {
                            lblOtraCarrera.Visible = false;
                            txtCarrera.Visible = false;
                            txtCarrera.Text = ddlCarrera.SelectedItem.Text;
                        }
                    }
                    btnSiguiente.ValidationGroup = "gpoInterno";

                }
                else if (SesionUsu.TipoParticipante == "E") //Empleado UNACH
                {
                    SesionUsu.UsuWXI = "X";
                    txtNumPlaza.Focus();
                    txtNombre_Gral.Enabled = false;
                    txtPaterno_Gral.Enabled = false;
                    txtMaterno_Gral.Enabled = false;
                    pnlEmpUNACH.Visible = true;
                    btnSiguiente.ValidationGroup = "gpoExterno";
                }
                else if (SesionUsu.TipoParticipante == "SX") //Estudiante Externo
                {
                    SesionUsu.UsuWXI = "X";
                    pnlEstudianteExterno.Visible = true;
                    btnSiguiente.Visible = true;
                    btnCancelar.Visible = true;


                    //pnlParticipante_Gral.Visible = true;
                    txtNombreEst_Ext.Focus();
                    btnSiguiente.ValidationGroup = "gpoInternoSM";
                }                
                else if (SesionUsu.TipoParticipante == "X")
                {
                    pnlParticipante_Gral.Visible = true;
                    txtNombre_Gral.Focus();
                    btnSiguiente.Visible = true;
                    btnCancelar.Visible = true;

                    SesionUsu.UsuWXI = "X";
                    btnSiguiente.ValidationGroup = "gpoExterno";
                }
                //else
                //{
                //    rowError.Visible = true;
                //    lblMsj.Text = "<i class='fa fa-user - circle' aria-hidden='true'></i> Seleccionar un tipo de participante.";
                //}
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Grado_Estudio_Evento", ref ddlNivel_Ext, "p_evento", "p_tipo_participante", SesionUsu.UsuEvento, ddlTipo_Participante.SelectedValue);


            }
            if (SesionUsu.UsuEvento == "ADMON" || SesionUsu.UsuEvento == "SUPERADMON" || SesionUsu.UsuEvento == "RENDIMIENTOS" || SesionUsu.UsuEvento == "FINANZAS_2016")
                {
                    if (Request.QueryString["WXI"] != null)
                    {
                        SesionUsu.UsuWXI = Request.QueryString["WXI"];
                        ExpRegCorreo.ValidationGroup = string.Empty;
                        CampoReqCorreo0.ValidationGroup = string.Empty;
                    }
                }
            
        }

        //protected void txtMaterno0_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblMsj.Text = string.Empty;
        //        SesionUsu = (Sesion)Session["SesionFicha"];
        //        ObjParticipante.APaterno = txtPaterno0.Text.ToUpper();
        //        ObjParticipante.AMaterno = txtMaterno0.Text.ToUpper();
        //        ObjParticipante.Nombre = txtNombre1.Text.ToUpper();
        //        ObjParticipante.Evento = SesionUsu.UsuEvento;

        //        CNParticipante.ConsultarParticipante(ref ObjParticipante, ref Verificador);
        //        if (Verificador == "0")
        //        {
        //            if (ObjParticipante.Operacion == "U")
        //            {
        //                rdoGenero0.SelectedValue = Convert.ToString(ObjParticipante.Genero);
        //                txtTelefono0.Text = ObjParticipante.TelParticular;
        //                txtCel0.Text = ObjParticipante.Celular;
        //                txtCorreo1.Text = ObjParticipante.Correo;
        //                ddlGrado_Max_Est0.SelectedValue = ObjParticipante.GradoEstudio;
        //                txtInstitucion0.Text = ObjParticipante.Dependencia;
        //                txtCargo_Puesto0.Text = ObjParticipante.CargoProcedencia;
        //                txtDomicilio0.Text = ObjParticipante.DomicilioProcedencia;
        //                txtCiudad0.Text = ObjParticipante.CiudadProcedencia;
        //                txtColonia0.Text = ObjParticipante.Colonia;
        //                txtCP0.Text = ObjParticipante.CP;
        //                ddlEdo_Provincia0.SelectedValue = ObjParticipante.EstadoProcedencia;
        //                txtConstancia1.Text = ObjParticipante.Constancia;
        //                txtPonencia1.Text = ObjParticipante.Ponencia1;
        //                txtPonencia2.Text = ObjParticipante.Ponencia2;
        //                ddlPeriodo_Pago_P.SelectedValue = Convert.ToString(ObjParticipante.PeriodoPago);
        //            }
        //            else
        //            {
        //                rdoGenero0.SelectedValue = "M";
        //                txtTelefono0.Text = string.Empty;
        //                txtCel0.Text = string.Empty;
        //                txtCorreo1.Text = string.Empty;
        //                ddlGrado_Max_Est0.SelectedValue = "ESTUDIANTE";
        //                txtInstitucion0.Text = string.Empty;
        //                txtCargo_Puesto0.Text = string.Empty;
        //                txtDomicilio0.Text = string.Empty;
        //                txtCiudad0.Text = string.Empty;
        //                txtColonia0.Text = string.Empty;
        //                txtCP0.Text = string.Empty;
        //                ddlEdo_Provincia0.SelectedValue = "CHIAPAS";
        //                txtConstancia1.Text = string.Empty;
        //                txtPonencia1.Text = string.Empty;
        //                txtPonencia2.Text = string.Empty;
        //                ddlPeriodo_Pago_P.SelectedValue = "20";
        //                txtConstancia1.Text = txtNombre1.Text.Trim() + " " + txtPaterno0.Text.Trim() + " " + txtMaterno0.Text.Trim();
        //            }
        //        }
        //        else
        //            lblMsj.Text = Verificador;

        //        SesionUsu.Operacion = ObjParticipante.Operacion;
        //        SesionUsu.UsuMatricula = ObjParticipante.NoControl;

        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsj.Text = ex.Message;
        //    }
        //}

        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {

                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Escuelas_Externos", ref ddlDependencia_D, "p_nivel", "p_evento", "p_usuario", ddlNivel.SelectedValue, SesionUsu.UsuEvento, SesionUsu.UsuWXI);
                ddlDependencia_D_SelectedIndexChanged(null, null);


                if (SesionUsu.NuevoReg == "N")
                {
                    if (ddlNivel.SelectedValue != "Z")
                    {
                        SesionUsu = (Sesion)Session["SesionFicha"];
                        ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
                        ObjAlumno.Evento = SesionUsu.UsuEvento;
                        ObjAlumno.TipoPersona = Convert.ToInt32(ddlTipo_Participante.SelectedValue);
                        ObjAlumno.Nivel = ddlNivel.SelectedValue;
                        CNAlumno.ConsultarAlumno(ref ObjAlumno, ref Verificador);
                        if (Verificador == "0")
                        {
                            if (ObjAlumno.StatusMatricula == "A")
                            {
                                SesionUsu.Id_Comprobante = 1;
                                pnlEstudianteUNACH.Visible = true;
                                btnRegistrar.Visible = false;
                                ddlDependencia_D.Enabled = false;
                                //ddlCarrera.Enabled = false;
                                txtNombreReg.Enabled = false;
                                txtPaternoReg.Enabled = false;
                                txtMaternoReg.Enabled = false;
                                txtSemestre.Enabled = false;
                                txtGrupo.Enabled = false;
                                txtCarrera.Enabled = false;
                                btnSiguiente.Enabled = false;
                                imgBttnBuscar.Visible = false;
                                SesionUsu.UsuMatricula = txtMatricula.Text.ToUpper();
                                SesionUsu.UsuNivel = ddlNivel.SelectedValue;
                                ddlDependencia_D.SelectedValue = ObjAlumno.Dependencia;
                                ddlDependencia_D_SelectedIndexChanged(null, null);
                                try
                                {
                                    ddlCarrera.SelectedValue = ObjAlumno.Carrera;
                                }
                                catch (Exception)
                                {
                                    ddlCarrera.SelectedValue = "000000";
                                }

                                SesionUsu.UsuDependencia = ObjAlumno.Dependencia;
                                SesionUsu.UsuCarrera = ObjAlumno.Carrera;
                                txtEscuela.Text = ObjAlumno.DescEscuela;
                                txtCarrera.Text = ObjAlumno.DescCarrera;
                                if (ddlCarrera.SelectedValue == "000000")
                                {
                                    lblOtraCarrera.Visible = true;
                                    txtCarrera.Visible = true;

                                }
                                else
                                {
                                    lblOtraCarrera.Visible = false;
                                    txtCarrera.Visible = false;
                                    txtCarrera.Text = ddlCarrera.SelectedItem.Text;
                                }
                                if (ddlNivel.SelectedValue == "N")
                                    ddlCarrera.Enabled = true;
                                else
                                    ddlCarrera.Enabled = false;

                                txtSemestre.Text = ObjAlumno.Semestre;
                                txtGrupo.Text = ObjAlumno.Grupo;
                                txtCorreo0.Text = ObjAlumno.Correo;
                                txtNombreReg.Text = ObjAlumno.Nombre;
                                txtPaternoReg.Text = ObjAlumno.APaterno;
                                txtMaternoReg.Text = ObjAlumno.AMaterno;
                                btnSiguiente.Visible = true;
                                btnSiguiente.Enabled = true;
                                btnCancelar.Visible = true;

                                lblMsj.Text = string.Empty;
                                rdoGeneroI.SelectedValue = Convert.ToString(ObjAlumno.Genero);
                                txtMatricula.Enabled = false;
                            }
                            else
                            {
                                txtCorreo0.Text = ObjAlumno.Correo;
                                rowError.Visible = true;
                                EnviarCorreoActivacion(txtMatricula.Text.ToUpper(), ddlNivel.SelectedValue);
                                lblMsj.Text = "Tu clave "+txtMatricula.Text+" aún no ha sido activada, para realizar la activación deberas consultar tu correo "+txtCorreo0.Text;
                            }
                        }
                        else
                        {
                            SesionUsu.Id_Comprobante = 0;
                            SesionUsu.UsuDependencia = "";
                            SesionUsu.UsuCarrera = "";
                            txtEscuela.Text = string.Empty;
                            txtCarrera.Text = string.Empty;
                            txtSemestre.Text = string.Empty;
                            txtGrupo.Text = string.Empty;
                            txtCorreo0.Text = string.Empty;
                            //txtNombre0.Text = string.Empty;                    
                            txtNombreReg.Text = string.Empty;
                            txtPaternoReg.Text = string.Empty;
                            txtMaternoReg.Text = string.Empty;
                            btnSiguiente.Enabled = false;
                            //btnCancelar.Enabled = false;

                            rowError.Visible = true;
                            lblMsj.Text = Verificador;
                        }

                    }
                }
                //else
                //{
                //    CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Escuelas_Externos", ref ddlDependencia_D, "p_nivel", "p_evento", "p_usuario", ddlNivel.SelectedValue, SesionUsu.UsuEvento, SesionUsu.UsuWXI);
                //    ddlDependencia_D_SelectedIndexChanged(null, null);
                //}

                if (SesionUsu.Ponente == "S")
                    pnlPonente.Visible = true;
                else
                    pnlPonente.Visible = false;

                if (SesionUsu.RequiereConstancia == "S")
                    pnlConstancia.Visible = true;
                else
                {
                    pnlConstancia.Visible = false;
                    txtConstancia.Text = string.Empty;
                }


            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCarrera.SelectedValue == "000000")
            {
                lblOtraCarrera.Visible = true;
                txtCarrera.Visible = true;
                txtCarrera.Text = string.Empty;
            }
            else
            {
                lblOtraCarrera.Visible = false;
                txtCarrera.Visible = false;
                txtCarrera.Text = ddlCarrera.SelectedItem.Text;

            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            ddlDependencia_D.Enabled = true;
            ddlCarrera.Enabled = true;
            //txtNombre0.Enabled = true;
            txtNombreReg.Enabled = true;
            txtPaternoReg.Enabled = true;
            txtMaternoReg.Enabled = true;
            txtSemestre.Enabled = true;
            txtCarrera.Enabled = true;
            //txtCorreo0.Enabled = true; Deshabilitado en la Nueva Version
            txtGrupo.Enabled = true;
            btnSiguiente.Enabled = true;
            SesionUsu.Id_Comprobante = 0;
            SesionUsu.UsuMatricula = txtMatricula.Text.ToUpper();
            rowError.Visible = true;
            lblMsj.Text = "Ingrese los datos del Alumno";
            //lblMsjReg.Visible = false;
            btnRegistrar.Visible = false;
            txtMatricula.Enabled = false;
            imgBttnBuscar.Enabled = false;
            lblNivel.Visible = true;
            ddlNivel.Visible = true;
            CNComun.LlenaLista("PKG_PAGOS_2016.Obt_Combo_Niveles", ref ddlNivel, "p_evento", SesionUsu.UsuEvento);
            pnlMsjReg.Visible = true;
            lblMsjReg.Text = "Por favor llena los datos que se te solicitan a continuación, revisa tu dirección de correo electrónico para poder activar tu cuenta.";
            pnlEstudianteUNACH.Visible = true;
            btnSiguiente.Visible = true;
            btnCancelar.Visible = true;

            ScriptManager.RegisterStartupScript(this, typeof(string), "SHOW_ALERT", "setFocus();", true);
            SesionUsu.NuevoReg = "S";
            //ClientScript.RegisterStartupScript(GetType(), "Mensaje2", "setFocus();", true);
        }
        protected void txtMaterno2_TextChanged(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                string s = ExpRegCorreo.ValidationGroup;
                SesionUsu = (Sesion)Session["SesionFicha"];
                ObjParticipante.TipoPersona = Convert.ToInt32(ddlTipo_Participante.SelectedValue);
                ObjParticipante.TelProcedencia = "";
                ObjParticipante.NoControl = SesionUsu.UsuMatricula;
                ObjParticipante.Correo = "";
                ObjAlumno.Correo = "";
                ObjParticipante.Ponencia1 = (SesionUsu.Ponente == "S") ? txtPonencia1.Text : string.Empty;
                ObjParticipante.Ponencia2 = (SesionUsu.Ponente == "S") ? txtPonencia2.Text : string.Empty;
                if (SesionUsu.TipoParticipante == "S")
                {
                    SesionUsu.PeriodoPago = ddlPeriodo_Pago_I.SelectedItem.Text;
                    SesionUsu.UsuGrupo = txtGrupo.Text;
                    SesionUsu.UsuSemestre = txtSemestre.Text;
                    ObjParticipante.Nombre = txtNombreReg.Text.ToUpper();
                    ObjParticipante.APaterno = txtPaternoReg.Text.ToUpper(); //"";
                    ObjParticipante.AMaterno = txtMaternoReg.Text.ToUpper(); //"";
                    SesionUsu.Donativo = "0";

                    ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
                    ObjAlumno.Nombre = txtNombreReg.Text.ToUpper(); //txtNombre0.Text.ToUpper();
                    ObjAlumno.APaterno = txtPaternoReg.Text.ToUpper();
                    ObjAlumno.AMaterno = txtMaternoReg.Text.ToUpper();
                    ObjAlumno.Semestre = txtSemestre.Text;
                    ObjAlumno.Grupo = txtGrupo.Text;
                    ObjAlumno.Carrera = ddlCarrera.SelectedValue;
                    if (ddlCarrera.SelectedValue != "000000")
                        txtCarrera.Text = ddlCarrera.SelectedItem.Text;
                    ObjAlumno.DescCarrera = txtCarrera.Text;


                    ObjAlumno.UsuNombre = "Alumno";
                    ObjAlumno.Nivel = ddlNivel.SelectedValue;
                    ObjAlumno.Dependencia = ddlDependencia_D.SelectedValue;
                    ObjAlumno.Correo = txtCorreo0.Text;
                    ObjParticipante.TelParticular = string.Empty;
                    ObjAlumno.Genero = Convert.ToChar(rdoGeneroI.SelectedValue);

                    if (SesionUsu.NuevoReg == "S")
                        ObjAlumno.StatusMatricula = (SesionUsu.UsuWXI != "X") ? "A" : "C";
                    else
                        ObjAlumno.StatusMatricula = "X";

                    Verificador = string.Empty;
                    if (SesionUsu.Id_Comprobante == 0)
                    {
                        CNAlumno.AlumnoInsertar(ObjAlumno, ref Verificador);
                        SesionUsu.UsuNivel = ddlNivel.SelectedValue;
                        SesionUsu.UsuDependencia = ddlDependencia_D.SelectedValue;
                        SesionUsu.UsuCarrera = ddlCarrera.SelectedValue;
                        SesionUsu.UsuMatricula = ObjAlumno.Matricula;
                    }
                    else                    
                        CNAlumno.AlumnoEditar(ref ObjAlumno, ref Verificador);

                    if (SesionUsu.Ponente == "S")
                    {
                        Verificador = string.Empty;
                        CNAlumno.AlumnoInsertarPonente(ObjAlumno, ObjParticipante, SesionUsu.UsuEvento, ref Verificador);
                    }



                }
                else
                {
                    if (SesionUsu.TipoParticipante == "SX")
                    {

                        ObjParticipante.APaterno = txtPaternoEst_Ext.Text.ToUpper();
                        ObjParticipante.AMaterno = txtMaternoEst_Ext.Text.ToUpper();
                        ObjParticipante.Nombre = txtNombreEst_Ext.Text.ToUpper();
                        ObjParticipante.Evento = SesionUsu.UsuEvento;
                        ObjParticipante.Genero = Convert.ToChar(rdoGeneroEst_Ext.SelectedValue);
                        ObjParticipante.Celular = txtCel_Ext.Text;
                        //ObjParticipante.TelParticular = txtTelefono0.Text;
                        //txtCorreoEst_ExtObjParticipante.Celular = txtCel0.Text;
                        ObjParticipante.Correo = txtCorreoEst_Ext.Text.ToUpper();
                        ObjParticipante.GradoEstudio = ddlNivel_Ext.SelectedValue;
                        ObjParticipante.Dependencia = txtNombreEscuela_Ext.Text.ToUpper(); //txtInstitucion0.Text.ToUpper();
                        ObjParticipante.CargoProcedencia = string.Empty;
                        ObjParticipante.DomicilioProcedencia = string.Empty;
                        ObjParticipante.CiudadProcedencia = string.Empty;
                        ObjParticipante.EstadoProcedencia = string.Empty;
                        ObjParticipante.Colonia = string.Empty;
                        ObjParticipante.CP = string.Empty;
                        ObjParticipante.Constancia = txtConstancia.Text.ToUpper();
                        //ObjParticipante.Ponencia1 = txtPonencia1.Text.ToUpper();
                        //ObjParticipante.Ponencia2 = txtPonencia2.Text.ToUpper();
                        //ObjParticipante.GradoEstudio = "";
                        ObjParticipante.TelParticular = "";
                        //ObjParticipante.Celular = "";


                        ObjParticipante.Donativo = "0";
                        ObjParticipante.PeriodoPago = Convert.ToInt32(ddlPeriodo_Pago_ISM.SelectedValue); //Convert.ToInt32(ddlPeriodo_Pago_P.SelectedValue);
                        SesionUsu.PeriodoPago = ddlPeriodo_Pago_ISM.SelectedItem.Text;
                        SesionUsu.UsuGrupo = txtGrupoEst_Ext.Text; //"X";
                        SesionUsu.UsuSemestre = txtSemestreEst_Ext.Text; // "99";
                    }
                    else if (SesionUsu.TipoParticipante == "E")
                    {

                        ObjParticipante.APaterno = txtPaterno_Gral.Text;
                        ObjParticipante.AMaterno = txtMaterno_Gral.Text;
                        ObjParticipante.Nombre = txtNombre_Gral.Text.ToUpper();
                        ObjParticipante.Evento = SesionUsu.UsuEvento;
                        ObjParticipante.Genero = Convert.ToChar(rdoGenero_Gral.SelectedValue);
                        ObjParticipante.TelParticular = txtTelefono_Gral.Text;
                        ObjParticipante.Celular = txtCel_Gral.Text;
                        ObjParticipante.Correo = txtCorreo_Gral.Text.ToUpper();
                        ObjParticipante.GradoEstudio = ddlGrado_Max_Est_Gral.Text;
                        ObjParticipante.Dependencia = txtInstitucion_Gral.Text; //DDLEscuela.SelectedValue;
                        ObjParticipante.CargoProcedencia = txtCargo_Puesto.Text;
                        ObjParticipante.DomicilioProcedencia = txtDomicilio_Gral.Text;
                        ObjParticipante.CiudadProcedencia = txtCiudad_Gral.Text;
                        ObjParticipante.EstadoProcedencia = ddlEdo_Provincia_Gral.SelectedValue;
                        ObjParticipante.Colonia = txtColonia_Gral.Text;
                        ObjParticipante.CP = txtCP_Gral.Text;
                        ObjParticipante.Constancia = txtConstancia.Text.ToUpper();
                        //ObjParticipante.Ponencia1 = txtPonencia1.Text.ToUpper();
                        //ObjParticipante.Ponencia2 = txtPonencia2.Text.ToUpper();
                        ObjParticipante.Donativo = "0";
                        ObjParticipante.PeriodoPago = Convert.ToInt32(ddlPeriodo_Pago__Gral.SelectedValue);
                        SesionUsu.PeriodoPago = ddlPeriodo_Pago__Gral.SelectedItem.Text;
                        //SesionUsu.MatriculaCapturada = txtMatricula2.Text;
                        SesionUsu.UsuGrupo = "X";
                        SesionUsu.UsuSemestre = "99";
                    }
                    else
                    {

                        ObjParticipante.APaterno = txtPaterno_Gral.Text.ToUpper();
                        ObjParticipante.AMaterno = txtMaterno_Gral.Text.ToUpper();
                        ObjParticipante.Nombre = txtNombre_Gral.Text.ToUpper();
                        ObjParticipante.Evento = SesionUsu.UsuEvento;
                        ObjParticipante.Genero = Convert.ToChar(rdoGenero_Gral.SelectedValue);
                        ObjParticipante.TelParticular = txtTelefono_Gral.Text;
                        ObjParticipante.Celular = txtCel_Gral.Text;
                        ObjParticipante.Correo = txtCorreo_Gral.Text.ToUpper();
                        ObjParticipante.GradoEstudio = ddlGrado_Max_Est_Gral.SelectedValue;
                        ObjParticipante.Dependencia = txtInstitucion_Gral.Text.ToUpper();
                        ObjParticipante.CargoProcedencia = txtCargo_Puesto.Text.ToUpper();
                        ObjParticipante.DomicilioProcedencia = txtDomicilio_Gral.Text.ToUpper();
                        ObjParticipante.CiudadProcedencia = txtCiudad_Gral.Text.ToUpper();
                        ObjParticipante.EstadoProcedencia = ddlEdo_Provincia_Gral.SelectedValue;
                        ObjParticipante.Colonia = txtColonia_Gral.Text.ToUpper();
                        ObjParticipante.CP = txtCP_Gral.Text.ToUpper();
                        ObjParticipante.Constancia = txtConstancia.Text.ToUpper();
                        ObjParticipante.Donativo = "0";
                        ObjParticipante.PeriodoPago = Convert.ToInt32(ddlPeriodo_Pago__Gral.SelectedValue);
                        //ObjParticipante.Ponencia1 = "";
                        //ObjParticipante.Ponencia2 = "";
                        SesionUsu.PeriodoPago = ddlPeriodo_Pago__Gral.SelectedItem.Text;
                        SesionUsu.UsuGrupo = "X";
                        SesionUsu.UsuSemestre = "99";

                    }
                    if (SesionUsu.Operacion == "I")
                        CNParticipante.InsertarParticipante(ref ObjParticipante, ref Verificador);
                    else
                        CNParticipante.ActualizarParticipante(ref ObjParticipante, ref Verificador);

                    SesionUsu.Donativo = ObjParticipante.Donativo;
                    SesionUsu.UsuNivel = "L";
                }
                if (Verificador == "0")
                {

                    SesionUsu.UsuNombre = ObjParticipante.Nombre;
                    SesionUsu.UsuApaterno = ObjParticipante.APaterno;
                    SesionUsu.UsuAMaterno = ObjParticipante.AMaterno;
                    SesionUsu.UsuTelefono = ObjParticipante.TelParticular;

                    if (String.IsNullOrEmpty(ObjAlumno.Correo))
                        SesionUsu.UsuCorreo = ObjParticipante.Correo;
                    else
                        SesionUsu.UsuCorreo = ObjAlumno.Correo;
                    //SesionUsu.UsuCorreo = (String.IsNullOrEmpty(ObjAlumno.Correo)) ? (String.IsNullOrEmpty(ObjParticipante.Correo))?"": ObjParticipante.Correo : ObjAlumno.Correo;

                    //SesionUsu.UsuEvento = ObjParticipante.Evento;
                    // la dependencia del evento se ingreso desde inicializar
                    SesionUsu.TipoPersona = Convert.ToInt32(ddlTipo_Participante.SelectedValue);
                    SesionUsu.TipoPersonaStr = ddlTipo_Participante.SelectedItem.Text;

                    if (SesionUsu.Id_Comprobante == 1) //(SesionUsu.StatusAC != "C") //SesionUsu.Id_Comprobante = 0
                    {
                        if (SesionUsu.UsuEvento != string.Empty)
                        {
                            if (SesionUsu.UsuWXI != "X")
                                Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                            else
                                Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento);
                        }
                        else
                            Response.Redirect("Registro_Participantes_P2.aspx");
                    }
                    else
                    {

                        if (SesionUsu.UsuWXI == "X")
                        {
                            if (ddlTipo_Participante.SelectedValue == "1")
                            {
                                EnviarCorreoActivacion(SesionUsu.UsuMatricula, SesionUsu.UsuNivel);
                                btnSiguiente.Enabled = false;
                            }
                            else
                            {
                                /*
                                if(SesionUsu.ComponentesExtras == "S")
                                    Response.Redirect("Registro_Participantes_Extra.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                                else
                                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);*/

                                //TextBox txt = pnlExtras.FindControl("txtEdad") as TextBox;
                                //var valor = txt.Text;
                                if(SesionUsu.ComponentesExtras == "S")
                                    ObtenerValoresComponentesExtras();

                                Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);


                            }
                        }
                        else
                            Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);

                    }


                }
                else
                    lblMsj2.Text = "No se pudo agregar sus datos.- " + Verificador;




            }
            catch (Exception ex)
            {
                //lblMsj.Text = ex.Message;
                lblMsj2.Text = ex.Message;
            }

        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatricula.Enabled = true;
            imgBttnBuscar.Enabled = true;
            ddlNivel.Enabled = true;
            SesionUsu = (Sesion)Session["SesionFicha"];

            string var = SesionUsu.UsuEvento;
            SesionUsu.UsuWXI = "X";
            if (Request.QueryString["WXI"] != null)
            {
                SesionUsu.UsuWXI = Request.QueryString["WXI"];

            }
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            if (var != string.Empty)
            {
                if (SesionUsu.UsuWXI != "X")
                    Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var + "&WXI=" + SesionUsu.UsuWXI);
                else
                    Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var);
            }
            else
                Response.Redirect("Registro_Participantes.aspx");
        }

        #endregion
        #region <Funciones y Sub>
        private void Inicializar()
        {
            //SesionUsu = (Sesion)Session["Sesion"];
            lblMsj.Text = string.Empty;
            rowError.Visible = false;
            //lblEspecificaciones.Visible = false;
            rowEspecificaciones.Visible = false;
            try
            {
                Session["ConfTipoPart"] = null;
                pnlMsjReg.Visible = false;
                lblMsjReg.Text = string.Empty;
                if (SesionUsu == null)
                {
                    SesionUsu = new Sesion();
                    SesionUsu.FichaReferencia = string.Empty;
                }

                SesionUsu.NuevoReg = "N";
                //SesionUsu.UsuEvento_Exclusivo = "N";
                if (Request.QueryString["Evento"] != null)
                {
                    SesionUsu.UsuEvento = Request.QueryString["Evento"];
                    ObjParticipante.Evento = SesionUsu.UsuEvento;

                    CNParticipante.ConsultarEvento(ref ObjParticipante, ref Verificador);
                    if (ObjParticipante.StatusEvento == 'N')
                    {
                        //SesionUsu.UsuEvento = "ALUMNO";
                        rowError.Visible = true;
                        lblMsj.Text = "El Evento no esta Vigente, favor de comunicarse con el administrador de la Dependencia";
                        //pnlEstudianteUNACH_RegMatricula.Visible = false;
                        pnlEstudianteUNACH_RegMatricula.Visible = false;
                        pnlEmpUNACH.Visible = false;
                        pnlParticipante_Gral.Visible = false;
                        pnlEstudianteUNACH.Visible = false;
                        pnlEstudianteExterno.Visible = false;
                        pnlConstancia.Visible = false;

                        ddlTipo_Participante.Enabled = false;
                        btnSiguiente.Visible = false;
                        btnCancelar.Visible = false;
                    }
                    else
                    {
                        rowError.Visible = false;
                        lblMsj.Text = string.Empty;
                        ddlTipo_Participante.Visible = false;
                        lblTipo_Participante.Visible = false;
                        if (SesionUsu.UsuEvento != "ALUMNO")
                            if (SesionUsu.UsuEvento != "EXTRAORDINARIO")
                                if (SesionUsu.UsuEvento != "VERANO")
                                    if (SesionUsu.UsuEvento != "POSGRADO")
                                        if (SesionUsu.UsuEvento != "LIBRE")
                                            if (SesionUsu.UsuEvento != "SUPERADMON")
                                                if (SesionUsu.UsuEvento != "ADMON")
                                                {
                                                    SesionUsu.UsuDependencia = ObjParticipante.Dependencia;
                                                    ddlTipo_Participante.Visible = true;
                                                    lblTipo_Participante.Visible = true;
                                                }

                        //pnlParticipante_Gral.Visible = true;
                        //pnlParticiante_Interno.Visible = true;
                        //pnlPonente.Visible = true;
                        ddlTipo_Participante.Enabled = true;
                        btnSiguiente.Visible = false;
                        btnCancelar.Visible = false;

                        lblEvento.Text = ObjParticipante.EventoStr;
                        SesionUsu.UsuEvento_Exclusivo = ObjParticipante.Evento_Exclusivo;

                        if (ObjParticipante.EventoEspecificacion != "" || ObjParticipante.EventoEspecificacion != string.Empty)
                        {
                            //lblEspecificacionesLey.Visible = true; 02/07
                            rowEspecificaciones.Visible = true;
                            lblEspecificaciones.Text = ObjParticipante.EventoEspecificacion;
                        }
                        else
                        {
                            //lblEspecificacionesLey.Visible = false;  02/07
                            rowEspecificaciones.Visible = false;
                            lblEspecificaciones.Text = string.Empty;
                        }

                        if (ObjParticipante.ComponentesExtras == "S")
                            SesionUsu.ComponentesExtras = "S";
                        else
                            SesionUsu.ComponentesExtras = "N";

                        CargarCombos();
                        InicializarTipoParticipante();
                        txtMatricula.Focus();
                    }
                }
                else
                {
                    SesionUsu.UsuEvento = "ALUMNO";
                    ddlTipo_Participante.Visible = false;
                    lblTipo_Participante.Visible = false;
                    pnlEstudianteUNACH_RegMatricula.Visible = true;
                    //lblEspecificacionesLey.Visible = false;  02/07
                    rowEspecificaciones.Visible = false;
                    lblEspecificaciones.Text = string.Empty;
                    //SesionUsu.TipoParticipante = "S";
                    CargarCombos();
                    InicializarTipoParticipante();
                    txtMatricula.Focus();
                }

                //CargarCombos();
                //if (SesionUsu.FichaRefID != 0)
                //{

                //    ddlTipo_Participante.SelectedValue = SesionUsu.TipoPersona.ToString();
                //    ddlTipo_Participante_SelectedIndexChanged(null, null);
                //    if (SesionUsu.TipoParticipante == "S")
                //    {
                //        txtMatricula.Text = SesionUsu.UsuMatricula;
                //        ddlNivel_SelectedIndexChanged(null, null);
                //    }
                //    else if (SesionUsu.TipoParticipante == "E")
                //    {
                //        txtNombre_Gral.Text = SesionUsu.UsuNombre;
                //        txtPaterno_Gral.Text = SesionUsu.UsuApaterno;
                //        txtMaterno_Gral.Text = SesionUsu.UsuAMaterno;
                //        txtMaterno_Gral_TextChanged(null, null);
                //    }
                //    else if (SesionUsu.TipoParticipante == "SX") //Estudiante Externo
                //    {
                //        txtNombreEst_Ext.Text = SesionUsu.UsuNombre;
                //        txtMaternoEst_Ext.Text = SesionUsu.UsuAMaterno;
                //        txtPaternoEst_Ext.Text = SesionUsu.UsuApaterno;
                //        txtMaternoEst_Ext_TextChanged(null, null);
                //    }
                //    else //Público General
                //    {
                //        txtNombre_Gral.Text = SesionUsu.UsuNombre;
                //        txtPaterno_Gral.Text = SesionUsu.UsuApaterno;
                //        txtMaterno_Gral.Text = SesionUsu.UsuAMaterno;
                //        txtMaterno_Gral_TextChanged(null, null);
                //    }

                //}
                //else
                //{
                //    ddlTipo_Participante_SelectedIndexChanged(null, null);
                //    SesionUsu.TipoPersona = Convert.ToInt32(ddlTipo_Participante.SelectedValue);
                //    Session["SesionFicha"] = SesionUsu;
                //    Session.Timeout = 20;
                //}
                
                //txtMatricula.Focus();
            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }

        private void InicializarTipoParticipante()
        {
            rowError.Visible = false;
            try
            {
                if (SesionUsu.FichaRefID != 0)
                {

                    ddlTipo_Participante.SelectedValue = SesionUsu.TipoPersona.ToString();
                    ddlTipo_Participante_SelectedIndexChanged(null, null);
                    if (SesionUsu.TipoParticipante == "S")
                    {
                        txtMatricula.Text = SesionUsu.UsuMatricula;
                        ddlNivel_SelectedIndexChanged(null, null);
                    }
                    else if (SesionUsu.TipoParticipante == "E")
                    {
                        txtNombre_Gral.Text = SesionUsu.UsuNombre;
                        txtPaterno_Gral.Text = SesionUsu.UsuApaterno;
                        txtMaterno_Gral.Text = SesionUsu.UsuAMaterno;
                        txtMaterno_Gral_TextChanged(null, null);
                        // "gpoPonente";
                    }
                    else if (SesionUsu.TipoParticipante == "SX") //Estudiante Externo
                    {
                        txtNombreEst_Ext.Text = SesionUsu.UsuNombre;
                        txtMaternoEst_Ext.Text = SesionUsu.UsuAMaterno;
                        txtPaternoEst_Ext.Text = SesionUsu.UsuApaterno;
                        txtMaternoEst_Ext_TextChanged(null, null);
                        //DDLEscuela.SelectedValue = SesionUsu.UsuDependencia;
                        //"gpoInternoSMatricula";
                    }
                    else //Público General
                    {
                        txtNombre_Gral.Text = SesionUsu.UsuNombre;
                        txtPaterno_Gral.Text = SesionUsu.UsuApaterno;
                        txtMaterno_Gral.Text = SesionUsu.UsuAMaterno;
                        txtMaterno_Gral_TextChanged(null, null);
                    }

                }
                else
                {
                    ddlTipo_Participante_SelectedIndexChanged(null, null);
                    SesionUsu.TipoPersona = Convert.ToInt32(ddlTipo_Participante.SelectedValue);
                    Session["SesionFicha"] = SesionUsu;
                    Session.Timeout = 20;
                    // SesionUsu.Operacion = "I";
                }
            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        private void CargarComponentesExtras()
        {
            pnlExtras.Visible = true;

            Componente ObjComponente = new Componente();
            ObjComponente.Evento = SesionUsu.UsuEvento;
            List<Componente> lstComponentes = new List<Componente>();
            CNParticipante.ConsultarEvento_Extras(ObjComponente, ref lstComponentes);
            if (lstComponentes.Count > 0)
            {
                Session["ComponentesExtras"] = lstComponentes;
                Panel divColuna = new Panel();

                foreach (Componente lst in lstComponentes)
                {
                    string caseSwitch = lst.Control;
                    Panel panel2 = new Panel();
                    switch (caseSwitch)
                    {
                        case "LABEL":
                            Label lblDinamico1 = new Label();
                            lblDinamico1.ID = lst.IdControl;
                            EnsureChildControls();
                            //panel2.Controls.Add(lblDinamico1);
                            pnlExtras.Controls.Add(lblDinamico1);
                            lblDinamico1.Text = lst.Text;                            
                            break;
                        case "TEXTBOX":
                            TextBox txtDinamico1 = new TextBox();
                            txtDinamico1.ID = lst.IdControl;                            
                            if (lst.Style_Key!=string.Empty && lst.Style_Value != string.Empty)
                                txtDinamico1.Style.Add(lst.Style_Key, lst.Style_Value);
                            EnsureChildControls();
                            panel2.Controls.Add(txtDinamico1);
                            pnlExtras.Controls.Add(panel2);

                            break;                        
                        case "SELECT":
                            DropDownList ddlDinamico1 = new DropDownList();
                            ddlDinamico1.ID = lst.IdControl;
                            CNComun.LlenaCombo("pkg_pagos_2016.OBT_Elementos_Control", ref ddlDinamico1, "p_id_control", Convert.ToString(lst.IdComponente));
                            //pnlExtras.Controls.Add(ddlDinamico1);
                            panel2.Controls.Add(ddlDinamico1);
                            pnlExtras.Controls.Add(panel2);
                            break;
                        case "REQUIRED":
                            RequiredFieldValidator requerido1 = new RequiredFieldValidator();
                            requerido1.ID = lst.IdControl;
                            requerido1.ControlToValidate = lst.IdControlValida;
                            requerido1.Text = "*Requerido";
                            requerido1.ErrorMessage = "*Requerido";
                            requerido1.ForeColor = System.Drawing.Color.Red;
                            //requerido1.ForeColor = "Red";
                            if (SesionUsu.TipoParticipante == "SX")
                                requerido1.ValidationGroup = "gpoInternoSM";

                            EnsureChildControls();
                            panel2.Controls.Add(requerido1);
                            pnlExtras.Controls.Add(panel2);

                            //pnlExtras.Controls.Add(requerido1);
                            break;
                    }
                }
            }
        }
        private void ObtenerValoresComponentesExtras()
        {
            List<Componente> lstComponentes = new List<Componente>();
            lstComponentes = (List<Componente>)Session["ComponentesExtras"];
            Session["ValoresComponentesExtras"] = null;
            if (lstComponentes.Count > 0)
            {
                //int i = 1;
                foreach (Componente lst in lstComponentes)
                {
                    string caseSwitch = lst.Control;
                    List<Componente> lstComponentesGuardar = new List<Componente>();
                    Componente objComponentes = new Componente();

                    switch (caseSwitch)
                    {
                        case "TEXTBOX":
                            TextBox txt = pnlExtras.FindControl(lst.IdControl) as TextBox;
                            objComponentes.IdControl = lst.IdControl;
                            objComponentes.Valor = txt.Text;
                            break;
                        //case "LABEL":
                        //    Label lbl = pnlExtras.FindControl(lst.IdControl) as Label;
                        //    lstComponentesGuardar[i].IdControl = lst.IdControl;
                        //    lstComponentesGuardar[i].Text = lst.Text;
                        //    break;
                        case "SELECT":
                            DropDownList ddl = pnlExtras.FindControl(lst.IdControl) as DropDownList;
                            objComponentes.IdControl = lst.IdControl;
                            objComponentes.Valor = ddl.SelectedValue;
                            break;
                    }
                    if (lst.Control == "TEXTBOX" || lst.Control == "SELECT")
                    {
                        if (Session["ValoresComponentesExtras"] != null)
                            lstComponentesGuardar = (List<Componente>)Session["ValoresComponentesExtras"];

                        lstComponentesGuardar.Add(objComponentes);
                        Session["ValoresComponentesExtras"] = lstComponentesGuardar;
                    }
                }
            }

            //if(lstComponentesGuardar.Count>0)            
            //    Session["ComponentesExtras"] = lstComponentesGuardar;
            
        }    
    
    private void CargarCombos()
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {
                CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Tipo_Persona", ref ddlTipo_Participante, "p_evento", SesionUsu.UsuEvento, ref ListTipoPartcipante);
                Session["ConfTipoPart"] = ListTipoPartcipante;
                CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Grado_Estudio", ref ddlGrado_Max_Est_Gral, "p_evento", SesionUsu.UsuEvento);
                //CNComun.LlenaCombo("pkg_pagos_2016.Obt_Combo_Grado_Estudio", ref ddlNivel_Ext, "p_evento", SesionUsu.UsuEvento);
                CargarComboBasicos("pkg_pagos.Obt_Combo_Estados_Mex", ref ddlEdo_Provincia_Gral);
                CargarCombo("pkg_pagos.Obt_Combo_Periodo_Pago", ref ddlPeriodo_Pago__Gral, "p_evento", SesionUsu.UsuEvento);
                CargarCombo("pkg_pagos.Obt_Combo_Periodo_Pago", ref ddlPeriodo_Pago_I, "p_evento", SesionUsu.UsuEvento);
                CargarCombo("pkg_pagos.Obt_Combo_Periodo_Pago", ref ddlPeriodo_Pago_ISM, "p_evento", SesionUsu.UsuEvento);

            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        private void CargarComboBasicos(string SP, ref DropDownList Combo)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarCombo(string SP, ref DropDownList Combo, string Parametro, string Valor)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, Parametro, Valor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarCombo(string SP, ref DropDownList Combo, string Parametro1, string Parametro2, string Valor1, string Valor2)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, Parametro1, Parametro2, Valor1, Valor2);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarCombo(string SP, ref DropDownList Combo, string Parametro1, string Parametro2, string Parametro3, string Parametro4, string Valor1, string Valor2, string Valor3, string Valor4)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, Parametro1, Parametro2, Parametro3, Parametro4, Valor1, Valor2, Valor3, Valor4);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void EnviarCorreoActivacion(string Matricula, string Nivel)
        {
            string ruta = string.Empty;
            string asunto = string.Empty;
            string contenido = string.Empty;
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                ruta = "https://sysweb.unach.mx/FichaReferenciada/Form/Activacion_Cuenta.aspx?ActCtaM=" + Matricula + "&ActCtaN=" + Nivel;
                asunto = "Confirma tu correo/Activa tu cuenta - SYSWEB";
                contenido = "<img src='https://sysweb.unach.mx/resources/imagenes/logo_sysweb400px.png'><br /><div align=center><font size='4'><a href=\'" + ruta + "'>Pagos Referenciados SYSWEB</a></font></div><br /><br />" + "<font size='2'>Se ha generado un usuario para el Sistema de Pagos Referenciados SYSWEB con esta dirección de correo electrónico.</br>" +
                            "Si tú hiciste esta solicitud, haz clic en el enlace de abajo para confirmar tu dirección de correo electrónico, activar tu cuenta y conlcuir tu proceso de registro:</br>" +
                            "<a href=\'" + ruta + "'>Confirmar tu dirección de correo electrónico </a></br></br>" +
                            "Si tú no realizaste esta solicitud, ignora este correo electrónico y no recibirás mas notificaciones al respecto.</br></br>" +
                            "<strong>SYSWEB - DIRECCIÓN DE SISTEMAS DE INFORMACIÓN ADMINISTRATIVA</strong>" +
                            "<br />Teléfono - (961) 617 80 00, Ext.: 5503, 5501, 5508 y 5509<br /><br /></font>";
                string MsjError = string.Empty;
                CNComun.EnvioCorreo(ref mmsg, asunto, contenido, txtCorreo0.Text, ref MsjError);
                if (MsjError == string.Empty)
                {
                    //Enviamos el mensaje      
                    if (mmsg != null)
                    {
                        lblMsj2.Text = "<div class='mensaje_rojo'>POR FAVOR ACTIVA TU CUENTA:</br></br><font color=#000000>Hemos enviado un correo electrónico a </br><strong>" + txtCorreo0.Text + "</strong> para que realices la activación de tu cuenta y comiences a realizar tus pagos SYSWEB.</font></br></br><strong>Si no recibes el correo de confirmación puedes comunicarte al teléfono 61 7 80 00, Ext.: 5503, 5501, 5508 y 5509</strong></div>";
                    }
                }
                else
                {
                    lblMsj2.Text = "<div class='mensaje_rojo'>El correo no pudo ser enviado, puedes activar tu cuenta dando click al siguiente enlace </br></br><a href=" + ruta + ">Confirmar cuenta</a></div>";
                    //MsjError; // "El correo no pudo ser enviado, intentelo más tarde";
                }
            }
            catch (Exception ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                lblMsj2.Text = ex.Message;
            }

        }
        #endregion

        //protected void btnBusca_Matricula_Click(object sender, EventArgs e)
        //{
        //    txtMatricula_TextChanged(null,null);            
        //}





        //protected void txtNombre_TextChanged(object sender, EventArgs e)
        //{
        //    if (SesionUsu.UsuEvento == "PLANES_2016" || SesionUsu.UsuEvento == "PLANES_2017")
        //    {
        //        txtPaterno_Gral.Text = ".";
        //        txtMaterno_Gral.Text = ".";
        //        txtMaterno_TextChanged(null, null);
        //    }
        //}

        protected void imgBttnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {
                CNComun.LlenaLista("pkg_pagos_2016.Obt_Combo_Nivel_Alumno", ref ddlNivel, "p_matricula", "p_evento", txtMatricula.Text.ToUpper(), SesionUsu.UsuEvento);
                if (ddlNivel.Items.Count == 1 && SesionUsu.UsuEvento_Exclusivo=="N")
                {
                    btnRegistrar.Visible = true;
                    pnlMsjReg.Visible = true;
                    //lblMsjReg.Text = "Dato no encontrado, si deseas registralo dar click por única vez.";
                    lblNivel.Visible = false;
                    ddlNivel.Visible = false;
                    //btnSiguiente.Visible = false;
                    ddlNivel.DataSource = null;
                    ddlNivel.DataBind();
                }
                else
                {
                    btnRegistrar.Visible = false;
                    pnlMsjReg.Visible = false;
                    //lblMsjReg.Text = string.Empty;
                    lblNivel.Visible = true;
                    ddlNivel.Visible = true;
                    //btnSiguiente.Visible = true;
                }
            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }

        protected void ddlDependencia_D_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {
                if (ddlNivel.SelectedValue != string.Empty /*&& ddlDependencia_D.SelectedValue != "0"*/)
                {
                    CNComun.LlenaCombo("PKG_PAGOS_2016.Obt_Combo_Carrera_Posgrado", ref ddlCarrera, "p_nivel", "p_dependencia", ddlNivel.SelectedValue, ddlDependencia_D.SelectedValue);
                    if (ddlCarrera.Items.Count >= 1)
                    {
                        ddlCarrera.SelectedIndex = 0;
                        ddlCarrera_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }

        protected void txtMatricula_TextChanged(object sender, EventArgs e)
        {
            imgBttnBuscar.Focus();
        }

        protected void txtMaterno_Gral_TextChanged(object sender, EventArgs e)
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {
                SesionUsu = (Sesion)Session["SesionFicha"];
                ObjParticipante.APaterno = txtPaterno_Gral.Text.ToUpper();
                ObjParticipante.AMaterno = Server.HtmlEncode(txtMaterno_Gral.Text.ToUpper());
                ObjParticipante.Nombre = txtNombre_Gral.Text.ToUpper();
                ObjParticipante.Evento = SesionUsu.UsuEvento;
                CNParticipante.ConsultarParticipante(ref ObjParticipante, ref Verificador);
                if (Verificador == "0")
                {
                    if (ObjParticipante.Operacion == "U")
                    {
                        ddlPeriodo_Pago__Gral.SelectedValue = Convert.ToString(ObjParticipante.PeriodoPago);
                        rdoGenero_Gral.SelectedValue = Convert.ToString(ObjParticipante.Genero);
                        ddlEdo_Provincia_Gral.SelectedValue = ObjParticipante.EstadoProcedencia;
                        txtCiudad_Gral.Text = ObjParticipante.CiudadProcedencia;
                        txtDomicilio_Gral.Text = ObjParticipante.DomicilioProcedencia;
                        txtColonia_Gral.Text = ObjParticipante.Colonia;
                        txtCP_Gral.Text = ObjParticipante.CP;
                        txtTelefono_Gral.Text = ObjParticipante.TelParticular;
                        txtCel_Gral.Text = ObjParticipante.Celular;
                        txtInstitucion_Gral.Text = ObjParticipante.Dependencia;
                        txtCargo_Puesto.Text = ObjParticipante.CargoProcedencia;
                        try
                        {
                            ddlGrado_Max_Est_Gral.SelectedValue = ObjParticipante.GradoEstudio;
                        }
                        catch
                        {
                            ddlGrado_Max_Est_Gral.SelectedIndex = 0;
                        }
                        txtCorreo_Gral.Text = ObjParticipante.Correo;
                        txtConstancia.Text = ObjParticipante.Constancia;
                        txtPonencia1.Text = (SesionUsu.Ponente == "S") ? ObjParticipante.Ponencia1 : string.Empty;
                        txtPonencia2.Text = (SesionUsu.Ponente == "S") ? ObjParticipante.Ponencia2 : string.Empty;

                    }
                    else
                    {
                        rdoGenero_Gral.SelectedValue = "M";
                        txtTelefono_Gral.Text = string.Empty;
                        txtCel_Gral.Text = string.Empty;
                        txtCorreo_Gral.Text = string.Empty;
                        //ddlGrado_Max_Est.SelectedValue = "ESTUDIANTE";
                        ddlGrado_Max_Est_Gral.SelectedIndex = 0; // "ESTUDIANTE";
                        txtInstitucion_Gral.Text = string.Empty;
                        txtCargo_Puesto.Text = string.Empty;
                        txtDomicilio_Gral.Text = string.Empty;
                        txtCiudad_Gral.Text = string.Empty;
                        ddlEdo_Provincia_Gral.SelectedValue = "CHIAPAS";
                        txtColonia_Gral.Text = string.Empty;
                        txtCP_Gral.Text = string.Empty;
                        txtConstancia.Text = string.Empty;
                        ddlPeriodo_Pago__Gral.SelectedValue = "20";
                        txtConstancia.Text = txtNombre_Gral.Text.Trim() + " " + txtPaterno_Gral.Text.Trim() + " " + txtMaterno_Gral.Text.Trim();
                    }
                }
                else
                {
                    rowError.Visible = true;
                    lblMsj.Text = Verificador;
                }
                SesionUsu.Operacion = ObjParticipante.Operacion;
                SesionUsu.UsuMatricula = ObjParticipante.NoControl;

            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }

        protected void txtMaternoEst_Ext_TextChanged(object sender, EventArgs e)
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {                
                SesionUsu = (Sesion)Session["SesionFicha"];
                ObjParticipante.APaterno = txtPaternoEst_Ext.Text;
                ObjParticipante.AMaterno = txtMaternoEst_Ext.Text;
                ObjParticipante.Nombre = txtNombreEst_Ext.Text.ToUpper();
                ObjParticipante.Evento = SesionUsu.UsuEvento;

                CNParticipante.ConsultarParticipante(ref ObjParticipante, ref Verificador);
                if (Verificador == "0")
                {
                    if (ObjParticipante.Operacion == "U")
                    {
                        rdoGeneroEst_Ext.SelectedValue = Convert.ToString(ObjParticipante.Genero);
                        txtCorreoEst_Ext.Text = ObjParticipante.Correo;
                        txtConstancia.Text = ObjParticipante.Constancia;
                        ddlPeriodo_Pago_ISM.SelectedValue = Convert.ToString(ObjParticipante.PeriodoPago);
                    }
                    else
                    {
                        rdoGeneroEst_Ext.SelectedValue = "M";
                        txtCorreoEst_Ext.Text = string.Empty;
                        txtConstancia.Text = txtNombreEst_Ext.Text.Trim() + " " + txtPaternoEst_Ext.Text.Trim() + " " + txtMaternoEst_Ext.Text.Trim(); ;
                        txtGrupoEst_Ext.Text = string.Empty;
                        txtSemestreEst_Ext.Text = string.Empty;
                        ddlPeriodo_Pago_ISM.SelectedValue = "20";

                    }
                }
                else
                {
                    rowError.Visible = true;
                    lblMsj.Text = Verificador;
                }
                SesionUsu.Operacion = ObjParticipante.Operacion;
                SesionUsu.UsuMatricula = ObjParticipante.NoControl;

            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }


        }

        protected void txtNombre_Gral_TextChanged(object sender, EventArgs e)
        {
            if (SesionUsu.UsuEvento == "PLANES_2016" || SesionUsu.UsuEvento == "PLANES_2017")
            {
                txtPaterno_Gral.Text = ".";
                txtMaterno_Gral.Text = ".";
                txtMaterno_Gral_TextChanged(null, null);
            }

        }

        protected void lstTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pnlEmpUNACH.Visible = false;

            pnlParticipante_Gral.Visible = true;
            pnlEstudianteUNACH_RegMatricula.Visible = false;
            pnlEstudianteUNACH.Visible = false;
            pnlPonente.Visible = false;

            pnlEstudianteExterno.Visible = false;
            ObjParticipante.NumPlaza = txtNumPlaza.Text;
            ObjParticipante.TipoPersonal = lstTipoPersonal.SelectedValue;
            CNParticipante.ConsultarParticipanteEmpleado(ref ObjParticipante, ref Verificador);
            if (Verificador == "0")
            {
                txtNombre_Gral.Text = ObjParticipante.Nombre.ToUpper();
                txtPaterno_Gral.Text = ObjParticipante.APaterno.ToUpper();
                txtMaterno_Gral.Text = ObjParticipante.AMaterno.ToUpper();
                btnSiguiente.Visible = true;
                btnSiguiente.Enabled = true;
                btnCancelar.Visible = true;

                txtMaterno_Gral_TextChanged(null, null);
                if (SesionUsu.RequiereConstancia == "S")
                    pnlConstancia.Visible = true;

                if (SesionUsu.Ponente == "S")
                    pnlPonente.Visible = true;


            }
            else
            {
                pnlMsjReg2.Visible = true;
                pnlParticipante_Gral.Visible = false;
                pnlConstancia.Visible = false;
                txtConstancia.Text = string.Empty;
                LimpiarDatosPublicoGral();
                lblMsjReg2.Text = "No se encontro ningún dato, puede intentar con otro tipo de participante.";
            }

        }

        protected void LimpiarDatosPublicoGral()
        {
            txtNombre_Gral.Text = string.Empty;
            txtPaterno_Gral.Text = string.Empty;
            txtMaterno_Gral.Text = string.Empty;
            txtCiudad_Gral.Text = string.Empty;
            txtDomicilio_Gral.Text = string.Empty;
            txtColonia_Gral.Text = string.Empty;
            txtCP_Gral.Text = string.Empty;
            txtTelefono_Gral.Text = string.Empty;
            txtCel_Gral.Text = string.Empty;
            txtInstitucion_Gral.Text = string.Empty;
            txtCargo_Puesto.Text = string.Empty;
            txtCorreo_Gral.Text = string.Empty;
        }

        protected void bttnBuscaPlaza_Click(object sender, ImageClickEventArgs e)
        {
            lblMsj.Text = string.Empty;
            rowError.Visible = false;
            try
            {
                CNComun.LlenaLista("PKG_PAGOS_2016.Obt_Combo_Tipo_Empleado", ref lstTipoPersonal, "p_plaza", txtNumPlaza.Text);
                if (lstTipoPersonal.Items.Count > 1)
                {
                    pnlMsjReg2.Visible = false;
                    lblMsjReg2.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;

            }

        }

        protected void txtMaternoReg_TextChanged(object sender, EventArgs e)
        {
            rowError.Visible = false;
            lblMsj.Text = string.Empty;
            try
            {                
                SesionUsu = (Sesion)Session["SesionFicha"];
                ObjParticipante.APaterno = txtPaternoReg.Text;
                ObjParticipante.AMaterno = txtMaternoReg.Text;
                ObjParticipante.Nombre = txtNombreReg.Text.ToUpper();
                ObjParticipante.Evento = SesionUsu.UsuEvento;

                CNParticipante.ConsultarParticipante(ref ObjParticipante, ref Verificador);
                if (Verificador == "0")
                {
                    if (ObjParticipante.Operacion == "U")
                    {
                        rdoGeneroI.SelectedValue = Convert.ToString(ObjParticipante.Genero);
                        txtCorreo0.Text = ObjParticipante.Correo;
                        txtConstancia.Text = ObjParticipante.Constancia;
                        ddlPeriodo_Pago_ISM.SelectedValue = Convert.ToString(ObjParticipante.PeriodoPago);
                    }
                    else
                    {
                        rdoGeneroEst_Ext.SelectedValue = "M";
                        txtCorreoEst_Ext.Text = string.Empty;
                        txtConstancia.Text = txtNombreEst_Ext.Text.Trim() + " " + txtPaternoEst_Ext.Text.Trim() + " " + txtMaternoEst_Ext.Text.Trim(); ;
                        txtGrupoEst_Ext.Text = string.Empty;
                        txtSemestreEst_Ext.Text = string.Empty;
                        ddlPeriodo_Pago_ISM.SelectedValue = "20";

                    }
                }
                else
                {
                    rowError.Visible = true;
                    lblMsj.Text = Verificador;
                }
                SesionUsu.Operacion = ObjParticipante.Operacion;
                SesionUsu.UsuMatricula = ObjParticipante.NoControl;

            }
            catch (Exception ex)
            {
                rowError.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }

        protected void linkBttnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnLimpiar_Click(null, null);
        }
    }

}