namespace ClinicaFrba
{
    partial class ModificarRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.rolSeleccionado = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.funcPanel = new System.Windows.Forms.Panel();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rol seleccionado:";
            // 
            // rolSeleccionado
            // 
            this.rolSeleccionado.AutoSize = true;
            this.rolSeleccionado.Location = new System.Drawing.Point(106, 9);
            this.rolSeleccionado.Name = "rolSeleccionado";
            this.rolSeleccionado.Size = new System.Drawing.Size(35, 13);
            this.rolSeleccionado.TabIndex = 1;
            this.rolSeleccionado.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Funcionalidades:";
            // 
            // funcPanel
            // 
            this.funcPanel.AutoScroll = true;
            this.funcPanel.Location = new System.Drawing.Point(15, 49);
            this.funcPanel.Name = "funcPanel";
            this.funcPanel.Size = new System.Drawing.Size(262, 262);
            this.funcPanel.TabIndex = 7;
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(112, 321);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 8;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 352);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.funcPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rolSeleccionado);
            this.Controls.Add(this.label1);
            this.Name = "ModificarRol";
            this.Text = "Modificar un rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rolSeleccionado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel funcPanel;
        private System.Windows.Forms.Button buttonModificar;

    }
}