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
    public partial class MotivoCambioPlanDialog : Form
    {
        private MotivoCambioPlanController controller;

        public MotivoCambioPlanDialog()
        {
            this.controller = new MotivoCambioPlanController(this);

            InitializeComponent();
        }

        public void setMotivoCambioPlanListener(MotivoCambioPlanListener listener)
        {
            this.controller.setMotivoCambioPlanListener(listener);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxMotivo.Text = "";
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            string motivoCambioPlan = this.textBoxMotivo.Text;
            if (motivoCambioPlan != null && motivoCambioPlan.Trim().Length > 0)
            {
                this.controller.cambiarDePlan(motivoCambioPlan);
            }
            else
            {
                this.showErrorMessage("Complete el motivo de cambio de Plan");
            }
        }

        private void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        internal void setPacienteModificado(Paciente paciente)
        {
            this.controller.setPacienteModificado(paciente);
        }
    }
}
