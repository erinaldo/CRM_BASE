USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereNovoProduto]    Script Date: 15/04/2020 09:53:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[InsereNovoProduto] 
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
insert into dbo.produtos (idfabricante,fabricante, Descrição,CodFabricante,CodBarras,IdCategoria,Categoria,IDSubCategoria,SubCategoria,NCM,IdUnComp,UnCompra,IdUnVenda,UnVenda,VendaDireta,Insumo,UsoInterno,Reaproveitamento)
values (@idfabricante,@Fabricante,@Descrição,@CodFabricante,@CodBarras,@IdCategoria,@Categoria,@IDSubCategoria,@SubCategoria,@NCM,@IdUnComp,@UnCompra,@IdUnVenda,@UnVenda,@VendaDireta,@Insumo,@UsoInterno,@Reaproveitamento)
End
GO

