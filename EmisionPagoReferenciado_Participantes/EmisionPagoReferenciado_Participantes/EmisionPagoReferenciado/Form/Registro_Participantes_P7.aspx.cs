using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CapaNegocio;

namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes_P7 : System.Web.UI.Page
    {
        #region <Variables>
        CN_Comun CNComun = new CN_Comun();
        static public String var = string.Empty;
        static public String palabra = "X";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*txtmp_account.Text = Request.Form["mp_account"];
                txtmp_product.Text = Request.Form["mp_product"];
                txtmp_order.Text = Request.Form["mp_order"];
                txtmp_reference.Text = Request.Form["mp_reference"];
                txtmp_node.Text = Request.Form["mp_node"];
                txtmp_concept.Text = Request.Form["mp_concept"];
                txtmp_amount.Text = Request.Form["mp_amount"];
                txtmp_customername.Text = Request.Form["mp_customername"];
                txtmp_currency.Text = Request.Form["mp_currency"];
                txtmp_signature.Text = Request.Form["mp_signature"];
                txtmp_urlsuccess.Text = Request.Form["mp_urlsuccess"];
                txtmp_urlfailure.Text = Request.Form["mp_urlfailure"];*/

                Uri myReferrer = Request.UrlReferrer;                                
                string OrigenUrl = myReferrer.Host.ToString();                
                if (OrigenUrl == "prepro.adquiracloud.mx")

                {
                    lblReference.Text = Request.Form["mp_reference"];
                    lblAmount.Text = string.Format("{0:c}",Convert.ToDouble(Request.Form["mp_amount"]));
                    string CadenaHash = CNComun.GetSHA256(Request.Form["mp_order"] + Request.Form["mp_reference"] + Request.Form["mp_amount"] + Request.Form["mp_authorization"]);
                    if (Request.Form["mp_signature"] == CadenaHash.ToLower())
                    {
                        if (Request.Form["mp_authorization"] != "000000")
                        {
                            lblMsj.Text = "PAGO EXITOSO"; // +CadenaHash;
                        }
                        else
                        {
                            lblMsj.Text = "PAGO EN PROCESO";
                        }
                    }
                    else
                    {
                        lblMsj.Text = "ERROR ..."; // +CadenaHash; // "ERROR";
                    }
                }

                else
                {
                    lblMsj.Text = "ERROR EN URL";
                }               
            }
        }

        protected void btnPago_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            if (var != string.Empty)
            {
                if (var == "ADMON" || var == "SUPERADMON")
                {
                    if (palabra != "X")
                        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var + "&WXI=" + palabra);
                    else
                        Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + var);
                }

            }
            else
                Response.Redirect("Registro_Participantes.aspx");
        }

        //private static string GetSHA256(string Signature)
        //{
        //    string message;
        //    string key;
        //    key = "ADQUIRA";
        //    message = Signature.ToLower();
        //    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        //    byte[] keyByte = encoding.GetBytes(key);

        //    HMACMD5 hmacmd5 = new HMACMD5(keyByte);
        //    HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
        //    //SHA256Managed hashString = new SHA256Managed();
        //    HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);

        //    byte[] messageBytes = encoding.GetBytes(message);

        //    //byte[] hashmessage = hmacmd5.ComputeHash(messageBytes);
        //    //this.hmac1.Text = ByteToString(hashmessage);

        //    //byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);
        //    //this.hmac2.Text = ByteToString(hashmessage);


        //    byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
        //    string Order = ByteToString(hashmessage);
        //    return Order;
        //}
        //private static string ByteToString(byte[] buff)
        //{
        //    string sbinary = "";

        //    for (int i = 0; i < buff.Length; i++)
        //    {
        //        sbinary += buff[i].ToString("X2"); // hex format
        //    }
        //    return (sbinary);
        //}


    }
}