using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicaFrba
{
    class EspecialidadMedicaManager : AbstractManager
    {
        public EspecialidadMedicaManager()
            : base(new ConexionBD())
        {
        }


        internal List<Especialidad> buscarConFiltros(string query, decimal tipoEspecialidadCodigo)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("descripcion", SqlDbType.VarChar, query);
                ParametroParaSP parametro2 = new ParametroParaSP("tipo_especialidad_cod", SqlDbType.Decimal, tipoEspecialidadCodigo);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Especialidades_Filtros", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Especialidad especialidad = new Especialidad();

                        especialidad.codigo = sqlReader.GetDecimal(0);
                        especialidad.descripcion = sqlReader.GetString(1);

                        TipoEspecialidad tipoEspecialidad = new TipoEspecialidad();
                        tipoEspecialidad.descripcion = sqlReader.GetString(2);
                        especialidad.tipoEspecialidad = tipoEspecialidad;

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

        internal List<Especialidad> findAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Especialidades", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Especialidad especialidad = new Especialidad();

                        especialidad.codigo = sqlReader.GetDecimal(0);
                        especialidad.descripcion = sqlReader.GetString(1);

                        TipoEspecialidad tipoEspecialidad = new TipoEspecialidad();
                        tipoEspecialidad.descripcion = sqlReader.GetString(2);
                        especialidad.tipoEspecialidad = tipoEspecialidad;

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
    }
}
