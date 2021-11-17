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
    public partial class RegistroNotas : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            
            if (gridCursos.SelectedIndex == -1)
            {
                formPanel.Visible = false;
            }
            if (!IsPostBack)
            {
                LoadGrid();
                
                
            }

        }
        public void LoadGrid()
        {
            gridCursos.DataSource = CLogic.GetCursosDocente(((Usuario)Session["UsuarioActual"]).Persona.ID);
            gridCursos.DataBind();

            
        }

        private void LoadGridAlumnos()
        {
            //List<AlumnoInscripcion> alumnosInscriptos = Logic.AlumnosCurso(SelectedIDCurso);
            //gridAlumnos.DataSource = alumnosInscriptos;
            //gridAlumnos.DataBind();
            ObjectDataSource1.SelectParameters.Clear();//add this line
            ObjectDataSource1.SelectParameters.Add("id_curso", SelectedIDCurso.ToString());
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
        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
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

        protected void gridAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedID = (int)gridAlumnos.SelectedValue;
        }

        protected void gridCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIDCurso = (int)gridCursos.SelectedValue;
            LoadGridAlumnos();
            formPanel.Visible = true;
           
        }

    }
}