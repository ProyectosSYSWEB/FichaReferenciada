using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      lis_go82@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_Participante
    {
        public void ConsultarParticipante(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

              
                string[] ParametrosIn = { "p_PATERNO",
                                          "p_MATERNO",
                                          "p_NOMBRES",
                                          "p_EVENTO"};
                object[] Valores = { ObjParticipante.APaterno,
                                     ObjParticipante.AMaterno,
                                     ObjParticipante.Nombre,
                                     ObjParticipante.Evento   
            };
                string[] ParametrosOut ={
                                        
                                          "p_GENERO",
                                          "p_GRADO" ,
                                          "p_TEL_PARTICULAR",
                                          "p_TEL_CELULAR",
                                          "p_EMAIL",
                                          "p_PROCEDENCIA_INSTITUCION",
                                          "p_PROCEDENCIA_CARGO",
                                          "p_PROCEDENCIA_DOMICILIO",
                                          "p_PROCEDENCIA_CIUDAD",
                                          "p_PROCEDENCIA_TELEFONO",
                                          "p_PONENCIA_TITULO_1",
                                          "p_PONENCIA_TITULO_2",
                                          "p_NOMBRE_CONSTANCIA",
                                          "p_TIPO_PERSONA",
                                          "p_ESTADO",
                                          "p_MATRICULA",
                                          "p_BANDERA",
                                          "p_OPERACION",
                                          "p_DONATIVO",
                                          "p_id_periodo_pago",
                                          "p_COLONIA",
                                          "p_CODIGO_POSTAL"
                };

                 Cmd = CDDatos.GenerarOracleCommand("OBT_EXTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjParticipante = new Participante();

                    ObjParticipante.Operacion = Convert.ToString(Cmd.Parameters["p_OPERACION"].Value);
                    if (ObjParticipante.Operacion == "U")
                    {
                        ObjParticipante.Genero = Convert.ToChar(Cmd.Parameters["p_GENERO"].Value);
                        ObjParticipante.GradoEstudio = Convert.ToString(Cmd.Parameters["p_GRADO"].Value);
                        ObjParticipante.TelParticular = Convert.ToString(Cmd.Parameters["p_TEL_PARTICULAR"].Value);
                        ObjParticipante.Celular = Convert.ToString(Cmd.Parameters["p_TEL_CELULAR"].Value);
                        ObjParticipante.Correo = Convert.ToString(Cmd.Parameters["p_EMAIL"].Value);
                        ObjParticipante.Dependencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_INSTITUCION"].Value);
                        ObjParticipante.CargoProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_CARGO"].Value);
                        ObjParticipante.DomicilioProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_DOMICILIO"].Value);
                        ObjParticipante.CiudadProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_CIUDAD"].Value);
                        ObjParticipante.TelProcedencia = Convert.ToString(Cmd.Parameters["p_PROCEDENCIA_TELEFONO"].Value);
                        ObjParticipante.Ponencia1 = Convert.ToString(Cmd.Parameters["p_PONENCIA_TITULO_1"].Value);
                        ObjParticipante.Ponencia2 = Convert.ToString(Cmd.Parameters["p_PONENCIA_TITULO_2"].Value);
                        ObjParticipante.Constancia = Convert.ToString(Cmd.Parameters["p_NOMBRE_CONSTANCIA"].Value);
                        ObjParticipante.TipoPersona = Convert.ToInt32(Cmd.Parameters["p_TIPO_PERSONA"].Value);
                        ObjParticipante.EstadoProcedencia = Convert.ToString(Cmd.Parameters["p_ESTADO"].Value);
                        ObjParticipante.CP = Convert.ToString(Cmd.Parameters["p_CODIGO_POSTAL"].Value);
                        ObjParticipante.Colonia = Convert.ToString(Cmd.Parameters["p_COLONIA"].Value);
                        ObjParticipante.Donativo = Convert.ToString(Cmd.Parameters["p_DONATIVO"].Value);
                        ObjParticipante.PeriodoPago = Convert.ToInt32(Cmd.Parameters["p_id_periodo_pago"].Value);
                    }

                }
                ObjParticipante.NoControl = Convert.ToString(Cmd.Parameters["p_MATRICULA"].Value);
               
              

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
        public void ConsultarEvento(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

              
                string[] ParametrosIn = { 
                                          "p_evento"};
                object[] Valores = { 
                                     ObjParticipante.Evento   
            };
                string[] ParametrosOut ={
                                          "p_BANDERA",
                                          "p_Escuela",
                                          "p_Descripcion",
                                          "p_observaciones",
                                          "p_componentes_extras",
                                          "p_exclusivo"
                };
                //Cmd = CDDatos.GenerarOracleCommand("OBT_EVENTO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                //Cmd = CDDatos.GenerarOracleCommand("VAL_EVENTO_ESCUELA2", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                Cmd = CDDatos.GenerarOracleCommand("OBT_EVENTO_VIGENTE", ref Verificador, ParametrosIn, Valores, ParametrosOut);

                ObjParticipante.StatusEvento = Convert.ToChar(Verificador);
                ObjParticipante.Dependencia = Convert.ToString(Cmd.Parameters["p_Escuela"].Value);
                ObjParticipante.EventoStr = Convert.ToString(Cmd.Parameters["p_Descripcion"].Value);
                ObjParticipante.EventoEspecificacion = Convert.ToString(Cmd.Parameters["p_observaciones"].Value);
                ObjParticipante.ComponentesExtras = Convert.ToString(Cmd.Parameters["p_componentes_extras"].Value);
                ObjParticipante.Evento_Exclusivo = Convert.ToString(Cmd.Parameters["p_exclusivo"].Value);

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
        public void InsertarParticipante(ref Participante ObjParticipante, ref string Verificador)
         {
             CD_Datos CDDatos = new CD_Datos();
             OracleCommand Cmd = null;
            try
            {

             
                string[] ParametrosIn = { "p_PATERNO",
                                          "p_MATERNO",
                                          "p_NOMBRES",
                                          "p_TEL_PARTICULAR",
                                          "p_TEL_CELULAR",
                                          "p_EMAIL",
                                          "p_PROCEDENCIA_INSTITUCION",
                                          "p_PROCEDENCIA_CARGO",
                                          "p_PROCEDENCIA_DOMICILIO",
                                          "p_PROCEDENCIA_CIUDAD",
                                          "p_PROCEDENCIA_TELEFONO",
                                          "p_TIPO_PERSONA",
                                           "p_PONENCIA_TITULO_1",
                                          "p_PONENCIA_TITULO_2",
                                          "p_NOMBRE_CONSTANCIA",
                                          "p_GENERO",
                                          "p_EVENTO",
                                          "p_GRADO",
                                          "p_ESTADO",
                                          "p_DONATIVO",
                                          "p_id_periodo_pago",
                                          "p_MATRICULA",
                                         "p_COLONIA",
                                          "p_CODIGO_POSTAL"};
                    object[] Valores = { ObjParticipante.APaterno,
                                         ObjParticipante.AMaterno,
                                         ObjParticipante.Nombre,
                                         ObjParticipante.TelParticular,
                                        ObjParticipante.Celular,
                                        ObjParticipante.Correo,
                                        ObjParticipante.Dependencia,
                                        ObjParticipante.CargoProcedencia,
                                        ObjParticipante.DomicilioProcedencia,
                                        ObjParticipante.CiudadProcedencia,
                                        ObjParticipante.TelProcedencia,
                                        ObjParticipante.TipoPersona,
                                        ObjParticipante.Ponencia1,
                                        ObjParticipante.Ponencia2,
                                        ObjParticipante.Constancia,
                                        ObjParticipante.Genero.ToString(),
                                        ObjParticipante.Evento,
                                        ObjParticipante.GradoEstudio,
                                        ObjParticipante.EstadoProcedencia,
                                        ObjParticipante.Donativo,
                                        ObjParticipante.PeriodoPago,
                                        ObjParticipante.NoControl,
                                        ObjParticipante.Colonia,
                                        ObjParticipante.CP
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("INS_EXTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);
          
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
        public void ActualizarParticipante(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

              
                string[] ParametrosIn = { "p_PATERNO",
                                          "p_MATERNO",
                                          "p_NOMBRES",
                                          "p_TEL_PARTICULAR",
                                          "p_TEL_CELULAR",
                                          "p_EMAIL",
                                          "p_PROCEDENCIA_INSTITUCION",
                                          "p_PROCEDENCIA_CARGO",
                                          "p_PROCEDENCIA_DOMICILIO",
                                          "p_PROCEDENCIA_CIUDAD",
                                          "p_PROCEDENCIA_TELEFONO",
                                          "p_TIPO_PERSONA",
                                           "p_PONENCIA_TITULO_1",
                                          "p_PONENCIA_TITULO_2",
                                          "p_NOMBRE_CONSTANCIA",
                                          "p_GENERO",
                                          "p_EVENTO",
                                          "p_GRADO",
                                          "p_ESTADO",
                                          "p_DONATIVO",
                                          "p_id_periodo_pago",
                                          "p_MATRICULA",
                                          "p_COLONIA",
                                          "p_CODIGO_POSTAL"};
                object[] Valores = { ObjParticipante.APaterno,
                                         ObjParticipante.AMaterno,
                                         ObjParticipante.Nombre,
                                         ObjParticipante.TelParticular,
                                        ObjParticipante.Celular,
                                        ObjParticipante.Correo,
                                        ObjParticipante.Dependencia,
                                        ObjParticipante.CargoProcedencia,
                                        ObjParticipante.DomicilioProcedencia,
                                        ObjParticipante.CiudadProcedencia,
                                        ObjParticipante.TelProcedencia,
                                        ObjParticipante.TipoPersona,
                                        ObjParticipante.Ponencia1,
                                        ObjParticipante.Ponencia2,
                                        ObjParticipante.Constancia,
                                        ObjParticipante.Genero.ToString(),
                                        ObjParticipante.Evento,
                                        ObjParticipante.GradoEstudio,
                                        ObjParticipante.EstadoProcedencia,
                                        ObjParticipante.Donativo,
                                        ObjParticipante.PeriodoPago,
                                        ObjParticipante.NoControl,
                                        ObjParticipante.Colonia,
                                        ObjParticipante.CP
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("UPD_EXTERNOS", ref Verificador, ParametrosIn, Valores, ParametrosOut);

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
        public void ConsultarParticipanteEmpleado(ref Participante ObjParticipante, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_PLAZA",
                                          "P_TIPO_PERSONAL"};
                object[] Valores = { ObjParticipante.NumPlaza,
                                     ObjParticipante.TipoPersonal};
                string[] ParametrosOut ={

                                          "p_PATERNO",
                                          "p_MATERNO" ,
                                          "p_NOMBRES",
                                          "P_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("OBT_EXTERNO_EMPLEADO", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjParticipante = new Participante();
                    ObjParticipante.APaterno = Convert.ToString(Cmd.Parameters["p_PATERNO"].Value);
                    ObjParticipante.AMaterno = Convert.ToString(Cmd.Parameters["p_MATERNO"].Value);
                    ObjParticipante.Nombre = Convert.ToString(Cmd.Parameters["p_NOMBRES"].Value);
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
        public void ConsultarEvento_Extras(Componente objComponentes, ref List<Componente> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
                String[] Parametros = { "p_evento" };
                Object[] Valores = { objComponentes.Evento };

                cmm = CDDatos.GenerarOracleCommandCursor("PKG_PAGOS_2016.Obt_Lista_Componentes", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    objComponentes = new Componente();
                    objComponentes.IdComponente = Convert.ToInt32(dr[0]);
                    objComponentes.Control = Convert.ToString(dr[1]);
                    objComponentes.IdControl = Convert.ToString(dr[2]);
                    objComponentes.Text = Convert.ToString(dr[3]);
                    objComponentes.Style_Key = Convert.ToString(dr[4]);
                    objComponentes.Style_Value = Convert.ToString(dr[5]);
                    objComponentes.IdControlValida = Convert.ToString(dr[6]);
                    objComponentes.MsgControlValida = Convert.ToString(dr[7]);
                    List.Add(objComponentes);
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }

    }
}
