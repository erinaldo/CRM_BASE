USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[InsereNovaUnidadeFt_X]    Script Date: 15/04/2020 09:53:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[InsereNovaUnidadeFt_X] 
@IdUnidade int,
@ft_X int,
@ChaveValidada int,
@Operação bit

as
begin
insert into dbo.UnidadesGeral (idunidade,ft_x,chavevalidada,operação)
values (@IdUnidade,@ft_X,@ChaveValidada,@Operação)
End
GO

