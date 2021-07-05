USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereNovaUnidade]    Script Date: 15/04/2020 09:53:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE procedure [dbo].[InsereNovaUnidade] 
@Descrição ntext,
@Sigla ntext

as
begin
insert into dbo.UnidadeParametro (descrição,sigla)
values (@Descrição,@Sigla)
End
GO

