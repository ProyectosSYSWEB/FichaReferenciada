using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_FichaReferenciada_SIAE
    {
        public void ConsultarFichaReferenciada(ref FichaReferenciadaSIAE objReferenciaSIAE, ref string Verificador)
        {
            try
            {
                CD_FichaReferenciada_SIAE CDReferenciadaSIAE = new CD_FichaReferenciada_SIAE();
                CDReferenciadaSIAE.ConsultarFichaReferenciada(ref objReferenciaSIAE, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
