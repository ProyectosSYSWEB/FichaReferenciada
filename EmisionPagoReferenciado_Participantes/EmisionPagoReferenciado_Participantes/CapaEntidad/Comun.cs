using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class Comun
    {
        private int _Id;
        private string _IdStr;
        private string _Descripcion;
        private string _EtiquetaDos;
        private string _EtiquetaTres;
        private string _EtiquetaCuatro;
        private string _EtiquetaCinco;
        private string _EtiquetaSeis;
        private string _EtiquetaSiete;
        private string _EtiquetaOcho;
        private string _Ruta;
        private byte[] _ImgBlob;

        public byte[] ImgBlob
        {
            get { return _ImgBlob; }
            set { _ImgBlob = value; }
        }

        public string Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }

        public string EtiquetaTres
        {
            get { return _EtiquetaTres; }
            set { _EtiquetaTres = value; }
        }
        public string EtiquetaDos
        {
            get { return _EtiquetaDos; }
            set { _EtiquetaDos = value; }
        }

        public string EtiquetaCuatro
        {
            get { return _EtiquetaCuatro; }
            set { _EtiquetaCuatro = value; }
        }
        public string EtiquetaCinco
        {
            get { return _EtiquetaCinco; }
            set { _EtiquetaCinco = value; }
        }

        public string EtiquetaSeis
        {
            get { return _EtiquetaSeis; }
            set { _EtiquetaSeis = value; }
        }

        public string EtiquetaSiete
        {
            get { return _EtiquetaSiete; }
            set { _EtiquetaSiete = value; }
        }

        public string EtiquetaOcho
        {
            get { return _EtiquetaOcho; }
            set { _EtiquetaOcho = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string IdStr
        {
            get { return _IdStr; }
            set { _IdStr = value; }
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
}
