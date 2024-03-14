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
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        private ArticuloNegocio negocio;
        public string imgDefecto = "https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listarConSP();
            cargarDesplegables();
        }

        protected void cardFavorito_Click(object sender, EventArgs e)
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

        private void cargarDesplegables()
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlCampoBusqueda.Items.Add("Código");
                    ddlCampoBusqueda.Items.Add("Nombre");
                    ddlCampoBusqueda.Items.Add("Marca");
                    ddlCampoBusqueda.Items.Add("Categoría");
                    ddlCampoBusqueda.Items.Add("Precio");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlCampoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string campo = ddlCampoBusqueda.SelectedValue;
                if(campo == "Nombre" || campo == "Código" || campo == "Marca" || campo == "Categoría")
                {
                    ddlCriterioBusqueda.Items.Clear();
                    ddlCriterioBusqueda.Items.Add("Comienza con");
                    ddlCriterioBusqueda.Items.Add("Contiene");
                    ddlCriterioBusqueda.Items.Add("Termina con");
                }
                else if(campo == "Precio")
                {
                    ddlCriterioBusqueda.Items.Clear();
                    ddlCriterioBusqueda.Items.Add("Menor a");
                    ddlCriterioBusqueda.Items.Add("Igual");
                    ddlCriterioBusqueda.Items.Add("Mayor a");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}