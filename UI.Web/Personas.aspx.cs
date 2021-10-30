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
            if (!IsPostBack)
            {
                LoadGrid();

                //ShowButtons(false);
                //gridActionsPanel.Visible = true;
                
               
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
        }
        
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        
        public FormModes FormMode
        {
            get { return (FormModes)ViewState["FormMode"]; }
            set { ViewState["FormMode"] = value; }
        }
        
        private Business.Entities.Persona Entity
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

        protected void gridPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridPersonas.SelectedValue;
        }


        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            EnableForm(true);
            if (IsEntitySelected)
            {
                formPanel.Visible = true; //panel del form donde edito todo
                FormMode = FormModes.Modificacion;
                LoadForm(SelectedID);
            }
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            txtApellido.Text = Convert.ToString(Entity.Apellido);
            txtNombre.Text = Convert.ToString(Entity.Nombre);
            txtLegajo.Text = this.Entity.Legajo.ToString();
            txtDireccion.Text = this.Entity.Direccion;
            txtTelefono.Text = this.Entity.Telefono;
            txtEmail.Text = this.Entity.Email;
            txtDia.Text = this.Entity.FechaNacimiento.Day.ToString();
            txtMes.Text = this.Entity.FechaNacimiento.Month.ToString();
            txtAnio.Text = this.Entity.FechaNacimiento.Year.ToString();
            ddlTipoPersona.SelectedValue = this.Entity.TipoPersona;
            //ddlEspecialidades.SelectedValue = this.Entity.Plan.Especialidad.ID.ToString();
            // No ponemos el Plan ver si lo ponemos
        }
        private void EnableForm(bool condicion)
        { //cambiar text box
            this.lblApellido.Visible = condicion;
            this.txtApellido.Visible = condicion;
            this.lblNombre.Visible = condicion;
            this.txtNombre.Visible = condicion;
            this.lblLegajo.Visible = condicion;
            this.txtLegajo.Visible = condicion;
            this.lblDireccion.Visible = condicion;
            this.txtDireccion.Visible = condicion;
            this.lblTelefono.Visible = condicion;
            this.txtTelefono.Visible = condicion;
            this.lblEmail.Visible = condicion;
            this.txtEmail.Visible = condicion;
            this.lblFechaNacimiento.Visible = condicion;
            this.txtDia.Visible = condicion;
            this.txtMes.Visible = condicion;
            this.txtAnio.Visible = condicion;
            this.lblTipoPersona.Visible = condicion;
            this.ddlTipoPersona.Visible = condicion;
            //this.lblEspecialidad.Visible = condicion;
            //this.ddlEspecialidades.Visible = condicion;
            //this.lblPlan.Visible = condicion; // se va?
            //this.ddlPlanes.Visible = condicion;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(SelectedID);
                this.ShowButtons(false);
            }
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
            txtNombre.Text = string.Empty;
            txtLegajo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDia.Text = string.Empty;
            txtMes.Text = string.Empty;
            txtAnio.Text = string.Empty;
            ddlTipoPersona.SelectedValue = string.Empty;
            //ddlEspecialidades.SelectedValue = string.Empty;
        }

   

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entity = this.Logic.GetOne(this.SelectedID);
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.ClearSession();
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Business.Entities.Persona();
                    this.LoadEntity(this.Entity);
                    if (!Logic.Existe(Entity.Legajo))
                    {
                        this.SaveEntity(Entity);
                    }
                    else
                        Response.Write("<script>window.alert('El Legajo ingresado pertenece a una persona ya existente.');</script>");
                    this.LoadGrid();
                    this.ClearSession();
                    break;
            }
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }

        private void LoadEntity(Business.Entities.Persona pers)
        {
            pers.Apellido = this.txtApellido.Text;
            pers.Nombre = this.txtNombre.Text;
            pers.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            pers.Direccion = this.txtDireccion.Text;
            pers.Telefono = this.txtTelefono.Text;
            pers.Email = this.txtEmail.Text;
            pers.FechaNacimiento = new DateTime(Convert.ToInt32(txtAnio.Text), Convert.ToInt32(txtMes.Text), Convert.ToInt32(txtDia.Text));
            pers.TipoPersona = this.ddlTipoPersona.SelectedValue;
            //pers.Plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue); // se va?
            //pers.Plan.ID = Convert.ToInt32(this.ddlPlanes.SelectedValue);
        }

        private void SaveEntity(Business.Entities.Persona pers)
        {
            try
            {
                this.Logic.Save(pers);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        private void ShowButtons(bool condicion)
        {
            this.eliminarLinkButton.Visible = condicion;
            this.editarLinkButton.Visible = condicion;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }


        //PLANES Y ESPECIALIDADES
       
    }
}
