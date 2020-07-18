using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Componente
    {
        private int _IdComponente;
        public int IdComponente
        {
            get { return _IdComponente; }
            set { _IdComponente = value; }
        }

        private int _Orden;
        public int Orden
        {
            get { return _Orden; }
            set { _Orden = value; }
        }

        private string _Evento;
        public string Evento
        {
            get { return _Evento; }
            set { _Evento = value; }
        }

        private string _Control;
        public string Control
        {
            get { return _Control; }
            set { _Control = value; }
        }

        private string _IdControl;
        public string IdControl
        {
            get { return _IdControl; }
            set { _IdControl = value; }
        }

        private string _Text;
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        private string _Valor;
        public string Valor
        {
            get { return _Valor; }
            set { _Valor = value; }
        }

        private string _IdControlValida;
        public string IdControlValida
        {
            get { return _IdControlValida; }
            set { _IdControlValida = value; }
        }

        private string _Style_Key=string.Empty;
        public string Style_Key
        {
            get { return _Style_Key; }
            set { _Style_Key = value; }
        }

        private string _Style_Value = string.Empty;
        public string Style_Value
        {
            get { return _Style_Value; }
            set { _Style_Value = value; }
        }

    }
}
