Public Class Classe_Veiculos_Oficina

    Public Class Telefone
        Protected Property Numero As Integer
        Private Property Prefixo As String
        Public Discar As Boolean
        Public Sub New(ByVal Prefixo As String, ByVal Numero As Integer)
            Discar = True
        End Sub
    End Class

    Public Class Celular

        Public Property Discar As Boolean
        Public Property IndiceAgenda As Integer


        Public Sub New(ByVal IndiceAgenda As Integer)
            Discar = False
        End Sub

    End Class

    Public Class CodMun

        Public Property CodUf As String

    End Class

    Public Class Sintegra

        'Public Property CodUf As String

    End Class

    Public Class AnoFabMod

        Public Property fipe_codigo As String
        Public Property name As String
        Public Property key As String
        Public Property veiculo As String
        Public Property id As String

    End Class
    Public Class DetFabMod
        Public Property id As String
        Public Property ano_modelo As String
        Public Property marca As String
        Public Property name As String
        Public Property veiculo As String
        Public Property preco As String
        Public Property combustivel As String
        Public Property referencia As String
        Public Property fipe_codigo As String
        Public Property key As String

    End Class
    Public Class Trib
        Public Property ICMS As String

    End Class
    Public Class MarcasAPI_Veiculos
        Public Property name As String
        Public Property fipe_name As String
        Public Property order As String
        Public Property key As String
        Public Property id As String

    End Class
    Public Class ModelosAPI_Veiculos
        Public Property fipe_marca As String
        Public Property name As String
        Public Property marca As String
        Public Property key As String
        Public Property id As String

    End Class
    Public Class Veiculos
        Public Property IdSolicitacao As String
        Public Property Placa As String
        Public Property IdVeiculo As String
        Public Property IdCliente As String
        Public Property Tipo As String
        Public Property Status As String
        Public Property Modelo As String
        Public Property Fabricante As String
        Public Property DataInicio As String

    End Class

    Public Class ConsultaPedidoOnline
        Public Property Status As String
        Public Property NomeFornecedor As String
        Public Property Qtdade As String
        Public Property SubTotal As String
        Public Property Doc As String
        Public Property Cep As String
        Public Property Numero As String
        Public Property Logotipo As String

    End Class

    Public Class Orcamentos
        Public Property IdOrcamento As String
        Public Property Aprovacao As String
        Public Property Placa As String
        Public Property NomeCliente As String
        Public Property DataOrcamento As String
        Public Property ValorTotal As String
        Public Property IdVeiculo As String
        Public Property DataAprovacao As String
        Public Property DocCliente As String

    End Class
    Public Class ItemOrcamentos
        Public Property IdItemOrcamento As String
        Public Property IdItem As String
        Public Property Descricao As String
        Public Property Qt As String
        Public Property VlrUnit As String
        Public Property VlrDesconto As String
        Public Property SubTotal As String
        Public Property ImgProduto As String
        Public Property Aprovado As String
        Public Property TipoDoItem As String
        Public Property TipoDaAquisicao As String
        Public Property IdImagemAval As String

    End Class
    Public Class Produtos
        Public Property IdProdutoEst As String
        Public Property CodFabricante As String
        Public Property Descricao As String
        Public Property ChaveOficina As String
        Public Property FabricanteVeic As String
        Public Property ModeloVeic As String
        Public Property AnoFab As String
        Public Property AnoMod As String
        Public Property Categoria As String
        Public Property SubCAtegoria As String
        Public Property Fabricante As String
        Public Property IdProdutoInterno As Object
    End Class

    Public Class CatalogoOnLine
        Public Property Descricao As String
        Public Property Tipo As String
        Public Property Fabricante As String
        Public Property QtDisponivel As String
        Public Property Apelido As String
        Public Property PartNumber As Object
        Public Property ImgPrincipal As Object
        Public Property IdItem As Object
        Public Property ValorUnit As Object
        Public Property Prazo As Object
        Public Property ChaveOficina As Object

    End Class
    Public Class FormasPgAceitaOnline
        Public Property IdFormaPgAceitaOnline As String
        Public Property Descricao As String
        Public Property A_Vista As String
        Public Property Parcela As String
        Public Property TipoIntervalo As String
        Public Property Intervalo As String
        Public Property NumBanco As String
        Public Property Ag As String
        Public Property Conta As String
        Public Property TaxaTransacao As String
        Public Property Cartao As String
        Public Property TipoCartao As String
        Public Property Bandeira As String

    End Class
    Public Class BandeiraCartao
        Public Property name As String
        Public Property image_url As String

    End Class
    Public Class ConsultaPg
        Public Property Status As String

    End Class
    Public Class DadosFornecedor
        Public Property Doc As String
        Public Property FAntasia As String
        Public Property Razao As String
        Public Property inscricao As String
        Public Property Cep As String
        Public Property Numero As String
        Public Property Complemento As String
    End Class
    Public Class ItemPedido
        Public Property IdProdutoIntSol As String
        Public Property IdProdutoExt As String
        Public Property Qtdade As String
        Public Property VlrUnit As String
        Public Property DescricaoItem As String
        Public Property PartNumber As String

    End Class
    Public Class Expedicao
        Public Property ChaveOficina As String
        Public Property Status As String
        Public Property IdPedido As String
        Public Property Qtdade As String
        Public Property IdProdutoExt As String
        Public Property Descricao As String
        Public Property NomeCliente As String
        Public Property IdItemPedido As String
        Public Property DataSolicitacao As String
        Public Property HoraSolicitacao As String
        Public Property DataFinanceiroLib As String
        Public Property HoraFinanceiroLib As String
        Public Property DataEstoqueValidado As String
        Public Property HoraEstoqueValidado As String
        Public Property DataSeparacao As String
        Public Property HoraSeparacao As String
        Public Property DataColeta As String
        Public Property HoraColeta As String
        Public Property ChaveEntregador As String
        Public Property StatusColeta As String

    End Class
    Public Class PedidoProduto
        Public Property IdPedido As String

    End Class
    Public Class ColetaPedido
        Public Property ChavePrestador As String
        Public Property ChaveColeta As String
        Public Property IdColeta As String

    End Class
    Public Class TransacaoCartao
        Public Property CREATE As String
        Public Property OP As String

    End Class

    Public Class OrcamentoAprovado

            Public Property IdItemOrcamento As Object
            Public Property IdItem As Object
            Public Property Qt As Object

        End Class

        Public Class Bancos

            Public Property value As Object
            Public Property label As Object

        End Class
        Public Class Clientes
            Public Property NomeCliente As String
            Public Property IdClienteN As String
            Public Property email As String
            Public Property celular As String
            Public Property cep As String
            Public Property numero As String
            Public Property complemento As String
            Public Property Doc As String

        End Class

        Public Class Servicos
            Public Property IdServico As String
            Public Property Descricao As String
            Public Property TMA As String
            Public Property Ativo As String
            Public Property VlrSugerido As String

        End Class

        Public Class ImagensVeiculo
            Public Property Placa As String
            Public Property Fabricante As String
            Public Property Modelo As String
            Public Property Versao As String
            Public Property Chassi As String
            Public Property AnoMod As String
            Public Property Cor As String
            Public Property IdVeiculo As String
            Public Property IdImagemVeiculo As String
            Public Property Categoria As String
            Public Property Subcateogira As String
            Public Property IdCliente As String
            Public Property lcl_arq As String
            Public Property ImgFim As String
            Public Property IdSolicitacao As String

        End Class

        Public Class Laudos

            Public Property IdLaudo As String
            Public Property NomeCliente As String
            Public Property Doc As String
            Public Property DataSolicitacao As String
            Public Property HoraSolicitacao As String
            Public Property ChaveOficina As String
            Public Property PlacaVeiculo As String
            Public Property ModeloVeiculo As String

        End Class

        Public Class ItemsLaudos

            Public Property DescricaoItem As String
            Public Property ImgPcUsadaUrl As String
            Public Property ImgPcNovaUrl As String
            Public Property NumNf As String
            Public Property ItemNF As String
            Public Property IdItemLaudo As String
            Public Property IdFornecedor As String

        End Class

        Public Class LaudosEncontrados

            Public Property IdLaudo As String
            Public Property Status As String
            Public Property ChaveOficina As String
            Public Property ChavePrestador As String

        End Class

        Public Class ImagemNF

            Public Property ImagemNF As String

        End Class

        Public Class Review

            Public Property DataSolicitacao As String
            Public Property HoraSolicitacao As String

        End Class

        Public Class DadosUsuario

            Public Property NomeCompleto As String
            Public Property UrlImagem As String
            Public Property Cargo As String

        End Class

        Public Class Funcoes

            Public Property DescricaoFuncao As String
            Public Property RemuneracaoPaga As String
            Public Property IdFuncao As String
            Public Property IdVinculoFuncao As String

        End Class

        Public Class Colaboradores
            Public Property IdUsuario As String
            Public Property ChaveOficina As String
            Public Property NomeCompleto As String
            Public Property Celular As String
            Public Property email As String
            Public Property Cargo As String
            Public Property IdVinculoExt As String
            Public Property Documento As String
            Public Property UrlImagem As String
            Public Property User As String
            Public Property Pass As String

        End Class

        Public Class Create
            Public Property Create As String
            Public Property Id As String

        End Class

        Public Class UsuariosColetados
            Public Property NomeCompleto As String
            Public Property Documento As String
            Public Property User As String
            Public Property Pass As String
            Public Property Celular As String
            Public Property email As String
            Public Property Cargo As String
            Public Property IdUsuario As String

        End Class

        Public Class CarMake
            Public Property CurrentTextValue As String
        End Class

        Public Class DadosVeiculo
            Public Property Modelo As String
            Public Property Ano As String
            Public Property Chassi As String
            Public Property Fuel As String
            Public Property Colour As String
            Public Property Type As String
            Public Property EngineCC As String
            Public Property Power As String
        Public Property ImageUrl As String
        Public Property Location As String
        Public Property CarMake As CarMake
        End Class

        Public Class ItensEncontrados
            Public Property IdItem As String
            Public Property Qt As String

        End Class

        Public Class SubCategorias
            Public Property IdSubCategoriaProduto As String
            Public Property Descricao As String

        End Class

        Public Class Fabricantes
            Public Property IdItem As String
            Public Property Qt As String

        End Class

    Public Class SolicitacaoCadExt
        Public Property IdSolicitacaoCotacao As String
        Public Property VlrUnit As String
        Public Property DataSolicitacaoCotacao As String
        Public Property HoraSolicitacaoCotacao As String
        Public Property DataCotacao As String
        Public Property HoraCotacao As String
        Public Property IdProdutoInterno As String
        Public Property IdItem As String

    End Class

End Class
