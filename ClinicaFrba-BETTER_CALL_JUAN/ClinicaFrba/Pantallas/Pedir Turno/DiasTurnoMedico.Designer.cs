namespace ClinicaFrba
{
    partial class DiasTurnoMedico
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
            this.FechaSeleccionadaButton = new System.Windows.Forms.Button();
            this.FechasDisponibles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FechasDisponibles)).BeginInit();
            this.SuspendLayout();
            // 
            // FechaSeleccionadaButton
            // 
            this.FechaSeleccionadaButton.Location = new System.Drawing.Point(93, 197);
            this.FechaSeleccionadaButton.Name = "FechaSeleccionadaButton";
            this.FechaSeleccionadaButton.Size = new System.Drawing.Size(75, 23);
            this.FechaSeleccionadaButton.TabIndex = 1;
            this.FechaSeleccionadaButton.Text = "Seleccionar";
            this.FechaSeleccionadaButton.UseVisualStyleBackColor = true;
            this.FechaSeleccionadaButton.Click += new System.EventHandler(this.FechaSeleccionadaButton_Click);
            // 
            // FechasDisponibles
            // 
            this.FechasDisponibles.AllowUserToAddRows = false;
            this.FechasDisponibles.AllowUserToDeleteRows = false;
            this.FechasDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FechasDisponibles.Location = new System.Drawing.Point(7, 12);
            this.FechasDisponibles.Name = "FechasDisponibles";
            this.FechasDisponibles.ReadOnly = true;
            this.FechasDisponibles.Size = new System.Drawing.Size(240, 179);
            this.FechasDisponibles.TabIndex = 2;
            // 
            // DiasTurnoMedico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 233);
            this.Controls.Add(this.FechasDisponibles);
            this.Controls.Add(this.FechaSeleccionadaButton);
            this.Name = "DiasTurnoMedico";
            this.Text = "DiasTurnoMedico";
            ((System.ComponentModel.ISupportInitialize)(this.FechasDisponibles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FechaSeleccionadaButton;
        private System.Windows.Forms.DataGridView FechasDisponibles;


    }
}