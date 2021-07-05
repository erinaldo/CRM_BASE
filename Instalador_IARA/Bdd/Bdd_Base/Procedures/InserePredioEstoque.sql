USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InserePredioEstoque]    Script Date: 15/04/2020 09:54:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InserePredioEstoque] 
@IdRuaEstoque int,
@NomeMatriz ntext

as
begin
insert into dbo.PredioEstoque (IdRuaEstoque,nomematriz)
values (@IdRuaEstoque,@NomeMatriz)
End
GO

