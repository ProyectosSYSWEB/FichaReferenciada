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
            //if (!IsPostBack)
            //{
            //    Inicializar();

            //}
            if (SesionUsu != null)
            {
                if (SesionUsu.ComponentesExtras == "S")
                    CargarComponentesExtras();
            }
            else
                Response.Redirect("https://sysweb.unach.mx/");
        }

        //protected void Inicializar()
        //{

        //    if (SesionUsu.ComponentesExtras == "S")
        //    {
        //        ObjComponente.Evento = SesionUsu.UsuEvento;
        //        List<Componente> lstComponentes = new List<Componente>();
        //        CNParticipante.ConsultarEvento_Extras(ObjComponente, ref lstComponentes);
        //        if (lstComponentes.Count > 0)
        //        {
        //            Session["ComponentesExtras"] = lstComponentes;
        //            Panel divColuna = new Panel();

        //            foreach (Componente lst in lstComponentes)
        //            {
        //                string caseSwitch = lst.Control;
        //                switch (caseSwitch)
        //                {
        //                    case "TEXTBOX":
        //                        TextBox txtDinamico = new TextBox();
        //                        txtDinamico.ID = lst.IdControl;
        //                        placeHolderDin.Controls.Add(txtDinamico);
        //                        //Label newLine2 = new Label(); newLine2.Text = "<br/>";
        //                        break;
        //                    case "LABEL":

        //                        Label lblDinamico = new Label();
        //                        lblDinamico.ID = lst.IdControl;
        //                        placeHolderDin.Controls.Add(lblDinamico);
        //                        lblDinamico.Text = lst.Text;
        //                        //Label newLine = new Label(); newLine.Text = "<br/>";
        //                        break;
        //                    case "SELECT":
        //                        DropDownList ddlDinamico = new DropDownList();
        //                        ddlDinamico.ID = lst.IdControl;
        //                        CNComun.LlenaCombo("pkg_pagos_2016.OBT_Elementos_Control", ref ddlDinamico, "p_id_control", Convert.ToString(lst.IdComponente));
        //                        placeHolderDin.Controls.Add(ddlDinamico);
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //}
        private void CargarComponentesExtras()
        {
            pnlExtras.Visible = true;

            Componente ObjComponente = new Componente();
            ObjComponente.Evento = SesionUsu.UsuEvento;
            List<Componente> lstComponentes = new List<Componente>();
            List<Componente> lstValores = new List<Componente>();
            CNParticipante.ConsultarEvento_Extras(ObjComponente, ref lstComponentes);
            if (lstComponentes.Count > 0)
            {
                Session["ComponentesExtras"] = lstComponentes;
                if (Session["ValoresComponentesExtras"] != null)
                    lstValores = (List<Componente>)Session["ValoresComponentesExtras"];

                Panel divColuna = new Panel();

                foreach (Componente lst in lstComponentes)
                {
                    string caseSwitch = lst.Control;
                    Panel panel2 = new Panel();
                    switch (caseSwitch)
                    {
                        case "LABEL":
                            Label lblDinamico1 = new Label();
                            lblDinamico1.ID = lst.IdControl;
                            EnsureChildControls();
                            //panel2.Controls.Add(lblDinamico1);
                            pnlExtras.Controls.Add(lblDinamico1);
                            lblDinamico1.Text = lst.Text;
                            break;
                        case "TEXTBOX":
                            TextBox txtDinamico1 = new TextBox();
                            txtDinamico1.ID = lst.IdControl;
                            txtDinamico1.Text=ValoresComponentesExtras(lst.IdControl);
                            txtDinamico1.CssClass = "form-control";
                            if (lst.Style_Key != string.Empty && lst.Style_Value != string.Empty)
                                txtDinamico1.Style.Add(lst.Style_Key, lst.Style_Value);
                            EnsureChildControls();
                            panel2.Controls.Add(txtDinamico1);
                            pnlExtras.Controls.Add(panel2);

                            break;
                        case "SELECT":
                            DropDownList ddlDinamico1 = new DropDownList();
                            ddlDinamico1.ID = lst.IdControl;
                            CNComun.LlenaCombo("pkg_pagos_2016.OBT_Elementos_Control", ref ddlDinamico1, "p_id_control", Convert.ToString(lst.IdComponente));
                            //pnlExtras.Controls.Add(ddlDinamico1);
                            panel2.Controls.Add(ddlDinamico1);
                            pnlExtras.Controls.Add(panel2);
                            break;
                        case "REQUIRED":
                            RequiredFieldValidator requerido1 = new RequiredFieldValidator();
                            requerido1.ID = lst.IdControl;
                            requerido1.ControlToValidate = lst.IdControlValida;
                            requerido1.Text = "*Requerido";
                            requerido1.ErrorMessage = lst.MsgControlValida;
                            requerido1.ForeColor = System.Drawing.Color.Red;                          
                            requerido1.ValidationGroup = "next";
                            EnsureChildControls();
                            panel2.Controls.Add(requerido1);
                            pnlExtras.Controls.Add(panel2);

                            //pnlExtras.Controls.Add(requerido1);
                            break;
                    }
                }
            }
        }
        private string ValoresComponentesExtras(string Componente)
        {
            List<Componente> lstValores = new List<Componente>();
            try
            {
                if (Session["ValoresComponentesExtras"] != null)
                {
                    lstValores = (List<Componente>)Session["ValoresComponentesExtras"];

                    var elemento = lstValores.First(item => item.IdControl == Componente);


                    return elemento.Valor;
                }
                else
                    return "";

            }
            catch (Exception ex)
            {
                return "";
            }

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            List<Componente> lstComponentes = new List<Componente>();
            lstComponentes = (List<Componente>)Session["ComponentesExtras"];
            Session["ValoresComponentesExtras"] = null;
            if (lstComponentes.Count > 0)
            {
                foreach (Componente lst in lstComponentes)
                {
                    string caseSwitch = lst.Control;
                    List<Componente> lstComponentesGuardar = new List<Componente>();
                    Componente objComponentes = new Componente();

                    switch (caseSwitch)
                    {
                        case "TEXTBOX":
                            TextBox txt = pnlExtras.FindControl(lst.IdControl) as TextBox;
                            objComponentes.IdControl = lst.IdControl;
                            objComponentes.Valor = txt.Text;
                            break;
                        case "SELECT":
                            DropDownList ddl = pnlExtras.FindControl(lst.IdControl) as DropDownList;
                            objComponentes.IdControl = lst.IdControl;
                            objComponentes.Valor = ddl.SelectedValue;
                            break;
                    }
                    if (lst.Control == "TEXTBOX" || lst.Control == "SELECT")
                    {
                        if (Session["ValoresComponentesExtras"] != null)
                            lstComponentesGuardar = (List<Componente>)Session["ValoresComponentesExtras"];

                        lstComponentesGuardar.Add(objComponentes);
                        Session["ValoresComponentesExtras"] = lstComponentesGuardar;
                    }
                }

                if (SesionUsu.UsuWXI != "X")
                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                else if (SesionUsu.UsuWXIAdmon != "X")
                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                else
                    Response.Redirect("Registro_Participantes_P2.aspx" + "?Evento=" + SesionUsu.UsuEvento);


            }


        }
        //protected void btnSiguiente_Click(object sender, EventArgs e)
        //{
        //    if (SesionUsu.ComponentesExtras == "S")
        //    {
        //        List<Componente> lstComponentes = new List<Componente>();
        //        List<Componente> lstComponentesGuardar = new List<Componente>();
        //        lstComponentes = (List<Componente>)Session["ComponentesExtras"];
        //        if (lstComponentes.Count > 0)
        //        {
        //            int i = 1;
        //            foreach (Componente lst in lstComponentes)
        //            {
        //                string caseSwitch = lst.Control;
        //                switch (caseSwitch)
        //                {
        //                    case "TEXTBOX":
        //                        //TextBox txt = (TextBox)FindControl("MainContent_" + lst.IdControl);
        //                        TextBox txt = placeHolderDin.FindControl(lst.IdControl + i.ToString()) as TextBox;

        //                        lstComponentesGuardar[i].IdControl = lst.IdControl;
        //                        lstComponentesGuardar[i].Text = txt.Text;
        //                        break;
        //                    case "LABEL":
        //                        //Label lbl = (Label)FindControl("MainContent_" + lst.IdControl);
        //                        Label lbl = placeHolderDin.FindControl(lst.IdControl + i.ToString()) as Label;

        //                        lstComponentesGuardar[i].IdControl = lst.IdControl;
        //                        lstComponentesGuardar[i].Text = lst.Text;



        //                        break;
        //                    case "SELECT":
        //                        DropDownList ddl = (DropDownList)FindControl(lst.IdControl);
        //                        lstComponentesGuardar[i].IdControl = lst.IdControl;
        //                        lstComponentesGuardar[i].Text = ddl.SelectedValue;
        //                        break;
        //                }
        //                i++;
        //            }
        //        }
        //    }
        //}

        protected void btnAnterior_Click(object sender, EventArgs e)
        {

        }
    }
}