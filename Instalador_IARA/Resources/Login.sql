USE [Base]
GO

/****** Object:  Table [dbo].[Login]    Script Date: 15/04/2020 09:43:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Login](
	[IdLogin] [int] IDENTITY(1,1) NOT NULL,
	[Nick] [ntext] NULL,
	[Pass] [ntext] NULL,
	[IdColaborador] [int] NULL,
	[IdPermissões] [int] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[IdLogin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

