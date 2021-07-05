USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereDescriçãoEndereço]    Script Date: 15/04/2020 09:51:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[InsereDescriçãoEndereço] 
@Descrição ntext,
@Abreviação ntext

as
begin
insert into dbo.descriçãologradouros (descrição,abreviação)
values (@Descrição,@Abreviação)
End
GO

