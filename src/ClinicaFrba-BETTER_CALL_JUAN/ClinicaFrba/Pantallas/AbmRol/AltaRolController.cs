using ClinicaFrba.Modelo.BD.Manager.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class AltaRolController
    {
        private AltaRol form;

        public AltaRolController(AltaRol form)
        {
            this.form = form;
        }

        internal List<Funcionalidad> obtenerTodasLasFuncionalidades()
        {
            FuncionalidadManager funcManager = new FuncionalidadManager();
            List<Funcionalidad> funcionalidades = funcManager.getTodasLasFuncionalidades();

            return funcionalidades;
        }



        internal void crearRolConFuncionesSeleccionadas(Rol rol, List<CheckBox> CBLFuncionalidades)
        {

            List<Funcionalidad> funcionalidadesAsignadas = new List<Funcionalidad>();

            CBLFuncionalidades.ForEach(cbf =>
            {
                if (cbf.Checked)
                {
                    Funcionalidad f = new Funcionalidad();
                    f.id = Convert.ToDecimal(cbf.Name);
                    f.descripcion = cbf.Text;
                    funcionalidadesAsignadas.Add(f);
                }
            });

            RolManager rm = new RolManager();

            rm.crearRol(rol, funcionalidadesAsignadas);
         
        }
    }
}
