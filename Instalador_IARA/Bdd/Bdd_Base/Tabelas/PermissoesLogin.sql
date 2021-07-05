USE [Base]
GO

/****** Object:  Table [dbo].[PermissoesLogin]    Script Date: 15/04/2020 09:44:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PermissoesLogin](
	[IdPermissão] [int] NOT NULL,
	[Descrição] [ntext] NULL,
 CONSTRAINT [PK_PermissoesLogin] PRIMARY KEY CLUSTERED 
(
	[IdPermissão] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

