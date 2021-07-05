USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereVinculoParental]    Script Date: 15/04/2020 09:55:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereVinculoParental] 
@Descrição ntext

as
begin
insert into dbo.vinculosparentais (descrição)
values (@Descrição)
End
GO

