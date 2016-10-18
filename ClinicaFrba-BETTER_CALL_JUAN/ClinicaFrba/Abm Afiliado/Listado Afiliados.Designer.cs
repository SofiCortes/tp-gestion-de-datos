using System.Windows.Forms;
namespace ClinicaFrba.Abm_Afiliado
{
    partial class ListadoAfiliados
    {
        public static string ACTION_CODE_FOR_LIST_MODIFY_AFILIADO = "ACTION_CODE_FOR_LIST_MODIFY_AFILIADO";
        public static string ACTION_CODE_FOR_LIST_DELETE_AFILIADO = "ACTION_CODE_FOR_LIST_DELETE_AFILIADO";
        public static string ACTION_CODE_FOR_LIST_LIST_AFILIADO = "ACTION_CODE_FOR_LIST_LIST_AFILIADO";

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultadosRolesGrid = new System.Windows.Forms.DataGridView();
            this.nombreColumnGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitadoColumnGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buscarButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosRolesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de busqueda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plan medico";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(167, 25);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre/Apellido";
            // 
            // resultadosRolesGrid
            // 
            this.resultadosRolesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultadosRolesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreColumnGrid,
            this.habilitadoColumnGrid,
            this.PlanMedico});
            this.resultadosRolesGrid.Location = new System.Drawing.Point(12, 183);
            this.resultadosRolesGrid.Name = "resultadosRolesGrid";
            this.resultadosRolesGrid.Size = new System.Drawing.Size(494, 210);
            this.resultadosRolesGrid.TabIndex = 5;
            this.resultadosRolesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            // 
            // nombreColumnGrid
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreColumnGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.nombreColumnGrid.HeaderText = "Numero Afiliado";
            this.nombreColumnGrid.Name = "nombreColumnGrid";
            // 
            // habilitadoColumnGrid
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.habilitadoColumnGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.habilitadoColumnGrid.HeaderText = "Nombre y Apellido";
            this.habilitadoColumnGrid.Name = "habilitadoColumnGrid";
            // 
            // PlanMedico
            // 
            this.PlanMedico.HeaderText = "PlanMedico";
            this.PlanMedico.Name = "PlanMedico";
            // 
            // buscarButton
            // 
            this.buscarButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarButton.Location = new System.Drawing.Point(371, 127);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(135, 30);
            this.buscarButton.TabIndex = 7;
            this.buscarButton.Text = "Buscar";
            this.buscarButton.UseVisualStyleBackColor = true;
            // 
            // limpiarButton
            // 
            this.limpiarButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarButton.Location = new System.Drawing.Point(12, 127);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(116, 30);
            this.limpiarButton.TabIndex = 6;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(144, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 25);
            this.comboBox1.TabIndex = 3;
            // 
            // ListadoAfiliados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.resultadosRolesGrid);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.limpiarButton);
            this.Name = "ListadoAfiliados";
            this.Text = "Listado de afiliados";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultadosRolesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView resultadosRolesGrid;
        private System.Windows.Forms.Button buscarButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreColumnGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn habilitadoColumnGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanMedico;
        private System.Windows.Forms.ComboBox comboBox1;

        public string actionCode { get; set; }

    }
}