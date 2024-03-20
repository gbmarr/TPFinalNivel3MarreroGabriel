using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace ProductWebApplication
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaFavorito { get; set; }
        private ArticuloNegocio negocio;
        public string imgDefecto = "https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public string cargarCardImg(string imagen)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagen))
                    return imagen;
                else
                    return imgDefecto;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
                throw ex;
            }
        }
    }
}