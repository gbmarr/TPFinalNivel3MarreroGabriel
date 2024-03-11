using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProductWebApplication
{
    public partial class Error : System.Web.UI.Page
    {
        public string error { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                error = Session["error"] != null ? Session["error"].ToString() : "Error no reconocido, contactese con su desarrollador...";
                lblError.Text = error;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}