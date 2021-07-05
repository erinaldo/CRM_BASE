USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereLogin]    Script Date: 15/04/2020 09:52:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereLogin] 
@NICK ntext,
@Pass ntext,
@IdColaborador int,
@idpermissões int

as
begin
insert into dbo.login (nick,pass,idcolaborador,idpermissões)
values (@nick,@pass,@IdColaborador,@idpermissões )
End
GO

