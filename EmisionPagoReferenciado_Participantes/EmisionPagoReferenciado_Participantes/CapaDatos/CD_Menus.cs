using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using CapaEntidad;
using System.Web.UI.WebControls;

namespace CapaDatos
{
    public class CD_Menus
    {

        public void LlenarMenus(ref Menu Mnu, ref Menus DatosMenu)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader dr = null;
              

                string[] Parametros = { 
                                        "p_usuario",
                                        "p_grupo", 
                                      };
                object[] Valores = { 
                                        DatosMenu.UsuarioNombre  ,   
                                        DatosMenu.Grupo,  
                                   };
              Cmd = CDDatos.GenerarOracleCommandCursor("PKG_CONTRATOS.Obt_Sistemas", ref dr, Parametros, Valores);

                if (dr.HasRows)
                {
                    MenuItem m1 = new MenuItem("Inicio", "0", "", "#");
                    Mnu.Items.Add(m1);

                    while (dr.Read())
                    {
                        MenuItem mnuMenuItem = new MenuItem();

                        if (dr["padre"].ToString() == string.Empty)
                        {
                            mnuMenuItem.Value = dr["id"].ToString();
                            mnuMenuItem.Text = dr["descripcion"].ToString();
                            mnuMenuItem.NavigateUrl = dr["clave"].ToString();
                            Mnu.Items.Add(mnuMenuItem);
                            AddMenuItem(mnuMenuItem, ref DatosMenu);
                        }
                    }
                    m1 = new MenuItem("Salir", "0", "", "Login.aspx");
                    Mnu.Items.Add(m1);

                    dr.Close();
                }
              
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }

        protected void AddMenuItem(MenuItem mnuItem, ref Menus mnu)
        {
            CD_Datos CDDatos = new CD_Datos();
            OracleCommand Cmd = null;
            try
            {
                OracleDataReader reader = null;
                

                string[] Parametros = { 
                                        "p_usuario",
                                        "p_grupo", 
                                      };
                object[] Valores = { 
                                        mnu.UsuarioNombre  ,   
                                        mnu.Grupo,  
                                   };
                Cmd = CDDatos.GenerarOracleCommandCursor("PKG_CONTRATOS.Obt_Sistemas", ref reader, Parametros, Valores);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MenuItem mnuNewMenuItem = new MenuItem();
                        if (reader["id_padre"].ToString().Equals(mnuItem.Value))
                        {
                            mnuNewMenuItem.Value = reader["id"].ToString();
                            mnuNewMenuItem.Text = reader["descripcion"].ToString();
                            mnuNewMenuItem.NavigateUrl = reader["clave"].ToString();
                            mnuItem.ChildItems.Add(mnuNewMenuItem);
                            AddMenuItem(mnuNewMenuItem, ref mnu);
                        }
                    }
                    reader.Close();
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CDDatos.LimpiarOracleCommand(ref Cmd);
            }
        }
    }
}