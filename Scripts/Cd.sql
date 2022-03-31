GO
use pruebaTecnicaActive
GO
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarCd')
DROP PROCEDURE ActualizarCd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'EliminarCd')
DROP PROCEDURE EliminarCd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarCd')
DROP PROCEDURE InsertarCd
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarCd')
DROP PROCEDURE ListarCd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerCd')
DROP PROCEDURE ObtenerCd
GO
--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE ActualizarCd
(
		@codigoTitulo BIGINT,
		@condicion VARCHAR(300),
		@ubicacion VARCHAR(500),
		@estado VARCHAR(500),
		@nroCd BIGINT
)
AS

BEGIN

		UPDATE [dbo].[Cd] SET
		CodigoTitulo = @codigoTitulo,
		Condicion = @condicion,
		Ubicacion = @ubicacion,
		Estado=@estado
		WHERE NroCd = @nroCd
		END
GO

CREATE PROCEDURE EliminarCd
(
@nroCd BIGINT
)
AS
BEGIN

	DELETE FROM 
		[dbo].[Cd] 
	WHERE 
		NroCd= @nroCd

END 

GO

CREATE PROCEDURE InsertarCd
(
		@codigoTitulo BIGINT,
		@condicion VARCHAR(300),
		@ubicacion VARCHAR(500),
		@estado VARCHAR(500)
)
AS

BEGIN
INSERT INTO [dbo].[Cd] 
(
	CodigoTitulo,
	Condicion,
	Ubicacion,
	Estado
)
VALUES
(
	@codigoTitulo,
	@condicion,
	@ubicacion,
	@estado
)
	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

CREATE PROCEDURE ListarCd
AS
BEGIN

SELECT * FROM [dbo].[Cd]
END 
GO

CREATE PROCEDURE ObtenerCd
(
		@nroCd BIGINT 
)
AS

BEGIN
		SELECT * FROM [dbo].[Cd] 
		WHERE
		NroCd= @nroCd
END
GO