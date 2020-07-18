using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public void ValidarUsuario(ref Usuario Usuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { "p_usuario", "p_password" };
                string[] Valores = { Usuario.Login, Usuario.Password };

             
              Cmm = CDDatos.GenerarOracleCommandCursor("PKG_CONTRATOS.Verifica_Usuario", ref dr, Parametros, Valores);

                while (dr.Read())
                {
                    Usuario = new Usuario();
                    Usuario.Login = Convert.ToString(dr.GetValue(0));
                    Usuario.Nombre = Convert.ToString(dr.GetValue(1));
                    Usuario.TipoUsu = Convert.ToString(dr.GetValue(3));
                    Usuario.Dependencia = Convert.ToString(dr.GetValue(4));
                }

                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }

        }
    }
}

