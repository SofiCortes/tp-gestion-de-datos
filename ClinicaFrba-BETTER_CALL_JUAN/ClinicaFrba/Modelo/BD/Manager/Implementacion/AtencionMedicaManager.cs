using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class AtencionMedicaManager : AbstractManager
    {
        public AtencionMedicaManager()
            : base(new ConexionBD())
        {
        }


        internal List<Consulta> buscarConsultasConFiltros(string nombre, string apellido, decimal codigo, decimal matricula)
        {

            List<Consulta> consultas = new List<Consulta>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nombre_paciente", SqlDbType.VarChar, matricula);
                ParametroParaSP parametro2 = new ParametroParaSP("apellido_paciente", SqlDbType.VarChar, apellido);
                ParametroParaSP parametro3 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, codigo);
                ParametroParaSP parametro4 = new ParametroParaSP("medico_matricula", SqlDbType.Decimal, matricula);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Consultas_Con_Filtros", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Consulta consulta = new Consulta();
                        consulta.id = sqlReader.GetInt16(0);
                        consulta.bonoConsultaId = sqlReader.GetDecimal(1);
                        consulta.enfermedades = sqlReader.GetString(2);
                        consulta.fechaHoraAtencion = sqlReader.GetDateTime(3);
                        consulta.fechaHoraLlegada = sqlReader.GetDateTime(4);
                        consulta.sintomas = sqlReader.GetString(5);
                        consulta.turnoNumero = sqlReader.GetDecimal(6);

                        Paciente paciente = new Paciente();
                        paciente.nombre = sqlReader.GetString(7);
                        paciente.apellido = sqlReader.GetString(8);

                        Especialidad especialidad = new Especialidad();
                        especialidad.descripcion = sqlReader.GetString(9);

                        consulta.paciente = paciente;
                        consulta.especialidad = especialidad;

                        consultas.Add(consulta);
                    }
                }

            }
            catch (Exception e)
            {
                consultas = null;
            }
            finally
            {
                this.closeDB();
            }
            return consultas;
        }

        internal bool registrarConsulta(decimal idConsulta, DateTime horaAtencion, string sintomas, string enfermedades)
        {
            bool registroConsulta = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("id_consulta", SqlDbType.Int, idConsulta);
                ParametroParaSP parametro2 = new ParametroParaSP("hora_atencion", SqlDbType.DateTime, horaAtencion);
                ParametroParaSP parametro3 = new ParametroParaSP("sintomas", SqlDbType.Decimal, sintomas);
                ParametroParaSP parametro4 = new ParametroParaSP("diagnostico", SqlDbType.Decimal, enfermedades);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Registro_Resultado_Consulta", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                registroConsulta = false;
            }
            finally
            {
                this.closeDB();
            }
            return registroConsulta;
        }
    }
}
