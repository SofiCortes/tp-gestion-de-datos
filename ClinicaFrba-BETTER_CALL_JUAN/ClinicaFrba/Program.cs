using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                ConfiguracionApp.getInstance();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                Application.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show("El archivo de configuracion es incorrecto. Por favor, complete correctamente todos los campos necesarios (Fecha y parametros de Base de Datos).", "Error");
            }
        }
    }
}
