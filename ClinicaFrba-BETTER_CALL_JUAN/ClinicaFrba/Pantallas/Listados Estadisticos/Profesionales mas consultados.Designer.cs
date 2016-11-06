namespace ClinicaFrba
{
    partial class ProfesionalesMasConsultados
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
            this.buscarButton = new System.Windows.Forms.Button();
            this.resultadosTop5Grid = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboPlan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboMes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSemestre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboAnio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosTop5Grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buscarButton
            // 
            this.buscarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buscarButton.Location = new System.Drawing.Point(545, 132);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 30);
            this.buscarButton.TabIndex = 15;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click_1);
            // 
            // resultadosTop5Grid
            // 
            this.resultadosTop5Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadosTop5Grid.Location = new System.Drawing.Point(13, 187);
            this.resultadosTop5Grid.Name = "resultadosTop5Grid";
            this.resultadosTop5Grid.Size = new System.Drawing.Size(607, 210);
            this.resultadosTop5Grid.TabIndex = 13;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.limpiarButton.Location = new System.Drawing.Point(13, 132);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 30);
            this.limpiarButton.TabIndex = 14;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboPlan);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboMes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboSemestre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboAnio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(13, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 117);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // comboPlan
            // 
            this.comboPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPlan.FormattingEnabled = true;
            this.comboPlan.Location = new System.Drawing.Point(54, 74);
            this.comboPlan.Name = "comboPlan";
            this.comboPlan.Size = new System.Drawing.Size(191, 21);
            this.comboPlan.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Plan";
            // 
            // comboMes
            // 
            this.comboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboMes.FormattingEnabled = true;
            this.comboMes.Location = new System.Drawing.Point(480, 26);
            this.comboMes.Name = "comboMes";
            this.comboMes.Size = new System.Drawing.Size(121, 21);
            this.comboMes.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Mes";
            // 
            // comboSemestre
            // 
            this.comboSemestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemestre.FormattingEnabled = true;
            this.comboSemestre.Location = new System.Drawing.Point(264, 26);
            this.comboSemestre.Name = "comboSemestre";
            this.comboSemestre.Size = new System.Drawing.Size(139, 21);
            this.comboSemestre.TabIndex = 5;
            this.comboSemestre.SelectedIndexChanged += new System.EventHandler(this.comboSemestre_SelectedIndexChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Semestre";
            // 
            // comboAnio
            // 
            this.comboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnio.FormattingEnabled = true;
            this.comboAnio.Location = new System.Drawing.Point(54, 26);
            this.comboAnio.Name = "comboAnio";
            this.comboAnio.Size = new System.Drawing.Size(121, 21);
            this.comboAnio.TabIndex = 1;
            this.comboAnio.SelectedIndexChanged += new System.EventHandler(this.comboAnio_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Año";
            // 
            // ProfesionalesMasConsultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 410);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.resultadosTop5Grid);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ProfesionalesMasConsultados";
            this.Text = "Profesionales mas consultados";
            ((System.ComponentModel.ISupportInitialize)(this.resultadosTop5Grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridView resultadosTop5Grid;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboPlan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboMes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSemestre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboAnio;
        private System.Windows.Forms.Label label1;


    }
}