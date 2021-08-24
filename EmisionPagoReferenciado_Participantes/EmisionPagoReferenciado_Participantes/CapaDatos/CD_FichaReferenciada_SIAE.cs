using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_FichaReferenciada_SIAE
    {
        public void ConsultarFichaReferenciada(ref FichaReferenciadaSIAE objReferenciaSIAE, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {

                int id = objReferenciaSIAE.IdReferencia;
                string[] ParametrosIn = { "p_id_referencia" };
                object[] Valores = { objReferenciaSIAE.IdReferencia };
                string[] ParametrosOut ={
                                        "p_Referencia",
                                        "p_Nombre",
                                        "p_Importe",
                                        "p_Vigencia",
                                        "p_Concepto",
                                        "P_DIAS_VIGENCIA",
                                        "p_Bandera"
                                        };

                Cmd = CDDatos.GenerarOracleCommand("OBT_REFERENCIA_SIAE", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    objReferenciaSIAE = new FichaReferenciadaSIAE();
                    objReferenciaSIAE.Nombre = Convert.ToString(Cmd.Parameters["p_Nombre"].Value);
                    objReferenciaSIAE.Importe = Convert.ToDouble(Cmd.Parameters["p_Importe"].Value);
                    objReferenciaSIAE.Vigencia = Convert.ToString(Cmd.Parameters["P_VIGENCIA"].Value);
                    objReferenciaSIAE.Concepto = Convert.ToString(Cmd.Parameters["P_CONCEPTO"].Value);
                    objReferenciaSIAE.Referencia = Convert.ToString(Cmd.Parameters["P_REFERENCIA"].Value);
                    objReferenciaSIAE.Dias_Vigencia = Convert.ToInt32(Cmd.Parameters["P_DIAS_VIGENCIA"].Value);
                    objReferenciaSIAE.IdReferencia = id;
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

    }
}
