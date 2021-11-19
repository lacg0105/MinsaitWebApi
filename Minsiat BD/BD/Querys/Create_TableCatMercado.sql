USE [Minsait]
GO

/****** Object:  Table [dbo].[CatMercado]    Script Date: 18/11/2021 01:12:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CatMercado](
	[IdMercado] [int] IDENTITY(1,1) NOT NULL,
	[NombreMercado] [varchar](255) NOT NULL,
 CONSTRAINT [PK_CatMercado] PRIMARY KEY CLUSTERED 
(
	[IdMercado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


