using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) //Indica que carga por primera vez
            {
                LoadGrid();
            }


        }
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

        UsuarioLogic _UsrLog;
        private UsuarioLogic UsrLog
        {
            get
            {
                if (_UsrLog == null)
                {
                    _UsrLog = new UsuarioLogic();
                }
                return _UsrLog;
            }
        }


        private void LoadGrid()
        {
            this.gridView.DataSource = this.UsrLog.GetAll();
            this.gridView.DataBind();

        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        /*
         La propiedad se almacena dentro del ViewState de la página porque va a ser necesario mantenerla almacenada entre Postbacks
        */

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Usuario Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;

            }
        }




        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        //asd

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;

        }

        private void LoadForm(int id)
        {
            this.Entity = this.UsrLog.GetOne(id);
            this.habilitadoCheckBox.Checked = Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = Entity.NombreUsuario;
            this.claveTextBox.Text = Entity.Clave;
            this.repetirClaveTextBox.Text = Entity.Clave;
            this.idPersonaTextBox.Text = Entity.IDPersona.ToString();
            LoadPersona(Entity.IDPersona);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

            EnableForm(true);
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.IDPersona = int.Parse(this.idPersonaTextBox.Text);
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.UsrLog.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {

                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entity = new Usuario();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        formPanel.Visible = false;
                    }
                    break;
                case FormModes.Alta:
                    {
                        this.Entity = new Usuario();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        formPanel.Visible = false;
                    }
                    break;
                default:
                    break;
            }

            //this.formPanel.Visible = false;
        }

        private void EnableForm(bool condicion)

        {
            this.idPersonaTextBox.Enabled = condicion;
            this.nombreUsuarioTextBox.Enabled = condicion;
            this.claveTextBox.Visible = condicion;
            this.claveLabel.Visible = condicion;
            this.repetirClaveTextBox.Visible = condicion;
            this.repetirClaveLabel.Visible = condicion;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.UsrLog.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);

        }

        private void ClearForm()

        {
            this.idPersonaTextBox.Text = string.Empty;
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
            this.claveTextBox.Text = string.Empty;
            this.repetirClaveTextBox.Text = string.Empty;
        }
        //hacer el punto 42
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
        }

        public Persona Per { get; set; }

        protected void BuscarPersona_Click(object sender, EventArgs e)
        {
            Persona Per = new Persona();
            LoadPersona(int.Parse(idPersonaTextBox.Text));
        }

        protected void LoadPersona(int id)
        {
            Per = PersLog.GetOne(id);
            if (Per.ID != 0)
            {
                nombreTextBox.Text = Per.Nombre;
                apellidoTextBox.Text = Per.Apellido;
                emailTextBox.Text = Per.Email;
            }
            else
            {
                nombreTextBox.Text = String.Empty;
                apellidoTextBox.Text = String.Empty;
                emailTextBox.Text = String.Empty;
            }

        }
    }
}