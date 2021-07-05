USE [Base]
GO

/****** Object:  Table [dbo].[EndereçoEstoque]    Script Date: 15/04/2020 09:39:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EndereçoEstoque](
	[IdEndereçoEstoque] [int] IDENTITY(1,1) NOT NULL,
	[IdAndarEstoque] [int] NULL,
	[NomeMatriz] [ntext] NULL,
 CONSTRAINT [PK_EndereçoEstoque] PRIMARY KEY CLUSTERED 
(
	[IdEndereçoEstoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

