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
    public partial class ListadoPlanes : Form
    {
        private ListadoPlanesController controller;

        public ListadoPlanes()
        {
            this.controller = new ListadoPlanesController(this);

            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.controller.llenarPlanesMedicos();
            };
        }

        internal void mostrarPlanesMedicos(List<PlanMedico> planes)
        {
            this.planesGrid.DataSource = planes;
        }
    }
}
