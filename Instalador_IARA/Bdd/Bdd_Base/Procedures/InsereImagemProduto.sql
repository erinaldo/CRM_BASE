USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereImagemProduto]    Script Date: 15/04/2020 09:52:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereImagemProduto] 
@IdProduto int,
@Imagem image

as
begin
insert into dbo.ImagemProduto (idproduto,imagem)
values (@IdProduto,@Imagem)
End
GO

