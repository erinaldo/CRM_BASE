USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereDependenteFuncionario]    Script Date: 15/04/2020 09:50:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[InsereDependenteFuncionario] 
@IdFuncionario int,
@Nome ntext,
@IdVinculo int,
@Vinculo ntext

as
begin
insert into dbo.DependentesFuncionarios (idfuncionario, nome,idvinculo,vinculo)
values (@IdFuncionario,@Nome,@IdVinculo, @vinculo)
End
GO

