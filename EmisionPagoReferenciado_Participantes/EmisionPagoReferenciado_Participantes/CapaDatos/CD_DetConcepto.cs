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
    public class CD_DetConcepto
    {
        public void ConsultarDetConcepto(ref DetConcepto ObjDetConcepto, ref List<DetConcepto> List)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {

                OracleDataReader dr = null;
              
                string[] ParametrosIn ={
                                           "p_evento",
                                           "p_concepto",
                                           "p_carrera"
                                           
                                        };
                Object[] Valores ={
                                      ObjDetConcepto.Evento,
                                      ObjDetConcepto.IdConcepto,
                                      Convert.ToInt32(ObjDetConcepto.TipoPersonaStr)
                                    
                    
                };
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Grid_Materias", ref dr, ParametrosIn, Valores);//text

                while (dr.Read())
                {
                    ObjDetConcepto = new DetConcepto();

                    ObjDetConcepto.IdDetConcepto = Convert.ToInt32(dr["id_materia"]);
                    ObjDetConcepto.DescripcionDetalle = Convert.ToString(dr["descripcion"]);
                    ObjDetConcepto.ImporteDetalle = Convert.ToDouble(dr["costo"]);
                   

                    List.Add(ObjDetConcepto);

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
        public void ValidarMateria(ref DetConcepto ObjDetConcepto, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

             


                string[] ParametrosIn = {
                                            "p_id_ficha_detalle_concepto",
                                            "p_id_materia" 
                                        };
                object[] Valores = {
                                   ObjDetConcepto.IdConcepto,
                                   ObjDetConcepto.IdDetConcepto
                                   };
                string[] ParametrosOut ={                                        
                                          "p_Resultado"
                };

                 Cmd = CDDatos.GenerarOracleCommand("val_materias", ParametrosIn, Valores, ParametrosOut);

                Verificador = Convert.ToString(Cmd.Parameters["p_Resultado"].Value);

                
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
        public void InsertarDetConcepto(ref string Verificador, ref DetConcepto ObjDetConcepto)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
           

                string[] Parametros = { "p_ID_MATERIA", 
                                        "p_CICLO_ESCOLAR",
                                        "p_SEMESTRE",
                                        "p_GRUPO",
                                        "p_ID_FICHA_DET_CONCEPTO",
                                        "P_Importe",
                                        "p_Evento"
                                      };
                string[] ParametrosOut = { "p_BANDERA" };

                object[] Valores = {
                                       ObjDetConcepto.IdDetConcepto,
                                       ObjDetConcepto.CicloEscolar,
                                       ObjDetConcepto.Semestre,
                                       ObjDetConcepto.Grupo,
                                       ObjDetConcepto.IdConcepto,
                                       ObjDetConcepto.ImporteDetalle,
                                       ObjDetConcepto.Evento
                                       };
                    OracleCmd = CDDatos.GenerarOracleCommand("INS_FICHA_DETALLE_MATERIAS", ref Verificador, Parametros, Valores, ParametrosOut);
                   
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
        public void EliminarDetConcepto(ref string Verificador, ref DetConcepto ObjDetConcepto)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand OracleCmd = null;
            try
            {
               

                string[] Parametros = {
                                        "p_id_ficha_detalle_concepto",
                                        "p_id_materia",
                                         "p_tipo_registro"
                                      };
                string[] ParametrosOut = { "p_BANDERA"
                                         };

                object[] Valores = {
                                       ObjDetConcepto.IdConcepto,
                                       ObjDetConcepto.IdDetConcepto,
                                       ObjDetConcepto.TipoRegistro
                                   };


                OracleCmd = CDDatos.GenerarOracleCommand("DEL_FICHA_DETALLE_MATERIA_ARBL", ref Verificador, Parametros, Valores, ParametrosOut);


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
       
    }
}
