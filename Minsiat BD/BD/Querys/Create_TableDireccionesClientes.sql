USE [Minsait]
GO

/****** Object:  Table [dbo].[DireccionesCliente]    Script Date: 18/11/2021 01:14:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DireccionesCliente](
	[IdCliente] [int] NOT NULL,
	[DireccionCliente] [varchar](800) NOT NULL,
	[TelefonoCliente] [varchar](255) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[DireccionesCliente]  WITH CHECK ADD  CONSTRAINT [FK_DireccionesCliente_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

ALTER TABLE [dbo].[DireccionesCliente] CHECK CONSTRAINT [FK_DireccionesCliente_Clientes]
GO


