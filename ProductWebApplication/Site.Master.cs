using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductWebApplication
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PaginaNoDisponible())
            {
                Response.Redirect("Login.aspx");
            }
        }

        private bool PaginaNoDisponible()
        {
            try
            {
                if (Page is Listado_de_Articulos || Page is FormularioArticulo || Page is Perfil || Page is Favoritos)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}