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
    public partial class ModificarAfiliado : Form
    {
        private List<string> tiposDocumentos = new List<string> { "Seleccionar...", "CI", "DNI", "LC", "LD" };
        private List<string> estadosCiviles = new List<string> { "Seleccionar...", "Soltero/a", "Casado/a", "Viudo/a", "Concubinato", "Divorciado/a" };
        private List<string> sexos = new List<string> { "Seleccionar...", "Femenino", "Masculino" };

        private ModificarAfiliadoController controller;

        public ModificarAfiliado()
        {
            this.controller = new ModificarAfiliadoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
                this.completarCampos();
            };
        }

        public void completarCampos()
        {
            Paciente paciente = this.controller.getPacienteAModificar();
            this.textBoxNombre.Text = paciente.nombre;
            this.textBoxApellido.Text = paciente.apellido;
            this.textBoxNroDoc.Text = paciente.nroDoc.ToString();
            this.textBoxDireccion.Text = paciente.direccion;
            this.textBoxTelefono.Text = paciente.telefono.ToString();
            this.textBoxEmail.Text = paciente.mail;
            this.dateTimePickerFechaNac.Value = paciente.fechaNacimiento;
            this.comboBoxTipoDoc.SelectedIndex = tiposDocumentos.IndexOf(paciente.tipoDoc);

            if (paciente.estadoCivil == null || paciente.estadoCivil.Length == 0)
            {
                this.comboBoxEstadoCivil.SelectedIndex = 0;
            }
            else
            {
                this.comboBoxEstadoCivil.SelectedIndex = estadosCiviles.IndexOf(paciente.estadoCivil);
            }

            if(paciente.sexo.Equals('N'))
            {
                this.comboBoxSexo.SelectedIndex = 0;
            }
            else
            {
                this.comboBoxSexo.SelectedIndex = sexos.IndexOf(paciente.sexo.Equals('M') ? "Masculino" : "Femenino");
            }

            for (int i = 0; i < this.comboBoxPlanMedico.Items.Count; i++)
            {
                PlanMedico planMedico = (PlanMedico)this.comboBoxPlanMedico.Items[i];
                if (planMedico.codigo.Equals(paciente.planMedicoCod))
                {
                    this.comboBoxPlanMedico.SelectedIndex = i;
                    break;
                }
            }
        }

        public void setPacienteAModificar(Paciente pacienteAModificar)
        {
            this.controller.setPacienteAModificar(pacienteAModificar);
        }

        private void llenarCombos()
        {
            this.controller.buscarPlanesParaCombo();
            this.comboBoxTipoDoc.DataSource = tiposDocumentos;
            this.comboBoxEstadoCivil.DataSource = estadosCiviles;
            this.comboBoxSexo.DataSource = sexos;
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
        {
            this.textBoxNroDoc.Text = "";
            this.textBoxDireccion.Text = "";
            this.textBoxTelefono.Text = "";
            this.textBoxEmail.Text = "";
            this.comboBoxTipoDoc.SelectedIndex = 0;
            this.comboBoxEstadoCivil.SelectedIndex = 0;
            this.comboBoxSexo.SelectedIndex = 0;
            this.comboBoxPlanMedico.SelectedIndex = 0;
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.validateData();
                Paciente paciente = this.buildPaciente();
                this.controller.modificarAfiliado(paciente);
            }
            catch (Exception exc)
            {
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
            nuevoPaciente.planMedicoCod = nuevoPaciente.planMedico.codigo;

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
                DateTime hoy = ConfiguracionApp.getInstance().fechaActual.Date;
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
    }
}
