using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocio
{
    public class CN_Componente
    {
        public void InsertarValores(int IdFichaBancaria, List<Componente> lstValoresComponentes, string Evento, ref string Verificador)
        {
            try
            {
                CD_Componente CDComponente = new CD_Componente();
                CDComponente.EliminarValores(IdFichaBancaria, ref Verificador);
                if (Verificador == "0")
                {
                    Verificador = string.Empty;
                    CDComponente.InsertarValores(IdFichaBancaria, lstValoresComponentes, Evento, ref Verificador);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
