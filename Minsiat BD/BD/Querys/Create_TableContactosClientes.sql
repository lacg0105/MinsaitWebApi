USE [Minsait]
GO

/****** Object:  Table [dbo].[ContactosCliente]    Script Date: 19/11/2021 03:24:39 a. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContactosCliente](
	[IdContactoCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[NombreContacto] [varchar](255) NOT NULL,
	[PuestoContacto] [varchar](255) NOT NULL,
	[CorreoContacto] [varchar](255) NOT NULL,
	[NumeroContacto] [varchar](255) NOT NULL,
 CONSTRAINT [PK_ContactosCliente] PRIMARY KEY CLUSTERED 
(
	[IdContactoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ContactosCliente]  WITH CHECK ADD  CONSTRAINT [FK_ContactosCliente_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[ContactosCliente] CHECK CONSTRAINT [FK_ContactosCliente_Clientes]
GO


