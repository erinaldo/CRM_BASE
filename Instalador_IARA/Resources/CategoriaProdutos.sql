USE [Base]
GO

/****** Object:  Table [dbo].[CategoriasProdutos]    Script Date: 15/04/2020 09:36:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CategoriasProdutos](
	[IdCategoriaProduto] [int] IDENTITY(1,1) NOT NULL,
	[Descrição] [ntext] NULL,
 CONSTRAINT [PK_CategoriasProdutos] PRIMARY KEY CLUSTERED 
(
	[IdCategoriaProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

