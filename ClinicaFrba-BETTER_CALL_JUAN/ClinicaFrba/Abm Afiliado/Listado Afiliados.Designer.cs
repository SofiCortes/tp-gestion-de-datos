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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion

        public string actionCode { get; set; }

    }
}