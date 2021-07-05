USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[AtualizaLogin]    Script Date: 15/04/2020 09:48:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[AtualizaLogin] 
@IdLogin int,
@NICK ntext,
@Pass ntext,
@IdColaborador int,
@idpermissões int

as
begin
SET NOCOUNT ON;
    UPDATE dbo.login 
    SET nick = @nick, pass = @pass, idcolaborador = @idcolaborador, Idpermissões = @idpermissões 
    WHERE Idlogin = @idlogin 
End
GO

