USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereCidade]    Script Date: 15/04/2020 09:50:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[InsereCidade] 
@IdEstado int,
@Descrição ntext

as
begin
insert into dbo.cidade (idestado,descrição)
values (@IdEstado,@Descrição)
End
GO

