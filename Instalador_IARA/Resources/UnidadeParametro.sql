USE [Base]
GO

/****** Object:  Table [dbo].[UnidadeParametro]    Script Date: 15/04/2020 09:45:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UnidadeParametro](
	[IdUnidade] [int] IDENTITY(1,1) NOT NULL,
	[Descrição] [ntext] NULL,
	[Sigla] [ntext] NULL,
 CONSTRAINT [PK_UnidadeParametro] PRIMARY KEY CLUSTERED 
(
	[IdUnidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

