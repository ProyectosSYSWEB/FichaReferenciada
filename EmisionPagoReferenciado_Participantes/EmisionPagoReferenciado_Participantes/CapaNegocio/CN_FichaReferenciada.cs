using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_FichaReferenciada
    {
        public void ConsultarFichaReferenciada(ref FichaReferenciada FichaReferenciada, ref string Verificador)
        {
            try
            {
                CD_FichaReferenciada CDFichaReferenciada = new CD_FichaReferenciada();
                CDFichaReferenciada.ConsultarFichaReferenciada(ref FichaReferenciada, ref Verificador);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarFichaReferenciada(ref FichaReferenciada FichaReferenciada, ref string Verificador)
        {
            try
            {
                CD_FichaReferenciada CDFichaReferenciada = new CD_FichaReferenciada();
                CDFichaReferenciada.InsertarFichaReferenciada(ref FichaReferenciada, ref Verificador);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizarFichaReferenciada(ref FichaReferenciada FichaReferenciada, ref string Verificador)
        {
            try
            {
                CD_FichaReferenciada CDFichaReferenciada = new CD_FichaReferenciada();
                CDFichaReferenciada.ActualizarFichaReferenciada(ref FichaReferenciada, ref Verificador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GenerarID(ref FichaReferenciada FichaReferenciada)
        {
            try
            {
                CD_FichaReferenciada CDFichaReferenciada = new CD_FichaReferenciada();
                CDFichaReferenciada.GenerarID(ref FichaReferenciada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GenerarReferencia(ref FichaReferenciada FichaReferenciada)
        {
            try
            {
                CD_FichaReferenciada CDFichaReferenciada = new CD_FichaReferenciada();
                CDFichaReferenciada.GenerarReferencia(ref FichaReferenciada);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
