USE [Base]
GO

/****** Object:  Table [dbo].[AndarEstoque]    Script Date: 15/04/2020 09:34:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AndarEstoque](
	[IdAndarEstoque] [int] IDENTITY(1,1) NOT NULL,
	[IdPredioEstoqeu] [int] NULL,
	[NomeMatriz] [ntext] NULL,
 CONSTRAINT [PK_AndarEstoque] PRIMARY KEY CLUSTERED 
(
	[IdAndarEstoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

