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
    public partial class Site : System.Web.UI.MasterPage
    {
        private User usuario;
        private string imgDefecto = "https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            verificarLogueo();
            cargarImagen();
        }

        // metodo para cargar la imagen de perfil en la barra de navegacion
        public void cargarImagen()
        {
            try
            {
                usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
                if (usuario != null)
                    imgPerfilLogueado.ImageUrl = usuario.UrlImagen;
                else
                    imgPerfilLogueado.ImageUrl = imgDefecto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // metodos para verificar si el cliente esta logueado y determinacion de las paginas a las que tiene acceso
        private void verificarLogueo()
        {
            usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
            if (PageNoDisponible())
            {
                UserNegocio negocio = new UserNegocio();
                if (!negocio.logueado(usuario))
                {
                    Response.Redirect("Login.aspx", false);
                }
            }
        }

        private bool PageNoDisponible()
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

        protected void btnDesloguear_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}