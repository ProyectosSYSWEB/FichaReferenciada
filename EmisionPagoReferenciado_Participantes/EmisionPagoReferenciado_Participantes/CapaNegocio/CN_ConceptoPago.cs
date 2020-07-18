using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_ConceptoPago
    {
        public void ConsultarConceptoPago(ref ConceptoPago ObjConceptoPago, ref List<ConceptoPago> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConsultarConceptoPago(ref ObjConceptoPago, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarConceptoPago(ref string Verificador, ref List<ConceptoPago> List)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.InsertarConceptoPago(ref Verificador, ref List);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ActualizaConceptoPago(ref string Verificador, ref ConceptoPago ObjConcepto)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ActualizaConceptoPago(ref Verificador, ref ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void EliminarConceptoPago(ref string Verificador, ref ConceptoPago ObjConcepto)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.EliminarConceptoPago(ref Verificador, ref ObjConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ConfigurarConceptoPago(ref ConceptoPago ConceptoPago, ref string Verificador)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ConfigurarConceptoPago(ref ConceptoPago, ref Verificador);
             }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ValidarConcepto(ref ConceptoPago ConceptoPago, ref string Verificador, ref string Mensaje)
        {
            try
            {
                CD_ConceptoPago CDConceptoPago = new CD_ConceptoPago();
                CDConceptoPago.ValidarConcepto(ref ConceptoPago, ref Verificador, ref Mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
