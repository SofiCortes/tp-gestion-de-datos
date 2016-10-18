using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pantalla_Principal
{
    public partial class Pantalla_Principal : Form
    {
        public Pantalla_Principal()
        {
            InitializeComponent();
        }

        private void buttonRoles_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
            hideShowGroupBox(groupBoxRoles, true);
        }

        private void buttonAfiliados_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, true);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonProfesionales_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, true);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonPlanes_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, true);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonBonos_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, true);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonTurnos_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, true);
        }

        private void buttonAtencionMedica_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxAtencionMedica, true);
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonListadoEstadistico_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxListadoEstadistico, true);
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void hideShowGroupBox(GroupBox groupBox, bool showOrHide)
        {
            groupBox.Visible = showOrHide;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
