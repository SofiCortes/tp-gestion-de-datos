using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class IngresarSintomasYEnfermedadDialog : Form
    {
        private IngresarSintomasYEnfermedadController controller;

        public IngresarSintomasYEnfermedadDialog()
        {
            this.controller = new IngresarSintomasYEnfermedadController(this);

            InitializeComponent();
        }

        public void setIngresarSintomasYEnfermedadesListener(IngresarSintomasYEnfermedadListener listener)
        {
            this.controller.setIngresarSintomasyEnfermedadesListener(listener);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxSintomas.Text = "";
            this.textBoxDiagnostico.Text = "";
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            string sintomas = this.textBoxSintomas.Text.Trim();
            string diagnostico = this.textBoxDiagnostico.Text.Trim();
            if (sintomas.Length > 0 && diagnostico.Length > 0)
            {
                this.controller.sintomasYDiagnosticoCompletado(sintomas, diagnostico);
            }
            else
            {
                this.showErrorMessage("Complete los sintomas y el diagnostico");
            }
        }

        private void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
