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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Usuario usr { get; set; }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            lblIncorrecto.Visible= false;
            lblInhabilitado.Visible = false;
            
            UsuarioLogic UsuarioLog = new UsuarioLogic();
            usr = UsuarioLog.GetUsuarioLogin(txtNombreUsuario.Text, txtClave.Text);
            if (usr.ID != 0)
            {
                if (usr.Habilitado)
                {
                    Session["UsuarioActual"] = usr;
                    Page.Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblInhabilitado.Visible = true;
                }
            }
            else
            {
                lblIncorrecto.Visible = true;
                txtNombreUsuario.Text = string.Empty;
                txtClave.Text = string.Empty;
            }
        }
    }
}