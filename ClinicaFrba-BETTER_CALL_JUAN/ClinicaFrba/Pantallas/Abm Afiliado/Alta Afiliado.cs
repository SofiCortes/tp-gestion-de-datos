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
            this.dateTimePickerFechaNac.ResetText();
            this.comboBoxTipoDoc.SelectedIndex = 0;
            this.comboBoxEstadoCivil.SelectedIndex = 0;
            this.comboBoxSexo.SelectedIndex = 0;
            this.comboBoxPlanMedico.SelectedIndex = 0;
            this.dataGridFamiliares.DataSource = null;
            this.controller.clearFamiliares();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try {
                this.validateData();
                Paciente paciente = this.buildPaciente();
                this.controller.agregarAfiliado(paciente);
            }catch(Exception exc) {
                this.showErrorMessage(exc.Message);
            }
        }

        private Paciente buildPaciente()
        {
            Paciente nuevoPaciente = new Paciente();
            nuevoPaciente.nombre = this.textBoxNombre.Text;
            nuevoPaciente.apellido = this.textBoxApellido.Text;
            nuevoPaciente.nroDoc = Convert.ToDecimal(this.textBoxNroDoc.Text);
            nuevoPaciente.direccion = this.textBoxDireccion.Text;
            nuevoPaciente.mail = this.textBoxEmail.Text;
            nuevoPaciente.telefono = Convert.ToDecimal(this.textBoxTelefono.Text);
            nuevoPaciente.fechaNacimiento = this.dateTimePickerFechaNac.Value.Date;
            nuevoPaciente.tipoDoc = (string)this.comboBoxTipoDoc.SelectedItem;
            nuevoPaciente.estadoCivil = (string)this.comboBoxEstadoCivil.SelectedItem;
            nuevoPaciente.sexo = ((string)this.comboBoxSexo.SelectedItem).ElementAt(0);

            nuevoPaciente.planMedico = (PlanMedico)this.comboBoxPlanMedico.SelectedItem;

            return nuevoPaciente;
        }

        private void validateData()
        {
            StringBuilder stringErrorBuilder = new StringBuilder();

            if (this.textBoxNombre.Text.Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete el Nombre.\n");
            }

            if (this.textBoxApellido.Text.Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete el Apellido.\n");
            }

            if (this.textBoxNroDoc.Text.Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete el Numero de Documento.\n");
            }

            if (this.textBoxDireccion.Text.Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete la Direccion.\n");
            }

            if (this.textBoxTelefono.Text.Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete el Telefono.\n");
            }

            if (this.textBoxEmail.Text.Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete el Email.\n");
            }

            if (this.dateTimePickerFechaNac.Value.ToString().Trim().Length == 0)
            {
                stringErrorBuilder.Append("Complete la Fecha de Nacimiento.\n");
            }
            else
            {
                DateTime fechaNacimientoSeleccionada = this.dateTimePickerFechaNac.Value.Date;
                DateTime hoy = ArchivoConfig.getFechaDeHoy().Date;
                if (fechaNacimientoSeleccionada.CompareTo(hoy) >= 0)
                {
                    stringErrorBuilder.Append("La Fecha de Nacimiento debe ser anterior al dia actual.\n");
                }
            }

            if (this.comboBoxEstadoCivil.SelectedIndex == 0)
            {
                stringErrorBuilder.Append("Seleccione un Estado Civil.\n");
            }

            if (this.comboBoxSexo.SelectedIndex == 0)
            {
                stringErrorBuilder.Append("Seleccione un Sexo.\n");
            }

            if (this.comboBoxTipoDoc.SelectedIndex == 0)
            {
                stringErrorBuilder.Append("Seleccione un Tipo de Documento.\n");
            }

            if (this.comboBoxPlanMedico.SelectedIndex == 0)
            {
                stringErrorBuilder.Append("Seleccione un Plan Medico.\n");
            }

            if (stringErrorBuilder.ToString().Trim().Length > 0)
            {
                throw new Exception(stringErrorBuilder.ToString());
            }
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

        internal void showInformationMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Informacion",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal void agregarFamiliar(List<Paciente> pacientes)
        {
            dataGridFamiliares.DataSource = pacientes.Select(
                paciente => new
                {
                    Nombre = paciente.nombre,
                    Apellido = paciente.apellido,
                    TipoDocumento = paciente.tipoDoc,
                    NumeroDocumento = paciente.nroDoc
                }
            ).ToList();
        }

        private void familiares_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = dataGridFamiliares.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;
            Paciente paciente = new Paciente();
            paciente.tipoDoc = Convert.ToString(row.Cells[2].Value.ToString());
            paciente.nroDoc = Convert.ToDecimal(row.Cells[3].Value.ToString());
            this.controller.onFamiliarClicked(paciente);
        }

        internal string getTipoDocSeleccionado()
        {
            return (string)this.comboBoxTipoDoc.SelectedValue;
        }

        internal decimal getNroDocSeleccionado()
        {
            if (this.textBoxNroDoc.Text.Trim().Length > 0)
            {
                decimal nroDocSeleccionado = Convert.ToDecimal(this.textBoxNroDoc.Text.Trim());
                return nroDocSeleccionado;
            }
            return -1;
        }
    }
}
