using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class UsuarioFuncionalidades
    {
        private static UsuarioFuncionalidades selfInstance;

        private List<string> funcionalidades;

        public static UsuarioFuncionalidades getInstance()
        {
            if (selfInstance == null)
            {
                selfInstance = new UsuarioFuncionalidades();
            }
            return selfInstance;
        }

        public void addFuncionalidades(List<string> nuevasFuncionalidades)
        {
            if (funcionalidades == null)
            {
                funcionalidades = new List<string>();
            }

            nuevasFuncionalidades.ForEach(funcionalidad => funcionalidades.Add(funcionalidad));
        }

        public bool tieneFuncionalidad(string funcionalidad)
        {
            return this.funcionalidades.Contains(funcionalidad);
        }

    }
}
