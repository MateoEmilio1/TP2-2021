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
            gridView.DataSource = UsrLog.GetAll();
            gridView.DataBind();

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
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
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
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedID"] = value;

            }
        }




        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }

        //asd

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridView.SelectedValue;

        }

        private void LoadForm(int id)
        {
            Entity = UsrLog.GetOne(id);
            habilitadoCheckBox.Checked = Entity.Habilitado;
            nombreUsuarioTextBox.Text = Entity.NombreUsuario;
            claveTextBox.Text = Entity.Clave;
            repetirClaveTextBox.Text = Entity.Clave;
            idPersonaTextBox.Text = Entity.Persona.ID.ToString(); 
            nombreTextBox.Text = Entity.Persona.Nombre;
            apellidoTextBox.Text = Entity.Persona.Apellido;
            emailTextBox.Text = Entity.Persona.Email;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

            EnableForm(true);
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Persona = PersLog.GetOne(int.Parse(idPersonaTextBox.Text));
            usuario.NombreUsuario = nombreUsuarioTextBox.Text;
            usuario.Clave = claveTextBox.Text;
            usuario.Habilitado = habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            UsrLog.Save(usuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (FormMode)
            {

                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        Entity = new Usuario();
                        Entity.ID = SelectedID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        formPanel.Visible = false;
                    }
                    break;
                case FormModes.Alta:
                    if (Page.IsValid)
                    {
                        Entity = new Usuario();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        formPanel.Visible = false;
                    }
                    break;
                default:
                    break;
            }

            //formPanel.Visible = false;
        }

        private void EnableForm(bool condicion)

        {
            idPersonaTextBox.Enabled = condicion;
            nombreUsuarioTextBox.Enabled = condicion;
            claveTextBox.Enabled = condicion;
            claveLabel.Enabled = condicion;
            repetirClaveTextBox.Enabled = condicion;
            repetirClaveLabel.Enabled = condicion;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            UsrLog.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);

        }

        private void ClearForm()

        {
            idPersonaTextBox.Text = string.Empty;
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            habilitadoCheckBox.Checked = false;
            nombreUsuarioTextBox.Text = string.Empty;
            claveTextBox.Text = string.Empty;
            repetirClaveTextBox.Text = string.Empty;
        }
        //hacer el punto 42
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            formPanel.Visible = false;
        }


        protected void BuscarPersona_Click(object sender, EventArgs e)
        {
            Persona Per = PersLog.GetOne(int.Parse(idPersonaTextBox.Text));
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