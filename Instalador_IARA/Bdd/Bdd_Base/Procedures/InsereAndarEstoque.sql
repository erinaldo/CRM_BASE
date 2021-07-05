USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereAndarEstoque]    Script Date: 15/04/2020 09:49:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereAndarEstoque] 
@IdPredioEstoque int,
@NomeMatriz ntext

as
begin
insert into dbo.AndarEstoque (IdpredioEstoqeu,nomematriz)
values (@IdPredioEstoque,@NomeMatriz)
End
GO

