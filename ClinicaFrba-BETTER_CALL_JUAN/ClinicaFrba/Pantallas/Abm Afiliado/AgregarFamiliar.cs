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
    public partial class AgregarFamiliar : Form
    {
        private List<string> tiposDocumentos = new List<string> { "Seleccionar...", "CI", "DNI", "LC", "LD" };
        private List<string> estadosCiviles = new List<string> { "Seleccionar...", "Soltero/a", "Casado/a", "Viudo/a", "Concubinato", "Divorciado/a" };
        private List<string> sexos = new List<string> { "Seleccionar...", "Femenino", "Masculino" };
        
        private AgregarFamiliarController controller;

        public AgregarFamiliar()
        {
            this.controller = new AgregarFamiliarController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
            };
        }

        public void setAgregarFamiliarListener(AgregarFamiliarListener listener)
        {
            this.controller.setAgregarFamiliarListener(listener);
        }

        private void llenarCombos()
        {
            this.comboBoxTipoDoc.DataSource = tiposDocumentos;
            this.comboBoxEstadoCivil.DataSource = estadosCiviles;
            this.comboBoxSexo.DataSource = sexos;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.textBoxNombre.Text = "";
            this.textBoxApellido.Text = "";
            this.textBoxNroDoc.Text = "";
            this.textBoxDireccion.Text = "";
            this.textBoxTelefono.Text = "";
            this.textBoxEmail.Text = "";
            this.textBoxFechaNacimiento.Text = "";
            this.comboBoxTipoDoc.SelectedIndex = 0;
            this.comboBoxEstadoCivil.SelectedIndex = 0;
            this.comboBoxSexo.SelectedIndex = 0;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        private void buttonFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        internal void keyPressNumericTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
