using Business.Entities;
using Business.Logic;
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
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
      
        }

        public Materia MateriaActual { get; set; }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
           

        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHsSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.cmbPlan.SelectedValue = this.MateriaActual.IDPlan;
      

            if (Modo == ModoForm.Alta)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Modificacion)
            {
                btnAceptar.Text = "Guardar";
            }
            else if (Modo == ModoForm.Baja)
            {
                btnAceptar.Text = "Eliminar";
                txtID.Enabled = false;
                txtDescripcion.Enabled = false;
                txtHsSemanales.Enabled = false;
                txtHsTotales.Enabled = false;
                cmbPlan.Enabled = false;
            }
            else
            {
                btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos()
        {

            if (Modo == ModoForm.Alta)
            {
                Materia MatNueva = new Materia();

                MatNueva.Descripcion = this.txtDescripcion.Text.ToString();
                MatNueva.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MatNueva.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
                MatNueva.IDPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());

                MateriaActual = MatNueva;
                MateriaLogic nuevaMat = new MateriaLogic();
                nuevaMat.Save(MateriaActual);

            }

            else if (Modo == ModoForm.Modificacion)
            {

                MateriaActual.Descripcion = this.txtDescripcion.Text.ToString();
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
                MateriaActual.IDPlan = Convert.ToInt32(cmbPlan.SelectedValue.ToString());

                MateriaLogic nuevaMat = new MateriaLogic();
                nuevaMat.Update(MateriaActual);


            }
            else if (Modo == ModoForm.Baja)
            {
                MateriaActual.Descripcion = "";
                MateriaActual.HSSemanales = 0;
                MateriaActual.HSTotales = 0;
                MateriaActual.IDPlan = 0;
                MateriaLogic nuevaMat = new MateriaLogic();
                nuevaMat.Delete(MateriaActual.ID);
            }
            else
                btnAceptar.Text = "Aceptar";
        }


        public override void GuardarCambios()
        {
            this.MapearADatos();

        }



        public override bool Validar()
        {
            if (this.txtDescripcion.Text.ToString() != "" && this.txtHsSemanales.Text.ToString() != "" && this.txtHsTotales.Text.ToString() != "0" && this.cmbPlan.SelectedValue.ToString() != string.Empty && this.txtHsSemanales.Text.ToString() != "0" && this.txtHsTotales.Text.ToString() != "0")
            {
                return true;
            }
            else
            {
                this.Notificar("Error", "Los campos no pueden estar vacío o valer '0'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia registrada exitosamente", "Nueva Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Modificacion && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia modificada exitosamente", "Modificar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (Modo == ModoForm.Baja && this.Validar() == true)
            {
                this.GuardarCambios();
                MessageBox.Show("Materia eliminada correctamente", "Eliminar Materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
