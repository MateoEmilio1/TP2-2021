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
            this.LoadGrid();
            if (this.GridView.SelectedIndex == -1)
            {
                ShowButtons(false);
                gridActionsPanel.Visible = true;
            }
        }

        PersonaLogic _logic;

        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new PersonaLogic();
                return _logic;
            }
        }

        Persona _Entity;

        private Persona Entity
        {
            get
            {
                if (_Entity != null)
                    return _Entity;
                else
                    return null;
            }
            set
            {
                _Entity = value;
            }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                    return (int)this.ViewState["SelectedID"];
                else
                    return 0;
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

        private void LoadGrid()
        {
            try
            {
                this.GridView.DataSource = this.Logic.GetAll();
                this.GridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void ShowButtons(bool enable)
        {
            this.lbEliminar.Visible = enable;
            this.lbEditar.Visible = enable;
        }

        private void LoadDdlEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.ddlEspecialidades.DataSource = el.GetAll();
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Especialidad--";
            init.Value = "-1";
            this.ddlEspecialidades.Items.Add(init);
            this.ddlEspecialidades.SelectedValue = "-1";
        }

        private void LoadDdlPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = new List<Plan>();
            foreach (Plan p in pl.GetAll())
            {
                if (p.Especialidad.ID == Convert.ToInt32(this.ddlEspecialidades.SelectedValue))
                {
                    planes.Add(p);
                }
            }
            this.ddlPlanes.DataSource = planes;
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataValueField = "ID";
            this.ddlPlanes.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Plan--";
            init.Value = "-1";
            this.ddlPlanes.Items.Add(init);
            this.ddlPlanes.SelectedValue = "-1";
        }

        private void EnableForm(bool enable)
        {
            this.lblApellido.Visible = enable;
            this.txtApellido.Visible = enable;
            this.lblNombre.Visible = enable;
            this.txtNombre.Visible = enable;
            this.lblLegajo.Visible = enable;
            this.txtLegajo.Visible = enable;
            this.lblDireccion.Visible = enable;
            this.txtDireccion.Visible = enable;
            this.lblTelefono.Visible = enable;
            this.txtTelefono.Visible = enable;
            this.lblEmail.Visible = enable;
            this.txtEmail.Visible = enable;
            this.lblFechaNacimiento.Visible = enable;
            this.txtDia.Visible = enable;
            this.txtMes.Visible = enable;
            this.txtAnio.Visible = enable;
            this.lblTipoPersona.Visible = enable;
            this.ddlTipoPersona.Visible = enable;
            this.lblEspecialidad.Visible = enable;
            this.ddlEspecialidades.Visible = enable;
            this.lblPlan.Visible = enable;
            this.ddlPlanes.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtApellido.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtLegajo.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtDia.Text = "dd";
            this.txtMes.Text = "mm";
            this.txtAnio.Text = "aaaa";
            this.ddlPlanes.Items.Clear();
            this.GridView.SelectedIndex = -1;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Logic.Delete(id);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadForm(int id)
        {
            try
            {
                this.Entity = this.Logic.GetOne(id);
                this.txtApellido.Text = this.Entity.Apellido;
                this.txtNombre.Text = this.Entity.Nombre;
                this.txtLegajo.Text = this.Entity.Legajo.ToString();
                this.txtDireccion.Text = this.Entity.Direccion;
                this.txtTelefono.Text = this.Entity.Telefono;
                this.txtEmail.Text = this.Entity.Email;
                this.txtDia.Text = this.Entity.FechaNacimiento.Day.ToString();
                this.txtMes.Text = this.Entity.FechaNacimiento.Month.ToString();
                this.txtAnio.Text = this.Entity.FechaNacimiento.Year.ToString();
                this.ddlTipoPersona.SelectedValue = this.Entity.TipoPersona;
                this.ddlEspecialidades.SelectedValue = this.Entity.Plan.Especialidad.ID.ToString();
                this.LoadDdlPlanes();
                this.ddlPlanes.SelectedValue = this.Entity.Plan.ID.ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(Persona pers)
        {
            pers.Apellido = this.txtApellido.Text;
            pers.Nombre = this.txtNombre.Text;
            pers.Legajo = Convert.ToInt32(this.txtLegajo.Text);
            pers.Direccion = this.txtDireccion.Text;
            pers.Telefono = this.txtTelefono.Text;
            pers.Email = this.txtEmail.Text;
            pers.FechaNacimiento = new DateTime(Convert.ToInt32(txtAnio.Text), Convert.ToInt32(txtMes.Text), Convert.ToInt32(txtDia.Text));
            pers.TipoPersona = this.ddlTipoPersona.SelectedValue;
            pers.Plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue);
            pers.Plan.ID = Convert.ToInt32(this.ddlPlanes.SelectedValue);
        }

        private void SaveEntity(Persona pers)
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
            this.ShowButtons(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.LoadDdlEspecialidades();
                this.formPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedID);
                this.LoadGrid();
                this.ShowButtons(false);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadDdlEspecialidades();
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
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
                    this.Entity = new Persona();
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

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlPlanes();
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
        }
    }
}
}