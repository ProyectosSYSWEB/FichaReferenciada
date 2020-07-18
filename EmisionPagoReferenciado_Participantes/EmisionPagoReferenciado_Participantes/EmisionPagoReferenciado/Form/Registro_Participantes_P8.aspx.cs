using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes_P8 : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        Comun ObjComun = new Comun();
        CN_Comun CNComun = new CN_Comun();

        Terminal ObjTerminal = new Terminal();
        CN_Terminal CNTerminal = new CN_Terminal();

        MultiPago ObjMultipago = new MultiPago();
        CN_Multipago CNMultipago = new CN_Multipago();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        #region <Funciones y Sub>
        private void Inicializar()
        {
            lblMsj.Text = string.Empty;
            try
            {
                if (SesionUsu.UsuEvento != string.Empty)
                {
                    if (SesionUsu.Terminal.Nombre_Convenio != string.Empty)
                    {
                        Obt_Datos_Terminal();
                        CNComun.LlenaCombo("pkg_pagos.Obt_Grid_Bancos_TPV", ref ddlBanco);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private void Obt_Datos_Terminal()
        {
            lblMsj.Text = string.Empty;
            Verificador = String.Empty;
            try
            {
                lblTerminal_l.Text = SesionUsu.Terminal.Nombre_Convenio;
                lblConvenio_l.Text = SesionUsu.Terminal.Numero_Convenio;
                lblReferencia_l1.Text = SesionUsu.FichaReferencia;
                lblNombre_l.Text = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                lblImporte_l.Text = string.Format("{0:c2}", SesionUsu.ImpDetalleConcep);
                lblNotas_l.Text = SesionUsu.Observaciones;

                //ObjTerminal.Usuario.Login =Convert.ToString(SesionUsu.UsuWXI);
                //CNTerminal.ObtDatosTerminal(ref ObjTerminal, ref Verificador);
                //if(Verificador=="0")
                //{
                //    lblTerminal_l.Text = ObjTerminal.Nombre_Convenio;
                //    lblConvenio_l.Text = ObjTerminal.Numero_Convenio;
                //    lblReferencia_l1.Text = SesionUsu.FichaReferencia;
                //    lblNombre_l.Text= SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                //    lblImporte_l.Text = string.Format("{0:c2}", SesionUsu.ImpDetalleConcep);
                //    lblNotas_l.Text = SesionUsu.Observaciones;
                //}
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        #endregion

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Verificador = string.Empty;
            try
            {
                ObjMultipago.Origen = "TPV";
                ObjMultipago.Account = "999";
                ObjMultipago.Order = Convert.ToString(SesionUsu.FichaRefID);
                ObjMultipago.Reference = SesionUsu.FichaReferencia;
                ObjMultipago.Node = "000";
                ObjMultipago.Concept = "099";
                ObjMultipago.Amount = string.Format("{0:0.00}", SesionUsu.ImpDetalleConcep);
                ObjMultipago.Currency = "1";
                ObjMultipago.PaymentMethod = "TDX";
                ObjMultipago.PaymentMethodComplete = "TDX";
                ObjMultipago.Response = "00";
                ObjMultipago.ResponseComplete = "00";
                ObjMultipago.Responsemsg = string.Empty;
                ObjMultipago.ResponseMsgComplete = string.Empty;
                ObjMultipago.Authorization = txtNumAutorizacion.Text;
                ObjMultipago.AuthorizationComplete = txtNumAutorizacion.Text;
                ObjMultipago.Pan = txtNumTarjeta.Text.PadLeft(16,'*');
                ObjMultipago.PanComplete = txtNumTarjeta.Text.PadLeft(16,'*');


                ObjMultipago.Date = string.Format("{0:dd/MM/yyyy hh:mm:ss}", System.DateTime.Now); //string.Format("{0:dd/MM/yyyy}",System.DateTime.Now);
                ObjMultipago.Signature = string.Empty;
                ObjMultipago.Customername = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;

                ObjMultipago.Promo_Msi = "0";
                ObjMultipago.Bankcode = ddlBanco.SelectedValue; //"00";
                ObjMultipago.Saleid = string.Empty;
                ObjMultipago.Sale_Historyid = string.Empty;
                ObjMultipago.Trx_Historyid = string.Empty;
                ObjMultipago.Trx_Historyidcomplete = string.Empty;
                ObjMultipago.Bankname = ddlBanco.SelectedItem.Text;
                ObjMultipago.Folio = string.Empty;
                ObjMultipago.Cardholdername = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                ObjMultipago.Cardholdernamecomplete = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                ObjMultipago.Authorization_Mp1 = string.Empty;
                ObjMultipago.Phone = SesionUsu.UsuTelefono;
                ObjMultipago.Email = SesionUsu.UsuCorreo;
                ObjMultipago.Promo = "REV";
                ObjMultipago.Promo_msi_bank = ddlBanco.SelectedItem.Text;
                ObjMultipago.Securepayment = "1";
                ObjMultipago.Cardtype = ddlTipoTarjeta.SelectedValue;
                ObjMultipago.IdFichaBancaria = SesionUsu.FichaRefID;
                ObjMultipago.Carrera = SesionUsu.UsuCarrera;
                ObjMultipago.Id_Fact = -1;
                //btnAceptar.Enabled = false;
                CNMultipago.InsertarMultipago_Transaccion(ref ObjMultipago, ref Verificador);
                if (Verificador != "0")
                    lblMsj.Text = Verificador;
                else
                {
                    if (ObjMultipago.Id_Fact != -1)
                    {
                        btnAceptar.Visible = false;                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerRecibo(3," + ObjMultipago.Id_Fact + ");", true);
                    }
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }

        protected void btnPago_Click(object sender, EventArgs e)
        {
            //SesionUsu = (Sesion)Session["Sesion"];
            //string var = SesionUsu.UsuEvento;
            //SesionUsu.UsuWXI = "X";
            //if (Request.QueryString["WXI"] != null)
            //{
            //    SesionUsu.UsuWXI = Request.QueryString["WXI"];

            //}
            //Session.Abandon();
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            //if (var != string.Empty)
            //{
            //    if (SesionUsu.UsuWXI != "X")
            //        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var + "&WXI=" + SesionUsu.UsuWXI);
            //    else
            //        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var);
            //}
            //else
            //    Response.Redirect("Registro_Participantes.aspx");
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
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
    }
}