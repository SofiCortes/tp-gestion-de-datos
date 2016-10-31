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
    public partial class PedirTurnoForm : Form
    {
        private PedirTurnoController controller;

        public PedirTurnoForm()
        {
            this.controller = new PedirTurnoController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarComboEspecialidades();
                this.controller.llenarListadoProfesionales();
            };
        }

        internal void llenarComboEspecialidades(List<Especialidad> especialidades)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.codigo = -1;
            especialidadDummy.descripcion = "Seleccione Especialidad";
            especialidades.Insert(0, especialidadDummy);

            Especialidad especialidadTodas = new Especialidad();
            especialidadTodas.codigo = 0;
            especialidadTodas.descripcion = "Todas";
            especialidades.Insert(1, especialidadTodas);

            this.comboEspecialidad.DataSource = especialidades;
            this.comboEspecialidad.DisplayMember = "descripcion";
        }
    }
}
