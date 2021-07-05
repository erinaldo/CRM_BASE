USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereNacionalidade]    Script Date: 15/04/2020 09:53:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[InsereNacionalidade] 
@Nacionalidade ntext,
@IdPais int,
@Pais ntext

as
begin
insert into dbo.Nacionalidades (Nacionalidade ,IdPais,Pais)
values (@Nacionalidade,@IdPais,@Pais)
End
GO

