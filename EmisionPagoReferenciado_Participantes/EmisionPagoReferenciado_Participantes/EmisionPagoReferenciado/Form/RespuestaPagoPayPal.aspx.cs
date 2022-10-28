using CapaEntidad;
using CapaNegocio;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmisionPagoReferenciado.Form
{
    public partial class RespuestaPagoPayPal : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        CN_PayPal CNPayPal = new CN_PayPal();
        InfPayPal objPayPal = new InfPayPal();

        InfPayPal SesionPayPal = new InfPayPal();
        //public static string secretkey = "ECC4E54DBA738857B84A7EBC6B5DC7187B8DA68750E88AB53AAA41F548D6F2D9";
        //public static string secretkey = "ECC4E54DBA738857B84A7EBC6B5DC7187B8DA68750E88AB53AAA41F548D6F2SYSW3B";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            //SesionPayPal = (InfPayPal)Session["PayPal"];
            if (Convert.ToString(Request.QueryString["idTransaccion"]) != null)
            {
                string tk = Request.QueryString["idTransaccion"];

                IJsonSerializer serializer = new JsonNetSerializer();
                var provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, algorithm);

                var payload = decoder.Decode(tk, CNPayPal.secretkey, verify: true);
                dynamic dato = JsonConvert.DeserializeObject<Object>(payload);
                string referencia = dato.referencia;
                string idTrans = dato.idTransaccion;
                lblIdTransaccion.Text = idTrans;
                //lblDependencia.Text = objPayPal.Dependencia;
                lblReferencia.Text = "Referencia: " + dato.referencia;
                lblNombre.Text = "Cliente: " + dato.nombre;
                lblImporte.Text = "Total: " + dato.total;
                //lblFechaPago.Text = objPayPal.Fecha_Pago;

                objPayPal.idTransaccion = idTrans;
                objPayPal.Referencia = referencia;

                CNPayPal.ObtenerDatosReferencia(ref objPayPal, ref Verificador);
                if (Verificador == "0")
                {
                    
                    if (objPayPal.IdRecibo != 0)
                    {
                        string ruta = "../Reportes/VisualizadorCrystal.aspx?cverep=3&idFact=" + objPayPal.IdRecibo;
                        string _open = "window.open('" + ruta + "', 'miniContenedor', 'toolbar=yes', 'location=no', 'menubar=yes', 'resizable=yes');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
                    }
                    //lblNombre.Text = "Nombre: " + dato.nombre;
                }


            }
        }
        protected void linkBttnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://sysweb.unach.mx/DSIA/");
        }

        protected void linkBttnRecibo_Click(object sender, EventArgs e)
        {
            
        }
    }
}