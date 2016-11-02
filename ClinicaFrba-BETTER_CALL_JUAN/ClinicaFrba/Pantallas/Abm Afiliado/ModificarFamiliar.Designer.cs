namespace ClinicaFrba
{
    partial class ModificarFamiliar
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
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.dateTimePickerFechaNac = new System.Windows.Forms.DateTimePicker();
            this.comboBoxEstadoCivil = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNroDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(17, 322);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 7;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click_1);
            // 
            // dateTimePickerFechaNac
            // 
            this.dateTimePickerFechaNac.Location = new System.Drawing.Point(97, 211);
            this.dateTimePickerFechaNac.Name = "dateTimePickerFechaNac";
            this.dateTimePickerFechaNac.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaNac.TabIndex = 22;
            // 
            // comboBoxEstadoCivil
            // 
            this.comboBoxEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstadoCivil.FormattingEnabled = true;
            this.comboBoxEstadoCivil.Location = new System.Drawing.Point(97, 268);
            this.comboBoxEstadoCivil.Name = "comboBoxEstadoCivil";
            this.comboBoxEstadoCivil.Size = new System.Drawing.Size(142, 21);
            this.comboBoxEstadoCivil.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Estado civil";
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Location = new System.Drawing.Point(97, 241);
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(142, 21);
            this.comboBoxSexo.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Sexo";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(6, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 27);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fecha de nacimiento";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(97, 179);
            this.textBoxEmail.MaxLength = 255;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(142, 20);
            this.textBoxEmail.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(97, 153);
            this.textBoxTelefono.MaxLength = 18;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(142, 20);
            this.textBoxTelefono.TabIndex = 11;
            this.textBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressNumericTextBox);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Telefono";
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(97, 127);
            this.textBoxDireccion.MaxLength = 255;
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.Size = new System.Drawing.Size(207, 20);
            this.textBoxDireccion.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Direccion";
            // 
            // textBoxNroDoc
            // 
            this.textBoxNroDoc.Location = new System.Drawing.Point(97, 101);
            this.textBoxNroDoc.MaxLength = 18;
            this.textBoxNroDoc.Name = "textBoxNroDoc";
            this.textBoxNroDoc.Size = new System.Drawing.Size(142, 20);
            this.textBoxNroDoc.TabIndex = 7;
            this.textBoxNroDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressNumericTextBox);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nro. Documento";
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(97, 74);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(142, 21);
            this.comboBoxTipoDoc.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo Documento";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(97, 48);
            this.textBoxApellido.MaxLength = 255;
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(142, 20);
            this.textBoxApellido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(97, 22);
            this.textBoxNombre.MaxLength = 255;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(142, 20);
            this.textBoxNombre.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(341, 322);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 8;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerFechaNac);
            this.groupBox1.Controls.Add(this.comboBoxEstadoCivil);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.comboBoxSexo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxTelefono);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxDireccion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxNroDoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxTipoDoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxApellido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 307);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Principales";
            // 
            // ModificarFamiliar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(433, 355);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarFamiliar";
            this.Text = "Modificar Familiar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNac;
        private System.Windows.Forms.ComboBox comboBoxEstadoCivil;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNroDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}