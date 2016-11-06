namespace ClinicaFrba
{
    partial class CancelarAtencionAdmin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxApellidoMedico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNombreMedico = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxApellidoPaciente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombrePaciente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeTurno = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxApellidoMedico);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxNombreMedico);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxApellidoPaciente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxNombrePaciente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimeTurno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 114);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // textBoxApellidoMedico
            // 
            this.textBoxApellidoMedico.Location = new System.Drawing.Point(338, 83);
            this.textBoxApellidoMedico.MaxLength = 255;
            this.textBoxApellidoMedico.Name = "textBoxApellidoMedico";
            this.textBoxApellidoMedico.Size = new System.Drawing.Size(105, 20);
            this.textBoxApellidoMedico.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Apellido medico";
            // 
            // textBoxNombreMedico
            // 
            this.textBoxNombreMedico.Location = new System.Drawing.Point(103, 83);
            this.textBoxNombreMedico.MaxLength = 255;
            this.textBoxNombreMedico.Name = "textBoxNombreMedico";
            this.textBoxNombreMedico.Size = new System.Drawing.Size(105, 20);
            this.textBoxNombreMedico.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre medico";
            // 
            // textBoxApellidoPaciente
            // 
            this.textBoxApellidoPaciente.Location = new System.Drawing.Point(338, 50);
            this.textBoxApellidoPaciente.MaxLength = 255;
            this.textBoxApellidoPaciente.Name = "textBoxApellidoPaciente";
            this.textBoxApellidoPaciente.Size = new System.Drawing.Size(105, 20);
            this.textBoxApellidoPaciente.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Apellido paciente";
            // 
            // textBoxNombrePaciente
            // 
            this.textBoxNombrePaciente.Location = new System.Drawing.Point(103, 50);
            this.textBoxNombrePaciente.MaxLength = 255;
            this.textBoxNombrePaciente.Name = "textBoxNombrePaciente";
            this.textBoxNombrePaciente.Size = new System.Drawing.Size(105, 20);
            this.textBoxNombrePaciente.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre paciente";
            // 
            // dateTimeTurno
            // 
            this.dateTimeTurno.Location = new System.Drawing.Point(94, 19);
            this.dateTimeTurno.Name = "dateTimeTurno";
            this.dateTimeTurno.Size = new System.Drawing.Size(200, 20);
            this.dateTimeTurno.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha de turno";
            // 
            // gridTurnos
            // 
            this.gridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTurnos.Location = new System.Drawing.Point(12, 179);
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.Size = new System.Drawing.Size(485, 150);
            this.gridTurnos.TabIndex = 7;
            this.gridTurnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTurnos_CellClick);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(422, 132);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 6;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(12, 132);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 5;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // CancelarAtencionAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 346);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gridTurnos);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Name = "CancelarAtencionAdmin";
            this.Text = "CancelarAtencionAdmin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxApellidoMedico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNombreMedico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxApellidoPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombrePaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridTurnos;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}