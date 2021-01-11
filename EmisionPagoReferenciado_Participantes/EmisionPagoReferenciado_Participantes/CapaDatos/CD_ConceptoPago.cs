  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.IO;
using CapaEntidad;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_ConceptoPago
    {
        public void ConsultarConceptoPago(ref ConceptoPago ObjConceptoPago, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
              
                string[] ParametrosIn ={
                                           "p_id_ficha_bancaria"
                                        };
                Object[] Valores ={
                                    ObjConceptoPago.IdFichaBancaria
                    
                };
               cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Conceptos_Selecionado", ref dr, ParametrosIn, Valores);//text

                while (dr.Read())
                {
                    ObjConceptoPago = new ConceptoPago();

                    ObjConceptoPago.Id = Convert.ToInt32(dr["id"]);
                    ObjConceptoPago.IdConcepto = Convert.ToInt32(dr["id_concepto"]);
                    ObjConceptoPago.Descripcion = Convert.ToString(dr["concepto"]);
                    ObjConceptoPago.ClaveConcepto = Convert.ToString(dr["clave"]);
                    ObjConceptoPago.ImporteConcepto = Convert.ToDouble(dr["importe"]);
                    ObjConceptoPago.Observaciones = Convert.ToString(dr["label_materias"]);
                    ObjConceptoPago.Anexo = Convert.ToString(dr["anexo"]);
                   
                    List.Add(ObjConceptoPago);

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
        public void ConfigurarConceptoPago(ref ConceptoPago ObjConceptoPago, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader dr = null;
                
                string[] ParametrosIn = { 
                                          "p_id_concepto", 
                                          "p_id_escuela", 
                                          "p_id_carrera", 
                                          "p_imp_patrocinador",
                                          "p_evento",
                                          "p_matricula"
                                        };
                object[] Valores = { 
                                     ObjConceptoPago.IdConcepto,
                                     ObjConceptoPago.Dependencia,
                                     ObjConceptoPago.TipoPersonaStr,
                                     ObjConceptoPago.Donativo,
                                     ObjConceptoPago.Evento,
                                     ObjConceptoPago.NoControl
                                    };


               Cmd = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Importe_Concepto", ref dr, ParametrosIn, Valores);
                Verificador = "1";
                while (dr.Read())
                {
                    ObjConceptoPago.IdConcepto = Convert.ToInt32(dr["id"]);
                    ObjConceptoPago.Descripcion = Convert.ToString(dr["concepto"]);
                    ObjConceptoPago.ClaveConcepto = Convert.ToString(dr["clave"]);
                    ObjConceptoPago.ImporteConcepto = Convert.ToDouble(dr["importe"]);
                    ObjConceptoPago.CobroXMateria = Convert.ToChar(dr["cobro_x_materia"]);
                    ObjConceptoPago.MaxMateria = Convert.ToString(dr["maximo_materias"]);
                    ObjConceptoPago.DiasVigencia = Convert.ToInt32(dr["dias_vigencia"]);
                    ObjConceptoPago.CicloEscolar = Convert.ToInt32(dr["ciclo_escolar_actual"]);
                    ObjConceptoPago.Anexo = Convert.ToString(dr["observaciones"]);
                    ObjConceptoPago.FechaVigencia = Convert.ToString(dr["Fecha_Vigencia"]);
                    Verificador = "0";  
                }

                dr.Close();

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
        public void InsertarConceptoPago(ref string Verificador, ref List<ConceptoPago> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
              

                string[] Parametros = { "p_ID", 
                                        "p_ID_FICHA_BANCARIA",
                                        "p_ID_CONCEPTO",
                                        "p_IMPORTE",
                                        "p_ANEXO" 
                                      };
                string[] ParametrosOut = { "p_BANDERA" };


                foreach (ConceptoPago ListRecorre in List)
                {
                    object[] Valores = {ListRecorre.Id,
                                        ListRecorre.IdFichaBancaria.ToString(),
                                        ListRecorre.IdConcepto,
                                        ListRecorre.ImporteConcepto,
                                        ListRecorre.Anexo 
                                       };
                    OracleCmd = CDDatos.GenerarOracleCommand("INS_FICHA_DETALLE_CONCEPTOS", ref Verificador, Parametros, Valores, ParametrosOut);
                   
                }
               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref OracleCmd);
            }

        }
        public void ValidarConcepto(ref ConceptoPago ObjConceptoPago, ref string Verificador, ref string Mensaje)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                

                string[] ParametrosIn = {
                                            "p_id_ficha_bancaria",
                                            "p_id_concepto"
                                        };
                object[] Valores = {
                                   ObjConceptoPago.IdFichaBancaria,
                                   ObjConceptoPago.IdConcepto
                                   };
                string[] ParametrosOut ={                                        
                                          "p_Resultado",
                                          "p_id_registro",
                                          "p_mensaje"
                };

                 Cmd = CDDatos.GenerarOracleCommand("VAL_CONFLICTOS_ARBOL", ParametrosIn, Valores, ParametrosOut);

                Verificador = Convert.ToString(Cmd.Parameters["p_Resultado"].Value);
                ObjConceptoPago.Id = Convert.ToInt32(Cmd.Parameters["p_id_registro"].Value);
                Mensaje = Convert.ToString(Cmd.Parameters["p_mensaje"].Value);

               
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
        public void EliminarConceptoPago(ref string Verificador, ref ConceptoPago ObjConcepto)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
              

                string[] Parametros = {
                                        "p_id_ficha_detalle_concepto"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {
                                       ObjConcepto.Id
                                   };


                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_DETALLE_CONCEPTO_CAS", ref Verificador, Parametros, Valores, ParametrosOut);



            }
            catch (Exception ex)
            {
              
               
                throw new Exception(ex.Message);
            }
            finally {
                CDDatos.LimpiarOracleCommand(ref OracleCmd);
            }

        }
        public void ActualizaConceptoPago(ref string Verificador, ref ConceptoPago ObjConceptoPago)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
              

                string[] Parametros = { "p_id_ficha_detalle_concepto", 
                                        "p_label_materias",
                                        "p_importe"
                                      };
                string[] ParametrosOut = { "p_Bandera" };

                object[] Valores = {
                                       ObjConceptoPago.IdConcepto,
                                       ObjConceptoPago.Observaciones,
                                       ObjConceptoPago.ImporteConcepto
                                   };
                OracleCmd = CDDatos.GenerarOracleCommand("UPD_FICHA_DETALLE_CONCEPTO", ref Verificador, Parametros, Valores, ParametrosOut);
                       

            }
            catch (Exception ex)
            {
               
                
                throw new Exception(ex.Message);
            }
            finally {
                CDDatos.LimpiarOracleCommand(ref OracleCmd);
            }

        }
    }
}
