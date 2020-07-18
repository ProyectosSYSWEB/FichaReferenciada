using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Alumno:Persona
    {
        private string _CicloEscolar;

        public string CicloEscolar
        {
            get { return _CicloEscolar; }
            set { _CicloEscolar = value; }
        }
        private string _Nivel;

        public string Nivel
        {
            get { return _Nivel.Trim(); }
            set { _Nivel = value.Trim(); }
        }
        private string _Grupo;

        public string Grupo
        {
            get { return _Grupo; }
            set { _Grupo = value; }
        }
        
        private string _Semestre;

        public string Semestre
        {
            get { return _Semestre; }
            set { _Semestre = value; }
        }
        private string _Carrera;

        public string Carrera
        {
            get { return _Carrera; }
            set { _Carrera = value; }
        }
        private string _DescCarrera;

        public string DescCarrera
        {
            get { return _DescCarrera; }
            set { _DescCarrera = value; }
        }
        private string _DescEscuela;

        public string DescEscuela
        {
            get { return _DescEscuela; }
            set { _DescEscuela = value; }
        }
        private string _Matricula;

        public string Matricula
        {
            get { return _Matricula; }
            set { _Matricula = value; }
        }
        private string _UsuNombre;

        public string UsuNombre
        {
            get { return _UsuNombre; }
            set { _UsuNombre = value; }
        }
        private string _StatusMatricula;

        public string StatusMatricula
        {
            get { return _StatusMatricula; }
            set { _StatusMatricula = value; }
        }

    }
}
