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
using System.Data.SqlClient;




namespace UI.Desktop
{
    public partial class Materias : ApplicationForm
    {
        public Materias()
        {
            InitializeComponent();

        }


        protected SqlDataAdapter _daMaterias;

        public SqlDataAdapter daMaterias
        {
            get { return _daMaterias; }
            set { _daMaterias = value; }
        }

        protected SqlConnection _conn;

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }



        public void Listar()
        {
            MateriaLogic mat = new MateriaLogic();
            this.dgvMaterias.DataSource = mat.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMateria.ShowDialog();
            this.Listar();
        }
    }
}
