using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class FichaReferenciadaSIAE
    {
        private int _IdReferencia;
        public int IdReferencia
        {
            get { return _IdReferencia; }
            set { _IdReferencia = value; }
        }
        private string _Referencia;
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private double _Importe;
        public double Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        private string _Vigencia;
        public string Vigencia
        {
            get { return _Vigencia; }
            set { _Vigencia = value; }
        }

        private int _Dias_Vigencia=1;
        public int Dias_Vigencia
        {
            get { return _Dias_Vigencia; }
            set { _Dias_Vigencia = value; }
        }

        private string _Concepto;
        public string Concepto
        {
            get { return _Concepto; }
            set { _Concepto = value; }
        }
    }
}
