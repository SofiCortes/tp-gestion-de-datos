﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    public partial class DiasTurnoMedico : Form
    {
        private DiasTurnoMedicoController controller;
        private Medico medico;
        private Especialidad especialidad;
        private decimal paciente_id;

        public DiasTurnoMedico()
        {
            this.controller = new DiasTurnoMedicoController(this);
            
            InitializeComponent();
        }

        internal void showCalendario(decimal paciente_id,Medico medico, Especialidad especialidad)
        {
            this.paciente_id = paciente_id;
            this.medico = medico;
            this.especialidad = especialidad;

            this.controller.getFechasDisponibles(medico, especialidad);           

            this.Show();
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal void llenarFechas(List<string> fechasDisponibles)
        {
            FechasDisponibles.DataSource = fechasDisponibles.Select(
                fecha => new
                {
                    Fecha = fecha
                }
            ).ToList();
        }

        private void FechaSeleccionadaButton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedCellCollection dataSelectedCell = FechasDisponibles.SelectedCells;
            DataGridViewCell dgvc = dataSelectedCell[0];
            DataGridViewRow row = dgvc.OwningRow;

            string fechaElegida=row.Cells[0].Value.ToString();

            HorariosTurnos horarios = new HorariosTurnos();
            horarios.TopMost = true;
            horarios.setHorariosTurnosListener(this.controller);
            horarios.showHorarios(paciente_id,medico,especialidad,fechaElegida);
        }
    }
}
