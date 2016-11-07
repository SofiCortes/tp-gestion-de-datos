using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class ConfiguracionApp
    {

        public DateTime fechaActual { get; set; }
        public String bdServer { get; set; }
        public String bdName { get; set; }
        public String bdUser { get; set; }
        public String bdUserPassword { get; set; }

        private static ConfiguracionApp _selfInstance;

        public static ConfiguracionApp getInstance()
        {
            if (_selfInstance == null)
            {
                loadConfiguration();
            }
            return _selfInstance;
        }

        private static void loadConfiguration()
        {
            _selfInstance = new ConfiguracionApp();
            ArchivoConfig.cargarParametros(_selfInstance);
            if(!validarParametrosCargadosOk()) {
                throw new Exception();
            }
        }

        private static bool validarParametrosCargadosOk()
        {
            return _selfInstance.fechaActual != null && _selfInstance.bdName != null
                && _selfInstance.bdServer != null && _selfInstance.bdUser != null
                && _selfInstance.bdUserPassword != null;
        }
    }
}
