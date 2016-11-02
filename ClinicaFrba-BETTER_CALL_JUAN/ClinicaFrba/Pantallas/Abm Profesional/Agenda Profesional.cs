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
    public partial class AgendaProfesional : Form
    {
        private AgendaProfesionalController controller;
        private List<CheckBox> CBLDias;

        public AgendaProfesional()
        {
            this.controller = new AgendaProfesionalController(this);

            InitializeComponent();

        }

        internal void showRegistroHorario(Medico medico, List<Especialidad> especialidades)
        {
            this.llenarComboEspecialidades(especialidades);
            this.mostrarDiasDeLaSemana();
            this.Show();
        }

        private void mostrarDiasDeLaSemana()
        {
            Dictionary<String,int> dias = new Dictionary<String, int>();
            dias.Add("Lunes",1);
            dias.Add("Martes",2);
            dias.Add("Miercoles",3);
            dias.Add("Jueves",4);
            dias.Add("Viernes",5);
            dias.Add("Sabado",6);

            this.CBLDias = new List<CheckBox>();
            int ycoords = 0;
         
            foreach(KeyValuePair<String, int> dia in dias){
                    CheckBox cbf = new CheckBox();
                    cbf.Width = diasPanel.Width;
                    cbf.Location = new Point(10, ycoords);
                    cbf.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    cbf.Text = dia.Key;
                    diasPanel.Controls.Add(cbf);
                    ycoords += 30;
                    this.CBLDias.Add(cbf);
                };
        }

        private void llenarComboEspecialidades(List<Especialidad> especialidades)
        {
            Especialidad especialidadDummy = new Especialidad();
            especialidadDummy.codigo = -1;
            especialidadDummy.descripcion = "Seleccione Especialidad";
            especialidades.Insert(0, especialidadDummy);

            this.comboEspecialidad.DataSource = especialidades;
            this.comboEspecialidad.DisplayMember = "descripcion";
        }
    }
}
