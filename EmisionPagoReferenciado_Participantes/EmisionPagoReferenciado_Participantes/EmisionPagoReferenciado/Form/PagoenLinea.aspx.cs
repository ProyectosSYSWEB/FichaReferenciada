using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmisionPagoReferenciado.Form
{
    public partial class PagoenLinea : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {                
                if (Request.QueryString["order_m"] != null)
                    mp_order.Value = Request.QueryString["order_m"];
                if (Request.QueryString["reference_m"] != null)
                    mp_reference.Value = Request.QueryString["reference_m"];
                if (Request.QueryString["amount_m"] != null)
                    mp_amount.Value = Request.QueryString["amount_m"];
                if (Request.QueryString["customername_m"] != null)
                    mp_customername.Value = Request.QueryString["customername_m"];

                mp_account.Value = "952";
                mp_product.Value = "1";                                
                mp_node.Value = "0";
                mp_concept.Value = "99";
                mp_amount.Value = string.Format("{0:0.00}", mp_amount.Value);                
                mp_currency.Value = "1";
                mp_signature.Value = CNComun.GetSHA256(Convert.ToString(mp_order.Value + mp_reference.Value + mp_amount.Value));
                mp_urlsuccess.Value = "https://sysweb.unach.mx/FichaReferenciada/Form/RespuestaPagoenLinea.aspx"; //"Registro_Participantes_P7.aspx";
                mp_urlfailure.Value = "https://sysweb.unach.mx/FichaReferenciada/Form/RespuestaPagoenLinea.aspx"; // "Registro_Participantes_P7.aspx";
                ClientScript.RegisterStartupScript(this.GetType(), "myScript", "PagBancomer();", true);
            }
        }
    }
}