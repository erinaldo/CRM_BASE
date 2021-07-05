USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereCliente]    Script Date: 15/04/2020 09:50:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereCliente] 
@RazãoSocial_nome ntext,
@CPF_CNPJ ntext,
@RG_IE ntext,
@TipoPersonalidade bit,
@CEP ntext,
@IdEndereço int,
@Endereço ntext,
@Numero int,
@Complemento ntext,
@Bairro ntext,
@Cidade ntext,
@Estado ntext,
@Pais ntext,
@Telefone ntext,
@CElular ntext,
@Email ntext

as
begin
insert into dbo.clientes (RazãoSocial_nome,CPF_CNPJ,RG_IE, TipoPersonalidade,cep,idendereço,endereço,numero,complemento,bairro,cidade,estado,pais,telefone,celular,email)
values (@RazãoSocial_nome,@CPF_CNPJ,@RG_IE,@TipoPersonalidade,@cep,@IdEndereço,@Endereço,@Numero,@Complemento,@bairro,@cidade,@estado,@pais,@telefone,@Celular,@Email)
End
GO

