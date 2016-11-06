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

        internal List<Medico> obtenerMedicosDeTurnosParaUsuario(decimal usuarioId)
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Get_Medicos_De_Turnos_Por_Usuario", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Medico medico = new Medico();

                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);
                        medico.tipoDoc = sqlReader.GetString(3);
                        medico.nroDoc = sqlReader.GetDecimal(4);
                        medico.direccion = sqlReader.GetString(5);
                        medico.telefono = sqlReader.GetDecimal(6);
                        medico.mail = sqlReader.GetString(7);
                        medico.fechaNacimiento = sqlReader.GetDateTime(8);

                        medicos.Add(medico);
                    }
                }
            }
            catch (Exception e)
            {
                medicos = null;
            }
            finally
            {
                this.closeDB();
            }
            return medicos;
        }

        internal List<Turno> buscarTurnosParaUsuario(decimal usuarioId)
        {
            List<Turno> turnos = new List<Turno>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Get_Turnos_Por_Usuario", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Turno turno = new Turno();
                        turno.numero = sqlReader.GetDecimal(0);
                        turno.fechaHora = sqlReader.GetDateTime(1);
                        turno.medicoEspecialidadId = sqlReader.GetDecimal(2);
                        turno.pacienteId = sqlReader.GetDecimal(3);

                        Medico medico = new Medico();
                        medico.apellido = sqlReader.GetString(4);
                        medico.nombre = sqlReader.GetString(5);
                        turno.medico = medico;

                        Especialidad especialidad = new Especialidad();
                        especialidad.descripcion = sqlReader.GetString(6);
                        turno.especialidad = especialidad;

                        turnos.Add(turno);
                    }
                }
            }
            catch (Exception e)
            {
                turnos = null;
            }
            finally
            {
                this.closeDB();
            }
            return turnos;
        }

        internal List<Turno> buscarTurnosParaUsuarioConFiltros(DateTime fechaBuscar, decimal medicoMatricula, decimal usuarioId)
        {
            List<Turno> turnos = new List<Turno>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                ParametroParaSP parametro2 = new ParametroParaSP("fecha_turno", SqlDbType.DateTime, fechaBuscar.Date);
                ParametroParaSP parametro3 = new ParametroParaSP("medico_matricula", SqlDbType.Decimal, medicoMatricula);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Get_Turnos_Por_Usuario_Con_Filtros", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Turno turno = new Turno();
                        turno.numero = sqlReader.GetDecimal(0);
                        turno.fechaHora = sqlReader.GetDateTime(1);
                        turno.medicoEspecialidadId = sqlReader.GetDecimal(2);
                        turno.pacienteId = sqlReader.GetDecimal(3);

                        Medico medico = new Medico();
                        medico.apellido = sqlReader.GetString(4);
                        medico.nombre = sqlReader.GetString(5);
                        turno.medico = medico;

                        Especialidad especialidad = new Especialidad();
                        especialidad.descripcion = sqlReader.GetString(6);
                        turno.especialidad = especialidad;

                        turnos.Add(turno);
                    }
                }
            }
            catch (Exception e)
            {
                turnos = null;
            }
            finally
            {
                this.closeDB();
            }
            return turnos;
        }

        internal bool cancelarTurno(decimal usuarioId, Turno turno, string motivo, TipoCancelacion tipoCancelacion)
        {
            bool turnoCancelado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                ParametroParaSP parametro2 = new ParametroParaSP("turno_numero", SqlDbType.Decimal, turno.numero);
                ParametroParaSP parametro3 = new ParametroParaSP("tipo", SqlDbType.Decimal, tipoCancelacion.id);
                ParametroParaSP parametro4 = new ParametroParaSP("motivo", SqlDbType.VarChar, motivo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Cancelar_Turno_Afiliado", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                turnoCancelado = false;
            }
            finally
            {
                this.closeDB();
            }

            return turnoCancelado;
        }

        internal bool cancelarRango(DateTime fechaDesde, DateTime fechaHasta, decimal usuarioId, string motivo, TipoCancelacion tipoCancelacion)
        {
            bool rangoCancelado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("fecha_inicio", SqlDbType.DateTime, fechaDesde);
                ParametroParaSP parametro2 = new ParametroParaSP("fecha_fin", SqlDbType.DateTime, fechaHasta);
                ParametroParaSP parametro3 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                ParametroParaSP parametro4 = new ParametroParaSP("tipo", SqlDbType.Decimal, tipoCancelacion.id);
                ParametroParaSP parametro5 = new ParametroParaSP("motivo", SqlDbType.VarChar, motivo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Cancelar_Turnos_Franja_Profesional", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                rangoCancelado = false;
            }
            finally
            {
                this.closeDB();
            }
            return rangoCancelado;
        }

        internal bool cancelarFecha(DateTime fecha, decimal usuarioId, string motivo, TipoCancelacion tipoCancelacion)
        {
            bool rangoCancelado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("fecha", SqlDbType.DateTime, fecha);
                ParametroParaSP parametro2 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                ParametroParaSP parametro3 = new ParametroParaSP("tipo", SqlDbType.Decimal, tipoCancelacion.id);
                ParametroParaSP parametro4 = new ParametroParaSP("motivo", SqlDbType.VarChar, motivo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Cancelar_Turno_Dia_Profesional", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                rangoCancelado = false;
            }
            finally
            {
                this.closeDB();
            }
            return rangoCancelado;
        }
    }
}
