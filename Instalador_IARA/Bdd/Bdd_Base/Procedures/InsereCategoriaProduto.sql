USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereCategoriaProduto]    Script Date: 15/04/2020 09:49:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereCategoriaProduto] 
@Descrição ntext

as
begin
insert into dbo.categoriasprodutos (descrição)
values (@Descrição)
End
GO

