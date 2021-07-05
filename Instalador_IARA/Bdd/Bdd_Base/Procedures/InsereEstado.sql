USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereEstado]    Script Date: 15/04/2020 09:51:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[InsereEstado] 
@IdPais int,
@Descrição ntext,
@Sigla ntext,
@CodTel int

as
begin
insert into dbo.estados (idpais,descrição,sigla,codtel)
values (@IdPais,@Descrição,@Sigla,@CodTel)
End
GO

