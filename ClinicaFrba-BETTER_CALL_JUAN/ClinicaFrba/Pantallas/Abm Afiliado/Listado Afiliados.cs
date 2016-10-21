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
    public partial class ListadoAfiliados : Form
    {
        private ListadoAfiliadosController controller;

        public ListadoAfiliados()
        {
            this.controller = new ListadoAfiliadosController(this);
            InitializeComponent();
        }
    }
}
