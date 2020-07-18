﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace EmisionPagoReferenciado.Form
{
    public partial class FrmAlumnos : System.Web.UI.Page
    {
        #region <Variables>
        string Verificador = string.Empty;
        int[] Celdas = new int[3];

        CN_Comun CNComun = new CN_Comun();
        Sesion SesionUsu = new Sesion();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
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
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMsj.Text = string.Empty;
            pnlDatos_Alumno.Visible = true;
            pnlPrincipal.Visible = false;
            SesionUsu.Id_Comprobante = 0;
            Nuevo();

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlDatos_Alumno.Visible = false;
            pnlPrincipal.Visible = true;
            Nuevo();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDatos();

        }
        //protected void grvAlumnos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    lblMsj.Text = string.Empty;
        //    try
        //    {
        //        int v = e.NewSelectedIndex;
        //        ObjAlumno.Matricula = grvAlumnos.Rows[v].Cells[0].Text;
        //        ObjAlumno.Dependencia = ddlDependencia.SelectedValue;
        //        ObjAlumno.Nivel = ddlNivel.SelectedValue;
        //        CNAlumno.ConsultarAlumnoSel(ref ObjAlumno, ref Verificador);
        //        if (Verificador == "0")
        //        {
        //            pnlDatos_Alumno.Visible = true;
        //            pnlPrincipal.Visible = false;
        //            SesionUsu.Id_Comprobante = 1;

        //            txtNombre.Text = ObjAlumno.Nombre;
        //            ddlCarrera.SelectedValue = ObjAlumno.Carrera;
        //            if (ddlCarrera.SelectedValue == "000000")
        //            {
        //                lblOtraCarrera.Visible = true;
        //                txtCarrera.Visible = true;
        //            }
        //            else
        //            {
        //                lblOtraCarrera.Visible = false;
        //                txtCarrera.Visible = false;

        //            }
        //            rdoGenero.SelectedValue = Convert.ToString(ObjAlumno.Genero);
        //            txtCorreo.Text = ObjAlumno.Correo;
        //            txtCarrera.Text = ObjAlumno.DescCarrera;
        //            txtSemestre.Text = ObjAlumno.Semestre;
        //            txtGrupo.Text = ObjAlumno.Grupo;
        //            txtMatricula.Text = grvAlumnos.Rows[v].Cells[0].Text;
        //            ddlDependencia_D.SelectedValue = ddlDependencia.SelectedValue;
        //            ddlNivel_D.SelectedValue = ddlNivel.SelectedValue;
        //            if (ObjAlumno.StatusMatricula == "A")
        //                chkActivo.Checked = true;
        //            else
        //                chkActivo.Checked = false;
        //        }
        //        else
        //            lblMsj.Text = Verificador;
        //    }
        //    catch (Exception ex)
        //    {
        //        lblMsj.Text = ex.Message;
        //    }
        //}
        protected void grvAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlumnos.PageIndex = 0;
            grvAlumnos.PageIndex = e.NewPageIndex;
            CargarGrid();
        }
        protected void ddlCarrera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCarrera.SelectedValue == "000000")
            {
                lblOtraCarrera.Visible = true;
                txtCarrera.Visible = true;
                txtCarrera.Text = string.Empty;
            }
            else
            {
                lblOtraCarrera.Visible = false;
                txtCarrera.Visible = false;
                txtCarrera.Text = ddlCarrera.SelectedItem.Text;

            }
        }
        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
        protected void ddlNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }
        #endregion
        #region <Funciones y Sub>

        private void Inicializar()
        {
            CargarCombos();
            CargarGrid();
        }
        private void CargarCombos()
        {
            try
            {
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Escuelas_Externos", ref ddlDependencia);
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel);
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Escuelas_Externos", ref ddlDependencia_D);
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Niveles", ref ddlNivel_D);
                CNComun.LlenaCombo("pkg_pagos.Obt_Combo_Carrera_Posgrado", ref ddlCarrera);
                if (ddlCarrera.SelectedValue == "000000")
                {
                    lblOtraCarrera.Visible = true;
                    txtCarrera.Visible = true;
                }
                else
                {
                    lblOtraCarrera.Visible = false;
                    txtCarrera.Visible = false;
                    txtCarrera.Text = ddlCarrera.SelectedItem.Text;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private void GuardarDatos()
        {
            try
            {
                ObjAlumno.Matricula = txtMatricula.Text.ToUpper();
                ObjAlumno.Nombre = txtNombre.Text;
                ObjAlumno.Semestre = txtSemestre.Text;
                ObjAlumno.Grupo = txtGrupo.Text;
                ObjAlumno.Carrera = ddlCarrera.SelectedValue;
                if (ddlCarrera.SelectedValue != "000000")
                    txtCarrera.Text = ddlCarrera.SelectedItem.Text;
                ObjAlumno.DescCarrera = txtCarrera.Text;
                ObjAlumno.UsuNombre = "Alumno";
                ObjAlumno.Nivel = ddlNivel_D.SelectedValue;
                ObjAlumno.Dependencia = ddlDependencia_D.SelectedValue;
                ObjAlumno.Correo = txtCorreo.Text;
                ObjAlumno.Genero = Convert.ToChar(rdoGenero.SelectedValue);
                if (chkActivo.Checked)
                    ObjAlumno.StatusMatricula = "A";
                else
                    ObjAlumno.StatusMatricula = "C";


                Verificador = string.Empty;
                if (SesionUsu.Id_Comprobante == 0)
                    CNAlumno.AlumnoInsertar(ObjAlumno, ref Verificador);
                else
                    CNAlumno.AlumnoEditar(ref ObjAlumno, ref Verificador);

                if (Verificador == "0")
                {
                    lblMsj.Text = "Los datos se guardaron correctamente.";
                }

                else
                {
                    lblMsj.Text = Verificador;
                }

                pnlDatos_Alumno.Visible = false;
                pnlPrincipal.Visible = true;
                Nuevo();
                CargarGrid();

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }
        }
        private List<Alumno> GetList()
        {
            try
            {
                List<Alumno> List = new List<Alumno>();
                ObjAlumno.Dependencia = ddlDependencia.SelectedValue;
                ObjAlumno.Nivel = ddlNivel.SelectedValue;
                CNAlumno.ConsultarAlumno(ref ObjAlumno, ref List);
                return List;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                grvAlumnos.DataSource = dt;
                grvAlumnos.DataSource = GetList();
                grvAlumnos.DataBind();
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
            }

        }
        private void Nuevo()
        {

            txtMatricula.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtSemestre.Text = string.Empty;
            txtGrupo.Text = string.Empty;
            txtCarrera.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            rdoGenero.SelectedValue = "M";
            ddlDependencia_D.SelectedValue = ddlDependencia.SelectedValue;
            ddlNivel_D.SelectedValue = ddlNivel.SelectedValue;
        }
        #endregion






    }
}