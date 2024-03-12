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
    public partial class Login : System.Web.UI.Page
    {
        public bool camposInvalidos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool camposValidos(string email, string pass)
        {
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(pass) && !string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(pass))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User usuario = new User();
            UserNegocio negocio = new UserNegocio();

            try
            {
                if(camposValidos(txtEmailLogin.Text, txtPassLogin.Text))
                {
                    usuario.Email = txtEmailLogin.Text;
                    usuario.Pass = txtPassLogin.Text;

                    if (negocio.loguear(usuario))
                    {
                        Session.Add("usuario", usuario);
                        Response.Redirect("Perfil.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "Los datos ingresados no son válidos, debes registrarte");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    camposInvalidos = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if(camposValidos(txtEmailLogin.Text, txtPassLogin.Text))
                {
                    User nuevo = new User();
                    nuevo.Email = txtEmailLogin.Text;
                    nuevo.Pass = txtPassLogin.Text;

                    UserNegocio negocio = new UserNegocio();
                    nuevo.ID = negocio.agregarUsuario(nuevo);
                    Session.Add("usuario", nuevo);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    camposInvalidos = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnEntendido_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }
    }
}