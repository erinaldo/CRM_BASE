USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereQuadraEstoque]    Script Date: 15/04/2020 09:54:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereQuadraEstoque] 
@Idestoque int,
@NomeMatriz ntext

as
begin
insert into dbo.QuadraEstoque (idestoque,nomematriz)
values (@Idestoque,@NomeMatriz)
End
GO

