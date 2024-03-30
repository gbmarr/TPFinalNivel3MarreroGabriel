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
        public bool isEdit { get; set; }
        public User Usuario { get; set; }
        public string imgDefecto = "https://cdn.shopify.com/s/files/1/0533/2089/files/placeholder-images-image_large.png?v=1530129081";
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = Session["usuario"] != null ? (User)Session["usuario"] : null;
            UserNegocio negocio = new UserNegocio();

            if (negocio.logueado(Usuario))
            {
                cargarCampos(Usuario);
                if (Request.QueryString["id"] != null)
                {
                    isEdit = true;
                    if (!IsPostBack)
                    {
                        txtPerfilID.Text = Usuario.ID.ToString();
                        txtPerfilEmail.Text = Usuario.Email;
                        txtPerfilPass.Text = Usuario.Pass;
                        txtPerfilNombre.Text = Usuario.Nombre;
                        txtPerfilApellido.Text = Usuario.Apellido;
                        ckdAdmin.Checked = Usuario.TipoUsuario;
                        txtPerfilImagen.Text = Usuario.UrlImagen;
                        imgPerfilUsuarioEdit.ImageUrl = cargarImagen(Usuario.UrlImagen);
                    }
                }
                else
                {
                    isEdit = false;
                }
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
            Response.Redirect("Perfil.aspx?id=" + Usuario.ID, false);
        }

        protected void btnAceptarEditPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                UserNegocio negocio = new UserNegocio();

                Usuario.ID = int.Parse(txtPerfilID.Text);
                Usuario.Email = txtPerfilEmail.Text;
                Usuario.Pass = txtPerfilPass.Text;
                Usuario.Nombre = txtPerfilNombre.Text;
                Usuario.Apellido = txtPerfilApellido.Text;
                Usuario.UrlImagen = txtPerfilImagen.Text;
                Usuario.TipoUsuario = ckdAdmin.Checked;

                if(Request.QueryString["id"] != null)
                    negocio.editarPerfil(Usuario);
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void txtPerfilImagen_TextChanged(object sender, EventArgs e)
        {
            imgPerfilUsuarioEdit.ImageUrl = cargarImagen(txtPerfilImagen.Text);
        }

        private string cargarImagen(string imagen)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagen) || !string.IsNullOrWhiteSpace(imagen))
                    return imagen;
                else
                    return imgDefecto;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }
    }
}