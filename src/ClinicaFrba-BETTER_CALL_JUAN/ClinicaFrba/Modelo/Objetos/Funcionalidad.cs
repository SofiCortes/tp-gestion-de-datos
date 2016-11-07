using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class Funcionalidad
    {
        public static string DAR_DE_ALTA_AFILIADO = "Dar de alta afiliado";
        public static string DAR_DE_BAJA_AFILIADO = "Dar de baja afiliado";
        public static string MODIFICAR_AFILIADO = "Modificar afiliado";
        public static string REGISTRO_DE_LLEGADA_PARA_ATENCION_MEDICA = "Registro de llegada para atención médica";
        public static string CANCELAR_ATENCION_MEDICA = "Cancelar atención médica";
        public static string GENERAR_LISTADO_ESTADISTICO = "Generar listado estadístico";
        public static string COMPRAR_BONO = "Comprar bono";
        public static string PEDIR_TURNO = "Pedir turno";
        public static string REGISTRO_DE_RESULTADO_PARA_ATENCION_MEDICA = "Registro de resultado para atención médica";

        public static string ACCIONES_CON_ROLES = "Acciones con roles";
        public static string ACCIONES_CON_AFILIADOS = "Acciones con afiliados";
        public static string ACCIONES_CON_PROFESIONALES = "Acciones con profesionales";
        public static string ACCIONES_CON_PLANES = "Acciones con planes";
        public static string ACCIONES_CON_BONOS = "Acciones con bonos";
        public static string ACCIONES_CON_TURNOS = "Acciones con turnos";
        public static string ACCIONES_CON_ATENCION_MEDICA = "Acciones con atencion medica";

        public decimal id { get; set; }
        public string descripcion { get; set; }
    }
}
