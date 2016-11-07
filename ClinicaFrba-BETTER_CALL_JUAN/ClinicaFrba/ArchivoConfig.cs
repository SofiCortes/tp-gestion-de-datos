using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ArchivoConfig
    {
        public static void cargarParametros(ConfiguracionApp configuracion) {
            string[] lineas = File.ReadAllLines("../../archivoConfig.txt");

            if (lineas != null && lineas.Count() > 0)
            {
                foreach (string linea in lineas)
                {
                    char[] separator = "=".ToCharArray();

                    String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);

                    string parametro = palabras.ElementAt(0);

                    if (parametro.Equals("fecha_hoy"))
                    {
                        cargarFecha(configuracion, linea);
                    }
                    else if (parametro.Equals("bd_server"))
                    {
                        cargarBDServer(configuracion, linea);
                    }
                    else if (parametro.Equals("bd_name"))
                    {
                        cargarBDName(configuracion, linea);
                    }
                    else if (parametro.Equals("bd_user"))
                    {
                        cargarBDUser(configuracion, linea);
                    }
                    else if (parametro.Equals("bd_user_password"))
                    {
                        cargarBDUserPassword(configuracion, linea);
                    }
                    else
                    {
                        throw new Exception("La linea " + linea + " no es un parametro de configuracion correcto");
                    }
                }
            }
            else
            {
                throw new Exception("Escriba correctamente los parametros en el archivo de configuracion");
            }
        }

        private static void cargarBDUserPassword(ConfiguracionApp configuracion, string linea)
        {
            char[] separator = "=".ToCharArray();

            String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);

            string bdUserPass = palabras.ElementAt(1);

            configuracion.bdUserPassword = bdUserPass;
        }

        private static void cargarBDUser(ConfiguracionApp configuracion, string linea)
        {
            char[] separator = "=".ToCharArray();

            String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);

            string bdUser = palabras.ElementAt(1);

            configuracion.bdUser = bdUser;
        }

        private static void cargarBDName(ConfiguracionApp configuracion, string linea)
        {
            char[] separator = "=".ToCharArray();

            String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);

            string bdName = palabras.ElementAt(1);

            configuracion.bdName = bdName;
        }

        private static void cargarBDServer(ConfiguracionApp configuracion, string linea)
        {
            char[] separator = "=".ToCharArray();

            String[] palabras = linea.Split(separator, 2, System.StringSplitOptions.None);

            string bdServer = palabras.ElementAt(1);

            configuracion.bdServer = bdServer;
        }

        private static void cargarFecha(ConfiguracionApp configuracion, string lineaFecha)
        {
            char[] separator = "=".ToCharArray();

            String[] palabras = lineaFecha.Split(separator, 2, System.StringSplitOptions.None);

            string fechaString = palabras.ElementAt(1);

            if (fechaString.Count() != 10 || !fechaString.Contains('/'))
                throw new Exception("Ingresar la fecha en formato aaaa/mm/dd");

            configuracion.fechaActual = DateTime.Parse(fechaString);
        }

    }
}
