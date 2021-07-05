USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereBairro]    Script Date: 15/04/2020 09:49:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[InsereBairro] 
@IdCidade int,
@Descrição ntext

as
begin
insert into dbo.Bairro (idCidade,descrição)
values (@IdCidade,@Descrição)
End
GO

