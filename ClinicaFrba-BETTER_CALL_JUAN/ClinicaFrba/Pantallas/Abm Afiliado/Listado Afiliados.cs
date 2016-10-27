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
    public partial class ListadoAfiliados : Form
    {
        private ListadoAfiliadosController controller;

        public ListadoAfiliados()
        {
            this.controller = new ListadoAfiliadosController(this);
            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarListadoAfiliados();
            };
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarListaConPacientes(List<Paciente> pacientes)
        {
            this.afiliadosGrid.DataSource = pacientes.Select(
                paciente => new
                {
                    NumeroAfiliado = paciente.nroRaiz + "-" + paciente.nroPersonal,
                    NombreyApellido = paciente.apellido + ", " + paciente.nombre,
                    Plan = paciente.planMedicoCod
                }
            ).ToList();
        }
    }
}
