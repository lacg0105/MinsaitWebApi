USE [Minsait]
GO

/****** Object:  Table [dbo].[CatPais]    Script Date: 18/11/2021 01:12:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CatPais](
	[IdPais] [int] IDENTITY(1,1) NOT NULL,
	[NombrePais] [varchar](255) NOT NULL,
 CONSTRAINT [PK_CatPais] PRIMARY KEY CLUSTERED 
(
	[IdPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


