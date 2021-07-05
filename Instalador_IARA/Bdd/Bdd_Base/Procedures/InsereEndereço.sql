USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereEndereço]    Script Date: 15/04/2020 09:51:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[InsereEndereço] 
@IdBairro int,
@Descrição ntext,
@CEP int,
@IdAbreviação int

as
begin
insert into dbo.Endereços (idBairro,descrição,CEP, idabreviação)
values (@IdBairro,@Descrição,@CEP,@IdAbreviação)
End
GO

