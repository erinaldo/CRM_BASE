USE [Base]
GO

/****** Object:  Table [dbo].[RuaEstoque]    Script Date: 15/04/2020 09:45:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RuaEstoque](
	[IdRuaEstoque] [int] IDENTITY(1,1) NOT NULL,
	[IdQuadra] [int] NULL,
	[NomeMatriz] [ntext] NULL,
 CONSTRAINT [PK_RuaEstoque] PRIMARY KEY CLUSTERED 
(
	[IdRuaEstoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
