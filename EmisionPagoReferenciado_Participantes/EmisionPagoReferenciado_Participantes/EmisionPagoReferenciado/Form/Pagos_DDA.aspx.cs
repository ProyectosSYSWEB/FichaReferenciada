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
    public partial class Pagos_DDA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        #region <Funciones y Sub>
        private void Inicializar()
        {
            Uri myReferrer = Request.UrlReferrer;
            string OrigenUrl = myReferrer.Host.ToString();
            Label1.Text = OrigenUrl;
            if (OrigenUrl == "aspirantes.unach.mx")
            {
                Label2.Text = "PASO";
            }
            else
            {
                Label2.Text = "NO PASOOOOO";
            }
        }
        #endregion
    }
}