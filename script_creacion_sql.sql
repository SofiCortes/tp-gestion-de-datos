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
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipos_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Tipos_Especialidades
	
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

CREATE TABLE [BETTER_CALL_JUAN].[Funcionalidades] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [descripcion] VARCHAR(255),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Usuarios] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [username] VARCHAR(255),
  [password] VARCHAR(255),
  [intentos_fallidos] SMALLINT,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Roles] (
  [id] SMALLINT IDENTITY(1,1),
  [nombre] VARCHAR(255),
  [habilitado] BIT,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Operaciones_Compra] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [cant_bonos] NUMERIC(4,0),
  [monto_total] NUMERIC(18,0),
  [paciente_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Turnos] (
  [numero] NUMERIC(18,0) IDENTITY(1,1),
  [fecha_hora] DATETIME,
  [paciente_id] NUMERIC(18,0),
  [medico_especialidad_id] NUMERIC(18,0),
  [cancelacion_id] NUMERIC(18,0),
  PRIMARY KEY ([numero])
);

CREATE TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [medico_id] NUMERIC(18,0),
  [especialidad_cod] NUMERIC(18,0),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Cancelaciones] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [tipo_cancelacion_id] NUMERIC(18,0),
  [motivo] VARCHAR(255),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] (
  [user_id] NUMERIC(18,0),
  [rol_id] SMALLINT,
  PRIMARY KEY ([user_id], [rol_id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Especialidades] (
  [codigo] NUMERIC(18,0) IDENTITY(1,1),
  [descripcion] VARCHAR(255),
  [tipo_especialidad_cod] NUMERIC(18,0),
  PRIMARY KEY ([codigo])
);

CREATE TABLE [BETTER_CALL_JUAN].[Tipos_Cancelaciones] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nombre] VARCHAR(255),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Consultas] (
  [id] INT IDENTITY(1,1),
  [sintomas] VARCHAR(255),
  [enfermedades] VARCHAR(255),
  [turno_numero] NUMERIC(18,0),
  [fecha_hora_llegada] DATETIME,
  [fecha_hora_atencion] DATETIME,
  [bono_consulta_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Bajas_Pacientes] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [paciente_id] NUMERIC(18,0),
  [fecha_baja] DATETIME,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Tipos_Especialidades] (
  [cod_especialidad] NUMERIC(18,0) IDENTITY(1,1),
  [descripcion] VARCHAR(255),
  PRIMARY KEY ([cod_especialidad])
);

CREATE TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] (
  [rol_id] SMALLINT,
  [funcionalidad_id] NUMERIC(18,0),
  PRIMARY KEY ([rol_id],[funcionalidad_id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Bonos_Consulta] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [fecha_compra] DATETIME,
  [fecha_impresion] DATETIME,
  [numero_consulta_paciente] NUMERIC(18,0),
  [paciente_compra_id] NUMERIC(18,0),
  [paciente_usa_id] NUMERIC(18,0),
  [plan_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Planes_Medicos] (
  [codigo] NUMERIC(18,0) IDENTITY(1,1),
  [descripcion] VARCHAR(255),
  [precio_bono_consulta] NUMERIC(18,0),
  [precio_bono_farmacia] NUMERIC(18,0),
  PRIMARY KEY ([codigo])
);

CREATE TABLE [BETTER_CALL_JUAN].[Medicos] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nombre] VARCHAR(255),
  [apellido] VARCHAR(255),
  [tipo_doc] VARCHAR(100),
  [nro_doc] NUMERIC(18,0),
  [direccion] VARCHAR(255),
  [telefono] NUMERIC(18,0),
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME,
  [sexo] CHAR(1),
  [matricula] NUMERIC(18,0),
  [usuario_id] NUMERIC(18,0),
  PRIMARY KEY ([id]),
  UNIQUE([tipo_doc], [nro_doc])
);

CREATE TABLE [BETTER_CALL_JUAN].[Pacientes] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nro_raiz] NUMERIC(18,0),
  [nro_personal] NUMERIC(2,0),
  [nombre] VARCHAR(255),
  [apellido] VARCHAR(255),
  [tipo_doc] VARCHAR(100),
  [nro_doc] NUMERIC(18,0),
  [direccion] VARCHAR(255),
  [telefono] NUMERIC(18,0),
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME,
  [sexo] CHAR,
  [estado_civil] VARCHAR(100),
  [cantidad_familiares] INT,
  [plan_medico_cod] NUMERIC(18,0),
  [habilitado] BIT,
  [nro_ultima_consulta] NUMERIC(18,0),
  [usuario_id] NUMERIC(18,0),
  PRIMARY KEY ([id]),
  UNIQUE([tipo_doc], [nro_doc]),
  UNIQUE([nro_raiz], [nro_personal])
);

CREATE TABLE [BETTER_CALL_JUAN].[Cambios_De_Plan] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [paciente_id] NUMERIC(18,0),
  [fecha_cambio] DATETIME,
  [motivo_cambio] VARCHAR(500),
  [plan_anterior_id] NUMERIC(18,0),
  [plan_nuevo_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Rangos_Atencion] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [dia_semana] NUMERIC(1,0),
  [hora_desde] TIME,
  [hora_hasta] TIME,
  [medico_especialidad_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);


ALTER TABLE [BETTER_CALL_JUAN].[Pacientes] ADD CONSTRAINT plan_medico_cod_pacientes FOREIGN KEY (plan_medico_cod) REFERENCES [BETTER_CALL_JUAN].[Planes_Medicos](codigo)
ALTER TABLE [BETTER_CALL_JUAN].[Pacientes] ADD CONSTRAINT usuario_id_pacientes FOREIGN KEY (usuario_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)

ALTER TABLE [BETTER_CALL_JUAN].[Bajas_Pacientes] ADD CONSTRAINT paciente_id_bajas_pacientes FOREIGN KEY (paciente_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)

ALTER TABLE [BETTER_CALL_JUAN].[Cambios_De_Plan] ADD CONSTRAINT paciente_id_cambio_plan FOREIGN KEY (paciente_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)
ALTER TABLE [BETTER_CALL_JUAN].[Cambios_De_Plan] ADD CONSTRAINT plan_anterior_id_cambio_plan FOREIGN KEY (plan_anterior_id) REFERENCES [BETTER_CALL_JUAN].[Planes_Medicos](codigo)
ALTER TABLE [BETTER_CALL_JUAN].[Cambios_De_Plan] ADD CONSTRAINT plan_nuevo_id_cambio_plan FOREIGN KEY (plan_nuevo_id) REFERENCES [BETTER_CALL_JUAN].[Planes_Medicos](codigo)

ALTER TABLE [BETTER_CALL_JUAN].[Bonos_Consulta] ADD CONSTRAINT paciente_compra_id_bono_consulta FOREIGN KEY (paciente_compra_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)
ALTER TABLE [BETTER_CALL_JUAN].[Bonos_Consulta] ADD CONSTRAINT paciente_usa_id_bono_consulta FOREIGN KEY (paciente_usa_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)
ALTER TABLE [BETTER_CALL_JUAN].[Bonos_Consulta] ADD CONSTRAINT plan_id_bono_consulta FOREIGN KEY (plan_id) REFERENCES [BETTER_CALL_JUAN].[Planes_Medicos](codigo)

ALTER TABLE [BETTER_CALL_JUAN].[Consultas] ADD CONSTRAINT turno_numero_consulta FOREIGN KEY (turno_numero) REFERENCES [BETTER_CALL_JUAN].[Turnos](numero)
ALTER TABLE [BETTER_CALL_JUAN].[Consultas] ADD CONSTRAINT bono_consulta_id_consulta FOREIGN KEY (bono_consulta_id) REFERENCES [BETTER_CALL_JUAN].[Bonos_Consulta](id)

ALTER TABLE [BETTER_CALL_JUAN].[Operaciones_Compra] ADD CONSTRAINT paciente_id_operacion_compra FOREIGN KEY (paciente_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)

ALTER TABLE [BETTER_CALL_JUAN].[Turnos] ADD CONSTRAINT paciente_id_turno FOREIGN KEY (paciente_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)
ALTER TABLE [BETTER_CALL_JUAN].[Turnos] ADD CONSTRAINT medico_especialidad_id_turno FOREIGN KEY (medico_especialidad_id) REFERENCES [BETTER_CALL_JUAN].[Medicos_Especialidades](id)
ALTER TABLE [BETTER_CALL_JUAN].[Turnos] ADD CONSTRAINT cancelacion_id_turno FOREIGN KEY (cancelacion_id) REFERENCES [BETTER_CALL_JUAN].[Cancelaciones](id)

ALTER TABLE [BETTER_CALL_JUAN].[Cancelaciones] ADD CONSTRAINT tipo_cancelacion_id_cancelacion FOREIGN KEY (tipo_cancelacion_id) REFERENCES [BETTER_CALL_JUAN].[Tipos_Cancelaciones](id)

ALTER TABLE [BETTER_CALL_JUAN].[Rangos_Atencion] ADD CONSTRAINT medico_especialidad_id_rango_atencion FOREIGN KEY (medico_especialidad_id) REFERENCES [BETTER_CALL_JUAN].[Medicos_Especialidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Especialidades] ADD CONSTRAINT tipo_especialidad_cod_especialidades FOREIGN KEY (tipo_especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Tipos_Especialidades](cod_especialidad)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos] ADD CONSTRAINT usuario_id_medicos FOREIGN KEY (usuario_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT user_id_roles_usuarios FOREIGN KEY (user_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT rol_id_roles_usuarios FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT rol_id_roles_funcionalidades FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT funcionalidad_id_roles_funcionalidades FOREIGN KEY (funcionalidad_id) REFERENCES [BETTER_CALL_JUAN].[Funcionalidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT medico_id_medicos_especialidades FOREIGN KEY (medico_id) REFERENCES [BETTER_CALL_JUAN].[Medicos](id)
ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT especialidad_cod_medicos_especialidades FOREIGN KEY (especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Especialidades](codigo)


/** FIN CREACION DE TABLAS **/
