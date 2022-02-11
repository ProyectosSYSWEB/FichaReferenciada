using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Web.UI.WebControls;
using System.IO;
using CapaEntidad;
#region Hecho por
//Nombre:      Lisseth Gtz. Gómez
//Correo:      melissargz@hotmail.com
//Institución: Unach
#endregion
namespace CapaDatos
{
    public class CD_Comun
    {
        public void LlenaCombo(string SP, ref List<Comun> list)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
               
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string Valor1)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
               

                string[] Parametros = { parametro1 };
                object[] Valores = { Valor1 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    else if (dr.FieldCount == 7)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                        Comun.EtiquetaSeis = Convert.ToString(dr.GetValue(6));
                        //Comun.EtiquetaSiete = Convert.ToString(dr.GetValue(7));

                    }
                    else if (dr.FieldCount == 8)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                        Comun.EtiquetaSeis = Convert.ToString(dr.GetValue(6));
                        Comun.EtiquetaSiete = Convert.ToString(dr.GetValue(7));
                        //Comun.EtiquetaOcho = Convert.ToString(dr.GetValue(8));

                    }
                    else if (dr.FieldCount == 9)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                        Comun.EtiquetaSeis = Convert.ToString(dr.GetValue(6));
                        Comun.EtiquetaSiete = Convert.ToString(dr.GetValue(7));
                        Comun.EtiquetaOcho = Convert.ToString(dr.GetValue(8));
                    }

                    list.Add(Comun);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string Valor1, string Valor2)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
               

                string[] Parametros = { parametro1, parametro2 };
                object[] Valores = { Valor1, Valor2 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string Valor1, string Valor2, string Valor3)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
               

                string[] Parametros = { parametro1, parametro2, parametro3 };
                object[] Valores = { Valor1, Valor2, Valor3 };

              Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string Valor1, string Valor2, string Valor3, string Valor4, string Valor5)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
               

                string[] Parametros = { parametro1, parametro2, parametro3, parametro4, parametro5 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4, Valor5 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string parametro5, string parametro6, string Valor1, string Valor2, string Valor3, string Valor4, string Valor5, string Valor6)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4, parametro5, parametro6 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4, Valor5, Valor6 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string Valor1, string Valor2, string Valor3, string Valor4)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
               

                string[] Parametros = { parametro1, parametro2, parametro3, parametro4};
                object[] Valores = { Valor1, Valor2, Valor3, Valor4};

                 Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    else if (dr.FieldCount == 6)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                        Comun.EtiquetaCinco = Convert.ToString(dr.GetValue(5));
                    }
                    list.Add(Comun);
                }
                dr.Close();
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }

        //Listas
        public void LlenaLista(string SP, ref List<Comun> list, string parametro1, string valor1)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1 };
                object[] Valores = { valor1 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        public void LlenaLista(string SP, ref List<Comun> list, string parametro1, string parametro2, string valor1, string valor2)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;
                string[] Parametros = { parametro1, parametro2 };
                object[] Valores = { valor1, valor2 };
                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {

                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {
                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }

        //Combos con grupo
        public void LlenaCombo(string SP, ref List<Comun> list, string parametro1, string parametro2, string parametro3, string parametro4, string Valor1, string Valor2, string Valor3, string Valor4, string usuBD)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmm = null;
            try
            {
                OracleDataReader dr = null;


                string[] Parametros = { parametro1, parametro2, parametro3, parametro4 };
                object[] Valores = { Valor1, Valor2, Valor3, Valor4 };

                Cmm = CDDatos.GenerarOracleCommandCursor(SP, ref dr, Parametros, Valores);

                Comun Comun = default(Comun);
                while (dr.Read())
                {
                    Comun = new Comun();
                    Comun.IdStr = Convert.ToString(dr.GetValue(0));
                    Comun.Descripcion = Convert.ToString(dr.GetValue(1));
                    if (dr.FieldCount == 3)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));

                    }
                    else if (dr.FieldCount == 4)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                    }
                    else if (dr.FieldCount == 5)
                    {

                        Comun.EtiquetaDos = Convert.ToString(dr.GetValue(2));
                        Comun.EtiquetaTres = Convert.ToString(dr.GetValue(3));
                        Comun.EtiquetaCuatro = Convert.ToString(dr.GetValue(4));
                    }
                    list.Add(Comun);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmm);
            }
        }
        //--

        public void ConsultarImagen(ref Comun ObjComun, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            try
            {
                OracleDataReader dr = null;
               
                string[] Parametros = { "p_Evento" };
                object[] Valores = { ObjComun.EtiquetaCuatro };

                ObjComun.Ruta = AppDomain.CurrentDomain.BaseDirectory + "/Images/Evento/";

                string[] files = System.IO.Directory.GetFiles(ObjComun.Ruta);
                foreach (string s in files)
                {
                    System.IO.File.Delete(s);
                }
                cmm = CDDatos.GenerarOracleCommandCursor("pkg_pagos.Obt_Logotipo", ref dr, Parametros, Valores);
                while (dr.Read())
                {
                    ObjComun.ImgBlob = (byte[])dr[0];
                    FileStream FS = new FileStream(ObjComun.Ruta + ObjComun.EtiquetaCuatro + ".jpg", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    FS.Write(ObjComun.ImgBlob, 0, ObjComun.ImgBlob.Length);
                    FS.Close();
                    FS = null;
                    Verificador = "0";
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
        }
        public string Desencripta(string Palabra)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            string clave="0";
            try
            {

                string[] Parametros = { "p_palabra", "p_tipo"};
                string[] ParametrosOut = { "p_encripta" };
                object[] Valores = {Palabra, "D"};

                cmm = CDDatos.GenerarOracleCommand("Gnr_Encripta",Parametros, Valores, ParametrosOut);
                clave= Convert.ToString(cmm.Parameters["p_encripta"].Value);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
            return clave;
        }
        public string ConsultaTipoUsu(Usuario objUsuario, ref string Verificador)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand cmm = null;
            string clave = "0";
            objUsuario.TipoUsu = "N";
            try
            {

                string[] Parametros = { "P_USUARIO" };
                string[] ParametrosOut = { "P_TIPO_USU", "P_BANDERA" };
                object[] Valores = { objUsuario.Nombre };
                cmm = CDDatos.GenerarOracleCommand("VAL_USUARIO_ADMON", Parametros, Valores, ParametrosOut);
                //if (Verificador == "0")
                //{
                    objUsuario.TipoUsu = Convert.ToString(cmm.Parameters["P_TIPO_USU"].Value);
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref cmm);
            }
            return clave;
        }

    }
}