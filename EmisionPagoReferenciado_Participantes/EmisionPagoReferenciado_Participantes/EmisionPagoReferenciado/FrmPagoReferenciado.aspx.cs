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
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace EmisionPagoReferenciado
{
    public partial class FrmPagoReferenciado : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_FichaReferenciada CNFichaReferenciada = new CN_FichaReferenciada();
        FichaReferenciada ObjFichaReferenciada = new FichaReferenciada();
        Sesion SesionUsu = new Sesion();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["Sesion"];
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        #region <Botones y Eventos>
        protected void btnImprime_Ficha_Click(object sender, EventArgs e)
        {
            if (lblReferencia_l.Text == string.Empty)
                lblMsj.Text = "Debe Generar la Referencia Bancaria";
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporteEX(1,'" + lblNombre_l.Text + "','" + lblReferencia_l.Text + "','" + lblImporte_l.Text + "','" + lblVigencia_l.Text + "','" + lblConcepto_l.Text + "');", true);
        }

        protected void btnPago_Linea_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), UniqueID, "VerReporte2(2);", true);
        }
        #endregion
        #region <Funciones y Sub>
        private void Inicializar()
        {
            ConsultarDatos();
        }
        private void ConsultarDatos()
        {
            try
            {
                if (Request.QueryString["XMLCadena"] != null)
                    ObjFichaReferenciada.XMLCadena = Request.QueryString["XMLCadena"];
                else
                    ObjFichaReferenciada.XMLCadena = "";
                //ObjFichaReferenciada.XMLCadena = SesionUsu.XMLCadena;
                CNFichaReferenciada.ConsultarFichaReferenciada(ref ObjFichaReferenciada, ref Verificador);
                if (Verificador == "0")
                {
                    lblNombre_l.Text = ObjFichaReferenciada.Nombre;
                    lblImporte_l.Text = Convert.ToString(ObjFichaReferenciada.Importetotal);
                    lblVigencia_l.Text = ObjFichaReferenciada.FechaVigencia;
                    lblConcepto_l.Text = ObjFichaReferenciada.ConceptoRef;
                    lblReferencia_l.Text = ObjFichaReferenciada.Referencia;
                }
                else
                    lblMsj.Text = Verificador;
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        #endregion
    }
}