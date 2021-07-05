USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereVinculoParental_Documento]    Script Date: 15/04/2020 09:55:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereVinculoParental_Documento] 
@IdVinculo int,
@IdDocumento int

as
begin
insert into dbo.VinculosDocumentos (idvinculo,iddocumento)
values (@IdVinculo,@IdDocumento)
End
GO

