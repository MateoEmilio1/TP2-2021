using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioActual"] == null)
            {
                bodyForm.Visible = false;
            }
            

        }


        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["UsuarioActual"] = null;
            Page.Response.Redirect("~/Login.aspx");
        }
    }
}