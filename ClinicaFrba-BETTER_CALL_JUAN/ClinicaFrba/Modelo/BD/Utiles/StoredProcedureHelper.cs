using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class StoredProcedureHelper
    {

        public static string getNumeroMesConNombreMes(string nombreMes)
        {
            string numeroMes = "0";
            if (nombreMes.Equals("Enero"))
            {
                numeroMes = "01";
            }
            else if (nombreMes.Equals("Febrero"))
            {
                numeroMes = "02";
            }
            else if (nombreMes.Equals("Marzo"))
            {
                numeroMes = "03";
            }
            else if (nombreMes.Equals("Abril"))
            {
                numeroMes = "04";
            }
            else if (nombreMes.Equals("Mayo"))
            {
                numeroMes = "05";
            }
            else if (nombreMes.Equals("Junio"))
            {
                numeroMes = "06";
            }
            else if (nombreMes.Equals("Julio"))
            {
                numeroMes = "07";
            }
            else if (nombreMes.Equals("Agosto"))
            {
                numeroMes = "08";
            }
            else if (nombreMes.Equals("Septiembre"))
            {
                numeroMes = "09";
            }
            else if (nombreMes.Equals("Octubre"))
            {
                numeroMes = "10";
            }
            else if (nombreMes.Equals("Noviembre"))
            {
                numeroMes = "11";
            }
            else if (nombreMes.Equals("Diciembre"))
            {
                numeroMes = "12";
            }
            return numeroMes;
        }


        public static string getAutorCancelacionConTipo(string autorCancelacion)
        {
            string cancelacion = "";
            if (autorCancelacion.Equals("Afiliados"))
            {
                cancelacion = "A";
            }
            else if (autorCancelacion.Equals("Medicos"))
            {
                cancelacion = "M";
            }
            else if (autorCancelacion.Equals("Todos"))
            {
                cancelacion = "T";
            }
            return cancelacion;
        }
    }
}
