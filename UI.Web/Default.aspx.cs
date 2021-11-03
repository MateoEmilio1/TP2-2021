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
            
            lblNombre.Text = ((Usuario)Session["UsuarioActual"]).Persona.Nombre;
            lblApellido.Text = ((Usuario)Session["UsuarioActual"]).Persona.Apellido;
            lblTipo.Text = ((Usuario)Session["UsuarioActual"]).Persona.TipoPersona;
        }

        

    }
}