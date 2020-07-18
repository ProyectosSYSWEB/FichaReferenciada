using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes_Extra : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        Comun ObjComun = new Comun();
        CN_Comun CNComun = new CN_Comun();
        Participante ObjParticipante = new Participante();
        Componente ObjComponente = new Componente();
        CN_Participante CNParticipante = new CN_Participante();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        private static List<Comun> ListTipoPartcipante = new List<Comun>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            if (!IsPostBack)
            {
                Inicializar();

            }
        }

        protected void Inicializar()
        {

            if (SesionUsu.ComponentesExtras == "S")
            {
                //SesionUsu.ComponentesExtras = "S";
                //pnlExtras.Visible = true;
                ObjComponente.Evento = SesionUsu.UsuEvento;
                List<Componente> lstComponentes = new List<Componente>();
                CNParticipante.ConsultarEvento_Extras(ObjComponente, ref lstComponentes);             
                if (lstComponentes.Count > 0)
                {
                    Session["ComponentesExtras"] = lstComponentes;
                    Panel divColuna = new Panel();

                    foreach (Componente lst in lstComponentes)
                    {
                        string caseSwitch = lst.Control;
                        switch (caseSwitch)
                        {
                            case "TEXTBOX":
                                TextBox txtDinamico = new TextBox();
                                txtDinamico.ID = lst.IdControl;
                                placeHolderDin.Controls.Add(txtDinamico);
                                //Label newLine2 = new Label(); newLine2.Text = "<br/>";
                                break;
                            case "LABEL":

                                Label lblDinamico = new Label();
                                lblDinamico.ID = lst.IdControl;
                                placeHolderDin.Controls.Add(lblDinamico);
                                lblDinamico.Text = lst.Text;
                                //Label newLine = new Label(); newLine.Text = "<br/>";
                                break;
                            case "SELECT":
                                DropDownList ddlDinamico = new DropDownList();
                                ddlDinamico.ID = lst.IdControl;
                                CNComun.LlenaCombo("pkg_pagos_2016.OBT_Elementos_Control", ref ddlDinamico, "p_id_control", Convert.ToString(lst.IdComponente));
                                placeHolderDin.Controls.Add(ddlDinamico);
                                break;
                        }
                    }
                }
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (SesionUsu.ComponentesExtras == "S")
            {
                List<Componente> lstComponentes = new List<Componente>();
                List<Componente> lstComponentesGuardar = new List<Componente>();
                lstComponentes = (List<Componente>)Session["ComponentesExtras"];
                if (lstComponentes.Count > 0)
                {
                    int i = 1;
                    foreach (Componente lst in lstComponentes)
                    {
                        string caseSwitch = lst.Control;
                        switch (caseSwitch)
                        {
                            case "TEXTBOX":
                                //TextBox txt = (TextBox)FindControl("MainContent_" + lst.IdControl);
                                TextBox txt = placeHolderDin.FindControl(lst.IdControl + i.ToString()) as TextBox;

                                lstComponentesGuardar[i].IdControl = lst.IdControl;
                                lstComponentesGuardar[i].Text = txt.Text;
                                break;
                            case "LABEL":
                                //Label lbl = (Label)FindControl("MainContent_" + lst.IdControl);
                                Label lbl = placeHolderDin.FindControl(lst.IdControl + i.ToString()) as Label;

                                lstComponentesGuardar[i].IdControl = lst.IdControl;
                                lstComponentesGuardar[i].Text = lst.Text;



                                break;
                            case "SELECT":
                                DropDownList ddl = (DropDownList)FindControl(lst.IdControl);
                                lstComponentesGuardar[i].IdControl = lst.IdControl;
                                lstComponentesGuardar[i].Text = ddl.SelectedValue;
                                break;
                        }
                        i++;
                    }
                }
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {

        }
    }
}