GO
use pruebaTecnicaActive
GO
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarCliente')
DROP PROCEDURE ActualizarCliente
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'EliminarCliente')
DROP PROCEDURE EliminarCliente
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarCliente')
DROP PROCEDURE InsertarCliente
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarCliente')
DROP PROCEDURE ListarCliente
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerCliente')
DROP PROCEDURE ObtenerCliente
GO
--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE ActualizarCliente
(
		@codigoCliente BIGINT,
		@telefono BIGINT,
		@nombreCliente VARCHAR(40),
		@email VARCHAR(50),
		@cedula BIGINT,
		@fechaNacimiento DATETIME,
		@fechaInscripcion DATETIME,
		@temaInteres VARCHAR(MAX),
		@estado VARCHAR(50)
)
AS

BEGIN

		UPDATE [dbo].[Cliente] SET
		Telefono = @telefono,
		NombreCliente = @nombreCliente,
		Email = @email,
		Cedula=@cedula,
		FechaNacimiento=@fechaNacimiento,
		FechaInscripcion=@fechaInscripcion,
		TemaInteres=@temaInteres,
		Estado=@estado
		WHERE CodigoCliente = @codigoCliente
		END
GO

CREATE PROCEDURE EliminarCliente
(
@codigoCliente BIGINT
)
AS
BEGIN

	DELETE FROM 
		[dbo].[Cliente] 
	WHERE 
		CodigoCliente= @codigoCliente

END 

GO

CREATE PROCEDURE InsertarCliente
(
		@telefono BIGINT,
		@nombreCliente VARCHAR(40),
		@email VARCHAR(50),
		@cedula BIGINT,
		@fechaNacimiento DATETIME,
		@fechaInscripcion DATETIME,
		@temaInteres VARCHAR(MAX),
		@estado VARCHAR(50)
)
AS

BEGIN
INSERT INTO [dbo].[Cliente] 
(
	Telefono,
	NombreCliente,
	Email,
	Cedula,
	FechaNacimiento,
	FechaInscripcion,
	TemaInteres,
	Estado
)
VALUES
(
	@telefono,
	@nombreCliente,
	@email,
	@cedula,
	@fechaNacimiento,
	@fechaInscripcion,
	@temaInteres,
	@estado
)
	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

CREATE PROCEDURE ListarCliente
AS
BEGIN

SELECT * FROM [dbo].[Cliente]
END 
GO

CREATE PROCEDURE ObtenerCliente
(
		@codigoCliente BIGINT 
)
AS

BEGIN
		SELECT * FROM [dbo].[Cliente] 
		WHERE
		CodigoCliente= @codigoCliente
END
GO