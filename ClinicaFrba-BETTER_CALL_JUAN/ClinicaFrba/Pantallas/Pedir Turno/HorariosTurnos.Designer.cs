namespace ClinicaFrba
{
    partial class HorariosTurnos
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
            this.HorariosDisponibles = new System.Windows.Forms.DataGridView();
            this.HorarioSeleccionadoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HorariosDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // HorariosDisponibles
            // 
            this.HorariosDisponibles.AllowUserToAddRows = false;
            this.HorariosDisponibles.AllowUserToDeleteRows = false;
            this.HorariosDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HorariosDisponibles.Location = new System.Drawing.Point(12, 12);
            this.HorariosDisponibles.Name = "HorariosDisponibles";
            this.HorariosDisponibles.ReadOnly = true;
            this.HorariosDisponibles.Size = new System.Drawing.Size(260, 207);
            this.HorariosDisponibles.TabIndex = 0;
            // 
            // HorarioSeleccionadoButton
            // 
            this.HorarioSeleccionadoButton.Location = new System.Drawing.Point(102, 227);
            this.HorarioSeleccionadoButton.Name = "HorarioSeleccionadoButton";
            this.HorarioSeleccionadoButton.Size = new System.Drawing.Size(75, 23);
            this.HorarioSeleccionadoButton.TabIndex = 2;
            this.HorarioSeleccionadoButton.Text = "Seleccionar";
            this.HorarioSeleccionadoButton.UseVisualStyleBackColor = true;
            this.HorarioSeleccionadoButton.Click += new System.EventHandler(this.HorarioSeleccionadoButton_Click);
            // 
            // HorariosTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.HorarioSeleccionadoButton);
            this.Controls.Add(this.HorariosDisponibles);
            this.Name = "HorariosTurnos";
            this.Text = "HorariosTurnos";
            ((System.ComponentModel.ISupportInitialize)(this.HorariosDisponibles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView HorariosDisponibles;
        private System.Windows.Forms.Button HorarioSeleccionadoButton;
    }
}