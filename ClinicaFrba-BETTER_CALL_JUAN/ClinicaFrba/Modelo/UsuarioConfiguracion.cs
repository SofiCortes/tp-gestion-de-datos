using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class UsuarioConfiguracion
    {
        private static UsuarioConfiguracion selfInstance;

        private decimal userId;
        private List<string> funcionalidades;
        private Rol rol;

        public static UsuarioConfiguracion getInstance()
        {
            if (selfInstance == null)
            {
                selfInstance = new UsuarioConfiguracion();
            }
            return selfInstance;
        }

        public void addFuncionalidades(List<string> nuevasFuncionalidades)
        {
            if (funcionalidades == null)
            {
                funcionalidades = new List<string>();
            }

            funcionalidades.AddRange(nuevasFuncionalidades);
        }

        public bool tieneFuncionalidad(string funcionalidad)
        {
            return this.funcionalidades.Contains(funcionalidad);
        }

        internal decimal getUsuarioId()
        {
            return userId;
        }

        public void setUsuarioId(decimal userId)
        {
            this.userId = userId;
        }

        internal void setRol(Rol rol)
        {
            this.rol = rol;
        }

        internal Rol getRol()
        {
            return this.rol;
        }
    }
}
