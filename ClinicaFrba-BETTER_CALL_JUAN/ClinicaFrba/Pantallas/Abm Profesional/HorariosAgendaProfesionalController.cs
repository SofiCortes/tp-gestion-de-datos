﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class HorariosAgendaProfesionalController
    {
        private HorariosAgendaProfesional form;
        private Dictionary<string, int> dias;
        private List<int> diasSeleccionados;

        public HorariosAgendaProfesionalController(HorariosAgendaProfesional horariosAgendaProfesional)
        {
            this.form = horariosAgendaProfesional;

            dias = new Dictionary<String, int>();
            dias.Add("Lunes", 1);
            dias.Add("Martes", 2);
            dias.Add("Miercoles", 3);
            dias.Add("Jueves", 4);
            dias.Add("Viernes", 5);
            dias.Add("Sabado", 6);
        }

        internal void registraAgenda(Medico medicoSeleccionado, Especialidad especialidadSeleccionada, Dictionary<System.Windows.Forms.NumericUpDown, System.Windows.Forms.NumericUpDown> horasDesde, Dictionary<System.Windows.Forms.NumericUpDown, System.Windows.Forms.NumericUpDown> horasHasta)
        {
            this.obtenerDiasSeleccionados(horasDesde);
            ProfesionalManager pm = new ProfesionalManager();

            Dictionary<KeyValuePair<NumericUpDown, NumericUpDown>, KeyValuePair<NumericUpDown, NumericUpDown>> rangoAtencion = this.obtenerRangoAtencion(horasDesde, horasHasta);

            try
            {
                pm.openDB();
                pm.beginTransaction();

                foreach (KeyValuePair<KeyValuePair<NumericUpDown, NumericUpDown>, KeyValuePair<NumericUpDown, NumericUpDown>> rango in rangoAtencion)
                {
                    pm.registrarRangoAtencion(medicoSeleccionado, especialidadSeleccionada, rango.Key, rango.Value);
                }

                pm.commitTransaction();
            }

            catch (Exception ex)
            {
                pm.rollbackTransaction();
                this.form.showErrorMessage(ex.Message);
            }

            finally
            {
                pm.closeDB();
            }


        }

        private Dictionary<KeyValuePair<NumericUpDown, NumericUpDown>, KeyValuePair<NumericUpDown, NumericUpDown>> obtenerRangoAtencion(Dictionary<NumericUpDown, NumericUpDown> horasDesde, Dictionary<NumericUpDown, NumericUpDown> horasHasta)
        {
            Dictionary<KeyValuePair<NumericUpDown, NumericUpDown>, KeyValuePair<NumericUpDown, NumericUpDown>> rangoAtencion = new Dictionary<KeyValuePair<NumericUpDown, NumericUpDown>, KeyValuePair<NumericUpDown, NumericUpDown>>();

            int i = 0;
            int cantidadHsDesde = horasDesde.Count;
            int cantidadHsHasta = horasHasta.Count;
            
            while (i < cantidadHsDesde || i < cantidadHsHasta)
                {
                    rangoAtencion.Add(horasDesde.ElementAt(i), horasHasta.ElementAt(i));
                    i++;
                }

            return rangoAtencion;
        }

        private void obtenerDiasSeleccionados(Dictionary<NumericUpDown, NumericUpDown> horasDesde)
        {
            foreach (KeyValuePair<NumericUpDown, NumericUpDown> hd in horasDesde)
            {
                foreach (KeyValuePair<String, int> dia in dias)
                {
                    if (dia.Key == hd.Key.Name)
                    {
                        hd.Key.Name = dia.Value.ToString();
                    }

                }
            }
        }
    }
}
