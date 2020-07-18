using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Usuario
    {
        private string _Nombre;
        private string _Login;
        private string _Password;
        private string _TipoUsu;
        //private string _NUsuario;

        //public string NUsuario
        //{
        //    get { return _NUsuario; }
        //    set { _NUsuario = value; }
        //}
        private string _Dependencia;

        public string Dependencia
        {
            get { return _Dependencia; }
            set { _Dependencia = value; }
        }

        public string Login
        {
            get { return _Login.Trim(); }
            set { _Login = value.Trim(); }
        }
        public string Nombre
        {
            get { return _Nombre.Trim(); }
            set { _Nombre = value.Trim(); }
        }

        public string Password
        {
            get { return _Password.Trim(); }
            set { _Password = value.Trim(); }
        }

        public string TipoUsu
        {
            get { return _TipoUsu.Trim(); }
            set { _TipoUsu = value.Trim(); }
        }
    }
}
