namespace ClinicaFrba
{
    partial class HorariosConsultas
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
            this.gridTurnos = new System.Windows.Forms.DataGridView();
            this.TurnoSeleccionadoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTurnos
            // 
            this.gridTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTurnos.Location = new System.Drawing.Point(12, 12);
            this.gridTurnos.Name = "gridTurnos";
            this.gridTurnos.Size = new System.Drawing.Size(484, 290);
            this.gridTurnos.TabIndex = 0;
            // 
            // TurnoSeleccionadoButton
            // 
            this.TurnoSeleccionadoButton.Location = new System.Drawing.Point(208, 318);
            this.TurnoSeleccionadoButton.Name = "TurnoSeleccionadoButton";
            this.TurnoSeleccionadoButton.Size = new System.Drawing.Size(75, 23);
            this.TurnoSeleccionadoButton.TabIndex = 2;
            this.TurnoSeleccionadoButton.Text = "Seleccionar";
            this.TurnoSeleccionadoButton.UseVisualStyleBackColor = true;
            this.TurnoSeleccionadoButton.Click += new System.EventHandler(this.TurnoSeleccionadoButton_Click);
            // 
            // HorariosConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 353);
            this.Controls.Add(this.TurnoSeleccionadoButton);
            this.Controls.Add(this.gridTurnos);
            this.Name = "HorariosConsultas";
            this.Text = "Horarios Consultas";
            ((System.ComponentModel.ISupportInitialize)(this.gridTurnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTurnos;
        private System.Windows.Forms.Button TurnoSeleccionadoButton;
    }
}