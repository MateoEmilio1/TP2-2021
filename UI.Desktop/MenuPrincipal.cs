using Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class MenuPrincipal : ApplicationForm
    {
        public MenuPrincipal(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
        }

        public Usuario user { get; set; }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias();
            mat.ShowDialog();

        }

        

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones com = new Comisiones();
            com.ShowDialog();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteCursos rep = new ReporteCursos();
            rep.ShowDialog();
        }
    }
}
