USE [Base]
GO

/****** Object:  Table [dbo].[UnidadesGeral]    Script Date: 15/04/2020 09:45:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UnidadesGeral](
	[IdUnidadeX] [int] IDENTITY(1,1) NOT NULL,
	[IdUnidade] [int] NULL,
	[ft_X] [int] NULL,
	[ChaveValidada] [int] NULL,
	[Operação] [bit] NULL,
 CONSTRAINT [PK_UnidadesGeral] PRIMARY KEY CLUSTERED 
(
	[IdUnidadeX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

