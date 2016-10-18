using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Pantalla_Principal
{
    public partial class Pantalla_Principal : Form
    {
        public Pantalla_Principal()
        {
            InitializeComponent();
        }

        private void buttonRoles_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
            hideShowGroupBox(groupBoxRoles, true);
        }

        private void buttonAfiliados_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, true);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonProfesionales_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, true);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonPlanes_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, true);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonBonos_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, true);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonTurnos_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, true);
        }

        private void buttonAtencionMedica_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxAtencionMedica, true);
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxListadoEstadistico, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void buttonListadoEstadistico_Click(object sender, EventArgs e)
        {
            hideShowGroupBox(groupBoxListadoEstadistico, true);
            hideShowGroupBox(groupBoxBonos, false);
            hideShowGroupBox(groupBoxRoles, false);
            hideShowGroupBox(groupBoxAfiliados, false);
            hideShowGroupBox(groupBoxAtencionMedica, false);
            hideShowGroupBox(groupBoxPlanes, false);
            hideShowGroupBox(groupBoxProfesionales, false);
            hideShowGroupBox(groupBoxTurnos, false);
        }

        private void hideShowGroupBox(GroupBox groupBox, bool showOrHide)
        {
            groupBox.Visible = showOrHide;
        }

        private void buttonCrearRol_Click(object sender, EventArgs e)
        {
            AbmRol.Alta_Rol form = new AbmRol.Alta_Rol();
            form.Show();
        }

        private void buttonModificarRol_Click(object sender, EventArgs e)
        {
            AbmRol.Roles form = new AbmRol.Roles();
            form.actionCode = AbmRol.Roles.ACTION_CODE_FOR_LIST_MODIFY_ROL;
            form.Show();
        }

        private void buttonEliminarRol_Click(object sender, EventArgs e)
        {
            AbmRol.Roles form = new AbmRol.Roles();
            form.actionCode = AbmRol.Roles.ACTION_CODE_FOR_LIST_DELETE_ROL;
            form.Show();
        }

        private void buttonListadoRoles_Click(object sender, EventArgs e)
        {
            AbmRol.Roles form = new AbmRol.Roles();
            form.actionCode = AbmRol.Roles.ACTION_CODE_FOR_LIST_LIST_ROL;
            form.Show();
        }

        private void buttonCrearAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.Alta_Afiliado form = new Abm_Afiliado.Alta_Afiliado();
            form.Show();
        }

        private void buttonModificarAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.ListadoAfiliados form = new Abm_Afiliado.ListadoAfiliados();
            form.actionCode = Abm_Afiliado.ListadoAfiliados.ACTION_CODE_FOR_LIST_MODIFY_AFILIADO;
            form.Show();
        }

        private void buttonEliminarAfiliado_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.ListadoAfiliados form = new Abm_Afiliado.ListadoAfiliados();
            form.actionCode = Abm_Afiliado.ListadoAfiliados.ACTION_CODE_FOR_LIST_DELETE_AFILIADO;
            form.Show();
        }

        private void buttonListadoAfiliados_Click(object sender, EventArgs e)
        {
            Abm_Afiliado.ListadoAfiliados form = new Abm_Afiliado.ListadoAfiliados();
            form.actionCode = Abm_Afiliado.ListadoAfiliados.ACTION_CODE_FOR_LIST_LIST_AFILIADO;
            form.Show();
        }

        private void buttonListadoProfesionales_Click(object sender, EventArgs e)
        {
            Abm_Profesional.ListadoProfesionales form = new Abm_Profesional.ListadoProfesionales();
            form.actionCode = Abm_Profesional.ListadoProfesionales.ACTION_CODE_FOR_LIST_LIST;
            form.Show();
        }

        private void buttonEspecialidadesMedicas_Click(object sender, EventArgs e)
        {
            Abm_Profesional.Listado_Especialidades_Medicas form = new Abm_Profesional.Listado_Especialidades_Medicas();
            form.Show();
        }

        private void buttonAgendaProfesionales_Click(object sender, EventArgs e)
        {
            Abm_Profesional.ListadoProfesionales form = new Abm_Profesional.ListadoProfesionales();
            form.actionCode = Abm_Profesional.ListadoProfesionales.ACTION_CODE_FOR_LIST_VIEW_AGENDA;
            form.Show();
        }

        private void buttonCompraBonos_Click(object sender, EventArgs e)
        {
            Compra_Bono.Form1 form = new Compra_Bono.Form1();
            form.Show();
        }

        private void buttonPedidoTurno_Click(object sender, EventArgs e)
        {
            Pedir_Turno.Form1 form = new Pedir_Turno.Form1();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Abm_Planes.Form1 form = new Abm_Planes.Form1();
            form.Show();
        }

        private void buttonEspecialidadesCancelaciones_Click(object sender, EventArgs e)
        {
            Listados_Estadisticos.EspecialidadConMasCancelaciones form = new Listados_Estadisticos.EspecialidadConMasCancelaciones();
            form.Show();
        }

        private void buttonProfesionalesPorPlan_Click(object sender, EventArgs e)
        {
            Listados_Estadisticos.ProfesionalesMasConsultados form = new Listados_Estadisticos.ProfesionalesMasConsultados();
            form.Show();
        }

        private void buttonProfesionalesMenosHoras_Click(object sender, EventArgs e)
        {
            Listados_Estadisticos.ProfesionalesConMenosHoras form = new Listados_Estadisticos.ProfesionalesConMenosHoras();
            form.Show();
        }

        private void buttonAfiliadosBonos_Click(object sender, EventArgs e)
        {
            Listados_Estadisticos.AfiliadosConMasBonos form = new Listados_Estadisticos.AfiliadosConMasBonos();
            form.Show();
        }

        private void buttonEspecialidadesBonos_Click(object sender, EventArgs e)
        {
            Listados_Estadisticos.EspecialidadesConMasBonos form = new Listados_Estadisticos.EspecialidadesConMasBonos();
            form.Show();
        }

        private void buttonRegistroLlegada_Click(object sender, EventArgs e)
        {
            Atenciones_medicas.Listado_Atenciones form = new Atenciones_medicas.Listado_Atenciones();
            form.actionCode = Atenciones_medicas.Listado_Atenciones.ACTION_CODE_FOR_LIST_REGISTRAR_LLEGADA_ATENCION;
            form.Show();
        }

        private void buttonRegistroResultado_Click(object sender, EventArgs e)
        {
            Atenciones_medicas.Listado_Atenciones form = new Atenciones_medicas.Listado_Atenciones();
            form.actionCode = Atenciones_medicas.Listado_Atenciones.ACTION_CODE_FOR_LIST_REGISTRAR_RESULTADO_CONSULTA;
            form.Show();
        }

        private void buttonCancelarAtencion_Click(object sender, EventArgs e)
        {
            Atenciones_medicas.Listado_Atenciones form = new Atenciones_medicas.Listado_Atenciones();
            form.actionCode = Atenciones_medicas.Listado_Atenciones.ACTION_CODE_FOR_LIST_CANCELAR_ATENCION;
            form.Show();
        }

    }
}
