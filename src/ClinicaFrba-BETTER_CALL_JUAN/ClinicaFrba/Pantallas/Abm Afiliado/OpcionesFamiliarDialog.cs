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
    public partial class OpcionesFamiliarDialog : Form
    {
        private OpcionesFamiliarController controller;

        public OpcionesFamiliarDialog()
        {
            this.controller = new OpcionesFamiliarController(this);

            InitializeComponent();
        }

        public void setPaciente(Paciente paciente)
        {
            this.controller.setPaciente(paciente);
        }

        public void setOpcionesFamiliarListener(OpcionesFamiliarListener listener)
        {
            this.controller.setOpcionesFamiliarListener(listener);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            this.controller.botonModificarSeleccionado();
            this.Close();
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            this.controller.botonEliminarSeleccionado();
            this.Close();
        }


    }
}
