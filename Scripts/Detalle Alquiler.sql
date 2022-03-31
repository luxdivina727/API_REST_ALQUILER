GO
use pruebaTecnicaActive
GO
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ActualizarDetalleAlquiler')
DROP PROCEDURE ActualizarDetalleAlquiler
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'EliminarDetalleAlquiler')
DROP PROCEDURE EliminarDetalleAlquiler
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'InsertarDetalleAlquiler')
DROP PROCEDURE InsertarDetalleAlquiler
GO 

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListarDetalleAlquiler')
DROP PROCEDURE ListarDetalleAlquiler
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ObtenerDetalleAlquiler')
DROP PROCEDURE ObtenerDetalleAlquiler
GO
--************************ PROCEDIMIENTOS PARA CREAR ************************--
CREATE PROCEDURE ActualizarDetalleAlquiler
(
		@codigoTitulo BIGINT,
		@item INT,
		@nroCd BIGINT,
		@diasPrestamos INT,
		@nroAlquiler BIGINT,
		@codigoDetalleAlquiler BIGINT,
		@fechaDevolucion DATETIME
)
AS

BEGIN

		UPDATE [dbo].[DetalleAlquiler] SET
		NroAlquiler = @nroAlquiler,
		Item = @item,
		CodigoTitulo = @codigoTitulo,
		NroCd=@nroCd,
		DiasPrestamo=@diasPrestamos,
		FechaDevolucion=@fechaDevolucion
		WHERE CodigoDetalleAlquiler = @codigoDetalleAlquiler
		END
GO

CREATE PROCEDURE EliminarDetalleAlquiler
(
@nroAlquiler BIGINT
)
AS
BEGIN

	DELETE FROM 
		[dbo].[DetalleAlquiler] 
	WHERE 
		NroAlquiler= @nroAlquiler

END 

GO

CREATE PROCEDURE InsertarDetalleAlquiler
(
		@codigoTitulo BIGINT,
		@item INT,
		@nroCd BIGINT,
		@diasPrestamos INT,
		@nroAlquiler BIGINT,
		@fechaDevolucion DATETIME
)
AS

BEGIN
INSERT INTO [dbo].[DetalleAlquiler] 
(
	CodigoTitulo,
	Item,
	NroCd,
	DiasPrestamo,
	NroAlquiler,
	FechaDevolucion
)
VALUES
(
	@codigoTitulo,
	@item,
	@nroCd,
	@diasPrestamos,
	@nroAlquiler,
	@fechaDevolucion
)
	SELECT CAST(SCOPE_IDENTITY() AS BIGINT)
END
GO

CREATE PROCEDURE ListarDetalleAlquiler
AS
BEGIN

SELECT * FROM [dbo].[DetalleAlquiler]
END 
GO

CREATE PROCEDURE ObtenerDetalleAlquiler
(
		@nroDetalleAlquiler BIGINT 
)
AS

BEGIN
		SELECT * FROM [dbo].[DetalleAlquiler] 
		WHERE
		CodigoDetalleAlquiler= @nroDetalleAlquiler
END
GO