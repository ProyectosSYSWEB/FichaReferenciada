using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;

namespace EmisionPagoReferenciado
{
    public partial class SiteMaster : System.Web.UI.MasterPage
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
       
           
            if (!IsPostBack)
                Inicializar();
        }
        #region <Funciones y Sub>
        private void Inicializar()
        {           
            try
            {

                ObjComun.EtiquetaCuatro = SesionUsu.UsuEvento;

                //Image1.ImageUrl = string.Empty;

                //if (ObjComun.EtiquetaCuatro != "ALUMNO") Image1.ImageUrl = "https://sysweb.unach.mx/dsia/imageness/eventos/" + ObjComun.EtiquetaCuatro + ".png";
                //else Image1.ImageUrl = "https://sysweb.unach.mx/dsia/imageness/eventos/evento.png";
            }
            catch (Exception ex)
            {
                //lblMsj.Text = ex.Message;  
            }

        }
        #endregion


    }
}
