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
    public partial class Cursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            gridCursos.DataSource = Logic.GetAll();
            gridCursos.DataBind();

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
        private Curso Entity
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
            SelectedID = (int)gridCursos.SelectedValue;
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            AñoTextBox.Text = Convert.ToString(Entity.AnioCalendario);
            CupoTextBox.Text = Convert.ToString(Entity.Cupo);
            IDComisionTextBox.Text = Convert.ToString(Entity.IDComision);
            IDMateriaTextBox.Text = Convert.ToString(Entity.IDMateria);
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

        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = int.Parse(AñoTextBox.Text);
            curso.Cupo = int.Parse(CupoTextBox.Text);
            curso.IDComision = int.Parse(IDComisionTextBox.Text);
            curso.IDMateria = int.Parse(IDMateriaTextBox.Text);
        }

        private void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            lblMatInexistente.Visible = false;
            lblComisionInexistente.Visible = false;
            switch (FormMode)
            {
                case FormModes.Baja:
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    break;

                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        if (Logic.ExisteComision(int.Parse(IDComisionTextBox.Text)))
                        {
                            if (Logic.ExisteMateria(int.Parse(IDComisionTextBox.Text)))
                            {
                                Entity = new Curso();
                                Entity.ID = SelectedID;
                                Entity.State = BusinessEntity.States.Modified;
                                LoadEntity(Entity);
                                SaveEntity(Entity);
                                LoadGrid();
                            }
                            else
                            {
                                lblMatInexistente.Visible = true;
                            }
                        }
                        else
                        {
                            lblComisionInexistente.Visible = true;
                        }
                    }
                    break;
                case FormModes.Alta:
                    if (Page.IsValid)
                    {
                        if (Logic.ExisteComision(int.Parse(IDComisionTextBox.Text)))
                        {
                            if (Logic.ExisteMateria(int.Parse(IDComisionTextBox.Text)))
                            {
                                Entity = new Curso();
                                LoadEntity(Entity);
                                SaveEntity(Entity);
                                LoadGrid();
                            }
                            else
                            {
                                lblMatInexistente.Visible = true;
                            }
                        }
                        else
                        {
                            lblComisionInexistente.Visible = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            formPanel.Visible = false;
        }

        private void EnableForm(bool condicion)

        {
            AñoTextBox.Enabled = condicion;
            CupoTextBox.Enabled = condicion;
            IDComisionTextBox.Enabled = condicion;
            IDMateriaTextBox.Enabled = condicion;
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
            AñoTextBox.Text = string.Empty;
            CupoTextBox.Text = string.Empty;
            IDComisionTextBox.Text = string.Empty;
            IDMateriaTextBox.Text = string.Empty;
        }
        //hacer el punto 42
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            formPanel.Visible = false;
        }


    }
}