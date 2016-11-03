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

        public HorariosAgendaProfesional()
        {
            this.controller = new HorariosAgendaProfesionalController(this);
            InitializeComponent();
        }

        internal void mostrarHorarios(List<CheckBox> CBLDias)
        {
            this.horasDesde = new Dictionary<NumericUpDown, NumericUpDown>();
            this.horasHasta = new Dictionary<NumericUpDown, NumericUpDown>();
            int ycoords = 0;
            int xcoords = 3;
            
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
                    horaDesde.Width = 40;
                    horaDesde.Location = new Point(xcoords, ycoords);
                    horaDesde.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(horaDesde);
                    xcoords += 80;

                    NumericUpDown minutosDesde = new NumericUpDown();
                    minutosDesde.Width = 40;
                    minutosDesde.Location = new Point(xcoords, ycoords);
                    minutosDesde.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(minutosDesde);
                    xcoords += 73;

                    NumericUpDown horaHasta = new NumericUpDown();
                    horaHasta.Width = 40;
                    horaHasta.Location = new Point(xcoords, ycoords);
                    horaHasta.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    diasPanel.Controls.Add(horaHasta);
                    xcoords += 70;

                    NumericUpDown minutosHasta = new NumericUpDown();
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
    }
}
