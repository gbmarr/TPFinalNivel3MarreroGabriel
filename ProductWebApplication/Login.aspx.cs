using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
    }
}