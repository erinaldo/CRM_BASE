USE [Base]
GO

/****** Object:  Table [dbo].[Endereços]    Script Date: 15/04/2020 09:41:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereços](
	[IdEndereço] [int] IDENTITY(1,1) NOT NULL,
	[IdBairro] [int] NULL,
	[Descrição] [ntext] NULL,
	[CEP] [int] NULL,
	[IdAbreviação] [int] NULL,
 CONSTRAINT [PK_Endereços] PRIMARY KEY CLUSTERED 
(
	[IdEndereço] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

