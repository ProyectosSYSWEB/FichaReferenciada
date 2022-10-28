using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_PayPal
    {
        public void ObtenerDatosReferencia(ref InfPayPal objPayPal, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                string[] ParametrosIn = { "P_ID_TRANSACCION", "P_REFERENCIA" };
                object[] Valores = { objPayPal.idTransaccion, objPayPal.Referencia };
                string[] ParametrosOut ={ "P_NOMBRE", "P_DEPENDENCIA", "P_IMPORTE", "P_FECHA_PAGO", "P_ID_FACTURA", "P_BANDERA" };

                Cmd = CDDatos.GenerarOracleCommand("OBT_DATOS_REF_PAYPAL", ref Verificador, ParametrosIn, Valores, ParametrosOut);
                objPayPal.Cliente = Convert.ToString(Cmd.Parameters["P_NOMBRE"].Value);
                objPayPal.Dependencia = Convert.ToString(Cmd.Parameters["P_DEPENDENCIA"].Value);
                objPayPal.Total = Convert.ToDecimal(Cmd.Parameters["P_IMPORTE"].Value);
                objPayPal.Fecha_Pago = Convert.ToString(Cmd.Parameters["P_FECHA_PAGO"].Value);
                objPayPal.IdRecibo = Convert.ToInt32(Cmd.Parameters["P_ID_FACTURA"].Value);
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
