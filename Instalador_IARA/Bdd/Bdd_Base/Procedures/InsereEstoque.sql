USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereEstoque]    Script Date: 15/04/2020 09:52:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereEstoque] 
@NomeEstoque ntext,
@CepEstoque ntext,
@Idendereço int,
@Endereço ntext,
@bairro ntext,
@cidade ntext,
@estado ntext,
@pais ntext,
@numero int,
@Complemento ntext

as
begin
insert into dbo.estoques (NomeEstoque,CepEstoque,Idendereço,Endereço,bairro,cidade,estado,pais,numero,complemento)
values (@NomeEstoque,@CepEstoque,@Idendereço,@Endereço,@bairro,@cidade,@estado,@pais,@numero,@Complemento)
End
GO

