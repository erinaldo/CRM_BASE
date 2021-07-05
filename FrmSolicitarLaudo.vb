Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports Newtonsoft.Json
Imports PdfSharp.Drawing

Public Class FrmSolicitarLaudo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public IdSolicitacao As Integer

    Private Sub BttOk_Click(sender As Object, e As EventArgs) Handles BttOk.Click

        'solicita no servidor externo, o backup vai fazer o restante

        If CkUsarInterna.Enabled = False Then

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim IdSolicitacaoReq As Integer = FrmLaudosSolicitados.DtFornecedores.SelectedCells(2).Value
            Dim BuscaSolicitacaoVeiculo = From sol In LqOficina.ImagemVeiculosColetado
                                          Where sol.IdSolicitacao = IdSolicitacaoReq
                                          Select sol.IdVeiculo

            'esse código será exterminado da equação quando a escolha for habilitada

            Dim baseUrl As String = "http://www.iarasoftware.com.br/cria_nova_engenharia.php?NomeRazao=" & FrmPrincipal.RazaoSocial & "&CPF_CNPJ=" & FrmPrincipal.CNPJ & "&CREA=" & "INT.TESTE" & "&Status=0&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            'insere a solicitacao do laudo

            Dim BuscaDadosVeiculo = From veic In LqOficina.Veiculos
                                    Where veic.IdVeiculo = BuscaSolicitacaoVeiculo.First
                                    Select veic.Placa, veic.Modelo

            Dim baseUrlSolicitaLaudo As String = "http://www.iarasoftware.com.br/cria_solicitacao_laudo_engenharia.php?ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdUsuarioSol=" & FrmPrincipal.IdUsuario & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString & "&DataEntrega=1111-11-11&HoraEntrega=00:00:00&IdSolicitacaoInt=" & IdSolicitacao & "&Status=0&PlacaVeiculo=" & BuscaDadosVeiculo.First.Placa & "&ModeloVeiculo=" & BuscaDadosVeiculo.First.Modelo

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientSolicitaLaudo = New WebClient()
            Dim contentSolicitaLaudo = syncClientSolicitaLaudo.DownloadString(baseUrlSolicitaLaudo)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Laudos))(contentSolicitaLaudo)

            Dim IdLaudoEnc As Integer = 0

            For Each row In read.ToList

                IdLaudoEnc = row.IdLaudo

            Next

            'insere os itens

            Me.Cursor = Cursors.WaitCursor

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            'Try

            Dim _IdVeiculo As Integer = BuscaSolicitacaoVeiculo.First

            'Cria um documento PDF

            Dim IdVeiculoFind As Integer = FrmLaudosSolicitados.DtFornecedores.SelectedCells(7).Value

            Dim Buscaveiculo = From veic In LqOficina.Veiculos
                               Where veic.IdVeiculo = IdVeiculoFind
                               Select veic.IdCliente

            Dim BuscaCliente = From veic In LqBase.Clientes
                               Where veic.IdClienteExt = Buscaveiculo.First
                               Select veic.RazaoSocial_nome

            'busca a imagem frontal para o veiculo

            Dim BuscaImagemFrontalVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                            Where veic.Descricao Like "Frontal - Principal" And veic.IdVeiculo = _IdVeiculo
                                            Select veic.ImagemColetado, veic.IdVeiculo, veic.IdSolicitacao


            If BuscaImagemFrontalVeiculo.Count > 0 Then

                Dim buscaSolucao = From sol In LqOficina.ImagemVeiculosColetado
                                   Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Frontal - Avaliacao"
                                   Select sol.ImagemColetado, sol.IdImagemColetada, sol.idImagemColetadaExt

                Dim buscaSolucaoComplementar = From sol In LqOficina.ImagemVeiculosColetado
                                               Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Frontal - Complementar"
                                               Select sol.ImagemColetado, sol.IdImagemColetada, sol.idImagemColetadaExt


                For Each row In buscaSolucao.ToList

                    Dim BuscaImagensSol = From sol In LqOficina.ImagemVeiculosColetado
                                          Where sol.Descricao Like "IMG_FT_PECA_NOVA - " & row.idImagemColetadaExt
                                          Select sol.ImagemColetado, sol.ImagemColetadoUrlFim, sol.ImagemColetadoUrl


                    For Each rowImg In BuscaImagensSol.ToList

                        'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))

                        Dim BuscaImagensSolUs = From sol In LqOficina.ImagemVeiculosColetado
                                                Where sol.Descricao Like "IMG_FT_PECA_USADA - " & row.idImagemColetadaExt
                                                Select sol.ImagemColetado, sol.ImagemColetadoUrlFim, sol.ImagemColetadoUrl, sol.IdSolicitacao

                        'busca a referecia no orcamento

                        Dim LqComercial As New LqComercialDataContext
                        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                        Dim BuscaComercial = From com In LqComercial.ProdutosOrcamento
                                             Where com.IdImagemAval = row.idImagemColetadaExt And com.Tipo = True
                                             Select com.IdProduto, com.IdSolicitacao, com.IdOrcamento

                        'verifica se a imagem foi vinculada

                        'senão, cria vinculo

                        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                        Dim BuscaSolicitacao = From sol In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                               Where sol.Destino Like "ORC_" & BuscaComercial.First.IdOrcamento And sol.IdProduto = BuscaComercial.First.IdProduto
                                               Select sol.IdSolicitacao

                        Dim BuscaSolicitacaoPagaEstoque = From est In LqEstoqueLocal.BaixaEndereco
                                                          Where est.IdSolicitacao = BuscaSolicitacao.First
                                                          Select est.NumNf

                        Dim _NumNF As String = BuscaSolicitacaoPagaEstoque.First

                        'busca o produto

                        Dim BuscaIdProduto = From prod In LqBase.Produtos
                                             Where prod.IdProduto = BuscaComercial.First.IdProduto
                                             Select prod.Descricao

                        Dim _Descricao As String

                        If BuscaIdProduto.Count = 0 Then

                            'busca Solicitacaocadastro

                            Dim BuscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                                           Where sol.IdSolicitacaoCadastro = BuscaComercial.First.IdSolicitacao
                                           Select sol.Descricao

                            _Descricao = BuscaSol.First

                        Else
                            _Descricao = BuscaIdProduto.First

                        End If

                        'insere o item no laudo

                        'busca item nf não utilizado


                        'insere a solicitacao do laudo

                        Dim Identificador As String

                        If BuscaComercial.First.IdProduto = 0 Then

                            Identificador = "S" & BuscaComercial.First.IdSolicitacao

                        Else

                            Identificador = BuscaComercial.First.IdProduto

                        End If

                        Dim baseUrlItemSolicitaLaudo As String = "http://www.iarasoftware.com.br/cria_item_laudo.php?IdProdutoOrcamento=" & Identificador & "&DescricaoItem=" & _Descricao & "&Status=0&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChavePrestador=" & FrmPrincipal.LblChaveEnc.Text & "&IdLaudo=" & IdLaudoEnc & "&ImgPcUsadaUrl=" & rowImg.ImagemColetadoUrl & "&ImgPcNovaUrl=" & BuscaImagensSolUs.First.ImagemColetadoUrl & "&NumNf=" & _NumNF & "&ItemNF=0"

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientItemSolicitaLaudo = New WebClient()
                        Dim contentItemSolicitaLaudo = syncClientItemSolicitaLaudo.DownloadString(baseUrlItemSolicitaLaudo)

                    Next

                Next

            End If

        End If

        Me.Cursor = Cursors.Arrow

        'cria solicitações internas

        FrmLaudosSolicitados.DtFornecedores.SelectedCells(3).Value = FrmLaudosSolicitados.ImageList2.Images(6)
        FrmLaudosSolicitados.DtFornecedores.SelectedCells(4).Value = FrmLaudosSolicitados.ImageList2.Images(3)

        Me.Close()

    End Sub

    Private Sub CkUsarInterna_CheckedChanged(sender As Object, e As EventArgs) Handles CkUsarInterna.CheckedChanged

        If CkUsarInterna.Checked = True Then

            DtFornecedores.Enabled = False

            BttOk.Enabled = True

        Else

            DtFornecedores.Enabled = True

            BttOk.Enabled = False

        End If

    End Sub
End Class