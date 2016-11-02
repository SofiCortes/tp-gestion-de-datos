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
    public partial class AgendaProfesional : Form
    {
        private AgendaProfesionalController controller;

        public AgendaProfesional()
        {
            this.controller = new AgendaProfesionalController(this);

            InitializeComponent();

        }

        internal void showRegistroHorario(Medico medico, List<Especialidad> especialidades)
        {
            this.llenarComboEspecialidades(especialidades);
            this.Show();
        }

        private void llenarComboEspecialidades(List<Especialidad> especialidades)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.codigo = -1;
            especialidadDummy.descripcion = "Seleccione Especialidad";
            especialidades.Insert(0, especialidadDummy);

            this.comboEspecialidad.DataSource = especialidades;
            this.comboEspecialidad.DisplayMember = "descripcion";
        }
    }
}
