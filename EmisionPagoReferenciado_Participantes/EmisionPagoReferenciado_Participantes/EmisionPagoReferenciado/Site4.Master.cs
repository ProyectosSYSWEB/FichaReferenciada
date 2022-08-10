using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmisionPagoReferenciado
{
    public partial class Site4 : System.Web.UI.MasterPage
    {
        #region <Variables>
        Sesion SesionUsu = new Sesion();
        Menus menu = new Menus();
        CN_Menus CN_mnu = new CN_Menus();
        Comun ObjComun = new Comun();
        CN_Comun CNComun = new CN_Comun();
        string Verificador = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];


            //if (!IsPostBack)
                Inicializar();
        }

        private void Inicializar()
        {
            //onLine.Visible = false;
            //offLine.Visible = true;
            try
            {
                //if (SesionUsu != null)
                //    if (SesionUsu.UsuCorreo != null)
                //        if (SesionUsu.UsuCorreo != "")
                //        {
                //            onLine.Visible = true;
                //            offLine.Visible = false;
                //            lblCorreoUsuario.Text = SesionUsu.UsuCorreo;
                //        }
            }
            catch (Exception ex)
            {
                //lblMsj.Text = ex.Message;  
            }

        }
    }

}