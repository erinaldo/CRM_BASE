USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InserePais]    Script Date: 15/04/2020 09:54:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[InserePais] 
@Descrição ntext,
@Sigla ntext,
@CodTel int

as
begin
insert into dbo.Paises (Descrição,Sigla,CodTel)
values (@descrição,@sigla,@codtel)
End
GO

