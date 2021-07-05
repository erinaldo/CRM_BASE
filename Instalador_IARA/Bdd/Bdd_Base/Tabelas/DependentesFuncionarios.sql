USE [Base]
GO

/****** Object:  Table [dbo].[DependentesFuncionarios]    Script Date: 15/04/2020 09:38:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DependentesFuncionarios](
	[IdDependente] [int] IDENTITY(1,1) NOT NULL,
	[IdFuncionario] [int] NULL,
	[Nome] [ntext] NULL,
	[IdVinculo] [int] NULL,
	[Vinculo] [ntext] NULL,
 CONSTRAINT [PK_DependentesFuncionarios] PRIMARY KEY CLUSTERED 
(
	[IdDependente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

