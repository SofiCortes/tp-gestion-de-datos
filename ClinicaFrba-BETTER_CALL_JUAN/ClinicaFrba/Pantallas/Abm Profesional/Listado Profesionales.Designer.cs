namespace ClinicaFrba
{
    partial class ListadoProfesionales
    {
        public static string ACTION_CODE_FOR_LIST_VIEW_AGENDA = "ACTION_CODE_FOR_LIST_VIEW_AGENDA";
        public static string ACTION_CODE_FOR_LIST_LIST = "ACTION_CODE_FOR_LIST_LIST";

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
            this.Text = "Listado de profesionales";
        }

        #endregion

        public string actionCode { get; set; }
    }
}