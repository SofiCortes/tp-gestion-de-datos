namespace ClinicaFrba
{
    partial class ComprarBono
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
            this.labelPlanMedico = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownBonos = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.labelPrecioBono = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBonos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Su Plan Medico es:";
            // 
            // labelPlanMedico
            // 
            this.labelPlanMedico.AutoSize = true;
            this.labelPlanMedico.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlanMedico.Location = new System.Drawing.Point(12, 31);
            this.labelPlanMedico.Name = "labelPlanMedico";
            this.labelPlanMedico.Size = new System.Drawing.Size(0, 20);
            this.labelPlanMedico.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 46);
            this.label3.TabIndex = 2;
            this.label3.Text = "ATENCION: Los Bonos comprados solo podran ser utilizados para su Plan actual. Pue" +
    "den ser utilizados por cualquier integrante de su familia.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione la cantidad de Bonos que desea comprar";
            // 
            // numericUpDownBonos
            // 
            this.numericUpDownBonos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBonos.Location = new System.Drawing.Point(6, 43);
            this.numericUpDownBonos.Name = "numericUpDownBonos";
            this.numericUpDownBonos.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownBonos.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonComprar);
            this.panel1.Controls.Add(this.numericUpDownBonos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(16, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 131);
            this.panel1.TabIndex = 5;
            this.panel1.Tag = "Compra";
            // 
            // buttonComprar
            // 
            this.buttonComprar.AutoSize = true;
            this.buttonComprar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonComprar.Location = new System.Drawing.Point(114, 92);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(77, 30);
            this.buttonComprar.TabIndex = 5;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelPrecioBono
            // 
            this.labelPrecioBono.AutoSize = true;
            this.labelPrecioBono.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrecioBono.Location = new System.Drawing.Point(12, 82);
            this.labelPrecioBono.Name = "labelPrecioBono";
            this.labelPrecioBono.Size = new System.Drawing.Size(0, 20);
            this.labelPrecioBono.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Precio del Bono:";
            // 
            // ComprarBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 339);
            this.Controls.Add(this.labelPrecioBono);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelPlanMedico);
            this.Controls.Add(this.label1);
            this.Name = "ComprarBono";
            this.Text = "Compra de bono";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBonos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPlanMedico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownBonos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonComprar;
        private System.Windows.Forms.Label labelPrecioBono;
        private System.Windows.Forms.Label label5;
    }
}