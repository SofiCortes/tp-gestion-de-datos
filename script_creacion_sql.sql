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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Cancelaciones

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Turnos'))
    DROP TABLE BETTER_CALL_JUAN.Turnos
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bonos_Consulta'))
    DROP TABLE BETTER_CALL_JUAN.Bonos_Consulta

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
  [descripcion] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Usuarios] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [username] VARCHAR(255) UNIQUE NOT NULL,
  [password] VARCHAR(255) NOT NULL,
  [intentos_fallidos] SMALLINT DEFAULT 0 NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Roles] (
  [id] SMALLINT IDENTITY(1,1),
  [nombre] VARCHAR(255) UNIQUE NOT NULL,
  [habilitado] BIT DEFAULT 1  NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Operaciones_Compra] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [cant_bonos] NUMERIC(4,0) NOT NULL,
  [monto_total] NUMERIC(18,0) NOT NULL,
  [paciente_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Turnos] (
  [numero] NUMERIC(18,0) IDENTITY(1,1),
  [fecha_hora] DATETIME NOT NULL,
  [paciente_id] NUMERIC(18,0) NOT NULL,
  [medico_especialidad_id] NUMERIC(18,0) NOT NULL,
  [turno_numero_maestra] NUMERIC(18,0),
  PRIMARY KEY ([numero])
);

CREATE TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [medico_id] NUMERIC(18,0) NOT NULL,
  [especialidad_cod] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Cancelaciones] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [tipo_cancelacion_id] NUMERIC(18,0) NOT NULL,
  [motivo] VARCHAR(255) NOT NULL,
  [turno_numero] NUMERIC(18,0) NOT NULL UNIQUE,
  [hecha_por_paciente] BIT NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] (
  [user_id] NUMERIC(18,0),
  [rol_id] SMALLINT NOT NULL,
  PRIMARY KEY ([user_id], [rol_id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Especialidades] (
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255) NOT NULL,
  [tipo_especialidad_cod] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([codigo])
);

CREATE TABLE [BETTER_CALL_JUAN].[Tipos_Cancelaciones] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nombre] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Consultas] (
  [id] INT IDENTITY(1,1),
  [sintomas] VARCHAR(255) NOT NULL,
  [enfermedades] VARCHAR(255) NOT NULL,
  [turno_numero] NUMERIC(18,0) NOT NULL,
  [fecha_hora_llegada] DATETIME NOT NULL,
  [fecha_hora_atencion] DATETIME NOT NULL,
  [bono_consulta_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Bajas_Pacientes] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [paciente_id] NUMERIC(18,0) NOT NULL,
  [fecha_baja] DATETIME NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Tipos_Especialidades] (
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([codigo])
);

CREATE TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] (
  [rol_id] SMALLINT,
  [funcionalidad_id] NUMERIC(18,0),
  PRIMARY KEY ([rol_id],[funcionalidad_id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Bonos_Consulta] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [fecha_compra] DATETIME NOT NULL,
  [fecha_impresion] DATETIME,
  [numero_consulta_paciente] NUMERIC(18,0),
  [paciente_compra_id] NUMERIC(18,0) NOT NULL,
  [paciente_usa_id] NUMERIC(18,0),
  [plan_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Planes_Medicos] (
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255) NOT NULL,
  [precio_bono_consulta] NUMERIC(18,0) NOT NULL,
  [precio_bono_farmacia] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([codigo])
);

CREATE TABLE [BETTER_CALL_JUAN].[Medicos] (
  [matricula] NUMERIC(18,0) IDENTITY(1,1),
  [nombre] VARCHAR(255) NOT NULL,
  [apellido] VARCHAR(255) NOT NULL,
  [tipo_doc] VARCHAR(100) NOT NULL,
  [nro_doc] NUMERIC(18,0) NOT NULL,
  [direccion] VARCHAR(255) NOT NULL,
  [telefono] NUMERIC(18,0) NOT NULL,
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME NOT NULL,
  [sexo] CHAR(1),
  [usuario_id] NUMERIC(18,0),
  PRIMARY KEY ([matricula]),
  UNIQUE([tipo_doc], [nro_doc])
);

CREATE TABLE [BETTER_CALL_JUAN].[Pacientes] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nro_raiz] NUMERIC(18,0),
  [nro_personal] NUMERIC(2,0) DEFAULT 00 NOT NULL,
  [nombre] VARCHAR(255) NOT NULL,
  [apellido] VARCHAR(255) NOT NULL,
  [tipo_doc] VARCHAR(100) NOT NULL,
  [nro_doc] NUMERIC(18,0) NOT NULL,
  [direccion] VARCHAR(255) NOT NULL,
  [telefono] NUMERIC(18,0) NOT NULL,
  [mail] VARCHAR(255),
  [fecha_nac] DATETIME NOT NULL,
  [sexo] CHAR(1),
  [estado_civil] VARCHAR(100),
  [cantidad_familiares] INT DEFAULT 0 NOT NULL,
  [plan_medico_cod] NUMERIC(18,0) NOT NULL,
  [habilitado] BIT DEFAULT 1 NOT NULL,
  [nro_ultima_consulta] NUMERIC(18,0) DEFAULT 0 NOT NULL,
  [usuario_id] NUMERIC(18,0),
  PRIMARY KEY ([id]),
  UNIQUE([tipo_doc], [nro_doc])
);

CREATE TABLE [BETTER_CALL_JUAN].[Cambios_De_Plan] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [paciente_id] NUMERIC(18,0) NOT NULL,
  [fecha_cambio] DATETIME NOT NULL,
  [motivo_cambio] VARCHAR(500) NOT NULL,
  [plan_anterior_id] NUMERIC(18,0) NOT NULL,
  [plan_nuevo_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);

CREATE TABLE [BETTER_CALL_JUAN].[Rangos_Atencion] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [dia_semana] NUMERIC(1,0) NOT NULL,
  [hora_desde] TIME NOT NULL,
  [hora_hasta] TIME NOT NULL,
  [medico_especialidad_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);

/** FIN CREACION DE TABLAS **/

/** MIGRACION **/

/* Tabla Pacientes */

--Nros Ultimas Consultas
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Consultas_Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Consultas_Pacientes
	

CREATE TABLE [BETTER_CALL_JUAN].[Consultas_Pacientes] (
	[Paciente_Dni] NUMERIC(18,0),
	[Bono_Consulta_Numero] NUMERIC(18,0),
	[Bono_Consulta_Fecha_Impresion] DATETIME,
	[Plan_Med_Codigo] NUMERIC(18,0),
	[Turno_Numero] NUMERIC(18,0)
);

INSERT INTO BETTER_CALL_JUAN.Consultas_Pacientes
SELECT Paciente_Dni, Bono_Consulta_Numero, Bono_Consulta_Fecha_Impresion, Plan_Med_Codigo, Turno_Numero
FROM gd_esquema.Maestra
WHERE Paciente_Nombre IS NOT NULL AND Paciente_Apellido IS NOT NULL AND Paciente_Dni IS NOT NULL AND Paciente_Direccion IS NOT NULL 
AND Paciente_Telefono IS NOT NULL AND Paciente_Mail IS NOT NULL AND Paciente_Fecha_Nac IS NOT NULL AND Plan_Med_Codigo IS NOT NULL 
AND Plan_Med_Descripcion IS NOT NULL AND Plan_Med_Precio_Bono_Consulta IS NOT NULL AND Plan_Med_Precio_Bono_Farmacia IS NOT NULL 
AND Turno_Numero IS NOT NULL AND Turno_Fecha IS NOT NULL AND Consulta_Sintomas IS NOT NULL AND Consulta_Enfermedades IS NOT NULL 
AND Medico_Nombre IS NOT NULL AND Medico_Apellido IS NOT NULL AND Medico_Dni IS NOT NULL AND Medico_Direccion IS NOT NULL 
AND Medico_Telefono IS NOT NULL AND Medico_Mail IS NOT NULL AND Medico_Fecha_Nac IS NOT NULL AND Especialidad_Codigo IS NOT NULL 
AND Especialidad_Descripcion IS NOT NULL AND Tipo_Especialidad_Codigo IS NOT NULL AND Tipo_Especialidad_Descripcion IS NOT NULL 
AND Compra_Bono_Fecha IS NULL AND Bono_Consulta_Fecha_Impresion IS NOT NULL AND Bono_Consulta_Numero IS NOT NULL
ORDER BY Paciente_Dni, Turno_Numero

--INSERT PACIENTES

INSERT INTO BETTER_CALL_JUAN.Pacientes (nombre, apellido, tipo_doc,nro_doc,direccion,telefono,mail,fecha_nac,plan_medico_cod,habilitado,nro_ultima_consulta)
SELECT DISTINCT Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, 
Plan_Med_Codigo, 1, (SELECT COUNT(DISTINCT cp.Bono_Consulta_Numero) FROM BETTER_CALL_JUAN.Consultas_Pacientes cp WHERE cp.Paciente_Dni = m.Paciente_Dni GROUP BY cp.Paciente_Dni) AS nroUltimaConsulta
FROM gd_esquema.Maestra m
GROUP BY Paciente_Nombre, Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Plan_Med_Codigo

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

INSERT INTO BETTER_CALL_JUAN.Turnos (fecha_hora,paciente_id,medico_especialidad_id, turno_numero_maestra)
SELECT DISTINCT Turno_Fecha, p.id AS paciente_id, 
(SELECT id FROM BETTER_CALL_JUAN.Medicos_Especialidades WHERE medico_id=med.matricula AND especialidad_cod=maestra.Especialidad_Codigo) AS medico_especialidad_id,
maestra.Turno_Numero
FROM gd_esquema.Maestra maestra JOIN BETTER_CALL_JUAN.Pacientes p ON (maestra.Paciente_Dni  =  p.nro_doc) JOIN BETTER_CALL_JUAN.Medicos med ON (maestra.Medico_Dni = med.nro_doc)
WHERE Turno_Numero IS NOT NULL AND Turno_Fecha IS NOT NULL
ORDER BY 1 ASC

/* Tabla Roles */
INSERT INTO BETTER_CALL_JUAN.Roles(nombre,habilitado)
VALUES 
--1
('Administrador',1),
--2
('Afiliado',1),
--3
('Administrativo',1),
--4
('Profesional',1)

/* Tabla Funcionalidades */
INSERT INTO BETTER_CALL_JUAN.Funcionalidades(descripcion)
VALUES
--1
('Dar de alta afiliado'),
--2
('Dar de baja afiliado'),
--3
('Modificar afiliado'),
--4
('Registro de llegada para atención médica'),
--5
('Cancelar atención médica'),
--6
('Generar listado estadístico'),
--7
('Comprar bono'),
--8
('Pedir turno'),
--9
('Registro de resultado para atención médica'), 
--10
('Acciones con roles'),
--11
('Acciones con afiliados'),
--12
('Acciones con profesionales'),
--13
('Acciones con planes'),
--14
('Acciones con bonos'),
--15
('Acciones con turnos'),
--16
('Acciones con atencion medica')

/* Tabla Roles Funcionalidades */
INSERT INTO BETTER_CALL_JUAN.Roles_Funcionalidades(rol_id,funcionalidad_id)
VALUES(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),(1,14),(1,15),(1,16),
(2,7),(2,8),(2,14),(2,15),
(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,11),(3,16),
(4,5),(4,9),(4,16)

/* Tabla Usuarios */
INSERT INTO BETTER_CALL_JUAN.Usuarios(username, password)
VALUES('admin',HASHBYTES('SHA2_256','w23e'))

INSERT INTO BETTER_CALL_JUAN.Usuarios(username, password)
SELECT tipo_doc+cast(nro_doc as varchar), HASHBYTES('SHA2_256', 'afiliadofrba') password
FROM BETTER_CALL_JUAN.Pacientes

INSERT INTO BETTER_CALL_JUAN.Usuarios(username, password)
SELECT tipo_doc+cast(nro_doc as varchar), HASHBYTES('SHA2_256', 'profesionalfrba') password
FROM BETTER_CALL_JUAN.Medicos

/* Tabla Roles Usuarios */
INSERT INTO BETTER_CALL_JUAN.Roles_Usuarios(user_id,rol_id)
VALUES(1,1)

INSERT INTO BETTER_CALL_JUAN.Roles_Usuarios(user_id,rol_id)
SELECT u.id, 2 rol
FROM BETTER_CALL_JUAN.Pacientes p JOIN BETTER_CALL_JUAN.Usuarios u ON ((p.tipo_doc+ cast(p.nro_doc as varchar)) = u.username)

INSERT INTO BETTER_CALL_JUAN.Roles_Usuarios(user_id,rol_id)
SELECT u.id, 4 rol
FROM BETTER_CALL_JUAN.Medicos m JOIN BETTER_CALL_JUAN.Usuarios u ON ((m.tipo_doc+ cast(m.nro_doc as varchar)) = u.username)

/* Tabla Bonos Consulta */

INSERT INTO BETTER_CALL_JUAN.Bonos_Consulta 
(fecha_compra,fecha_impresion,numero_consulta_paciente,paciente_compra_id,paciente_usa_id,plan_id)
SELECT cp1.Bono_Consulta_Fecha_Impresion, cp1.Bono_Consulta_Fecha_Impresion,
(
SELECT nro_consulta_paciente 
FROM
	(SELECT Bono_Consulta_Numero,ROW_NUMBER() OVER (ORDER BY Turno_Numero) AS nro_consulta_paciente 
	FROM  BETTER_CALL_JUAN.Consultas_Pacientes cp2 
	WHERE cp2.Paciente_Dni=cp1.Paciente_Dni) 
	AS tab1
WHERE cp1.Bono_Consulta_Numero=tab1.Bono_Consulta_Numero
) as nro_consulta_paciente, 
(SELECT id FROM BETTER_CALL_JUAN.Pacientes WHERE nro_doc=Paciente_Dni) as paciente_compra_id, 
(SELECT id FROM BETTER_CALL_JUAN.Pacientes WHERE nro_doc=Paciente_Dni) as paciente_usa_id,
cp1.Plan_Med_Codigo
FROM BETTER_CALL_JUAN.Consultas_Pacientes cp1

DROP TABLE BETTER_CALL_JUAN.Consultas_Pacientes

/* Tabla Consultas */
INSERT INTO BETTER_CALL_JUAN.Consultas (sintomas, enfermedades, turno_numero, fecha_hora_llegada, fecha_hora_atencion, bono_consulta_id)
SELECT DISTINCT M.Consulta_Sintomas, M.Consulta_Enfermedades, T.numero turnoId, M.Turno_Fecha, M.Turno_Fecha,
(SELECT DISTINCT id FROM BETTER_CALL_JUAN.Bonos_Consulta B 
WHERE B.paciente_usa_id = P.id AND 
B.numero_consulta_paciente=
	(SELECT rownum FROM 
		(SELECT DISTINCT M2.Turno_Numero, ROW_NUMBER() OVER(ORDER BY M2.Turno_Numero) rownum 
		FROM gd_esquema.Maestra M2 
		WHERE M2.Paciente_Dni=P.nro_doc AND M2.Turno_Numero IS NOT NULL AND M2.Consulta_Sintomas IS NOT NULL)
		as turnosPaciente 
	WHERE Turno_Numero=M.Turno_Numero
	)
) as bono_consulta_id
FROM gd_esquema.Maestra M
JOIN BETTER_CALL_JUAN.Pacientes P ON P.nro_doc = M.Paciente_Dni
JOIN BETTER_CALL_JUAN.Turnos T ON T.turno_numero_maestra = M.Turno_Numero
JOIN BETTER_CALL_JUAN.Especialidades E ON E.codigo = M.Especialidad_Codigo
WHERE M.Consulta_Enfermedades IS NOT NULL AND M.Consulta_Sintomas IS NOT NULL

/* Tabla Operaciones Compra */

INSERT INTO BETTER_CALL_JUAN.Operaciones_Compra (cant_bonos, monto_total, paciente_id)
SELECT COUNT(DISTINCT Bono_Consulta_Numero) cantBonos, SUM(Plan_Med_Precio_Bono_Consulta) montoTotal, p.id pacienteID
FROM gd_esquema.Maestra m JOIN BETTER_CALL_JUAN.Pacientes p ON (m.Paciente_Dni = p.nro_doc)
WHERE Compra_Bono_Fecha IS NOT NULL
GROUP BY p.id, Compra_Bono_Fecha

/* Tabla Rangos Horarios */

CREATE TABLE #MedicosEspecialidadesTemp (
medico_dni numeric(18,0),
esp_codigo numeric(18,0),
med_esp_id numeric(18,0),
)

INSERT INTO #MedicosEspecialidadesTemp
SELECT med.nro_doc, esp.codigo, med_esp.id
FROM BETTER_CALL_JUAN.Medicos med JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med.matricula = med_esp.medico_id)
JOIN BETTER_CALL_JUAN.Especialidades esp ON (esp.codigo = med_esp.especialidad_cod)

INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28072053 AND esp_codigo = 10018)) --1
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10006)) --2
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10007)) --3
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10026)) --4
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 11:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10047)) --5
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 16:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10017)) --6
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10033)) --7
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10038)) --8
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54980698 AND esp_codigo = 10033)) --9
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10004)) --10
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10019)) --11
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54851289 AND esp_codigo = 10020)) --12
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10010)) --13
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10012)) --14
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 1465925 AND esp_codigo = 10033)) --15
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 65090855 AND esp_codigo = 10039)) --16
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 97196837 AND esp_codigo = 10034)) --17
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 9999)) --18
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10001)) --19
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10048)) --20
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54030479 AND esp_codigo = 10029)) --21
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 72817971 AND esp_codigo = 10033)) --22
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 9954476 AND esp_codigo = 10016)) --23
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 27123524 AND esp_codigo = 10032)) --24
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10000)) --25
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10025)) --26
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86815204 AND esp_codigo = 10022)) --27
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 56949224 AND esp_codigo = 10020)) --28
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 78862992 AND esp_codigo = 10045)) --29
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10001)) --30
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10025)) --31
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 3116603 AND esp_codigo = 10047)) --32
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 11:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 9999)) --33
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 10015)) --34
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10016)) --35
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10037)) --36
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(1,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 96743144 AND esp_codigo = 10016)) --37
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28072053 AND esp_codigo = 10018)) --38
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10006)) --39
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10007)) --40
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10026)) --41
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 11:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10047)) --42
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 16:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10017)) --43
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10033)) --44
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10038)) --45
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54980698 AND esp_codigo = 10033)) --46
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10004)) --47
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10019)) --48
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54851289 AND esp_codigo = 10020)) --49
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10010)) --50
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10012)) --51
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 1465925 AND esp_codigo = 10033)) --52
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 97196837 AND esp_codigo = 10036)) --53
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 9999)) --54
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10001)) --55
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10048)) --56
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54030479 AND esp_codigo = 10029)) --57
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 72817971 AND esp_codigo = 10033)) --58
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 9954476 AND esp_codigo = 10016)) --59
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 27123524 AND esp_codigo = 10032)) --60
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10000)) --61
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10025)) --62
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86815204 AND esp_codigo = 10022)) --63
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 56949224 AND esp_codigo = 10020)) --64
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 78862992 AND esp_codigo = 10045)) --65
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10001)) --66
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10025)) --67
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 3116603 AND esp_codigo = 10047)) --68
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 10037)) --69
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10019)) --70
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(2,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 96743144 AND esp_codigo = 10016)) --71
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28072053 AND esp_codigo = 10018)) --72
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),  (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10006)) --73
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10007)) --74
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10026)) --75
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 11:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10047)) --76
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10033)) --77
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10038)) --78
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54980698 AND esp_codigo = 10033)) --79
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10004)) --80
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10019)) --81
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54851289 AND esp_codigo = 10020)) --82
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10010)) --83
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10012)) --84
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 1465925 AND esp_codigo = 10033)) --85
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 65090855 AND esp_codigo = 10039)) --86
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 97196837 AND esp_codigo = 10034)) --87
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 10010)) --88
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 10014)) --89
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10001)) --90
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10048)) --91
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54030479 AND esp_codigo = 10029)) --92
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 88421890 AND esp_codigo = 10021)) --93
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 72817971 AND esp_codigo = 10007)) --94
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 9954476 AND esp_codigo = 10016)) --95
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 46998467 AND esp_codigo = 10032)) --96
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10025)) --97
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10018)) --98
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86815204 AND esp_codigo = 10022)) --99
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 56949224 AND esp_codigo = 10020)) --100
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 78862992 AND esp_codigo = 10045)) --101
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10001)) --102
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10027)) --103
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 3116603 AND esp_codigo = 10047)) --104
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 11:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 9999)) --105
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 10015)) --106
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10016)) --107
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10037)) --108
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(3,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 96743144 AND esp_codigo = 10016)) --109
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28072053 AND esp_codigo = 10018)) --110
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10006)) --111
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 35198771 AND esp_codigo = 10007)) --112
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10026)) --113
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 11:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10047)) --114
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10033)) --115
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	 (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10038)) --116
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54980698 AND esp_codigo = 10033)) --117
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10004)) --118
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10019)) --119
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54851289 AND esp_codigo = 10020)) --120
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10010)) --121
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10012)) --122
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 1465925 AND esp_codigo = 10033)) --123
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 97196837 AND esp_codigo = 10036)) --124
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 10010)) --125
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 10014)) --126
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10001)) --127
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10048)) --128
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 88421890 AND esp_codigo = 10021)) --129
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 72817971 AND esp_codigo = 10033)) --130
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 9954476 AND esp_codigo = 10016)) --131
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 46998467 AND esp_codigo = 10032)) --132
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10018)) --133
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 56949224 AND esp_codigo = 10020)) --134
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 78862992 AND esp_codigo = 10045)) --135
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10001)) --136
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)), (SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 3116603 AND esp_codigo = 10047))--137
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 10037)) --138
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10019)) --139
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(4,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 96743144 AND esp_codigo = 10016)) --140
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28072053 AND esp_codigo = 10018)) --141
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10026)) --142
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 11:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10047)) --143
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 15:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10033)) --144
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10038)) --145
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54980698 AND esp_codigo = 10033)) --146
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 10:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10004))--147
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10019)) --148
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54851289 AND esp_codigo = 10020)) --149
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10010)) --150
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10012)) --151
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 1465925 AND esp_codigo = 10033)) --152
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 65090855 AND esp_codigo = 10039)) --153
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 97196837 AND esp_codigo = 10034)) --154
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 10010)) --155
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 10014)) --156
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10001)) --157
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10048)) --158
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 72817971 AND esp_codigo = 10033)) --159
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 9954476 AND esp_codigo = 10024)) --160
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 27123524 AND esp_codigo = 10032)) --161
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 46998467 AND esp_codigo = 10032)) --162
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 92746405 AND esp_codigo = 10018)) --163
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 14:00' AS TIME(0)), CAST ('2016-10-01 20:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86815204 AND esp_codigo = 10022)) --164
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 56949224 AND esp_codigo = 10020)) --165
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 78862992 AND esp_codigo = 10045)) --166
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10001)) --167
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 28036677 AND esp_codigo = 10027)) --168
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 17:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 3116603 AND esp_codigo = 10047)) --169
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 7:00' AS TIME(0)), CAST ('2016-10-01 11:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 9999)) --170
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 10015)) --171
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10016)) --172
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 13:00' AS TIME(0)), CAST ('2016-10-01 18:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10037)) --173
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(5,	CAST ('2016-10-01 8:00' AS TIME(0)), CAST ('2016-10-01 16:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 96743144 AND esp_codigo = 10016)) --174
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 86526083 AND esp_codigo = 10017)) --175
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10033)) --176
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 12:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 10675835 AND esp_codigo = 10038)) --177
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 52427724 AND esp_codigo = 10004)) --178
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 54851289 AND esp_codigo = 10020)) --179
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 80527583 AND esp_codigo = 10012)) --180
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 1465925 AND esp_codigo = 10033)) --181 
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 20407720 AND esp_codigo = 9999)) --182
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 14:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 18756896 AND esp_codigo = 10042)) --183
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 72817971 AND esp_codigo = 10007)) --184
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 12:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 27123524 AND esp_codigo = 10032)) --185
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 56949224 AND esp_codigo = 10020)) --186
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 78862992 AND esp_codigo = 10045)) --187
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 3116603 AND esp_codigo = 10047)) --188
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 15:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 93533777 AND esp_codigo = 10037)) --189
INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion(dia_semana, hora_desde, hora_hasta, medico_especialidad_id) VALUES	(6,	CAST ('2016-10-01 10:00' AS TIME(0)), CAST ('2016-10-01 13:00' AS TIME(0)),	(SELECT med_esp_id FROM #MedicosEspecialidadesTemp WHERE medico_dni = 85129809 AND esp_codigo = 10019)) --190

DROP TABLE #MedicosEspecialidadesTemp

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

ALTER TABLE [BETTER_CALL_JUAN].[Cancelaciones] ADD CONSTRAINT tipo_cancelacion_id_cancelacion FOREIGN KEY (tipo_cancelacion_id) REFERENCES [BETTER_CALL_JUAN].[Tipos_Cancelaciones](id)
ALTER TABLE [BETTER_CALL_JUAN].[Cancelaciones] ADD CONSTRAINT turno_numero_cancelacion FOREIGN KEY (turno_numero) REFERENCES [BETTER_CALL_JUAN].[Turnos](numero)

ALTER TABLE [BETTER_CALL_JUAN].[Rangos_Atencion] ADD CONSTRAINT medico_especialidad_id_rango_atencion FOREIGN KEY (medico_especialidad_id) REFERENCES [BETTER_CALL_JUAN].[Medicos_Especialidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Especialidades] ADD CONSTRAINT tipo_especialidad_cod_especialidades FOREIGN KEY (tipo_especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Tipos_Especialidades](codigo)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos] ADD CONSTRAINT usuario_id_medicos FOREIGN KEY (usuario_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT user_id_roles_usuarios FOREIGN KEY (user_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT rol_id_roles_usuarios FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT rol_id_roles_funcionalidades FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT funcionalidad_id_roles_funcionalidades FOREIGN KEY (funcionalidad_id) REFERENCES [BETTER_CALL_JUAN].[Funcionalidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT medico_id_medicos_especialidades FOREIGN KEY (medico_id) REFERENCES [BETTER_CALL_JUAN].[Medicos](matricula)
ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT especialidad_cod_medicos_especialidades FOREIGN KEY (especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Especialidades](codigo)


IF EXISTS (SELECT * FROM sys.all_columns WHERE name='turno_numero_maestra')
	ALTER TABLE [BETTER_CALL_JUAN].[Turnos] DROP COLUMN turno_numero_maestra

-----------------------------------------

/** PROCEDURES **/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Login'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Login
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Roles'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Roles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Funcionalidades_De_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Funcionalidades_De_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Planes'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Planes
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Todos_Los_Roles'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Todos_Los_Roles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Todas_Las_Funcionalidades'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Todas_Las_Funcionalidades
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Crear_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Crear_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Obtener_Rol_Id'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Obtener_Rol_Id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Asignar_Funcionalidad_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Asignar_Funcionalidad_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Alta_Usuario_Afiliado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Alta_Usuario_Afiliado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Alta_Afiliado_Nuevo_Grupo'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Alta_Afiliado_Nuevo_Grupo
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Alta_Afiliado_Familiar'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Alta_Afiliado_Familiar
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Afiliados'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Afiliados
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Baja_Afiliado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Baja_Afiliado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Modificar_Afiliado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Modificar_Afiliado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Modificar_Plan_Medico'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Modificar_Plan_Medico
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Comprar_Bonos'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Comprar_Bonos
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Obtener_Funcionalidades_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Obtener_Funcionalidades_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Pedir_Turno'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Pedir_Turno
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Top_5_Especialidades_Con_Mas_Cancelaciones'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Top_5_Especialidades_Con_Mas_Cancelaciones
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Mas_Consultados_Por_Plan'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Mas_Consultados_Por_Plan
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Con_Menos_Horas_Trabajadas_Segun_Especialidad'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Top_5_Profesionales_Con_Menos_Horas_Trabajadas_Segun_Especialidad
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Top_5_Afiliados_Con_Mayor_Cantidad_Bonos_Comprados'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Top_5_Afiliados_Con_Mayor_Cantidad_Bonos_Comprados
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Top_5_Especialidades_Con_Mas_Bonos_Utilizados'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Top_5_Especialidades_Con_Mas_Bonos_Utilizados
GO

------------------------------------------

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Login] (@user VARCHAR(255), @passwordIngresada VARCHAR(255), @retorno SMALLINT OUT)
AS
BEGIN
	DECLARE @passwordReal VARCHAR(255), @intentosFallidos SMALLINT, @idUsuario NUMERIC(18,0)

	SELECT @idUsuario=id, @passwordReal=password, @intentosFallidos=intentos_fallidos
	FROM BETTER_CALL_JUAN.Usuarios
	WHERE username=@user

	IF (@idUsuario IS NULL) 
		SET @retorno= -1	--No existe el usuario
	ELSE 
	BEGIN
		IF(@intentosFallidos>=3)
			SET @retorno= -2 --Usuario inhabilitado
		ELSE 
		BEGIN
			IF(@passwordReal = HASHBYTES('SHA2_256',@passwordIngresada))
			BEGIN
				IF(@intentosFallidos>0)
					BEGIN
						UPDATE BETTER_CALL_JUAN.Usuarios
						SET intentos_fallidos=0
						WHERE id=@idUsuario	
					END	

				IF ((SELECT COUNT(DISTINCT ru.rol_id) FROM BETTER_CALL_JUAN.Roles_Usuarios ru WHERE ru.user_id=@idUsuario) = 1)
					SET  @retorno=1 --Login OK. Tiene 1 rol
				ELSE
					SET @retorno=2 ---Login OK. Tiene mas de 1 rol
			END
			ELSE
			BEGIN
				UPDATE BETTER_CALL_JUAN.Usuarios
				SET intentos_fallidos= @intentosFallidos + 1
				WHERE id=@idUsuario	
				
				SET @retorno= -3 --Contrasenia incorrecta
			END
		END 

	END
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Roles] (@user VARCHAR(255))
AS
BEGIN
	SELECT R.nombre FROM BETTER_CALL_JUAN.Roles R
	JOIN BETTER_CALL_JUAN.Usuarios U ON U.username = @user
	JOIN BETTER_CALL_JUAN.Roles_Usuarios RU ON U.id = RU.user_id
	WHERE RU.rol_id = R.id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Funcionalidades_De_Rol] (@rol VARCHAR(255))
AS
BEGIN
	SELECT F.descripcion FROM BETTER_CALL_JUAN.Funcionalidades F
	JOIN BETTER_CALL_JUAN.Roles R ON R.nombre = @rol
	JOIN BETTER_CALL_JUAN.Roles_Funcionalidades RF ON RF.rol_id = R.id
	WHERE F.id = RF.funcionalidad_id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Planes]
AS
BEGIN
	SELECT PM.codigo, PM.descripcion, PM.precio_bono_consulta, PM.precio_bono_farmacia
	FROM BETTER_CALL_JUAN.Planes_Medicos PM
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Todos_Los_Roles]
AS
BEGIN
	SELECT *
	FROM BETTER_CALL_JUAN.Roles R
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Todas_Las_Funcionalidades]
AS
BEGIN
	SELECT id, descripcion
	FROM BETTER_CALL_JUAN.Funcionalidades
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Crear_Rol] (@nombre VARCHAR(255), @retorno SMALLINT OUT)
AS
BEGIN
	IF ((SELECT id FROM BETTER_CALL_JUAN.Roles WHERE nombre = @nombre) IS NULL)
	BEGIN
	INSERT INTO BETTER_CALL_JUAN.Roles(nombre) VALUES(@nombre)
	SET @retorno = 1
	END
	ELSE
	BEGIN
	SET @retorno = -1
	END
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Obtener_Rol_Id] (@nombre VARCHAR(255), @id SMALLINT OUT)
AS
BEGIN
	SET @id = (SELECT id FROM BETTER_CALL_JUAN.Roles WHERE nombre = @nombre)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Asignar_Funcionalidad_Rol] (@rol_id SMALLINT, @funcionalidad_id NUMERIC(18,0))
AS
BEGIN
	INSERT INTO BETTER_CALL_JUAN.Roles_Funcionalidades(rol_id, funcionalidad_id) VALUES (@rol_id, @funcionalidad_id)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Alta_Usuario_Afiliado](@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0), @id NUMERIC(18,0) OUT)
AS
BEGIN
	INSERT INTO BETTER_CALL_JUAN.Usuarios (username,password) 
	VALUES (@tipo_doc+cast(@nro_doc as varchar),'afiliadofrba')

	SELECT @id=MAX(id)
	FROM BETTER_CALL_JUAN.Usuarios

	RETURN @id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Alta_Afiliado_Familiar](@nro_raiz NUMERIC(18,0),@nombre VARCHAR(255),@apellido VARCHAR(255),
																	   @tipo_doc VARCHAR(100),@nro_doc NUMERIC(18,0),@direccion VARCHAR(255),
																	   @telefono NUMERIC(18,0),@mail VARCHAR(255),@fecha_nac DATETIME, 
																	   @sexo CHAR(1), @estado_civil VARCHAR(100),@plan_medico_cod NUMERIC(18,0))
AS
BEGIN
	IF (@nro_raiz IS NULL OR NOT EXISTS (SELECT nro_raiz FROM Pacientes WHERE nro_raiz=@nro_raiz))
	BEGIN
		RAISERROR('Debe especificarse un numero raiz valido',10,1)
		RETURN
	END

	DECLARE @usuario_id NUMERIC(18,0)
	EXEC BETTER_CALL_JUAN.Procedure_Alta_Usuario_Afiliado @tipo_doc, @nro_doc, @usuario_id OUT

	INSERT INTO BETTER_CALL_JUAN.Pacientes  
	(nro_raiz,nombre,apellido,tipo_doc,nro_doc,direccion,telefono,mail,
	fecha_nac,sexo,estado_civil,plan_medico_cod,usuario_id)
	VALUES
	(@nro_raiz,@nombre,@apellido,@tipo_doc,@nro_doc,@direccion,@telefono,
	@mail,@fecha_nac,@sexo,@estado_civil,@plan_medico_cod,@usuario_id)

END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Alta_Afiliado_Nuevo_Grupo](@nombre VARCHAR(255),@apellido VARCHAR(255),@tipo_doc VARCHAR(100),
																		  @nro_doc NUMERIC(18,0),@direccion VARCHAR(255),@telefono NUMERIC(18,0),
																		  @mail VARCHAR(255),@fecha_nac DATETIME, @sexo CHAR(1), 
																		  @estado_civil VARCHAR(100),@plan_medico_cod NUMERIC(18,0))
AS
BEGIN
	DECLARE @nro_raiz_nuevo NUMERIC(18,0)

	SELECT @nro_raiz_nuevo=MAX(nro_raiz)
	FROM BETTER_CALL_JUAN.Pacientes
		
	IF(@nro_raiz_nuevo IS NULL)
		SET @nro_raiz_nuevo=1
	ELSE
		SET @nro_raiz_nuevo= @nro_raiz_nuevo+1

	DECLARE @usuario_id NUMERIC(18,0)
	EXEC BETTER_CALL_JUAN.Procedure_Alta_Usuario_Afiliado @tipo_doc, @nro_doc, @usuario_id OUT

	INSERT INTO BETTER_CALL_JUAN.Pacientes  
	(nro_raiz,nombre,apellido,tipo_doc,nro_doc,direccion,telefono,mail,
	fecha_nac,sexo,estado_civil,plan_medico_cod,usuario_id)
	VALUES
	(@nro_raiz_nuevo,@nombre,@apellido,@tipo_doc,@nro_doc,@direccion,@telefono,
	@mail,@fecha_nac,@sexo,@estado_civil,@plan_medico_cod,@usuario_id)

END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Afiliados]
AS
BEGIN
	SELECT id,nro_raiz,nro_personal,nombre,apellido,tipo_doc,nro_doc,direccion,telefono,mail,fecha_nac,sexo,
	estado_civil,cantidad_familiares,plan_medico_cod,habilitado,nro_ultima_consulta,usuario_id

	FROM BETTER_CALL_JUAN.Pacientes
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Modificar_Afiliado] (@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0), @direccion VARCHAR(255), @telefono NUMERIC(18,0), @mail VARCHAR(255), @sexo CHAR(1), @estado_civil VARCHAR(100))
AS
BEGIN
	IF (@nro_doc IS NULL OR NOT EXISTS (SELECT nro_doc FROM Pacientes WHERE tipo_doc=@tipo_doc AND nro_doc=@nro_doc)) 
	--chequear si esta validacion va aca o como lo manda desde la app
	BEGIN
		RAISERROR('No existe afiliado registrado con el numero de documento ingresado.', 10,1)
		RETURN
	END

	UPDATE Pacientes
	SET direccion=@direccion, telefono=@telefono, mail=@mail, sexo=@sexo, estado_civil=@estado_civil
	WHERE tipo_doc = @tipo_doc AND nro_doc = @nro_doc
						
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Modificar_Plan_Medico] (@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0), @nuevo_plan NUMERIC(18,0), @motivo VARCHAR(500)) -- si le puedo pasar directamente el id paciente joya me ahorro un join
AS
BEGIN
	IF (@nro_doc IS NULL OR NOT EXISTS (SELECT nro_doc FROM Pacientes WHERE tipo_doc=@tipo_doc AND nro_doc=@nro_doc)) 
	--chequear si esta validacion va aca o como lo manda desde la app
	BEGIN
		RAISERROR('No existe afiliado registrado con el numero de documento ingresado.', 10,1)
		RETURN
	END

	INSERT INTO Cambios_De_Plan(paciente_id,fecha_cambio, motivo_cambio, plan_anterior_id)  
	VALUES ((SELECT id FROM Pacientes WHERE tipo_doc=@tipo_doc AND nro_doc=@nro_doc), 
			GETDATE(), 
			@motivo,
			(SELECT plan_medico_cod FROM Pacientes WHERE tipo_doc = @tipo_doc AND nro_doc = @nro_doc)) --esto es la villa
	
	UPDATE Pacientes
	SET plan_medico_cod=@nuevo_plan
	WHERE tipo_doc = @tipo_doc AND nro_doc = @nro_doc
						
END
GO


CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Baja_Afiliado] (@nro_doc NUMERIC(18,0)) --agregamos el tipo de doc?
AS
BEGIN
	IF (@nro_doc IS NULL OR NOT EXISTS (SELECT nro_doc FROM Pacientes WHERE nro_doc=@nro_doc)) 
	--chequear si esta validacion va aca o como lo manda desde la app
	BEGIN
		RAISERROR('No existe afiliado registrado con el numero de documento ingresado.', 10,1)
		RETURN
	END

	IF((SELECT habilitado FROM Pacientes WHERE nro_doc = @nro_doc) = 0)
	BEGIN
		RAISERROR('El afiliado ya está dado de baja.', 10,1)
		RETURN
	END

	UPDATE Pacientes
	SET habilitado = 0
	WHERE nro_doc = @nro_doc

	INSERT INTO Bajas_Pacientes(fecha_baja, paciente_id) 
	VALUES (GETDATE(), (SELECT id FROM BETTER_CALL_JUAN.Pacientes WHERE nro_doc = @nro_doc))

END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Comprar_Bonos] (@id_afiliado_comprador NUMERIC(18,0), @cant_bonos NUMERIC(18,0),
															   @plan_medico_bono_id NUMERIC(18,0), @monto_a_pagar NUMERIC(18,2) OUT)
AS
BEGIN
	DECLARE @precio_bono NUMERIC(18,0)

	SELECT @precio_bono=p.precio_bono_consulta
	FROM BETTER_CALL_JUAN.Planes_Medicos p
	WHERE p.codigo  = @plan_medico_bono_id

	SET @monto_a_pagar = @precio_bono * @cant_bonos

	INSERT INTO BETTER_CALL_JUAN.Operaciones_Compra (cant_bonos,monto_total,paciente_id) 
	VALUES (@cant_bonos,@monto_a_pagar,@id_afiliado_comprador)

	DECLARE @i INT = 0;

	WHILE @i< @cant_bonos
	BEGIN
	   INSERT INTO BETTER_CALL_JUAN.Bonos_Consulta (fecha_compra,paciente_compra_id,plan_id)
	   VALUES (GETDATE() /*@@fecha_del_sistema*/,@id_afiliado_comprador,@plan_medico_bono_id)
	   SET @i = @i + 1;
	END;

	RETURN @monto_a_pagar
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Obtener_Funcionalidades_Rol] (@rol_id SMALLINT)
AS
BEGIN
	SELECT rf.funcionalidad_id, f.descripcion
	FROM BETTER_CALL_JUAN.Roles_Funcionalidades rf JOIN BETTER_CALL_JUAN.Funcionalidades f ON (rf.funcionalidad_id = f.id)
	WHERE rf.rol_id = @rol_id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Pedir_Turno](@id_afiliado NUMERIC(18,0),@medico_id NUMERIC(18,0), 
															@especialidad_codigo NUMERIC(18,0), @fecha_hora_turno DATETIME)
AS
BEGIN
	DECLARE @medico_especialidad_id NUMERIC(18,0)

	SELECT @medico_especialidad_id=me.id
	FROM BETTER_CALL_JUAN.Medicos_Especialidades me
	WHERE me.medico_id=@medico_id AND me.especialidad_cod=@especialidad_codigo

	INSERT INTO BETTER_CALL_JUAN.Turnos(fecha_hora,paciente_id,medico_especialidad_id)
	VALUES (@fecha_hora_turno,@id_afiliado,@medico_especialidad_id)
END
GO

/* **FALTA COMPLETAR**

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Horarios_Disponibles](@medico_id NUMERIC(18,0),@especialidad_codigo NUMERIC(18,0))
AS
BEGIN
	DECLARE @medico_especialidad_id NUMERIC(18,0)

	SELECT @medico_especialidad_id=me.id
	FROM BETTER_CALL_JUAN.Medicos_Especialidades me
	WHERE me.medico_id=@medico_id AND me.especialidad_cod=@especialidad_codigo

	SELECT R.dia_semana, R.hora_desde, R.hora_hasta
	FROM BETTER_CALL_JUAN.Rangos_Atencion R
	WHERE R.medico_especialidad_id=@medico_especialidad_id

END
GO
*/

/** TOP 5 **/

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Especialidades_Con_Mas_Cancelaciones](@autor_cancelacion CHAR(1),@fechaDesde DATE, @fechaHasta DATE)
AS
BEGIN
	IF (@autor_cancelacion NOT IN ('A','M','T'))
	BEGIN
		RAISERROR('@autor_cancelacion debe ser A para Afiliados, M para medicos o T para todos',10,1)
		RETURN
	END

	IF (@fechaHasta <= @fechaDesde)
	BEGIN
		RAISERROR('@fechaHasta debe ser mayor que @fechaDesde',10,1)
		RETURN
	END
	
	IF(@autor_cancelacion='A')
	BEGIN
		SELECT TOP 5 e.codigo, e.descripcion, COUNT(DISTINCT c.id) cantCancelaciones
		FROM BETTER_CALL_JUAN.Especialidades e JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (e.codigo = me.especialidad_cod)
		JOIN BETTER_CALL_JUAN.Turnos t ON (me.id = t.medico_especialidad_id) JOIN BETTER_CALL_JUAN.Cancelaciones c ON (c.turno_numero = t.numero)
		WHERE c.hecha_por_paciente=1 AND cast(t.fecha_hora as DATE) BETWEEN @fechaDesde AND @fechaHasta 
		GROUP BY e.codigo, e.descripcion
		ORDER BY cantCancelaciones DESC
	END

	ELSE IF(@autor_cancelacion='M')
	BEGIN
		SELECT TOP 5 e.codigo, e.descripcion, COUNT(DISTINCT c.id) cantCancelaciones
		FROM BETTER_CALL_JUAN.Especialidades e JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (e.codigo = me.especialidad_cod)
		JOIN BETTER_CALL_JUAN.Turnos t ON (me.id = t.medico_especialidad_id) JOIN BETTER_CALL_JUAN.Cancelaciones c ON (c.turno_numero = t.numero)
		WHERE c.hecha_por_paciente=0 AND cast(t.fecha_hora as DATE) BETWEEN @fechaDesde AND @fechaHasta 
		GROUP BY e.codigo, e.descripcion
		ORDER BY cantCancelaciones DESC
	END

	ELSE IF(@autor_cancelacion='T')
	BEGIN
		SELECT TOP 5 e.codigo, e.descripcion, COUNT(DISTINCT c.id) cantCancelaciones
		FROM BETTER_CALL_JUAN.Especialidades e JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (e.codigo = me.especialidad_cod)
		JOIN BETTER_CALL_JUAN.Turnos t ON (me.id = t.medico_especialidad_id) JOIN BETTER_CALL_JUAN.Cancelaciones c ON (c.turno_numero = t.numero)
		WHERE cast(t.fecha_hora as DATE) BETWEEN @fechaDesde AND @fechaHasta 
		GROUP BY e.codigo, e.descripcion
		ORDER BY cantCancelaciones DESC
	END
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Profesionales_Mas_Consultados_Por_Plan]
(@plan_medico_id NUMERIC(18,0),@fechaDesde DATE, @fechaHasta DATE)
AS 
BEGIN
	IF (@fechaHasta <= @fechaDesde)
	BEGIN
		RAISERROR('@fechaHasta debe ser mayor que @fechaDesde',10,1)
		RETURN
	END

	IF NOT EXISTS(SELECT codigo FROM BETTER_CALL_JUAN.Planes_Medicos WHERE codigo=@plan_medico_id)
	BEGIN
		RAISERROR('Id de plan medico incorrecto',10,1)
		RETURN
	END

	SELECT TOP 5 med.matricula, med.nombre, med.apellido,esp.codigo,esp.descripcion, COUNT(DISTINCT cons.id) cantConsultas

	FROM BETTER_CALL_JUAN.Medicos med 
	JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med.matricula = med_esp.medico_id)
	JOIN BETTER_CALL_JUAN.Turnos t ON (t.medico_especialidad_id=med_esp.id) 
	JOIN BETTER_CALL_JUAN.Consultas cons ON (cons.turno_numero=t.numero)
	JOIN BETTER_CALL_JUAN.Especialidades esp ON (esp.codigo = med_esp.especialidad_cod) 
	JOIN BETTER_CALL_JUAN.Pacientes pac ON (pac.id = t.paciente_id)
	WHERE pac.plan_medico_cod=@plan_medico_id AND cast(t.fecha_hora as DATE) BETWEEN @fechaDesde AND @fechaHasta
	GROUP BY med.matricula, med.nombre, med.apellido,esp.codigo, esp.descripcion
	ORDER BY cantConsultas DESC

END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Profesionales_Con_Menos_Horas_Trabajadas_Segun_Especialidad]
(@especialidad_cod NUMERIC(18,0),@fechaDesde DATE, @fechaHasta DATE)
AS
BEGIN
	IF (@fechaHasta <= @fechaDesde)
	BEGIN
		RAISERROR('@fechaHasta debe ser mayor que @fechaDesde',10,1)
		RETURN
	END

	IF NOT EXISTS (SELECT codigo FROM BETTER_CALL_JUAN.Especialidades WHERE codigo=@especialidad_cod)
	BEGIN
		RAISERROR('Codigo de especialidad incorrecto',10,1)
		RETURN
	END

	SELECT TOP 5 med.matricula, med.nombre, med.apellido, COUNT(DISTINCT c.id)/2 cantHorasTrabajadas --porque cada consulta dura media hora
	FROM BETTER_CALL_JUAN.Medicos med 
	JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med_esp.medico_id=med.matricula AND med_esp.especialidad_cod=@especialidad_cod)
	JOIN BETTER_CALL_JUAN.Turnos t ON (t.medico_especialidad_id=med_esp.id)
	JOIN BETTER_CALL_JUAN.Consultas c ON (c.turno_numero = t.numero)
	WHERE cast(t.fecha_hora as DATE) BETWEEN @fechaDesde AND @fechaHasta
	GROUP BY med.matricula, med.nombre, med.apellido
	ORDER BY cantHorasTrabajadas ASC
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Afiliados_Con_Mayor_Cantidad_Bonos_Comprados](@fechaDesde DATE, @fechaHasta DATE)
AS
BEGIN
	IF (@fechaHasta <= @fechaDesde)
	BEGIN
		RAISERROR('@fechaHasta debe ser mayor que @fechaDesde',10,1)
		RETURN
	END

	SELECT TOP 5 p.nombre,p.apellido,p.tipo_doc,p.nro_doc, p.direccion, p.telefono,p.cantidad_familiares, COUNT(DISTINCT b.id) cantBonosComprados
	FROM BETTER_CALL_JUAN.Pacientes p JOIN BETTER_CALL_JUAN.Bonos_Consulta b ON (b.paciente_compra_id=p.id)
	WHERE cast(b.fecha_compra as DATE) BETWEEN @fechaDesde AND @fechaHasta
	GROUP BY p.nombre,p.apellido,p.tipo_doc,p.nro_doc, p.direccion, p.telefono,p.cantidad_familiares
	ORDER BY cantBonosComprados DESC
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Especialidades_Con_Mas_Bonos_Utilizados](@fechaDesde DATE, @fechaHasta DATE)
AS
BEGIN
	IF (@fechaHasta <= @fechaDesde)
	BEGIN
		RAISERROR('@fechaHasta debe ser mayor que @fechaDesde',10,1)
		RETURN
	END

	SELECT TOP 5 e.codigo, e.descripcion, COUNT(DISTINCT c.id) cantBonosUtilizados --porque para cada consulta se usa un bono
	FROM BETTER_CALL_JUAN.Especialidades e 
	JOIN Medicos_Especialidades med_esp ON (e.codigo = med_esp.especialidad_cod)
	JOIN Turnos t ON (t.medico_especialidad_id = med_esp.id)
	JOIN Consultas c ON (c.turno_numero = t.numero)
	WHERE cast(t.fecha_hora as DATE) BETWEEN @fechaDesde AND @fechaHasta
	GROUP BY e.codigo, e.descripcion
	ORDER BY cantBonosUtilizados DESC
END
GO


----------------------------------------

/** TRIGGERS **/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Trigger_Insert_Consulta'))
	DROP TRIGGER BETTER_CALL_JUAN.Trigger_Insert_Consulta
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Trigger_Insert_Afiliado'))
	DROP TRIGGER BETTER_CALL_JUAN.Trigger_Insert_Afiliado
GO

CREATE TRIGGER [BETTER_CALL_JUAN].[Trigger_Insert_Consulta] ON [BETTER_CALL_JUAN].[Consultas] AFTER INSERT
AS
BEGIN
	UPDATE BETTER_CALL_JUAN.Pacientes
	SET nro_ultima_consulta +=1
	FROM inserted i JOIN BETTER_CALL_JUAN.Turnos t ON (i.turno_numero = t.numero) 
	JOIN BETTER_CALL_JUAN.Pacientes p ON (t.paciente_id = p.id)
END
GO

CREATE TRIGGER [BETTER_CALL_JUAN].[Trigger_Insert_Afiliado] ON [BETTER_CALL_JUAN].[Pacientes] AFTER INSERT
AS
BEGIN
	DECLARE @id_nuevo_afiliado NUMERIC(18,0), @nro_raiz_nuevo_afiliado NUMERIC(18,0), 
			@cant_familiares INT, @maxNroPersonalDeGrupo NUMERIC(2,0)
			
	--Obtengo datos insertados

	SELECT @id_nuevo_afiliado=id, @nro_raiz_nuevo_afiliado=nro_raiz from inserted
	
	--Obtengo datos de su familia	

	SELECT @cant_familiares=(COUNT(DISTINCT id)-1) , @maxNroPersonalDeGrupo = MAX(nro_personal)
	FROM BETTER_CALL_JUAN.Pacientes 
	WHERE nro_raiz=@nro_raiz_nuevo_afiliado

	--Actualizo Cant Familiares

	UPDATE BETTER_CALL_JUAN.Pacientes
	SET cantidad_familiares = @cant_familiares
	WHERE nro_raiz=@nro_raiz_nuevo_afiliado

	--Actualizo Nro Personal Al Insertado

	UPDATE BETTER_CALL_JUAN.Pacientes
	SET nro_personal = @maxNroPersonalDeGrupo + 1
	WHERE id=@id_nuevo_afiliado

END
GO
