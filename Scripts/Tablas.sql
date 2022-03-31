CREATE DATABASE PruebaTecnicaActive

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cliente')
BEGIN
		CREATE TABLE [dbo].[Cliente] (
		[CodigoCliente]		BIGINT			   IDENTITY (1,1) NOT NULL,
		[Telefono]			BIGINT							  NOT NULL,
		[NombreCliente]		VARCHAR(40)						  NOT NULL,
		[Email]				VARCHAR(80)						  NOT NULL,
		[Cedula]			BIGINT								  NOT NULL,
		[FechaNacimiento]	DATETIME						  NOT NULL,
		[FechaInscripcion]	DATETIME						  NOT NULL,
		[TemaInteres]		VARCHAR(MAX)					  NOT NULL,
		[Estado]			VARCHAR(50)						  NOT NULL,
		CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([CodigoCliente] ASC)
		);
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Alquiler')
BEGIN
			CREATE TABLE [dbo].[Alquiler](
			[NroAlquiler]			BIGINT				IDENTITY(1,1) NOT NULL,
			[FechaAlquiler]			DATETIME						  NOT NULL,
			[ValorAlquiler]		    INT								  NOT NULL,
			[CodigoCliente]			BIGINT							  NOT NULL,
			CONSTRAINT [PK_Alquiler] PRIMARY KEY CLUSTERED ([NroAlquiler] ASC)
			);
END 
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Alquiler')
BEGIN

	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Alquiler_Cliente')
	BEGIN

		ALTER TABLE [dbo].[Alquiler]
		ADD CONSTRAINT [FK_Alquiler_Cliente] FOREIGN KEY ([CodigoCliente]) REFERENCES [dbo].[Cliente] ([CodigoCliente]);

	END
END 
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Sancion')
BEGIN
	CREATE TABLE [dbo].[Sancion] (
	[NroSancion]			BIGINT			   IDENTITY(1,1) NOT NULL,
	[TipoSancion]			VARCHAR(50)						 NOT NULL,
	[NroDiasSancion]		INT								 NOT NULL,
	[CodigoCliente]			BIGINT							 NOT NULL ,
	[NroAlquiler]			BIGINT							 NOT NULL,
	CONSTRAINT [PK_Sancion] PRIMARY KEY CLUSTERED ([NroSancion] ASC)
	)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Sancion')
BEGIN

	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Sancion_Cliente')
	BEGIN

		ALTER TABLE [dbo].[Sancion]
		ADD CONSTRAINT [FK_Sancion_Cliente] FOREIGN KEY ([CodigoCliente]) REFERENCES [dbo].[Cliente] ([CodigoCliente]);

	END
		IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_Sancion_Alquiler')
	BEGIN

		ALTER TABLE [dbo].[Sancion]
		ADD CONSTRAINT [FK_Sancion_Alquiler] FOREIGN KEY ([NroAlquiler]) REFERENCES [dbo].[Alquiler] ([NroAlquiler]);

	END
END 
GO


IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Cd')
BEGIN
	CREATE TABLE [dbo].[Cd](
		[NroCd]					 BIGINT IDENTITY(1,1)		NOT NULL,
		[CodigoTitulo]			 BIGINT						NOT NULL ,
		[Condicion]				 VARCHAR(300)				NOT NULL,
		[Ubicacion]				 VARCHAR(500)				NOT NULL,
		[Estado]				 VARCHAR(500)				NOT NULL,
	CONSTRAINT [PK_Cd] PRIMARY KEY CLUSTERED ([NroCd] ASC)
		);
END
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DetalleAlquiler')
BEGIN
		CREATE TABLE [dbo].[DetalleAlquiler] (
		[CodigoDetalleAlquiler]			BIGINT IDENTITY(1,1)	NOT NULL,
		[NroAlquiler]					BIGINT					NOT NULL,
		[Item]							INT						NOT NULL,
		[CodigoTitulo]					BIGINT					NOT NULL,
		[NroCd]							BIGINT					NOT NULL,
		[DiasPrestamo]					INT						NOT NULL,
		[FechaDevolucion]				DATETIME				NOT NULL,
		CONSTRAINT [PK_DetalleAlquiler] PRIMARY KEY CLUSTERED ([CodigoDetalleAlquiler] ASC)
		)
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'DetalleAlquiler')
BEGIN

	IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_DetalleAlquiler_Cd')
	BEGIN

		ALTER TABLE [dbo].[DetalleAlquiler]
		ADD CONSTRAINT [FK_DetalleAlquiler_Cd] FOREIGN KEY ([NroCd]) REFERENCES [dbo].[Cd] ([NroCd]);

	END
		IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_NAME = 'FK_DetalleAlquiler_Alquiler')
	BEGIN

		ALTER TABLE [dbo].[DetalleAlquiler]
		ADD CONSTRAINT [FK_DetalleAlquiler_Alquiler] FOREIGN KEY ([NroAlquiler]) REFERENCES [dbo].[Alquiler] ([NroAlquiler]);

	END
END 
GO

