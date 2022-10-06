using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmisionPagoReferenciado.Form
{
    public partial class PagoExclusivoSYSWEB : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        CN_Token CNToken = new CN_Token();
        FichaReferenciada objDatos = new FichaReferenciada();

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DatosRef"] == null)
                Session["DatosRef"] = new Sesion();

            //SesionUsu = (Sesion)Session["Sesion"];
            SesionUsu = (Sesion)System.Web.HttpContext.Current.Session["DatosRef"];


            if (!IsPostBack)
            {

                //Session["Sesion"] = new Sesion();
                //SesionUsu = (Sesion)Session["Sesion"];

                AccesoDen.Visible = false;
                InfPagoRef.Visible = true;


                //SesionUsu = (Sesion)Session["DatosSIAE"];

                if (Request.QueryString["sw_acc"] != null)
                {
                    Verificador = string.Empty;
                    string TK = Request.QueryString["sw_acc"].ToString();

                    bool Valido = CNToken.ValidateToken(TK);
                    if (Valido == true)
                    {
                        CNToken.ObtenerDatosSYSWEB(ref objDatos, TK, ref Verificador);
                        if (Verificador == "0")
                        {

                            SesionUsu.FichaRefID = objDatos.IdFichaBancaria;
                            SesionUsu.ImpConcepto = objDatos.Total;
                          
                            SesionUsu.UsuNombre = objDatos.Nombre.Replace("\r", "%20");
                            SesionUsu.FichaReferencia = objDatos.Referencia;
                            SesionUsu.UsuEvento = objDatos.Evento;
                            SesionUsu.UsuMatricula = objDatos.Matricula;
                            lblNombre_l.Text = objDatos.Nombre.Replace("\r", "%20");
                            lblMatricula.Text = objDatos.Matricula;
                            lblReferencia_l.Text = objDatos.Referencia;
                            lblImporte_l.Text = Convert.ToString(objDatos.Total);
                            lblConcepto_l.Text = objDatos.ObsSolicitudFactura.Replace("\r", "%20");
                            hddnObservaciones.Value = objDatos.Observaciones.Replace("\r", "%20");
                            lblVigencia_l.Text = objDatos.FechaVigencia;
                            System.Web.HttpContext.Current.Session["DatosRef"] = SesionUsu;
                            if (Convert.ToInt32(objDatos.Dias_Vigencia) > 0)
                            {
                                AccesoDen.Visible = false;
                                InfPagoRef.Visible = true;
                                divPagoTDC.Visible = true;
                                divExpiroFecha.Visible = false;
                            }
                            else
                            {
                                AccesoDen.Visible = false;
                                InfPagoRef.Visible = true;
                                divPagoTDC.Visible = false;
                                divExpiroFecha.Visible = true;
                            }
                            //Session["Sesion"] =SesionUsu;

                        }
                    }
                    else
                    {
                        AccesoDen.Visible = true;
                        InfPagoRef.Visible = false;
                    }
                }
                else
                {
                    AccesoDen.Visible = true;
                    InfPagoRef.Visible = false;
                }
            }
        }

        protected void imgBttnPagoTDC_Click(object sender, ImageClickEventArgs e)
        {
            int IdRef = SesionUsu.FichaRefID;
            string Total = string.Format("{0:0.00}", SesionUsu.ImpConcepto);
            string nombre = SesionUsu.UsuNombre;
            string _open = "window.open('" + "PagoenLinea.aspx?order_m=" + SesionUsu.FichaRefID + "&reference_m=" + SesionUsu.FichaReferencia + "&amount_m=" + SesionUsu.ImpConcepto + "&customername_m=" + SesionUsu.UsuNombre + "', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

        protected void imgBttnPagoEfec_Click(object sender, ImageClickEventArgs e)
        {
            string ruta;
            string _open;
            if (SesionUsu.UsuEvento == "VENTA_PRODUCTOS")
            {
                ruta = "https://sysweb.unach.mx/Ingresos/Reportes/VisualizadorCrystal.aspx?Tipo=REP000-1&idFact=" + SesionUsu.FichaRefID;
                _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            }
            else
            {

                ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=REP_FICHA_REF&idFact=" + SesionUsu.FichaRefID + "&Referencia=" + lblReferencia_l.Text;
                //ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=REP_FICHA_REF&Nombre=" + lblNombre_l.Text + "&Referencia=" + lblReferencia_l.Text + "&Importe=" + lblImporte_l.Text.TrimStart('$') + "&Vigencia=" + lblVigencia_l.Text + "&Concepto=" + lblConcepto_l.Text + "&Observaciones=" + hddnObservaciones.Value + "&Matricula=" + SesionUsu.UsuMatricula;
                _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}