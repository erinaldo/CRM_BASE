USE [Base]
GO

/****** Object:  Table [dbo].[QuadraEstoque]    Script Date: 15/04/2020 09:44:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[QuadraEstoque](
	[IdQuadraEstoque] [int] IDENTITY(1,1) NOT NULL,
	[IdEstoque] [int] NULL,
	[NomeMatriz] [ntext] NULL,
 CONSTRAINT [PK_QuadraEstoque] PRIMARY KEY CLUSTERED 
(
	[IdQuadraEstoque] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

