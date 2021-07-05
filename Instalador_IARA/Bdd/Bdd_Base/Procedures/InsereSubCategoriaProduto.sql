USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereSubcategoriaProduto]    Script Date: 15/04/2020 09:55:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[InsereSubcategoriaProduto] 
@Idcategoria int,
@Descrição ntext

as
begin
insert into dbo.subcategoriasproduto (Idcategoria,descrição)
values (@Idcategoria,@Descrição)
End
GO

