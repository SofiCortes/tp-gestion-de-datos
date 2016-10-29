using ClinicaFrba.Modelo.BD.Manager.Implementacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class ModificarRolController
    {
        private ModificarRol form;

        public ModificarRolController(ModificarRol form)
        {
            this.form = form;
        }

        internal int obtenerRolID(Rol rol)
        {
            RolManager rm = new RolManager();
            int id = rm.obtenerRolID(rol.nombre);
            return id;
        }

        internal List<Funcionalidad> obtenerTodasLasFuncionalidades()
        {
            FuncionalidadManager fm = new FuncionalidadManager();
            List<Funcionalidad> todasLasFuncionalidades = fm.getTodasLasFuncionalidades();
            return todasLasFuncionalidades;
        }

        internal List<Funcionalidad> obtenerTodasLasFuncionalidadesDelRol(int id)
        {
            FuncionalidadManager fm = new FuncionalidadManager();
            List<Funcionalidad> funcsDelRol = fm.obtenerFuncionalidadesRol(id);
            return funcsDelRol;
        }

        internal void modificarRol(Rol rol, List<CheckBox> CBLFuncionalidades)
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

            rm.modificarRol(rol, funcionalidadesAsignadas);
        }

        internal bool obtenerEstadoHabilitacionRol(Rol rol)
        {
            RolManager rm = new RolManager();
            int habilitado = rm.obtenerEstadoHabilitacionRol(rol.id);
            return (habilitado == 1);
        }
    }
}
