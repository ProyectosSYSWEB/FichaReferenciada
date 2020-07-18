using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;
#region Hecho por
//Nombre:      Melissa Alejandra Rodríguez González
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Alumno
    {
        public void ConsultarAlumno(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = {"p_tipo",
                                        "p_matricula",
                                        "p_evento",
                                        "p_tipo_participante",                                        
                                        "p_nivel"};
                object[] Valores = {"A",                    
                                    ObjAlumno.Matricula,
                                    ObjAlumno.Evento,
                                    ObjAlumno.TipoPersona,
                                    ObjAlumno.Nivel
            };
                string[] ParametrosOut ={
                                        
                                          "p_nombre",
                                          "p_appat",
                                          "p_apmat",
                                          "p_sexo" ,
                                          "p_email",
                                          "p_escuela",
                                          "p_carrera",
                                          "p_semestre",
                                          "p_grupo",
                                          "p_Bandera",
                                          "p_desc_escuela",
                                          "p_desc_carrera",
                                          "p_status",
                                          "p_fecha_nacimiento",
                                          "p_genero"
                };

                //Cmd = CDDatos.GenerarOracleCommand("OBT_INTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_ALUMNO2017", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();

                    ObjAlumno.Dependencia = Convert.ToString(Cmd.Parameters["p_escuela"].Value);
                    ObjAlumno.Carrera = Cmd.Parameters["p_carrera"].Value.ToString();
                    ObjAlumno.Semestre = Convert.ToString(Cmd.Parameters["p_semestre"].Value);
                    ObjAlumno.Grupo = Convert.ToString(Cmd.Parameters["p_grupo"].Value);
                    ObjAlumno.Correo = Convert.ToString(Cmd.Parameters["p_email"].Value);
                    ObjAlumno.Constancia = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.APaterno = Convert.ToString(Cmd.Parameters["p_appat"].Value);
                    ObjAlumno.AMaterno = Convert.ToString(Cmd.Parameters["p_apmat"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_sexo"].Value);
                    ObjAlumno.DescEscuela = Convert.ToString(Cmd.Parameters["p_desc_escuela"].Value);
                    ObjAlumno.DescCarrera = Convert.ToString(Cmd.Parameters["p_desc_carrera"].Value);
                    ObjAlumno.StatusMatricula = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    //ObjAlumno.PeriodoPago = Convert.ToString(Cmd.Parameters["p_id_periodo_pago"].Value);
                    //ObjAlumno.TipoPersona = Convert.ToInt32(Cmd.Parameters["p_TIPO_PERSONA"].Value);


                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void ConsultarAlumnoSel(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "p_matricula",
                                        "p_dependencia",
                                        "p_nivel"};
                object[] Valores = {   ObjAlumno.Matricula,
                                       ObjAlumno.Dependencia,
                                       ObjAlumno.Nivel
            };
                string[] ParametrosOut ={
                                          "p_nombre",
                                          "p_carrera",
                                          "p_semestre",
                                          "p_grupo",
                                          "p_status",
                                          "p_Bandera",
                                          "p_id_carrera",
                                        "p_sexo",
                                        "p_email"
                };

                Cmd = CDDatos.GenerarOracleCommand("SEL_ALUMNO_POSGRADO_2016", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjAlumno = new Alumno();
                    ObjAlumno.Dependencia = Convert.ToString(Cmd.Parameters["p_dependencia"].Value);
                    ObjAlumno.Carrera = Convert.ToString(Cmd.Parameters["p_id_carrera"].Value);
                    ObjAlumno.DescCarrera = Convert.ToString(Cmd.Parameters["p_carrera"].Value);
                    ObjAlumno.Semestre = Convert.ToString(Cmd.Parameters["p_semestre"].Value);
                    ObjAlumno.Grupo = Convert.ToString(Cmd.Parameters["p_grupo"].Value);
                    ObjAlumno.Nombre = Convert.ToString(Cmd.Parameters["p_nombre"].Value);
                    ObjAlumno.APaterno = Convert.ToString(Cmd.Parameters["p_paterno"].Value);
                    ObjAlumno.AMaterno = Convert.ToString(Cmd.Parameters["p_materno"].Value);
                    ObjAlumno.StatusMatricula = Convert.ToString(Cmd.Parameters["p_status"].Value);
                    ObjAlumno.Correo = Convert.ToString(Cmd.Parameters["p_email"].Value);
                    ObjAlumno.Genero = Convert.ToChar(Cmd.Parameters["p_sexo"].Value);

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }        
        public void AlumnoEditar(ref Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_matricula", "p_dependencia", "p_nivel",
                                        "p_nombre", "p_paterno", "p_materno", "p_carrera",
                                        "p_id_carrera", "p_semestre", "p_grupo","p_status", "p_usuario","p_sexo",
                                        "p_email" };
                object[] Valores = { ObjAlumno.Matricula, ObjAlumno.Dependencia, ObjAlumno.Nivel,
                                     ObjAlumno.Nombre, ObjAlumno.APaterno, ObjAlumno.AMaterno, ObjAlumno.DescCarrera,
                                     ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo, ObjAlumno.StatusMatricula, ObjAlumno.UsuNombre, ObjAlumno.Genero, ObjAlumno.Correo };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_ALUMNO_POSGRADO_2016", ref Verificador, Parametros, Valores, ParametrosOut);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
        public void AlumnoInsertar(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_matricula", "p_dependencia", "p_nivel",
                                        "p_nombre", "p_paterno", "p_materno", "p_carrera",
                                        "p_id_carrera", "p_semestre", "p_grupo", "p_usuario","p_sexo",
                                        "p_email", "p_status" };
                object[] Valores = { ObjAlumno.Matricula, ObjAlumno.Dependencia, ObjAlumno.Nivel,
                                     ObjAlumno.Nombre, ObjAlumno.APaterno, ObjAlumno.AMaterno, ObjAlumno.DescCarrera,
                                     ObjAlumno.Carrera, ObjAlumno.Semestre, ObjAlumno.Grupo, ObjAlumno.UsuNombre, ObjAlumno.Genero, ObjAlumno.Correo, ObjAlumno.StatusMatricula };
                String[] ParametrosOut = { "p_Bandera", "p_matricula_generada" };
                Cmd = CDDatos.GenerarOracleCommand("INS_ALUMNO_POSGRADO_2016", ref Verificador, Parametros, Valores, ParametrosOut);
                
                ObjAlumno.Matricula = Convert.ToString(Cmd.Parameters["p_matricula_generada"].Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

        public void AlumnoInsertarPonente(Alumno ObjAlumno, Participante ObjParticipante, string Evento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_EVENTO", "P_MATRICULA", "P_PONENCIA_TITULO_1",
                                        "P_PONENCIA_TITULO_2", "P_NOMBRE_CONSTANCIA", "P_TIPO_PERSONA" };
                object[] Valores = { Evento, ObjAlumno.Matricula, ObjParticipante.Ponencia1,
                                     ObjParticipante.Ponencia2, ObjParticipante.Constancia, ObjParticipante.TipoPersona };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("INS_DATOS_PONENCIA", ref Verificador, Parametros, Valores, ParametrosOut);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }


        public void AlumnoEditarPonente(Alumno ObjAlumno, Participante ObjParticipante, string Evento, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "P_EVENTO", "P_MATRICULA", "P_PONENCIA_TITULO_1",
                                        "P_PONENCIA_TITULO_2", "P_NOMBRE_CONSTANCIA", "P_TIPO_PERSONA" };
                object[] Valores = { Evento, ObjAlumno.Matricula, ObjParticipante.Ponencia1,
                                     ObjParticipante.Ponencia2, ObjParticipante.Constancia, ObjParticipante.TipoPersona };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_DATOS_PONENCIA", ref Verificador, Parametros, Valores, ParametrosOut);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

        public void AlumnoClienteActivar(Alumno ObjAlumno, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                String[] Parametros = { "p_matricula", "P_NIVEL" };
                object[] Valores = { ObjAlumno.Matricula, ObjAlumno.Nivel };
                String[] ParametrosOut = { "p_Bandera" };
                Cmd = CDDatos.GenerarOracleCommand("UPD_STATUS_ALUMNO_CLIENTE", ref Verificador, Parametros, Valores, ParametrosOut);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

    }

}