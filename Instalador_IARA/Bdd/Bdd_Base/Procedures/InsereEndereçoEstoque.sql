USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereEndereçoEstoque]    Script Date: 15/04/2020 09:51:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereEndereçoEstoque] 
@IdAndarEstoque int,
@NomeMatriz ntext

as
begin
insert into dbo.EndereçoEstoque (IdandarEstoque,nomematriz)
values (@IdAndarEstoque,@NomeMatriz)
End
GO

