USE [Base]
GO

/****** Object:  Table [dbo].[Documentos]    Script Date: 15/04/2020 09:38:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Documentos](
	[IdDocumento] [int] IDENTITY(1,1) NOT NULL,
	[Descrição] [ntext] NULL,
	[Sigla] [ntext] NULL,
	[Mascara] [ntext] NULL,
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
(
	[IdDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

