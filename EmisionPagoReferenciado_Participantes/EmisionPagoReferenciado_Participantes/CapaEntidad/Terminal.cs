using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Terminal
    {
        private string _Nombre_Convenio;
        public string Nombre_Convenio
        {
            get { return _Nombre_Convenio; }
            set { _Nombre_Convenio = value; }
        }

        private string _Numero_Convenio;
        public string Numero_Convenio
        {
            get { return _Numero_Convenio; }
            set { _Numero_Convenio = value; }
        }

        private Usuario _Usuario = new Usuario();
        public Usuario Usuario
        {

            get { return _Usuario; }
            set { _Usuario = value; }
        }
    }
}
