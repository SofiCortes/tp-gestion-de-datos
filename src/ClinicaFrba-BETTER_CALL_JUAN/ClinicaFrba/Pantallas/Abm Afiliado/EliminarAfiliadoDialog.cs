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
    public partial class EliminarAfiliadoDialog : Form
    {
        private EliminarAfiliadoController controller;

        public EliminarAfiliadoDialog()
        {
            this.controller = new EliminarAfiliadoController(this);

            InitializeComponent();
        }

        internal void setPacienteAEliminar(Paciente paciente)
        {
            this.controller.setPacienteAEliminar(paciente);
        }

        private void buttonSi_Click(object sender, EventArgs e)
        {
            this.controller.eliminarAfiliado();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void showInformationDialog(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
