using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class RegistrarResultadoConsultaController : IngresarSintomasYEnfermedadListener
    {
        private Medico medico;
        private RegistrarResultadoConsulta form;

        public RegistrarResultadoConsultaController(RegistrarResultadoConsulta form)
        {
            this.form = form;
        }

        internal void buscarConsultas(string nombre, string apellido, Especialidad especialidadMedica)
        {
            decimal codigo = especialidadMedica.codigo;
            decimal matricula = this.medico.matricula;
            AtencionMedicaManager atencionMedicaManager = new AtencionMedicaManager();
            List<Consulta> consultas = atencionMedicaManager.buscarConsultasConFiltros(nombre, apellido, codigo, matricula);

            if (consultas != null)
            {
                this.form.llenarTablaConConsultas(consultas);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al buscar las Consultas");
            }
        }

        internal void llenarComboEspecialidades()
        {
            ProfesionalManager profesionalManager = new ProfesionalManager();
            this.medico = profesionalManager.buscarPorUsuarioId(UsuarioConfiguracion.getInstance().getUsuarioId());

            if (this.medico != null)
            {
                List<Especialidad> especialidadesDelMedico = profesionalManager.buscarEspecialidadesMedico(this.medico);

                if (especialidadesDelMedico != null)
                {
                    this.form.llenarComboEspecialidades(especialidadesDelMedico);
                }
                else
                {
                    this.form.showErrorMessage("Ocurrio un error al obtener las Especialidades del Medico");
                    this.form.Close();
                }
            }
            else
            {
                this.form.showErrorMessage("Usted no es un medico y no puede registrar un resultado de atencion.");
                this.form.Close();
            }

        }

        public void onSintomasYEnfermadadesCompletadas(string sintomas, string enfermedades)
        {
            DataGridViewRow row = this.form.getConsultaSeleccionada();

            decimal idConsulta = Decimal.Parse(row.Cells[0].Value.ToString());

            AtencionMedicaManager atencionMedicaManager = new AtencionMedicaManager();
            bool registroConsulta = atencionMedicaManager.registrarConsulta(idConsulta, DateTime.Now, sintomas, enfermedades);

            if (registroConsulta)
            {
                this.form.showInformationMessage("La consulta fue registrada con exito");
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al registrar la consulta");
            }
        }
    }
}
