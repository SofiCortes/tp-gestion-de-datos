﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    public class AltaAfiliadoController : AgregarFamiliarListener, ModificarFamiliarListener, OpcionesFamiliarListener
    {
        private AltaAfiliado form;
        private List<Paciente> familiaresAgregados;

        public AltaAfiliadoController(AltaAfiliado form)
        {
            this.form = form;
        }

        internal void buscarPlanesParaCombo()
        {
            PlanManager planManager = new PlanManager();
            List<PlanMedico> planesMedicos = planManager.getPlanesMedicos();

            if (planesMedicos != null)
            {
                this.form.llenarComboPlanesMedicos(planesMedicos);
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al obtener los Planes Medicos");
            }
        }

        public void onFamiliarCreado(Paciente paciente)
        {
            if (this.familiaresAgregados == null)
            {
                this.familiaresAgregados = new List<Paciente>();
            }
            paciente.id = this.familiaresAgregados.Count;
            this.familiaresAgregados.Add(paciente);
            this.form.agregarFamiliar(this.familiaresAgregados);
        }

        internal void agregarAfiliado(Paciente paciente)
        {
            paciente.familiares = this.familiaresAgregados;
            PacienteManager pacienteManager = new PacienteManager();
            bool afiliadoAgregado = pacienteManager.agregarAfiliado(paciente);

            if (afiliadoAgregado)
            {
                this.form.showInformationMessage("El Afiliado fue dado de alta correctamente junto a toda su informacion");
                this.form.Close();
            }
            else
            {
                this.form.showErrorMessage("Ocurrio un error al agregar el Afiliado");
            }
        }

        internal void clearFamiliares()
        {
            this.familiaresAgregados.Clear();
        }

        public void onFamiliarModificado(Paciente paciente)
        {
            this.familiaresAgregados.Remove(paciente);
            this.familiaresAgregados.Insert(Convert.ToInt32(paciente.id), paciente);
            this.form.agregarFamiliar(this.familiaresAgregados);
        }

        public void onEliminarFamiliarSelected(Paciente paciente)
        {
            this.familiaresAgregados.Remove(paciente);
            this.form.agregarFamiliar(this.familiaresAgregados);
        }

        public void onModificarFamiliarSelected(Paciente paciente)
        {
            ModificarFamiliar ModificarFamiliar = new ModificarFamiliar();
            ModificarFamiliar.setModificarFamiliarListener(this);
            ModificarFamiliar.setPacienteAModificar(paciente);
            ModificarFamiliar.ShowDialog();
        }

        internal void onFamiliarClicked(Paciente paciente)
        {
            foreach (Paciente familiar in this.familiaresAgregados)
            {
                if (familiar.nroDoc.Equals(paciente.nroDoc))
                {
                    OpcionesFamiliarDialog OpcionesFamiliarDialog = new OpcionesFamiliarDialog();
                    OpcionesFamiliarDialog.setOpcionesFamiliarListener(this);
                    OpcionesFamiliarDialog.setPaciente(familiar);
                    OpcionesFamiliarDialog.ShowDialog();
                    break;
                }
            }
        }
    }
}
