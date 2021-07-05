USE [Base]
GO

/****** Object:  Table [dbo].[Clientes]    Script Date: 15/04/2020 09:38:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[RazãoSocial_nome] [ntext] NULL,
	[CPF_CNPJ] [ntext] NULL,
	[RG_IE] [ntext] NULL,
	[TipoPersonalidade] [bit] NULL,
	[CEP] [ntext] NULL,
	[IdEndereço] [int] NULL,
	[Endereço] [ntext] NULL,
	[Numero] [int] NULL,
	[Complemento] [ntext] NULL,
	[Bairro] [ntext] NULL,
	[CIdade] [ntext] NULL,
	[Estado] [ntext] NULL,
	[Pais] [ntext] NULL,
	[Telefone] [ntext] NULL,
	[Celular] [ntext] NULL,
	[Email] [ntext] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

