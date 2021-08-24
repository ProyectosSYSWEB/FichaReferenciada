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
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes_P3 : System.Web.UI.Page
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
        FichaReferenciada ObjFichaReferenciada = new FichaReferenciada();
        CN_FichaReferenciada CNFichaReferenciada = new CN_FichaReferenciada();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            if (SesionUsu != null)
            {
                if (!IsPostBack)                
                    Inicializar();                
            }
            else
                Response.Redirect("https://sysweb.unach.mx/");
        }
        #region <Botones y Eventos>

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            UpdateFichaReferenciada(ref Verificador);
            if (Verificador == "0")
            {
                if (SesionUsu.UsuEvento != string.Empty)
                {
                    if (SesionUsu.UsuWXI != "X")
                        Response.Redirect("Registro_Participantes_P5.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                    else if (SesionUsu.UsuWXIAdmon != "X")
                        Response.Redirect("Registro_Participantes_P5.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                    else
                        Response.Redirect("Registro_Participantes_P5.aspx" + "?Evento=" + SesionUsu.UsuEvento);
                }
                else
                    Response.Redirect("Registro_Participantes_P5.aspx");
            }
            else
                lblMsj.Text = Verificador;

        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {

            SesionUsu.FichaComprobanteFiscal = rdoBttnFactFis.SelectedValue;
            SesionUsu.FichaTipoPersonaFiscal = rdoBttnTipoPersonaFiscal.SelectedValue;
            SesionUsu.FichaRazonSocial = txtRazon_Social.Text;
            SesionUsu.FichaRFC = txtRFC.Text;
            SesionUsu.FichaCalleFiscal = txtCalle_Fiscal.Text;
            SesionUsu.FichaColoniaFiscal = txtColonia_Fiscal.Text;
            SesionUsu.FichaCPFiscal = txtCP_Fiscal.Text;
            SesionUsu.FichaEstadoFiscal = ddlEstado_Fiscal.SelectedValue;
            SesionUsu.FichaMunicipioFiscal = ddlMunicipio_Fiscal.SelectedValue;
            SesionUsu.FichaTelefonoFiscal = txtTelefono_Fiscal.Text;
            SesionUsu.FichaCorreoFiscal = txtCorreo_Fiscal.Text;
            SesionUsu.FichaMetodoPago = ddlMetodoPago.SelectedValue;
            SesionUsu.FichaUsoCFDI = ddlCFDI.SelectedValue;
            SesionUsu.FichaObsSolicitudFactura = txtDescConcepto.Text.ToUpper();
            //SesionUsu.FichaCiudad = txtTelefono_Fiscal.Text;
            SesionUsu.FichaOpcion = 1; // bandera para saber que esta regresando y copiar datos
            if (SesionUsu.UsuEvento != string.Empty)
            {
                if (SesionUsu.UsuWXI != "X")
                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                else if (SesionUsu.UsuWXIAdmon != "X")
                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                else
                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento);
            }
            else
                Response.Redirect("Registro_Participantes_P3.aspx");


        }

        #endregion
        #region <Funciones y Sub>
        private void Inicializar()
        {
            lblMsj.Text = string.Empty;
            try
            {
                if (Request.QueryString["Evento"] != null)
                {
                    SesionUsu.UsuEvento = Request.QueryString["Evento"];
                    txtCorreo_Fiscal.Text = SesionUsu.UsuCorreo;
                    ObjParticipante.Evento = SesionUsu.UsuEvento;
                    CNParticipante.ConsultarEvento(ref ObjParticipante, ref Verificador);
                    if (ObjParticipante.StatusEvento == 'N')
                    {
                        SesionUsu.UsuEvento = "ALUMNO";
                        lblMsj.Text = "El Evento no esta Vigente, favor de comunicarse con el administrador de la Dependencia";
                        btnSiguiente.Visible = false;
                    }
                    else
                    {
                        lblMsj.Text = "";
                        if (SesionUsu.UsuEvento != "ALUMNO")
                            if (SesionUsu.UsuEvento != "EXTRAORDINARIO")
                                if (SesionUsu.UsuEvento != "VERANO")
                                    if (SesionUsu.UsuEvento != "POSGRADO")
                                        if (SesionUsu.UsuEvento != "LIBRE")
                                            if (SesionUsu.UsuEvento != "SUPERADMON")
                                                if (SesionUsu.UsuEvento != "ADMON")
                                                    SesionUsu.UsuDependencia = ObjParticipante.Dependencia;

                        btnSiguiente.Visible = true;


                    }
                }
                else
                    SesionUsu.UsuEvento = "ALUMNO";

                if (SesionUsu.FichaOpcion == 1) // bandera para saber que esta regresando y copiar datos
                {
                    rdoBttnFactFis.SelectedValue = SesionUsu.FichaComprobanteFiscal;
                    rdoBttnFactFis_SelectedIndexChanged(null, null);
                    rdoBttnTipoPersonaFiscal.SelectedValue = SesionUsu.FichaTipoPersonaFiscal;
                    txtRazon_Social.Text = SesionUsu.FichaRazonSocial;
                    txtRFC.Text = SesionUsu.FichaRFC;
                    txtCalle_Fiscal.Text = SesionUsu.FichaCalleFiscal;
                    txtColonia_Fiscal.Text = SesionUsu.FichaColoniaFiscal;
                    txtCP_Fiscal.Text = SesionUsu.FichaCPFiscal;
                    CargarCombo("PKG_CONTRATOS.Obt_Combo_Estados", ref ddlEstado_Fiscal, "p_pais", "1");
                    ddlEstado_Fiscal.SelectedValue = SesionUsu.FichaEstadoFiscal;
                    ddlEstado_Fiscal_SelectedIndexChanged(null, null);
                    ddlMunicipio_Fiscal.SelectedValue = SesionUsu.FichaMunicipioFiscal;
                    txtTelefono_Fiscal.Text = SesionUsu.FichaTelefonoFiscal;
                    txtCorreo_Fiscal.Text = SesionUsu.FichaCorreoFiscal;
                    ddlMetodoPago.SelectedValue = SesionUsu.FichaMetodoPago;
                    ddlCFDI.SelectedValue=SesionUsu.FichaUsoCFDI;
                    txtDescConcepto.Text=SesionUsu.FichaObsSolicitudFactura;

                    //txtCalle_Fiscal.Text = SesionUsu.FichaDomicilio;
                    //txtTelefono_Fiscal.Text = SesionUsu.FichaCiudad;
                }
                else
                    CargarCombos();

                lblEvento.Text = ObjParticipante.EventoStr; // +" "+SesionUsu.FichaReferencia;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private void UpdateFichaReferenciada(ref string MsjVerificador)
        {
            try
            {

                ObjFichaReferenciada.IdFichaBancaria = SesionUsu.FichaRefID;
                ObjFichaReferenciada.Importetotal = SesionUsu.ImpDetalleConcep;
                ObjFichaReferenciada.ComprobanteFiscal = rdoBttnFactFis.SelectedValue;
                ObjFichaReferenciada.Referencia = SesionUsu.FichaReferencia;
                //ObjFichaReferenciada.ConceptoRef = SesionUsu.Observaciones;
                if (SesionUsu.UsuEvento == "FINANZAS_2016")
                    ObjFichaReferenciada.ConceptoRef = SesionUsu.Observaciones + " PERIDO_PAGO:" + SesionUsu.PeriodoPago + SesionUsu.Anexo;
                else
                    ObjFichaReferenciada.ConceptoRef = SesionUsu.Observaciones + SesionUsu.Anexo;

                ObjFichaReferenciada.TipoPersonaFiscal = (rdoBttnFactFis.SelectedValue == "S") ? rdoBttnTipoPersonaFiscal.SelectedValue : string.Empty;
                ObjFichaReferenciada.RazonSocial = txtRazon_Social.Text.ToUpper();
                ObjFichaReferenciada.RFC = txtRFC.Text.ToUpper();
                ObjFichaReferenciada.CalleFiscal = txtCalle_Fiscal.Text.ToUpper();
                ObjFichaReferenciada.ColoniaFiscal = txtColonia_Fiscal.Text.ToUpper();
                ObjFichaReferenciada.CPFiscal = txtCP_Fiscal.Text.ToUpper();
                ObjFichaReferenciada.EstadoFiscal = (rdoBttnFactFis.SelectedValue == "S") ? ddlEstado_Fiscal.SelectedValue : string.Empty;
                ObjFichaReferenciada.MunicipioFiscal = (rdoBttnFactFis.SelectedValue == "S") ? ddlMunicipio_Fiscal.SelectedValue : string.Empty;
                ObjFichaReferenciada.TelefonoFiscal = txtTelefono_Fiscal.Text;
                ObjFichaReferenciada.CorreoFiscal = (rdoBttnFactFis.SelectedValue == "S") ? txtCorreo_Fiscal.Text : string.Empty;
                ObjFichaReferenciada.MetodoPagoFiscal = ddlMetodoPago.SelectedValue;
                ObjFichaReferenciada.CFDI=ddlCFDI.SelectedValue;
                ObjFichaReferenciada.ObsSolicitudFactura= txtDescConcepto.Text.ToUpper();


                ObjFichaReferenciada.Evento = SesionUsu.UsuEvento;
                ObjFichaReferenciada.NoControl = SesionUsu.UsuMatricula;
                ObjFichaReferenciada.Correo = SesionUsu.UsuCorreo;
                if (SesionUsu.TipoPersona == 1)
                    ObjFichaReferenciada.Nombre = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;

                else
                    ObjFichaReferenciada.Nombre = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;

                CNFichaReferenciada.ActualizarFichaReferenciada(ref ObjFichaReferenciada, ref Verificador);

                if (Verificador == "0")
                {
                    lblMsj.Text = string.Empty;
                    SesionUsu.FichaComprobanteFiscal = rdoBttnFactFis.SelectedValue;
                    SesionUsu.FichaTipoPersonaFiscal = rdoBttnTipoPersonaFiscal.SelectedValue;
                    SesionUsu.FichaRazonSocial = txtRazon_Social.Text.ToUpper();
                    SesionUsu.FichaRFC = txtRFC.Text.ToUpper();
                    SesionUsu.FichaCalleFiscal = txtCalle_Fiscal.Text.ToUpper();
                    SesionUsu.FichaColoniaFiscal = txtColonia_Fiscal.Text.ToUpper();
                    SesionUsu.FichaCPFiscal = txtCP_Fiscal.Text.ToUpper();
                    SesionUsu.FichaEstadoFiscal = ddlEstado_Fiscal.SelectedValue;
                    SesionUsu.FichaMunicipioFiscal = ddlMunicipio_Fiscal.SelectedValue;
                    SesionUsu.FichaTelefonoFiscal = txtTelefono_Fiscal.Text.ToUpper();
                    SesionUsu.FichaCorreoFiscal = txtCorreo_Fiscal.Text;
                    SesionUsu.FichaMetodoPago = ddlMetodoPago.SelectedValue;
                    SesionUsu.FichaUsoCFDI = ddlCFDI.SelectedValue;
                    SesionUsu.FichaObsSolicitudFactura = txtDescConcepto.Text.ToUpper();

                    SesionUsu.FichaOpcion = 1;
                    //if (SesionUsu.UsuCorreo != txtCorreo.Text)
                    //{
                    //    ObjAlumno.Correo = txtCorreo.Text;
                    //    CNAlumno.AlumnoEditar(ref ObjAlumno, ref Verificador);
                    //}
                }
                else
                {

                    MsjVerificador = Verificador;
                }
            }
            catch (Exception ex)
            {
                MsjVerificador = ex.Message;
            }

        }
        private void CargarCombos()
        {
            try
            {
                CargarCombo("PKG_CONTRATOS.Obt_Combo_Estados", ref ddlEstado_Fiscal, "p_pais", "1");
                ddlEstado_Fiscal.SelectedValue = "8";
                ddlEstado_Fiscal_SelectedIndexChanged(null, null);
                ddlMunicipio_Fiscal.SelectedValue = "213";
                //CargarCombo("PKG_PAGOS_2016.Obt_Combo_Tipo_Servicios_F", ref ddlServicio);                
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private void CargarCombo(string SP, ref DropDownList Combo)
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

        #endregion

        protected void rdoBttnFactFis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBttnFactFis.SelectedValue == "S")
            {
                pnlDatos.Visible = true;
                valRFC.ValidationGroup = "DatosFiscales";
                valRazon_Social.ValidationGroup = "DatosFiscales";
                valCalle_Fiscal.ValidationGroup = "DatosFiscales";
                valColonia_Fiscal.ValidationGroup = "DatosFiscales";
                valCP_Fiscal.ValidationGroup = "DatosFiscales";
                valEstado_Fiscal.ValidationGroup = "DatosFiscales";
                valMunicipio_Fiscal.ValidationGroup = "DatosFiscales";
                valMetodoPago.ValidationGroup = "DatosFiscales";
                valCFDI.ValidationGroup = "DatosFiscales";
                valDescConcepto.ValidationGroup = "DatosFiscales";
                valCorreo_Fiscal.ValidationGroup = "DatosFiscales";
                btnSiguiente.ValidationGroup = "DatosFiscales";
                valCheck.ValidationGroup = "DatosFiscales";
            }
            else
            {
                pnlDatos.Visible = false;
                valRFC.ValidationGroup = string.Empty;
                valRazon_Social.ValidationGroup = string.Empty;
                valCalle_Fiscal.ValidationGroup = string.Empty;
                valColonia_Fiscal.ValidationGroup = string.Empty;
                valCP_Fiscal.ValidationGroup = string.Empty;
                valEstado_Fiscal.ValidationGroup = string.Empty;
                valMunicipio_Fiscal.ValidationGroup = string.Empty;
                valCorreo_Fiscal.ValidationGroup = string.Empty;
                valMetodoPago.ValidationGroup = string.Empty;
                valCFDI.ValidationGroup = string.Empty;
                valDescConcepto.ValidationGroup = string.Empty;
                valCheck.ValidationGroup = string.Empty;
                btnSiguiente.ValidationGroup = string.Empty;
                rdoBttnTipoPersonaFiscal.SelectedValue = "M";
                txtRFC.Text = string.Empty;
                txtRazon_Social.Text = string.Empty;
                txtCalle_Fiscal.Text = string.Empty;
                txtColonia_Fiscal.Text = string.Empty;
                txtCP_Fiscal.Text = string.Empty;
                ddlEstado_Fiscal.SelectedValue = "8";
                ddlEstado_Fiscal_SelectedIndexChanged(null, null);
                ddlMunicipio_Fiscal.SelectedValue = "213";
                ddlMetodoPago.SelectedValue = "0";
                ddlCFDI.SelectedValue = "0";
                txtDescConcepto.Text = string.Empty;
                txtTelefono_Fiscal.Text = string.Empty;
                txtCorreo_Fiscal.Text = string.Empty;
            }
        }

        protected void ddlEstado_Fiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarCombo("PKG_CONTRATOS.Obt_Combo_Municipios", ref ddlMunicipio_Fiscal, "p_edo", ddlEstado_Fiscal.SelectedValue);
                //ddlMunicipio_Fiscal.SelectedValue = "213";
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void rdoBttnTipoPersonaFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoBttnTipoPersonaFiscal.SelectedValue == "F")
            {
                lblRazon_Social.Text = "Nombre";
                txtRazon_Social.Attributes.Add("placeholder", "Nombre(s) Ap Paterno Ap Materno");
                txtRFC.MaxLength = 13;
            }
            else
            {
                txtRazon_Social.Text = string.Empty;
                lblRazon_Social.Text = "Razón Social";
                txtRazon_Social.Attributes.Add("placeholder", "");
                txtRFC.MaxLength = 12;
            }
        }
    }
}