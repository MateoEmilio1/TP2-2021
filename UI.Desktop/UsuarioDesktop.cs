using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop() //Constructor por default
        {
            

        }

        public UsuarioDesktop (ModoForm modo):this () //alta
        {
            InitializeComponent();
            Modo = modo ;
            Usuario usuario = new Usuario();
            UsuarioActual = usuario;

            MapearDeDatos();

        }

        public UsuarioDesktop(int ID, ModoForm modo):this() //modificacion/baja
        {
            InitializeComponent();
            Modo = modo;
            UsuarioLogic Usuario_Logic = new UsuarioLogic();
            UsuarioActual = Usuario_Logic.GetOne(ID);
            MapearDeDatos();

        }

        public override void MapearDeDatos()
        {

            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Persona.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Persona.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Persona.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave; // confirmarclave?

            
            
            if (  (Modo == (ModoForm.Alta))  ||  (Modo == (ModoForm.Modificacion)) )
            {
                this.btnAceptar.Text = "Guardar";
            }
            if (Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            if ( Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }


        }
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario user = new Usuario();
                UsuarioActual = user;
            }
            else
            {
                this.UsuarioActual.ID = Convert.ToInt32( this.txtID.Text);
               
            }
            

            if ((Modo == (ModoForm.Alta)) || (Modo == (ModoForm.Modificacion)))
            {
                this.UsuarioActual.ID = Convert.ToInt16(this.txtID.Text);

                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;

                this.UsuarioActual.Persona.Nombre = this.txtNombre.Text;

                this.UsuarioActual.Persona.Apellido = this.txtApellido.Text;

                this.UsuarioActual.Persona.Email = this.txtEmail.Text;

                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;

                this.UsuarioActual.Clave = this.txtClave.Text;

            }
            
            
            if (Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }
            if (Modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = BusinessEntity.States.Modified; 
            }
            if (Modo == ModoForm.Alta)
            {
                UsuarioActual.State = BusinessEntity.States.New; 
            }
            if (Modo == ModoForm.Consulta)
            {
                UsuarioActual.State = BusinessEntity.States.Unmodified; 
            }




        }
        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic user = new UsuarioLogic();
            user.Save(UsuarioActual);

        }
        public override bool Validar()
        {   
            if(
            (this.txtID.Text != null) &&
            ((this.chkHabilitado.Checked== true) || (this.chkHabilitado.Checked == false)) &&
            (this.txtNombre.Text != null ) &&
            (this.txtApellido.Text != null) &&
            (this.txtEmail.Text != null ) &&
            (this.txtUsuario.Text != null) &&
            (txtClave.Text == txtConfirmarClave.Text) && 
            ((txtClave.TextLength) >= 8) &&
            (this.chkHabilitado.Checked == true) 
            )
            {
                return true;
            }
            else
            {
                Notificar("Error al ingreso del datos", "Verifique sus datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

        }

        
        
        public override void Notificar(string titulo, string mensaje, MessageBoxButtons
                        botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }
        public override void Notificar(string mensaje, MessageBoxButtons botones,
        MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
        
        Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get
            {
                return _usuarioActual;
            }
            set
            {
                _usuarioActual = value;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool opc;
            opc = Validar();

            if(opc == true)
            {
                GuardarCambios();
                Close();
            }
            else if(opc == true)
            {
                Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

// Version final ABM en funcionamiento 5/7/21