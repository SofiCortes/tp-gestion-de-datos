namespace ClinicaFrba
{
    partial class ListadoBonos
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
            this.gridBonos = new System.Windows.Forms.DataGridView();
            this.BonoSeleccionadoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridBonos)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBonos
            // 
            this.gridBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBonos.Location = new System.Drawing.Point(12, 12);
            this.gridBonos.Name = "gridBonos";
            this.gridBonos.Size = new System.Drawing.Size(217, 230);
            this.gridBonos.TabIndex = 0;
            // 
            // BonoSeleccionadoButton
            // 
            this.BonoSeleccionadoButton.Location = new System.Drawing.Point(84, 253);
            this.BonoSeleccionadoButton.Name = "BonoSeleccionadoButton";
            this.BonoSeleccionadoButton.Size = new System.Drawing.Size(75, 23);
            this.BonoSeleccionadoButton.TabIndex = 2;
            this.BonoSeleccionadoButton.Text = "Seleccionar";
            this.BonoSeleccionadoButton.UseVisualStyleBackColor = true;
            this.BonoSeleccionadoButton.Click += new System.EventHandler(this.BonoSeleccionadoButton_Click);
            // 
            // ListadoBonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 288);
            this.Controls.Add(this.BonoSeleccionadoButton);
            this.Controls.Add(this.gridBonos);
            this.Name = "ListadoBonos";
            this.Text = "ListadoBonos";
            ((System.ComponentModel.ISupportInitialize)(this.gridBonos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBonos;
        private System.Windows.Forms.Button BonoSeleccionadoButton;
    }
}