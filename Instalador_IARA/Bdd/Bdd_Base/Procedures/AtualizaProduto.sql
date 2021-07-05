USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[AtualizaProduto]    Script Date: 15/04/2020 09:49:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




Create procedure [dbo].[AtualizaProduto] 
@IdProduto int,
@Descrição ntext,
@IdFabricante int,
@Fabricante ntext,
@CodFabricante ntext,
@CodBarras ntext,
@IdCategoria int,
@Categoria ntext,
@IDSubCategoria int,
@SubCategoria ntext,
@NCM ntext,
@IdUnComp int,
@UnCompra ntext,
@IdUnVenda int,
@UnVenda ntext,
@VendaDireta bit,
@Insumo bit,
@UsoInterno bit,
@Reaproveitamento bit


as
begin
SET NOCOUNT ON;
    UPDATE dbo.produtos 
    SET descrição =@descrição, idfabricante = @IdFabricante ,fabricante = @fabricante, codfabricante = @codfabricante, codbarras = @CodBarras, idcategoria = @idcategoria, Categoria=@categoria, IdSubcategoria = @IDSubCategoria, ncm = @ncm, iduncomp = @IdUnComp , uncompra = @uncompra, idunvenda = @idunvenda, Unvenda = @unvenda, Vendadireta = @vendadireta, insumo = @insumo, usointerno = @usointerno,reaproveitamento = @reaproveitamento
    WHERE idproduto =@IdProduto 
End
GO

