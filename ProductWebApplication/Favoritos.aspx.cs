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
        public List<Articulo> ListaFavoritos { get; set; }
        public string imgDefecto = "https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            User usuario = Session["usuario"] != null ? ((User)Session["usuario"]) : null;
            FavoritoNegocio negocioFavs = new FavoritoNegocio();

            if (usuario != null)
            {
                if (!IsPostBack)
                {
                    ListaFavoritos = negocioFavs.listarFavoritos(usuario.ID);
                    if (ListaFavoritos != null)
                    {
                        repeaterFav.DataSource = ListaFavoritos;
                        repeaterFav.DataBind();
                    }
                }
            }
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

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
            FavoritoNegocio negocioFavs = new FavoritoNegocio();
            try
            {
                User usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;

                if(usuario != null)
                {
                    string idArti = ((Button)sender).CommandArgument;
                    negocioFavs.eliminarFavorito(idArti, usuario.ID.ToString());

                    ListaFavoritos = negocioFavs.listarFavoritos(usuario.ID);
                    if (ListaFavoritos != null)
                    {
                        repeaterFav.DataSource = ListaFavoritos;
                        repeaterFav.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}