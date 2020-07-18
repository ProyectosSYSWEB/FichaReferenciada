using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Terminal
    {
        public void ObtDatosTerminal(ref Terminal Terminal, ref string Verificador)
        {
            try
            {
                CD_Terminal CD_Terminal = new CD_Terminal();
                CD_Terminal.Obt_Datos_Terminal(ref Terminal, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
