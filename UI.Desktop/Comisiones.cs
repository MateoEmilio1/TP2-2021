using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class Comisiones : ApplicationForm
    {
        public Comisiones()
        {
            InitializeComponent();
        }


        protected SqlDataAdapter _daComisiones;

        public SqlDataAdapter daComisiones
        {
            get { return _daComisiones; }
            set { _daComisiones = value; }
        }

        protected SqlConnection _conn;

        public SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }




        public void Listar()
        {
            ComisionLogic com = new ComisionLogic();
            this.dgvComisiones.DataSource = com.GetAll();
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
            ComisionesDesktop formComi = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            formComi.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows != null)
            {

                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
                ComisionesDesktop formComi = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formComi.ShowDialog(); //muestro el formulario UsuarioDesktop
                this.Listar();

            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

            if (this.dgvComisiones.SelectedRows != null)
            {
                int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID; //error aca
                ComisionesDesktop formComi = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);
                formComi.ShowDialog();
                this.Listar();
            }



        }
    }
}
