using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class TurnoManager : AbstractManager
    {
        public TurnoManager()
            : base(new ConexionBD())
        {
        }


        internal List<string> getFechasDisponibles(Medico medico, Especialidad especialidad)
        {
            List<string> fechasDisponibles = new List<string>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medico.matricula);
                ParametroParaSP parametro2 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidad.codigo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Fechas_Disponibles_Para_Turno", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        string fecha = sqlReader.GetDateTime(0).ToShortDateString();
                        fechasDisponibles.Add(fecha);
                    }
                }

            }
            catch (Exception e)
            {
                fechasDisponibles = null;
            }
            finally
            {
                this.closeDB();
            }

            return fechasDisponibles;
        }
    }
}
