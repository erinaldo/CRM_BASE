USE [Base]
GO

/****** Object:  Table [dbo].[Estoques]    Script Date: 15/04/2020 09:42:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Estoques](
	[IdEstoque] [int] IDENTITY(1,1) NOT NULL,
	[NomeEstoque] [ntext] NULL,
	[CepEstoque] [ntext] NULL,
	[IdEndereço] [int] NULL,
	[Endereço] [ntext] NULL,
	[Bairro] [ntext] NULL,
	[Cidade] [ntext] NULL,
	[Estado] [ntext] NULL,
	[Pais] [ntext] NULL,
	[Numero] [int] NULL,
	[Complemento] [ntext] NULL,
 CONSTRAINT [PK_Estoques] PRIMARY KEY CLUSTERED 
(
	[IdEstoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

