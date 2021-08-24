﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion
namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes_P5 : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        MultiPago SesionMultipago = new MultiPago();
        Comun ObjComun = new Comun();
        CN_Comun CNComun = new CN_Comun();
        static public String var= string.Empty;
        static public String palabra = "X";
        Participante ObjParticipante = new Participante();
        CN_Participante CNParticipante = new CN_Participante();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        FichaReferenciada ObjFichaReferenciada = new FichaReferenciada();
        CN_FichaReferenciada CNFichaReferenciada = new CN_FichaReferenciada();
        Terminal ObjTerminal = new Terminal();
        CN_Terminal CNTerminal = new CN_Terminal();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            //SesionMultipago = (MultiPago)Session["Multipago"];
            if (SesionUsu != null)
            {           
                if (!IsPostBack)            
                    Inicializar();
            }
            else            
                Response.Redirect("https://sysweb.unach.mx/");
            
        }

        #region <Botones y Eventos>
        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (SesionUsu.UsuEvento != string.Empty)
               {
                if (SesionUsu.UsuWXI != "X")
                    Response.Redirect("Registro_Participantes_P3.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                else if (SesionUsu.UsuWXIAdmon != "X")
                    Response.Redirect("Registro_Participantes_P3.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                else
                    Response.Redirect("Registro_Participantes_P3.aspx" + "?Evento=" + SesionUsu.UsuEvento);
            }  
            else
                Response.Redirect("Registro_Participantes_P2.aspx");
        }
        protected void btnImprimir_Click(object sender, EventArgs e)
        {

            btnAnterior.Visible = false;
            btnImprimir.Visible = false;
            btnPagoBancomer.Visible = false;
            //divDatosPago.Visible = false;
            //imgBancos.Visible = false;
            //Iframe1.Visible = true;
            divRep.Visible = true;
            var = SesionUsu.UsuEvento;
            palabra = SesionUsu.UsuWXI;
            Session.Abandon();

            if (lblReferencia_l.Text == string.Empty)
                lblMsj.Text = "Debe Generar la Referencia Bancaria";
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(1,'" + lblNombre_l.Text + "','" + lblReferencia_l.Text + "','" + lblImporte_l.Text.TrimStart('$') + "','" + lblVigencia_l.Text + "','" + hddnConceptos.Value + "','" + hddnObservaciones.Value + "');", true);
            }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte(1,'" + lblNombre_l.Text + "','" + lblReferencia_l.Text + "','" + lblImporte_l.Text.TrimStart('$') + "','" + lblVigencia_l.Text + "','" + lblConcepto_l.Text + "');", true);
        

        }
        protected void btnPago_Click(object sender, EventArgs e)
        {
            if (SesionUsu != null)
            {
                string var = SesionUsu.UsuEvento;
                string OrigenArchivo = Server.MapPath("~") + "/ArchivoReferencia/Referencia - " + lblReferencia_l.Text + ".PDF";

                if (System.IO.File.Exists(OrigenArchivo))
                    System.IO.File.Delete(OrigenArchivo);


                SesionUsu.UsuWXI = "X";
                if (Request.QueryString["WXI"] != null)
                    SesionUsu.UsuWXI = Request.QueryString["WXI"];


                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));


                //if (var != string.Empty)
                if (SesionUsu.UsuEvento != string.Empty)
                {
                    if (SesionUsu.UsuWXI != "X")
                        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var + "&WXI=" + SesionUsu.UsuWXI);
                    else if (SesionUsu.UsuWXIAdmon != "X")
                        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                    else
                        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var);
                }
                else
                    Response.Redirect("Registro_Participantes.aspx");
            }
            else
                Response.Redirect("https://sysweb.unach.mx/");
            

        }
        protected void btnPagoBancomer_Click(object sender, EventArgs e)
        {
            mp_account.Value = "952";
            mp_product.Value = "1";
            mp_order.Value = Convert.ToString(SesionUsu.FichaRefID);
            mp_reference.Value = SesionUsu.FichaReferencia;
            mp_node.Value = "0";
            mp_concept.Value = "99";
            mp_amount.Value = string.Format("{0:0.00}", SesionUsu.ImpDetalleConcep);
            mp_customername.Value = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
            mp_currency.Value = "1";             
            mp_signature.Value = CNComun.GetSHA256(Convert.ToString(mp_order.Value + mp_reference.Value + mp_amount.Value));
            mp_urlsuccess.Value = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes_P6.aspx"; //"Registro_Participantes_P7.aspx";
            mp_urlfailure.Value = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes_P6.aspx"; // "Registro_Participantes_P7.aspx";

            ClientScript.RegisterStartupScript(this.GetType(), "myScript", "PagBancomer();", true);
        }
        #endregion

        #region <Funciones y Sub>
        private void Inicializar()
        {
            btnAnterior.Visible = true;
            btnForma_Pago.Visible = true;
            //Iframe1.Visible = false;
            divRep.Visible = false;
            lblMensajeCorreo.Text = string.Empty;
            Verificador = string.Empty;
            try
            {
                if (SesionUsu.UsuEvento == "SUPERADMON" || SesionUsu.UsuEvento == "ADMON" || SesionUsu.UsuWXIAdmon != "X")
                    //divGenLink.Visible = true;
                //if (SesionUsu.UsuWXIAdmon != "X")
                {
                    Usuario objUsuario = new Usuario();
                    objUsuario.Nombre = SesionUsu.UsuWXIAdmon;
                    CNComun.ConsultaTipoUsu(objUsuario, ref Verificador);
                    //if (Verificador == "0")
                    //{
                        if (objUsuario.TipoUsu == "SA" || objUsuario.TipoUsu == "A")
                            divGenLink.Visible = true;
                    //}
                }
                else
                    divGenLink.Visible = false;

                ConsultarDatos();               
            }
            catch (Exception ex)
            {
                lblMensajeCorreo.Text = ex.Message;
            }
        }

        private void VerificaEvento()
        {
            lblMsj.Text = string.Empty;
            try
            {
                if (SesionUsu.UsuEvento != "ALUMNO" && SesionUsu.UsuEvento != "LIBRE" && SesionUsu.UsuEvento != "SUPERADMON" && SesionUsu.UsuEvento != "ADMON")
                    divMensajeEventos.Visible = true;
                else
                    divMensajeEventos.Visible = false;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }


        private void VerificaUsuarioPV()
        {
            ObjTerminal.Usuario.Login = Convert.ToString(SesionUsu.UsuWXI);
            CNTerminal.ObtDatosTerminal(ref ObjTerminal, ref Verificador);
            if (Verificador == "0")
            {
                SesionUsu.Terminal.Nombre_Convenio = ObjTerminal.Nombre_Convenio;
                SesionUsu.Terminal.Numero_Convenio = ObjTerminal.Numero_Convenio;
                rbtFormaPago.Items.Insert(4, new ListItem("Terminal Punto de Venta", "5"));
            }
        }
        private void ConsultarDatos()
        {
            
            CNComun.LlenaListaRbn("PKG_PAGOS_2016.Obt_Combo_Formas_Pago", ref rbtFormaPago, "p_evento", "p_usuario", SesionUsu.UsuEvento, SesionUsu.UsuWXI);
            rbtFormaPago.SelectedIndex = 0;

            lblImporte_l.Text = string.Format("{0:c2}", SesionUsu.ImpDetalleConcep);
            lblReferencia_l.Text = SesionUsu.FichaReferencia;
            lblConcepto_l.Text = SesionUsu.Observaciones + ".    TIPO DE PERSONA:  " + SesionUsu.TipoPersonaStr + ".    PERIODO DE PAGO:  " + SesionUsu.PeriodoPago + ".   " + SesionUsu.Anexo;
            hddnConceptos.Value = SesionUsu.Observaciones;
            hddnObservaciones.Value = SesionUsu.TipoPersonaStr + ".    PERIODO DE PAGO:  " + SesionUsu.PeriodoPago + ".   " + SesionUsu.Anexo;
            lblVigencia_l.Text = SesionUsu.FechaVigencia;
            lblNombre_l.Text = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
            rbtFormaPago_SelectedIndexChanged(null, null);
                //if (SesionUsu.UsuEvento == "FINANZAS_2016")
                //    ddlForma_Pago.Items.

        }
        private void rptPDFAdjunto(String Reporte, String Nombre, String Referencia, String Importe, String Vigencia, String Concepto, String Observaciones)
        {
            System.Web.UI.Page p = new System.Web.UI.Page();
            CrystalDecisions.CrystalReports.Engine.ReportDocument report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            try
            {

                report.Load(p.Server.MapPath("~") + Reporte);
                report.SetParameterValue(0, Nombre);
                report.SetParameterValue(1, Referencia);
                report.SetParameterValue(2, Importe);
                report.SetParameterValue(3, Vigencia);
                report.SetParameterValue(4, Concepto);
                report.SetParameterValue(5, Observaciones);
                report.PrintOptions.PaperSize = PaperSize.PaperLetter;
                string archivo = p.Server.MapPath("~") + "/ArchivoReferencia/Referencia - " + Referencia + ".PDF";
                report.ExportToDisk(ExportFormatType.PortableDocFormat, archivo); // "FichaReferenciada-" + Nombre.Substring(0, 15));

            }
            catch (Exception ex)
            {
                lblMensajeCorreo.Text = ex.Message;
            }
            finally
            {

                //CR_Reportes.ReportSource = report;
                report.Close();
                report.Dispose();
                //CR_Reportes.Dispose();
                GC.Collect();
                //CR_Reportes.Dispose();
            }
        }
        protected void btnForma_Pago_Click(object sender, EventArgs e)
        {
            if (rbtFormaPago.SelectedValue == "1")
            {
                btnAnterior.Visible = false;
                btnForma_Pago.Visible = false;
                divRep.Visible = true;
                //imgBancos.Visible = false; //pnDatos
                //Iframe1.Visible = true;
                divDatosPago.Visible = false;
                divRep.Visible = true;
                if (lblReferencia_l.Text == string.Empty)
                    lblMsj.Text = "Debe Generar la Referencia Bancaria";
                else
                {
                    hddnObservaciones.Value = hddnObservaciones.Value.Replace("\r", "%20%20%20%20%20");
                    hddnObservaciones.Value = hddnObservaciones.Value.Replace("\n", "%20%20%20%20%20");                    
                    string ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=1&Nombre=" + lblNombre_l.Text + "&Referencia=" + lblReferencia_l.Text + "&Importe=" + lblImporte_l.Text.TrimStart('$') + "&Vigencia=" + lblVigencia_l.Text + "&Concepto=" + hddnConceptos.Value + "&Observaciones=" + hddnObservaciones.Value;
                    //string ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=5&idFicha=" + SesionUsu.FichaRefID + "&Observaciones=" + hddnObservaciones.Value;
                    string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    chkCorreo.Visible = true;
                   
                }
            }
            else if (rbtFormaPago.SelectedValue == "2" || rbtFormaPago.SelectedValue == "3" || rbtFormaPago.SelectedValue == "4" || rbtFormaPago.SelectedValue == "5")
            {               
                    mp_account.Value = "952";
                    mp_product.Value = "1";
                    mp_order.Value = Convert.ToString(SesionUsu.FichaRefID);
                    mp_reference.Value = SesionUsu.FichaReferencia;
                    mp_node.Value = "0";
                    mp_concept.Value = "99";
                    mp_amount.Value = string.Format("{0:0.00}", SesionUsu.ImpDetalleConcep);
                    mp_customername.Value = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                    mp_currency.Value = "1";
                    mp_signature.Value = CNComun.GetSHA256(Convert.ToString(mp_order.Value + mp_reference.Value + mp_amount.Value));
                    mp_urlsuccess.Value = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes_P6.aspx"; //"Registro_Participantes_P7.aspx";
                    mp_urlfailure.Value = "https://sysweb.unach.mx/FichaReferenciada/Form/Registro_Participantes_P6.aspx"; // "Registro_Participantes_P7.aspx";
                    ClientScript.RegisterStartupScript(this.GetType(), "myScript", "PagBancomer();", true);                
            }
            else if (rbtFormaPago.SelectedValue == "5")
            {
                //Response.Redirect("Registro_Participantes_P8.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                if (SesionUsu.UsuEvento != string.Empty)
                {
                    if (SesionUsu.UsuWXI != "X")
                        Response.Redirect("Registro_Participantes_P8.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                    else if (SesionUsu.UsuWXIAdmon != "X")
                        Response.Redirect("Registro_Participantes_P8.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                    else
                        Response.Redirect("Registro_Participantes_P8.aspx" + "?Evento=" + SesionUsu.UsuEvento);
                }
                else
                    Response.Redirect("Registro_Participantes_P8.aspx");
            }
            //SesionUsu.FichaRefIDPagoTC = SesionUsu.FichaRefID;
            //if (SesionUsu != null)
            //{
            //    SesionUsu.FichaReferencia = string.Empty;
            //    SesionUsu.FichaRefID = 0;
            //}

        }
        protected void ddlForma_Pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ddlForma_Pago.SelectedValue = "1";
        }
        #endregion

        protected void chkCorreo_CheckedChanged(object sender, EventArgs e)
        {
            //string ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=1&Nombre=" + lblNombre_l.Text + "&Referencia=" + lblReferencia_l.Text + "&Importe=" + lblImporte_l.Text.TrimStart('$') + "&Vigencia=" + lblVigencia_l.Text + "&Concepto=" + hddnConceptos.Value + "&Observaciones=" + hddnObservaciones.Value;
            //string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
            if (SesionUsu != null)           
                txtCorreo.Text = SesionUsu.UsuCorreo;

            modalCorreo.Show();
        }

        protected void bttnCorreo_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;
            string archivo = string.Empty;
            string asunto = string.Empty;
            string contenido = string.Empty;
            string OrigenArchivo = string.Empty;
            lblMensajeCorreo.Text = string.Empty;
            modalCorreo.Show();
            try
            {
                //ruta = "../ReportesFicha/VisualizadorCrystal.aspx?cverep=4&Nombre=" + lblNombre_l.Text + "&Referencia=" + lblReferencia_l.Text + "&Importe=" + lblImporte_l.Text.TrimStart('$') + "&Vigencia=" + lblVigencia_l.Text + "&Concepto=" + hddnConceptos.Value + "&Observaciones=" + hddnObservaciones.Value;
                ////string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), ruta, true);
                rptPDFAdjunto("\\Reportes\\Ficha_Referenciada.rpt", lblNombre_l.Text, lblReferencia_l.Text, lblImporte_l.Text.TrimStart('$'), lblVigencia_l.Text, hddnConceptos.Value, hddnObservaciones.Value);
                archivo = Server.MapPath("~") + "/ArchivoReferencia/Referencia - " + lblReferencia_l.Text + ".PDF";
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                asunto = "Ficha Referenciada UNACH-SYSWEB";
                contenido = "<font size='2'>Para cualquier duda o aclaración te puedes comunicar a los siguientes telefonos:" + "<br /><br /><strong>DIRECCIÓN DE SISTEMAS DE INFORMACIÓN ADMINISTRATIVA</strong><br />Teléfono - (961) 617 80 00, Ext.: 5503, 5501, 5508 y 5509<br /><br />" +
                "<strong>DEPARTAMENTO DE FINANZAS</strong><br />Teléfono - (961) 617 80 00, Ext.: 5108</font>";
                string MsjError = string.Empty;
                CNComun.EnvioCorreoAdjunto(ref mmsg, archivo, asunto, contenido, txtCorreo.Text, ref MsjError);
                if (MsjError == string.Empty)
                {
                    if (mmsg != null)
                    {
                        //modalCorreo.Hide();
                        lblMensajeCorreo.Text = "La referencia se ha enviado correctamente al correo: " + txtCorreo.Text;
                        OrigenArchivo = Server.MapPath("~") + "/ArchivoReferencia/Referencia - " + lblReferencia_l.Text + ".PDF";
                        if (System.IO.File.Exists(OrigenArchivo))
                            System.IO.File.Delete(OrigenArchivo);

                        chkCorreo.Visible = false;
                    }
                    else
                    {
                        lblMensajeCorreo.Text = "Error en el envio de los archivos. "+ MsjError; // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "modal", "mostrar_modal( 0, '" + MsjError + "');", true);  //lblMsj.Text = ex.Message;
                        chkCorreo.Checked=false;
                    }
                }
                else
                    lblMensajeCorreo.Text = MsjError;
            }
            catch (Exception ex)
            {
                lblMensajeCorreo.Text = ex.Message;
            }

        }

        protected void bttnCancelarCorreo_Click(object sender, EventArgs e)
        {
            chkCorreo.Checked = false;
            modalCorreo.Hide();
        }

        protected void rbtFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            //divDatosPago.Visible = false;


            if (SesionUsu.UsuEvento != "ALUMNO" && SesionUsu.UsuEvento != "LIBRE" && SesionUsu.UsuEvento != "SUPERADMON" && SesionUsu.UsuEvento != "ADMON")
            {
                if (rbtFormaPago.SelectedValue == "1")
                    lblInfFormaPago.Text = "El comprobante oficial estará disponible 24 hrs., hábiles después de haber realizado el pago, en https://sysweb.unach.mx/ingresos/, en la opción <strong>REFERENCIA BANCARIA.</strong>";
                else if (rbtFormaPago.SelectedValue == "2")
                    lblInfFormaPago.Text = "Recuerda <strong>NO CERRAR EL PORTAL DE BANCOMER,</strong> te direccionara nuevamente a sysweb para obtener tu comprobante oficial.";
                else if (rbtFormaPago.SelectedValue == "4")
                    lblInfFormaPago.Text = "El comprobante oficial estará disponible hasta 48 hrs. hábiles después de haber realizado el pago, en la página https://sysweb.unach.mx/ingresos/, en la opción <strong>REFERENCIA BANCARIA.</strong>";
                else if (rbtFormaPago.SelectedValue == "5")
                    lblInfFormaPago.Text = "El comprobante oficial estará disponible hasta 72 hrs. hábiles después de haber realizado el pago, en la página https://sysweb.unach.mx/ingresos/, en la opción <strong>REFERENCIA BANCARIA.</strong>";


            }
            else
            {
                if (rbtFormaPago.SelectedValue == "1")
                    lblInfFormaPago.Text = "El comprobante oficial estará disponible 24 hrs., hábiles después de haber realizado el pago, en https://sysweb.unach.mx/ingresos/, en la opción <strong>ALUMNO Ó ASPIRANTE.</strong>";
                else if (rbtFormaPago.SelectedValue == "2")
                    lblInfFormaPago.Text = "Recuerda <strong>NO CERRAR EL PORTAL DE BANCOMER,</strong> te direccionara nuevamente a sysweb para obtener tu comprobante oficial.";
                else if (rbtFormaPago.SelectedValue == "3")
                    lblInfFormaPago.Text = "El comprobante oficial estará disponible hasta 48 hrs. hábiles después de haber realizado el pago, en la página https://sysweb.unach.mx/ingresos/, en la opción <strong>ALUMNO Ó ASPIRANTE.</strong>";
                else if (rbtFormaPago.SelectedValue == "2")
                    lblInfFormaPago.Text = "El comprobante oficial estará disponible hasta 72 hrs. hábiles después de haber realizado el pago, en la página https://sysweb.unach.mx/ingresos/, en la opción <strong>ALUMNO Ó ASPIRANTE.</strong>";

            }
        }

        protected void linkGen_Click(object sender, EventArgs e)
        {
            string cadena = string.Empty;
            try
            {
                cadena = CN_Token.GenerarToken(Convert.ToInt32(SesionUsu.FichaRefID), SesionUsu.FichaReferencia);
                linkPago.Text = "https://sysweb.unach.mx/FichaReferenciada/Form/PagoExclusivoSYSWEB.aspx?sw_acc=" + cadena;
            }
            catch(Exception ex)
            {

            }
        }
    }
}