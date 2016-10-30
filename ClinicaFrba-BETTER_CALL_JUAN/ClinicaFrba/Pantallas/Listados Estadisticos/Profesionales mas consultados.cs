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
    public partial class ProfesionalesMasConsultados : Form
    {
        private List<string> mesesPrimerSemestre = new List<string> { "Seleccione mes", "Todos", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio" };
        private List<string> mesesSegundoSemestre = new List<string> { "Seleccione mes", "Todos", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private List<string> semestres = new List<string> { "Seleccione semestre", "Primer semestre", "Segundo semestre" };

        private ProfesionalesMasConsultadosController controller;

        public ProfesionalesMasConsultados()
        {
            this.controller = new ProfesionalesMasConsultadosController(this);
            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
                this.controller.buscarPlanes();
            };
        }

        private void llenarCombos()
        {
            this.comboAnio.DataSource = new List<string> { "Seleccione anio", "2015", "2016" };
            this.comboSemestre.Enabled = false;
            this.comboMes.Enabled = false;
        }

        private void buscarButton_Click_1(object sender, EventArgs e)
        {
            string anioSeleccionado = (string)this.comboAnio.SelectedItem;
            string mesSeleccionado = (string)this.comboMes.SelectedItem;
            string semestreSeleccionado = (string)this.comboSemestre.SelectedItem;
            PlanMedico planMedicoSeleccionado = (PlanMedico)this.comboPlan.SelectedItem;

            if (anioSeleccionado.Equals("Seleccione anio") || semestreSeleccionado.Equals("Seleccione semestre") ||
                mesSeleccionado.Equals("Seleccione mes") || planMedicoSeleccionado.codigo == -1)
            {
                this.showErrorMessage("Seleccione los filtros correctamente");
            }
            else
            {
                this.buscarButton.Enabled = false;
                this.limpiarButton.Enabled = false;
                this.resultadosTop5Grid.DataSource = null;
                this.comboAnio.Enabled = false;
                this.comboSemestre.Enabled = false;
                this.comboMes.Enabled = false;
                this.comboPlan.Enabled = false;

                this.controller.buscarProfesionalesConFiltros(semestreSeleccionado, anioSeleccionado, mesSeleccionado, planMedicoSeleccionado);
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarButton_Click_1(object sender, EventArgs e)
        {
            this.comboAnio.SelectedItem = this.comboAnio.Items[0];
            this.comboSemestre.Enabled = false;
            this.comboMes.Enabled = false;
            this.comboPlan.SelectedItem = this.comboPlan.Items[0];
            this.resultadosTop5Grid.DataSource = null;
        }

        private void comboAnio_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboAnio.SelectedIndex > 0)
            {
                comboSemestre.Enabled = true;
                comboSemestre.DataSource = semestres;
            }
            else
            {
                comboSemestre.DataSource = null;
                comboMes.DataSource = null;
                comboSemestre.Enabled = false;
                comboMes.Enabled = false;
            }
        }

        private void comboSemestre_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboSemestre.SelectedIndex > 0)
            {
                comboMes.Enabled = true;
                if (comboSemestre.SelectedIndex == 1)
                {
                    comboMes.DataSource = mesesPrimerSemestre;
                }
                else if (comboSemestre.SelectedIndex == 2)
                {
                    comboMes.DataSource = mesesSegundoSemestre;
                }
            }
            else
            {
                comboMes.DataSource = null;
                comboMes.Enabled = false;
            }
        }

        internal void showListado(List<MedicoDAO> medicos)
        {
            this.buscarButton.Enabled = true;
            this.limpiarButton.Enabled = true;
            this.comboAnio.Enabled = true;
            this.comboSemestre.Enabled = true;
            this.comboMes.Enabled = true;
            this.comboPlan.Enabled = true;

            this.resultadosTop5Grid.DataSource = medicos.Select(
                medico => new
                {
                    Matricula = medico.medico.matricula,
                    NombreYApellido = medico.medico.apellido + ", " + medico.medico.nombre,
                    Consultas = medico.cantConsultas,
                    Especialidad = medico.especialidadMedico.descripcion
                }
            ).ToList();
        }

        internal void completarComboPlanes(List<PlanMedico> planes)
        {
            PlanMedico planDummy = new PlanMedico();
            planDummy.codigo = -1;
            planDummy.descripcion = "Seleccione plan medico";
            planes.Insert(0, planDummy);

            PlanMedico planTodos = new PlanMedico();
            planTodos.codigo = 0;
            planTodos.descripcion = "Todos";
            planes.Insert(1, planTodos);

            this.comboPlan.DataSource = planes;
            this.comboPlan.DisplayMember = "descripcion";
        }
    }
}
