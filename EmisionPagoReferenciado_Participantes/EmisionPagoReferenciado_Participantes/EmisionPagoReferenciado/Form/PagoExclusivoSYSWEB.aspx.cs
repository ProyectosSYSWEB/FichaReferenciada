﻿using CapaEntidad;
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
                            SesionUsu.UsuNombre = objDatos.Nombre;
                            SesionUsu.FichaReferencia = objDatos.Referencia;
                            lblNombre_l.Text = objDatos.Nombre;
                            lblReferencia_l.Text = objDatos.Referencia;
                            lblImporte_l.Text = Convert.ToString(objDatos.Total);
                            lblConcepto_l.Text = objDatos.ObsSolicitudFactura;
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
            string ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=REP_SYSWEB&idFicha=" + SesionUsu.FichaReferencia;
            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }
    }
}