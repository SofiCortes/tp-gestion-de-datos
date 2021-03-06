﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClinicaFrba
{
    class PacienteManager : AbstractManager
    {
        public PacienteManager()
            : base(new ConexionBD())
        {
        }


        internal List<Paciente> findAll()
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Afiliados", null);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Paciente paciente = new Paciente();
                        paciente.id = sqlReader.GetDecimal(0);
                        paciente.nroRaiz = !sqlReader.IsDBNull(1) ? sqlReader.GetDecimal(1) : 0;
                        paciente.nroPersonal = sqlReader.GetDecimal(2);
                        paciente.nombre = sqlReader.GetString(3);
                        paciente.apellido = sqlReader.GetString(4);
                        paciente.tipoDoc = sqlReader.GetString(5);
                        paciente.nroDoc = sqlReader.GetDecimal(6);
                        paciente.direccion = sqlReader.GetString(7);
                        paciente.telefono = sqlReader.GetDecimal(8);
                        paciente.mail = sqlReader.GetString(9);
                        paciente.fechaNacimiento = sqlReader.GetDateTime(10);
                        paciente.sexo = !sqlReader.IsDBNull(11) ? sqlReader.GetString(11).ElementAt(0) : 'N';
                        paciente.estadoCivil = !sqlReader.IsDBNull(12) ? sqlReader.GetString(12) : "";
                        paciente.cantidadFamiliares = sqlReader.GetInt32(13);
                        paciente.planMedicoCod = sqlReader.GetDecimal(14);
                        paciente.planMedicoDescripcion = sqlReader.GetString(15);
                        paciente.habilitado = sqlReader.GetBoolean(16);
                        paciente.nroUltimaConsulta = sqlReader.GetDecimal(17);
                        paciente.usuarioId = !sqlReader.IsDBNull(18) ? sqlReader.GetDecimal(18) : 0;

                        pacientes.Add(paciente);
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

        internal List<Paciente> buscarAfiliadosPorNombreYPlan(string queryNombre, string queryApellido, decimal planCode)
        {
            List<Paciente> pacientes = new List<Paciente>();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nombre", SqlDbType.VarChar, queryNombre);
                ParametroParaSP parametro2 = new ParametroParaSP("apellido", SqlDbType.VarChar, queryApellido);
                ParametroParaSP parametro3 = new ParametroParaSP("plan_codigo", SqlDbType.Decimal, planCode);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Afiliados_Filtros", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        Paciente paciente = new Paciente();
                        paciente.id = sqlReader.GetDecimal(0);
                        paciente.nroRaiz = !sqlReader.IsDBNull(1) ? sqlReader.GetDecimal(1) : 0;
                        paciente.nroPersonal = sqlReader.GetDecimal(2);
                        paciente.nombre = sqlReader.GetString(3);
                        paciente.apellido = sqlReader.GetString(4);
                        paciente.tipoDoc = sqlReader.GetString(5);
                        paciente.nroDoc = sqlReader.GetDecimal(6);
                        paciente.direccion = sqlReader.GetString(7);
                        paciente.telefono = sqlReader.GetDecimal(8);
                        paciente.mail = sqlReader.GetString(9);
                        paciente.fechaNacimiento = sqlReader.GetDateTime(10);
                        paciente.sexo = !sqlReader.IsDBNull(11) ? sqlReader.GetString(11).ElementAt(0) : 'N';
                        paciente.estadoCivil = !sqlReader.IsDBNull(12) ? sqlReader.GetString(12) : "";
                        paciente.cantidadFamiliares = sqlReader.GetInt32(13);
                        paciente.planMedicoCod = sqlReader.GetDecimal(14);
                        paciente.planMedicoDescripcion = sqlReader.GetString(15);
                        paciente.habilitado = sqlReader.GetBoolean(16);
                        paciente.nroUltimaConsulta = sqlReader.GetDecimal(17);

                        pacientes.Add(paciente);
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

        internal bool agregarAfiliado(Paciente paciente)
        {
            bool agregoAfiliado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nombre", SqlDbType.VarChar, paciente.nombre);
                ParametroParaSP parametro2 = new ParametroParaSP("apellido", SqlDbType.VarChar, paciente.apellido);
                ParametroParaSP parametro3 = new ParametroParaSP("tipo_doc", SqlDbType.VarChar, paciente.tipoDoc);
                ParametroParaSP parametro4 = new ParametroParaSP("nro_doc", SqlDbType.Decimal, paciente.nroDoc);
                ParametroParaSP parametro5 = new ParametroParaSP("direccion", SqlDbType.VarChar, paciente.direccion);
                ParametroParaSP parametro6 = new ParametroParaSP("telefono", SqlDbType.Decimal, paciente.telefono);
                ParametroParaSP parametro7 = new ParametroParaSP("mail", SqlDbType.VarChar, paciente.mail);
                ParametroParaSP parametro8 = new ParametroParaSP("fecha_nac", SqlDbType.DateTime, paciente.fechaNacimiento);
                ParametroParaSP parametro9 = new ParametroParaSP("sexo", SqlDbType.Char, paciente.sexo);
                ParametroParaSP parametro10 = new ParametroParaSP("estado_civil", SqlDbType.VarChar, paciente.estadoCivil);
                ParametroParaSP parametro11 = new ParametroParaSP("plan_medico_cod", SqlDbType.Decimal, paciente.planMedico.codigo);
                ParametroParaSP parametro12 = new ParametroParaSP("nro_raiz_nuevo", SqlDbType.Decimal);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);
                parametros.Add(parametro7);
                parametros.Add(parametro8);
                parametros.Add(parametro9);
                parametros.Add(parametro10);
                parametros.Add(parametro11);
                parametros.Add(parametro12);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Alta_Afiliado_Nuevo_Grupo", parametros);
                procedure.ExecuteNonQuery();

                decimal nroRaizNuevoAfiliado = Convert.ToDecimal(procedure.Parameters["@nro_raiz_nuevo"].Value);

                if (paciente.familiares != null && paciente.familiares.Count > 0)
                {
                    foreach(Paciente familiar in paciente.familiares) 
                    {
                        agregoAfiliado &= this.guardarFamiliar(familiar, nroRaizNuevoAfiliado, paciente.planMedico.codigo);
                    }
                }
            }
            catch (SqlException e)
            {
                agregoAfiliado = false;
            }
            finally
            {
                this.closeDB();
            }

            return agregoAfiliado;
        }

        private bool guardarFamiliar(Paciente paciente, decimal nroRaizNuevoAfiliado, decimal planMedicoCod)
        {
            bool agregoAfiliado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nro_raiz", SqlDbType.Decimal, nroRaizNuevoAfiliado);
                ParametroParaSP parametro2 = new ParametroParaSP("nombre", SqlDbType.VarChar, paciente.nombre);
                ParametroParaSP parametro3 = new ParametroParaSP("apellido", SqlDbType.VarChar, paciente.apellido);
                ParametroParaSP parametro4 = new ParametroParaSP("tipo_doc", SqlDbType.VarChar, paciente.tipoDoc);
                ParametroParaSP parametro5 = new ParametroParaSP("nro_doc", SqlDbType.Decimal, paciente.nroDoc);
                ParametroParaSP parametro6 = new ParametroParaSP("direccion", SqlDbType.VarChar, paciente.direccion);
                ParametroParaSP parametro7 = new ParametroParaSP("telefono", SqlDbType.Decimal, paciente.telefono);
                ParametroParaSP parametro8 = new ParametroParaSP("mail", SqlDbType.VarChar, paciente.mail);
                ParametroParaSP parametro9 = new ParametroParaSP("fecha_nac", SqlDbType.DateTime, paciente.fechaNacimiento);
                ParametroParaSP parametro10 = new ParametroParaSP("sexo", SqlDbType.Char, paciente.sexo);
                ParametroParaSP parametro11 = new ParametroParaSP("estado_civil", SqlDbType.VarChar, paciente.estadoCivil);
                ParametroParaSP parametro12 = new ParametroParaSP("plan_medico_cod", SqlDbType.Decimal, planMedicoCod);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);
                parametros.Add(parametro7);
                parametros.Add(parametro8);
                parametros.Add(parametro9);
                parametros.Add(parametro10);
                parametros.Add(parametro11);
                parametros.Add(parametro12);

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Alta_Afiliado_Familiar", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                agregoAfiliado = false;
            }
            finally
            {
                this.closeDB();
            }

            return agregoAfiliado;
        }

        internal bool puedeGuardarseAfiliado(string tipoDoc, decimal nroDoc)
        {
            bool puedeGuardarse;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("tipo_doc", SqlDbType.VarChar, tipoDoc);
                ParametroParaSP parametro2 = new ParametroParaSP("nro_doc", SqlDbType.Decimal, nroDoc);
                ParametroParaSP parametro3 = new ParametroParaSP("retorno", SqlDbType.SmallInt); 
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Validar_Documento", parametros);
                procedure.ExecuteNonQuery();

                int retorno = Convert.ToInt16(procedure.Parameters["@retorno"].Value);
                puedeGuardarse = retorno == 1;
            }
            catch (SqlException e)
            {
                puedeGuardarse = false;
            }
            finally
            {
                this.closeDB();
            }

            return puedeGuardarse;
        }

        internal Paciente buscarAfiliadoPorTipoyNroDoc(string tipoDoc, decimal nroDoc)
        {
            Paciente paciente = new Paciente();
            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("tipo_doc", SqlDbType.VarChar, tipoDoc);
                ParametroParaSP parametro2 = new ParametroParaSP("nro_doc", SqlDbType.Decimal, nroDoc);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Buscar_Afiliados_Por_Documento", parametros);
                SqlDataReader sqlReader = procedure.ExecuteReader();

                if (sqlReader.HasRows)
                {
                    while (sqlReader.Read())
                    {
                        paciente.id = sqlReader.GetDecimal(0);
                        paciente.nroRaiz = !sqlReader.IsDBNull(1) ? sqlReader.GetDecimal(1) : 0;
                        paciente.nroPersonal = sqlReader.GetDecimal(2);
                        paciente.nombre = sqlReader.GetString(3);
                        paciente.apellido = sqlReader.GetString(4);
                        paciente.tipoDoc = sqlReader.GetString(5);
                        paciente.nroDoc = sqlReader.GetDecimal(6);
                        paciente.direccion = sqlReader.GetString(7);
                        paciente.telefono = sqlReader.GetDecimal(8);
                        paciente.mail = sqlReader.GetString(9);
                        paciente.fechaNacimiento = sqlReader.GetDateTime(10);
                        paciente.sexo = !sqlReader.IsDBNull(11) ? sqlReader.GetString(11).ElementAt(0) : 'N';
                        paciente.estadoCivil = !sqlReader.IsDBNull(12) ? sqlReader.GetString(12) : "";
                        paciente.cantidadFamiliares = sqlReader.GetInt32(13);
                        paciente.planMedicoCod = sqlReader.GetDecimal(14);
                        paciente.nroUltimaConsulta = sqlReader.GetDecimal(15);
                    }
                }
            }
            catch (Exception e)
            {
                paciente = null;
            }
            finally
            {
                this.closeDB();
            }
            return paciente;
        }

        internal bool modificarAfiliado(decimal planMedicoCodViejo, Paciente paciente, string motivoCambioPlan)
        {
            bool modificoAfiliado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("paciente_id", SqlDbType.Decimal, paciente.id);
                ParametroParaSP parametro3 = new ParametroParaSP("tipo_doc", SqlDbType.VarChar, paciente.tipoDoc);
                ParametroParaSP parametro4 = new ParametroParaSP("nro_doc", SqlDbType.Decimal, paciente.nroDoc);
                ParametroParaSP parametro5 = new ParametroParaSP("direccion", SqlDbType.VarChar, paciente.direccion);
                ParametroParaSP parametro6 = new ParametroParaSP("telefono", SqlDbType.Decimal, paciente.telefono);
                ParametroParaSP parametro7 = new ParametroParaSP("mail", SqlDbType.VarChar, paciente.mail);
                ParametroParaSP parametro8 = new ParametroParaSP("sexo", SqlDbType.Char, paciente.sexo);
                ParametroParaSP parametro9 = new ParametroParaSP("estado_civil", SqlDbType.VarChar, paciente.estadoCivil);
                ParametroParaSP parametro10 = new ParametroParaSP("plan_viejo_id", SqlDbType.Decimal, planMedicoCodViejo);
                ParametroParaSP parametro11 = new ParametroParaSP("plan_nuevo_id", SqlDbType.Decimal, paciente.planMedicoCod);
                ParametroParaSP parametro12 = new ParametroParaSP("motivo", SqlDbType.VarChar, motivoCambioPlan);
                ParametroParaSP parametro13 = new ParametroParaSP("fecha_hoy", SqlDbType.DateTime, ConfiguracionApp.getInstance().fechaActual);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro3);
                parametros.Add(parametro4);
                parametros.Add(parametro5);
                parametros.Add(parametro6);
                parametros.Add(parametro7);
                parametros.Add(parametro8);
                parametros.Add(parametro9);
                parametros.Add(parametro10);
                parametros.Add(parametro11);
                parametros.Add(parametro12);
                parametros.Add(parametro13);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Modificar_Afiliado", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                modificoAfiliado = false;
            }
            finally
            {
                this.closeDB();
            }

            return modificoAfiliado;
        }

        internal bool eliminarAfiliado(Paciente pacienteAEliminar)
        {
            bool eliminarAfiliado = true;

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("id_paciente", SqlDbType.Decimal, pacienteAEliminar.id);
                ParametroParaSP parametro2 = new ParametroParaSP("fecha_hoy", SqlDbType.DateTime, ConfiguracionApp.getInstance().fechaActual);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Baja_Afiliado", parametros);
                procedure.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                eliminarAfiliado = false;
            }
            finally
            {
                this.closeDB();
            }

            return eliminarAfiliado;
        }

        internal decimal getPacienteIdSegunNroAfiliado(decimal nroAfiliado)
        {
            decimal paciente_id;

            int lengthNroAfiliado = nroAfiliado.ToString().Length;

            decimal nro_raiz = decimal.Parse(nroAfiliado.ToString().Substring(0,lengthNroAfiliado-2));
            decimal nro_personal = decimal.Parse(nroAfiliado.ToString().Substring(lengthNroAfiliado-2,2));

            try
            {
                ParametroParaSP parametro1 = new ParametroParaSP("nro_raiz", SqlDbType.Decimal, nro_raiz);
                ParametroParaSP parametro2 = new ParametroParaSP("nro_personal", SqlDbType.Decimal, nro_personal);
                ParametroParaSP parametro3 = new ParametroParaSP("paciente_id", SqlDbType.Decimal);
                List<ParametroParaSP> parametros = new List<ParametroParaSP>();
                parametros.Add(parametro1);
                parametros.Add(parametro2);
                parametros.Add(parametro3);

                this.openDB();

                SqlCommand procedure = this.createCallableProcedure("BETTER_CALL_JUAN.Procedure_Get_Paciente_Id_Segun_Nro_Afiliado", parametros);
                procedure.ExecuteNonQuery();

                paciente_id = Convert.ToInt64(procedure.Parameters["@paciente_id"].Value);
                
            }
            catch (SqlException e)
            {
                paciente_id = 0;
            }
            finally
            {
                this.closeDB();
            }

            return paciente_id;
        }
    }
}
