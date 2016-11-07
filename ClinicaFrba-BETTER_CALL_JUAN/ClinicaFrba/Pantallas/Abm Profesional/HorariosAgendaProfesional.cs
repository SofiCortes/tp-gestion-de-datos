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
    public partial class HorariosAgendaProfesional : Form
    {
        private HorariosAgendaProfesionalController controller;
        private Dictionary<NumericUpDown, NumericUpDown> horasDesde;
        private Dictionary<NumericUpDown, NumericUpDown> horasHasta;
        private Especialidad especialidadSeleccionada;
        private Medico medicoSeleccionado;

        public HorariosAgendaProfesional()
        {
            this.controller = new HorariosAgendaProfesionalController(this);
            InitializeComponent();
        }

        internal void mostrarHorarios(List<CheckBox> CBLDias, Medico medico, Especialidad especialidad)
        {
            especialidadSeleccionada = especialidad;
            medicoSeleccionado = medico;
            this.horasDesde = new Dictionary<NumericUpDown, NumericUpDown>();
            this.horasHasta = new Dictionary<NumericUpDown, NumericUpDown>();
            int ycoords = 0;
            int xcoords = 3;

            this.fechaDesde.Value = ArchivoConfig.getFechaDeHoy();
            this.fechaHasta.Value = ArchivoConfig.getFechaDeHoy();
                        
            CBLDias.ForEach(cbdia =>
            {
                if (cbdia.Checked)
                {
                    Label dia = new Label();
                    dia.Width = 70;
                    dia.Text = cbdia.Text;
                    dia.Location = new Point(xcoords, ycoords);
                    dia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(dia);
                    xcoords += 96;

                    NumericUpDown horaDesde = new NumericUpDown();
                    horaDesde.Name = dia.Text;
                    horaDesde.Maximum = 23;
                    horaDesde.Minimum = 0;
                    horaDesde.Width = 40;
                    horaDesde.Location = new Point(xcoords, ycoords);
                    horaDesde.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(horaDesde);
                    xcoords += 80;

                    NumericUpDown minutosDesde = new NumericUpDown();
                    minutosDesde.Name = dia.Text;
                    minutosDesde.Maximum = 59;
                    minutosDesde.Minimum = 0;
                    minutosDesde.Width = 40;
                    minutosDesde.Location = new Point(xcoords, ycoords);
                    minutosDesde.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(minutosDesde);
                    xcoords += 73;

                    NumericUpDown horaHasta = new NumericUpDown();
                    horaHasta.Name = dia.Text;
                    horaHasta.Maximum = 23;
                    horaHasta.Minimum = 0;
                    horaHasta.Width = 40;
                    horaHasta.Location = new Point(xcoords, ycoords);
                    horaHasta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(horaHasta);
                    xcoords += 70;

                    NumericUpDown minutosHasta = new NumericUpDown();
                    minutosHasta.Name = dia.Text;
                    minutosHasta.Maximum = 59;
                    minutosHasta.Minimum = 0;
                    minutosHasta.Width = 40;
                    minutosHasta.Location = new Point(xcoords, ycoords);
                    minutosHasta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(minutosHasta);

                    ycoords += 25;
                    this.horasDesde.Add(horaDesde, minutosDesde);
                    this.horasHasta.Add(horaHasta, minutosHasta);
                    xcoords = 3;
                }
            });

            this.Show();
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            String fecha_desde = fechaDesde.Value.ToShortDateString();
            String fecha_hasta = fechaHasta.Value.ToShortDateString();
            
            DateTime hoy = ArchivoConfig.getFechaDeHoy();

            if (DateTime.Parse(fecha_desde) >= hoy)
            {
                if (DateTime.Parse(fecha_desde) <= DateTime.Parse(fecha_hasta))
                {

                    if (this.validarHorarios())
                    {
                        try
                        {
                            this.controller.registraAgenda(medicoSeleccionado, especialidadSeleccionada, horasDesde, horasHasta, fecha_desde, fecha_hasta);
                            this.Close();
                        }
                        catch (Exception x)
                        {
                            this.showErrorMessage(x.Message);
                        }
                    }
                }
                else
                {
                    this.showErrorMessage("La Fecha Hasta debe ser posterior a la Fecha Desde");
                }
            }
            else
            {
                this.showErrorMessage("La Fecha Desde no puede ser menor a la fecha de hoy");
            }
            
        }

        private Boolean validarHorarios()
        {
            if (this.horasDesde.Any(hd => (hd.Key.Name != "Sabado" && hd.Key.Value < 7) || (hd.Key.Name != "Sabado" && hd.Key.Value > 20)))
            {
                this.showErrorMessage("Los horarios de atencion en los dias de semana es de 7 a 20 hs.");
                return false;
            }

            else
            {
                if (this.horasDesde.Any(hd => (hd.Key.Name == "Sabado" && hd.Key.Value < 10) || (hd.Key.Name == "Sabado" && hd.Key.Value > 15)))
                {
                    this.showErrorMessage("Los horarios de atencion los sabados es de 10 a 15 hs.");
                    return false;
                }

                else
                {
                    if (this.horasHasta.Any(hh => (hh.Key.Name != "Sabado" && hh.Key.Value < 7) || (hh.Key.Name != "Sabado" && hh.Key.Value > 20)))
                    {
                        this.showErrorMessage("Los horarios de atencion en los dias de semana es de 7 a 20 hs.");
                        return false;
                    }

                    else
                    {
                        if (this.horasHasta.Any(hh => (hh.Key.Name == "Sabado" && hh.Key.Value < 10) || (hh.Key.Name == "Sabado" && hh.Key.Value > 15)))
                        {
                            this.showErrorMessage("Los horarios de atencion los sabados es de 10 a 15 hs.");
                            return false;
                        }

                        else
                        {

                            foreach (KeyValuePair<NumericUpDown, NumericUpDown> hd in horasDesde)
                            {
                                foreach (KeyValuePair<NumericUpDown, NumericUpDown> hh in horasHasta)
                                {
                                    if (hd.Key.Name == hh.Key.Name && hd.Key.Value >= hh.Key.Value)
                                    {
                                        this.showErrorMessage("La Hora Hasta debe ser posterior a la Hora Desde");
                                        return false;
                                    }
                                }
                            }

                            return true;
                        }
                    }
                }
            }
        }

        internal void showErrorMessage(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
