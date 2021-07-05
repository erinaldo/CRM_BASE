USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereColaborador]    Script Date: 15/04/2020 09:50:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Create procedure [dbo].[InsereColaborador] 
@NomeCompleto ntext,
@CPF ntext,
@RG ntext,
@NomePai Ntext,
@NomeMãe ntext,
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
@Email ntext,
@TelefoneCont1 ntext,
@NomeCont1 ntext,
@TelefoneCont2 ntext,
@NomeCont2 ntext,
@TelefoneCont3 ntext,
@NomeCont3 ntext,
@Foto image,
@IdCargo int,
@Cargo ntext,
@IdNacionalidade int,
@Nacionalidade ntext

as
begin
insert into dbo.Funcionarios (NomeCompleto,cpf,rg, nomepai,nomemãe,cep,idendereço,endereço,numero,complemento,bairro,cidade,estado,pais,telefone,celular,email,telefonecont1,nomecont1,telefonecont2,nomecont2,telefonecont3,nomecont3,foto,idcargo,cargo,idnacionalidade,nacionalidade)
values (@NomeCompleto,@CPF,@rg,@NomePai,@NomeMãe,@cep,@IdEndereço,@Endereço,@Numero,@Complemento,@bairro,@cidade,@estado,@pais,@telefone,@Celular,@Email,@TelefoneCont1,@NomeCont1,@TelefoneCont2,@NomeCont2,@TelefoneCont3,@NomeCont3,@foto,@IdCargo,@cargo,@IdNacionalidade,@Nacionalidade)
End
GO

