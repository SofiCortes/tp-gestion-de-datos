using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class ProfesionalManager : AbstractManager
    {
        private SqlTransaction transact;

        public ProfesionalManager()
            : base(new ConexionBD())
        {
        }

        internal List<Medico> findAll()
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Medicos", null);
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
                        medico.sexo = !sqlReader.IsDBNull(9) ? sqlReader.GetString(9).ElementAt(0) : '-';

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

        internal List<Medico> buscarMedicosPorFiltro(string queryNombre, string queryApellido, string tipoDocSeleccionado, decimal documento, decimal matricula, decimal especialidadCodigo)
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("matricula", SqlDbType.Decimal, matricula);
                ParametroParaSP parametro2 = new ParametroParaSP("tipo_doc", SqlDbType.VarChar, tipoDocSeleccionado);
                ParametroParaSP parametro3 = new ParametroParaSP("nro_doc", SqlDbType.Decimal, documento);
                ParametroParaSP parametro4 = new ParametroParaSP("nombre", SqlDbType.VarChar, queryNombre);
                ParametroParaSP parametro5 = new ParametroParaSP("apellido", SqlDbType.VarChar, queryApellido);
                ParametroParaSP parametro6 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidadCodigo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Medicos_Filtros", parametros);
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
                        medico.sexo = !sqlReader.IsDBNull(9) ? sqlReader.GetString(9).ElementAt(0) : '-';

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

        internal Dictionary<Medico, Especialidad> buscarMedicosConSuEspecialidad(string queryNombre, string queryApellido, decimal especialidadCodigo)
        {
            Dictionary<Medico,Especialidad> medEsp = new Dictionary<Medico,Especialidad>();

            try
            {
                ParametroParaSP parametro4 = new ParametroParaSP("nombre", SqlDbType.VarChar, queryNombre);
                ParametroParaSP parametro5 = new ParametroParaSP("apellido", SqlDbType.VarChar, queryApellido);
                ParametroParaSP parametro6 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidadCodigo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Medico_Y_Especialidad_Para_Turno", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Medico medico = new Medico();
                        Especialidad especialidad = new Especialidad();

                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);
                        especialidad.codigo = sqlReader.GetDecimal(3);
                        especialidad.descripcion = sqlReader.GetString(4);

                        medEsp.Add(medico, especialidad);
                    }
                }

            }
            catch (Exception e)
            {
                medEsp = null;
            }
            finally
            {
                this.closeDB();
            }
            return medEsp;
        }

        internal List<Medico> buscarMedicosParaAgenda(string queryNombre, string queryApellido, decimal especialidadCodigo)
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                ParametroParaSP parametro4 = new ParametroParaSP("nombre", SqlDbType.VarChar, queryNombre);
                ParametroParaSP parametro5 = new ParametroParaSP("apellido", SqlDbType.VarChar, queryApellido);
                ParametroParaSP parametro6 = new ParametroParaSP("especialidad_codigo", SqlDbType.Decimal, especialidadCodigo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Medico_Para_Agenda", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Medico medico = new Medico();

                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);

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

        internal List<Especialidad> buscarEspecialidadesMedico(Medico medico)
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                ParametroParaSP parametro4 = new ParametroParaSP("matricula", SqlDbType.Decimal, medico.matricula);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Especialidades_Medico", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Especialidad especialidad = new Especialidad();

                        especialidad.codigo = sqlReader.GetDecimal(0);
                        especialidad.descripcion = sqlReader.GetString(1);

                        especialidades.Add(especialidad);
                    }
                }

            }
            catch (Exception e)
            {
                especialidades = null;
            }
            finally
            {
                this.closeDB();
            }
            return especialidades;
        }

        internal Medico buscarPorUsuarioId(decimal usuarioId)
        {
            Medico medico = new Medico();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("usuario_id", SqlDbType.Decimal, usuarioId);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Medico_Por_Usuario_Id", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);
                        medico.tipoDoc = sqlReader.GetString(3);
                        medico.nroDoc = sqlReader.GetDecimal(4);
                        medico.direccion = sqlReader.GetString(5);
                        medico.telefono = sqlReader.GetDecimal(6);
                        medico.mail = sqlReader.GetString(7);
                        medico.fechaNacimiento = sqlReader.GetDateTime(8);
                        medico.sexo = !sqlReader.IsDBNull(9) ? sqlReader.GetString(9).ElementAt(0) : '-';
                    }
                }

            }
            catch (Exception e)
            {
                medico = null;
            }
            finally
            {
                this.closeDB();
            }
            return medico;
        }

        internal void registrarRangoAtencion(Medico medicoSeleccionado, Especialidad especialidadSeleccionada, KeyValuePair<System.Windows.Forms.NumericUpDown, System.Windows.Forms.NumericUpDown> horaDesde, KeyValuePair<System.Windows.Forms.NumericUpDown, System.Windows.Forms.NumericUpDown> horaHasta, String fechaDesde, String fechaHasta)
        {
                String hd = horaDesde.Key.Value.ToString() + ":" + horaDesde.Value.Value.ToString();
                String hh = horaHasta.Key.Value.ToString() + ":" + horaHasta.Value.Value.ToString();

                ParametroParaSP parametro4 = new ParametroParaSP("dia_semana", SqlDbType.Decimal, Decimal.Parse(horaDesde.Key.Name));
                ParametroParaSP parametro5 = new ParametroParaSP("hd", SqlDbType.DateTime, DateTime.Parse(hd));
                ParametroParaSP parametro6 = new ParametroParaSP("hh", SqlDbType.DateTime, DateTime.Parse(hh));
                ParametroParaSP parametro1 = new ParametroParaSP("fd", SqlDbType.DateTime, DateTime.Parse(fechaDesde));
                ParametroParaSP parametro2 = new ParametroParaSP("fh", SqlDbType.DateTime, DateTime.Parse(fechaHasta));
                ParametroParaSP parametro7 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medicoSeleccionado.matricula);
                ParametroParaSP parametro8 = new ParametroParaSP("especialidad_id", SqlDbType.Decimal, especialidadSeleccionada.codigo);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro7);
                parametros.Add(parametro8);

                this.openDB();
                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Crear_Rango_Horario_Medico", parametros);
                procedure.ExecuteScalar();
                this.closeDB();
        }

        internal Decimal getHorasTrabajadas(Medico medicoSeleccionado, String fechaDesde, String fechaHasta)
        {
            ParametroParaSP parametro7 = new ParametroParaSP("medico_id", SqlDbType.Decimal, medicoSeleccionado.matricula);
            ParametroParaSP parametro8 = new ParametroParaSP("fd", SqlDbType.DateTime, DateTime.Parse(fechaDesde));
            ParametroParaSP parametro9 = new ParametroParaSP("fh", SqlDbType.DateTime, DateTime.Parse(fechaDesde));
            ParametroParaSP parametro4 = new ParametroParaSP("horas_trabajadas", SqlDbType.Decimal);

            List<ParametroParaSP> parametros = new List<ParametroParaSP>();
            parametros.Add(parametro7);
            parametros.Add(parametro8);
            parametros.Add(parametro9);
            parametros.Add(parametro4);

            this.openDB();
            SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Horas_Trabajadas_Medico", parametros);
            procedure.ExecuteNonQuery();

            Decimal hsTrabajadas = Convert.ToDecimal(procedure.Parameters["@horas_trabajadas"].Value);
            this.closeDB();

            return hsTrabajadas;
        }
    }
}
