USE [Minsait]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 18/11/2021 01:13:35 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[IdPais] [int] NOT NULL,
	[IdMercado] [int] NOT NULL,
	[NombreCliente] [varchar](255) NOT NULL,
	[IdentificadorFiscal] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_CatMercado] FOREIGN KEY([IdMercado])
REFERENCES [dbo].[CatMercado] ([IdMercado])
GO

ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_CatMercado]
GO

ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_CatPais] FOREIGN KEY([IdPais])
REFERENCES [dbo].[CatPais] ([IdPais])
GO

ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_CatPais]
GO


