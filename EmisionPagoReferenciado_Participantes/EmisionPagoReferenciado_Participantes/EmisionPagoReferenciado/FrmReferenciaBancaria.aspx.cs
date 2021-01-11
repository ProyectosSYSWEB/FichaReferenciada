using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace EmisionPagoReferenciado
{
    public partial class FrmReferenciaBancaria : System.Web.UI.Page
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
            if (Request.QueryString["Matricula"] != null)
                if (Request.QueryString["Evento"] != null)
                    ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteIN(2,'" + Request.QueryString["Matricula"] + "','" + Request.QueryString["Evento"] + "');", true);
                else
                    lblMsj.Text = "Debe contener Matrícula ó Evento";
        }
        
        #endregion
    }
}