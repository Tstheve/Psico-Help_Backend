CREATE DATABASE PsicologoDB
GO 

USE PsicologoDB
GO

DROP DATABASE PsicologoDB

CREATE TABLE Usuario(
  Id_Usuario INT PRIMARY KEY IDENTITY,
  Correo VARCHAR(100),
  Clave VARCHAR(20),
  Nombre VARCHAR(50),
  Apellido VARCHAR(50),
  Edad TINYINT,
  Telefono VARCHAR(8),
  Pseudonimo VARCHAR(20)
)
GO

CREATE TABLE Chats (
  Id_Chat INT PRIMARY KEY IDENTITY,
  Id_Usuario INT,
  Asunto VARCHAR(200),
  Id_Psicologo INT
)
GO

CREATE TABLE Psicologo (
  Id_Psicologo			 INT PRIMARY KEY IDENTITY,
  Id_Usuario				INT,
  Nombre				 VARCHAR(80),
  Apellido				 VARCHAR(80),
  Edad					 INT,
  Especialidad			 VARCHAR(80),
  Años_de_experiencia	 INT
);
GO

CREATE TABLE Municipio (
  Id_Municipio INT PRIMARY KEY IDENTITY,
  Nombre_municipio				VARCHAR(100),
  Departamento					VARCHAR(80),
  Id_Usuario INT
  );
GO

DROP TABLE  Citas
CREATE TABLE Citas (
  Id_cita INT PRIMARY KEY IDENTITY,
  Fecha DATETIME,
  Id_Usuario INT,
  Id_Psicologo INT,
  Id_Municipio INT
)
GO

DROP TABLE Membresia
CREATE TABLE Membresia (
  Id_Membresia INT PRIMARY KEY IDENTITY(1,1),
  Descripcion VARCHAR(90),
  Precio VARCHAR(3),
  Id_Usuario INT
)
GO


------------------------------------------------------------------------------------------------------------
------------------------------------------LLAVEZ FORANEAS----------------------------------------------------

ALTER TABLE Chats
ADD CONSTRAINT FK_ChatsUsuarios
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario);


ALTER TABLE Psicologo
ADD CONSTRAINT FK_PsicologoUsuario
FOREIGN KEY (Id_Psicologo) REFERENCES Usuario(Id_Usuario);


ALTER TABLE Municipio
ADD CONSTRAINT FK_Municipio_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES Usuario (Id_Usuario);

--Aqui vamos!!
ALTER TABLE Citas
ADD CONSTRAINT FK_Citas_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario);

ALTER TABLE Membresia
ADD CONSTRAINT FK_Membresia_Usuario
FOREIGN KEY (Id_Usuario) REFERENCES Usuario(Id_Usuario);



-------------------------------------------------------------------------------------------------------------
----------------------------------------PROCESOS ALMACENADOS------------------------------------------------
---------------------------------------------------------------------------------------------------------------


------------------------------------------------------------------------------------------------------------
--------------------------------Insertar usuario----------------------------------------------------------

CREATE PROCEDURE InsertUsuario
  @Correo VARCHAR(100),
  @Clave VARCHAR(20),
  @Nombre VARCHAR(50),
  @Apellido VARCHAR(50),
  @Edad TINYINT,
  @Telefono VARCHAR(8),
  @Pseudonimo VARCHAR(20)
  AS
	BEGIN
			SET NOCOUNT ON;
			INSERT INTO Usuario VALUES ( @Correo, @Clave, @Nombre, @Apellido, @Edad, @Telefono, @Pseudonimo);
			END
			GO

			EXEC InsertUsuario 'torrez08@gmail.com', 'alvarez12', 'Stheven', 'Torrez', 20, '86329022', 'storrez'
			EXEC InsertUsuario'Alvarez@gmail.com', 'torrez', 'Mijail', 'Alvarez', 22, '82345433', 'alvarez'
			EXEC InsertUsuario'storrez23@gmail.com', 'flores12', 'Carlos', 'Fuente', 23, '83452355', 'carlos'
			EXEC InsertUsuario'Jorge@gmail.com', 'rulos1', 'Jorge', 'Narvaes', 22, '83456633', 'crack'
			EXEC InsertUsuario'eve123@gmail.com', 'Evelin12', 'Eveling', 'Cruz', 24, '78992455', 'evelinc'
			EXEC InsertUsuario'mey34@gmail.com', 'meylin', 'Mey', 'Xolimar', 24, '84567855', 'Mey'

	

			SELECT * FROM Usuario

			------------------------------------------------------------------------------------------------------------
--------------------------------Actualizar usuario----------------------------------------------------------

IF OBJECT_ID('ActualizarUsuario') IS NOT NULL
BEGIN 
DROP PROC ActualizarUsuario
END 
GO
CREATE PROC ActualizarUsuario
   @Id_Usuario INT,
  @Correo VARCHAR(100),
  @Clave VARCHAR(20),
  @Nombre VARCHAR(50),
  @Apellido VARCHAR(50),
  @Edad TINYINT,
  @Telefono VARCHAR(8),
  @Pseudonimo VARCHAR(20)
  
AS 
BEGIN 

SET NOCOUNT ON;
		UPDATE Usuario SET	 Correo = @Correo, 
							   Clave = @Clave,
							   Nombre = @Nombre,
							   Apellido = @Apellido,
							  Edad = @Edad,
							  Telefono = @Telefono,
							  Pseudonimo = @Pseudonimo
WHERE  Id_Usuario = @Id_Usuario
END
GO

EXEC ActualizarUsuario  2,'Alvarez@gmail.com', 'torrez', 'Mijail', 'torrez', 22, '82345433', 'gordo'
EXEC ActualizarUsuario  3,'torrez@gmail.com', 'alvares', 'jordan', 'flores', 21, '82453456', 'flaco'
EXEC ActualizarUsuario  4,'Alzes@gmail.com', 'lopez', 'carlos', 'fuente', 25, '84563456', 'negro'

SELECT * FROM Usuario


------------------------------------------------------------------------------------------------------------
--------------------------------Eliminar Usuario----------------------------------------------------------


IF OBJECT_ID('DeleteUsuario') IS NOT NULL
DROP PROCEDURE DeleteUsuario
GO

CREATE PROCEDURE DeleteUsuario
@Id_Usuario 	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM Usuario WHERE @Id_Usuario = Id_Usuario;
END
GO

EXEC DeleteUsuario 6
EXEC DeleteUsuario 2


SELECT * FROM Usuario

------------------------------------------------------------------------------------------------------------
--------------------------------Mostrar solo Id Usuario----------------------------------------------------------

IF OBJECT_ID('SelectUsuario') IS NOT NULL
DROP PROCEDURE SelectUsuario
GO

CREATE PROCEDURE SelectUsuario
@Id_Usuario	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Usuario WHERE Id_Usuario = @Id_Usuario;
END
GO

EXEC SelectUsuario 4


------------------------------------------------------------------------------------------------------------
--------------------------------Mostrar todos los datos Usuario----------------------------------------------------------


 IF OBJECT_ID('DatosUsuario') IS NOT NULL
DROP PROCEDURE DatosUsuario
GO

CREATE PROCEDURE DatosUsuario

AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Usuario 
END
GO

EXEC DatosUsuario




----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------CHATS------------------------------------------------------------------



---------------------------------------------------------------------------------------------------------------
---------------------------------INSERTAR CHAT-----------------------------------------------------------------
DROP PROCEDURE InsertChats
CREATE PROCEDURE InsertChats
  @Id_Usuario INT,
  @Asunto VARCHAR(200),
  @Id_Psicologo	INT
  AS
	BEGIN
			SET NOCOUNT ON;
			INSERT INTO Chats VALUES ( @Id_Usuario, @Asunto, @Id_Psicologo);
			END
			GO

			EXEC InsertChats    3,'HolaMundo' ,1
			EXEC InsertChats  4, 'mensaje en blanco',2  
			EXEC InsertChats   5,'error mensaje', 3
		

	SELECT * FROM Chats


	SELECT * FROM Psicologo
------------------------------------------------------------------------------------------------------------
------------------------------------------ACTUALIZAR CHAT----------------------------------------------------


IF OBJECT_ID('Actualizar_Chat') IS NOT NULL
BEGIN 
DROP PROC Actualizar_Chat
END 
GO
CREATE PROC Actualizar_Chat
@Id_Chat	INT,
   @Asunto VARCHAR(200),
  @Id_Usuario INT,
  @Id_Psicologo		INT
  
AS 
BEGIN 

SET NOCOUNT ON;
		UPDATE Chats SET Asunto = @Asunto,
						Id_usuario = @Id_Usuario,
						Id_Psicologo = @Id_Psicologo

WHERE  Id_Chat = @Id_Chat
END
GO

EXEC	Actualizar_Chat   1,'se ha cambiado todo', 2,1
EXEC	Actualizar_Chat   2,'en blanco', 3, 2
EXEC	Actualizar_Chat   3,'probando', 4, 3

SELECT*FROM Chats



-----------------------------------------------------------------------------------------------------------
-------------------------------------DELETE CHAT------------------------------------------------------------


IF OBJECT_ID('DeleteChat') IS NOT NULL
DROP PROCEDURE DeleteChat
GO

CREATE PROCEDURE DeleteChat
@Id_Chat 	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM Chats WHERE @Id_Chat= Id_Chat;
END
GO


EXEC DeleteChat 3
EXEC DeleteChat 4

SELECT * FROM Chats


----------------------------------------------------------------------------------------------------------------
--------------------------------MOSTRAR SOLO ID CHAT--------------------------------------------------------------

IF OBJECT_ID('SelectChats') IS NOT NULL
DROP PROCEDURE SelectChats
GO

CREATE PROCEDURE SelectChats
@Id_Chat	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Chats WHERE Id_Chat = @Id_Chat;
END
GO

EXEC SelectChats 1


SELECT *FROM Chats



------------------------------------------------------------------------------------------------------------
------------------------------MOSTRAR TODOS LOS DATOS DE CHAT-----------------------------------------------

 IF OBJECT_ID('DatosChat') IS NOT NULL
DROP PROCEDURE DatosChat
GO

CREATE PROCEDURE DatosChat

AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Chats
END
GO

EXEC DatosUsuario


            
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------PSICOLOGO------------------------------------------------------



---------------------------------------------------------------------------------------------------------------
---------------------------------INSERTAR PSICOLOGO-----------------------------------------------------------------

DROP PROCEDURE INSERTPsicologo

CREATE PROCEDURE INSERTPsicologo
 @Id_Usuario				INT,
 @Nombre				 VARCHAR(80),
  @Apellido				 VARCHAR(80),
  @Edad					 INT,
  @Especialidad			 VARCHAR(80),
  @Años_de_experiencia	 INT
  AS
	BEGIN
			SET NOCOUNT ON;
			INSERT INTO Psicologo VALUES ( @Id_Usuario, @Nombre, @Apellido, @Edad, @Especialidad, @Años_de_experiencia);
			END
			GO

			EXEC INSERTPsicologo   1,'Eveling', 'Cruz', 33, 'Resolución de Conflictos y Mediación Social', 5
				EXEC INSERTPsicologo  2,'Stheven', 'Torrez', 38, 'Resolución de Conflictos y Mediación Social', 3
					EXEC INSERTPsicologo  3,'Bryant', 'Lopez', 35, 'Resolución de Conflictos y Mediación Social', 4
			

	SELECT * FROM Psicologo




---------------------------------------------------------------------------------------------------------------
---------------------------------ACTUALIZAR PSICOLOGO-----------------------------------------------------------------


IF OBJECT_ID('ActualizarPsicologo') IS NOT NULL
BEGIN 
DROP PROC ActualizarPsicologo
END 
GO
CREATE PROC ActualizarPsicologo
@Id_Psicologo		INT,
  @Nombre				 VARCHAR(80),
  @Apellido				 VARCHAR(80),
  @Edad					TINYINT,
  @Especialidad			VARCHAR(80),
@Años_de_experiencia	INT
  
AS 
BEGIN 

SET NOCOUNT ON;
		UPDATE Psicologo SET Nombre = @Nombre,
						Apellido = @Apellido,
						Edad = @Edad,
						Especialidad = @Especialidad,
						Años_de_experiencia= @Años_de_experiencia

WHERE  Id_Psicologo = @Id_Psicologo
END
GO

EXEC	ActualizarPsicologo  1,'Kathleen', 'Maltez', 42, 'Recursos Humanos', 8

SELECT*FROM Psicologo


---------------------------------------------------------------------------------------------------------------
---------------------------------DELETE PSICOLOGO--------------------------------------------------------------

IF OBJECT_ID('DeletePsicologo') IS NOT NULL
DROP PROCEDURE DeletePsicologo
GO

CREATE PROCEDURE DeletePsicologo
@Id_Psicologo	INT
AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM Psicologo WHERE @Id_Psicologo= Id_Psicologo;
END
GO


EXEC DeletePsicologo 2

SELECT * FROM Psicologo


---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR SOLOO ID PSICOLOGO----------------------------------------------------


IF OBJECT_ID('SelectPsicologo') IS NOT NULL
DROP PROCEDURE SelectPsicologo
GO

CREATE PROCEDURE SelectPsicologo
@Id_Psicologo	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Psicologo WHERE Id_Psicologo = @Id_Psicologo;
END
GO

EXEC SelectPsicologo 1


SELECT *FROM Psicologo



---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR TODOS LOS DATOS DE PSICOLOGO------------------------------------------

IF OBJECT_ID('DatosPsicologo') IS NOT NULL
DROP PROCEDURE DatosPsicologo
GO

CREATE PROCEDURE DatosPsicologo

AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Psicologo
END
GO

EXEC DatosPsicologo




---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------MUNICIPIO----------------------------------------------------------



	---------------------------------------------------------------------------------------------------------------
---------------------------------INSERTAR MUNICIPIO-----------------------------------------------------------------

CREATE PROCEDURE InsertMunicipio
  @Nombre_municipio				VARCHAR(100),
  @Departamento					VARCHAR(80),
  @Id_Usuario					INT
  AS
	BEGIN
			SET NOCOUNT ON;
			INSERT INTO Municipio VALUES (  @Nombre_municipio, @Departamento, @Id_Usuario);
			END
			GO

			EXEC InsertMunicipio 'Chontales', 'Juigalpa', 1
				EXEC InsertMunicipio  'Managua', 'Managua', 2
					EXEC InsertMunicipio  'Esteli', 'Esteli',3
			
			SELECT * FROM Municipio



------------------------------------------------------------------------------------------------------------
--------------------------------ACTUALIZAR MUNICIPIO---------------------------------------------------------


IF OBJECT_ID('ActualizarMunicipio') IS NOT NULL
BEGIN 
DROP PROC ActualizarMunicipio
END 
GO
CREATE PROC ActualizarMunicipio
	@Id_municipio			INT,
  @Nombre_municipio				VARCHAR(100),
  @Departamento					VARCHAR(80),
  @Id_Usuario					INT
  
AS 
BEGIN 

SET NOCOUNT ON;
		UPDATE Municipio SET Nombre_municipio = @Nombre_municipio,
								Departamento = @Departamento,
								Id_Usuario = @Id_Usuario

WHERE  Id_municipio = @Id_municipio
END
GO

EXEC ActualizarMunicipio 1,'Nueva Segovia', 'Madrid',1
 

SELECT*FROM Municipio



------------------------------------------------------------------------------------------------------------
------------------------------------------DELETE MUNICIPIO----------------------------------------------------

IF OBJECT_ID('DeleteMunicipio') IS NOT NULL
DROP PROCEDURE DeleteMunicipio
GO

CREATE PROCEDURE DeleteMunicipio
 @Id_municipio INT 

AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM Municipio WHERE @Id_municipio= Id_municipio;
END
GO


EXEC DeleteMunicipio 2

SELECT * FROM Municipio


---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR SOLOO ID MUNICIPIO----------------------------------------------------


IF OBJECT_ID('SelectMunicipio') IS NOT NULL
DROP PROCEDURE SelectMunicipio
GO

CREATE PROCEDURE SelectMunicipio
@Id_Municipio	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Municipio WHERE Id_Municipio = @Id_Municipio;
END
GO

EXEC SelectMunicipio 1


SELECT *FROM Municipio



---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR TODOS LOS DATOS DE MUNICIPIO------------------------------------------

IF OBJECT_ID('DatosMunicipio') IS NOT NULL
DROP PROCEDURE DatosMunicipio
GO

CREATE PROCEDURE DatosMunicipio

AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Municipio
END
GO

EXEC DatosMunicipio



---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------CITAS----------------------------------------------------------



------------------------------------------------------------------------------------------------------------
------------------------------------------INSERTAR CITA----------------------------------------------------

 DROP PROCEDURE InsertCita
CREATE PROCEDURE InsertCita
  @Fecha DATETIME,
  @Id_Usuario INT,
  @Id_Psicologo INT,
  @Id_Municipio INT
  AS
	BEGIN
			SET NOCOUNT ON;
			INSERT INTO Citas VALUES (  @Fecha, @Id_Usuario, @Id_Psicologo,@Id_Municipio);
			END
			GO			
			
			SELECT * FROM Citas
			



------------------------------------------------------------------------------------------------------------
------------------------------------------ACTUALIZAR CITA----------------------------------------------------


IF OBJECT_ID('ActualizarCita') IS NOT NULL
BEGIN 
DROP PROC ActualizarCita
END 
GO
CREATE PROC ActualizarCita
	 @Id_cita	INT,
  @Fecha VARCHAR(8),
  @hora datetime,
  @Id_Usuario INT,
  @Id_Psicologo INT,
  @Id_Municipio INT
  
AS 
BEGIN 

SET NOCOUNT ON;
		UPDATE Citas SET
							Fecha= @Fecha,
							hora = @hora,
							Id_Usuario = @Id_Usuario,
							Id_Psicologo = @Id_Psicologo,
							Id_Municipio = @Id_Municipio
							


WHERE  Id_cita = @Id_cita

END
GO

EXEC	ActualizarCita 1,'23', 5, 1,1,1

SELECT*FROM Citas


------------------------------------------------------------------------------------------------------------
------------------------------------------DELETE CITA----------------------------------------------------

IF OBJECT_ID('DeleteCita') IS NOT NULL
DROP PROCEDURE DeleteCita
GO

CREATE PROCEDURE DeleteCita
 @Id_cita INT 

AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM Citas WHERE @Id_cita= Id_cita;
END
GO


EXEC DeleteCita 1

SELECT * FROM Citas



---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR SOLOO ID CITAS----------------------------------------------------


IF OBJECT_ID('SelectCita') IS NOT NULL
DROP PROCEDURE SelectCita
GO

CREATE PROCEDURE SelectCita
@Id_cita	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Citas WHERE Id_cita = @Id_cita;
END
GO

EXEC SelectCita 3


SELECT *FROM Citas



---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR TODOS LOS DATOS DE CITAS------------------------------------------

IF OBJECT_ID('DatosCita') IS NOT NULL
DROP PROCEDURE DatosCita
GO

CREATE PROCEDURE DatosCita

AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Citas
END
GO

EXEC DatosCita





---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------MEMBRESIA---------------------------------------------------------



---------------------------------------------------------------------------------------------------------------
---------------------------------INSERTAR MEMBRESIA-----------------------------------------------------------------
CREATE PROCEDURE InserMembresia
  @Descripcion VARCHAR(90),
  @Precio		VARCHAR(3),
  @Id_Usuario		INT
  AS
	BEGIN
			SET NOCOUNT ON;
			INSERT INTO Membresia VALUES ( @Descripcion, @Precio, @Id_Usuario);
			END
			GO


		EXEC InserMembresia  'la membresia de cobre', '250', 3
		
		EXEC InserMembresia  'la membresia de cobre', '250', 2
		
		EXEC InserMembresia  'la membresia de cobre', '250', 1


	SELECT * FROM Membresia

	


------------------------------------------------------------------------------------------------------------
------------------------------------------ACTUALIZAR MEMBRESIA----------------------------------------------------

IF OBJECT_ID('ActualizarMembresia') IS NOT NULL
BEGIN 
DROP PROC ActualizarMembresia
END 
GO
CREATE PROC ActualizarMembresia
@Id_Membresia	INT,
  @Descripcion VARCHAR(90),
  @Precio VARCHAR(20),
  @Id_Usuario		INT
  
AS 
BEGIN 

SET NOCOUNT ON;
		UPDATE Membresia SET Descripcion = @Descripcion,
								Precio = @Precio,
								Id_Usuario = @Id_Usuario

WHERE  Id_Membresia = @Id_Membresia

END
GO

EXEC	ActualizarMembresia 1,'esta es descripcion', '240',2

SELECT*FROM Membresia



------------------------------------------------------------------------------------------------------------
------------------------------------------DELETE MEMBRESIA----------------------------------------------------

IF OBJECT_ID('DeleteMembresia') IS NOT NULL
DROP PROCEDURE DeleteMembresia
GO

CREATE PROCEDURE DeleteMembresia
 @Id_Membresia INT 

AS
BEGIN
		SET NOCOUNT ON;
		DELETE FROM Membresia WHERE @Id_Membresia= Id_Membresia;
END
GO


EXEC DeleteMembresia 2

SELECT * FROM Membresia



---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR SOLOO ID MEMBRESIA----------------------------------------------------


IF OBJECT_ID('SelectMembresia') IS NOT NULL
DROP PROCEDURE SelectMembresia
GO

CREATE PROCEDURE SelectMembresia
@Id_Membresia	INT
AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Membresia WHERE Id_Membresia = @Id_Membresia;
END
GO

EXEC SelectMembresia 3


SELECT *FROM Membresia




---------------------------------------------------------------------------------------------------------------
---------------------------------MOSTRAR TODOS LOS DATOS DE MEMBRESIA------------------------------------------

IF OBJECT_ID('DatosMembresia') IS NOT NULL
DROP PROCEDURE DatosMembresia
GO

CREATE PROCEDURE DatosMembresia

AS
BEGIN
		SET NOCOUNT ON;
		SELECT * FROM Membresia
END
GO

EXEC DatosMembresia

SELECT * FROM Membresia
