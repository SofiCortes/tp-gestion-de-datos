using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class ProfesionalManager : AbstractManager
    {
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

        internal List<Medico> buscarMedicosPorFiltro(string queryNombre, string queryApellido, string queryDocumento, string queryMatricula, decimal especialidadCodigo)
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nombre", SqlDbType.VarChar, queryNombre);
                ParametroParaSP parametro2 = new ParametroParaSP("apellido", SqlDbType.VarChar, queryApellido);
                ParametroParaSP parametro3 = new ParametroParaSP("documento", SqlDbType.VarChar, queryDocumento);
                ParametroParaSP parametro4 = new ParametroParaSP("matricula", SqlDbType.VarChar, queryMatricula);
                ParametroParaSP parametro5 = new ParametroParaSP("especialidad_cod", SqlDbType.Decimal, especialidadCodigo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Medicos_Con_Filtros", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {

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
    }
}
