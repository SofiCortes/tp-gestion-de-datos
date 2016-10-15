--Me conecto a la base de datos a usar
USE [GD2C2016]
GO

/** CREACION DE SCHEMA **/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'BETTER_CALL_JUAN')
BEGIN
    EXEC ('CREATE SCHEMA BETTER_CALL_JUAN AUTHORIZATION gd')
END
GO
/** FIN CREACION DE SCHEMA**/

/** VALIDACION DE TABLAS **/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles'))
    DROP TABLE BETTER_CALL_JUAN.Roles
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles_Funcionalidades'))
    DROP TABLE BETTER_CALL_JUAN.Roles_Funcionalidades
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Funcionalidades'))
    DROP TABLE BETTER_CALL_JUAN.Funcionalidades
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles_Usuarios'))
    DROP TABLE BETTER_CALL_JUAN.Roles_Usuarios
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Usuarios'))
    DROP TABLE BETTER_CALL_JUAN.Usuarios
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Medicos
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipo_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Tipo_Especialidades
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Especialidades
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Medicos_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Medicos_Especialidades
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Rangos_Atencion'))
    DROP TABLE BETTER_CALL_JUAN.Rangos_Atencion
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Turnos'))
    DROP TABLE BETTER_CALL_JUAN.Turnos
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipos_Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Tipos_Cancelaciones
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Cancelaciones
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Consultas'))
    DROP TABLE BETTER_CALL_JUAN.Consultas
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Operaciones_Compra'))
    DROP TABLE BETTER_CALL_JUAN.Operaciones_Compra
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bonos_Consulta'))
    DROP TABLE BETTER_CALL_JUAN.Bonos_Consulta
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Pacientes
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bajas_Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Bajas_Pacientes
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Planes_Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Planes_Medicos
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cambios_De_Plan'))
    DROP TABLE BETTER_CALL_JUAN.Cambios_De_Plan

/** FIN VALIDACION DE TABLAS **/

/** CREACION DE TABLAS **/

/** FIN CREACION DE TABLAS **/