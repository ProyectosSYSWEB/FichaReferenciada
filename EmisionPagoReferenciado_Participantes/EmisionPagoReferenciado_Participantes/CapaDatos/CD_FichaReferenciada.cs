using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using CapaEntidad;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion

namespace CapaDatos
{
    public class CD_FichaReferenciada
    {

        public void ConsultarFichaReferenciada(ref FichaReferenciada ObjFichaReferenciada, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                
                string[] ParametrosIn = { "p_xml_origen" };
                object[] Valores = { ObjFichaReferenciada.XMLCadena };
                string[] ParametrosOut ={                                        
                                        "p_Referencia",
                                        "p_Nombre",
                                        "p_Importe",
                                        "p_Vigencia",
                                        "p_Concepto",
                                        "p_Bandera"
                                        };

                Cmd = CDDatos.GenerarOracleCommand("OBT_MAPEO_XML", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    ObjFichaReferenciada = new FichaReferenciada();


                    ObjFichaReferenciada.Referencia = Convert.ToString(Cmd.Parameters["p_Referencia"].Value);
                    ObjFichaReferenciada.Nombre = Convert.ToString(Cmd.Parameters["p_Nombre"].Value);
                    ObjFichaReferenciada.Importetotal = Convert.ToDouble(Cmd.Parameters["p_Importe"].Value);
                    ObjFichaReferenciada.FechaVigencia = Convert.ToString(Cmd.Parameters["p_Vigencia"].Value);
                    ObjFichaReferenciada.ConceptoRef = Convert.ToString(Cmd.Parameters["p_Concepto"].Value);


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
        public void InsertarFichaReferenciada(ref FichaReferenciada ObjFichaReferenciada, string Correo, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

               
                string[] ParametrosIn = { "p_ID",
                                          "p_MATRICULA",
                                          "p_SEMESTRE",
                                          "p_GRUPO",
                                          "p_CARRERA",
                                          "p_ESCUELA",
                                          "p_CICLO_ESCOLAR",
                                          "p_REFERENCIA",
                                          "p_OBSERVACIONES",
                                          "p_ALUMNO",
                                          "p_EVENTO",
                                          "P_CORREO"
                };
                object[] Valores = { 
                                        ObjFichaReferenciada.IdFichaBancaria,
                                        ObjFichaReferenciada.NoControl,
                                        ObjFichaReferenciada.Semestre,
                                        ObjFichaReferenciada.Grupo,
                                        ObjFichaReferenciada.Carrera,
                                        ObjFichaReferenciada.Dependencia,
                                        ObjFichaReferenciada.CicloEscolar,
                                        ObjFichaReferenciada.Referencia,
                                        ObjFichaReferenciada.ConceptoRef,
                                        ObjFichaReferenciada.Nombre,
                                        ObjFichaReferenciada.Evento,
                                        Correo
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA",
                                          "p_Dias_Vigencia"
                };

               Cmd = CDDatos.GenerarOracleCommand("INS_INF_FICHA_BANCARIA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
               //Cmd = CDDatos.GenerarOracleCommand("INS_FICHA_BANCARIA", ref Verificador, ParametrosIn, Valores, ParametrosOut);


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
        public void ActualizarFichaReferenciada(ref FichaReferenciada ObjFichaReferenciada, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

               
                string[] ParametrosIn = { "p_ID",
                                          "p_REFERENCIA",
                                          "p_IMPORTE",
                                          "p_OBSERVACIONES",
                                          "P_COMPROBRANTE_FISCAL",
                                          "P_TIPO_PERSONA",
                                          "P_RAZON_SOCIAL",                                          
                                          "P_RFC_FISCAL",
                                          "P_CALLE_FISCAL",
                                          "P_COLONIA_FISCAL",
                                          "P_CP_FISCAL",
                                          "P_ESTADO_FISCAL",
                                          "P_MUNICIPIO_FISCAL",
                                          "P_TELEFONO_FISCAL",
                                          "P_CORREO_FISCAL",
                                          "P_METODO_PAGO_FISCAL",

                                          "P_CFDI", 
                                          //"P_TIPO_SERVICIO_FISCAL", 
                                          "P_OBS_SOLICITUD_FACTURA", 
                                          //"P_FORMA_PAGO_FISCAL",

                                          "p_EVENTO",
                                          "p_MATRICULA",
                                          "p_ALUMNO",
                                          "P_CORREO"
                                        };
                object[] Valores = { 
                                        ObjFichaReferenciada.IdFichaBancaria,
                                        ObjFichaReferenciada.Referencia,
                                        ObjFichaReferenciada.Importetotal,
                                        ObjFichaReferenciada.ConceptoRef,
                                        ObjFichaReferenciada.ComprobanteFiscal,
                                        ObjFichaReferenciada.TipoPersonaFiscal,
                                        ObjFichaReferenciada.RazonSocial,
                                        //ObjFichaReferenciada.Domicilio,
                                        ObjFichaReferenciada.RFC,
                                        ObjFichaReferenciada.CalleFiscal,
                                        ObjFichaReferenciada.ColoniaFiscal,
                                        ObjFichaReferenciada.CPFiscal,
                                        ObjFichaReferenciada.EstadoFiscal,
                                        ObjFichaReferenciada.MunicipioFiscal,
                                        ObjFichaReferenciada.TelefonoFiscal,
                                        ObjFichaReferenciada.CorreoFiscal,       
                                        ObjFichaReferenciada.MetodoPagoFiscal,                                                                                                                 
                                        ObjFichaReferenciada.CFDI,
                                        //ObjFichaReferenciada.TipoServicioFiscal,
                                        ObjFichaReferenciada.ObsSolicitudFactura,
                                        //ObjFichaReferenciada.FormaPagoFiscal,
                                        ObjFichaReferenciada.Evento,
                                        ObjFichaReferenciada.NoControl,
                                        ObjFichaReferenciada.Nombre,
                                        ObjFichaReferenciada.Correo
            };
                string[] ParametrosOut ={                                        
                                          "p_BANDERA"
                };

                Cmd = CDDatos.GenerarOracleCommand("UPD_INF_FICHA_BANCARIA", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                //Cmd = CDDatos.GenerarOracleCommand("UPD_FICHA_BANCARIA_2016", ref Verificador, ParametrosIn, Valores, ParametrosOut);


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
        public void GenerarID(ref FichaReferenciada ObjFichaReferenciada)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                
                string[] ParametrosIn = { };
                object[] Valores = { };
                string[] ParametrosOut ={                                        
                                          "p_Id"
                };

               Cmd = CDDatos.GenerarOracleCommand("GNR_ID_FICHA_BANCARIA", ParametrosIn, Valores, ParametrosOut);

                ObjFichaReferenciada.IdFichaBancaria = Convert.ToInt32(Cmd.Parameters["p_Id"].Value);

               
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
        public void GenerarReferencia(ref FichaReferenciada ObjFichaReferenciada)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                
                string[] ParametrosIn = { "p_matricula", "p_id_ficha" };
                object[] Valores = { ObjFichaReferenciada.NoControl, ObjFichaReferenciada.IdFichaBancaria};
                string[] ParametrosOut ={ "p_matricula_ajustada", "p_id_ficha_ajustada" };

                Cmd = CDDatos.GenerarOracleCommand("gnr_matricula_ajustada", ParametrosIn, Valores, ParametrosOut);
                ObjFichaReferenciada.NoControl = Cmd.Parameters["p_matricula_ajustada"].Value.ToString();
                ObjFichaReferenciada.XMLCadena = Convert.ToString(Cmd.Parameters["p_id_ficha_ajustada"].Value);                
                CDDatos.LimpiarOracleCommand(ref Cmd);



                //-----------OBTIENE LA DEPENDENCIA SEGUN EL NIVEL, EJ: 41101 A 41102 PARA POSGRADO-----------//

                CDDatos = new CD_Datos();
                string[] ParametrosIn2 = { "p_depedencia", "p_nivel" };
                object[] Valores2 = { ObjFichaReferenciada.Dependencia, ObjFichaReferenciada.Nivel };
                string[] ParametrosOut2 = { "p_dependencia_ajustada", "p_bandera" };

                Cmd = CDDatos.GenerarOracleCommand("GNR_DEPENDENCIA_AJUSTADA_2016", ParametrosIn2, Valores2, ParametrosOut2);
                ObjFichaReferenciada.Dependencia = Cmd.Parameters["p_dependencia_ajustada"].Value.ToString();
                
                CDDatos.LimpiarOracleCommand(ref Cmd);

                //-----------OBTIENE LA REFERENCIA-----------//


                CDDatos = new CD_Datos();
                string[] Parametro = {"p_Ref_Inicial","p_DIAS_VIGENCIA","p_Importe"};
                object[] Valor = {ObjFichaReferenciada.Dependencia + ObjFichaReferenciada.NoControl + ObjFichaReferenciada.XMLCadena,
                                  ObjFichaReferenciada.Vigencia,
                                  ObjFichaReferenciada.Importetotal};

                string[] ParametroOut ={"p_Referencia"};
                Cmd = CDDatos.GenerarOracleCommand("GNR_REFERENCIA", Parametro, Valor, ParametroOut);
                ObjFichaReferenciada.Referencia = Cmd.Parameters["p_Referencia"].Value.ToString();
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
