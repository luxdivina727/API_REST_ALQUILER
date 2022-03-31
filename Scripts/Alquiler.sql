GO
use pruebaTecnicaActive
GO
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarAlquiler')
DROP PROCEDURE ActualizarAlquiler
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'EliminarAlquiler')
DROP PROCEDURE EliminarAlquiler
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarAlquiler')
DROP PROCEDURE InsertarAlquiler
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarAlquiler')
DROP PROCEDURE ListarAlquiler
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerAlquiler')
DROP PROCEDURE ObtenerAlquiler
GO
--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE ActualizarAlquiler
(
		@nroAlquiler BIGINT,
		@fechaAlquiler DATETIME,
		@valorAlquiler INT,
		@codigoCliente BIGINT
)
AS

BEGIN

		UPDATE [dbo].[Alquiler] SET
		FechaAlquiler = @fechaAlquiler,
		ValorAlquiler = @valorAlquiler,
		CodigoCliente = @codigoCliente
		WHERE NroAlquiler = @nroAlquiler
		END
GO

CREATE PROCEDURE EliminarAlquiler
(
@nroAlquiler BIGINT
)
AS
BEGIN

	DELETE FROM 
		[dbo].[Alquiler] 
	WHERE 
		NroAlquiler= @nroAlquiler

END 

GO

CREATE PROCEDURE InsertarAlquiler
(
		@fechaAlquiler DATETIME,
		@valorAlquiler INT,
		@codigoCliente BIGINT
)
AS

BEGIN
INSERT INTO [dbo].[Alquiler] 
(
	FechaAlquiler,
	ValorAlquiler,
	CodigoCliente
)
VALUES
(
	@fechaAlquiler,
	@valorAlquiler,
	@codigoCliente
)
	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

CREATE PROCEDURE ListarAlquiler
AS
BEGIN

SELECT * FROM [dbo].[Alquiler]
END 
GO

CREATE PROCEDURE ObtenerAlquiler
(
		@nroAlquiler BIGINT 
)
AS

BEGIN
		SELECT * FROM [dbo].[Alquiler] 
		WHERE
		NroAlquiler= @nroAlquiler
END
GO