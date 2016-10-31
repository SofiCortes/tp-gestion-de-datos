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
    public partial class ComprarBono : Form
    {
        private ComprarBonoController controller;

        public ComprarBono()
        {
            this.controller = new ComprarBonoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.buscarPlanMedicoDelAfiliado();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDownBonos.Value > 0)
            {
                this.controller.comprarBonos(numericUpDownBonos.Value);
            }
            else
            {
                this.showErrorMessage("Seleccione un valor mayor a 0.");
            }
        }

        internal void showPlanMedico(string p)
        {
            this.labelPlanMedico.Text = p;
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void showInformationMessage(string p)
        {
            throw new NotImplementedException();
        }
    }
}
