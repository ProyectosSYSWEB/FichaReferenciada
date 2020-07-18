using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class CD_Componente
    {
        public void InsertarValores(int IdFichaBancaria, List<Componente> lstValoresComponentes, string Evento, ref string Verificador)
        {

            foreach (Componente lst in lstValoresComponentes)
            {

                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_ID_FICHA_BANC", "P_ID_CONTROL", "P_EVENTO", "P_VALOR" };
                    object[] Valores = { IdFichaBancaria, lst.IdControl, Evento, lst.Valor };
                    String[] ParametrosOut = { "p_Bandera" };

                    Cmd = CDDatos.GenerarOracleCommand("INS_FICHA_BANCARIA_EXTRAS", ref Verificador, Parametros, Valores, ParametrosOut);

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
        public void EliminarValores(int IdFichaBancaria, ref string Verificador)
        {

          
                CD_Datos CDDatos = new CD_Datos();
                OracleCommand Cmd = null;
                try
                {
                    String[] Parametros = { "P_ID_FICHA" };
                    object[] Valores = { IdFichaBancaria };
                    String[] ParametrosOut = { "P_BANDERA" };

                    Cmd = CDDatos.GenerarOracleCommand("DEL_FICHA_BANCARIA_EXTRAS", ref Verificador, Parametros, Valores, ParametrosOut);

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
