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

        internal List<string> getHorariosDisponiblesParaFecha(Medico medico, Especialidad especialidad, string fechaElegida)
        {
            List<string> horariosDisponibles = new List<string>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medico.matricula);
                ParametroParaSP parametro2 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidad.codigo);
                ParametroParaSP parametro3 = new ParametroParaSP("fecha", SqlDbType.DateTime, DateTime.Parse(fechaElegida));

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Horarios_Disponibles_Para_Turno", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        string horario = sqlReader.GetTimeSpan(0).ToString();
                        horariosDisponibles.Add(horario);
                    }
                }

            }
            catch (Exception e)
            {
                horariosDisponibles = null;
            }
            finally
            {
                this.closeDB();
            }

            return horariosDisponibles;
        }

        internal bool pedirTurnoAfiliado(Medico medico, Especialidad especialidad, string fechaElegida, string horarioElegido)
        {
            bool turnoPedido = true;
            try
            {
                decimal usuario_id = UsuarioConfiguracion.getInstance().getUsuarioId();

                DateTime fecha_hora_turno = DateTime.Parse(fechaElegida) + TimeSpan.Parse(horarioElegido);

                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id_afiliado", SqlDbType.Decimal, usuario_id);
                ParametroParaSP parametro2 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medico.matricula);
                ParametroParaSP parametro3 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidad.codigo);
                ParametroParaSP parametro4 = new ParametroParaSP("fecha_hora_turno", SqlDbType.DateTime, fecha_hora_turno);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Usuario_Id", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                turnoPedido = false;
            }
            finally
            {
                this.closeDB();
            }
            return turnoPedido;
        }

        internal bool pedirTurnoAdministrativo(decimal paciente_id, Medico medico, Especialidad especialidad, string fechaElegida, string horarioElegido)
        {
            bool turnoPedido = true;
            try
            {
                DateTime fecha_hora_turno = DateTime.Parse(fechaElegida) + TimeSpan.Parse(horarioElegido);

                ParametroParaSP parametro1 = new ParametroParaSP("paciente_id", SqlDbType.Decimal, paciente_id);
                ParametroParaSP parametro2 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medico.matricula);
                ParametroParaSP parametro3 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidad.codigo);
                ParametroParaSP parametro4 = new ParametroParaSP("fecha_hora_turno", SqlDbType.DateTime, fecha_hora_turno);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();

                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Paciente_Id", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                turnoPedido = false;
            }
            finally
            {
                this.closeDB();
            }
            return turnoPedido;
        }
    }
}
