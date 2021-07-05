USE [Base]
GO

/****** Object:  Table [dbo].[DescriçãoLogradouros]    Script Date: 15/04/2020 09:38:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DescriçãoLogradouros](
	[IdDescriçãoLog] [int] IDENTITY(1,1) NOT NULL,
	[Descrição] [ntext] NULL,
	[Abreviação] [ntext] NULL,
 CONSTRAINT [PK_DescriçãoLogradouros] PRIMARY KEY CLUSTERED 
(
	[IdDescriçãoLog] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

