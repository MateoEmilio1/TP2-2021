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
    public partial class Inscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Usuario)Session["UsuarioActual"]).Persona.TipoPersona != "Alumno")
            {
                Response.Write("<script>window.alert('Página solo permitida para docente');</script>");
                Page.Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                LoadGrid();
                
                
            }

        }

        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }

        CursoLogic _clogic;
        private CursoLogic CLogic
        {
            get
            {
                if (_clogic == null)
                {
                    _clogic = new CursoLogic();
                }
                return _clogic;
            }
        }

        private void LoadGrid()
        {
            gridInscripciones.DataSource = Logic.GetAllUsuarioActual(((Usuario)Session["UsuarioActual"]).Persona.ID);
            gridInscripciones.DataBind();
            gridForm.DataSource = CLogic.GetAll();
            gridForm.DataBind();
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
        private AlumnoInscripcion Entity
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

        private int SelectedIDCurso
        {
            get
            {
                if (ViewState["SelectedIDCurso"] != null)
                {
                    return (int)ViewState["SelectedIDCurso"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                ViewState["SelectedIDCurso"] = value;

            }
        }



        private bool IsEntitySelected
        {
            get
            {
                return (SelectedID != 0);
            }
        }
        private bool IsCursoSelected
        {
            get
            {
                return (SelectedIDCurso != 0);
            }
        }
        //asd

        protected void gridInscripciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridInscripciones.SelectedValue;
        }

        protected void gridForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDCurso = (int)gridForm.SelectedValue;
        }

        private void LoadEntity(AlumnoInscripcion insc)
        {
            insc.State = BusinessEntity.States.New;
            insc.Condicion = "Inscripto";
            insc.Curso = CLogic.GetOne(SelectedIDCurso);
            insc.Persona = ((Usuario)Session["UsuarioActual"]).Persona;
        }
        
        private void CambioCupo(Curso curso, int i)
        {
            curso.State = BusinessEntity.States.Modified;
            curso.Cupo = curso.Cupo + i;
            CLogic.Save(curso);
        }

        private void SaveEntity(AlumnoInscripcion insc)
        {
            Logic.Save(insc);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

            switch (FormMode)
            {
                case FormModes.Baja:
                    Entity = new AlumnoInscripcion();
                    Entity.ID = SelectedID;
                    CambioCupo((Logic.GetOne(SelectedID).Curso), +1);
                    DeleteEntity(SelectedID);
                    LoadGrid();
                    formPanel.Visible = false;
                    formActionsPanel.Visible = false;
                    break;
                case FormModes.Alta:
                    
                    Entity = new AlumnoInscripcion();
                    LoadEntity(Entity);
                    CambioCupo(Entity.Curso, -1);
                    SaveEntity(Entity);
                    LoadGrid();
                    formPanel.Visible = false;
                    formActionsPanel.Visible = false;
                    break;
                default:
                    break;
            }



        }

        

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (IsEntitySelected)
            {
                formPanel.Visible = false;
                formActionsPanel.Visible = true;
                FormMode = FormModes.Baja;
            }
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = true;
            formActionsPanel.Visible = true;
            FormMode = FormModes.Alta;

        }

        
        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            formActionsPanel.Visible = false;
        }
    }
}