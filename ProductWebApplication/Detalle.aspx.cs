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
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            
            if(id != "")
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                // forma larga de obtener el articulo
                // List<Articulo> lista = negocio.listar(id);
                // Articulo seleccionado = lista[0];

                // forma corta
                Articulo seleccionado = (negocio.listar(id))[0];

                // cargo los datos en pantalla
                txtCod.Text = seleccionado.codArticulo;
                txtNombre.Text = seleccionado.Nombre;
                txtDesc.Text = seleccionado.Descripcion;
                txtMarca.Text = seleccionado.Marca.Descripcion;
                txtCat.Text = seleccionado.Categoria.Descripcion;
                txtPrecio.Text = "$" + seleccionado.Precio.ToString();
                imgUrl.ImageUrl = seleccionado.Imagen;
            }
            
        }
    }
}