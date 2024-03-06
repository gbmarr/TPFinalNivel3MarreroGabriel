using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace ProductWebApplication
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            if (!IsPostBack)
            {
                ddlMarca.DataSource = negocio.listarConSP();
                ddlMarca.DataTextField = "Marca";
                ddlMarca.DataValueField = "ID";
                ddlMarca.DataBind();
                ddlCat.DataSource = negocio.listarConSP();
                ddlCat.DataTextField = "Categoria";
                ddlCat.DataValueField = "ID";
                ddlCat.DataBind();
            }
            // obtengo el id si es que viene en la url
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (id != "")
            {
                // obtengo el articulo que coincida con el id
                Articulo modificar = (negocio.listar(id))[0];

                // cargo los campos de texto con los datos del articulo a modificar
                txtID.Text = id;
                txtCod.Text = modificar.codArticulo;
                txtNombre.Text = modificar.Nombre;
                txtDesc.Text = modificar.Descripcion;
                ddlMarca.SelectedValue = modificar.Marca.Descripcion;
                ddlCat.SelectedValue = modificar.Categoria.Descripcion;
                txtPrecio.Text = modificar.Precio.ToString();
                txtImagen.Text = modificar.Imagen;
                imageUrl.ImageUrl = modificar.Imagen;
            }
        }
    }
}