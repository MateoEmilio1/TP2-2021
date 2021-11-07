
namespace UI.Desktop
{
    partial class MateriaDesktop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MateriaDesktop));
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblHsSemanales = new System.Windows.Forms.Label();
            this.txtHsSemanales = new System.Windows.Forms.TextBox();
            this.lblHorasTotales = new System.Windows.Forms.Label();
            this.txtHsTotales = new System.Windows.Forms.TextBox();
            this.lblIdPlan = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.materiaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.materiaLogicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.materiaLogicBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.materiaLogicBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaLogicBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaLogicBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaLogicBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 39);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 13);
            this.lblID.TabIndex = 3;
            this.lblID.Text = "ID de Materia: ";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(114, 36);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(181, 20);
            this.txtID.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 76);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "Descripcion: ";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(114, 76);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(181, 74);
            this.txtDescripcion.TabIndex = 7;
            this.txtDescripcion.Text = "";
            // 
            // lblHsSemanales
            // 
            this.lblHsSemanales.AutoSize = true;
            this.lblHsSemanales.Location = new System.Drawing.Point(12, 167);
            this.lblHsSemanales.Name = "lblHsSemanales";
            this.lblHsSemanales.Size = new System.Drawing.Size(96, 13);
            this.lblHsSemanales.TabIndex = 8;
            this.lblHsSemanales.Text = "Horas Semanales: ";
            // 
            // txtHsSemanales
            // 
            this.txtHsSemanales.Location = new System.Drawing.Point(114, 164);
            this.txtHsSemanales.Name = "txtHsSemanales";
            this.txtHsSemanales.Size = new System.Drawing.Size(181, 20);
            this.txtHsSemanales.TabIndex = 9;
            // 
            // lblHorasTotales
            // 
            this.lblHorasTotales.AutoSize = true;
            this.lblHorasTotales.Location = new System.Drawing.Point(12, 205);
            this.lblHorasTotales.Name = "lblHorasTotales";
            this.lblHorasTotales.Size = new System.Drawing.Size(79, 13);
            this.lblHorasTotales.TabIndex = 10;
            this.lblHorasTotales.Text = "Horas Totales: ";
            // 
            // txtHsTotales
            // 
            this.txtHsTotales.Location = new System.Drawing.Point(114, 202);
            this.txtHsTotales.Name = "txtHsTotales";
            this.txtHsTotales.Size = new System.Drawing.Size(181, 20);
            this.txtHsTotales.TabIndex = 11;
            // 
            // lblIdPlan
            // 
            this.lblIdPlan.AutoSize = true;
            this.lblIdPlan.Location = new System.Drawing.Point(12, 237);
            this.lblIdPlan.Name = "lblIdPlan";
            this.lblIdPlan.Size = new System.Drawing.Size(48, 13);
            this.lblIdPlan.TabIndex = 12;
            this.lblIdPlan.Text = "ID Plan: ";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DataSource = this.materiaBindingSource;
            this.cmbPlan.DisplayMember = "IDPlan";
            this.cmbPlan.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(114, 234);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(181, 21);
            this.cmbPlan.TabIndex = 13;
            // 
            // materiaBindingSource
            // 
            this.materiaBindingSource.DataSource = typeof(Business.Entities.Materia);
            // 
            // planBindingSource
            // 
            this.planBindingSource.DataSource = typeof(Business.Entities.Plan);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(114, 272);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click_1);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(220, 272);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // materiaLogicBindingSource
            // 
            this.materiaLogicBindingSource.DataSource = typeof(Business.Logic.MateriaLogic);
            // 
            // materiaLogicBindingSource1
            // 
            this.materiaLogicBindingSource1.DataSource = typeof(Business.Logic.MateriaLogic);
            // 
            // materiaLogicBindingSource2
            // 
            this.materiaLogicBindingSource2.DataSource = typeof(Business.Logic.MateriaLogic);
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 321);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.lblIdPlan);
            this.Controls.Add(this.txtHsTotales);
            this.Controls.Add(this.lblHorasTotales);
            this.Controls.Add(this.txtHsSemanales);
            this.Controls.Add(this.lblHsSemanales);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MateriaDesktop";
            this.Text = "Materia";
            ((System.ComponentModel.ISupportInitialize)(this.materiaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaLogicBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaLogicBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materiaLogicBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Label lblHsSemanales;
        private System.Windows.Forms.TextBox txtHsSemanales;
        private System.Windows.Forms.Label lblHorasTotales;
        private System.Windows.Forms.TextBox txtHsTotales;
        private System.Windows.Forms.Label lblIdPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource materiaBindingSource;
        private System.Windows.Forms.BindingSource planBindingSource;
        private System.Windows.Forms.BindingSource materiaLogicBindingSource;
        private System.Windows.Forms.BindingSource materiaLogicBindingSource1;
        private System.Windows.Forms.BindingSource materiaLogicBindingSource2;
    }
}