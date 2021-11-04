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
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Usuario)Session["UsuarioActual"]).Persona.TipoPersona != "Docente")
            {
                Response.Write("<script>window.alert('Página solo permitida para docentes');</script>");
                Page.Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
                
                ddlTipoPersona.DataBind();
                ddlIDPlan.DataBind();
            }

        }

        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            gridPersonas.DataSource = Logic.GetAll();
            gridPersonas.DataBind();
            ddlTipoPersona.DataBind();
            ddlIDPlan.DataBind();

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
        private Persona Entity
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
            SelectedID = (int)gridPersonas.SelectedValue;
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtApellido.Text = Entity.Apellido;
            txtDireccion.Text = Entity.Direccion;
            txtEmail.Text = Entity.Email;
            calFechaNac.SelectedDate = Entity.FechaNacimiento;
            ddlTipoPersona.SelectedValue = Entity.TipoPersona;
            ddlIDPlan.SelectedValue = Convert.ToString(Entity.IDPlan);
            txtLegajo.Text = Convert.ToString(Entity.Legajo);
            txtNombre.Text = Convert.ToString(Entity.Nombre);
            txtTelefono.Text = Convert.ToString(Entity.Telefono);
        }

        private void LoadEntity(Persona per)
        {
            per.Apellido = txtApellido.Text;
            per.Direccion = txtDireccion.Text;
            per.Email = txtEmail.Text;
            per.FechaNacimiento = calFechaNac.SelectedDate;
            per.IDPlan = int.Parse(ddlIDPlan.SelectedValue);
            per.Legajo = int.Parse(txtLegajo.Text);
            per.Nombre = txtNombre.Text;
            per.Telefono= txtTelefono.Text;
            per.TipoPersona = ddlTipoPersona.Text;
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

        private void SaveEntity(Persona per)
        {
            Logic.Save(per);
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
                        this.Entity = new Persona();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        formPanel.Visible = false;
                    }
                    break;
                case FormModes.Alta:
                    if (Page.IsValid)
                    {
                        this.Entity = new Persona();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        formPanel.Visible = false;
                    }
                    break;
                default:
                    break;
            }



        }

        private void EnableForm(bool condicion)

        {
            txtApellido.Enabled = condicion;
            txtDireccion.Enabled = condicion;
            txtEmail.Enabled = condicion;
            calFechaNac.Enabled = condicion;
            ddlTipoPersona.Enabled = condicion;
            ddlIDPlan.Enabled = condicion;
            txtLegajo.Enabled = condicion;
            txtNombre.Enabled = condicion;
            txtTelefono.Enabled = condicion;
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
            Logic.Delete(id);
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
            txtApellido.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            calFechaNac.SelectedDate = DateTime.Today;
            txtLegajo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }
        //hacer el punto 42
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            formPanel.Visible = false;
        }
    }
}