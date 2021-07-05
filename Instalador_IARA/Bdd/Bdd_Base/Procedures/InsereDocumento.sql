USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereDocumento]    Script Date: 15/04/2020 09:51:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereDocumento] 
@Descrição ntext,
@Sigla ntext,
@Mascara ntext

as
begin
insert into dbo.documentos (descrição,sigla,mascara)
values (@Descrição,@sigla,@Mascara)
End
GO

