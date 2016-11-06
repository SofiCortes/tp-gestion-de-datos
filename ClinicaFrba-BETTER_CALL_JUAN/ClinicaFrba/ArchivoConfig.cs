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
        public static DateTime getFechaDeHoy() {
            String[] lineas = File.ReadAllLines("../../archivoConfig.txt");

            if(lineas.Count()!=1)
                throw new Exception("Se debe ingresar una linea en el archivo de configuracion con: fecha_hoy=aaaa/mm/dd");

            String lineaFecha = lineas.ElementAt(0);
            char[] separator = "=".ToCharArray();

            String[] palabras = lineaFecha.Split(separator,2,System.StringSplitOptions.None);

            if(palabras.ElementAt(0)!="fecha_hoy")
                throw new Exception("Se debe ingresar una linea en el archivo de configuracion con: fecha_hoy=aaaa/mm/dd");

            string fechaString = palabras.ElementAt(1);

            if(fechaString.Count()!=10 || !fechaString.Contains('/'))
                throw new Exception("Ingresar la fecha en formato aaaa/mm/dd");

            return DateTime.Parse(fechaString);
        }



    }
}
