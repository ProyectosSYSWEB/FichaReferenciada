﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Menus
    {

        private string _NombreMenu;
        public string NombreMenu
        {
            get { return _NombreMenu; }
            set { _NombreMenu = value; }
        }

        private string _UsuarioNombre;
        public string UsuarioNombre
        {
            get { return _UsuarioNombre; }
            set { _UsuarioNombre = value; }
        }

        private int _Grupo;
        public int Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }

    }
}
