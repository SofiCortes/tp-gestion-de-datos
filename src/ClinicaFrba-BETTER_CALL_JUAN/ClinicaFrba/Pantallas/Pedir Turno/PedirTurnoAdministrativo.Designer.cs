namespace ClinicaFrba
{
    partial class Pedir_Turno_Administrativo
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
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buscarButton = new System.Windows.Forms.Button();
            this.medicosEspecialidadParaTurnoGrid = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.labelNroAfiliado = new System.Windows.Forms.Label();
            this.nroAfiliado = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicosEspecialidadParaTurnoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroAfiliado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboEspecialidad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxApellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.groupBox1.Location = new System.Drawing.Point(22, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 109);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda de medico";
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Location = new System.Drawing.Point(99, 67);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(392, 23);
            this.comboEspecialidad.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Especialidad:";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(327, 24);
            this.textBoxApellido.MaxLength = 255;
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(164, 21);
            this.textBoxApellido.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellido:";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(75, 24);
            this.textBoxNombre.MaxLength = 255;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(169, 21);
            this.textBoxNombre.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre:";
            // 
            // buscarButton
            // 
            this.buscarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.buscarButton.Location = new System.Drawing.Point(451, 143);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 30);
            this.buscarButton.TabIndex = 19;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // medicosEspecialidadParaTurnoGrid
            // 
            this.medicosEspecialidadParaTurnoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.medicosEspecialidadParaTurnoGrid.Location = new System.Drawing.Point(22, 205);
            this.medicosEspecialidadParaTurnoGrid.Name = "medicosEspecialidadParaTurnoGrid";
            this.medicosEspecialidadParaTurnoGrid.Size = new System.Drawing.Size(504, 273);
            this.medicosEspecialidadParaTurnoGrid.TabIndex = 17;
            this.medicosEspecialidadParaTurnoGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.medicosEspecialidadParaTurnoGrid_CellClick);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.limpiarButton.Location = new System.Drawing.Point(349, 143);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 30);
            this.limpiarButton.TabIndex = 18;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click_1);
            // 
            // labelNroAfiliado
            // 
            this.labelNroAfiliado.AutoSize = true;
            this.labelNroAfiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.labelNroAfiliado.Location = new System.Drawing.Point(33, 150);
            this.labelNroAfiliado.Name = "labelNroAfiliado";
            this.labelNroAfiliado.Size = new System.Drawing.Size(99, 16);
            this.labelNroAfiliado.TabIndex = 20;
            this.labelNroAfiliado.Text = "Nro de afiliado:";
            // 
            // nroAfiliado
            // 
            this.nroAfiliado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.nroAfiliado.Location = new System.Drawing.Point(140, 150);
            this.nroAfiliado.Maximum = new decimal(new int[] {
            1241513983,
            370409800,
            542101,
            0});
            this.nroAfiliado.Name = "nroAfiliado";
            this.nroAfiliado.Size = new System.Drawing.Size(147, 21);
            this.nroAfiliado.TabIndex = 21;
            // 
            // Pedir_Turno_Administrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 497);
            this.Controls.Add(this.nroAfiliado);
            this.Controls.Add(this.labelNroAfiliado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.medicosEspecialidadParaTurnoGrid);
            this.Controls.Add(this.limpiarButton);
            this.Name = "Pedir_Turno_Administrativo";
            this.Text = "Pedir Turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicosEspecialidadParaTurnoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nroAfiliado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridView medicosEspecialidadParaTurnoGrid;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label labelNroAfiliado;
        private System.Windows.Forms.NumericUpDown nroAfiliado;
    }
}