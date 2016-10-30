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
    public partial class ProfesionalesConMenosHoras : Form
    {
        private List<string> mesesPrimerSemestre = new List<string> { "Seleccione mes", "Todos", "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio" };
        private List<string> mesesSegundoSemestre = new List<string> { "Seleccione mes", "Todos", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        private List<string> semestres = new List<string> { "Seleccione semestre", "Primer semestre", "Segundo semestre" };
        
        private ProfesionalesConMenosHorasController controller;

        public ProfesionalesConMenosHoras()
        {
            this.controller = new ProfesionalesConMenosHorasController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.llenarCombos();
                this.controller.buscarEspecialidades();
            };
        }

        private void llenarCombos()
        {
            this.comboAnio.DataSource = new List<string> { "Seleccione anio", "2015", "2016" };
            this.comboSemestre.Enabled = false;
            this.comboMes.Enabled = false;
        }

        private void buscarButton_Click(object sender, EventArgs e)
        {
            string anioSeleccionado = (string)this.comboAnio.SelectedItem;
            string mesSeleccionado = (string)this.comboMes.SelectedItem;
            string semestreSeleccionado = (string)this.comboSemestre.SelectedItem;
            Especialidad especialidadSeleccionada = (Especialidad)this.comboEspecialidad.SelectedItem;

            if (anioSeleccionado.Equals("Seleccione anio") || semestreSeleccionado.Equals("Seleccione semestre") ||
                mesSeleccionado.Equals("Seleccione mes") || especialidadSeleccionada.codigo == -1)
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
                this.comboEspecialidad.Enabled = false;

                this.controller.buscarProfesionalesConFiltros(semestreSeleccionado, anioSeleccionado, mesSeleccionado, especialidadSeleccionada);
            }
        }

        internal void showErrorMessage(string mensaje)
        {
           MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.comboAnio.SelectedItem = this.comboAnio.Items[0];
            this.comboSemestre.Enabled = false;
            this.comboMes.Enabled = false;
            this.comboEspecialidad.SelectedItem = this.comboEspecialidad.Items[0];
            this.resultadosTop5Grid.DataSource = null;
        }


        internal void completarComboEspecialidades(List<Especialidad> especialidades)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.codigo = -1;
            especialidadDummy.descripcion = "Seleccione especialidad";
            especialidades.Insert(0, especialidadDummy);

            Especialidad especialidadTodas = new Especialidad();
            especialidadTodas.codigo = 0;
            especialidadTodas.descripcion = "Todas";
            especialidades.Insert(1, especialidadTodas);

            this.comboEspecialidad.DataSource = especialidades;
            this.comboEspecialidad.DisplayMember = "descripcion";
        }

        private void comboAnio_SelectedIndexChanged(object sender, EventArgs e)
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

        private void comboSemestre_SelectedIndexChanged(object sender, EventArgs e)
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
            this.comboEspecialidad.Enabled = true;

            this.resultadosTop5Grid.DataSource = medicos.Select(
                medico => new
                {
                    Matricula = medico.medico.matricula,
                    NombreYApellido = medico.medico.apellido + ", " + medico.medico.nombre,
                    Horas = medico.cantHorasTrabajadas
                }
            ).ToList();
        }
        
    }
}
