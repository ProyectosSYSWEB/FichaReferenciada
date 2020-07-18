using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Multipago
    {
        public void InsertarMultipago_Transaccion(ref MultiPago MultiPago, ref string Verificador)
        {
            try
            {
                CD_Multipago CDMultiPago = new CD_Multipago();
                CDMultiPago.InsertarMultipago_Transaccion(ref MultiPago, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
