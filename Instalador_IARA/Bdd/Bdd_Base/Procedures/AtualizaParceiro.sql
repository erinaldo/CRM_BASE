USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[AtualizaParceiro]    Script Date: 15/04/2020 09:48:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[AtualizaParceiro] 
@IdParceiro int,
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
@Email ntext,
@TipoParceiro int

as
begin
SET NOCOUNT ON;
    UPDATE dbo.ParceirosComerciais 
	SET razãosocial_nome = @RazãoSocial_nome, cpf_cnpj = @CPF_CNPJ, RG_IE = @RG_IE, TipoPersonalidade = @TipoPersonalidade ,CEP=@CEP,IdEndereço=@IdEndereço,Endereço=@Endereço,Numero=@Numero,Complemento=@Complemento,Bairro=@Bairro,Cidade=@Cidade,Estado=@Estado,Pais=@Pais,Telefone=@Telefone,CElular=@CElular,Email=@Email, TipoParceiro =@TipoParceiro 
    WHERE IdParceiro  = @IdParceiro 
End
GO

