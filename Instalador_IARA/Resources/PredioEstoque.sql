USE [Base]
GO

/****** Object:  Table [dbo].[PredioEstoque]    Script Date: 15/04/2020 09:44:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PredioEstoque](
	[IdPredioEstoque] [int] IDENTITY(1,1) NOT NULL,
	[IdRuaEstoque] [int] NULL,
	[NomeMatriz] [ntext] NULL,
 CONSTRAINT [PK_PredioEstoque] PRIMARY KEY CLUSTERED 
(
	[IdPredioEstoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

