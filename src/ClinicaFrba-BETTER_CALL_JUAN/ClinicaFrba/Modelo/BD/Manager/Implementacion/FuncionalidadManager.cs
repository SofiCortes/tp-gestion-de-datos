using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFrba.Modelo.BD.Manager.Implementacion
{
    class FuncionalidadManager : AbstractManager
    {
        public FuncionalidadManager()
            : base(new ConexionBD())
        {
        }

        internal List<Funcionalidad> getTodasLasFuncionalidades()
        {
            List<Funcionalidad> funcionalidades = new List<Funcionalidad>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Todas_Las_Funcionalidades", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Funcionalidad func = new Funcionalidad();
                        func.id = sqlReader.GetDecimal(0);
                        func.descripcion = sqlReader.GetString(1);

                        funcionalidades.Add(func);
                    }
                }
            }
            catch (Exception e)
            {
                funcionalidades = null;
            }
            finally
            {
                this.closeDB();
            }
            return funcionalidades;
        }

        internal void agregarFuncionalidadesAlRol(Rol rol, List<Funcionalidad> funcionalidadesAsignadas)
        {
            try
            {
                RolManager rm = new RolManager();
                rol.id = rm.obtenerRolID(rol.nombre);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();

                this.openDB();
                SqlCommand procedure;

                funcionalidadesAsignadas.ForEach(func =>
                {
                    parametros.Clear();

                    ParametroParaSP parametro3 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, rol.id);
                    ParametroParaSP parametro4 = new ParametroParaSP("funcionalidad_id", SqlDbType.Decimal, func.id);

                    parametros.Add(parametro3);
                    parametros.Add(parametro4);

                    procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Asignar_Funcionalidad_Rol", parametros);
                    procedure.ExecuteNonQuery();

                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.closeDB();
            }
        }

        internal List<Funcionalidad> obtenerFuncionalidadesRol(int id)
        {
            List<Funcionalidad> funcsRol = new List<Funcionalidad>();
            try
            {
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                SqlCommand procedure;

                ParametroParaSP parametro3 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, id);

                parametros.Add(parametro3);
                this.openDB();

                procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Obtener_Funcionalidades_Rol", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Funcionalidad func = new Funcionalidad();
                        func.id = sqlReader.GetDecimal(0);
                        func.descripcion = sqlReader.GetString(1);

                        funcsRol.Add(func);
                    }
                }
            }
            catch (Exception e)
            {
                funcsRol = null;
            }
            finally
            {
                this.closeDB();
            }
            return funcsRol;
        }


        internal void modificarFuncionalidadesDeRol(Rol rol, List<Funcionalidad> funcionalidadesAsignadas)
        {
            try
            {
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                SqlCommand procedure;
                ParametroParaSP parametro3 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, rol.id);
                parametros.Add(parametro3);

                this.openDB();

                procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Borrar_Funcionalidad_Rol", parametros);
                procedure.ExecuteNonQuery();

                funcionalidadesAsignadas.ForEach(func =>
                {
                    parametros.Clear();

                    ParametroParaSP parametro4 = new ParametroParaSP("funcionalidad_id", SqlDbType.Decimal, func.id);

                    parametros.Add(parametro3);
                    parametros.Add(parametro4);

                    procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Asignar_Funcionalidad_Rol", parametros);
                    procedure.ExecuteNonQuery();

                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.closeDB();
            }
        }
    }
}
