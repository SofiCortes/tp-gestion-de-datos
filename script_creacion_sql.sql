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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bajas_Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Bajas_Pacientes
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cambios_De_Plan'))
    DROP TABLE BETTER_CALL_JUAN.Cambios_De_Plan

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Consultas'))
    DROP TABLE BETTER_CALL_JUAN.Consultas

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Operaciones_Compra'))
    DROP TABLE BETTER_CALL_JUAN.Operaciones_Compra

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Rangos_Atencion'))
    DROP TABLE BETTER_CALL_JUAN.Rangos_Atencion

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles_Funcionalidades'))
    DROP TABLE BETTER_CALL_JUAN.Roles_Funcionalidades

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles_Usuarios'))
    DROP TABLE BETTER_CALL_JUAN.Roles_Usuarios

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Turnos'))
    DROP TABLE BETTER_CALL_JUAN.Turnos
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bonos_Consulta'))
    DROP TABLE BETTER_CALL_JUAN.Bonos_Consulta

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Cancelaciones

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Funcionalidades'))
    DROP TABLE BETTER_CALL_JUAN.Funcionalidades

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Medicos_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Medicos_Especialidades

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Pacientes

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Planes_Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Planes_Medicos

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles'))
    DROP TABLE BETTER_CALL_JUAN.Roles
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipos_Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Tipos_Cancelaciones

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Medicos

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Especialidades

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipos_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Tipos_Especialidades

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Usuarios'))
    DROP TABLE BETTER_CALL_JUAN.Usuarios

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
  [codigo] NUMERIC(18,0),
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
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255),
  PRIMARY KEY ([codigo])
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
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255),
  [precio_bono_consulta] NUMERIC(18,0),
  [precio_bono_farmacia] NUMERIC(18,0),
  PRIMARY KEY ([codigo])
);

CREATE TABLE [BETTER_CALL_JUAN].[Medicos] (
  [matricula] NUMERIC(18,0) IDENTITY(1,1),
  [nombre] VARCHAR(255),
  [apellido] VARCHAR(255),
  [tipo_doc] VARCHAR(100),
  [nro_doc] NUMERIC(18,0),
  [direccion] VARCHAR(255),
  [telefono] NUMERIC(18,0),
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME,
  [sexo] CHAR(1),
  [usuario_id] NUMERIC(18,0),
  PRIMARY KEY ([matricula]),
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
  --UNIQUE([nro_raiz], [nro_personal])
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

/** FIN CREACION DE TABLAS **/

/** MIGRACION **/

/* Tabla Pacientes */

--Nros Ultimas Consultas
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.nrosUltimasConsultasPacientes'))
    DROP TABLE BETTER_CALL_JUAN.nrosUltimasConsultasPacientes
	

CREATE TABLE [BETTER_CALL_JUAN].[ConsultasPacientes] (
	[Paciente_Dni] NUMERIC(18,0),
	[Bono_Consulta_Numero] NUMERIC(18,0)
);

INSERT INTO BETTER_CALL_JUAN.ConsultasPacientes
SELECT Paciente_Dni, Bono_Consulta_Numero
FROM gd_esquema.Maestra
WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL AND Paciente_Dni IS NOT NULL AND Paciente_Direccion IS NOT NULL 
AND Paciente_Telefono IS NOT NULL AND Paciente_Mail IS NOT NULL AND Paciente_Fecha_Nac IS NOT NULL AND Plan_Med_Codigo IS NOT NULL 
AND Plan_Med_Descripcion IS NOT NULL AND Plan_Med_Precio_Bono_Consulta IS NOT NULL AND Plan_Med_Precio_Bono_Farmacia IS NOT NULL 
AND Turno_Numero IS NOT NULL AND Turno_Fecha IS NOT NULL AND Consulta_Sintomas IS NOT NULL AND Consulta_Enfermedades IS NOT NULL 
AND Medico_Nombre IS NOT NULL AND Medico_Apellido IS NOT NULL AND Medico_Dni IS NOT NULL AND Medico_Direccion IS NOT NULL 
AND Medico_Telefono IS NOT NULL AND Medico_Mail IS NOT NULL AND Medico_Fecha_Nac IS NOT NULL AND Especialidad_Codigo IS NOT NULL 
AND Especialidad_Descripcion IS NOT NULL AND Tipo_Especialidad_Codigo IS NOT NULL AND Tipo_Especialidad_Descripcion IS NOT NULL 
AND Compra_Bono_Fecha IS NULL AND Bono_Consulta_Fecha_Impresion IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
ORDER BY 1 ASC

--INSERT PACIENTES
INSERT INTO BETTER_CALL_JUAN.Pacientes (nombre, apellido, tipo_doc,nro_doc,direccion,telefono,mail,fecha_nac,plan_medico_cod,habilitado,nro_ultima_consulta)
SELECT DISTINCT Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, 
Plan_Med_Codigo, 1, (SELECT COUNT(DISTINCT cp.Bono_Consulta_Numero) FROM BETTER_CALL_JUAN.ConsultasPacientes cp WHERE cp.Paciente_Dni = m.Paciente_Dni GROUP BY cp.Paciente_Dni) AS nroUltimaConsulta
FROM gd_esquema.Maestra m
GROUP BY Paciente_Nombre, Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Plan_Med_Codigo

DROP TABLE BETTER_CALL_JUAN.ConsultasPacientes

/* Tabla Medicos */
INSERT INTO BETTER_CALL_JUAN.Medicos(nombre, apellido, tipo_doc, nro_doc, direccion, telefono, mail, fecha_nac)
SELECT DISTINCT Medico_Nombre, Medico_Apellido, 'DNI', Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL

/* Tabla Planes Medicos */
INSERT INTO BETTER_CALL_JUAN.Planes_Medicos(codigo, descripcion, precio_bono_consulta, precio_bono_farmacia)
SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra

/* Tabla Especialidades */
INSERT INTO BETTER_CALL_JUAN.Especialidades (codigo,descripcion,tipo_especialidad_cod)
SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra
WHERE Especialidad_Codigo IS NOT NULL

/* Tabla Tipos Especialidades */
INSERT INTO BETTER_CALL_JUAN.Tipos_Especialidades (codigo,descripcion)
SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL

/* Tabla Medicos Especialidades */

INSERT INTO BETTER_CALL_JUAN.Medicos_Especialidades(medico_id, especialidad_cod)
SELECT DISTINCT med.matricula, Especialidad_Codigo 
FROM gd_esquema.Maestra maestra JOIN BETTER_CALL_JUAN.Medicos med ON (maestra.Medico_Dni=med.nro_doc)
ORDER BY med.matricula, Especialidad_Codigo

/* Tabla Turnos */

INSERT INTO BETTER_CALL_JUAN.Turnos (fecha_hora,paciente_id,medico_especialidad_id)
SELECT DISTINCT Turno_Fecha, p.id AS paciente_id, 
(SELECT id FROM BETTER_CALL_JUAN.Medicos_Especialidades WHERE medico_id=med.matricula AND especialidad_cod=maestra.Especialidad_Codigo) AS medico_especialidad_id
FROM gd_esquema.Maestra maestra JOIN BETTER_CALL_JUAN.Pacientes p ON (maestra.Paciente_Dni  =  p.nro_doc) JOIN BETTER_CALL_JUAN.Medicos med ON (maestra.Medico_Dni = med.nro_doc)
WHERE Turno_Numero IS NOT NULL AND Turno_Fecha IS NOT NULL
ORDER BY 1 ASC

/* Tabla Roles */
INSERT INTO BETTER_CALL_JUAN.Roles(nombre,habilitado)
VALUES('Afiliado',1),('Administrativo',1),('Profesional',1)

/* Tabla Bonos Consulta */
/*
Se me ocurren dos opciones para asignar correctamente el numero_consulta_paciente a cada bono:
1) Dos cursores, uno adentro del otro. Uno que por afuera recorra por paciente, y el de adentro que recorra por bono
	y asigne a cada bono el numero_consulta_paciente basado en un acumulador que se inicia luego de fetchear el paciente.

2) Otra opcion muy mala: Quitar el insert masivo de los nroUltimaConsulta en la tabla Pacientes y poner todos en 0. 
	Usar este atributo como si fuera el acumulador por paciente mencionado anteriormente. Entonces seria un cursor solo por bono
	que vaya consultando el atributo del paciente y lo vaya incrementando (me parece peor porque esta haciendo constantemente 
	select y update a la base por un atributo acumulador que seria mejor q este en memoria(opcion 1).
	La ventaja de esta opcion es que no hace falta hacer el insert masivo de los nroUltimaConsulta en Pacientes, ya que al finalizar
	la insercion de los bonos, este atributo queda correcto para cada paciente.
*/

/** FIN MIGRACION **/

/*FOREIGN KEYS*/

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

ALTER TABLE [BETTER_CALL_JUAN].[Especialidades] ADD CONSTRAINT tipo_especialidad_cod_especialidades FOREIGN KEY (tipo_especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Tipos_Especialidades](codigo)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos] ADD CONSTRAINT usuario_id_medicos FOREIGN KEY (usuario_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT user_id_roles_usuarios FOREIGN KEY (user_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT rol_id_roles_usuarios FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT rol_id_roles_funcionalidades FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT funcionalidad_id_roles_funcionalidades FOREIGN KEY (funcionalidad_id) REFERENCES [BETTER_CALL_JUAN].[Funcionalidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT medico_id_medicos_especialidades FOREIGN KEY (medico_id) REFERENCES [BETTER_CALL_JUAN].[Medicos](matricula)
ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT especialidad_cod_medicos_especialidades FOREIGN KEY (especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Especialidades](codigo)

/*
--No hay cambios de planes en Maestra
--Ya que en este select no hay nadie con mas de 1 en cantPlanes

SELECT Paciente_Dni, COUNT(DISTINCT Plan_Med_Codigo) cantPlanes
FROM gd_esquema.Maestra
GROUP BY Paciente_Dni
ORDER BY 2 DESC
*/
