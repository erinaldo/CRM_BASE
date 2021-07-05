USE [Base]
GO

/****** Object:  Table [dbo].[Funcionarios]    Script Date: 15/04/2020 09:42:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Funcionarios](
	[IdFuncionario] [int] IDENTITY(1,1) NOT NULL,
	[NomeCompleto] [ntext] NULL,
	[CPF] [ntext] NULL,
	[RG] [ntext] NULL,
	[NomePai] [ntext] NULL,
	[NomeMãe] [ntext] NULL,
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
	[TelefoneCont1] [ntext] NULL,
	[NomeCont1] [ntext] NULL,
	[telefoneCont2] [ntext] NULL,
	[NomeCont2] [ntext] NULL,
	[telefoneCont3] [ntext] NULL,
	[NomeCont3] [ntext] NULL,
	[Foto] [image] NULL,
	[IdCargo] [int] NULL,
	[Cargo] [ntext] NULL,
	[IdNacionalidade] [int] NULL,
	[Nacionalidade] [ntext] NULL,
 CONSTRAINT [PK_Funcionarios] PRIMARY KEY CLUSTERED 
(
	[IdFuncionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

