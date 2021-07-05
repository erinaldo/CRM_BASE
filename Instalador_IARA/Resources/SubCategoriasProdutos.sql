USE [Base]
GO

/****** Object:  Table [dbo].[SubCategoriasProduto]    Script Date: 15/04/2020 09:45:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubCategoriasProduto](
	[IdSubCategoria] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Descrição] [ntext] NULL,
	[MarkupSugerido] [money] NULL,
 CONSTRAINT [PK_SubCategoriasProduto] PRIMARY KEY CLUSTERED 
(
	[IdSubCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

