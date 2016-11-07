--Me conecto a la base de datos a usar
USE [GD2C2016]
GO

--Seteo el primer dia de la semana como Lunes

SET DATEFIRST 1
GO

/** CREACION DE SCHEMA **/
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'BETTER_CALL_JUAN')
BEGIN
    EXEC ('CREATE SCHEMA BETTER_CALL_JUAN AUTHORIZATION gd')
END
GO
/** FIN CREACION DE SCHEMA**/

/** VALIDACION DE TABLAS **/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Ausencias_Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Ausencias_Medicos
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bajas_Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Bajas_Pacientes
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cambios_De_Plan'))
    DROP TABLE BETTER_CALL_JUAN.Cambios_De_Plan
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Consultas'))
    DROP TABLE BETTER_CALL_JUAN.Consultas
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Operaciones_Compra'))
    DROP TABLE BETTER_CALL_JUAN.Operaciones_Compra
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Rangos_Atencion'))
    DROP TABLE BETTER_CALL_JUAN.Rangos_Atencion
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles_Funcionalidades'))
    DROP TABLE BETTER_CALL_JUAN.Roles_Funcionalidades
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles_Usuarios'))
    DROP TABLE BETTER_CALL_JUAN.Roles_Usuarios
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Cancelaciones
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Turnos'))
    DROP TABLE BETTER_CALL_JUAN.Turnos
GO
		
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Bonos_Consulta'))
    DROP TABLE BETTER_CALL_JUAN.Bonos_Consulta
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Funcionalidades'))
    DROP TABLE BETTER_CALL_JUAN.Funcionalidades
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Medicos_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Medicos_Especialidades
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Pacientes
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Planes_Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Planes_Medicos
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Roles'))
    DROP TABLE BETTER_CALL_JUAN.Roles
GO
		
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipos_Cancelaciones'))
    DROP TABLE BETTER_CALL_JUAN.Tipos_Cancelaciones
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Medicos'))
    DROP TABLE BETTER_CALL_JUAN.Medicos
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Especialidades
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Tipos_Especialidades'))
    DROP TABLE BETTER_CALL_JUAN.Tipos_Especialidades
GO
	
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Usuarios'))
    DROP TABLE BETTER_CALL_JUAN.Usuarios
GO
	
/** FIN VALIDACION DE TABLAS **/

/** CREACION DE TABLAS **/

CREATE TABLE [BETTER_CALL_JUAN].[Funcionalidades] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [descripcion] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Usuarios] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [username] VARCHAR(255) UNIQUE NOT NULL,
  [password] VARCHAR(255) NOT NULL,
  [intentos_fallidos] SMALLINT DEFAULT 0 NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Roles] (
  [id] SMALLINT IDENTITY(1,1),
  [nombre] VARCHAR(255) UNIQUE NOT NULL,
  [habilitado] BIT DEFAULT 1  NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Operaciones_Compra] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [cant_bonos] NUMERIC(4,0) NOT NULL,
  [monto_total] NUMERIC(18,0) NOT NULL,
  [paciente_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Turnos] (
  [numero] NUMERIC(18,0) IDENTITY(1,1),
  [fecha_hora] DATETIME NOT NULL,
  [paciente_id] NUMERIC(18,0),
  [medico_especialidad_id] NUMERIC(18,0) NOT NULL,
  [turno_numero_maestra] NUMERIC(18,0),
  PRIMARY KEY ([numero])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [medico_id] NUMERIC(18,0) NOT NULL,
  [especialidad_cod] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Cancelaciones] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [tipo_cancelacion_id] NUMERIC(18,0) NOT NULL,
  [motivo] VARCHAR(255) NOT NULL,
  [turno_numero] NUMERIC(18,0) NOT NULL UNIQUE,
  [paciente_id] NUMERIC(18,0),
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] (
  [user_id] NUMERIC(18,0),
  [rol_id] SMALLINT NOT NULL,
  PRIMARY KEY ([user_id], [rol_id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Especialidades] (
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255) NOT NULL,
  [tipo_especialidad_cod] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([codigo])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Tipos_Cancelaciones] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nombre] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Consultas] (
  [id] INT IDENTITY(1,1),
  [sintomas] VARCHAR(255),
  [enfermedades] VARCHAR(255),
  [turno_numero] NUMERIC(18,0) NOT NULL,
  [fecha_hora_llegada] DATETIME NOT NULL,
  [fecha_hora_atencion] DATETIME,
  [bono_consulta_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Bajas_Pacientes] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [paciente_id] NUMERIC(18,0) NOT NULL,
  [fecha_baja] DATETIME NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Tipos_Especialidades] (
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255) NOT NULL,
  PRIMARY KEY ([codigo])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] (
  [rol_id] SMALLINT,
  [funcionalidad_id] NUMERIC(18,0),
  PRIMARY KEY ([rol_id],[funcionalidad_id])
);
GO
	
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
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Planes_Medicos] (
  [codigo] NUMERIC(18,0),
  [descripcion] VARCHAR(255) NOT NULL,
  [precio_bono_consulta] NUMERIC(18,0) NOT NULL,
  [precio_bono_farmacia] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([codigo])
);
GO
	
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
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Pacientes] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [nro_raiz] NUMERIC(18,0) NOT NULL,
  [nro_personal] NUMERIC(2,0) DEFAULT 01 NOT NULL,
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
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Cambios_De_Plan] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [paciente_id] NUMERIC(18,0) NOT NULL,
  [fecha_cambio] DATETIME NOT NULL,
  [motivo_cambio] VARCHAR(500) NOT NULL,
  [plan_anterior_id] NUMERIC(18,0) NOT NULL,
  [plan_nuevo_id] NUMERIC(18,0) NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
CREATE TABLE [BETTER_CALL_JUAN].[Rangos_Atencion] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [dia_semana] NUMERIC(1,0) NOT NULL,
  [hora_desde] TIME NOT NULL,
  [hora_hasta] TIME NOT NULL,
  [medico_especialidad_id] NUMERIC(18,0),
  [fecha_desde] DATE NOT NULL,
  [fecha_hasta] DATE NOT NULL,
  PRIMARY KEY ([id])
);
GO

CREATE TABLE [BETTER_CALL_JUAN].[Ausencias_Medicos] (
  [id] NUMERIC(18,0) IDENTITY(1,1),
  [medico_id] NUMERIC(18,0) NOT NULL,
  [fecha_desde] DATETIME NOT NULL,
  [fecha_hasta] DATETIME NOT NULL,
  PRIMARY KEY ([id])
);
GO
	
/** FIN CREACION DE TABLAS **/

/** MIGRACION **/

/* Tabla Pacientes */

--Nros Ultimas Consultas
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Consultas_Pacientes'))
    DROP TABLE BETTER_CALL_JUAN.Consultas_Pacientes
GO
		

CREATE TABLE [BETTER_CALL_JUAN].[Consultas_Pacientes] (
	[Paciente_Dni] NUMERIC(18,0),
	[Bono_Consulta_Numero] NUMERIC(18,0),
	[Bono_Consulta_Fecha_Impresion] DATETIME,
	[Plan_Med_Codigo] NUMERIC(18,0),
	[Turno_Numero] NUMERIC(18,0)
);
GO
	
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
GO
	
--INSERT PACIENTES

INSERT INTO BETTER_CALL_JUAN.Pacientes (nro_raiz,nombre, apellido, tipo_doc,nro_doc,direccion,telefono,mail,fecha_nac,plan_medico_cod,habilitado,nro_ultima_consulta)
SELECT DISTINCT 0,Paciente_Nombre, Paciente_Apellido, 'DNI', Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, 
Plan_Med_Codigo, 1, (SELECT COUNT(DISTINCT cp.Bono_Consulta_Numero) FROM BETTER_CALL_JUAN.Consultas_Pacientes cp WHERE cp.Paciente_Dni = m.Paciente_Dni GROUP BY cp.Paciente_Dni) AS nroUltimaConsulta
FROM gd_esquema.Maestra m
GROUP BY Paciente_Nombre, Paciente_Apellido,Paciente_Dni, Paciente_Direccion, Paciente_Telefono, Paciente_Mail, Paciente_Fecha_Nac, Plan_Med_Codigo
GO

UPDATE BETTER_CALL_JUAN.Pacientes
SET nro_raiz=id
	
/* Tabla Medicos */
INSERT INTO BETTER_CALL_JUAN.Medicos(nombre, apellido, tipo_doc, nro_doc, direccion, telefono, mail, fecha_nac)
SELECT DISTINCT Medico_Nombre, Medico_Apellido, 'DNI', Medico_Dni, Medico_Direccion, Medico_Telefono, Medico_Mail, Medico_Fecha_Nac
FROM gd_esquema.Maestra
WHERE Medico_Dni IS NOT NULL
GO
	
/* Tabla Planes Medicos */
INSERT INTO BETTER_CALL_JUAN.Planes_Medicos(codigo, descripcion, precio_bono_consulta, precio_bono_farmacia)
SELECT DISTINCT Plan_Med_Codigo, Plan_Med_Descripcion, Plan_Med_Precio_Bono_Consulta, Plan_Med_Precio_Bono_Farmacia
FROM gd_esquema.Maestra
GO
	
/* Tabla Especialidades */
INSERT INTO BETTER_CALL_JUAN.Especialidades (codigo,descripcion,tipo_especialidad_cod)
SELECT DISTINCT Especialidad_Codigo, Especialidad_Descripcion, Tipo_Especialidad_Codigo
FROM gd_esquema.Maestra
WHERE Especialidad_Codigo IS NOT NULL
GO
	
/* Tabla Tipos Especialidades */
INSERT INTO BETTER_CALL_JUAN.Tipos_Especialidades (codigo,descripcion)
SELECT DISTINCT Tipo_Especialidad_Codigo, Tipo_Especialidad_Descripcion
FROM gd_esquema.Maestra
WHERE Tipo_Especialidad_Codigo IS NOT NULL
GO
	
/* Tabla Medicos Especialidades */

INSERT INTO BETTER_CALL_JUAN.Medicos_Especialidades(medico_id, especialidad_cod)
SELECT DISTINCT med.matricula, Especialidad_Codigo 
FROM gd_esquema.Maestra maestra JOIN BETTER_CALL_JUAN.Medicos med ON (maestra.Medico_Dni=med.nro_doc)
ORDER BY med.matricula, Especialidad_Codigo
GO
	
/* Tabla Turnos */

INSERT INTO BETTER_CALL_JUAN.Turnos (fecha_hora,paciente_id,medico_especialidad_id, turno_numero_maestra)
SELECT DISTINCT Turno_Fecha, p.id AS paciente_id, 
(SELECT id FROM BETTER_CALL_JUAN.Medicos_Especialidades WHERE medico_id=med.matricula AND especialidad_cod=maestra.Especialidad_Codigo) AS medico_especialidad_id,
maestra.Turno_Numero
FROM gd_esquema.Maestra maestra JOIN BETTER_CALL_JUAN.Pacientes p ON (maestra.Paciente_Dni  =  p.nro_doc) JOIN BETTER_CALL_JUAN.Medicos med ON (maestra.Medico_Dni = med.nro_doc)
WHERE Turno_Numero IS NOT NULL AND Turno_Fecha IS NOT NULL
ORDER BY 1 ASC
GO
	
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
GO
	
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
GO
	
/* Tabla Roles Funcionalidades */
INSERT INTO BETTER_CALL_JUAN.Roles_Funcionalidades(rol_id,funcionalidad_id)
VALUES(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9),(1,10),(1,11),(1,12),(1,13),(1,14),(1,15),(1,16),
(2,7),(2,8),(2,14),(2,15),(2,16),(2,5),
(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,11),(3,16),
(4,5),(4,9),(4,16)
GO
	
/* Tabla Usuarios */
INSERT INTO BETTER_CALL_JUAN.Usuarios(username, password)
VALUES('admin',HASHBYTES('SHA2_256','w23e'))
GO
	
INSERT INTO BETTER_CALL_JUAN.Usuarios(username, password)
SELECT tipo_doc+cast(nro_doc as varchar), HASHBYTES('SHA2_256', 'afiliadofrba') password
FROM BETTER_CALL_JUAN.Pacientes
GO
	
INSERT INTO BETTER_CALL_JUAN.Usuarios(username, password)
SELECT tipo_doc+cast(nro_doc as varchar), HASHBYTES('SHA2_256', 'profesionalfrba') password
FROM BETTER_CALL_JUAN.Medicos
GO
	
/* Tabla Roles Usuarios */
INSERT INTO BETTER_CALL_JUAN.Roles_Usuarios(user_id,rol_id)
VALUES(1,1)
GO
	
INSERT INTO BETTER_CALL_JUAN.Roles_Usuarios(user_id,rol_id)
SELECT u.id, 2 rol
FROM BETTER_CALL_JUAN.Pacientes p JOIN BETTER_CALL_JUAN.Usuarios u ON ((p.tipo_doc+ cast(p.nro_doc as varchar)) = u.username)
GO
	
INSERT INTO BETTER_CALL_JUAN.Roles_Usuarios(user_id,rol_id)
SELECT u.id, 4 rol
FROM BETTER_CALL_JUAN.Medicos m JOIN BETTER_CALL_JUAN.Usuarios u ON ((m.tipo_doc+ cast(m.nro_doc as varchar)) = u.username)
GO
	
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
GO
	
DROP TABLE BETTER_CALL_JUAN.Consultas_Pacientes
GO
	
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
GO
	
/* Tabla Operaciones Compra */

INSERT INTO BETTER_CALL_JUAN.Operaciones_Compra (cant_bonos, monto_total, paciente_id)
SELECT COUNT(DISTINCT Bono_Consulta_Numero) cantBonos, SUM(Plan_Med_Precio_Bono_Consulta) montoTotal, p.id pacienteID
FROM gd_esquema.Maestra m JOIN BETTER_CALL_JUAN.Pacientes p ON (m.Paciente_Dni = p.nro_doc)
WHERE Compra_Bono_Fecha IS NOT NULL
GROUP BY p.id, Compra_Bono_Fecha
GO
	
/* Asociacion Pacientes y Medicos con su usuario id */
UPDATE BETTER_CALL_JUAN.Pacientes 
SET usuario_id = u.id 
FROM(
SELECT id, username
FROM BETTER_CALL_JUAN.Usuarios) u
WHERE (Pacientes.tipo_doc + CONVERT(VARCHAR(255),Pacientes.nro_doc)) = u.username
GO
	
UPDATE BETTER_CALL_JUAN.Medicos 
SET usuario_id = u.id 
FROM(
SELECT id, username
FROM BETTER_CALL_JUAN.Usuarios) u
WHERE (Medicos.tipo_doc + CONVERT(VARCHAR(255),Medicos.nro_doc)) = u.username
GO
	

/* Tabla Tipos Cancelaciones */

INSERT INTO BETTER_CALL_JUAN.Tipos_Cancelaciones(nombre) VALUES ('Viaje'),('Enfermedad'),('Otro')
GO
	
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

ALTER TABLE [BETTER_CALL_JUAN].[Turnos] WITH NOCHECK ADD CONSTRAINT paciente_id_turno FOREIGN KEY (paciente_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)
ALTER TABLE [BETTER_CALL_JUAN].[Turnos] ADD CONSTRAINT medico_especialidad_id_turno FOREIGN KEY (medico_especialidad_id) REFERENCES [BETTER_CALL_JUAN].[Medicos_Especialidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Cancelaciones] ADD CONSTRAINT tipo_cancelacion_id_cancelacion FOREIGN KEY (tipo_cancelacion_id) REFERENCES [BETTER_CALL_JUAN].[Tipos_Cancelaciones](id)
ALTER TABLE [BETTER_CALL_JUAN].[Cancelaciones] ADD CONSTRAINT turno_numero_cancelacion FOREIGN KEY (turno_numero) REFERENCES [BETTER_CALL_JUAN].[Turnos](numero)
ALTER TABLE [BETTER_CALL_JUAN].[Cancelaciones] WITH NOCHECK ADD CONSTRAINT paciente_id_cancelacion FOREIGN KEY (paciente_id) REFERENCES [BETTER_CALL_JUAN].[Pacientes](id)

ALTER TABLE [BETTER_CALL_JUAN].[Rangos_Atencion] ADD CONSTRAINT medico_especialidad_id_rango_atencion FOREIGN KEY (medico_especialidad_id) REFERENCES [BETTER_CALL_JUAN].[Medicos_Especialidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Especialidades] ADD CONSTRAINT tipo_especialidad_cod_especialidades FOREIGN KEY (tipo_especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Tipos_Especialidades](codigo)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos] ADD CONSTRAINT usuario_id_medicos FOREIGN KEY (usuario_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT user_id_roles_usuarios FOREIGN KEY (user_id) REFERENCES [BETTER_CALL_JUAN].[Usuarios](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Usuarios] ADD CONSTRAINT rol_id_roles_usuarios FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)

ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT rol_id_roles_funcionalidades FOREIGN KEY (rol_id) REFERENCES [BETTER_CALL_JUAN].[Roles](id)
ALTER TABLE [BETTER_CALL_JUAN].[Roles_Funcionalidades] ADD CONSTRAINT funcionalidad_id_roles_funcionalidades FOREIGN KEY (funcionalidad_id) REFERENCES [BETTER_CALL_JUAN].[Funcionalidades](id)

ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT medico_id_medicos_especialidades FOREIGN KEY (medico_id) REFERENCES [BETTER_CALL_JUAN].[Medicos](matricula)
ALTER TABLE [BETTER_CALL_JUAN].[Medicos_Especialidades] ADD CONSTRAINT especialidad_cod_medicos_especialidades FOREIGN KEY (especialidad_cod) REFERENCES [BETTER_CALL_JUAN].[Especialidades](codigo)

ALTER TABLE [BETTER_CALL_JUAN].[Ausencias_Medicos] ADD CONSTRAINT medico_id_ausencias_medicos FOREIGN KEY (medico_id) REFERENCES [BETTER_CALL_JUAN].[Medicos](matricula)

GO
	

IF EXISTS (SELECT * FROM sys.all_columns WHERE name='turno_numero_maestra')
	ALTER TABLE [BETTER_CALL_JUAN].[Turnos] DROP COLUMN turno_numero_maestra
GO
	
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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Usuario_Id'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Usuario_Id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Paciente_Id'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Paciente_Id
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

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Obtener_Estado_Habilitado_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Obtener_Estado_Habilitado_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Nombres_Especialidades'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Nombres_Especialidades
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Especialidades'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Especialidades
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Habilitar_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Habilitar_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Eliminar_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Eliminar_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Modificar_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Modificar_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Borrar_Funcionalidad_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Borrar_Funcionalidad_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Rol'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Rol
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Rol_Habilitado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Rol_Habilitado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Afiliados_Filtros'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Afiliados_Filtros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Consulta'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Consulta
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Registro_Resultado_Consulta'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Registro_Resultado_Consulta
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Tipos_Especialidades'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Tipos_Especialidades
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Especialidades_Filtros'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Especialidades_Filtros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Plan_Por_Nombre'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Plan_Por_Nombre
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Medicos'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Medicos
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Medicos_Filtros'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Medicos_Filtros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Cancelar_Turno_Dia_Profesional'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Cancelar_Turno_Dia_Profesional
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Cancelar_Turnos_Franja_Profesional'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Cancelar_Turnos_Franja_Profesional
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Medico_Y_Especialidad_Para_Turno'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Medico_Y_Especialidad_Para_Turno
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Cancelar_Turno_Afiliado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Cancelar_Turno_Afiliado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Plan_Por_Usuario_Id'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Plan_Por_Usuario_Id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Fechas_Disponibles_Para_Turno'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Fechas_Disponibles_Para_Turno
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Horarios_Disponibles_Para_Turno'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Horarios_Disponibles_Para_Turno
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Especialidades_Medico'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Especialidades_Medico
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Medico_Para_Agenda'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Medico_Para_Agenda
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Turnos_Fecha_Por_Medico'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Turnos_Fecha_Por_Medico
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Validar_Documento'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Validar_Documento
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Registro_Llegada_Afiliado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Registro_Llegada_Afiliado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Afiliados_Por_Documento'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Afiliados_Por_Documento
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Rangos_Atencion_Medico'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Rangos_Atencion_Medico
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Medico_Por_Usuario_Id'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Medico_Por_Usuario_Id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Buscar_Consultas_Con_Filtros'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Buscar_Consultas_Con_Filtros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Crear_Rango_Horario_Medico'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Crear_Rango_Horario_Medico
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Afiliado_Bonos_Disponibles'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Afiliado_Bonos_Disponibles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Paciente_Id_Segun_Nro_Afiliado'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Paciente_Id_Segun_Nro_Afiliado
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Get_Horas_Trabajadas_Medico'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Get_Horas_Trabajadas_Medico
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Get_Medicos_De_Turnos_Por_Usuario'))
	DROP PROCEDURE BETTER_CALL_JUAN.Get_Medicos_De_Turnos_Por_Usuario
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Get_Turnos_Por_Usuario'))
	DROP PROCEDURE BETTER_CALL_JUAN.Get_Turnos_Por_Usuario
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Get_Turnos_Por_Usuario_Con_Filtros'))
	DROP PROCEDURE BETTER_CALL_JUAN.Get_Turnos_Por_Usuario_Con_Filtros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Get_Tipo_Cancelaciones'))
	DROP PROCEDURE BETTER_CALL_JUAN.Get_Tipo_Cancelaciones
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Afiliado_Cantidad_Bonos_Disponibles'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Afiliado_Cantidad_Bonos_Disponibles
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Anios_Top_5_Especialidades_Mas_Bonos'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Anios_Top_5_Especialidades_Mas_Bonos
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Anios_Top_5_Afiliados_Mas_Bonos'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Anios_Top_5_Afiliados_Mas_Bonos
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Anios_Top_5_Profesionales_Menos_Horas'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Anios_Top_5_Profesionales_Menos_Horas
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Anios_Top_5_Profesionales_Mas_Consultados'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Anios_Top_5_Profesionales_Mas_Consultados
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Anios_Top_5_Mas_Cancelaciones'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Anios_Top_5_Mas_Cancelaciones
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Get_Turnos_Con_Filtros'))
	DROP PROCEDURE BETTER_CALL_JUAN.Get_Turnos_Con_Filtros
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Procedure_Cancelar_Turno'))
	DROP PROCEDURE BETTER_CALL_JUAN.Procedure_Cancelar_Turno
GO

--------

CREATE PROCEDURE [BETTER_CALL_JUAN].[Get_Turnos_Con_Filtros]
(@fecha_a_buscar DATETIME, @nombre_medico VARCHAR(255), @apellido_medico VARCHAR(255), @nombre_paciente VARCHAR(255), @apellido_paciente VARCHAR(255))
AS
BEGIN
	DECLARE @QUERY_1 NVARCHAR(2000) = 'SELECT T.numero, T.fecha_hora, T.medico_especialidad_id, T.paciente_id, M.apellido, M.nombre, E.descripcion, 
									P.nombre, P.apellido, P.tipo_doc, P.nro_doc
									FROM BETTER_CALL_JUAN.Turnos T
									JOIN BETTER_CALL_JUAN.Pacientes P ON P.id = T.paciente_id
									JOIN BETTER_CALL_JUAN.Medicos_Especialidades ME ON T.medico_especialidad_id = ME.id
									JOIN BETTER_CALL_JUAN.Especialidades E ON E.codigo = ME.especialidad_cod
									JOIN BETTER_CALL_JUAN.Medicos M ON M.matricula = ME.medico_id
									WHERE P.nombre like @nombre_paciente AND P.apellido like @apellido_paciente
									AND M.nombre like @nombre_medico AND M.apellido like @apellido_medico
									AND DATEDIFF(day, @fecha_a_buscar, T.fecha_hora) = 0
									ORDER BY T.fecha_hora DESC'
			
	SET @nombre_medico = '%' + @nombre_medico + '%'
	SET @apellido_medico = '%' + @apellido_medico + '%'
	SET @nombre_paciente = '%' + @nombre_paciente + '%'
	SET @apellido_paciente = '%' + @apellido_paciente + '%'

	EXEC sp_executesql @QUERY_1, N'@fecha_a_buscar DATETIME, @nombre_medico VARCHAR(255), @apellido_medico VARCHAR(255), @nombre_paciente VARCHAR(255), @apellido_paciente VARCHAR(255)',
				@fecha_a_buscar, @nombre_medico, @apellido_medico, @nombre_paciente, @apellido_paciente
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Get_Tipo_Cancelaciones]
AS
BEGIN
	SELECT TC.id, TC.nombre
	FROM BETTER_CALL_JUAN.Tipos_Cancelaciones TC
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Get_Turnos_Por_Usuario_Con_Filtros]
(@usuario_id NUMERIC(18,0), @fecha_turno DATETIME, @medico_matricula NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(2000)
	DECLARE @QUERY_1 VARCHAR(900) = 'SELECT T.numero, T.fecha_hora, T.medico_especialidad_id, T.paciente_id, M.apellido, M.nombre, E.descripcion
									FROM BETTER_CALL_JUAN.Turnos T
									JOIN BETTER_CALL_JUAN.Pacientes P ON P.id = T.paciente_id
									JOIN BETTER_CALL_JUAN.Medicos_Especialidades ME ON T.medico_especialidad_id = ME.id
									JOIN BETTER_CALL_JUAN.Especialidades E ON E.codigo = ME.especialidad_cod
									JOIN BETTER_CALL_JUAN.Medicos M ON M.matricula = ME.medico_id
									WHERE P.usuario_id = @usuario_id'
	DECLARE @QUERY_2 VARCHAR(800) = ''
	DECLARE @QUERY_3 VARCHAR(800) = ''
	DECLARE @QUERY_4 VARCHAR(800) = ' ORDER BY T.fecha_hora DESC'

	IF @fecha_turno IS NOT NULL
		BEGIN
			SET @QUERY_2 = ' AND DATEDIFF(day, @fecha_turno, T.fecha_hora) = 0'
		END

	IF @medico_matricula > 0
		BEGIN
			SET @QUERY_3 = ' AND M.matricula = @medico_matricula'
		END

			
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4

	EXEC sp_executesql @QUERY_FINAL, N'@usuario_id NUMERIC(18,0), @fecha_turno DATETIME, @medico_matricula NUMERIC(18,0)',
				@usuario_id, @fecha_turno, @medico_matricula
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Get_Turnos_Por_Usuario]
(@usuario_id NUMERIC(18,0))
AS
BEGIN
	SELECT T.numero, T.fecha_hora, T.medico_especialidad_id, T.paciente_id, M.apellido, M.nombre, E.descripcion
	FROM BETTER_CALL_JUAN.Turnos T
	JOIN BETTER_CALL_JUAN.Pacientes P ON P.id = T.paciente_id
	JOIN BETTER_CALL_JUAN.Medicos_Especialidades ME ON T.medico_especialidad_id = ME.id
	JOIN BETTER_CALL_JUAN.Especialidades E ON E.codigo = ME.especialidad_cod
	JOIN BETTER_CALL_JUAN.Medicos M ON M.matricula = ME.medico_id
	WHERE P.usuario_id = @usuario_id
	ORDER BY T.fecha_hora DESC
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Get_Medicos_De_Turnos_Por_Usuario]
(@usuario_id NUMERIC(18,0))
AS
BEGIN
	SELECT DISTINCT m.matricula, m.nombre,m.apellido,m.tipo_doc,m.nro_doc,m.direccion,m.telefono,m.mail,m.fecha_nac,m.sexo, m.usuario_id
	FROM BETTER_CALL_JUAN.Medicos m
	JOIN BETTER_CALL_JUAN.Pacientes P ON P.usuario_id = @usuario_id
	JOIN BETTER_CALL_JUAN.Turnos T ON T.paciente_id = P.id
	JOIN BETTER_CALL_JUAN.Medicos_Especialidades ME ON ME.id = T.medico_especialidad_id
	WHERE m.matricula = ME.medico_id
	ORDER BY m.apellido, m.nombre, m.matricula
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Horas_Trabajadas_Medico] (@medico_id NUMERIC(18,0), @fd DATETIME, @fh DATETIME, @horas_trabajadas NUMERIC(18,0) OUT)
AS
BEGIN
DECLARE @fecha_desde DATE, @fecha_hasta DATE
SET @fecha_desde = CONVERT(DATE, @fd)
SET @fecha_hasta = CONVERT(DATE, @fh)
IF EXISTS (SELECT ra.id
		   FROM BETTER_CALL_JUAN.Rangos_Atencion ra JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (ra.medico_especialidad_id = me.id)
		   WHERE me.medico_id = @medico_id
		   AND (@fecha_desde between fecha_desde and fecha_hasta)
		   OR (@fecha_desde between fecha_desde and fecha_hasta) 
		   OR (fecha_desde between @fecha_desde and @fecha_hasta) 
		   OR (fecha_hasta between @fecha_desde and @fecha_hasta)
		   )
	BEGIN
		   SET @horas_trabajadas = (SELECT SUM(DATEDIFF(HH, hora_desde, hora_hasta))
		   FROM BETTER_CALL_JUAN.Rangos_Atencion ra JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (ra.medico_especialidad_id = me.id)
		   WHERE me.medico_id = @medico_id
		   AND (@fecha_desde between fecha_desde and fecha_hasta)
		   OR (@fecha_desde between fecha_desde and fecha_hasta) 
		   OR (fecha_desde between @fecha_desde and @fecha_hasta) 
		   OR (fecha_hasta between @fecha_desde and @fecha_hasta))
	END

	ELSE
	BEGIN
		SET @horas_trabajadas = 0
	END
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Paciente_Id_Segun_Nro_Afiliado] (@nro_raiz NUMERIC(18,0), @nro_personal NUMERIC(18,0), @paciente_id NUMERIC(18,0) OUT)
AS
BEGIN	
	SELECT @paciente_id = id
	FROM BETTER_CALL_JUAN.Pacientes
	WHERE nro_raiz=@nro_raiz AND nro_personal=@nro_personal

	IF @paciente_id IS NULL
		SET @paciente_id = 0

	RETURN @paciente_id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Crear_Rango_Horario_Medico] (@dia_semana NUMERIC(1,0), @hd DATETIME, @hh DATETIME, @fd DATETIME, @fh DATETIME, @medico_id NUMERIC(18,0), @especialidad_id NUMERIC(18,0))
AS
BEGIN
DECLARE @hora_desde TIME, @hora_hasta TIME, @meid NUMERIC(18,0), @hsTrabajadas NUMERIC(18,0), @fecha_desde DATE, @fecha_hasta DATE
SET @hora_desde = CONVERT(TIME, @hd)
SET @hora_hasta = CONVERT(TIME, @hh)
SET @fecha_desde = CONVERT(DATE, @fd)
SET @fecha_hasta = CONVERT(DATE, @fh)

SET @meid = (SELECT id FROM BETTER_CALL_JUAN.Medicos_Especialidades WHERE medico_id = @medico_id AND especialidad_cod = @especialidad_id)

SET @hsTrabajadas = (SELECT SUM(DATEDIFF(HH,ra.hora_desde,ra.hora_hasta))
					FROM BETTER_CALL_JUAN.Rangos_Atencion ra JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (ra.medico_especialidad_id = me.id)
					WHERE me.medico_id = @medico_id
					AND (@fecha_desde between fecha_desde and fecha_hasta)
					OR (@fecha_desde between fecha_desde and fecha_hasta) 
					OR (fecha_desde between @fecha_desde and @fecha_hasta) 
					OR (fecha_hasta between @fecha_desde and @fecha_hasta)) + DATEDIFF(HH,@hd,@hh)

IF (@hsTrabajadas > 48)
	BEGIN
	RAISERROR('Las horas trabajadas semanalmente no pueden superar las 48 hs',14,1)
	END

	ELSE IF EXISTS (
	SELECT ra.id 
	FROM BETTER_CALL_JUAN.Rangos_Atencion ra JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (ra.medico_especialidad_id = me.id)
	WHERE me.medico_id = @medico_id
	AND dia_semana = @dia_semana 
	AND ((@hora_desde > hora_desde AND  @hora_desde <hora_hasta)
	OR (@hora_hasta > hora_desde AND @hora_hasta < hora_hasta)
	OR (hora_desde > @hora_desde AND hora_desde < @hora_hasta)
	OR (hora_hasta > @hora_desde AND hora_hasta < @hora_hasta) 
	OR (@hora_desde = hora_desde AND @hora_hasta = hora_hasta))
	AND ((@fecha_desde between fecha_desde and fecha_hasta)
	OR (@fecha_hasta between fecha_desde and fecha_hasta) 
	OR (fecha_desde between @fecha_desde and @fecha_hasta) 
	OR (fecha_hasta between @fecha_desde and @fecha_hasta)))
	BEGIN
	RAISERROR('Ya tiene un rango asignado dentro del rango seleccionado',14,1)
	END

	ELSE
	BEGIN 
	INSERT INTO BETTER_CALL_JUAN.Rangos_Atencion (dia_semana, hora_desde, hora_hasta, medico_especialidad_id, fecha_desde, fecha_hasta) VALUES (@dia_semana, @hd, @hh, @meid, @fd, @fh)
	END
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Consultas_Con_Filtros]
(@nombre_paciente VARCHAR(255), @apellido_paciente VARCHAR(255), @especialidad_codigo NUMERIC(18,0), @medico_matricula NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_1 NVARCHAR(1500) = 'SELECT C.id, C.bono_consulta_id, C.enfermedades, C.fecha_hora_atencion, C.fecha_hora_llegada, C.sintomas, C.turno_numero,
									 P.nombre, P.apellido, E.descripcion
									 FROM BETTER_CALL_JUAN.Consultas C
									 JOIN BETTER_CALL_JUAN.Medicos_Especialidades ME ON (ME.medico_id = @medico_matricula AND ME.especialidad_cod = @especialidad_codigo)
									 JOIN BETTER_CALL_JUAN.Especialidades E ON E.codigo = ME.especialidad_cod
									 JOIN BETTER_CALL_JUAN.Pacientes P ON (P.apellido like @apellido_paciente AND P.nombre like @nombre_paciente)
									 JOIN BETTER_CALL_JUAN.Turnos T ON (T.numero = C.turno_numero AND T.paciente_id = P.id)
									 WHERE C.fecha_hora_llegada IS NOT NULL AND C.fecha_hora_atencion IS NULL'

	SET @nombre_paciente = '%' + @nombre_paciente + '%'
	SET @apellido_paciente = '%' + @apellido_paciente + '%'

	EXEC sp_executesql @QUERY_1, N'@nombre_paciente VARCHAR(255), @apellido_paciente VARCHAR(255),
				@especialidad_codigo NUMERIC(18,0), @medico_matricula NUMERIC(18,0)', @nombre_paciente, @apellido_paciente, @especialidad_codigo, @medico_matricula
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Medico_Por_Usuario_Id] (@usuario_id NUMERIC(18,0))
AS
BEGIN
	SELECT m.matricula, m.nombre,m.apellido,m.tipo_doc,m.nro_doc,m.direccion,m.telefono,m.mail,m.fecha_nac,m.sexo, m.usuario_id
	FROM BETTER_CALL_JUAN.Medicos m
	WHERE m.usuario_id = @usuario_id
	ORDER BY m.apellido, m.nombre, m.matricula
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Rangos_Atencion_Medico] (@matricula NUMERIC(18,0))
AS
BEGIN
	SELECT r.id,r.dia_semana,r.hora_desde,r.hora_hasta,r.medico_especialidad_id
	FROM BETTER_CALL_JUAN.Rangos_Atencion r 
	JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (r.medico_especialidad_id=med_esp.id AND med_esp.medico_id=@matricula)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Afiliados_Por_Documento]
(@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0))
AS
BEGIN
	SELECT p.id,p.nro_raiz,p.nro_personal,p.nombre,p.apellido,p.tipo_doc,p.nro_doc,p.direccion,p.telefono,p.mail,
	p.fecha_nac,p.sexo,p.estado_civil,p.cantidad_familiares,p.plan_medico_cod, p.nro_ultima_consulta
	FROM BETTER_CALL_JUAN.Pacientes p
	WHERE p.nro_doc = @nro_doc AND p.tipo_doc=@tipo_doc AND p.habilitado=1
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Validar_Documento]
(@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0), @retorno SMALLINT OUT)
AS
BEGIN
	DECLARE @idUsuario NUMERIC(18,0)

	SELECT @idUsuario=id
	FROM BETTER_CALL_JUAN.Pacientes P
	WHERE P.tipo_doc like @tipo_doc AND P.nro_doc = @nro_doc

	IF (@idUsuario IS NULL) 
		SET @retorno= 1	-- No existe el usuario, es correcto que lo creemos
	ELSE 
		SET @retorno = 0 -- Ya existe un usuario con ese tipo y numero de documento
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Horarios_Disponibles_Para_Turno]
(@medico_id NUMERIC(18,0),@especialidad_codigo NUMERIC(18,0),@fecha DATETIME)
AS
BEGIN
	DECLARE @diaSemana SMALLINT, @cantTurnos INT, @i INT=0, @hora_desde TIME, @hora_hasta TIME, 
	@hora_turno TIME, @medico_especialidad_id NUMERIC(18,0), @fecha_hora_turno DATETIME

	CREATE TABLE #horarios
	(
	hora TIME
	)

	SET @diaSemana = DATEPART(dw,@fecha)

	SELECT @medico_especialidad_id=id
	FROM BETTER_CALL_JUAN.Medicos_Especialidades
	WHERE medico_id=@medico_id AND especialidad_cod=@especialidad_codigo

	SELECT r.hora_desde,r.hora_hasta INTO #rangosTemp
	FROM BETTER_CALL_JUAN.Rangos_Atencion r 
	JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (r.medico_especialidad_id = med_esp.id)
	WHERE med_esp.medico_id=@medico_id AND med_esp.especialidad_cod=@especialidad_codigo AND r.dia_semana=@diaSemana
			AND (@fecha BETWEEN r.fecha_desde AND r.fecha_hasta)

	DECLARE rangoCursor CURSOR FOR
	SELECT hora_desde,hora_hasta 
	FROM #rangosTemp

	OPEN rangoCursor

	FETCH rangoCursor INTO @hora_desde, @hora_hasta

	WHILE @@FETCH_STATUS = 0 
	BEGIN
		SET @cantTurnos = DATEDIFF(mi,@hora_desde,@hora_hasta)/30

		SET @i=0

		WHILE @i < @cantTurnos
		BEGIN
			SET @hora_turno = DATEADD(mi,30*@i,@hora_desde)
			SET @fecha_hora_turno= @fecha + cast(@hora_turno as DATETIME)
			IF NOT EXISTS ( SELECT t.numero	FROM BETTER_CALL_JUAN.Turnos t 
							WHERE t.medico_especialidad_id=@medico_especialidad_id 
							AND DATEDIFF(mi,t.fecha_hora,@fecha_hora_turno)=0 AND t.paciente_id IS NOT NULL
							)
			BEGIN			
				INSERT INTO #horarios (hora) VALUES (@hora_turno)
			END			

			SET @i = @i + 1
		END

		FETCH rangoCursor INTO @hora_desde, @hora_hasta
	END

	CLOSE rangoCursor
	DEALLOCATE rangoCursor

	SELECT hora FROM #horarios
		
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Fechas_Disponibles_Para_Turno](@medico_id NUMERIC(18,0),@especialidad_codigo NUMERIC(18,0), @fecha_hoy DATETIME)
AS
BEGIN
	CREATE TABLE #fechasTemp(fecha DATE)

	DECLARE @i INT = 0, @unaFecha DATE, @estaDisponibleFecha BIT

	WHILE @i<60
	BEGIN
		SET @unaFecha = DATEADD(dd,@i,@fecha_hoy)
		SET @estaDisponibleFecha= [BETTER_CALL_JUAN].[Function_Fecha_Esta_Disponible_Para_Turno](@unaFecha,@medico_id,@especialidad_codigo)
		IF( @estaDisponibleFecha=1)
		BEGIN
			INSERT INTO #fechasTemp (fecha) VALUES (@unaFecha)		
		END

		SET @i= @i+1
	END	

	SELECT fecha FROM #fechasTemp
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Medico_Y_Especialidad_Para_Turno](@nombre VARCHAR(255),@apellido VARCHAR(255), @especialidad_codigo NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(500) = 'SELECT DISTINCT m.matricula,m.nombre,m.apellido, e.codigo, e.descripcion
									 FROM BETTER_CALL_JUAN.Medicos m JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med_esp.medico_id=m.matricula)
									 JOIN BETTER_CALL_JUAN.Especialidades e ON (med_esp.especialidad_cod=e.codigo)
									 WHERE '
	DECLARE @QUERY_2 VARCHAR(500) = ' '
	DECLARE @QUERY_3 VARCHAR(500) = 'm.nombre LIKE @nombre AND m.apellido LIKE @apellido'
	DECLARE @QUERY_4 VARCHAR(500) = ' ORDER BY m.apellido,m.nombre,m.matricula,e.descripcion'

	IF @especialidad_codigo >0
		SET @QUERY_2 = 'med_esp.especialidad_cod = @especialidad_codigo AND '

	SET @nombre = '%' + @nombre + '%'
	SET @apellido = '%' + @apellido + '%'
	
		
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4

	EXEC sp_executesql @QUERY_FINAL, N'@nombre VARCHAR(255), @apellido VARCHAR(255),
									   @especialidad_codigo NUMERIC(18,0)',@nombre, @apellido,@especialidad_codigo
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Medicos_Filtros] 
(@matricula NUMERIC(18,0),@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0),@nombre VARCHAR(255), @apellido VARCHAR(255),@especialidad_codigo NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(500) = 'SELECT DISTINCT m.matricula, m.nombre,m.apellido,m.tipo_doc,m.nro_doc,m.direccion,m.telefono,m.mail,m.fecha_nac,m.sexo
									 FROM BETTER_CALL_JUAN.Medicos m JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med_esp.medico_id=m.matricula) 
									 WHERE '
	DECLARE @QUERY_2 VARCHAR(500) = ' '
	DECLARE @QUERY_3 VARCHAR(500) = ' '
	DECLARE @QUERY_4 VARCHAR(500) = ' '
	DECLARE @QUERY_5 VARCHAR(500) = ' m.tipo_doc LIKE @tipo_doc AND m.nombre LIKE @nombre AND m.apellido LIKE @apellido '
	DECLARE @QUERY_6 VARCHAR(500) = ' ORDER BY m.apellido,m.nombre,m.matricula'

	IF @especialidad_codigo >0
		SET @QUERY_2 = ' med_esp.especialidad_cod = @especialidad_codigo AND '

	IF @matricula >0
		SET @QUERY_3 = ' m.matricula = @matricula AND '

	IF @nro_doc >0
		SET @QUERY_4 = ' m.nro_doc = @nro_doc AND '

	SET @tipo_doc = '%' + @tipo_doc + '%'
	SET @nombre = '%' + @nombre + '%'
	SET @apellido = '%' + @apellido + '%'
	
		
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4 + @QUERY_5+ @QUERY_6

	EXEC sp_executesql @QUERY_FINAL, N'@matricula NUMERIC(18,0),@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0),@nombre VARCHAR(255), @apellido VARCHAR(255),
									   @especialidad_codigo NUMERIC(18,0)',@matricula,@tipo_doc, @nro_doc,@nombre, @apellido,@especialidad_codigo
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Medicos]
AS
BEGIN
	SELECT m.matricula, m.nombre,m.apellido,m.tipo_doc,m.nro_doc,m.direccion,m.telefono,m.mail,m.fecha_nac,m.sexo, m.usuario_id
	FROM BETTER_CALL_JUAN.Medicos m
	ORDER BY m.apellido, m.nombre, m.matricula
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Especialidades_Filtros] 
(@descripcion VARCHAR(255), @tipo_especialidad_cod NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(500) = 'SELECT e.codigo,e.descripcion,te.descripcion as tipo_especialidad FROM BETTER_CALL_JUAN.Especialidades e 
									JOIN BETTER_CALL_JUAN.Tipos_Especialidades te ON (e.tipo_especialidad_cod=te.codigo)'
	DECLARE @QUERY_2 VARCHAR(500) = ' WHERE e.descripcion LIKE @descripcion'
	DECLARE @QUERY_3 VARCHAR(500) = ' '
	DECLARE @QUERY_4 VARCHAR(500) = ' ORDER BY e.descripcion'

	IF @tipo_especialidad_cod > 0
		SET @QUERY_3 = ' AND e.tipo_especialidad_cod=@tipo_especialidad_cod'

	SET @descripcion = '%' + @descripcion + '%'
		
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4
	EXEC sp_executesql @QUERY_FINAL, N'@descripcion VARCHAR(255), @tipo_especialidad_cod NUMERIC(18,0)', @descripcion, @tipo_especialidad_cod
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Tipos_Especialidades]
AS
BEGIN
	SELECT te.codigo, te.descripcion
	FROM BETTER_CALL_JUAN.Tipos_Especialidades te
	ORDER BY te.descripcion
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Afiliados_Filtros] 
(@nombre VARCHAR(255), @apellido VARCHAR(255),@plan_codigo NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(500) = 'SELECT p.id,p.nro_raiz,p.nro_personal,p.nombre,p.apellido,p.tipo_doc,p.nro_doc,p.direccion,p.telefono,p.mail,
	p.fecha_nac,p.sexo,p.estado_civil,p.cantidad_familiares,p.plan_medico_cod,pm.descripcion,p.habilitado,p.nro_ultima_consulta
	FROM BETTER_CALL_JUAN.Pacientes p JOIN BETTER_CALL_JUAN.Planes_Medicos pm ON (p.plan_medico_cod=pm.codigo)'
	DECLARE @QUERY_2 VARCHAR(500) = ' WHERE (p.habilitado=1 AND p.nombre LIKE @nombre AND p.apellido LIKE @apellido)'
	DECLARE @QUERY_3 VARCHAR(500) = ' '
	DECLARE @QUERY_4 VARCHAR(500) = ' ORDER BY p.apellido,p.nombre,p.id'

	IF @plan_codigo > 0
		SET @QUERY_3 = ' AND p.plan_medico_cod = @plan_codigo'

	SET @nombre = '%' + @nombre + '%'
	SET @apellido = '%' + @apellido + '%'
		
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4
	EXEC sp_executesql @QUERY_FINAL, N'@nombre VARCHAR(255), @apellido VARCHAR(255), @plan_codigo NUMERIC(18,0)', @nombre, @apellido, @plan_codigo
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Rol] (@rol_nombre VARCHAR(255))
AS
BEGIN
	SELECT *
	FROM BETTER_CALL_JUAN.Roles R
	WHERE R.nombre like '%'+ @rol_nombre +'%'
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Rol_Habilitado] (@rol_nombre VARCHAR(255))
AS
BEGIN
	SELECT *
	FROM BETTER_CALL_JUAN.Roles R
	WHERE R.nombre like '%'+ @rol_nombre +'%' AND R.habilitado = 1
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Login] (@user VARCHAR(255), @passwordIngresada VARCHAR(255), @retorno NUMERIC(18,0) OUT)
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
					SET  @retorno= @idUsuario --Login OK. Tiene 1 rol
				ELSE
					SET @retorno= @idUsuario ---Login OK. Tiene mas de 1 rol
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
																		  @estado_civil VARCHAR(100),@plan_medico_cod NUMERIC(18,0), @nro_raiz_nuevo NUMERIC(18,0) OUT)
AS
BEGIN

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
	estado_civil,cantidad_familiares,plan_medico_cod, pm.descripcion,habilitado,nro_ultima_consulta,usuario_id
	FROM BETTER_CALL_JUAN.Pacientes p JOIN BETTER_CALL_JUAN.Planes_Medicos pm ON (p.plan_medico_cod =pm.codigo)
	WHERE p.habilitado=1
	ORDER BY apellido,nombre,id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Modificar_Plan_Medico] (@paciente_id NUMERIC(18,0), @plan_viejo_id NUMERIC(18,0), 
																	   @plan_nuevo_id NUMERIC(18,0), @motivo VARCHAR(500), @fecha_hoy DATETIME)
AS
BEGIN

	INSERT INTO Cambios_De_Plan(paciente_id,fecha_cambio, motivo_cambio, plan_anterior_id,plan_nuevo_id)  
	VALUES (@paciente_id,@fecha_hoy,@motivo,@plan_viejo_id,@plan_nuevo_id)
	
	UPDATE Pacientes
	SET plan_medico_cod=@plan_nuevo_id
	WHERE id=@paciente_id
						
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Modificar_Afiliado] 
(@paciente_id NUMERIC(18,0),@tipo_doc VARCHAR(100), @nro_doc NUMERIC(18,0), @direccion VARCHAR(255), @telefono NUMERIC(18,0), @mail VARCHAR(255), 
@sexo CHAR(1), @estado_civil VARCHAR(100),@plan_viejo_id NUMERIC(18,0), @plan_nuevo_id NUMERIC(18,0), @motivo VARCHAR(500), @fecha_hoy DATETIME)
AS
BEGIN
	UPDATE Pacientes
	SET direccion=@direccion, telefono=@telefono, mail=@mail, sexo=@sexo, estado_civil=@estado_civil, nro_doc=@nro_doc, tipo_doc=@tipo_doc
	WHERE id=@paciente_id

	IF(@plan_viejo_id != @plan_nuevo_id)
	BEGIN
		EXEC BETTER_CALL_JUAN.Procedure_Modificar_Plan_Medico @paciente_id,@plan_viejo_id,@plan_nuevo_id,@motivo, @fecha_hoy
	END						
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Baja_Afiliado] (@id_paciente NUMERIC(18,0),@fecha_hoy DATETIME) 
AS
BEGIN
	IF((SELECT habilitado FROM Pacientes WHERE id = @id_paciente) = 0)
	BEGIN
		RAISERROR('El afiliado ya está dado de baja.', 10,1)
		RETURN
	END

	UPDATE Pacientes
	SET habilitado = 0
	WHERE id = @id_paciente

	INSERT INTO Bajas_Pacientes(fecha_baja, paciente_id) VALUES (@fecha_hoy, @id_paciente)

	UPDATE Turnos
	SET paciente_id = NULL
	WHERE paciente_id = @id_paciente
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Comprar_Bonos] (@id_usuario NUMERIC(18,0), @cant_bonos NUMERIC(18,0),@plan_medico_bono_id NUMERIC(18,0), 
																@monto_a_pagar NUMERIC(18,2) OUT, @fecha_hoy DATETIME)
AS
BEGIN
	DECLARE @precio_bono NUMERIC(18,0)
	DECLARE @id_afiliado_comprador NUMERIC(18,0)

	SELECT @id_afiliado_comprador = P.id
	FROM BETTER_CALL_JUAN.Pacientes P
	WHERE P.usuario_id = @id_usuario

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
	   VALUES (@fecha_hoy,@id_afiliado_comprador,@plan_medico_bono_id)
	   SET @i = @i + 1;
	END;

	RETURN @monto_a_pagar

END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Plan_Por_Usuario_Id]
(@usuario_id NUMERIC(18,0))
AS
BEGIN
	SELECT PM.codigo, PM.descripcion, PM.precio_bono_consulta, PM.precio_bono_farmacia
	FROM BETTER_CALL_JUAN.Planes_Medicos PM
	JOIN BETTER_CALL_JUAN.Pacientes P ON (P.usuario_id = @usuario_id AND P.plan_medico_cod = PM.codigo)
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

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Pedir_Turno_Con_Paciente_Id](@paciente_id NUMERIC(18,0),@medico_id NUMERIC(18,0), 
															@especialidad_codigo NUMERIC(18,0), @fecha_hora_turno DATETIME)
AS
BEGIN
	DECLARE @medico_especialidad_id NUMERIC(18,0)

	SELECT @medico_especialidad_id=me.id
	FROM BETTER_CALL_JUAN.Medicos_Especialidades me
	WHERE me.medico_id=@medico_id AND me.especialidad_cod=@especialidad_codigo

	INSERT INTO BETTER_CALL_JUAN.Turnos(fecha_hora,paciente_id,medico_especialidad_id)
	VALUES (@fecha_hora_turno,@paciente_id,@medico_especialidad_id)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Pedir_Turno_Con_Usuario_Id](@usuario_id_afiliado NUMERIC(18,0),@medico_id NUMERIC(18,0), 
															@especialidad_codigo NUMERIC(18,0), @fecha_hora_turno DATETIME)
AS
BEGIN
	DECLARE @paciente_id NUMERIC(18,0)

	SELECT @paciente_id = p.id
	FROM BETTER_CALL_JUAN.Pacientes p 
	JOIN BETTER_CALL_JUAN.Usuarios u 
	ON (p.usuario_id = u.id  AND u.id=@usuario_id_afiliado)

	EXEC BETTER_CALL_JUAN.Procedure_Pedir_Turno_Con_Paciente_Id @paciente_id, @medico_id, @especialidad_codigo, @fecha_hora_turno
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Obtener_Estado_Habilitado_Rol] (@rol_id SMALLINT, @habilitado SMALLINT OUT)
AS
BEGIN
	SET @habilitado = (SELECT habilitado FROM BETTER_CALL_JUAN.Roles WHERE id = @rol_id)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Especialidades]
AS
BEGIN
	SELECT e.codigo, e.descripcion, te.descripcion as tipo_especialidad
	FROM BETTER_CALL_JUAN.Especialidades e JOIN BETTER_CALL_JUAN.Tipos_Especialidades te ON (e.tipo_especialidad_cod=te.codigo)
	ORDER BY e.descripcion
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Habilitar_Rol] (@rol_id SMALLINT)
AS
BEGIN
UPDATE BETTER_CALL_JUAN.Roles
SET habilitado = 1
WHERE id = @rol_id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Eliminar_Rol] (@rol_id SMALLINT)
AS
BEGIN
	UPDATE BETTER_CALL_JUAN.Roles
	SET habilitado = 0
	WHERE id = @rol_id
	END

	DELETE FROM BETTER_CALL_JUAN.Roles_Usuarios
	WHERE rol_id = @rol_id
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Modificar_Rol] (@rol_id SMALLINT, @nombre VARCHAR(255))
AS
BEGIN
	IF((SELECT nombre FROM BETTER_CALL_JUAN.Roles WHERE nombre=@nombre) IS NULL)
	BEGIN
	UPDATE BETTER_CALL_JUAN.Roles
	SET nombre = @nombre
	WHERE id = @rol_id
	END
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Borrar_Funcionalidad_Rol] (@rol_id SMALLINT)
AS
BEGIN
	DELETE FROM BETTER_CALL_JUAN.Roles_Funcionalidades WHERE rol_id = @rol_id
END
GO
  
CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Consulta] (@matricula NUMERIC(18,0), @cod_especialidad NUMERIC(18,0), @fecha DATETIME) --aca creo que hay que mandarle el id de usuario
AS
BEGIN
	DECLARE @medico_especialidad_id NUMERIC(18,0)

	SELECT @medico_especialidad_id = id
	FROM Medicos_Especialidades
	WHERE medico_id = @matricula AND especialidad_cod = @cod_especialidad

	SELECT nombre, apellido, t.fecha_hora, c.fecha_hora_llegada
	FROM Consultas c JOIN Turnos t ON (c.turno_numero = t.numero) JOIN Pacientes p ON (t.paciente_id = p.id)
	WHERE DATEDIFF(day, @fecha, fecha_hora) = 0 AND medico_especialidad_id = @medico_especialidad_id
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Registro_Resultado_Consulta] (@id_consulta INT, @hora_atencion DATETIME, @sintomas VARCHAR(255), @diagnostico VARCHAR(255))
AS
BEGIN
	UPDATE Consultas
	SET fecha_hora_atencion=@hora_atencion, sintomas=@sintomas, enfermedades=@diagnostico
	WHERE id=@id_consulta 
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Plan_Por_Nombre] (@descripcion VARCHAR(255))
AS
BEGIN
	SELECT codigo, descripcion, precio_bono_consulta, precio_bono_farmacia
	FROM Planes_Medicos
	WHERE descripcion like '%' + @descripcion + '%'
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Cancelar_Turno_Dia_Profesional] (@fecha DATETIME, @usuario_id NUMERIC(18,0), @tipo NUMERIC(18,0), @motivo VARCHAR(255))
AS
BEGIN
	INSERT INTO Cancelaciones(tipo_cancelacion_id, motivo, turno_numero)
	SELECT @tipo, @motivo, numero
	FROM Turnos t 
	JOIN Medicos_Especialidades me ON (t.medico_especialidad_id = me.id) 
	JOIN Medicos m ON (me.medico_id = m.matricula)
	WHERE m.usuario_id = @usuario_id AND DATEDIFF(day,fecha_hora,@fecha) = 0	
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Cancelar_Turnos_Franja_Profesional] (@fecha_inicio DATETIME, @fecha_fin DATETIME, @usuario_id NUMERIC(18,0), @tipo NUMERIC(18,0), @motivo VARCHAR(255))
AS
BEGIN
	INSERT INTO Cancelaciones(tipo_cancelacion_id, motivo, turno_numero)
	SELECT @tipo, @motivo, numero
	FROM Turnos t JOIN Medicos_Especialidades me ON (t.medico_especialidad_id = me.id) JOIN Medicos m ON (me.medico_id = m.matricula)
	WHERE m.usuario_id = @usuario_id AND fecha_hora BETWEEN CONVERT(date,@fecha_inicio) AND CONVERT(date, @fecha_fin)	

	INSERT INTO Ausencias_Medicos(medico_id, fecha_desde, fecha_hasta)
	VALUES
	((SELECT M.matricula FROM BETTER_CALL_JUAN.Medicos M WHERE M.usuario_id = @usuario_id),
	@fecha_inicio, @fecha_fin)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Cancelar_Turno] (@turno_numero NUMERIC(18,0), @tipo NUMERIC(18,0), @motivo VARCHAR(255))
AS
BEGIN
	INSERT INTO Cancelaciones(tipo_cancelacion_id, motivo, turno_numero) VALUES (@tipo, @motivo, @turno_numero)
	UPDATE Turnos SET paciente_id = NULL WHERE numero = @turno_numero
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Cancelar_Turno_Afiliado] (@usuario_id NUMERIC(18,0), @turno_numero NUMERIC(18,0), @tipo NUMERIC(18,0), @motivo VARCHAR(255))
AS
BEGIN
	DECLARE @paciente_id NUMERIC(18,0)
	SELECT @paciente_id = P.id FROM BETTER_CALL_JUAN.Pacientes P where P.usuario_id = @usuario_id

	INSERT INTO Cancelaciones(tipo_cancelacion_id, motivo, turno_numero, paciente_id) VALUES (@tipo, @motivo, @turno_numero, @paciente_id)
	UPDATE Turnos SET paciente_id = NULL WHERE numero = @turno_numero
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Especialidades_Medico] (@matricula NUMERIC(18,0))
AS
BEGIN
SELECT e.codigo, e.descripcion
FROM BETTER_CALL_JUAN.Medicos m JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (m.matricula = me.medico_id)
								JOIN BETTER_CALL_JUAN.Especialidades e ON (me.especialidad_cod = e.codigo)
WHERE m.matricula = @matricula
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Get_Medico_Para_Agenda](@nombre VARCHAR(255),@apellido VARCHAR(255), @especialidad_codigo NUMERIC(18,0))
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(500) = 'SELECT DISTINCT m.matricula,m.nombre,m.apellido
									 FROM BETTER_CALL_JUAN.Medicos m JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med_esp.medico_id=m.matricula)
									 JOIN BETTER_CALL_JUAN.Especialidades e ON (med_esp.especialidad_cod=e.codigo)
									 WHERE '
	DECLARE @QUERY_2 VARCHAR(500) = ' '
	DECLARE @QUERY_3 VARCHAR(500) = 'm.nombre LIKE @nombre AND m.apellido LIKE @apellido'
	DECLARE @QUERY_4 VARCHAR(500) = ' ORDER BY m.apellido,m.nombre,m.matricula'

	IF @especialidad_codigo >0
		SET @QUERY_2 = 'med_esp.especialidad_cod = @especialidad_codigo AND '

	SET @nombre = '%' + @nombre + '%'
	SET @apellido = '%' + @apellido + '%'
	
		
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4

	EXEC sp_executesql @QUERY_FINAL, N'@nombre VARCHAR(255), @apellido VARCHAR(255),
									   @especialidad_codigo NUMERIC(18,0)',@nombre, @apellido,@especialidad_codigo
END
GO


CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Buscar_Turnos_Fecha_Por_Medico](@medico_id NUMERIC(18,0), @especialidad_codigo NUMERIC(18,0), @fecha DATE)
AS
BEGIN
	DECLARE @medico_especialidad_id NUMERIC(18,0)

	SELECT @medico_especialidad_id=me.id
	FROM BETTER_CALL_JUAN.Medicos_Especialidades me
	WHERE me.medico_id=@medico_id AND me.especialidad_cod=@especialidad_codigo

	SELECT paciente_id, tipo_doc, nro_doc, nombre, apellido, fecha_hora, numero --le mando el id del paciente para que al llamar al sp de registro_llegada ya lo tenga la app, no para mostrar
	FROM Turnos t JOIN Pacientes p ON (t.paciente_id = p.id)
	WHERE medico_especialidad_id = @medico_especialidad_id AND DATEDIFF(day, t.fecha_hora, @fecha) = 0
	ORDER BY t.fecha_hora
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Afiliado_Cantidad_Bonos_Disponibles](@id_paciente NUMERIC(18,0), @bonos_disponibles INT OUT)
AS
BEGIN
	DECLARE @nro_raiz NUMERIC(18,0), @plan NUMERIC(18,0)

	SELECT @nro_raiz = nro_raiz, @plan = plan_medico_cod
	FROM Pacientes
	WHERE id = @id_paciente
	
	SELECT @bonos_disponibles = COUNT(bc.id)
	FROM Bonos_Consulta bc JOIN Pacientes p ON (bc.paciente_compra_id = p.id)
	WHERE paciente_compra_id IN (SELECT id FROM Pacientes WHERE nro_raiz = @nro_raiz) AND numero_consulta_paciente IS NULL AND plan_id = @plan
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Afiliado_Bonos_Disponibles](@id_paciente NUMERIC(18,0))
AS
BEGIN
	DECLARE @nro_raiz NUMERIC(18,0), @plan NUMERIC(18,0)

	SELECT @nro_raiz = nro_raiz, @plan = plan_medico_cod
	FROM Pacientes
	WHERE id = @id_paciente
	
	SELECT bc.id, fecha_compra
	FROM Bonos_Consulta bc JOIN Pacientes p ON (bc.paciente_compra_id = p.id)
	WHERE paciente_compra_id IN (SELECT id FROM Pacientes WHERE nro_raiz = @nro_raiz) AND numero_consulta_paciente IS NULL AND plan_id = @plan
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Registro_Llegada_Afiliado](@id_paciente NUMERIC(18,0), @turno_numero NUMERIC(18,0), @hora_llegada DATETIME, @bono_id NUMERIC(18,0), @retorno SMALLINT OUT)
AS
BEGIN
	DECLARE @nro_raiz NUMERIC(18,0), @plan_id NUMERIC(18,0), @nro_nueva_consulta_paciente NUMERIC(18,0)
	DECLARE @cant_bonos INT

	SELECT @nro_raiz = nro_raiz, @plan_id = plan_medico_cod
	FROM Pacientes
	WHERE id = @id_paciente
	
	BEGIN TRANSACTION
		BEGIN TRY
				INSERT INTO Consultas(turno_numero, fecha_hora_llegada, bono_consulta_id) VALUES (@turno_numero, @hora_llegada, @bono_id)
				
				SELECT @nro_nueva_consulta_paciente=nro_ultima_consulta+1
				FROM Pacientes
				WHERE id = @id_paciente

				UPDATE Bonos_Consulta
				SET numero_consulta_paciente = @nro_nueva_consulta_paciente, paciente_usa_id = @id_paciente
				WHERE id = @bono_id

				UPDATE Pacientes
				SET nro_ultima_consulta = @nro_nueva_consulta_paciente
				WHERE id = @id_paciente
				
				SET @retorno = 1 -- operacion ok
				COMMIT
			END TRY
			BEGIN CATCH
				SET @retorno = -1 --No se pudo completar la operación
				ROLLBACK
			END CATCH

END
GO

/** TOP 5 **/
CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Anios_Top_5_Mas_Cancelaciones]
AS
BEGIN
	SELECT DISTINCT YEAR(T.fecha_hora) AS anio
	FROM BETTER_CALL_JUAN.Turnos T
	JOIN BETTER_CALL_JUAN.Cancelaciones C ON (C.turno_numero = T.numero)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Especialidades_Con_Mas_Cancelaciones]
(@autor_cancelacion CHAR(1), @semestre INT, @anio INT, @mes INT)
AS
BEGIN
	IF (@autor_cancelacion NOT IN ('A','M','T'))
	BEGIN
		RAISERROR('@autor_cancelacion debe ser A para Afiliados, M para medicos o T para todos',10,1)
		RETURN
	END

	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(200) = 'SELECT TOP 5 e.codigo, e.descripcion, COUNT(DISTINCT c.id) cantCancelaciones'
	DECLARE @QUERY_2 VARCHAR(250) = ' FROM BETTER_CALL_JUAN.Especialidades e JOIN BETTER_CALL_JUAN.Medicos_Especialidades me ON (e.codigo = me.especialidad_cod)'
	DECLARE @QUERY_3 VARCHAR(250) = ' JOIN BETTER_CALL_JUAN.Turnos t ON (me.id = t.medico_especialidad_id) JOIN BETTER_CALL_JUAN.Cancelaciones c ON (c.turno_numero = t.numero)'
	DECLARE @QUERY_4 VARCHAR(250)
	DECLARE @QUERY_5 VARCHAR(250)
	DECLARE @QUERY_6 VARCHAR(200) = ' GROUP BY e.codigo, e.descripcion ORDER BY cantCancelaciones DESC'

	IF @mes = 0
		BEGIN
			IF @semestre = 1
				SET @QUERY_4 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (1, 2, 3, 4, 5, 6)'
			ELSE
				SET @QUERY_4 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (7, 8, 9, 10, 11, 12)'
		END
	ELSE
		SET @QUERY_4 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') = @mes'

	IF(@autor_cancelacion='A')
	BEGIN
		SET @QUERY_5 = ' AND c.paciente_id IS NOT NULL'
	END

	ELSE IF(@autor_cancelacion='M')
	BEGIN
		SET @QUERY_5 = ' AND c.paciente_id IS NULL'
	END

	ELSE IF(@autor_cancelacion='T')
	BEGIN
		SET @QUERY_5 = ' '
	END
	
	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4 + @QUERY_5 + @QUERY_6
	EXEC sp_executesql @QUERY_FINAL, N'@autor_cancelacion CHAR(1), @semestre INT, @anio INT, @mes INT', @autor_cancelacion, @semestre, @anio, @mes
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Anios_Top_5_Profesionales_Mas_Consultados]
AS
BEGIN
	SELECT DISTINCT YEAR(T.fecha_hora) AS anio
	FROM BETTER_CALL_JUAN.Turnos T
	JOIN BETTER_CALL_JUAN.Consultas cons ON (cons.turno_numero=T.numero)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Profesionales_Mas_Consultados_Por_Plan]
(@plan_medico_id NUMERIC(18,0), @anio INT, @mes INT, @semestre INT)
AS 
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(2000)
	DECLARE @QUERY_0 VARCHAR(300) = 'SELECT TOP 5 med.matricula, med.nombre, med.apellido,esp.codigo,esp.descripcion, COUNT(DISTINCT cons.id) cantConsultas FROM BETTER_CALL_JUAN.Medicos med '
	DECLARE @QUERY_1 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med.matricula = med_esp.medico_id)'
	DECLARE @QUERY_2 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Turnos t ON (t.medico_especialidad_id=med_esp.id)'
	DECLARE @QUERY_3 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Consultas cons ON (cons.turno_numero=t.numero)'
	DECLARE @QUERY_4 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Especialidades esp ON (esp.codigo = med_esp.especialidad_cod)'
	DECLARE @QUERY_5 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Pacientes pac ON (pac.id = t.paciente_id)'
	DECLARE @QUERY_6 VARCHAR(300)
	DECLARE @QUERY_7 VARCHAR(300)
	DECLARE @QUERY_8 VARCHAR(300) = ' GROUP BY med.matricula, med.nombre, med.apellido,esp.codigo, esp.descripcion'
	DECLARE @QUERY_9 VARCHAR(300) = ' ORDER BY cantConsultas DESC'

	IF @mes = 0
		BEGIN
			IF @semestre = 1
				SET @QUERY_6 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (1, 2, 3, 4, 5, 6)'
			ELSE
				SET @QUERY_6 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (7, 8, 9, 10, 11, 12)'
		END	
	ELSE
		SET @QUERY_6 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') = @mes'

	IF @plan_medico_id = 0
		SET @QUERY_7 = ''
	ELSE
		SET @QUERY_7 = ' AND pac.plan_medico_cod=@plan_medico_id'
		
	SET @QUERY_FINAL = @QUERY_0 + @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4 + @QUERY_5 + @QUERY_6 + @QUERY_7 + @QUERY_8 + @QUERY_9
	EXEC sp_executesql @QUERY_FINAL, N'@plan_medico_id NUMERIC(18,0), @anio INT, @mes INT', @plan_medico_id, @anio, @mes

END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Anios_Top_5_Profesionales_Menos_Horas]
AS
BEGIN
	SELECT DISTINCT YEAR(T.fecha_hora) AS anio
	FROM BETTER_CALL_JUAN.Turnos T
	JOIN BETTER_CALL_JUAN.Consultas c ON (c.turno_numero = T.numero)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Profesionales_Con_Menos_Horas_Trabajadas_Segun_Especialidad]
(@especialidad_cod NUMERIC(18,0), @anio INT, @mes INT, @semestre INT)
AS
BEGIN
	
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_0 VARCHAR(300) = 'SELECT TOP 5 med.matricula, med.nombre, med.apellido, COUNT(DISTINCT c.id)/2 cantHorasTrabajadas FROM BETTER_CALL_JUAN.Medicos med'
	DECLARE @QUERY_1 VARCHAR(300)
	DECLARE @QUERY_2 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Turnos t ON (t.medico_especialidad_id=med_esp.id) JOIN BETTER_CALL_JUAN.Consultas c ON (c.turno_numero = t.numero)'
	DECLARE @QUERY_3 VARCHAR(300)
	DECLARE @QUERY_4 VARCHAR(300) = ' GROUP BY med.matricula, med.nombre, med.apellido ORDER BY cantHorasTrabajadas ASC'

	IF @especialidad_cod = 0
		SET @QUERY_1 = ' JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON med_esp.medico_id=med.matricula'
	ELSE
		SET @QUERY_1 = ' JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (med_esp.medico_id=med.matricula AND med_esp.especialidad_cod= @especialidad_cod)'
		
	IF @mes = 0
		BEGIN
			IF @semestre = 1
				SET @QUERY_3 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (1, 2, 3, 4, 5, 6)'
			ELSE
				SET @QUERY_3 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (7, 8, 9, 10, 11, 12)'
		END
	ELSE
		SET @QUERY_3 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') = @mes'

	SET @QUERY_FINAL = @QUERY_0 + @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4
	EXEC sp_executesql @QUERY_FINAL, N'@especialidad_cod NUMERIC(18,0), @anio INT, @mes INT', @especialidad_cod, @anio, @mes
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Anios_Top_5_Afiliados_Mas_Bonos]
AS
BEGIN
	SELECT DISTINCT YEAR(B.fecha_compra) AS anio
	FROM BETTER_CALL_JUAN.Bonos_Consulta B
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Afiliados_Con_Mayor_Cantidad_Bonos_Comprados]
(@semestre INT, @anio INT, @mes INT)
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(300) = 'SELECT TOP 5 p.nombre,p.apellido,p.tipo_doc,p.nro_doc, p.direccion, p.telefono,p.cantidad_familiares, COUNT(DISTINCT b.id) cantBonosComprados'
	DECLARE @QUERY_2 VARCHAR(300) = ' FROM BETTER_CALL_JUAN.Pacientes p JOIN BETTER_CALL_JUAN.Bonos_Consulta b ON (b.paciente_compra_id=p.id)'
	DECLARE @QUERY_3 VARCHAR(200)
	DECLARE @QUERY_4 VARCHAR(200) = ' GROUP BY p.nombre,p.apellido,p.tipo_doc,p.nro_doc, p.direccion, p.telefono,p.cantidad_familiares'
	DECLARE @QUERY_5 VARCHAR(200) = ' ORDER BY cantBonosComprados DESC'
	
	IF @mes = 0
		BEGIN
			IF @semestre = 1
				SET @QUERY_3 = ' WHERE Format(b.fecha_compra, ''yyyy'') = @anio AND Format(b.fecha_compra, ''MM'') IN (1, 2, 3, 4, 5, 6)'
			ELSE
				SET @QUERY_3 = ' WHERE Format(b.fecha_compra, ''yyyy'') = @anio AND Format(b.fecha_compra, ''MM'') IN (7, 8, 9, 10, 11, 12)'
		END
	ELSE
		SET @QUERY_3 = ' WHERE Format(b.fecha_compra, ''yyyy'') = @anio AND Format(b.fecha_compra, ''MM'') = @mes'

	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4 + @QUERY_5
	EXEC sp_executesql @QUERY_FINAL, N'@semestre INT, @anio INT, @mes INT', @semestre, @anio, @mes
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Anios_Top_5_Especialidades_Mas_Bonos]
AS
BEGIN
	SELECT DISTINCT YEAR(T.fecha_hora) AS anio
	FROM BETTER_CALL_JUAN.Turnos T
	JOIN BETTER_CALL_JUAN.Consultas cons ON (cons.turno_numero=T.numero)
END
GO

CREATE PROCEDURE [BETTER_CALL_JUAN].[Procedure_Top_5_Especialidades_Con_Mas_Bonos_Utilizados]
(@semestre INT, @anio INT, @mes INT)
AS
BEGIN
	DECLARE @QUERY_FINAL NVARCHAR(1500)
	DECLARE @QUERY_1 VARCHAR(300) = 'SELECT TOP 5 e.codigo, e.descripcion, COUNT(DISTINCT c.id) cantBonosUtilizados FROM BETTER_CALL_JUAN.Especialidades e '
	DECLARE @QUERY_2 VARCHAR(300) = ' JOIN BETTER_CALL_JUAN.Medicos_Especialidades med_esp ON (e.codigo = med_esp.especialidad_cod)'
	DECLARE @QUERY_3 VARCHAR(200) = ' JOIN BETTER_CALL_JUAN.Turnos t ON (t.medico_especialidad_id = med_esp.id)'
	DECLARE @QUERY_4 VARCHAR(200) = ' JOIN BETTER_CALL_JUAN.Consultas c ON (c.turno_numero = t.numero)'
	DECLARE @QUERY_5 VARCHAR(200)
	DECLARE @QUERY_6 VARCHAR(200) = ' GROUP BY e.codigo, e.descripcion'
	DECLARE @QUERY_7 VARCHAR(200) = ' ORDER BY cantBonosUtilizados DESC'
	
	IF @mes = 0
		BEGIN
			IF @semestre = 1
				SET @QUERY_5 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (1, 2, 3, 4, 5, 6)'
			ELSE
				SET @QUERY_5 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') IN (7, 8, 9, 10, 11, 12)'
		END
	ELSE
		SET @QUERY_5 = ' WHERE Format(t.fecha_hora, ''yyyy'') = @anio AND Format(t.fecha_hora, ''MM'') = @mes'

	SET @QUERY_FINAL = @QUERY_1 + @QUERY_2 + @QUERY_3 + @QUERY_4 + @QUERY_5 + @QUERY_6 + @QUERY_7
	EXEC sp_executesql @QUERY_FINAL, N'@semestre INT, @anio INT, @mes INT', @semestre, @anio, @mes
	
END
GO

/** FIN TOP 5 **/

----------------------------------------

/** TRIGGERS **/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Trigger_Insert_Afiliado'))
	DROP TRIGGER BETTER_CALL_JUAN.Trigger_Insert_Afiliado
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

----------------------
/** FUNCTIONS **/

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Function_Fecha_Esta_Disponible_Para_Turno'))
	DROP FUNCTION BETTER_CALL_JUAN.Function_Fecha_Esta_Disponible_Para_Turno
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'BETTER_CALL_JUAN.Function_Afiliado_Cantidad_Bonos_Disponibles'))
	DROP FUNCTION BETTER_CALL_JUAN.Function_Afiliado_Cantidad_Bonos_Disponibles
GO

CREATE FUNCTION [BETTER_CALL_JUAN].[Function_Fecha_Esta_Disponible_Para_Turno]
(@fecha DATE,@medico_id NUMERIC(18,0),@especialidad_codigo NUMERIC(18,0))
RETURNS BIT
BEGIN
	DECLARE @fecha_disponible BIT

	IF EXISTS (SELECT am.id FROM BETTER_CALL_JUAN.Ausencias_Medicos am 
				WHERE medico_id=@medico_id AND @fecha BETWEEN am.fecha_desde AND am.fecha_hasta)
	BEGIN
		SET @fecha_disponible = 0
	END

	ELSE
	BEGIN
		DECLARE @medico_especialidad_id NUMERIC(18,0), @cantTurnosDisponibles INT, @cantTurnosOcupados INT, 
				@cantTurnosTotales INT

		SELECT @medico_especialidad_id=me.id
		FROM BETTER_CALL_JUAN.Medicos_Especialidades me
		WHERE me.medico_id=@medico_id AND me.especialidad_cod=@especialidad_codigo

		SELECT @cantTurnosTotales = SUM(DATEDIFF(mi,r.hora_desde,r.hora_hasta))/30
		FROM BETTER_CALL_JUAN.Rangos_Atencion r	
		WHERE r.medico_especialidad_id=@medico_especialidad_id AND r.dia_semana=DATEPART(dw,@fecha)
				AND (@fecha BETWEEN r.fecha_desde AND r.fecha_hasta)
	
		SELECT @cantTurnosOcupados= COUNT(DISTINCT t.numero)
		FROM BETTER_CALL_JUAN.Turnos t
		WHERE paciente_id IS NOT NULL AND convert(date,t.fecha_hora)=@fecha AND t.medico_especialidad_id=@medico_especialidad_id

		SET @cantTurnosDisponibles=@cantTurnosTotales-@cantTurnosOcupados

		SET @fecha_disponible = CASE WHEN @cantTurnosDisponibles > 0 THEN 1 --la fecha esta disponible
									ELSE 0 --la fecha no esta disponible
								END
	END

	RETURN @fecha_disponible
END
GO

CREATE FUNCTION [BETTER_CALL_JUAN].[Function_Afiliado_Cantidad_Bonos_Disponibles](@nro_raiz NUMERIC(18,0), @plan NUMERIC(18,0))
RETURNS INT
BEGIN
	DECLARE @bonos_disponibles INT
	
	SELECT @bonos_disponibles = COUNT(bc.id)
	FROM Bonos_Consulta bc JOIN Pacientes p ON (bc.paciente_compra_id = p.id)
	WHERE paciente_compra_id IN (SELECT id FROM Pacientes WHERE nro_raiz = @nro_raiz) AND numero_consulta_paciente IS NULL AND plan_id = @plan

	RETURN @bonos_disponibles
END
GO
