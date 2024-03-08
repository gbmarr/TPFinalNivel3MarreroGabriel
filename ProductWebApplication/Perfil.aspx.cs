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
    public partial class Perfil : System.Web.UI.Page
    {
        public User usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
            UserNegocio negocio = new UserNegocio();

            if (negocio.logueado(usuario))
            {
                lblID.Text = usuario.ID.ToString();
                lblNombre.Text = usuario.Nombre;
                lblApellido.Text = usuario.Apellido;
                imgPerfilUsuario.ImageUrl = usuario.UrlImagen;
                ckbAdmin.Checked = usuario.TipoUsuario;
            }
        }

        protected void btnEditarPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}