﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClinicaFrba.Modelo.BD.Manager.Implementacion;
using System.Windows.Forms;

namespace ClinicaFrba
{
    class RolManager : AbstractManager
    {
        public RolManager()
            : base(new ConexionBD())
        {
        }

        public List<string> getFuncionalidadesDeRol(string rol)
        {
            List<string> funcionalidades = new List<string>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol", SqlDbType.VarChar, rol);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Funcionalidades_De_Rol", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        funcionalidades.Add(sqlReader.GetString(0));
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

        internal List<Rol> buscarTodos()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Todos_Los_Roles", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Rol rol = new Rol();
                        rol.id = sqlReader.GetInt16(0);
                        rol.nombre = sqlReader.GetString(1);
                        rol.habilitado = sqlReader.GetBoolean(2);

                        roles.Add(rol);
                    }
                }
            }
            catch (Exception e)
            {
                roles = null;
            }
            finally
            {
                this.closeDB();
            }
            return roles;
        }

        internal void crearRol(Rol rol, List<Funcionalidad> funcionalidadesAsignadas)
        {
            try
            {
                FuncionalidadManager fm = new FuncionalidadManager();
                ParametroParaSP parametro1 = new ParametroParaSP("nombre", SqlDbType.VarChar, rol.nombre);
                ParametroParaSP parametro2 = new ParametroParaSP("retorno", SqlDbType.SmallInt);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Crear_Rol", parametros);
                procedure.ExecuteNonQuery();

                int ok = Convert.ToInt32(procedure.Parameters["@retorno"].Value);
                if (ok == 1)
                {
                    fm.agregarFuncionalidadesAlRol(rol, funcionalidadesAsignadas);
                }
                else
                {
                    AltaRol ar = new AltaRol();
                    ar.ShowErrorDialog("Ya existe el rol ingresado en el sistema");
                }
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

        internal int obtenerRolID(string nombre)
        {
            int id = 0;
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nombre", SqlDbType.VarChar, nombre);
                ParametroParaSP parametro2 = new ParametroParaSP("id", SqlDbType.SmallInt);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Obtener_Rol_Id", parametros);
                procedure.ExecuteNonQuery();

                id = Convert.ToInt32(procedure.Parameters["@id"].Value);

            }
            catch (Exception e)
            {
                id = 0;
            }
            finally
            {
                this.closeDB();
            }

            return id;
        }

        internal void modificarRol(Rol rol, List<Funcionalidad> funcionalidadesAsignadas)
        {
            try
            {
                FuncionalidadManager fm = new FuncionalidadManager();
                ParametroParaSP parametro1 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, rol.id);
                ParametroParaSP parametro2 = new ParametroParaSP("nombre", SqlDbType.VarChar, rol.nombre);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Modificar_Rol", parametros);
                procedure.ExecuteNonQuery();

                fm.modificarFuncionalidadesDeRol(rol, funcionalidadesAsignadas);

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

        internal int obtenerEstadoHabilitacionRol(int id)
        {
            int habilitado = -1;
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, id);
                ParametroParaSP parametro2 = new ParametroParaSP("habilitado", SqlDbType.SmallInt);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Obtener_Estado_Habilitado_Rol", parametros);
                procedure.ExecuteNonQuery();

                habilitado = Convert.ToInt32(procedure.Parameters["@habilitado"].Value);
            }
            catch (Exception e)
            {
                habilitado = -1;
            }
            finally
            {
                this.closeDB();
            }

            return habilitado;
        }

        internal void habilitarRol(int id)
        {
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol_id", SqlDbType.VarChar, id);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Habilitar_Rol", parametros);
                procedure.ExecuteNonQuery();
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

        internal void eliminarRol(Rol rol)
        {
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol_id", SqlDbType.SmallInt, rol.id);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Eliminar_Rol", parametros);
                procedure.ExecuteNonQuery();
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

        internal List<Rol> buscarTodosHabilitados()
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Todos_Los_Roles", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Rol rol = new Rol();
                        rol.id = sqlReader.GetInt16(0);
                        rol.nombre = sqlReader.GetString(1);
                        rol.habilitado = sqlReader.GetBoolean(2);

                        if (rol.habilitado)
                        {
                            roles.Add(rol);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                roles = null;
            }
            finally
            {
                this.closeDB();
            }
            return roles;
        }

        internal List<Rol> buscarPorNombre(string textoABuscar)
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol_nombre", SqlDbType.VarChar, textoABuscar);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Rol", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Rol rol = new Rol();
                        rol.id = sqlReader.GetInt16(0);
                        rol.nombre = sqlReader.GetString(1);
                        rol.habilitado = sqlReader.GetBoolean(2);

                        roles.Add(rol);
                    }
                }
            }
            catch (Exception e)
            {
                roles = null;
            }
            finally
            {
                this.closeDB();
            }
            return roles;
        }

        internal List<Rol> buscarPorNombreHabilitados(string textoABuscar)
        {
            List<Rol> roles = new List<Rol>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("rol_nombre", SqlDbType.VarChar, textoABuscar);

                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Rol_Habilitado", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Rol rol = new Rol();
                        rol.id = sqlReader.GetInt16(0);
                        rol.nombre = sqlReader.GetString(1);
                        rol.habilitado = sqlReader.GetBoolean(2);

                        roles.Add(rol);
                    }
                }
            }
            catch (Exception e)
            {
                roles = null;
            }
            finally
            {
                this.closeDB();
            }
            return roles;
        }
    }
}
