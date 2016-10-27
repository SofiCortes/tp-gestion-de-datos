namespace ClinicaFrba
{
    partial class AltaRol
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
            this.nombreRolLabel = new System.Windows.Forms.Label();
            this.RolNameTextBox = new System.Windows.Forms.TextBox();
            this.agregarRolButton = new System.Windows.Forms.Button();
            this.funcPanel = new System.Windows.Forms.Panel();
            this.labelFuncionalidades = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nombreRolLabel
            // 
            this.nombreRolLabel.AutoSize = true;
            this.nombreRolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreRolLabel.Location = new System.Drawing.Point(12, 18);
            this.nombreRolLabel.Name = "nombreRolLabel";
            this.nombreRolLabel.Size = new System.Drawing.Size(47, 13);
            this.nombreRolLabel.TabIndex = 0;
            this.nombreRolLabel.Text = "Nombre:";
            // 
            // RolNameTextBox
            // 
            this.RolNameTextBox.Location = new System.Drawing.Point(65, 15);
            this.RolNameTextBox.Name = "RolNameTextBox";
            this.RolNameTextBox.Size = new System.Drawing.Size(179, 20);
            this.RolNameTextBox.TabIndex = 1;
            // 
            // agregarRolButton
            // 
            this.agregarRolButton.Location = new System.Drawing.Point(99, 298);
            this.agregarRolButton.Name = "agregarRolButton";
            this.agregarRolButton.Size = new System.Drawing.Size(75, 23);
            this.agregarRolButton.TabIndex = 5;
            this.agregarRolButton.Text = "Agregar";
            this.agregarRolButton.UseVisualStyleBackColor = true;
            this.agregarRolButton.Click += new System.EventHandler(this.agregarRolButton_Click);
            // 
            // funcPanel
            // 
            this.funcPanel.AutoScroll = true;
            this.funcPanel.Location = new System.Drawing.Point(15, 61);
            this.funcPanel.Name = "funcPanel";
            this.funcPanel.Size = new System.Drawing.Size(240, 231);
            this.funcPanel.TabIndex = 6;
            // 
            // labelFuncionalidades
            // 
            this.labelFuncionalidades.AutoSize = true;
            this.labelFuncionalidades.Location = new System.Drawing.Point(18, 42);
            this.labelFuncionalidades.Name = "labelFuncionalidades";
            this.labelFuncionalidades.Size = new System.Drawing.Size(87, 13);
            this.labelFuncionalidades.TabIndex = 7;
            this.labelFuncionalidades.Text = "Funcionalidades:";
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 331);
            this.Controls.Add(this.labelFuncionalidades);
            this.Controls.Add(this.funcPanel);
            this.Controls.Add(this.agregarRolButton);
            this.Controls.Add(this.RolNameTextBox);
            this.Controls.Add(this.nombreRolLabel);
            this.Name = "AltaRol";
            this.Text = "Agregar rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nombreRolLabel;
        private System.Windows.Forms.TextBox RolNameTextBox;
        private System.Windows.Forms.Button agregarRolButton;
        private System.Windows.Forms.Panel funcPanel;
        private System.Windows.Forms.Label labelFuncionalidades;

    }
}