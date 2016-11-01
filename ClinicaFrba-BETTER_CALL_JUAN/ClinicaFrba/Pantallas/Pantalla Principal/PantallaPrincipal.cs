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
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();

            this.Shown += (s, e1) =>
            {
                this.ocultarBotonesSinPermisos();
            };
        }

        private void ocultarBotonesSinPermisos()
        {
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.DAR_DE_ALTA_AFILIADO))
            {
                this.buttonCrearAfiliado.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.DAR_DE_BAJA_AFILIADO))
            {
                this.buttonEliminarAfiliado.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.MODIFICAR_AFILIADO))
            {
                this.buttonModificarAfiliado.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.REGISTRO_DE_LLEGADA_PARA_ATENCION_MEDICA))
            {
                this.buttonRegistroLlegada.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.CANCELAR_ATENCION_MEDICA))
            {
                this.buttonCancelarAtencion.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.GENERAR_LISTADO_ESTADISTICO))
            {
                this.buttonListadoEstadistico.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.COMPRAR_BONO))
            {
                this.buttonCompraBonos.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.PEDIR_TURNO))
            {
                this.buttonPedidoTurno.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.REGISTRO_DE_RESULTADO_PARA_ATENCION_MEDICA))
            {
                this.buttonRegistroResultado.Visible = false;
            }

            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_ROLES))
            {
                this.buttonRoles.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_AFILIADOS))
            {
                this.buttonAfiliados.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_PROFESIONALES))
            {
                this.buttonProfesionales.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_PLANES))
            {
                this.buttonPlanes.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_BONOS))
            {
                this.buttonBonos.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_TURNOS))
            {
                this.buttonTurnos.Visible = false;
            }
            if (!UsuarioConfiguracion.getInstance().tieneFuncionalidad(Funcionalidad.ACCIONES_CON_ATENCION_MEDICA))
            {
                this.buttonAtencionMedica.Visible = false;
            }
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
            AltaRol form = new AltaRol();
            form.Show();
        }

        private void buttonModificarRol_Click(object sender, EventArgs e)
        {
            ListadoRoles form = new ListadoRoles();
            form.actionCode = ListadoRoles.ACTION_CODE_FOR_LIST_MODIFY_ROL;
            form.Show();
        }

        private void buttonEliminarRol_Click(object sender, EventArgs e)
        {
            ListadoRoles form = new ListadoRoles();
            form.actionCode = ListadoRoles.ACTION_CODE_FOR_LIST_DELETE_ROL;
            form.Show();
        }

        private void buttonListadoRoles_Click(object sender, EventArgs e)
        {
            ListadoRoles form = new ListadoRoles();
            form.actionCode = ListadoRoles.ACTION_CODE_FOR_LIST_LIST_ROL;
            form.Show();
        }

        private void buttonCrearAfiliado_Click(object sender, EventArgs e)
        {
            AltaAfiliado form = new AltaAfiliado();
            form.Show();
        }

        private void buttonModificarAfiliado_Click(object sender, EventArgs e)
        {
            ListadoAfiliados form = new ListadoAfiliados();
            form.actionCode = ListadoAfiliados.ACTION_CODE_FOR_LIST_MODIFY_AFILIADO;
            form.Show();
        }

        private void buttonEliminarAfiliado_Click(object sender, EventArgs e)
        {
            ListadoAfiliados form = new ListadoAfiliados();
            form.actionCode = ListadoAfiliados.ACTION_CODE_FOR_LIST_DELETE_AFILIADO;
            form.Show();
        }

        private void buttonListadoAfiliados_Click(object sender, EventArgs e)
        {
            ListadoAfiliados form = new ListadoAfiliados();
            form.actionCode = ListadoAfiliados.ACTION_CODE_FOR_LIST_LIST_AFILIADO;
            form.Show();
        }

        private void buttonListadoProfesionales_Click(object sender, EventArgs e)
        {
            ListadoProfesionales form = new ListadoProfesionales();
            form.actionCode = ListadoProfesionales.ACTION_CODE_FOR_LIST_LIST;
            form.Show();
        }

        private void buttonRegistrarAgenda_Click(object sender, EventArgs e)
        {
            ListadoProfesionalesParaRegistrarAgenda form = new ListadoProfesionalesParaRegistrarAgenda();
            form.Show();
        }

        private void buttonEspecialidadesMedicas_Click(object sender, EventArgs e)
        {
            ListadoEspecialidadesMedicas form = new ListadoEspecialidadesMedicas();
            form.Show();
        }

        private void buttonAgendaProfesionales_Click(object sender, EventArgs e)
        {
            ListadoProfesionales form = new ListadoProfesionales();
            form.actionCode = ListadoProfesionales.ACTION_CODE_FOR_LIST_VIEW_AGENDA;
            form.Show();
        }

        private void buttonCompraBonos_Click(object sender, EventArgs e)
        {
            ComprarBono form = new ComprarBono();
            form.Show();
        }

        private void buttonPedidoTurno_Click(object sender, EventArgs e)
        {
            PedirTurnoForm form = new PedirTurnoForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListadoPlanes form = new ListadoPlanes();
            form.Show();
        }

        private void buttonEspecialidadesCancelaciones_Click(object sender, EventArgs e)
        {
            EspecialidadConMasCancelaciones form = new EspecialidadConMasCancelaciones();
            form.Show();
        }

        private void buttonProfesionalesPorPlan_Click(object sender, EventArgs e)
        {
            ProfesionalesMasConsultados form = new ProfesionalesMasConsultados();
            form.Show();
        }

        private void buttonProfesionalesMenosHoras_Click(object sender, EventArgs e)
        {
            ProfesionalesConMenosHoras form = new ProfesionalesConMenosHoras();
            form.Show();
        }

        private void buttonAfiliadosBonos_Click(object sender, EventArgs e)
        {
            AfiliadosConMasBonos form = new AfiliadosConMasBonos();
            form.Show();
        }

        private void buttonEspecialidadesBonos_Click(object sender, EventArgs e)
        {
            EspecialidadesConMasBonos form = new EspecialidadesConMasBonos();
            form.Show();
        }

        private void buttonRegistroLlegada_Click(object sender, EventArgs e)
        {
            ListadoAtenciones form = new ListadoAtenciones();
            form.actionCode = ListadoAtenciones.ACTION_CODE_FOR_LIST_REGISTRAR_LLEGADA_ATENCION;
            form.Show();
        }

        private void buttonRegistroResultado_Click(object sender, EventArgs e)
        {
            ListadoAtenciones form = new ListadoAtenciones();
            form.actionCode = ListadoAtenciones.ACTION_CODE_FOR_LIST_REGISTRAR_RESULTADO_CONSULTA;
            form.Show();
        }

        private void buttonCancelarAtencion_Click(object sender, EventArgs e)
        {
            ListadoAtenciones form = new ListadoAtenciones();
            form.actionCode = ListadoAtenciones.ACTION_CODE_FOR_LIST_CANCELAR_ATENCION;
            form.Show();
        }

    }
}
