using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Terminal
    {
        public void Obt_Datos_Terminal(ref Terminal Terminal, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {


                string[] ParametrosIn = { "P_USUARIO" };
                object[] Valores = { Terminal.Usuario.Login };
                string[] ParametrosOut ={ "P_NOMBRE_CONV", "P_NUMERO_CONV", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("SEL_DATOS_TERMINAL", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                if (Verificador == "0")
                {
                    Terminal = new Terminal();
                    Terminal.Nombre_Convenio = Convert.ToString(Cmd.Parameters["P_NOMBRE_CONV"].Value);
                    Terminal.Numero_Convenio = Convert.ToString(Cmd.Parameters["P_NUMERO_CONV"].Value);
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
