using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidad;
namespace EmisionPagoReferenciado.Form
{

    public partial class Activacion_Cuenta : System.Web.UI.Page
    {
        #region <Variables>
        CN_Alumno CNAlumno = new CN_Alumno();
        Alumno ObjAlumno = new Alumno();
        string Verificador = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["ActCtaM"] != null && Request.QueryString["ActCtaN"] != null)
                {
                    string Matricula = Request.QueryString["ActCtaM"];
                    string Nivel = Request.QueryString["ActCtaN"];
                    ActivacionMatricula(Matricula, Nivel);
                }
            }
        }
        #region <Funciones y Sub>
        private void ActivacionMatricula(string Matricula, string Nivel)
        {
            pnlMsjReg.Visible = false;
            lblMsjError.Text = string.Empty;
            Verificador = string.Empty;
            lblMsjActivacion.Text = string.Empty;
            try
            {

                ObjAlumno.Matricula = Matricula;
                ObjAlumno.Nivel = Nivel;
                CNAlumno.AlumnoClienteActivar(ObjAlumno, ref Verificador);
                if (Verificador == "0")
                    lblMsjActivacion.Text = "<font size=20px><STRONG>FELICIDADES </STRONG></font></br></br>Se ha activado tu cuenta, para el SYSWEB. </br>- Tu número de acceso es: <STRONG>" + Matricula+ "</STRONG></br></br>" +
                        "Te recordamos que con este registro puedes hacer tus pagos de cualquiera de las dependencias de la "+
                        "Universidad que ofertan sus servicios a través de SYSWEB.</br></br><div align='center'><a href='https://sysweb.unach.mx/DSIA/#Alumnos'>REALIZAR UN PAGO DE SERVICIO</a></div>";
            }
            catch(Exception ex)
            {
                pnlMsjReg.Visible = true;
                lblMsjError.Text = ex.Message;
            }
        }
        #endregion
        //&lt;strong&gt;FELICIDADES &lt;/strong&gt;&lt;/br&gt;&lt;/br&gt; Se ha activado tu cuenta, para el SYSWEB. </br>- Tu número de acceso es:
    }
}