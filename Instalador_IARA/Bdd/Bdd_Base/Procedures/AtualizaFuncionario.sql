USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[AtualizaFuncionario]    Script Date: 15/04/2020 09:48:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE procedure [dbo].[AtualizaFuncionario] 
@IdFuncionario int,
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
SET NOCOUNT ON;
    UPDATE dbo.funcionarios 
    SET nomecompleto = @NomeCompleto, cpf = @cpf, rg = @rg,nomepai = @nomepai, nomemãe = @NomeMãe, cep = @cep, idendereço = @IdEndereço, Endereço = @Endereço ,numero = @numero, complemento = @complemento,bairro = @bairro, cidade = @cidade, estado = @estado, Pais = @pais,telefone = @telefone, celular = @celular,email = @email, telefonecont1 = @TelefoneCont1,nomecont1 = @NomeCont1 ,telefonecont2 = @telefonecont2, nomecont2 = @NomeCont2 ,telefonecont3 = @TelefoneCont3 , nomecont3 = @NomeCont3 ,idcargo = @IdCargo , cargo = @cargo, idnacionalidade = @IdNacionalidade , nacionalidade = @nacionalidade
    WHERE idfuncionario = @idfuncionario 
End
GO

