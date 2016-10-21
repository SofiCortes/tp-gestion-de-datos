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
    public partial class ProfesionalesMasConsultados : Form
    {
        private ProfesionalesMasConsultadosController controller;

        public ProfesionalesMasConsultados()
        {
            this.controller = new ProfesionalesMasConsultadosController(this);
            InitializeComponent();
        }
    }
}
