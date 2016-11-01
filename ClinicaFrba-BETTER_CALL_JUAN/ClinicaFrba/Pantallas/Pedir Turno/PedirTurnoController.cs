using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class PedirTurnoController
    {

        private PedirTurnoForm form;

        public PedirTurnoController(PedirTurnoForm form)
        {
            this.form = form;
        }

        internal void llenarComboEspecialidades()
        {
            EspecialidadMedicaManager especialidadMedicaManager = new EspecialidadMedicaManager();
            List<Especialidad> especialidades = especialidadMedicaManager.findAll();

            if (especialidades != null)
            {
                this.form.llenarComboEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener las Especialidades.");
            }
        }



        internal void buscarProfesionalesConFiltros(string queryNombre, string queryApellido, Especialidad especialidadSeleccionada)
        {
            ProfesionalManager profesionalManager = new ProfesionalManager();
            Dictionary<Medico,Especialidad> medicosFiltrados = profesionalManager.buscarMedicosConSuEspecialidad(queryNombre, queryApellido, especialidadSeleccionada.codigo);

            if (medicosFiltrados != null)
            {
                this.form.llenarListadoProfesionalesConEspecialidad(medicosFiltrados);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los Profesionales.");
            }
        }

        internal Medico obtenerMedico(System.Windows.Forms.DataGridView medicosEspecialidadParaTurnoGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = medicosEspecialidadParaTurnoGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;
            Medico medico = new Medico();
            medico.matricula = Decimal.Parse(row.Cells[0].Value.ToString());
            medico.apellido = row.Cells[1].Value.ToString();
            medico.nombre = row.Cells[2].Value.ToString(); 
            return medico;
        }



        internal string obtenerDescripcionEspecialidad(System.Windows.Forms.DataGridView medicosEspecialidadParaTurnoGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = medicosEspecialidadParaTurnoGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;
            
            return row.Cells[3].Value.ToString();
        }

        internal decimal obtenerCodigoEspecialidad(DataGridView medicosEspecialidadParaTurnoGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = medicosEspecialidadParaTurnoGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;

            return decimal.Parse(row.Cells[4].Value.ToString());
        }
    }
}
