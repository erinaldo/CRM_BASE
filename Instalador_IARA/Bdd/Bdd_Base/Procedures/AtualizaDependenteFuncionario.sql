USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[AtualizaIdDependenteFuncionario]    Script Date: 15/04/2020 09:48:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




Create procedure [dbo].[AtualizaIdDependenteFuncionario] 
@IdFuncionario int,
@IdDependente int

as
begin
SET NOCOUNT ON;
    UPDATE dbo.dependentesFuncionarios 
    SET idfuncionario=@IdFuncionario
    WHERE idDependente = @IdDependente 
End
GO

