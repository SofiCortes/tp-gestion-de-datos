using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ConsultaManager : AbstractManager
    {
        public ConsultaManager()
            : base(new ConexionBD())
        {
        }

        internal List<Turno> getTurnosParaFechaDeHoy(Medico medico, Especialidad especialidad)
        {
            List<Turno> turnos = new List<Turno>();


            try
            {

                ParametroParaSP parametro1 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medico.matricula);
                ParametroParaSP parametro2 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidad.codigo);
                ParametroParaSP parametro3 = new ParametroParaSP("fecha", SqlDbType.DateTime, ArchivoConfig.getFechaDeHoy()); 
                
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Turnos_Fecha_Por_Medico", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Turno turno = new Turno(); 
                        turno.pacienteId = sqlReader.GetDecimal(0);
                        
                        Paciente paciente = new Paciente();
                        paciente.tipoDoc = sqlReader.GetString(1);
                        paciente.nroDoc = sqlReader.GetDecimal(2);
                        paciente.nombre = sqlReader.GetString(3);
                        paciente.apellido = sqlReader.GetString(4);
 
                        turno.fechaHora = sqlReader.GetDateTime(5);
                        turno.numero = sqlReader.GetDecimal(6);

                        turno.paciente = paciente;
 
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

        internal int registrarLlegada(Turno turno, DateTime horaLlegada, decimal idBono)
        {
            int retorno = 0;
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("id_paciente", SqlDbType.Decimal, turno.pacienteId);
                ParametroParaSP parametro2 = new ParametroParaSP("turno_numero", SqlDbType.Decimal, turno.numero);
                ParametroParaSP parametro3 = new ParametroParaSP("hora_llegada", SqlDbType.DateTime, horaLlegada);
                ParametroParaSP parametro4 = new ParametroParaSP("bono_id", SqlDbType.Decimal, idBono);
                ParametroParaSP parametro5 = new ParametroParaSP("retorno", SqlDbType.SmallInt);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);


                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Registro_Llegada_Afiliado", parametros);
                procedure.ExecuteNonQuery();

                retorno = Convert.ToInt16(procedure.Parameters["@retorno"].Value);
            }
            catch (Exception e)
            {
                retorno = -1;
            }
            finally
            {
                this.closeDB();
            }
            return retorno;
        }


    }
}
