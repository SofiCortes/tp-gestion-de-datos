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
        public static string DAR_DE_ALTA_PROFESIONAL = "Dar de alta profesional";
        public static string DAR_DE_BAJA_PROFESIONAL = "Dar de baja profesional";
        public static string MODIFICAR_PROFESIONAL = "Modificar profesional";
        public static string DAR_DE_ALTA_ESPECIALIDAD_MEDICA = "Dar de alta especialidad médica";
        public static string DAR_DE_VAJA_ESPECIALIDAD_MEDICA = "Dar de baja especialidad médica";
        public static string MODIFICAR_ESPECIALIDAD_MEDICA = "Modificar especialidad médica";
        public static string DAR_DE_ALTA_PLAN = "Dar de alta plan";
        public static string DAR_DE_BAJA_PLAN = "Dar de baja plan";
        public static string MODIFICAR_PLAN = "Modificar plan";
        public static string REGISTRAR_AGENDA_PROFESIONAL = "Registrar agenda profesional";
        public static string REGISTRO_DE_LLEGADA_PARA_ATENCION_MEDICA = "Registro de llegada para atención médica";
        public static string CANCELAR_ATENCION_MEDICA = "Cancelar atención médica";
        public static string GENERAR_LISTADO_ESTADISTICO = "Generar listado estadístico";
        public static string COMPRAR_BONO = "Comprar bono";
        public static string PEDIR_TURNO = "Pedir turno";
        public static string REGISTRO_DE_RESULTADO_PARA_ATENCION_MEDICA = "Registro de resultado para atención médica";

        public decimal id { get; set; }
        public string descripcion { get; set; }
    }
}
