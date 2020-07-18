using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Usuario
    {
        public void ValidarUsuario(ref Usuario Usuario, ref string Verificador)
        {
            try
            {
                CD_Usuario CD_Usuario = new CD_Usuario();
                CD_Usuario.ValidarUsuario(ref Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}