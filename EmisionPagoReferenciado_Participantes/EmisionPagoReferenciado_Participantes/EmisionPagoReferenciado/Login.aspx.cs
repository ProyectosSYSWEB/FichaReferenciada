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
    public partial class Login : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        CN_Usuario CN_Usuario = new CN_Usuario();
        Usuario Usuario = new Usuario();
        Sesion SesionUsu = new Sesion();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
            }
            //  RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
        #region <Botones y Eventos>
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarUsuario();
                if (Usuario.Login != "")
                {
                    IniciarSesion();

                }
                else
                {

                    this.LoginUser.FailureText = Verificador;
                    this.LoginUser.UserName = string.Empty;

                }
            }
            catch (Exception ex)
            {
                this.LoginUser.FailureText = ex.Message;

            }
        }
        #endregion
        #region <Funciones y Sub>

        public void IniciarSesion()
        {
            try
            {
                SesionUsu.UsuNombre = Usuario.Login;
                SesionUsu.UsuDependencia = Usuario.Dependencia;
                SesionUsu.UsuTipoUsu = Usuario.TipoUsu;

                if (Request.QueryString["XMLCadena"] != null)
                    SesionUsu.XMLCadena = Request.QueryString["XMLCadena"];
                else
                    SesionUsu.XMLCadena = "";

                Session["Sesion"] = SesionUsu;
                Session.Timeout = 20;
                Response.Redirect("~/Form/Registro_Participantes.aspx");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ValidarUsuario()
        {
            try
            {
                Usuario.Login = this.LoginUser.UserName.ToUpper();
                Usuario.Password = this.LoginUser.Password.ToUpper();

                CN_Usuario.ValidarUsuario(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ".-ValidarUsuario");
            }
        }

        private void CargarComboBasicos(string SP, ref DropDownList Combo)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}