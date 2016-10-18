﻿namespace ClinicaFrba.AbmRol
{
    partial class Roles
    {
        public static string ACTION_CODE_FOR_LIST_MODIFY_ROL = "ACTION_CODE_FOR_LIST_MODIFY_ROL";
        public static string ACTION_CODE_FOR_LIST_DELETE_ROL = "ACTION_CODE_FOR_LIST_DELETE_ROL";
        public static string ACTION_CODE_FOR_LIST_LIST_ROL = "ACTION_CODE_FOR_LIST_LIST_ROL";

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
            this.resultadosRolesGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarButton = new System.Windows.Forms.Button();
            this.nombreColumnGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitadoColumnGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosRolesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // resultadosRolesGrid
            // 
            this.resultadosRolesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadosRolesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreColumnGrid,
            this.habilitadoColumnGrid});
            this.resultadosRolesGrid.Location = new System.Drawing.Point(13, 134);
            this.resultadosRolesGrid.Name = "resultadosRolesGrid";
            this.resultadosRolesGrid.Size = new System.Drawing.Size(243, 210);
            this.resultadosRolesGrid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre rol";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(90, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 1;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarButton.Location = new System.Drawing.Point(13, 80);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 30);
            this.limpiarButton.TabIndex = 2;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // buscarButton
            // 
            this.buscarButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarButton.Location = new System.Drawing.Point(181, 80);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(75, 30);
            this.buscarButton.TabIndex = 3;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            // 
            // nombreColumnGrid
            // 
            this.nombreColumnGrid.HeaderText = "Nombre";
            this.nombreColumnGrid.Name = "nombreColumnGrid";
            this.nombreColumnGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // habilitadoColumnGrid
            // 
            this.habilitadoColumnGrid.HeaderText = "Habilitado";
            this.habilitadoColumnGrid.Name = "habilitadoColumnGrid";
            this.habilitadoColumnGrid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // Roles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 356);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.resultadosRolesGrid);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Roles";
            this.Text = "Roles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosRolesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView resultadosRolesGrid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreColumnGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitadoColumnGrid;

        public string actionCode { get; set; }
    }
}