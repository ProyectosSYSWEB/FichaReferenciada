using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocio;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace EmisionPagoReferenciado.Form
{
    public partial class Registro_Participantes_P2 : System.Web.UI.Page
    {
        #region <Variables>
        String Verificador = string.Empty;
        Sesion SesionUsu = new Sesion();
        Comun ObjComun = new Comun();
        CN_Comun CNComun = new CN_Comun();
        String Mensaje = string.Empty;
        List<Comun> ListDetConceptoDisp = new List<Comun>();
        List<Comun> ListDetConceptoAsig = new List<Comun>();
        Participante ObjParticipante = new Participante();
        CN_Participante CNParticipante = new CN_Participante();
        Alumno ObjAlumno = new Alumno();
        CN_Alumno CNAlumno = new CN_Alumno();
        ConceptoPago ObjConcepto = new ConceptoPago();
        CN_ConceptoPago CNConcepto = new CN_ConceptoPago();
        List<ConceptoPago> ListConcepto = new List<ConceptoPago>();
        DetConcepto ObjDetConcepto = new DetConcepto();
        CN_DetConcepto CNDetConcepto = new CN_DetConcepto();
        FichaReferenciada ObjFichaReferenciada = new FichaReferenciada();
        CN_FichaReferenciada CNFichaReferenciada = new CN_FichaReferenciada();
        CN_Componente CNComponente = new CN_Componente();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            SesionUsu = (Sesion)Session["SesionFicha"];
            if (SesionUsu != null)
            {
                if (!IsPostBack)
                    Inicializar();
            }
            else
                Response.Redirect("https://sysweb.unach.mx/");
        }
        #region <Botones y Eventos>
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            lblMsj.Visible = false;
            try
            {
                if (lstMaterias_Asignadas.Items.Count > 1) // SE CARGAN ESTOS DATOS PARA GENERAR LA REFERENCIA FINAL
                {
                    ObjFichaReferenciada.IdFichaBancaria = SesionUsu.FichaRefID;
                    ObjFichaReferenciada.NoControl = SesionUsu.UsuMatricula;
                    ObjFichaReferenciada.Nivel = SesionUsu.UsuNivel;
                    ObjFichaReferenciada.Dependencia = SesionUsu.UsuDependencia;
                    ObjFichaReferenciada.Vigencia = SesionUsu.FichaVigencia;
                    ObjFichaReferenciada.Importetotal = SesionUsu.ImpDetalleConcep;                    
                    ObjFichaReferenciada.Evento = SesionUsu.UsuEvento;
                    SesionUsu.FichaReferencia = GetReferencia();
                    if (SesionUsu.ComponentesExtras == "S")
                    {
                        Verificador = string.Empty;
                        List<Componente> lstComponentes = new List<Componente>();
                        lstComponentes = (List<Componente>)Session["ValoresComponentesExtras"];
                        CNComponente.InsertarValores(SesionUsu.FichaRefID, lstComponentes, SesionUsu.UsuEvento, ref Verificador);
                        if (Verificador != "0")
                        {
                            //SesionUsu.Operacion = "I";
                            lblMsj.Visible = true;
                            lblMsj.Text = Verificador;
                        }
                    }

                    if (SesionUsu.TipoPersona == 20)
                        SesionUsu.Anexo = " REQUERIMIENTOS: " + txtObservaciones2.Text + ".    MATRICULA CAPTURADA: " + SesionUsu.MatriculaCapturada; // +" --PERIDO DE PAGO:"+SesionUsu.Observaciones;
                    else
                        SesionUsu.Anexo = " REQUERIMIENTOS: " + txtObservaciones2.Text; //+ " --PERIDO DE PAGO:" + SesionUsu.Observaciones;

                    UpdateFichaReferenciada(ref Verificador);
                    if (Verificador == "0")
                    {
                        if (SesionUsu.UsuEvento != string.Empty)
                        {
                            if (SesionUsu.UsuWXI != "X")
                                Response.Redirect("Registro_Participantes_P5.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                            else if (SesionUsu.UsuWXIAdmon != "X")
                                Response.Redirect("Registro_Participantes_P5.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                            else
                                Response.Redirect("Registro_Participantes_P5.aspx" + "?Evento=" + SesionUsu.UsuEvento);
                        }
                        else
                            Response.Redirect("Registro_Participantes_P5.aspx");
                    }
                    else
                        lblMsj.Text = Verificador;
                }
                else
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = "Debe agregar al menos un elemento a lista de --Seleccionados--";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }

        private void UpdateFichaReferenciada(ref string MsjVerificador)
        {
            try
            {

                ObjFichaReferenciada.IdFichaBancaria = SesionUsu.FichaRefID;
                ObjFichaReferenciada.Importetotal = SesionUsu.ImpDetalleConcep;
                ObjFichaReferenciada.Referencia = SesionUsu.FichaReferencia;
                if (SesionUsu.UsuEvento == "FINANZAS_2016")
                    ObjFichaReferenciada.ConceptoRef = SesionUsu.Observaciones + " PERIDO_PAGO:" + SesionUsu.PeriodoPago + SesionUsu.Anexo;
                else
                    ObjFichaReferenciada.ConceptoRef = SesionUsu.Observaciones + SesionUsu.Anexo;



                ObjFichaReferenciada.Evento = SesionUsu.UsuEvento;
                ObjFichaReferenciada.NoControl = SesionUsu.UsuMatricula;
                ObjFichaReferenciada.Correo = SesionUsu.UsuCorreo;
                if (SesionUsu.TipoPersona == 1)
                    ObjFichaReferenciada.Nombre = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;

                else
                    ObjFichaReferenciada.Nombre = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;

                CNFichaReferenciada.ActualizarFichaReferenciada(ref ObjFichaReferenciada, ref Verificador);

                if (Verificador == "0")
                {
                    lblMsj.Text = string.Empty;
                    SesionUsu.FichaOpcion = 1;
                }
                else
                {

                    MsjVerificador = Verificador;
                }
            }
            catch (Exception ex)
            {
                MsjVerificador = ex.Message;
            }

        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (SesionUsu.UsuEvento != string.Empty)
            {
                if (SesionUsu.ComponentesExtras == "S")
                    Response.Redirect("Registro_Participantes_Extra.aspx" + "?Evento=" + SesionUsu.UsuEvento);
                else if (SesionUsu.UsuWXI != "X")
                    Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXI=" + SesionUsu.UsuWXI);
                else if (SesionUsu.UsuWXIAdmon != "X")
                    Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + SesionUsu.UsuEvento + "&WXIEvento=" + SesionUsu.UsuWXIAdmon);
                else
                    Response.Redirect("Registro_Participantes.aspx" + "?Evento=" + SesionUsu.UsuEvento);
            }
            else
                Response.Redirect("Registro_Participantes.aspx");
        }
        protected void btnAgregar_Materia_Click(object sender, EventArgs e)
        {
            lblMsj.Visible = false;
            try
            {

                if (SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaTres == "C")//tipo registro: C=Concepto, M= Materia, I=nada
                {
                    GetConfigurarConcepto(Convert.ToInt32(lstMaterias_Disponibles.SelectedValue));
                    if (SesionUsu.Operacion == "I")
                    {
                        AddFichaReferenciada();
                    }
                    AddConceptoPago();

                }
                else if (SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaTres == "M")
                {
                    GetConfigurarConcepto(Convert.ToInt32(SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaCuatro));
                    if (SesionUsu.Operacion == "I")
                    {
                        AddFichaReferenciada();
                    }
                    AddConceptoPago();


                    ObjDetConcepto.IdConcepto = SesionUsu.ConceptoID;
                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(lstMaterias_Disponibles.SelectedValue);

                    CNDetConcepto.ValidarMateria(ref Verificador, ref ObjDetConcepto);
                    if (Verificador == "0")
                    {
                        ObjDetConcepto.CicloEscolar = ObjConcepto.CicloEscolar;
                        ObjDetConcepto.Semestre = SesionUsu.UsuSemestre;
                        ObjDetConcepto.Grupo = SesionUsu.UsuGrupo;
                        ObjDetConcepto.Evento = SesionUsu.UsuEvento;
                        ObjDetConcepto.ImporteDetalle = Convert.ToDouble(SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaDos);
                        CNDetConcepto.InsertarDetConcepto(ref Verificador, ref ObjDetConcepto);

                    }
                    else
                    {
                        lblMsj.Visible = true;
                        lblMsj.Text = Verificador;
                    }
                }
                if (Verificador == "0")
                {
                    CargarComboMaterias();
                }
                else
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = "No se pudo agregar los datos: " + Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        protected void btnEliminar_Materia_Click(object sender, EventArgs e)
        {
            lblMsj.Visible = false;
            try
            {
                lblMsj.Text = string.Empty;
                ObjDetConcepto.TipoRegistro = SesionUsu.ListDetConceptoAsig[lstMaterias_Asignadas.SelectedIndex].EtiquetaTres;
                if (ObjDetConcepto.TipoRegistro == "M")
                {
                    ObjDetConcepto.IdConcepto = SesionUsu.ConceptoID;
                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(lstMaterias_Asignadas.SelectedValue);
                }
                else if (ObjDetConcepto.TipoRegistro == "C")
                {
                    ObjDetConcepto.IdConcepto = Convert.ToInt32(lstMaterias_Asignadas.SelectedValue);
                    ObjDetConcepto.IdDetConcepto = 0;
                }
                else
                {
                    ObjDetConcepto.IdConcepto = SesionUsu.ConceptoID;
                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(lstMaterias_Asignadas.SelectedValue);
                }
                CNDetConcepto.EliminarDetConcepto(ref Verificador, ref ObjDetConcepto);
                if (Verificador == "0")
                {
                    CargarComboMaterias();
                    txtImporteAdd.Text = "";
                }
                else
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        protected void lstMaterias_Disponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMsj.Visible = false;
            lblDescMatDisp.Text = string.Empty;
            try
            {
                if (Convert.ToDouble(SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaDos) == 0)
                {
                    if (SesionUsu.UsuEvento != "EXTRAORDINARIO")
                    {
                        txtImporteAdd.Visible = true;
                        lblImporteAdd.Visible = true;
                        txtImporteAdd.Text = "";
                    }
                }
                else
                {
                    txtImporteAdd.Visible = false;
                    lblImporteAdd.Visible = false;
                    txtImporteAdd.Text = SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaDos;
                }
                lblDescMatDisp.Text = lstMaterias_Disponibles.SelectedItem.Text;
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }

        #endregion
        #region <Funciones y Sub>
        private void Inicializar()
        {
            lblDescMatDisp.Text = string.Empty;
            lblDescMatAsig.Text = string.Empty;
            lblMsj.Text = string.Empty;
            lblMsj.Visible = false;
            try
            {
                if (Request.QueryString["Evento"] != null)
                {
                    SesionUsu.UsuEvento = Request.QueryString["Evento"];
                    ObjParticipante.Evento = SesionUsu.UsuEvento;
                    CNParticipante.ConsultarEvento(ref ObjParticipante, ref Verificador);
                    if (ObjParticipante.StatusEvento == 'N')
                    {
                        SesionUsu.UsuEvento = "ALUMNO";
                        lblMsj.Visible = true;
                        lblMsj.Text = "El Evento no esta Vigente, favor de comunicarse con el administrador de la Dependencia";
                        btnSiguiente.Visible = false;
                    }
                    else
                    {
                        lblMsj.Text = "";
                        if (SesionUsu.UsuEvento != "ALUMNO")
                            if (SesionUsu.UsuEvento != "EXTRAORDINARIO")
                                if (SesionUsu.UsuEvento != "VERANO")
                                    if (SesionUsu.UsuEvento != "POSGRADO")
                                        if (SesionUsu.UsuEvento != "LIBRE")
                                            if (SesionUsu.UsuEvento != "SUPERADMON")
                                                if (SesionUsu.UsuEvento != "RENDIMIENTOS")
                                                    if (SesionUsu.UsuEvento != "ADMON")
                                                        SesionUsu.UsuDependencia = ObjParticipante.Dependencia;

                        btnSiguiente.Visible = true;


                    }
                }
                else

                    SesionUsu.UsuEvento = "ALUMNO";
                //-------------------------------------------------------------------


                if (SesionUsu.FichaRefID == 0)
                {
                    SesionUsu.Operacion = "I";

                }
                lblEvento.Text = ObjParticipante.EventoStr;
                //lblEvento.Text = ObjParticipante.EventoStr + " " + SesionUsu.FichaReferencia;

                CargarCombos();
                if (String.IsNullOrEmpty(SesionUsu.Anexo))
                    txtObservaciones2.Text = SesionUsu.Anexo;
                else
                    txtObservaciones2.Text = SesionUsu.Anexo.Replace(" REQUERIMIENTOS: ", "");
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;

            }
        }
        private void CargarCombos()
        {
            lblMsj.Visible = false;
            try
            {
                if (SesionUsu.TipoPersona == 1)
                    if (SesionUsu.UsuEvento == "EXTRAORDINARIO" || SesionUsu.UsuEvento == "VERANO" || SesionUsu.UsuEvento == "POSGRADO" || SesionUsu.UsuEvento == "NINGUNO" || SesionUsu.UsuEvento == "LIBRE" || SesionUsu.UsuEvento == "ALUMNO" || SesionUsu.UsuEvento == "ADMON" || SesionUsu.UsuEvento == "SUPERADMON")
                        CargarCombo("pkg_pagos.Obt_Combo_Materias_Arbol", ref lstMaterias_Disponibles, "p_matricula", "p_evento", "p_carrera", "p_escuela", "p_nivel", "p_usuario", SesionUsu.UsuMatricula, SesionUsu.UsuEvento, SesionUsu.UsuCarrera, SesionUsu.UsuDependencia, SesionUsu.UsuNivel, SesionUsu.UsuWXI, ref ListDetConceptoDisp);
                    else
                        CargarCombo("pkg_pagos.Obt_Combo_Materias_Arbol", ref lstMaterias_Disponibles, "p_matricula", "p_evento", "p_carrera", "p_escuela", "p_nivel", "p_usuario", SesionUsu.UsuMatricula, SesionUsu.UsuEvento, Convert.ToString(SesionUsu.TipoPersona), SesionUsu.UsuDependencia, SesionUsu.UsuNivel, SesionUsu.UsuWXI, ref ListDetConceptoDisp);
                else
                    CargarCombo("pkg_pagos.Obt_Combo_Materias_Arbol", ref lstMaterias_Disponibles, "p_matricula", "p_evento", "p_carrera", "p_escuela", "p_nivel", "p_usuario", SesionUsu.UsuMatricula, SesionUsu.UsuEvento, SesionUsu.TipoPersona.ToString(), SesionUsu.UsuDependencia, SesionUsu.UsuNivel, SesionUsu.UsuWXI, ref ListDetConceptoDisp);
                CopiarComboDisp(ref ListDetConceptoDisp);
                CargarComboMaterias();
                Titulo(lstMaterias_Disponibles);
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        private void CargarCombo(string SP, ref ListBox Combo, string parametro1, string parametro2, string parametro3, string parametro4, string valor1, string valor2, string valor3, string valor4, ref List<Comun> Etiquetas)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, parametro1, parametro2, parametro3, parametro4, valor1, valor2, valor3, valor4, ref Etiquetas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarCombo(string SP, ref ListBox Combo, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string valor1, string valor2, string valor3, string valor4, string valor5, ref List<Comun> Etiquetas)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, parametro1, parametro2, parametro3, parametro4, parametro5, valor1, valor2, valor3, valor4, valor5, ref Etiquetas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarCombo(string SP, ref ListBox Combo, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string parametro6, string valor1, string valor2, string valor3, string valor4, string valor5, string valor6, ref List<Comun> Etiquetas)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, parametro1, parametro2, parametro3, parametro4, parametro5, parametro6, valor1, valor2, valor3, valor4, valor5, valor6, ref Etiquetas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarCombo(string SP, ref ListBox Combo, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, parametro1, parametro2, parametro3, valor1, valor2, valor3);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarCombo(string SP, ref ListBox Combo, string parametro1, string parametro2, string parametro3, string valor1, string valor2, string valor3, ref List<Comun> Etiquetas)
        {
            try
            {
                CN_Comun CNComun = new CN_Comun();
                CNComun.LlenaCombo(SP, ref Combo, parametro1, parametro2, parametro3, valor1, valor2, valor3, ref Etiquetas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CargarComboMaterias()
        {
            lblMsj.Visible = false;
            try
            {
                //ListDetConceptoAsig.Clear();
                if (SesionUsu.TipoPersona == 1)
                    if (SesionUsu.UsuEvento == "EXTRAORDINARIO" || SesionUsu.UsuEvento == "VERANO" || SesionUsu.UsuEvento == "POSGRADO" || SesionUsu.UsuEvento == "NINGUNO" || SesionUsu.UsuEvento == "LIBRE" || SesionUsu.UsuEvento == "ALUMNO" || SesionUsu.UsuEvento == "ADMON" || SesionUsu.UsuEvento == "SUPERADMON")
                        CargarCombo("pkg_pagos.Obt_Grid_Materias_Arbol", ref lstMaterias_Asignadas, "p_evento", "p_concepto", "p_carrera", "p_escuela", "p_ficha_bancaria", SesionUsu.UsuEvento, SesionUsu.ConceptoID.ToString(), SesionUsu.UsuCarrera, SesionUsu.UsuDependencia, SesionUsu.FichaRefID.ToString(), ref ListDetConceptoAsig);
                    else
                        CargarCombo("pkg_pagos.Obt_Grid_Materias_Arbol", ref lstMaterias_Asignadas, "p_evento", "p_concepto", "p_carrera", "p_escuela", "p_ficha_bancaria", SesionUsu.UsuEvento, SesionUsu.ConceptoID.ToString(), Convert.ToString(SesionUsu.TipoPersona), SesionUsu.UsuDependencia, SesionUsu.FichaRefID.ToString(), ref ListDetConceptoAsig);
                else
                    CargarCombo("pkg_pagos.Obt_Grid_Materias_Arbol", ref lstMaterias_Asignadas, "p_evento", "p_concepto", "p_carrera", "p_escuela", "p_ficha_bancaria", SesionUsu.UsuEvento, SesionUsu.ConceptoID.ToString(), SesionUsu.TipoPersona.ToString(), SesionUsu.UsuDependencia, SesionUsu.FichaRefID.ToString(), ref ListDetConceptoAsig);
                CopiarComboAsig(ref ListDetConceptoAsig);
                Titulo(lstMaterias_Asignadas);
                Titulo(lstMaterias_Disponibles);
                if (SesionUsu.ListDetConceptoAsig.Count > 0)
                {
                    int v = SesionUsu.ListDetConceptoAsig.Count;
                    int i = 1;
                    ObjDetConcepto.ImporteDetalle = 0.00;
                    ObjDetConcepto.Observaciones = "";

                    while (i < v)
                    {
                        //ObjDetConcepto.Observaciones += "\n" + ListDetConceptoAsig[i].Descripcion.TrimStart('.') + "(" + ListDetConceptoAsig[i].IdStr + ")";
                        ObjDetConcepto.Observaciones += "     " + SesionUsu.ListDetConceptoAsig[i].Descripcion.TrimStart('.') + "\n";
                        ObjDetConcepto.ImporteDetalle += Convert.ToDouble(SesionUsu.ListDetConceptoAsig[i].EtiquetaCuatro);
                        i = i + 1;
                    }
                    SesionUsu.ImpDetalleConcep = ObjDetConcepto.ImporteDetalle;
                    SesionUsu.Observaciones = ObjDetConcepto.Observaciones;


                    if (Convert.ToInt32(ObjConcepto.MaxMateria) == SesionUsu.ListDetConceptoAsig.Count)
                    {
                        //btnAgregar_Materia.Enabled = false; MOD VERSION ACT TEMPLATE
                        linkBttnAgregar.Enabled = false;
                        lblMsj.Visible = true;
                        lblMsj.Text = "Sólo puede Agregar " + (Convert.ToInt32(ObjConcepto.MaxMateria) - 2) + " Talleres, Conferencias ó Materias";
                    }
                    else
                    {
                        //btnAgregar_Materia.Enabled = true; MOD VERSION ACT TEMPLATE
                        linkBttnAgregar.Enabled = true;
                        // lblMsj.Text = string.Empty;
                    }
                }
                else
                {
                    SesionUsu.ListDetConceptoAsig.Clear();
                    SesionUsu.ImpDetalleConcep = 0.00;

                }
                if (SesionUsu.TipoPersona == 15)
                    SesionUsu.ImpDetalleConcep = ObjConcepto.ImporteConcepto;

                ObjFichaReferenciada.Importetotal = SesionUsu.ImpDetalleConcep;
                lblImporteTotal.Text = string.Format("{0:c2}", ObjFichaReferenciada.Importetotal);
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
        private int GetID()
        {
            int ID = 0;
            lblMsj.Visible = false;
            try
            {
                ObjFichaReferenciada = new FichaReferenciada();
                CNFichaReferenciada.GenerarID(ref ObjFichaReferenciada);
                ID = ObjFichaReferenciada.IdFichaBancaria;

            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
            return ID;

        }
        private string GetReferencia()
        {
            string Referencia = "";
            lblMsj.Visible = false;
            try
            {
                CNFichaReferenciada.GenerarReferencia(ref ObjFichaReferenciada);
                Referencia = ObjFichaReferenciada.Referencia;
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
            return Referencia;
        }
        private void GetConfigurarConcepto(int idConcepto)
        {
            lblMsj.Visible = false;
            try
            {
                ObjConcepto = new ConceptoPago();

                ObjConcepto.IdConcepto = idConcepto;// idconcepto clave
                ObjConcepto.Dependencia = SesionUsu.UsuDependencia;
                if (SesionUsu.TipoPersona == 1)
                    ObjConcepto.TipoPersonaStr = SesionUsu.UsuCarrera;
                else
                    ObjConcepto.TipoPersonaStr = Convert.ToString(SesionUsu.TipoPersona);
                ObjConcepto.Donativo = Convert.ToInt32(SesionUsu.Donativo);
                ObjConcepto.Evento = SesionUsu.UsuEvento;
                ObjConcepto.NoControl = SesionUsu.UsuMatricula;
                CNConcepto.ConfigurarConceptoPago(ref ObjConcepto, ref Verificador);
                SesionUsu.FichaVigencia = ObjConcepto.DiasVigencia;
                SesionUsu.FechaVigencia = ObjConcepto.FechaVigencia;

            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }
        private void AddConceptoPago()
        {
            lblMsj.Visible = false;
            try
            {
                lblMsj.Text = string.Empty;
                ObjConcepto.IdFichaBancaria = SesionUsu.FichaRefID;
                CNConcepto.ValidarConcepto(ref ObjConcepto, ref Verificador, ref Mensaje);
                if (Verificador == "0")
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = Mensaje;
                    ObjConcepto.Id = GetID();// Se creo una nueva fichareferenciada

                    ListConcepto.Add(ObjConcepto);
                    if (ObjConcepto.ImporteConcepto == 0)
                    {
                        ObjConcepto.ImporteConcepto = Convert.ToDouble(txtImporteAdd.Text);
                        if (ObjConcepto.ImporteConcepto == 0)
                        {
                            ObjConcepto.ImporteConcepto = 1;

                        }
                    }
                    CNConcepto.InsertarConceptoPago(ref Verificador, ref ListConcepto);
                    if (Verificador == "0")
                    {

                        SesionUsu.ConceptoID = ObjConcepto.Id;

                    }
                    else
                    {
                        lblMsj.Visible = true;
                        lblMsj.Text = Verificador;
                    }
                }
                else
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = Mensaje;
                    SesionUsu.ConceptoID = ObjConcepto.Id;

                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }
        private void AddFichaReferenciada()
        {
            lblMsj.Visible = false;
            try
            {

                ObjFichaReferenciada.IdFichaBancaria = GetID();
                ObjFichaReferenciada.NoControl = SesionUsu.UsuMatricula;
                ObjFichaReferenciada.Nivel = SesionUsu.UsuNivel;
                ObjFichaReferenciada.Dependencia = SesionUsu.UsuDependencia;
                if (SesionUsu.TipoPersona == 1)
                {
                    ObjFichaReferenciada.Carrera = SesionUsu.UsuCarrera;
                    ObjFichaReferenciada.Nombre = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                }
                else
                {

                    ObjFichaReferenciada.Carrera = Convert.ToString(SesionUsu.TipoPersona);
                    ObjFichaReferenciada.Nombre = SesionUsu.UsuNombre + " " + SesionUsu.UsuApaterno + " " + SesionUsu.UsuAMaterno;
                }
                ObjFichaReferenciada.Vigencia = ObjConcepto.DiasVigencia;
                ObjFichaReferenciada.Importetotal = ObjConcepto.ImporteConcepto;
                ObjFichaReferenciada.CicloEscolar = ObjConcepto.CicloEscolar;
                ObjFichaReferenciada.Evento = SesionUsu.UsuEvento;
                ObjFichaReferenciada.Referencia = GetReferencia();
                ObjFichaReferenciada.ConceptoRef = "";
                ObjFichaReferenciada.Grupo = SesionUsu.UsuGrupo;
                ObjFichaReferenciada.Semestre = SesionUsu.UsuSemestre;
                //ObjFichaReferenciada.Evento = SesionUsu.UsuEvento;
                ObjFichaReferenciada.Correo = SesionUsu.UsuCorreo;
                CNFichaReferenciada.InsertarFichaReferenciada(ref ObjFichaReferenciada, SesionUsu.UsuCorreo, SesionUsu.UsuWXI, ref Verificador);

                if (Verificador == "0")
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = string.Empty;
                    SesionUsu.Operacion = "U";
                    SesionUsu.FichaRefID = ObjFichaReferenciada.IdFichaBancaria;
                }
                else
                {
                    SesionUsu.Operacion = "I";
                    lblMsj.Visible = true;
                    lblMsj.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }

        }
        public void Titulo(ListBox LBX)
        {
            if (LBX != null)
                foreach (ListItem li in LBX.Items)
                    li.Attributes.Add("title", li.Text);
        }
        private void CopiarComboDisp(ref List<Comun> LBXPasa)
        {
            try
            {
                SesionUsu.ListDetConceptoDisp.Clear();
                for (int i = 0; i < LBXPasa.Count; i++)
                {
                    ObjComun = new Comun();
                    ObjComun.Id = LBXPasa[i].Id;
                    ObjComun.IdStr = LBXPasa[i].IdStr;
                    ObjComun.Descripcion = LBXPasa[i].Descripcion;
                    ObjComun.EtiquetaDos = LBXPasa[i].EtiquetaDos;
                    ObjComun.EtiquetaTres = LBXPasa[i].EtiquetaTres;
                    ObjComun.EtiquetaCuatro = LBXPasa[i].EtiquetaCuatro;
                    ObjComun.EtiquetaCinco = LBXPasa[i].EtiquetaCinco;
                    SesionUsu.ListDetConceptoDisp.Add(ObjComun);
                }
                //  Sorting(ref LBXRecibe);
                LBXPasa.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void CopiarComboAsig(ref List<Comun> LBXPasa)
        {
            try
            {
                SesionUsu.ListDetConceptoAsig.Clear();

                for (int i = 0; i < LBXPasa.Count; i++)
                {
                    ObjComun = new Comun();
                    ObjComun.Id = LBXPasa[i].Id;
                    ObjComun.IdStr = LBXPasa[i].IdStr;
                    ObjComun.Descripcion = LBXPasa[i].Descripcion;
                    ObjComun.EtiquetaDos = LBXPasa[i].EtiquetaDos;
                    ObjComun.EtiquetaTres = LBXPasa[i].EtiquetaTres;
                    ObjComun.EtiquetaCuatro = LBXPasa[i].EtiquetaCuatro;
                    ObjComun.EtiquetaCinco = LBXPasa[i].EtiquetaCinco;
                    SesionUsu.ListDetConceptoAsig.Add(ObjComun);
                }
                //  Sorting(ref LBXRecibe);
                LBXPasa.Clear();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        #endregion

        protected void lstMaterias_Asignadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDescMatAsig.Text = string.Empty;
            lblDescMatAsig.Text = lstMaterias_Asignadas.SelectedItem.Text;
        }

       
        protected void linkBttnEliminar_Materia_Click(object sender, EventArgs e)
        {
            lblMsj.Visible = false;
            try
            {
                lblMsj.Text = string.Empty;
                ObjDetConcepto.TipoRegistro = SesionUsu.ListDetConceptoAsig[lstMaterias_Asignadas.SelectedIndex].EtiquetaTres;
                if (ObjDetConcepto.TipoRegistro == "M")
                {
                    ObjDetConcepto.IdConcepto = SesionUsu.ConceptoID;
                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(lstMaterias_Asignadas.SelectedValue);
                }
                else if (ObjDetConcepto.TipoRegistro == "C")
                {
                    ObjDetConcepto.IdConcepto = Convert.ToInt32(lstMaterias_Asignadas.SelectedValue);
                    ObjDetConcepto.IdDetConcepto = 0;
                }
                else
                {
                    ObjDetConcepto.IdConcepto = SesionUsu.ConceptoID;
                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(lstMaterias_Asignadas.SelectedValue);
                }
                CNDetConcepto.EliminarDetConcepto(ref Verificador, ref ObjDetConcepto);
                if (Verificador == "0")
                {
                    CargarComboMaterias();
                    txtImporteAdd.Text = "";
                }
                else
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }

        protected void linkBttnAgregar_Click(object sender, EventArgs e)
        {
            lblMsj.Visible = false;
            try
            {

                if (SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaTres == "C")//tipo registro: C=Concepto, M= Materia, I=nada
                {
                    GetConfigurarConcepto(Convert.ToInt32(lstMaterias_Disponibles.SelectedValue));
                    if (SesionUsu.Operacion == "I")
                    {
                        AddFichaReferenciada();
                    }
                    AddConceptoPago();

                }
                else if (SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaTres == "M")
                {
                    GetConfigurarConcepto(Convert.ToInt32(SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaCuatro));
                    if (SesionUsu.Operacion == "I")
                    {
                        AddFichaReferenciada();
                    }
                    AddConceptoPago();


                    ObjDetConcepto.IdConcepto = SesionUsu.ConceptoID;
                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(lstMaterias_Disponibles.SelectedValue);

                    CNDetConcepto.ValidarMateria(ref Verificador, ref ObjDetConcepto);
                    if (Verificador == "0")
                    {
                        ObjDetConcepto.CicloEscolar = ObjConcepto.CicloEscolar;
                        ObjDetConcepto.Semestre = SesionUsu.UsuSemestre;
                        ObjDetConcepto.Grupo = SesionUsu.UsuGrupo;
                        ObjDetConcepto.Evento = SesionUsu.UsuEvento;
                        ObjDetConcepto.ImporteDetalle = Convert.ToDouble(SesionUsu.ListDetConceptoDisp[lstMaterias_Disponibles.SelectedIndex].EtiquetaDos);
                        CNDetConcepto.InsertarDetConcepto(ref Verificador, ref ObjDetConcepto);

                    }
                    else
                    {
                        lblMsj.Visible = true;
                        lblMsj.Text = Verificador;
                    }
                }
                if (Verificador == "0")
                {
                    CargarComboMaterias();
                }
                else
                {
                    lblMsj.Visible = true;
                    lblMsj.Text = "No se pudo agregar los datos: " + Verificador;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Visible = true;
                lblMsj.Text = ex.Message;
            }
        }
    }
}