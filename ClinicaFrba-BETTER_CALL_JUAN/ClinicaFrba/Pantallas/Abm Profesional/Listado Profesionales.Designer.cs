namespace ClinicaFrba
{
    partial class ListadoProfesionales
    {
        public static string ACTION_CODE_FOR_LIST_VIEW_AGENDA = "ACTION_CODE_FOR_LIST_VIEW_AGENDA";
        public static string ACTION_CODE_FOR_LIST_LIST = "ACTION_CODE_FOR_LIST_LIST";

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
            this.comboTipoDoc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboEspecialidad = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buscarButton = new System.Windows.Forms.Button();
            this.resultadosGrid = new System.Windows.Forms.DataGridView();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboTipoDoc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboEspecialidad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxDocumento);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxApellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMatricula);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 190);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // comboTipoDoc
            // 
            this.comboTipoDoc.FormattingEnabled = true;
            this.comboTipoDoc.Location = new System.Drawing.Point(118, 63);
            this.comboTipoDoc.Name = "comboTipoDoc";
            this.comboTipoDoc.Size = new System.Drawing.Size(172, 25);
            this.comboTipoDoc.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tipo Documento";
            // 
            // comboEspecialidad
            // 
            this.comboEspecialidad.FormattingEnabled = true;
            this.comboEspecialidad.Location = new System.Drawing.Point(124, 148);
            this.comboEspecialidad.Name = "comboEspecialidad";
            this.comboEspecialidad.Size = new System.Drawing.Size(242, 25);
            this.comboEspecialidad.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Especialidad";
            // 
            // textBoxDocumento
            // 
            this.textBoxDocumento.Location = new System.Drawing.Point(413, 63);
            this.textBoxDocumento.Name = "textBoxDocumento";
            this.textBoxDocumento.Size = new System.Drawing.Size(140, 25);
            this.textBoxDocumento.TabIndex = 9;
            this.textBoxDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressNumericTextBox);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Documento";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(349, 105);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(140, 25);
            this.textBoxApellido.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Apellido";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(90, 105);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(140, 25);
            this.textBoxNombre.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxMatricula.Location = new System.Drawing.Point(90, 26);
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(140, 25);
            this.textBoxMatricula.TabIndex = 1;
            this.textBoxMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressNumericTextBox);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matricula";
            // 
            // buscarButton
            // 
            this.buscarButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarButton.Location = new System.Drawing.Point(532, 208);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 30);
            this.buscarButton.TabIndex = 11;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            this.buscarButton.Click += new System.EventHandler(this.buscarButton_Click);
            // 
            // resultadosGrid
            // 
            this.resultadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadosGrid.Location = new System.Drawing.Point(12, 262);
            this.resultadosGrid.Name = "resultadosGrid";
            this.resultadosGrid.Size = new System.Drawing.Size(595, 210);
            this.resultadosGrid.TabIndex = 9;
            this.resultadosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultadosGrid_CellContentClick);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarButton.Location = new System.Drawing.Point(12, 208);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 30);
            this.limpiarButton.TabIndex = 10;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // ListadoProfesionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.resultadosGrid);
            this.Controls.Add(this.limpiarButton);
            this.Name = "ListadoProfesionales";
            this.Text = "Listado de profesionales";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridView resultadosGrid;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.ComboBox comboEspecialidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboTipoDoc;
        private System.Windows.Forms.Label label6;

        public string actionCode { get; set; }
    }
}