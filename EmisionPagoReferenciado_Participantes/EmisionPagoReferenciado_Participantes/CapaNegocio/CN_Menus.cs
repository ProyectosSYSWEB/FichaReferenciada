﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Menus
    {

        public void LlenarMenus(ref Menu MenuT, ref Menus menu)
        {
            try
            {
                CD_Menus claseCapaDatos = new CD_Menus();
                claseCapaDatos.LlenarMenus(ref  MenuT, ref menu);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}