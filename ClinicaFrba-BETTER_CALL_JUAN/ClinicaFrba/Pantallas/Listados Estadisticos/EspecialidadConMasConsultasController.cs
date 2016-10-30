﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class EspecialidadConMasConsultasController
    {
        private EspecialidadesConMasBonos form;

        public EspecialidadConMasConsultasController(EspecialidadesConMasBonos form)
        {
            this.form = form;
        }


        internal void buscarEspecialidadesConFiltros(string anioSeleccionado, string mesSeleccionado, string semestreSeleccionado)
        {
            mesSeleccionado = StoredProcedureHelper.getNumeroMesConNombreMes(mesSeleccionado);
            semestreSeleccionado = semestreSeleccionado.Equals("Primer semestre") ? "1" : "2";
            EstadisticasManager estadisticasManager = new EstadisticasManager();
            List<EspecialidadDAO> especialidades = estadisticasManager.getEspecialidadesConMasConsultas(anioSeleccionado, mesSeleccionado, semestreSeleccionado);

            if (especialidades != null)
            {
                this.form.showEspecialidades(especialidades);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener las especialidades");
            }
        }
    }
}
