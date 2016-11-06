using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class EstadisticasManager : AbstractManager
    {
        public EstadisticasManager()
            : base(new ConexionBD())
        {
        }

        internal List<MedicoDAO> getProfesionalesConMenosHoras(string semestreSeleccionado, string anioSeleccionado, string mesSeleccionado, decimal especialidadCod)
        {
            List<MedicoDAO> medicos = new List<MedicoDAO>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("especialidad_cod", SqlDbType.Decimal, especialidadCod);
                ParametroParaSP parametro2 = new ParametroParaSP("anio", SqlDbType.Int, int.Parse(anioSeleccionado));
                ParametroParaSP parametro3 = new ParametroParaSP("mes", SqlDbType.Int, int.Parse(mesSeleccionado));
                ParametroParaSP parametro4 = new ParametroParaSP("semestre", SqlDbType.Int, int.Parse(semestreSeleccionado));
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Con_Menos_Horas_Trabajadas_Segun_Especialidad", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        MedicoDAO medicoDAO = new MedicoDAO();

                        Medico medico = new Medico();
                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);

                        medicoDAO.medico = medico;
                        medicoDAO.cantHorasTrabajadas = sqlReader.GetInt32(3);

                        medicos.Add(medicoDAO);
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

        internal List<MedicoDAO> getProfesionalesMasConsultados(string semestreSeleccionado, string anioSeleccionado, string mesSeleccionado, decimal planMedicoCod)
        {
            List<MedicoDAO> medicos = new List<MedicoDAO>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("plan_medico_id", SqlDbType.Decimal, planMedicoCod);
                ParametroParaSP parametro2 = new ParametroParaSP("anio", SqlDbType.Int, int.Parse(anioSeleccionado));
                ParametroParaSP parametro3 = new ParametroParaSP("mes", SqlDbType.Int, int.Parse(mesSeleccionado));
                ParametroParaSP parametro4 = new ParametroParaSP("semestre", SqlDbType.Int, int.Parse(semestreSeleccionado));
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Mas_Consultados_Por_Plan", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        MedicoDAO medicoDAO = new MedicoDAO();

                        Medico medico = new Medico();
                        medico.matricula = sqlReader.GetDecimal(0);
                        medico.nombre = sqlReader.GetString(1);
                        medico.apellido = sqlReader.GetString(2);

                        Especialidad especialidad = new Especialidad();
                        especialidad.codigo = sqlReader.GetDecimal(3);
                        especialidad.descripcion = sqlReader.GetString(4);

                        medicoDAO.medico = medico;
                        medicoDAO.especialidadMedico = especialidad;
                        medicoDAO.cantConsultas = sqlReader.GetInt32(5);

                        medicos.Add(medicoDAO);
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

        internal List<EspecialidadDAO> getEspecialidadesConMasCancelaciones(char autorCancelacion, string anioSeleccionado, string mesSeleccionado, string semestreSeleccionado)
        {
            List<EspecialidadDAO> especialidades = new List<EspecialidadDAO>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("autor_cancelacion", SqlDbType.Char, autorCancelacion);
                ParametroParaSP parametro2 = new ParametroParaSP("semestre", SqlDbType.Int, int.Parse(semestreSeleccionado));
                ParametroParaSP parametro3 = new ParametroParaSP("anio", SqlDbType.Int, int.Parse(anioSeleccionado));
                ParametroParaSP parametro4 = new ParametroParaSP("mes", SqlDbType.Int, int.Parse(mesSeleccionado));
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Top_5_Especialidades_Con_Mas_Cancelaciones", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        EspecialidadDAO especialidadDAO = new EspecialidadDAO();

                        Especialidad especialidad = new Especialidad();
                        especialidad.codigo = sqlReader.GetDecimal(0);
                        especialidad.descripcion = sqlReader.GetString(1);

                        especialidadDAO.cantCancelaciones = sqlReader.GetInt32(2);
                        especialidadDAO.especialidad = especialidad;

                        especialidades.Add(especialidadDAO);
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

        internal List<PacienteDAO> getAfiliadosConMasBonos(string anioSeleccionado, string mesSeleccionado, string semestreSeleccionado)
        {
            List<PacienteDAO> pacientes = new List<PacienteDAO>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("semestre", SqlDbType.Int, int.Parse(semestreSeleccionado));
                ParametroParaSP parametro2 = new ParametroParaSP("anio", SqlDbType.Int, int.Parse(anioSeleccionado));
                ParametroParaSP parametro3 = new ParametroParaSP("mes", SqlDbType.Int, int.Parse(mesSeleccionado));
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Top_5_Afiliados_Con_Mayor_Cantidad_Bonos_Comprados", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        PacienteDAO pacienteDAO = new PacienteDAO();

                        Paciente paciente = new Paciente();
                        paciente.nombre = sqlReader.GetString(0);
                        paciente.apellido = sqlReader.GetString(1);
                        paciente.tipoDoc = sqlReader.GetString(2);
                        paciente.nroDoc = sqlReader.GetDecimal(3);
                        paciente.direccion = sqlReader.GetString(4);
                        paciente.telefono = sqlReader.GetDecimal(5);
                        paciente.cantidadFamiliares = sqlReader.GetInt32(6);

                        pacienteDAO.cantBonosComprados = sqlReader.GetInt32(7);
                        pacienteDAO.paciente = paciente;

                        pacientes.Add(pacienteDAO);
                    }
                }

            }
            catch (Exception e)
            {
                pacientes = null;
            }
            finally
            {
                this.closeDB();
            }
            return pacientes;
        }

        internal List<EspecialidadDAO> getEspecialidadesConMasConsultas(string anioSeleccionado, string mesSeleccionado, string semestreSeleccionado)
        {
            List<EspecialidadDAO> especialidades = new List<EspecialidadDAO>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("semestre", SqlDbType.Int, int.Parse(semestreSeleccionado));
                ParametroParaSP parametro2 = new ParametroParaSP("anio", SqlDbType.Int, int.Parse(anioSeleccionado));
                ParametroParaSP parametro3 = new ParametroParaSP("mes", SqlDbType.Int, int.Parse(mesSeleccionado));
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Top_5_Especialidades_Con_Mas_Bonos_Utilizados", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        EspecialidadDAO especialidadDAO = new EspecialidadDAO();

                        Especialidad especialidad = new Especialidad();
                        especialidad.codigo = sqlReader.GetDecimal(0);
                        especialidad.descripcion = sqlReader.GetString(1);

                        especialidadDAO.cantBonosUtilizados = sqlReader.GetInt32(2);
                        especialidadDAO.especialidad = especialidad;

                        especialidades.Add(especialidadDAO);
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

        internal List<int> getAniosProfesionalesConMenosHoras()
        {
            List<int> anios = new List<int>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Anios_Top_5_Profesionales_Menos_Horas", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        anios.Add(sqlReader.GetInt32(0));
                    }
                }

            }
            catch (Exception e)
            {
                anios = null;
            }
            finally
            {
                this.closeDB();
            }
            return anios;
        }

        internal List<int> getAniosProfesionalesMasConsultados()
        {
            List<int> anios = new List<int>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Anios_Top_5_Profesionales_Mas_Consultados", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        anios.Add(sqlReader.GetInt32(0));
                    }
                }

            }
            catch (Exception e)
            {
                anios = null;
            }
            finally
            {
                this.closeDB();
            }
            return anios;
        }

        internal List<int> getAniosEspecialidadesConMasCancelaciones()
        {
            List<int> anios = new List<int>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Anios_Top_5_Mas_Cancelaciones", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        anios.Add(sqlReader.GetInt32(0));
                    }
                }

            }
            catch (Exception e)
            {
                anios = null;
            }
            finally
            {
                this.closeDB();
            }
            return anios;
        }

        internal List<int> getAniosAfiliadosConMasBonos()
        {
            List<int> anios = new List<int>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Anios_Top_5_Afiliados_Mas_Bonos", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        anios.Add(sqlReader.GetInt32(0));
                    }
                }

            }
            catch (Exception e)
            {
                anios = null;
            }
            finally
            {
                this.closeDB();
            }
            return anios;
        }

        internal List<int> getAniosEspecialidadesConMasConsultas()
        {
            List<int> anios = new List<int>();

            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Anios_Top_5_Especialidades_Mas_Bonos", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        anios.Add(sqlReader.GetInt32(0));
                    }
                }

            }
            catch (Exception e)
            {
                anios = null;
            }
            finally
            {
                this.closeDB();
            }
            return anios;
        }
    }
}
