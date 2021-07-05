USE [Base]
GO

/****** Object:  Table [dbo].[Produtos]    Script Date: 15/04/2020 09:44:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produtos](
	[IdProduto] [int] IDENTITY(1,1) NOT NULL,
	[Descrição] [ntext] NULL,
	[Idfabricante] [int] NULL,
	[Fabricante] [ntext] NULL,
	[CodFabricante] [ntext] NULL,
	[CodBarras] [ntext] NULL,
	[IdCategoria] [int] NULL,
	[Categoria] [ntext] NULL,
	[IDSubCategoria] [int] NULL,
	[SubCategoria] [ntext] NULL,
	[NCM] [ntext] NULL,
	[IdUnComp] [int] NULL,
	[UnCompra] [ntext] NULL,
	[IdUnVenda] [int] NULL,
	[UnVenda] [ntext] NULL,
	[VendaDireta] [bit] NULL,
	[Insumo] [bit] NULL,
	[UsoInterno] [bit] NULL,
	[Reaproveitamento] [bit] NULL,
 CONSTRAINT [PK_Produtos] PRIMARY KEY CLUSTERED 
(
	[IdProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

