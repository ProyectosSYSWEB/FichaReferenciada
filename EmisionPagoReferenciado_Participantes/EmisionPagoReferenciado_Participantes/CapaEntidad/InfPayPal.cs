using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class InfPayPal
    {
        public string _idTransaccion = string.Empty;
        public int _IdReferencia;

        public string _Referencia = string.Empty;
        public string _Dependencia = string.Empty;
        public string _Cliente = string.Empty;
        public string _Fecha_Pago = string.Empty;
        public string _Origen = string.Empty;
        private decimal _Total;
        public int _IdRecibo;

        public string Origen
        {
            get { return _Origen; }
            set { _Origen = value; }
        }

        public int IdReferencia
        {
            get { return _IdReferencia; }
            set { _IdReferencia = value; }
        }
        public int IdRecibo
        {
            get { return _IdRecibo; }
            set { _IdRecibo = value; }
        }
        public string Fecha_Pago
        {
            get { return _Fecha_Pago; }
            set { _Fecha_Pago = value; }
        }
        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }
        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public string Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }
        public string idTransaccion
        {
            get { return _idTransaccion; }
            set { _idTransaccion = value; }
        }
    }
}
