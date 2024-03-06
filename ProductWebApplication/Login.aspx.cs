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
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["page"] != null)
            {
                lblLoginTitle.Text = "Registro";
                btnLogin.Text = "Registrarse";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User usuario = new User();
            UserNegocio negocio = new UserNegocio();

            try
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
                    Session.Add("error de logueo", "Los datos ingresados no son válidos");
                    Response.Redirect("Error.aspx", false);
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