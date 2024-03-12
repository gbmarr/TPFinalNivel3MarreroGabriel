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
        public User Usuario { get; set; }
        private string imgDefecto = "https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
            UserNegocio negocio = new UserNegocio();

            if (negocio.logueado(Usuario))
            {
                cargarCampos(Usuario);
            }
        }

        private void cargarCampos(User Usuario)
        {
            try
            {
                lblID.Text = Usuario.ID.ToString() ?? "#userID";
                lblNombre.Text = Usuario.Nombre ?? "#usernombre";
                lblApellido.Text = Usuario.Apellido ?? "#userapellido";
                if (!string.IsNullOrEmpty(Usuario.UrlImagen))
                    imgPerfilUsuario.ImageUrl = Usuario.UrlImagen;
                else
                    imgPerfilUsuario.ImageUrl = imgDefecto;
                ckbAdmin.Checked = Usuario.TipoUsuario;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx?profile=edit", false);
        }
    }
}