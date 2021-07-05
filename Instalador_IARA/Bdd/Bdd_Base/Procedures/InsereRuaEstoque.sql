USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereRuaEstoque]    Script Date: 15/04/2020 09:54:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereRuaEstoque] 
@IdQuadra int,
@NomeMatriz ntext

as
begin
insert into dbo.RuaEstoque (IdQuadra,nomematriz)
values (@IdQuadra,@NomeMatriz)
End
GO

