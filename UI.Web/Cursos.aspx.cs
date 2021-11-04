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

        ComisionLogic _clogic;
        private ComisionLogic ComisionLogic
        {
            get
            {
                if (_clogic == null)
                {
                    _clogic = new ComisionLogic();
                }
                return _clogic;
            }
        }
        MateriaLogic _mlogic;
        private MateriaLogic MateriaLogic
        {
            get
            {
                if (_mlogic == null)
                {
                    _mlogic = new MateriaLogic();
                }
                return _mlogic;
            }
        }

        private void LoadGrid()
        {
            gridCursos.DataSource = Logic.GetAll();
            gridCursos.DataBind();
            IDComisionDDL.DataBind();
            IDMateriaDDL.DataBind();
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
            IDComisionDDL.SelectedValue = Entity.Comision.Descripcion;
            IDMateriaDDL.SelectedValue= Convert.ToString(Entity.Comision.ID);
            IDMateriaDDL.SelectedValue = Convert.ToString(Entity.Materia.ID);
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
            curso.Comision = ComisionLogic.GetOne(int.Parse(IDComisionDDL.SelectedValue));
            curso.Materia = MateriaLogic.GetOne(int.Parse(IDMateriaDDL.SelectedValue));
        }

        private void SaveEntity(Curso curso)
        {
            Logic.Save(curso);
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
                        this.Entity = new Curso();
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
                        this.Entity = new Curso();
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
            AñoTextBox.Enabled = condicion;
            CupoTextBox.Enabled = condicion;
            IDComisionDDL.Enabled = condicion;
            IDMateriaDDL.Enabled = condicion;
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
        }
        //hacer el punto 42
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            formPanel.Visible = false;
        }
    }
}