using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario UsrActual = (Usuario)Session["UsuarioActual"];
            
            lblNombre.Text = UsrActual.Nombre;
            lblApellido.Text = UsrActual.Apellido;
        }

        public Usuario UsrActual { get; set; }



    }
}