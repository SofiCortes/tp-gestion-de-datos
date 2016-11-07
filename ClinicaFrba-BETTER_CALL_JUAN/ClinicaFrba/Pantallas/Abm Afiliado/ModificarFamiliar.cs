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
    public partial class ModificarFamiliar : Form
    {
        
        private List<string> tiposDocumentos = new List<string> { "Seleccionar...", "CI", "DNI", "LC", "LD" };
        private List<string> estadosCiviles = new List<string> { "Seleccionar...", "Soltero/a", "Casado/a", "Viudo/a", "Concubinato", "Divorciado/a" };
        private List<string> sexos = new List<string> { "Seleccionar...", "Femenino", "Masculino" };
        
        private ModificarFamiliarController controller;

        public ModificarFamiliar()
        {
            this.controller = new ModificarFamiliarController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
                this.completarCampos();
            };
        }

        private void completarCampos()
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
            this.comboBoxEstadoCivil.SelectedIndex = estadosCiviles.IndexOf(paciente.estadoCivil);
            this.comboBoxSexo.SelectedIndex = sexos.IndexOf(paciente.sexo.Equals('M') ? "Masculino" : "Femenino");
        }

        public void setModificarFamiliarListener(ModificarFamiliarListener listener)
        {
            this.controller.setModificarFamiliarListener(listener);
        }

        public void setPacienteAModificar(Paciente pacienteAModificar)
        {
            this.controller.setPacienteAModificar(pacienteAModificar);
        }

        private void llenarCombos()
        {
            this.comboBoxTipoDoc.DataSource = tiposDocumentos;
            this.comboBoxEstadoCivil.DataSource = estadosCiviles;
            this.comboBoxSexo.DataSource = sexos;
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
            nuevoPaciente.fechaNacimiento = this.dateTimePickerFechaNac.Value;
            nuevoPaciente.tipoDoc = (string)this.comboBoxTipoDoc.SelectedItem;
            nuevoPaciente.estadoCivil = (string)this.comboBoxEstadoCivil.SelectedItem;
            nuevoPaciente.sexo = ((string)this.comboBoxSexo.SelectedItem).ElementAt(0);

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
                DateTime fechaNacimientoSeleccionada = this.dateTimePickerFechaNac.Value;
                DateTime hoy = ConfiguracionApp.getInstance().fechaActual;
                if(fechaNacimientoSeleccionada.CompareTo(hoy) > 0) {
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

            if (stringErrorBuilder.ToString().Trim().Length > 0)
            {
                throw new Exception(stringErrorBuilder.ToString());
            }
        }

        internal void keyPressNumericTextBox(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonLimpiar_Click_1(object sender, EventArgs e)
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
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.validateData();
                Paciente paciente = this.buildPaciente();
                this.controller.modificarFamiliar(paciente);
            }
            catch (Exception exc)
            {
                this.showErrorMessage(exc.Message);
            }
        }
    }
}