namespace ClinicaFrba
{
    partial class CancelarAtencionMedico
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
            this.radioButtonCancelarDia = new System.Windows.Forms.RadioButton();
            this.radioButtonCancelarPeriodo = new System.Windows.Forms.RadioButton();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.groupboxDia = new System.Windows.Forms.GroupBox();
            this.groupBoxRango = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.fechaDesde = new System.Windows.Forms.DateTimePicker();
            this.fechaHasta = new System.Windows.Forms.DateTimePicker();
            this.groupboxDia.SuspendLayout();
            this.groupBoxRango.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonCancelarDia
            // 
            this.radioButtonCancelarDia.AutoSize = true;
            this.radioButtonCancelarDia.Location = new System.Drawing.Point(13, 13);
            this.radioButtonCancelarDia.Name = "radioButtonCancelarDia";
            this.radioButtonCancelarDia.Size = new System.Drawing.Size(99, 17);
            this.radioButtonCancelarDia.TabIndex = 0;
            this.radioButtonCancelarDia.TabStop = true;
            this.radioButtonCancelarDia.Text = "Cancelar un dia";
            this.radioButtonCancelarDia.UseVisualStyleBackColor = true;
            this.radioButtonCancelarDia.CheckedChanged += new System.EventHandler(this.radioButtonCancelarDia_CheckedChanged);
            // 
            // radioButtonCancelarPeriodo
            // 
            this.radioButtonCancelarPeriodo.AutoSize = true;
            this.radioButtonCancelarPeriodo.Location = new System.Drawing.Point(13, 37);
            this.radioButtonCancelarPeriodo.Name = "radioButtonCancelarPeriodo";
            this.radioButtonCancelarPeriodo.Size = new System.Drawing.Size(120, 17);
            this.radioButtonCancelarPeriodo.TabIndex = 1;
            this.radioButtonCancelarPeriodo.TabStop = true;
            this.radioButtonCancelarPeriodo.Text = "Cancelar un periodo";
            this.radioButtonCancelarPeriodo.UseVisualStyleBackColor = true;
            this.radioButtonCancelarPeriodo.CheckedChanged += new System.EventHandler(this.radioButtonCancelarPeriodo_CheckedChanged);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(138, 172);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 2;
            this.buttonCancelar.Text = "Cancelar turnos";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // groupboxDia
            // 
            this.groupboxDia.Controls.Add(this.fecha);
            this.groupboxDia.Controls.Add(this.label1);
            this.groupboxDia.Location = new System.Drawing.Point(13, 72);
            this.groupboxDia.Name = "groupboxDia";
            this.groupboxDia.Size = new System.Drawing.Size(337, 57);
            this.groupboxDia.TabIndex = 3;
            this.groupboxDia.TabStop = false;
            this.groupboxDia.Text = "Cancelar dia";
            // 
            // groupBoxRango
            // 
            this.groupBoxRango.Controls.Add(this.fechaHasta);
            this.groupBoxRango.Controls.Add(this.fechaDesde);
            this.groupBoxRango.Controls.Add(this.label3);
            this.groupBoxRango.Controls.Add(this.label2);
            this.groupBoxRango.Location = new System.Drawing.Point(13, 72);
            this.groupBoxRango.Name = "groupBoxRango";
            this.groupBoxRango.Size = new System.Drawing.Size(337, 94);
            this.groupBoxRango.TabIndex = 4;
            this.groupBoxRango.TabStop = false;
            this.groupBoxRango.Text = "Cancelar Rango";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar dia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccionar dia desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Seleccionar dia hasta";
            // 
            // fecha
            // 
            this.fecha.Location = new System.Drawing.Point(93, 22);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(200, 20);
            this.fecha.TabIndex = 1;
            // 
            // fechaDesde
            // 
            this.fechaDesde.Location = new System.Drawing.Point(125, 27);
            this.fechaDesde.Name = "fechaDesde";
            this.fechaDesde.Size = new System.Drawing.Size(200, 20);
            this.fechaDesde.TabIndex = 2;
            // 
            // fechaHasta
            // 
            this.fechaHasta.Location = new System.Drawing.Point(125, 54);
            this.fechaHasta.Name = "fechaHasta";
            this.fechaHasta.Size = new System.Drawing.Size(200, 20);
            this.fechaHasta.TabIndex = 3;
            // 
            // CancelarAtencionMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 202);
            this.Controls.Add(this.groupBoxRango);
            this.Controls.Add(this.groupboxDia);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.radioButtonCancelarPeriodo);
            this.Controls.Add(this.radioButtonCancelarDia);
            this.Name = "CancelarAtencionMedico";
            this.Text = "CancelarAtencionMedico";
            this.groupboxDia.ResumeLayout(false);
            this.groupboxDia.PerformLayout();
            this.groupBoxRango.ResumeLayout(false);
            this.groupBoxRango.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonCancelarDia;
        private System.Windows.Forms.RadioButton radioButtonCancelarPeriodo;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.GroupBox groupboxDia;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxRango;
        private System.Windows.Forms.DateTimePicker fechaHasta;
        private System.Windows.Forms.DateTimePicker fechaDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}