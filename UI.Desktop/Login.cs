using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Login : ApplicationForm
    {
        public Login()
        {
            InitializeComponent();
        }

        public Usuario usr { get; set; }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            UsuarioLogic UsuarioLog = new UsuarioLogic();
            usr = UsuarioLog.GetUsuarioLogin(txtNombreUsuario.Text, txtClave.Text);
            if (usr.ID != 0)
            {
                if (usr.Habilitado)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.Notificar("Usuario no habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtClave.Clear();
            }
        }
    }
}
