USE [Base]
GO

/****** Object:  StoredProcedure [dbo].[Inserefabricante]    Script Date: 15/04/2020 09:52:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create procedure [dbo].[Inserefabricante] 
@Fabricante ntext

as
begin
insert into dbo.fabricantes (fabricante)
values (@Fabricante)
End
GO

