using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
using System.Web.UI.HtmlControls;

namespace ProductWebApplication
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool confirmaEliminacion;
        private string imgDefecto = "https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png";
        private ArticuloNegocio negocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                cargarDesplegables();

                if (id == "")
                    btnModificar.Text = "Agregar";

                cargarCampos(id);
            }
        }

        private void cargarDesplegables()
        {
            try
            {
                negocio = new ArticuloNegocio();
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
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        private void cargarCampos(string id)
        {
            negocio = new ArticuloNegocio();
            // obtengo el id si es que viene en la url
            if (id != "" && !IsPostBack)
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
                imageUrl.ImageUrl = cargarImagen(modificar.Imagen);
            }
        }

        private string cargarImagen(string imagen)
        {
            try
            {
                if (imagen != null || imagen != "")
                    return imagen;
                else
                    return imagen = imgDefecto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                negocio = new ArticuloNegocio();

                //nuevo.ID = int.Parse(txtID.Text);
                nuevo.codArticulo = txtCod.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDesc.Text;

                nuevo.Marca = new Elemento();
                nuevo.Marca.ID = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Elemento();
                nuevo.Categoria.ID = int.Parse(ddlCat.SelectedValue);

                nuevo.Imagen = txtImagen.Text;
                nuevo.Precio = Decimal.Parse(txtPrecio.Text);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.ID = int.Parse(txtID.Text);
                    negocio.modificarArticuloConSP(nuevo);
                }
                else
                {
                    negocio.agregarArticuloConSP(nuevo);
                }


                Response.Redirect("ListadoArticulos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmaEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                negocio = new ArticuloNegocio();
                negocio.eliminar(int.Parse(txtID.Text));
                Response.Redirect("ListadoArticulos.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnCancelarEliminacion_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            imageUrl.ImageUrl = cargarImagen(txtImagen.Text);
        }
    }
}