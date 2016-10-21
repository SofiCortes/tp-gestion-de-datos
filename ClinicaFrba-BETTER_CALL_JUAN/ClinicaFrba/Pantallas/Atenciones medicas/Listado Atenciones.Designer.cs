namespace ClinicaFrba
{
    partial class ListadoAtenciones
    {
        public static string ACTION_CODE_FOR_LIST_CANCELAR_ATENCION = "ACTION_CODE_FOR_LIST_CANCELAR_ATENCION";
        public static string ACTION_CODE_FOR_LIST_REGISTRAR_LLEGADA_ATENCION = "ACTION_CODE_FOR_LIST_REGISTRAR_LLEGADA_ATENCION";
        public static string ACTION_CODE_FOR_LIST_REGISTRAR_RESULTADO_CONSULTA = "ACTION_CODE_FOR_LIST_REGISTRAR_RESULTADO_CONSULTA";

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
            this.Text = "Listado de atenciones medicas";
        }

        #endregion

        public string actionCode { get; set; }
    }
}