GO
use pruebaTecnicaActive
GO
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarSancion')
DROP PROCEDURE ActualizarSancion
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'EliminarSancion')
DROP PROCEDURE EliminarSancion
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarSancion')
DROP PROCEDURE InsertarSancion
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarSancion')
DROP PROCEDURE ListarSancion
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerSancion')
DROP PROCEDURE ObtenerSancion
GO
--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE ActualizarSancion
(
		@nroSancion BIGINT,
		@tipoSancion VARCHAR(50),
		@nroDiasSancion INT,
		@codigoCliente BIGINT,
		@nroAlquiler BIGINT
)
AS

BEGIN

		UPDATE [dbo].[Sancion] SET
		TipoSancion = @tipoSancion,
		NroDiasSancion = @nroDiasSancion,
		CodigoCliente = @codigoCliente,
		NroAlquiler=@nroAlquiler
		WHERE NroSancion = @nroSancion
		END
GO

CREATE PROCEDURE EliminarSancion
(
	@nroSancion BIGINT
)
AS
BEGIN

	DELETE FROM 
		[dbo].[Sancion] 
	WHERE 
		NroSancion= @nroSancion

END 

GO

CREATE PROCEDURE InsertarSancion
(
		@tipoSancion VARCHAR(50),
		@nroDiasSancion INT,
		@codigoCliente BIGINT,
		@nroAlquiler BIGINT
)
AS

BEGIN
INSERT INTO [dbo].[Sancion] 
(
	TipoSancion,
	NroDiasSancion,
	CodigoCliente,
	NroAlquiler
)
VALUES
(
	@tipoSancion,
	@nroDiasSancion,
	@codigoCliente,
	@nroAlquiler
)
	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

CREATE PROCEDURE ListarSancion
AS
BEGIN

SELECT * FROM [dbo].[Sancion]
END 
GO

CREATE PROCEDURE ObtenerSancion
(
		@nroSancion BIGINT 
)
AS

BEGIN
		SELECT * FROM [dbo].[Sancion] 
		WHERE
		NroSancion= @nroSancion
END
GO