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
    public partial class HorariosConsultas : Form
    {
        private HorariosConsultasController controller;
        private Medico medico;
        private Especialidad especialidad;
        private Turno turno;

        public HorariosConsultas()
        {
            InitializeComponent();
            this.controller = new HorariosConsultasController(this);
        }

        internal void showConsultas(Medico medico, Especialidad especialidad)
        {
            this.medico = medico;
            this.especialidad = especialidad;

            this.controller.buscarTurnosParaFechaActual(medico, especialidad);

            this.Show();

        }
        
        internal void llenarTablaConTurnos(List<Turno> turnos)
        {
            gridTurnos.DataSource = turnos.Select(
                turno => new
                {
                    Turno = turno.numero,
                    IDPaciente = turno.pacienteId,
                    NombreYApellido = turno.paciente.apellido + ", " + turno.paciente.nombre,
                    Hora = Convert.ToString(turno.fechaHora),
                }
            ).ToList();
        }     

       internal void showErrorMessage(string mensaje)
       {
           MessageBox.Show(mensaje, "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
       }

       private void TurnoSeleccionadoButton_Click(object sender, EventArgs e)
       {
           Turno turno = controller.obtenerTurno(gridTurnos);
           ListadoBonos listadoBonos = new ListadoBonos();
           listadoBonos.showBonos(turno);
           this.Close();     
       }

        
    }
}
