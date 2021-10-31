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
            Persona PersonaActual = PersLog.GetOne(UsrActual.IDPersona);
            lblNombre.Text = PersonaActual.Nombre;
            lblApellido.Text = PersonaActual.Apellido;
            lblTipo.Text = PersonaActual.TipoPersona;
        }

        public Usuario UsrActual { get; set; }

        public Persona PersonaActual { get; set; }

        PersonaLogic _PersLog;
        private PersonaLogic PersLog
        {
            get
            {
                if (_PersLog == null)
                {
                    _PersLog = new PersonaLogic();
                }
                return _PersLog;
            }
        }

    }
}