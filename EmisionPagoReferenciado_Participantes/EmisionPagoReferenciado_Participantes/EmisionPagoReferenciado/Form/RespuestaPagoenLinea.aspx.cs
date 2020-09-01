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
    public partial class RespuestaPagoenLinea : System.Web.UI.Page
    {
        #region <Variables>
        MultiPago SesionMultipago = new MultiPago();
        Sesion SesionUsu = new Sesion();
        CN_Comun CNComun = new CN_Comun();
        CN_FichaReferenciada CNFichaRef = new CN_FichaReferenciada();
        CN_Multipago CNMultipago = new CN_Multipago();
        MultiPago ObjMultipago = new MultiPago();
        static public String var = string.Empty;
        static public String palabra = "X";
        string Verificador = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                Session["Multipago"] = null;

            else
            {
                if (Session["Multipago"] != null)
                    SesionMultipago = (MultiPago)Session["Multipago"];

            }

            try
            {

                if (Convert.ToString(Request.Form["mp_account"]) != null)
                    SesionMultipago.Account = Convert.ToString(Request.Form["mp_account"]);
                if (Convert.ToString(Request.Form["mp_order"]) != null)
                {
                    SesionMultipago.Order = Convert.ToString(Request.Form["mp_order"]);
                    SesionMultipago.IdFichaBancaria = Convert.ToInt32(Request.Form["mp_order"]);// SesionUsu.FichaRefID;
                }
                if (Convert.ToString(Request.Form["mp_reference"]) != null)
                    SesionMultipago.Reference = Convert.ToString(Request.Form["mp_reference"]);
                if (Convert.ToString(Request.Form["mp_node"]) != null)
                    SesionMultipago.Node = Convert.ToString(Request.Form["mp_node"]);
                if (Convert.ToString(Request.Form["mp_concept"]) != null)
                    SesionMultipago.Concept = Convert.ToString(Request.Form["mp_concept"]);
                if (Convert.ToString(Request.Form["mp_amount"]) != null)
                    SesionMultipago.Amount = string.Format("{0:0.00}", Convert.ToString(Request.Form["mp_amount"]));
                if (Convert.ToString(Request.Form["mp_currency"]) != null)
                    SesionMultipago.Currency = Convert.ToString(Request.Form["mp_currency"]);
                if (Convert.ToString(Request.Form["mp_paymentmethod"]) != null)
                    SesionMultipago.PaymentMethod = Convert.ToString(Request.Form["mp_paymentmethod"]);
                if (Convert.ToString(Request.Form["mp_paymentmethodcomplete"]) != null)
                    SesionMultipago.PaymentMethodComplete = Convert.ToString(Request.Form["mp_paymentmethodcomplete"]);
                if (Convert.ToString(Request.Form["mp_response"]) != null)
                    SesionMultipago.Response = Convert.ToString(Request.Form["mp_response"]);
                if (Convert.ToString(Request.Form["mp_responsecomplete"]) != null)
                    SesionMultipago.ResponseComplete = Convert.ToString(Request.Form["mp_responsecomplete"]);
                if (Convert.ToString(Request.Form["mp_responsemsg"]) != null)
                    SesionMultipago.Responsemsg = Convert.ToString(Request.Form["mp_responsemsg"]);
                if (Convert.ToString(Request.Form["mp_responsemsgcomplete"]) != null)
                    SesionMultipago.ResponseMsgComplete = Convert.ToString(Request.Form["mp_responsemsgcomplete"]);
                if (Convert.ToString(Request.Form["mp_authorization"]) != null)
                    SesionMultipago.Authorization = Convert.ToString(Request.Form["mp_authorization"]);
                if (Convert.ToString(Request.Form["mp_authorizationcomplete"]) != null)
                    SesionMultipago.AuthorizationComplete = Convert.ToString(Request.Form["mp_authorizationcomplete"]);
                if (Convert.ToString(Request.Form["mp_pan"]) != null)
                    SesionMultipago.Pan = Convert.ToString(Request.Form["mp_pan"]);
                if (Convert.ToString(Request.Form["mp_pancomplete"]) != null)
                    SesionMultipago.PanComplete = Convert.ToString(Request.Form["mp_pancomplete"]);
                if (Convert.ToString(Request.Form["mp_date"]) != null)
                    SesionMultipago.Date = Convert.ToString(Request.Form["mp_date"]);
                if (Convert.ToString(Request.Form["mp_signature"]) != null)
                    SesionMultipago.Signature = Convert.ToString(Request.Form["mp_signature"]);
                if (Convert.ToString(Request.Form["mp_customername"]) != null)
                    SesionMultipago.Customername = Convert.ToString(Request.Form["mp_customername"]);
                if (Convert.ToString(Request.Form["mp_promo_msi"]) != null)
                    SesionMultipago.Promo_Msi = Convert.ToString(Request.Form["mp_promo_msi"]);
                if (Convert.ToString(Request.Form["mp_bankcode"]) != null)
                    SesionMultipago.Bankcode = Convert.ToString(Request.Form["mp_bankcode"]);
                if (Convert.ToString(Request.Form["mp_saleid"]) != null)
                    SesionMultipago.Saleid = Convert.ToString(Request.Form["mp_saleid"]);
                if (Convert.ToString(Request.Form["mp_sale_historyid"]) != null)
                    SesionMultipago.Sale_Historyid = Convert.ToString(Request.Form["mp_sale_historyid"]);
                if (Convert.ToString(Request.Form["mp_trx_historyid"]) != null)
                    SesionMultipago.Trx_Historyid = Convert.ToString(Request.Form["mp_trx_historyid"]);
                if (Convert.ToString(Request.Form["mp_trx_historyidcomplete"]) != null)
                    SesionMultipago.Trx_Historyidcomplete = Convert.ToString(Request.Form["mp_trx_historyidcomplete"]);
                if (Convert.ToString(Request.Form["mp_bankname"]) != null)
                    SesionMultipago.Bankname = Convert.ToString(Request.Form["mp_bankname"]);
                if (Convert.ToString(Request.Form["mp_folio"]) != null)
                    SesionMultipago.Folio = Convert.ToString(Request.Form["mp_folio"]);
                if (Convert.ToString(Request.Form["mp_cardholdername"]) != null)
                    SesionMultipago.Cardholdername = Convert.ToString(Request.Form["mp_cardholdername"]);
                if (Convert.ToString(Request.Form["mp_phone"]) != null)
                    SesionMultipago.Phone = Convert.ToString(Request.Form["mp_phone"]);
                if (Convert.ToString(Request.Form["mp_email"]) != null)
                    SesionMultipago.Email = Convert.ToString(Request.Form["mp_email"]);
                if (Convert.ToString(Request.Form["mp_promo"]) != null)
                    SesionMultipago.Promo = Convert.ToString(Request.Form["mp_promo"]);
                if (Convert.ToString(Request.Form["mp_promo_msi_bank"]) != null)
                    SesionMultipago.Promo_msi_bank = Convert.ToString(Request.Form["mp_promo_msi_bank"]);
                if (Convert.ToString(Request.Form["mp_securepayment"]) != null)
                    SesionMultipago.Securepayment = Convert.ToString(Request.Form["mp_securepayment"]);
                if (Convert.ToString(Request.Form["mp_cardtype"]) != null)
                    SesionMultipago.Cardtype = Convert.ToString(Request.Form["mp_cardtype"]);


                if (SesionMultipago != null)
                {
                    lblFolio.Text = SesionMultipago.Order;
                    lblMedioPago.Text = (SesionMultipago.PaymentMethod == "TDX") ? "VISA/MASTERCARD" : "";
                    lblReferencia.Text = SesionMultipago.Reference;
                    lblImporte.Text = string.Format("{0:c2}", Convert.ToDouble(SesionMultipago.Amount));
                    lblAutorizacion.Text = SesionMultipago.Authorization;
                    lblNumTarjeta.Text = SesionMultipago.PanComplete;
                    lblFecha.Text = string.Format("{0:dd/MM/yyyy}", SesionMultipago.Date);
                    if (SesionMultipago.Id_Fact == 0)
                    {
                        Verificador = string.Empty;
                        string Msj = string.Empty;
                        //try
                        //{
                        SesionMultipago.Carrera = "";// SesionUsu.UsuCarrera;
                        SesionMultipago.Origen = "SYSWEB";
                        Session["Multipago"] = SesionMultipago;
                        string CadenaHash = CNComun.GetSHA256(SesionMultipago.Order + SesionMultipago.Reference + SesionMultipago.Amount + SesionMultipago.Authorization);

                        if (SesionMultipago.Signature == CadenaHash)
                        {
                            if (SesionMultipago.Authorization != null)
                            {
                                if (SesionMultipago.Authorization.Length >= 1)
                                {
                                    if (SesionMultipago.Authorization != "000000")
                                    {
                                        //Msj = "!PAGO REALIZADO CON ÉXITO¡";
                                        divPagoConf.Visible = true;
                                        lblmensaje2.Text = "Si desea descargar nuevamente su recibo oficial puede hacerlo accediendo al <BR/> Sistema de Recaudación de Ingresos (https://sysweb.unach.mx/ingresos)";
                                    }

                                    else
                                    {
                                        Msj = "Su pago de encuentra en proceso, en dos días hábiles podrá consultar su estatus accediendo al <BR/> Sistema de Recaudación de Ingresos (https://sysweb.unach.mx/ingresos)";  //"PAGO EN PROCESO DE VALIDACIÓN";
                                    }


                                    SesionMultipago.Id_Fact = -1;
                                    CNMultipago.InsertarMultipago_Transaccion(ref SesionMultipago, ref Verificador);
                                    if (Verificador != "0")
                                        lblMsj.Text = Verificador;
                                    else
                                    {
                                        if (SesionMultipago.Id_Fact == -1)
                                            lblMsj.Text = Msj + SesionMultipago.Reference + "***";
                                        else
                                        {
                                            SesionMultipago.Id_Fact = SesionMultipago.Id_Fact;
                                            lblMsj.Text = "*" + Msj + "*";
                                            string ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=3&idFact=" + SesionMultipago.Id_Fact;
                                            string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);                                            
                                            Session["Multipago"] = null;
                                            SesionUsu.FichaReferencia = string.Empty;
                                            SesionUsu.FichaRefID = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    divPagoConf.Visible = false;
                                    divPagoNoConf.Visible = true;
                                }
                            }

                        }

                        else
                        {
                            lblMsj.Text = "ERROR 256";
                        }
                        //}
                        //catch (Exception ex)
                        //{
                        //    lblMsj.Text = lblMsj.Text + ex.Message;
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = lblMsj.Text + ex.Message;
            }
        
        }
        #region <Funciones y Sub>
        protected void DatosBancomer()
        {
            try
            {
                //SesionMultipago = (MultiPago)Session["Multipago"];
                //Session["Multipago"] = SesionMultipago;

                //string CadenaHash = CNComun.GetSHA256(SesionMultipago.Order + SesionMultipago.Reference + SesionMultipago.Amount + SesionMultipago.Authorization);               
                //if (SesionMultipago.Signature== CadenaHash)
                //{

                Verificador = string.Empty;
                string Msj = string.Empty;
                if (Convert.ToString(SesionMultipago.Account) != null)
                    ObjMultipago.Account = SesionMultipago.Account;
                if (Convert.ToString(SesionMultipago.Order) != null)
                    ObjMultipago.Order = SesionMultipago.Order;
                if (Convert.ToString(SesionMultipago.Reference) != null)
                    ObjMultipago.Reference = SesionMultipago.Reference;
                if (Convert.ToString(SesionMultipago.Node) != null)
                    ObjMultipago.Node = SesionMultipago.Node;
                if (Convert.ToString(SesionMultipago.Concept) != null)
                    ObjMultipago.Concept = SesionMultipago.Concept;
                if (Convert.ToString(SesionMultipago.Amount) != null)
                    ObjMultipago.Amount = SesionMultipago.Amount;
                if (Convert.ToString(SesionMultipago.Currency) != null)
                    ObjMultipago.Currency = SesionMultipago.Currency;
                if (Convert.ToString(SesionMultipago.PaymentMethod) != null)
                    ObjMultipago.PaymentMethod = SesionMultipago.PaymentMethod;
                if (Convert.ToString(SesionMultipago.PaymentMethodComplete) != null)
                    ObjMultipago.PaymentMethodComplete = SesionMultipago.PaymentMethodComplete;
                if (Convert.ToString(SesionMultipago.Response) != null)
                    ObjMultipago.Response = SesionMultipago.Response;
                if (Convert.ToString(SesionMultipago.ResponseComplete) != null)
                    ObjMultipago.ResponseComplete = SesionMultipago.ResponseComplete;
                if (Convert.ToString(SesionMultipago.Responsemsg) != null)
                    ObjMultipago.Responsemsg = SesionMultipago.Responsemsg;
                if (Convert.ToString(SesionMultipago.ResponseMsgComplete) != null)
                    ObjMultipago.ResponseMsgComplete = SesionMultipago.ResponseMsgComplete;
                if (Convert.ToString(SesionMultipago.Authorization) != null)
                    ObjMultipago.Authorization = SesionMultipago.Authorization;
                if (Convert.ToString(SesionMultipago.AuthorizationComplete) != null)
                    ObjMultipago.AuthorizationComplete = SesionMultipago.AuthorizationComplete;
                if (Convert.ToString(SesionMultipago.Pan) != null)
                    ObjMultipago.Pan = SesionMultipago.Pan;
                if (Convert.ToString(SesionMultipago.PanComplete) != null)
                    ObjMultipago.PanComplete = SesionMultipago.PanComplete;
                if (Convert.ToString(SesionMultipago.Date) != null)
                    ObjMultipago.Date = SesionMultipago.Date;
                if (Convert.ToString(SesionMultipago.Signature) != null)
                    ObjMultipago.Signature = SesionMultipago.Signature;
                if (Convert.ToString(SesionMultipago.Customername) != null)
                    ObjMultipago.Customername = SesionMultipago.Customername;
                if (Convert.ToString(SesionMultipago.Promo_Msi) != null)
                    ObjMultipago.Promo_Msi = SesionMultipago.Promo_Msi;
                //AQUI
                if (Convert.ToString(SesionMultipago.Bankcode) != null)
                    ObjMultipago.Bankcode = SesionMultipago.Bankcode;
                if (Convert.ToString(SesionMultipago.Saleid) != null)
                    ObjMultipago.Saleid = SesionMultipago.Saleid;
                if (Convert.ToString(SesionMultipago.Sale_Historyid) != null)
                    ObjMultipago.Sale_Historyid = SesionMultipago.Sale_Historyid;
                if (Convert.ToString(SesionMultipago.Trx_Historyid) != null)
                    ObjMultipago.Trx_Historyid = SesionMultipago.Trx_Historyid;
                if (Convert.ToString(SesionMultipago.Trx_Historyidcomplete) != null)
                    ObjMultipago.Trx_Historyidcomplete = SesionMultipago.Trx_Historyidcomplete;
                if (Convert.ToString(SesionMultipago.Bankname) != null)
                    ObjMultipago.Bankname = SesionMultipago.Bankname;
                if (Convert.ToString(SesionMultipago.Folio) != null)
                    ObjMultipago.Folio = SesionMultipago.Folio;
                if (Convert.ToString(SesionMultipago.Cardholdername) != null)
                    ObjMultipago.Cardholdername = SesionMultipago.Cardholdername;
                //if (Convert.ToString(SesionMultipago.Cardholdernamecomplete) != null)
                //    ObjMultipago.Cardholdernamecomplete = SesionMultipago.Cardholdernamecomplete;
                //if (Convert.ToString(SesionMultipago.Authorization_Mp1) != null)
                //    ObjMultipago.Authorization_Mp1 = SesionMultipago.Authorization_Mp1;                
                //ObjMultipago.Cardholdernamecomplete = null;                
                //ObjMultipago.Authorization_Mp1 = null;
                if (Convert.ToString(SesionMultipago.Phone) != null)
                    ObjMultipago.Phone = SesionMultipago.Phone;
                if (Convert.ToString(SesionMultipago.Email) != null)
                    ObjMultipago.Email = SesionMultipago.Email;
                if (Convert.ToString(SesionMultipago.Promo) != null)
                    ObjMultipago.Promo = SesionMultipago.Promo;
                if (Convert.ToString(SesionMultipago.Promo_msi_bank) != null)
                    ObjMultipago.Promo_msi_bank = SesionMultipago.Promo_msi_bank;
                if (Convert.ToString(SesionMultipago.Securepayment) != null)
                    ObjMultipago.Securepayment = SesionMultipago.Securepayment;
                if (Convert.ToString(SesionMultipago.Cardtype) != null)
                    ObjMultipago.Cardtype = SesionMultipago.Cardtype;
                ObjMultipago.IdFichaBancaria = SesionUsu.FichaRefID;
                ObjMultipago.Carrera = SesionUsu.UsuCarrera;
                ObjMultipago.Origen = "SYSWEB";


                string CadenaHash = CNComun.GetSHA256(SesionMultipago.Order + SesionMultipago.Reference + SesionMultipago.Amount + SesionMultipago.Authorization);
                if (SesionMultipago.Signature == CadenaHash)
                {
                    if (ObjMultipago.Authorization != null)
                    {
                        if (ObjMultipago.Authorization.Length >= 1)
                        {
                            if (ObjMultipago.Authorization != "000000")
                            {
                                Msj = "!PAGO REALIZADO CON ÉXITO¡";
                                lblmensaje2.Text = "Si desea descargar nuevamente su recibo oficial puede hacerlo accediendo al <BR/> Sistema de Recaudación de Ingresos (https://sysweb.unach.mx/ingresos)";
                            }

                            else
                                Msj = "PAGO EN PROCESO DE VALIDACIÓN";

                            lblmensaje2.Text = "Su pago de encuentra en proceso, en dos días hábiles podrá consultar su estatus accediendo al <BR/> Sistema de Recaudación de Ingresos (https://sysweb.unach.mx/ingresos)";

                            ObjMultipago.Id_Fact = -1;
                            CNMultipago.InsertarMultipago_Transaccion(ref ObjMultipago, ref Verificador);
                            if (Verificador != "0")
                                lblMsj.Text = Verificador;
                            else
                            {
                                if (ObjMultipago.Id_Fact == -1)
                                    lblMsj.Text = Msj + ObjMultipago.Reference + "***";
                                else
                                {
                                    SesionMultipago.Id_Fact = ObjMultipago.Id_Fact;
                                    lblMsj.Text = "*" + Msj + "*";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerRecibo(3," + ObjMultipago.Id_Fact + ");", true);
                                }
                            }
                        }
                    }
                    //else
                    //    CNMultipago.InsertarMultipago_Transaccion(ref ObjMultipago, ref Verificador);

                }

                else
                {
                    lblMsj.Text = "ERROR 256";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }
        protected void LimpiarSession()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
        #endregion

        protected void btnRecibo_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerRecibo(3,'" + SesionMultipago.Id_Fact + "');", true);
        }
    }
}