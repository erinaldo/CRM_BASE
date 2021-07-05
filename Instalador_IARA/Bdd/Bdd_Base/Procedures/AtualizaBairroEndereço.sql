USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[AtualizaBairroEndereço]    Script Date: 15/04/2020 09:47:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[AtualizaBairroEndereço] 
@IdBairro int,
@IdEndereço int

as
begin
SET NOCOUNT ON;
    UPDATE dbo.Endereços 
    SET IdBairro=@IdBairro
    WHERE IdEndereço =@IdEndereço
End
GO

