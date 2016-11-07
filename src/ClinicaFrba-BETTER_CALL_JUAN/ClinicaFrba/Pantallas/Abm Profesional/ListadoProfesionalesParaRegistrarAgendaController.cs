using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class ListadoProfesionalesParaRegistrarAgendaController
    {
        private ListadoProfesionalesParaRegistrarAgenda form;

        public ListadoProfesionalesParaRegistrarAgendaController(ListadoProfesionalesParaRegistrarAgenda form)
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
            List<Medico> medicosFiltrados = profesionalManager.buscarMedicosParaAgenda(queryNombre, queryApellido, especialidadSeleccionada.codigo);

            if (medicosFiltrados != null)
            {
                this.form.llenarListadoProfesionalesConEspecialidad(medicosFiltrados);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar los Profesionales.");
            }
        }

        internal Medico obtenerMedico(System.Windows.Forms.DataGridView medicosEspecialidadParaAgendaGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = medicosEspecialidadParaAgendaGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;
            Medico medico = new Medico();
            medico.matricula = Decimal.Parse(row.Cells[0].Value.ToString());
            medico.apellido = row.Cells[1].Value.ToString();
            medico.nombre = row.Cells[2].Value.ToString();
            return medico;
        }


        internal string obtenerDescripcionEspecialidad(System.Windows.Forms.DataGridView medicosEspecialidadParaAgendaGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = medicosEspecialidadParaAgendaGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;

            return row.Cells[3].Value.ToString();
        }

        internal decimal obtenerCodigoEspecialidad(DataGridView medicosEspecialidadParaAgendaGrid)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = medicosEspecialidadParaAgendaGrid.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;

            return decimal.Parse(row.Cells[4].Value.ToString());
        }

        internal List<Especialidad> obtenerEspecialidadesMedico(Medico medico)
        {
            ProfesionalManager profesionalManager = new ProfesionalManager();
            List<Especialidad> especialidadesEncontradas = profesionalManager.buscarEspecialidadesMedico(medico);
            return especialidadesEncontradas;
        }
    }
}
