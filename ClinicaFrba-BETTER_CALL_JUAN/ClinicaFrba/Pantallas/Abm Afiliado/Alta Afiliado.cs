﻿using System;
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
    public partial class AltaAfiliado : Form
    {
        private List<string> tiposDocumentos = new List<string> { "Seleccionar...", "CI", "DNI", "LC", "LD" };
        private List<string> estadosCiviles = new List<string> { "Seleccionar...", "Soltero/a", "Casado/a", "Viudo/a", "Concubinato", "Divorciado/a" };
        private List<string> sexos = new List<string> { "Seleccionar...", "Femenino", "Masculino" };

        private AltaAfiliadoController controller;

        public AltaAfiliado()
        {
            this.controller = new AltaAfiliadoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
            };
        }

        private void llenarCombos()
        {
            this.controller.buscarPlanesParaCombo();
            this.comboBoxTipoDoc.DataSource = tiposDocumentos;
            this.comboBoxEstadoCivil.DataSource = estadosCiviles;
            this.comboBoxSexo.DataSource = sexos;
        }

        private void buttonFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void buttonAgregarFamiliar_Click(object sender, EventArgs e)
        {
            AgregarFamiliar form = new AgregarFamiliar();
            form.setAgregarFamiliarListener(this.controller);
            form.ShowDialog();
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
            this.comboBoxPlanMedico.SelectedIndex = 0;
            this.panelFamiliares.Controls.Clear();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

        }

        internal void llenarComboPlanesMedicos(List<PlanMedico> planesMedicos)
        {
            PlanMedico planMedicoDummy = new PlanMedico();
            planMedicoDummy.codigo = -1;
            planMedicoDummy.descripcion = "Seleccionar...";
            planesMedicos.Insert(0, planMedicoDummy);

            this.comboBoxPlanMedico.DataSource = planesMedicos;
            this.comboBoxPlanMedico.DisplayMember = "descripcion";
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void keyPressNumericTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

    }
}
