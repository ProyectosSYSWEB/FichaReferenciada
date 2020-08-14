using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Sesion
    {
        private string _UsuWXI;
        public string UsuWXI
        {
            get { return _UsuWXI.Trim(); }
            set { _UsuWXI = value.Trim(); }
        }

        private string _ComponentesExtras="N";
        public string ComponentesExtras
        {
            get { return _ComponentesExtras.Trim(); }
            set { _ComponentesExtras = value.Trim(); }
        }

        private string _UsuNivel;
        public string UsuNivel
        {
            get { return _UsuNivel.Trim(); }
            set { _UsuNivel = value.Trim(); }
        }

        private string _UsuTelefono;
        public string UsuTelefono
        {
            get { return _UsuTelefono.Trim(); }
            set { _UsuTelefono = value.Trim(); }
        }

        private string _UsuCelular;
        public string UsuCelular
        {
            get { return _UsuCelular.Trim(); }
            set { _UsuCelular = value.Trim(); }
        }

        private string _UsuCorreo;
        public string UsuCorreo
        {
            get {
                return _UsuCorreo.Trim(); }
            set { _UsuCorreo = value.Trim(); }
        }

        private string _UsuNombre;
        public string UsuNombre
        {
            get { return _UsuNombre.Trim(); }
            set { _UsuNombre = value.Trim(); }
        }

        private string _UsuApaterno;
        public string UsuApaterno
        {
            get { return _UsuApaterno.Trim(); }
            set { _UsuApaterno = value.Trim(); }
        }

        private string _UsuAMaterno;
        public string UsuAMaterno
        {
            get { return _UsuAMaterno.Trim(); }
            set { _UsuAMaterno = value.Trim(); }
        }

        private string _UsuDependencia;
        public string UsuDependencia
        {
            get { return _UsuDependencia.Trim(); }
            set { _UsuDependencia = value.Trim(); }
        }

        private string _UsuEvento=string.Empty;
        public string UsuEvento
        {
            get { return _UsuEvento.Trim(); }
            set { _UsuEvento = value.Trim(); }
        }

        //Evento_Exclusivo

        private string _UsuEvento_Exclusivo="N";
        public string UsuEvento_Exclusivo
        {
            get { return _UsuEvento_Exclusivo.Trim(); }
            set { _UsuEvento_Exclusivo = value.Trim(); }
        }

        private string _Operacion;
        public string Operacion
        {
            get { return _Operacion.Trim(); }
            set { _Operacion = value.Trim(); }
        }

        private string _UsuTipoUsu;
        public string UsuTipoUsu
        {
            get { return _UsuTipoUsu.Trim(); }
            set { _UsuTipoUsu = value.Trim(); }
        }

        private string _UsuMatricula;
        public string UsuMatricula
        {
            get { return _UsuMatricula.Trim(); }
            set { _UsuMatricula = value.Trim(); }
        }
        
        private string _UsuCarrera;
        public string UsuCarrera
        {
            get { return _UsuCarrera.Trim(); }
            set { _UsuCarrera = value.Trim(); }
        }
        
        private string _UsuGrupo;
        public string UsuGrupo
        {
            get { return _UsuGrupo.Trim(); }
            set { _UsuGrupo = value.Trim(); }
        }
        
        private string _UsuSemestre;
        public string UsuSemestre
        {
            get { return _UsuSemestre.Trim(); }
            set { _UsuSemestre = value.Trim(); }
        }

        private string _XMLCadena;
        public string XMLCadena
        {
            get { return _XMLCadena.Trim(); }
            set { _XMLCadena = value.Trim(); }
        }

        private string _Donativo;
        public string Donativo
        {
            get { return _Donativo.Trim(); }
            set { _Donativo = value.Trim(); }
        }

        private string _PeriodoPago;
        public string PeriodoPago
        {
            get { return _PeriodoPago.Trim(); }
            set { _PeriodoPago = value.Trim(); }
        }

        private int _TipoPersona=0;
        public int TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        private string _TipoPersonaStr;
        public string TipoPersonaStr
        {
            get { return _TipoPersonaStr; }
            set { _TipoPersonaStr = value; }
        }

        private int _FichaRefID=0;
        public int FichaRefID
        {
            get { return _FichaRefID; }
            set { _FichaRefID = value; }
        }

        private int _FichaRefIDPagoTC;
        public int FichaRefIDPagoTC
        {
            get { return _FichaRefIDPagoTC; }
            set { _FichaRefIDPagoTC = value; }
        }

        private int _FichaOpcion;
        public int FichaOpcion
        {
            get { return _FichaOpcion; }
            set { _FichaOpcion = value; }
        }

        private string _FichaReferencia=string.Empty;
        public string FichaReferencia
        {
            get { return _FichaReferencia.Trim(); }
            set { _FichaReferencia = value.Trim(); }
        }

        //--INICIA DATOS FISCALES--//
        private string _FichaTipoPersonaFiscal;
        public string FichaTipoPersonaFiscal
        {
            get { return _FichaTipoPersonaFiscal.Trim(); }
            set { _FichaTipoPersonaFiscal = value.Trim(); }
        }

        private string _FichaRFC;
        public string FichaRFC
        {
            get { return _FichaRFC.Trim(); }
            set { _FichaRFC = value.Trim(); }
        }

        private string _FichaRazonSocial;
        public string FichaRazonSocial
        {
            get { return _FichaRazonSocial.Trim(); }
            set { _FichaRazonSocial = value.Trim(); }
        }

        private string _FichaDomicilio;
        public string FichaDomicilio
        {
            get { return _FichaDomicilio.Trim(); }
            set { _FichaDomicilio = value.Trim(); }
        }

        public string FichaCalleFiscal
        {
            get { return _FichaCalleFiscal.Trim(); }
            set { _FichaCalleFiscal = value.Trim(); }
        }
        private string _FichaCalleFiscal;

        public string FichaColoniaFiscal
        {
            get { return _FichaColoniaFiscal.Trim(); }
            set { _FichaColoniaFiscal = value.Trim(); }
        }
        private string _FichaColoniaFiscal;

        public string FichaCPFiscal
        {
            get { return _FichaCPFiscal.Trim(); }
            set { _FichaCPFiscal = value.Trim(); }
        }
        private string _FichaCPFiscal;

        public string FichaEstadoFiscal
        {
            get { return _FichaEstadoFiscal.Trim(); }
            set { _FichaEstadoFiscal = value.Trim(); }
        }
        private string _FichaEstadoFiscal;

        public string FichaMunicipioFiscal
        {
            get { return _FichaMunicipioFiscal.Trim(); }
            set { _FichaMunicipioFiscal = value.Trim(); }
        }
        private string _FichaMunicipioFiscal;

        public string FichaTelefonoFiscal
        {
            get { return _FichaTelefonoFiscal.Trim(); }
            set { _FichaTelefonoFiscal = value.Trim(); }
        }
        private string _FichaTelefonoFiscal;

        private string _FichaCorreoFiscal;
        public string FichaCorreoFiscal
        {
            get { return _FichaCorreoFiscal.Trim(); }
            set { _FichaCorreoFiscal = value.Trim(); }
        }

        private string _FichaMetodoPago;
        public string FichaMetodoPago
        {
            get { return _FichaMetodoPago.Trim(); }
            set { _FichaMetodoPago = value.Trim(); }
        }


        private string _FichaComprobanteFiscal;
        public string FichaComprobanteFiscal
        {
            get { return _FichaComprobanteFiscal.Trim(); }
            set { _FichaComprobanteFiscal = value.Trim(); }
        }

        //--FIN DATOS FISCALES--//

        private string _FichaCiudad;
        public string FichaCiudad
        {
            get { return _FichaCiudad.Trim(); }
            set { _FichaCiudad = value.Trim(); }
        }

        private int _FichaVigencia;
        public int FichaVigencia
        {
            get { return _FichaVigencia; }
            set { _FichaVigencia = value; }
        }
        
        private string _Observaciones;
        public string Observaciones
        {
            get { return _Observaciones.Trim(); }
            set { _Observaciones = value.Trim(); }
        }

        private int _ConceptoID;
        public int ConceptoID
        {
            get { return _ConceptoID; }
            set { _ConceptoID = value; }
        }

        private int _Id_Comprobante;
        public int Id_Comprobante
        {
            get { return _Id_Comprobante; }
            set { _Id_Comprobante = value; }
        }

        private double _ImpConcepto;
        public double ImpConcepto
        {
            get { return _ImpConcepto; }
            set { _ImpConcepto = value; }
        }

        private double _ImpDetalleConcep;
        public double ImpDetalleConcep
        {
            get { return _ImpDetalleConcep; }
            set { _ImpDetalleConcep = value; }
        }

        private string _FechaVigencia;
        public string FechaVigencia
        {
            get { return _FechaVigencia; }
            set { _FechaVigencia = value; }
        }

        private string _Anexo;
        public string Anexo
        {
            get { return _Anexo; }
            set { _Anexo = value; }
        }

        //private string _Anexo2; //Observaciones que son especificadas por los eventos, no por el usuario que genera la referencia.
        //public string Anexo2
        //{
        //    get { return _Anexo2; }
        //    set { _Anexo2 = value; }
        //}

        private string _MatriculaCapturada;
        public string MatriculaCapturada
        {
            get { return _MatriculaCapturada; }
            set { _MatriculaCapturada = value; }
        }

        private string _NuevoReg;
        public string NuevoReg 
        {
            get { return _NuevoReg; }
            set { _NuevoReg = value; }
        }


        private string _Ponente;
        public string Ponente
        {
            get { return _Ponente; }
            set { _Ponente = value; }
        }

        private string _RequiereConstancia;
        public string RequiereConstancia
        {
            get { return _RequiereConstancia; }
            set { _RequiereConstancia = value; }
        }

        //PARAMETROS BANCOMER
        private string _ReferenceBancomer;
        public string ReferenceBancomer
        {
            get { return _ReferenceBancomer; }
            set { _ReferenceBancomer = value; }
        }

        private string _NumAutorizacionBancomer;
        public string NumAutorizacionBancomer
        {
            get { return _NumAutorizacionBancomer; }
            set { _NumAutorizacionBancomer = value; }
        }

        private string _HashBancomer;
        public string HashBancomer
        {
            get { return _HashBancomer; }
            set { _HashBancomer = value; }
        }

        private string _OrderBancomer;
        public string OrderBancomer
        {
            get { return _OrderBancomer; }
            set { _OrderBancomer = value; }
        }

        private string _AmountBancomer;
        public string AmountBancomer
        {
            get { return _AmountBancomer; }
            set { _AmountBancomer = value; }
        }

        private string _DateBancomer;
        public string DateBancomer
        {
            get { return _DateBancomer; }
            set { _DateBancomer = value; }
        }

        private string _PaymentMethodBancomer;
        public string PaymentMethodBancomer
        {
            get { return _PaymentMethodBancomer; }
            set { _PaymentMethodBancomer = value; }
        }

        private string _FolioBancomer;
        public string FolioBancomer
        {
            get { return _FolioBancomer; }
            set { _FolioBancomer = value; }
        }

        private string _PanBancomer;
        public string PanBancomer
        {
            get { return _PanBancomer; }
            set { _PanBancomer = value; }
        }

        private string _TipoParticipante;
        public string TipoParticipante
        {
            get { return _TipoParticipante; }
            set { _TipoParticipante = value; }
        }

       


        private List<Comun> _ListDetConceptoDisp = new List<Comun>();
        public List<Comun> ListDetConceptoDisp
        {
            get { return _ListDetConceptoDisp; }
            set { _ListDetConceptoDisp = value; }
        }

        private List<Comun> _ListDetConceptoAsig = new List<Comun>();
        public List<Comun> ListDetConceptoAsig
        {
            get { return _ListDetConceptoAsig; }
            set { _ListDetConceptoAsig = value; }
        }

        private Terminal _Terminal = new Terminal();
        public Terminal Terminal
        {

            get { return _Terminal; }
            set { _Terminal = value; }
        }
    }
}
