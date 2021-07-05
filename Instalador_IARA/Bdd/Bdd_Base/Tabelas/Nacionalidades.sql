USE [Base]
GO

/****** Object:  Table [dbo].[Nacionalidades]    Script Date: 15/04/2020 09:43:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Nacionalidades](
	[IdNacionalidade] [int] IDENTITY(1,1) NOT NULL,
	[Nacionalidade] [ntext] NULL,
	[IdPais] [int] NULL,
	[Pais] [ntext] NULL,
 CONSTRAINT [PK_Nacionalidades] PRIMARY KEY CLUSTERED 
(
	[IdNacionalidade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

