using System;
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

        public DiasTurnoMedico()
        {
            this.controller = new DiasTurnoMedicoController(this);
            
            InitializeComponent();
        }

        internal void showCalendario(Medico medico, Especialidad especialidad)
        {
            this.Show();
        }
    }
}
