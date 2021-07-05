Public Class FrmStart

    Dim LqOficina As New LqOficinaDataContext
    Dim LqFinanceiro As New LqFinanceiroDataContext

    Public _IdVeiculo As Integer

    Public Sub CarregaDashboard()

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim LstDatas As New ListBox
        Dim LstEventos As New ListBox
        Dim LstHra As New ListBox

        Dim BuscaEvento = From eve In LqOficina.Vistorias
                          Where eve.IdVeiculo = _IdVeiculo
                          Select eve.NivelReq, eve.DataVistoria, eve.DataSolicitação, eve.DataInicioVistoria, eve.Concluido, eve.Recebida

        For Each row In BuscaEvento.ToList

            If row.Concluido = True Then

                LstDatas.Items.Add(row.DataSolicitação)
                LstEventos.Items.Add(row.NivelReq)

                LstDatas.Items.Add(row.DataInicioVistoria)
                LstEventos.Items.Add(row.NivelReq)

                LstDatas.Items.Add(row.DataVistoria)
                LstEventos.Items.Add(row.NivelReq)

            Else

                If row.DataInicioVistoria.Value <> "1111-11-11" Then

                    LstDatas.Items.Add(row.DataSolicitação)
                    LstEventos.Items.Add(row.NivelReq)

                    LstDatas.Items.Add(row.DataInicioVistoria)
                    LstEventos.Items.Add(row.NivelReq)

                Else

                    LstDatas.Items.Add(row.DataSolicitação)
                    LstEventos.Items.Add(row.NivelReq)

                End If

            End If

        Next

        ChTimeline.Series(0).Points.DataBindXY(LstDatas.Items, LstEventos.Items)
        'busca peçças solicitadas

        Dim BuscaProcessos0 = From desm In LqOficina.Vistorias
                              Where desm.IdVeiculo = _IdVeiculo And desm.NivelReq = 0
                              Select desm.IdVistoria

        'busca peçças solicitadas

        Dim BuscaProcessosDesmonte = From desm In LqOficina.Vistorias
                                     Where desm.IdVeiculo = _IdVeiculo And desm.NivelReq > 0 And desm.NivelReq < 3
                                     Select desm.IdVistoria

        For Each item0 In BuscaProcessosDesmonte.ToList
            'busca itens da vistoria

            Dim BuscaItemSolucao = From Sol In LqComercial.Orcamentos
                                   Where Sol.IdDesmonte = item0
                                   Select Sol.IdOrcamento, Sol.Aprovado

            For Each row In BuscaItemSolucao.ToList

                'busca itens do orcamento

                Dim BuscaOrcamento = From orc In LqComercial.ProdutosOrcamento
                                     Where orc.IdOrcamento = row.IdOrcamento And orc.Tipo = True
                                     Select orc.IdSolicitacao, orc.IdProduto, orc.Qtdade

                For Each row1 In BuscaOrcamento.ToList

                    If row1.IdProduto = 0 Then

                        'busca descricao

                        Dim BuscaSolicitacao = From ofi In LqOficina.SolicitacaoCadastroPeca
                                               Where ofi.IdSolicitacaoCadastro = row1.IdSolicitacao
                                               Select ofi.Descricao

                        'busca necessidade da peça

                        Dim BuscaNecessidade = From nec In LqOficina.SoluçõesVistoria
                                               Where nec.IdProcesso = item0
                                               Select nec.IdSolucoes

                        Dim BuscaSolução = From sol In LqOficina.ItensSoluçãoN
                                           Where sol.IdSolucao = BuscaNecessidade.First And sol.IdSolicitacao = row1.IdSolicitacao
                                           Select sol.NeessitaInicio, sol.Qt

                        If row.Aprovado = False Then

                            If BuscaSolicitacao.Count > 0 Then
                                If BuscaNecessidade.Count > 0 Then
                                    If BuscaSolução.Count > 0 Then

                                        DtLiberações.Rows.Add("S" & row1.IdSolicitacao, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aguardando aprovação do cliente.", My.Resources.Cancel_40972, My.Resources.alert_icon_icons_com_52395)

                                    End If
                                End If
                            End If

                        Else

                            'busca estoque

                            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                            Dim BuscaEstoque = From est In LqFinanceiro.Cotacoes
                                               Where est.IdSolicitacaoCad = row1.IdSolicitacao
                                               Select est.Comprado, est.ValorCotado

                            If BuscaEstoque.Count > 0 Then

                                If BuscaEstoque.First.Comprado = False Then

                                    If BuscaSolicitacao.Count > 0 Then
                                        If BuscaNecessidade.Count > 0 Then
                                            If BuscaSolução.Count > 0 Then

                                                DtLiberações.Rows.Add("S" & row1.IdSolicitacao, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Aguardando compra do item.", My.Resources.Cancel_40972, My.Resources.alert_icon_icons_com_52395)

                                            End If
                                        End If
                                    End If

                                Else

                                    If BuscaSolicitacao.Count > 0 Then
                                        If BuscaNecessidade.Count > 0 Then
                                            If BuscaSolução.Count > 0 Then

                                                DtLiberações.Rows.Add("S" & row1.IdSolicitacao, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Item comprado, aguardando entrada no estoque.", My.Resources.Cancel_40972, My.Resources.alert_icon_icons_com_52395)

                                            End If
                                        End If
                                    End If

                                End If

                            Else

                                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
                                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                                'busca solicitacao de cadastro

                                Dim BuscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                                               Where sol.IdSolicitacaoCadastro = row1.IdSolicitacao
                                               Select sol.IdCodCad

                                'busca estoque

                                Dim BuscaEstoque0 = From est In LqFinanceiro.Cotacoes
                                                    Where est.IdProduto = BuscaSol.First
                                                    Select est.Comprado, est.ValorCotado

                                If BuscaEstoque0.First.Comprado = False Then

                                    If BuscaSolicitacao.Count > 0 Then
                                        If BuscaNecessidade.Count > 0 Then
                                            If BuscaSolução.Count > 0 Then

                                                DtLiberações.Rows.Add(BuscaSol.First, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Aguardando compra do item.", My.Resources.Cancel_40972, My.Resources.alert_icon_icons_com_52395)

                                            End If
                                        End If
                                    End If

                                Else

                                    If BuscaSolicitacao.Count > 0 Then
                                        If BuscaNecessidade.Count > 0 Then
                                            If BuscaSolução.Count > 0 Then

                                                'busca item no estoque

                                                LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                                Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                                                       Where arm.IdProduto = BuscaSol.First
                                                                       Select arm.Qt

                                                If BuscaArmazenagem.Count > 0 Then

                                                    'verifica se qtdade é sufciente

                                                    If BuscaSolução.First.Qt >= BuscaArmazenagem.First Then

                                                        'verifica posicionamento do estoque

                                                        Dim BuscaSolicitacaoEstoque = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                                                      Where est.Destino Like "ORC_" & row.IdOrcamento
                                                                                      Select est.IdLiberador, est.Status, est.Ret

                                                        If BuscaSolicitacaoEstoque.First.IdLiberador = 0 Then

                                                            DtLiberações.Rows.Add(BuscaSol.First, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item disponivel, aguardando liberação do estoque.", My.Resources.check_ok_accept_apply_1582, My.Resources.alert_icon_icons_com_52395)

                                                        Else

                                                            If BuscaSolicitacaoEstoque.First.Ret = False Then

                                                                DtLiberações.Rows.Add(BuscaSol.First, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item disponivel, aguardando retirada no estoque.", My.Resources.check_ok_accept_apply_1582, My.Resources.cargo_1_icon)

                                                            Else

                                                                DtLiberações.Rows.Add(BuscaSol.First, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item retirado.", My.Resources.check_ok_accept_apply_1582, My.Resources.check_ok_accept_apply_1582)

                                                            End If

                                                        End If

                                                    Else

                                                        DtLiberações.Rows.Add(BuscaSol.First, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Estoque insuficiente.", My.Resources.alert_icon_icons_com_52395, My.Resources.alert_icon_icons_com_52395)

                                                    End If

                                                Else

                                                    DtLiberações.Rows.Add(BuscaSol.First, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Item comprado, aguardando entrada no estoque.", My.Resources.Cancel_40972, My.Resources.alert_icon_icons_com_52395)

                                                End If
                                            End If
                                        End If

                                    End If

                                End If

                            End If

                        End If

                    Else

                        'busca descricao

                        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        Dim BuscaSolicitacao = From ofi In LqBase.Produtos
                                               Where ofi.IdProduto = row1.IdProduto
                                               Select ofi.Descricao

                        'busca necessidade da peça

                        Dim BuscaNecessidade = From nec In LqOficina.SoluçõesVistoria
                                               Where nec.IdProcesso = item0
                                               Select nec.IdSolucoes

                        Dim BuscaSolução = From sol In LqOficina.ItensSoluçãoN
                                           Where sol.IdSolucao = BuscaNecessidade.First And sol.IdProduto = row1.IdProduto
                                           Select sol.NeessitaInicio, sol.Qt

                        If row.Aprovado = False Then

                            If BuscaSolicitacao.Count > 0 Then
                                If BuscaNecessidade.Count > 0 Then
                                    If BuscaSolução.Count > 0 Then

                                        DtLiberações.Rows.Add(row1.IdProduto, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aguardando aprovação do cliente.", My.Resources.Cancel_40972, My.Resources.alert_icon_icons_com_52395)

                                    End If
                                End If
                            End If

                        Else

                            'busca estoque

                            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                            Dim BuscaEstoque = From est In LqFinanceiro.Cotacoes
                                               Where est.IdProduto = row1.IdProduto
                                               Select est.Comprado, est.ValorCotado, est.IdComprador

                            If BuscaEstoque.First.IdComprador = 0 Then


                                If BuscaSolicitacao.Count > 0 Then
                                    If BuscaNecessidade.Count > 0 Then
                                        If BuscaSolução.Count > 0 Then

                                            DtLiberações.Rows.Add(row1.IdProduto, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Aguardando compra do item.", My.Resources.check_ok_accept_apply_1582, My.Resources.alert_icon_icons_com_52395)

                                        End If
                                    End If
                                End If


                                BttAvaliacaoComplementar.Enabled = True

                            Else

                                'Busca estoque

                                LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                Dim BuscaItemsEstoque = From est In LqEstoqueLocal.Armazenagem
                                                        Where est.IdProduto = row1.IdProduto
                                                        Select est.Qt

                                Dim _Qt As Integer = 0

                                For Each row2 In BuscaItemsEstoque.ToList

                                    _Qt += row2

                                Next

                                If _Qt >= row1.Qtdade Then


                                    If BuscaSolicitacao.Count > 0 Then
                                        If BuscaNecessidade.Count > 0 Then
                                            If BuscaSolução.Count > 0 Then

                                                DtLiberações.Rows.Add(row1.IdProduto, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Item comprado, aguardando retirada no estoque.", My.Resources.check_ok_accept_apply_1582, My.Resources.alert_icon_icons_com_52395)

                                            End If
                                        End If
                                    End If

                                    BttAvaliacaoComplementar.Enabled = True

                                    BttIniciarServiços.Enabled = True

                                Else


                                    If BuscaSolicitacao.Count > 0 Then
                                        If BuscaNecessidade.Count > 0 Then
                                            If BuscaSolução.Count > 0 Then

                                                DtLiberações.Rows.Add(row1.IdProduto, BuscaSolicitacao.First, BuscaSolução.First.NeessitaInicio, "Item aprovado. Item comprado, aguardando entrada no estoque.", My.Resources.check_ok_accept_apply_1582, My.Resources.alert_icon_icons_com_52395)

                                            End If
                                        End If
                                    End If

                                    BttAvaliacaoComplementar.Enabled = True

                                End If

                            End If

                        End If

                    End If

                Next

            Next

        Next

        'verifica se é possível começar os serviços

        For Each row As DataGridViewRow In DtLiberações.Rows

            If row.Cells(2).Value = False Then

                BttIniciarServiços.Enabled = True

            Else

                If row.Cells(3).Value.ToString = "Item retirado." Then

                    BttIniciarServiços.Enabled = True

                End If

            End If

        Next


    End Sub

    Public Sub CarregaInicioServico()

        Dim _Serviços As Integer = 0

        Dim TrPrc As TreeView = FrmReparoIniciado.TrItensAprovados

        'busca peçças solicitadas

        Dim BuscaProcessos0 = From desm In LqOficina.Vistorias
                              Where desm.IdVeiculo = _IdVeiculo And desm.NivelReq = 0
                              Select desm.IdVistoria

        'busca peçças solicitadas

        Dim BuscaProcessosDesmonte = From desm In LqOficina.Vistorias
                                     Where desm.IdVeiculo = _IdVeiculo And desm.NivelReq > 0 And desm.NivelReq < 3
                                     Select desm.IdVistoria

        For Each item0 In BuscaProcessosDesmonte.ToList

            'busca itens da vistoria

            Dim BuscaItemSolucao = From Sol In LqComercial.Orcamentos
                                   Where Sol.IdDesmonte = item0
                                   Select Sol.IdOrcamento, Sol.Aprovado

            For Each row In BuscaItemSolucao.ToList

                'insere produto 

                'busca itens do orcamento

                Dim BuscaOrcamento = From orc In LqComercial.ProdutosOrcamento
                                     Where orc.IdOrcamento = row.IdOrcamento And orc.Tipo = True
                                     Select orc.IdSolicitacao, orc.IdProduto, orc.Qtdade

                For Each row1 In BuscaOrcamento.ToList

                    If row1.IdProduto = 0 Then

                        'busca descricao

                        Dim BuscaSolicitacao = From ofi In LqOficina.SolicitacaoCadastroPeca
                                               Where ofi.IdSolicitacaoCadastro = row1.IdSolicitacao
                                               Select ofi.Descricao, ofi.IdCodCad

                        'busca necessidade da peça

                        Dim BuscaNecessidade = From nec In LqOficina.SoluçõesVistoria
                                               Where nec.IdProcesso = item0
                                               Select nec.IdSolucoes

                        Dim BuscaSolução = From sol In LqOficina.ItensSoluçãoN
                                           Where sol.IdSolucao = BuscaNecessidade.First And sol.IdSolicitacao = row1.IdSolicitacao
                                           Select sol.NeessitaInicio, sol.Qt

                        'insere o no

                        Dim BuscadescricaoCad = From cod In LqBase.Produtos
                                                Where cod.IdProduto = BuscaSolicitacao.First.IdCodCad
                                                Select cod.Descricao

                        TrPrc.Nodes.Add(BuscaSolicitacao.First.IdCodCad & " " & BuscadescricaoCad.First)

                        'adiciona detalhes da requisição

                        Dim TrDetPrd As TreeNode = TrPrc.Nodes(TrPrc.Nodes.Count - 1)

                        TrDetPrd.Nodes.Add("Qt solicitada. " & BuscaSolução.First.Qt)

                        'verifica serviços contratados

                        Dim BuscaSoluçãoServiços = From sol In LqOficina.ItensSoluçãoN
                                                   Where sol.IdSolucao = BuscaNecessidade.First And sol.Tipo = False
                                                   Select sol.NeessitaInicio, sol.Qt, sol.IdProduto

                        Dim TrDetServ As TreeNode = TrDetPrd.Nodes(TrDetPrd.Nodes.Count - 1)
                        TrDetServ.Nodes.Add("Serviços direcionados.")

                        For Each rowSrv In BuscaSoluçãoServiços.ToList

                            Dim BuscaServiços = From serv In LqBase.Servicos
                                                Where serv.IdServico = rowSrv.IdProduto
                                                Select serv.Descricao

                            TrDetServ.Nodes(0).Nodes.Add(BuscaServiços.First)
                            _Serviços += 1

                        Next

                        TrDetPrd.Expand()

                    Else

                        'busca descricao

                        Dim BuscaSolicitacao = From ofi In LqBase.Produtos
                                               Where ofi.IdProduto = row1.IdProduto
                                               Select ofi.Descricao

                        'busca necessidade da peça

                        Dim BuscaNecessidade = From nec In LqOficina.SoluçõesVistoria
                                               Where nec.IdProcesso = item0
                                               Select nec.IdSolucoes

                        Dim BuscaSolução = From sol In LqOficina.ItensSoluçãoN
                                           Where sol.IdSolucao = BuscaNecessidade.First And sol.IdProduto = row1.IdProduto
                                           Select sol.NeessitaInicio, sol.Qt


                    End If

                Next


            Next

        Next

        If _Serviços = 0 Then

            'insere proximo stagio

            LqOficina.InsereNovaVistoriaVeiculo(_IdVeiculo, _idCliente, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, True, 2, Now.TimeOfDay, Today.Date)

            FrmReparoIniciado.Fecha = True

        End If

    End Sub
    Dim LqBase As New DtCadastroDataContext
    Dim LqComercial As New LqComercialDataContext
    Dim LqEstoqueLocal As New LqEstoqueLocalDataContext

    Private Sub FrmStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaDashboard()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public _placa As String
    Public _modelo As String
    Public _idCliente As String

    Private Sub BttAvaliacaoComplementar_Click(sender As Object, e As EventArgs) Handles BttAvaliacaoComplementar.Click

        'insere vistoria nivel 1

        FrmNovoStudioAvaliacao._Placa = _placa

        FrmNovoStudioAvaliacao.LblPlacaN.Text = _placa & " - " & _modelo

        Dim BuscaProcesso = From conc In LqOficina.Vistorias
                            Where conc.Concluido = True And conc.NivelReq = 0 And conc.IdVeiculo = _IdVeiculo
                            Select conc.IdVistoria, conc.IdCliente

        'manda a informação da vistoria

        Dim BuscaProcessoDesmonte = From conc In LqOficina.Vistorias
                                    Where conc.Concluido = True And conc.NivelReq = 1 And conc.IdVeiculo = _IdVeiculo
                                    Select conc.IdVistoria, conc.IdCliente

        If BuscaProcessoDesmonte.Count > 0 Then

            'busca processo 

            Dim BuscaProcessoComplementar = From conc In LqOficina.Vistorias
                                            Where conc.NivelReq = 2 And conc.IdVeiculo = _IdVeiculo
                                            Select conc.IdVistoria, conc.IdCliente

            If BuscaProcessoComplementar.Count = 0 Then

                FrmNovoStudioAvaliacao.LblNumProcessoN.Text = BuscaProcesso.First.IdVistoria
                FrmNovoStudioAvaliacao.LblNumSoluçãoN.Text = BuscaProcessoDesmonte.First.IdVistoria

                FrmNovoStudioAvaliacao._IdVeiculo = _IdVeiculo
                FrmNovoStudioAvaliacao._IdCliente = BuscaProcesso.First.IdCliente

                FrmNovoStudioAvaliacao.LblStagio.Text = "Avaliação complementar"

                FrmNovoStudioAvaliacao.SelPrincipal = "Dianteira"
                FrmNovoStudioAvaliacao.BttCarregar.Enabled = True

                Dim BuscaModelo = From mode In LqOficina.Veiculos
                                  Where mode.IdVeiculo = _IdVeiculo
                                  Select mode.IdModelo

                FrmNovoStudioAvaliacao._idModeloVeic = BuscaModelo.First

                'busca imagens registradas


                Dim BuscaImages = From img In LqOficina.ImagemRespostaCklist
                                  Where img.IdProcesso = BuscaProcesso.First.IdVistoria
                                  Select img.Imagem, img.Titulo, img.IdImagemProcesso

                Dim TrRespostashecklist As TreeView = FrmNovoStudioAvaliacao.TrRespostashecklist

                For Each row In BuscaImages.ToList

                    TrRespostashecklist.Nodes.Add(row.IdImagemProcesso)

                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(145 + (128 * (TrRespostashecklist.Nodes.Count - 1)))
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(0)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add("MK")

                    'busca soluções 

                    Dim BuscaSolucao = From sol In LqOficina.MarcasImagens
                                       Where sol.IdImagem = row.IdImagemProcesso
                                       Select sol.IdMarcaImagem, sol.Descricao, sol.Cor, sol.X, sol.Y

                    'insere no treenode

                    Dim TrMarcas As TreeNode = TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2)

                    'insere macação

                    For Each item In BuscaSolucao.ToList

                        TrMarcas.Nodes.Add(item.descricao)

                        Dim TrMarcasPts As TreeNode = TrMarcas.Nodes(TrMarcas.Nodes.Count - 1)

                        TrMarcasPts.Nodes.Add("Pts")

                        Dim TrvalorePts As TreeNode = TrMarcasPts.Nodes(0)

                        TrvalorePts.Nodes.Add(item.X)
                        TrvalorePts.Nodes.Add(item.Y)

                        TrMarcasPts.Nodes.Add("Solução")
                        TrMarcasPts.Nodes.Add(item.Cor)
                        TrMarcasPts.Nodes.Add(item.IdMarcaImagem)

                        'busca solucao

                        Dim BuscaSolucaoMk = From sol In LqOficina.SoluçõesVistoria
                                             Where sol.IdMarca = item.IdMarcaImagem
                                             Select sol.IdSolucoes

                        Dim BuscaItemSolucao = From sol In LqOficina.ItensSoluçãoN
                                               Where sol.IdSolucao = BuscaSolucaoMk.First
                                               Select sol.IdItemSolucao, sol.Qt, sol.Tipo, sol.NeessitaInicio, sol.IdProduto, sol.IdSolicitacao


                        Dim TrSolucao As TreeNode = TrMarcasPts.Nodes(1)

                        TrSolucao.Nodes.Add("Produtos")

                        If BuscaSolucaoMk.Count > 0 Then

                            For Each item1 In BuscaItemSolucao.ToList

                                If item1.Tipo = True Then

                                    If item1.IdProduto = 0 Then

                                        TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Add("S" & item1.IdSolicitacao)

                                        'insere detalhes do item 

                                        Dim TrDetalhe As TreeNode = TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes(TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Count - 1)

                                        'busca Solicitacao

                                        Dim BuscaDescricaoDaSolicitacao = From sol In LqOficina.SolicitacaoCadastroPeca
                                                                          Where sol.IdSolicitacaoCadastro = item1.IdSolicitacao
                                                                          Select sol.Descricao, sol.PartNumber

                                        TrDetalhe.Nodes.Add(BuscaDescricaoDaSolicitacao.First.descricao)
                                        TrDetalhe.Nodes.Add(BuscaDescricaoDaSolicitacao.First.PartNumber)
                                        TrDetalhe.Nodes.Add(item1.Qt)
                                        TrDetalhe.Nodes.Add(item1.NeessitaInicio)

                                        'verifica se item foi aprovado no orçamento
                                        Dim BuscaAprovacao = From aprov In LqComercial.ProdutosOrcamento
                                                             Where aprov.IdSolicitacao = item1.IdSolicitacao
                                                             Select aprov.IdOrcamento

                                        Dim BuscaOrcamento = From orc In LqComercial.Orcamentos
                                                             Where orc.IdOrcamento = BuscaAprovacao.First
                                                             Select orc.Aprovado, orc.DataAprov

                                        If BuscaAprovacao.Count > 0 Then

                                            If BuscaOrcamento.Count > 0 Then

                                                If BuscaOrcamento.First.Aprovado = False Then

                                                    If BuscaOrcamento.First.DataAprov <> "1111-11-11" Then
                                                        TrDetalhe.Nodes.Add("Item recusado")
                                                    Else
                                                        TrDetalhe.Nodes.Add("Item em análise")
                                                    End If

                                                Else

                                                    TrDetalhe.Nodes.Add("Item aprovado")


                                                End If

                                            Else

                                                TrDetalhe.Nodes.Add("Item em análise")

                                            End If

                                        Else

                                            TrDetalhe.Nodes.Add("Item em análise")

                                        End If


                                    Else

                                        TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Add(item1.IdProduto)

                                        Dim TrDetalhe As TreeNode = TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes(TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Count - 1)

                                        'busca Solicitacao

                                        Dim BuscaDescricaoDoProduto = From sol In LqBase.Produtos
                                                                      Where sol.IdProduto = item1.IdProduto
                                                                      Select sol.Descricao, sol.CodFabricante

                                        TrDetalhe.Nodes.Add(BuscaDescricaoDoProduto.First.descricao)
                                        TrDetalhe.Nodes.Add(BuscaDescricaoDoProduto.First.CodFabricante)
                                        TrDetalhe.Nodes.Add(item1.Qt)
                                        TrDetalhe.Nodes.Add(item1.NeessitaInicio)

                                        'verifica se item foi aprovado no orçamento
                                        Dim BuscaAprovacao = From aprov In LqComercial.ProdutosOrcamento
                                                             Where aprov.IdProduto = item1.IdProduto
                                                             Select aprov.IdOrcamento

                                        Dim BuscaOrcamento = From orc In LqComercial.Orcamentos
                                                             Where orc.IdOrcamento = BuscaAprovacao.First
                                                             Select orc.Aprovado, orc.DataAprov

                                        If BuscaAprovacao.Count > 0 Then

                                            If BuscaOrcamento.Count > 0 Then

                                                If BuscaOrcamento.First.Aprovado = False Then

                                                    If BuscaOrcamento.First.DataAprov <> "1111-11-11" Then
                                                        TrDetalhe.Nodes.Add("Item recusado")
                                                    Else
                                                        TrDetalhe.Nodes.Add("Item em análise")
                                                    End If

                                                Else

                                                    TrDetalhe.Nodes.Add("Item aprovado")

                                                End If

                                            Else

                                                TrDetalhe.Nodes.Add("Item em análise")

                                            End If

                                        Else

                                            TrDetalhe.Nodes.Add("Item em análise")

                                        End If



                                    End If

                                End If

                            Next

                        End If

                        TrSolucao.Nodes.Add("Serviços")

                        If BuscaSolucaoMk.Count > 0 Then

                            For Each item1 In BuscaItemSolucao.ToList

                                If item1.Tipo = False Then

                                    'insere detalhes do item 

                                    TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Add(item1.IdProduto)

                                    Dim TrDetalhe As TreeNode = TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes(TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Count - 1)

                                    'busca Solicitacao

                                    Dim BuscaDescricaoDoProduto = From sol In LqBase.Servicos
                                                                  Where sol.IdServico = item1.IdProduto
                                                                  Select sol.Descricao, sol.EPIServico

                                    TrDetalhe.Nodes.Add(BuscaDescricaoDoProduto.First.Descricao)
                                    TrDetalhe.Nodes.Add(item1.Qt)

                                End If

                            Next

                        End If

                        TrSolucao.Nodes.Add(item.Cor)

                    Next

                    'divide texto

                    'publica login sugerido
                    Dim Contexto As String = row.Titulo

                    Dim str As String = Contexto
                    Dim separador As String = ","
                    Dim palavras As String() = str.Split(separador)
                    Dim LstPalavras As New ListBox
                    Dim palavra As String

                    For Each palavra In palavras
                        LstPalavras.Items.Add(palavra)
                    Next

                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(LstPalavras.Items(0).ToString)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(LstPalavras.Items(1).ToString)

                    FrmNovoStudioAvaliacao.SelPrincipal = LstPalavras.Items(0).ToString
                    FrmNovoStudioAvaliacao.SelText = LstPalavras.Items(1).ToString


                    Dim Cat As String = LstPalavras.Items(1).ToString

                    If Cat = "F.Parachoque" Then

                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VfrenteVetorParachoqueD

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "F.Capô" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VfrenteVetorCapo

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "F.Iluminação" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VFrenteIlum

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "F.Parabrisas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.vfrentepara

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "F.Retrovisores" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VFrenteRet

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "F.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VFrenteAcab

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Parachoque" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VtrasVetorParachoque

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Tampa traseira" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVetorTampaPortaMala

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Iluminação" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVetorLanterna

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVetorAcab

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Vidro traseiro" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVidro

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "L.E.Portas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqPortas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.E.Vidros" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqVidros

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "L.E.Estruturas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqEstrutura1

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.E.Paralamas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqParalamas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.E.Pneus" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqPneus

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.E.Rodas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqRodas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.E.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqAcabamentos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Portas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirPortas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Vidros" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirVidros

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "L.D.Estruturas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirEstrutura

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Paralamas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirParalamas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Pneus" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirPneus

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.D.Rodas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirRodas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.D.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirAcabamentos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "Acab. das Portas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorAcabPortas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Bancos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorBancos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRasgos.Visible = True
                        FrmNovoStudioAvaliacao.BtnManchas.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Console" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorConsole

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "Direção e comandos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorDireção

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Painel" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorPainel

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Porta malas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorPortaMalas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnRasgos.Visible = True
                        FrmNovoStudioAvaliacao.BtnManchas.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Acessórios" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessóriosAces

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Amortecedores" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosAmortecedores

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Partes elétricas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosEletricidade

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Sis. Exaustão" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosExaustão

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Sis. Frenagem" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosFreios

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Tracionamento e aliment." Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosMotor

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Estepe" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosStep

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Sis. Lubrificação" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosFluidos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Partes mecânicas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosParteMecanica1

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    End If


                    FrmNovoStudioAvaliacao.TrParentSel = TrRespostashecklist.Nodes.Count - 1

                Next

                'busca dados já avaliados

                FrmNovoStudioAvaliacao.Show(FrmPrincipal)

                FrmNovoStudioAvaliacao.HabilitaCampos()

                FrmNovoStudioAvaliacao.PintaMk()

                FrmNovoStudioAvaliacao.TrRespostashecklist.Visible = True

                Me.Cursor = Cursors.Arrow

            Else

                Dim BuscaProcessoComplementarR = From conc In LqOficina.Vistorias
                                                 Where conc.NivelReq > 0 And conc.IdVeiculo = _IdVeiculo
                                                 Select conc.IdVistoria, conc.IdCliente

                FrmNovoStudioAvaliacao.LblNumProcessoN.Text = BuscaProcesso.First.IdVistoria

                For Each rowdm In BuscaProcessoComplementarR.ToList

                    FrmNovoStudioAvaliacao.LblNumSoluçãoN.Text = rowdm.IdVistoria

                Next

                FrmNovoStudioAvaliacao._IdVeiculo = _IdVeiculo
                FrmNovoStudioAvaliacao._IdCliente = BuscaProcesso.First.IdCliente

                FrmNovoStudioAvaliacao.LblStagio.Text = "Avaliação complementar"

                FrmNovoStudioAvaliacao.SelPrincipal = "Dianteira"
                FrmNovoStudioAvaliacao.BttCarregar.Enabled = True

                Dim BuscaModelo = From mode In LqOficina.Veiculos
                                  Where mode.IdVeiculo = _IdVeiculo
                                  Select mode.IdModelo

                FrmNovoStudioAvaliacao._idModeloVeic = BuscaModelo.First

                'busca imagens registradas

                Dim BuscaImages = From img In LqOficina.ImagemRespostaCklist
                                  Where img.IdProcesso = BuscaProcesso.First.IdVistoria
                                  Select img.Imagem, img.Titulo, img.IdImagemProcesso

                Dim TrRespostashecklist As TreeView = FrmNovoStudioAvaliacao.TrRespostashecklist

                For Each row In BuscaImages.ToList

                    TrRespostashecklist.Nodes.Add(row.IdImagemProcesso)

                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(145 + (128 * (TrRespostashecklist.Nodes.Count - 1)))
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(0)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add("MK")

                    'busca soluções 

                    Dim BuscaSolucao = From sol In LqOficina.MarcasImagens
                                       Where sol.IdImagem = row.IdImagemProcesso
                                       Select sol.IdMarcaImagem, sol.Descricao, sol.Cor, sol.X, sol.Y

                    'insere no treenode

                    Dim TrMarcas As TreeNode = TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2)

                    'insere macação

                    For Each item In BuscaSolucao.ToList

                        TrMarcas.Nodes.Add(item.descricao)

                        Dim TrMarcasPts As TreeNode = TrMarcas.Nodes(TrMarcas.Nodes.Count - 1)

                        TrMarcasPts.Nodes.Add("Pts")

                        Dim TrvalorePts As TreeNode = TrMarcasPts.Nodes(0)

                        TrvalorePts.Nodes.Add(item.X)
                        TrvalorePts.Nodes.Add(item.Y)

                        TrMarcasPts.Nodes.Add("Solução")
                        TrMarcasPts.Nodes.Add(item.Cor)
                        TrMarcasPts.Nodes.Add(item.IdMarcaImagem)

                        'busca solucao

                        Dim BuscaSolucaoMk = From sol In LqOficina.SoluçõesVistoria
                                             Where sol.IdMarca = item.IdMarcaImagem And sol.IdSolucoes <> BuscaProcesso.First.IdVistoria
                                             Select sol.IdSolucoes

                        Dim TrSolucao As TreeNode = TrMarcasPts.Nodes(1)

                        TrSolucao.Nodes.Add("Produtos")

                        For Each item2 In BuscaSolucaoMk.ToList

                            Dim BuscaItemSolucao = From sol In LqOficina.ItensSoluçãoN
                                                   Where sol.IdSolucao = item2 And sol.Tipo = True
                                                   Select sol.IdItemSolucao, sol.Qt, sol.Tipo, sol.NeessitaInicio, sol.IdProduto, sol.IdSolicitacao

                            For Each item1 In BuscaItemSolucao.ToList

                                If item1.Tipo = True Then

                                    If item1.IdProduto = 0 Then

                                        TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Add("S" & item1.idsolicitacao)

                                        'insere detalhes do item 

                                        Dim TrDetalhe As TreeNode = TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes(TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Count - 1)

                                        'busca Solicitacao

                                        Dim BuscaDescricaoDaSolicitacao = From sol In LqOficina.SolicitacaoCadastroPeca
                                                                          Where sol.IdSolicitacaoCadastro = item1.idsolicitacao
                                                                          Select sol.Descricao, sol.PartNumber

                                        TrDetalhe.Nodes.Add(BuscaDescricaoDaSolicitacao.First.descricao)
                                        TrDetalhe.Nodes.Add(BuscaDescricaoDaSolicitacao.First.PartNumber)
                                        TrDetalhe.Nodes.Add(item1.Qt)
                                        TrDetalhe.Nodes.Add(item1.NeessitaInicio)


                                        'verifica se item foi aprovado no orçamento
                                        Dim BuscaAprovacao = From aprov In LqComercial.ProdutosOrcamento
                                                             Where aprov.IdSolicitacao = item1.idsolicitacao
                                                             Select aprov.IdOrcamento

                                        Dim BuscaOrcamento = From orc In LqComercial.Orcamentos
                                                             Where orc.IdOrcamento = BuscaAprovacao.First
                                                             Select orc.Aprovado, orc.DataAprov

                                        If BuscaAprovacao.Count > 0 Then

                                            If BuscaOrcamento.Count > 0 Then

                                                If BuscaOrcamento.First.Aprovado = False Then

                                                    If BuscaOrcamento.First.DataAprov <> "1111-11-11" Then
                                                        TrDetalhe.Nodes.Add("Item recusado")
                                                    Else
                                                        TrDetalhe.Nodes.Add("Item em análise")
                                                    End If

                                                Else

                                                    TrDetalhe.Nodes.Add("Item aprovado")


                                                End If

                                            Else

                                                TrDetalhe.Nodes.Add("Item em análise")

                                            End If

                                        Else

                                            TrDetalhe.Nodes.Add("Item em análise")

                                        End If


                                    Else

                                        TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Add(item1.IdProduto)

                                        Dim TrDetalhe As TreeNode = TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes(TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Count - 1)

                                        'busca Solicitacao

                                        Dim BuscaDescricaoDoProduto = From sol In LqBase.Produtos
                                                                      Where sol.IdProduto = item1.IdProduto
                                                                      Select sol.descricao, sol.CodFabricante

                                        TrDetalhe.Nodes.Add(BuscaDescricaoDoProduto.First.descricao)
                                        TrDetalhe.Nodes.Add(BuscaDescricaoDoProduto.First.CodFabricante)
                                        TrDetalhe.Nodes.Add(item1.Qt)
                                        TrDetalhe.Nodes.Add(item1.NeessitaInicio)

                                        'verifica se item foi aprovado no orçamento
                                        Dim BuscaAprovacao = From aprov In LqComercial.ProdutosOrcamento
                                                             Where aprov.IdProduto = item1.IdProduto And aprov.IdSolucao = item2
                                                             Select aprov.IdOrcamento

                                        Dim BuscaOrcamento = From orc In LqComercial.Orcamentos
                                                             Where orc.IdOrcamento = BuscaAprovacao.First
                                                             Select orc.Aprovado, orc.DataAprov

                                        If BuscaAprovacao.Count > 0 Then

                                            If BuscaOrcamento.Count > 0 Then

                                                If BuscaOrcamento.First.Aprovado = False Then

                                                    If BuscaOrcamento.First.DataAprov <> "1111-11-11" Then
                                                        TrDetalhe.Nodes.Add("Item recusado")
                                                    Else
                                                        TrDetalhe.Nodes.Add("Item em análise")
                                                    End If

                                                Else

                                                    TrDetalhe.Nodes.Add("Item aprovado")


                                                End If

                                            Else

                                                TrDetalhe.Nodes.Add("Item em análise")

                                            End If

                                        Else

                                            TrDetalhe.Nodes.Add("Item em análise")

                                        End If


                                    End If

                                End If

                            Next

                            For Each item1 In BuscaItemSolucao.ToList

                                If item1.Tipo = False Then

                                    'insere detalhes do item 

                                    TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Add(item1.IdProduto)

                                    Dim TrDetalhe As TreeNode = TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes(TrSolucao.Nodes(TrSolucao.Nodes.Count - 1).Nodes.Count - 1)

                                    'busca Solicitacao

                                    Dim BuscaDescricaoDoProduto = From sol In LqBase.Servicos
                                                                  Where sol.IdServico = item1.IdProduto
                                                                  Select sol.Descricao, sol.EPIServico

                                    TrDetalhe.Nodes.Add(BuscaDescricaoDoProduto.First.Descricao)
                                    TrDetalhe.Nodes.Add(item1.Qt)

                                End If

                            Next

                        Next

                        TrSolucao.Nodes.Add("Serviços")
                        TrSolucao.Nodes.Add("")

                        '0800 701 0180
                        '003204586937224

                    Next

                    'divide texto

                    'publica login sugerido
                    Dim Contexto As String = row.Titulo

                    Dim str As String = Contexto
                    Dim separador As String = ","
                    Dim palavras As String() = str.Split(separador)
                    Dim LstPalavras As New ListBox
                    Dim palavra As String

                    For Each palavra In palavras
                        LstPalavras.Items.Add(palavra)
                    Next

                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(LstPalavras.Items(0).ToString)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(LstPalavras.Items(1).ToString)

                    FrmNovoStudioAvaliacao.SelPrincipal = LstPalavras.Items(0).ToString
                    FrmNovoStudioAvaliacao.SelText = LstPalavras.Items(1).ToString


                    Dim Cat As String = LstPalavras.Items(1).ToString

                    If Cat = "F.Parachoque" Then

                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VfrenteVetorParachoqueD

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "F.Capô" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VfrenteVetorCapo

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "F.Iluminação" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VFrenteIlum

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "F.Parabrisas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.vfrentepara

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "F.Retrovisores" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VFrenteRet

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "F.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VFrenteAcab

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Parachoque" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VtrasVetorParachoque

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Tampa traseira" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVetorTampaPortaMala

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Iluminação" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVetorLanterna

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVetorAcab

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "T.Vidro traseiro" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VTrasVidro

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "L.E.Portas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqPortas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.E.Vidros" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqVidros

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "L.E.Estruturas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqEstrutura1

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.E.Paralamas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqParalamas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.E.Pneus" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqPneus

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.E.Rodas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqRodas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.E.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateEsqAcabamentos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Portas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirPortas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Vidros" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirVidros

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnVidroAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnVidroTrincado.Visible = True

                    ElseIf Cat = "L.D.Estruturas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirEstrutura

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Paralamas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirParalamas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRiscos.Visible = True
                        FrmNovoStudioAvaliacao.BtnAmassado.Visible = True
                        FrmNovoStudioAvaliacao.BtnCorrosão.Visible = True
                        FrmNovoStudioAvaliacao.BtnImpossívelReparar.Visible = True
                        FrmNovoStudioAvaliacao.BtnPeçaAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "L.D.Pneus" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirPneus

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.D.Rodas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirRodas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "L.D.Acabamentos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VLateDirAcabamentos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "Acab. das Portas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorAcabPortas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Bancos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorBancos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnRasgos.Visible = True
                        FrmNovoStudioAvaliacao.BtnManchas.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Console" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorConsole

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                    ElseIf Cat = "Direção e comandos" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorDireção

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Painel" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorPainel

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnPinturaDesbotada.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Porta malas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VInteriorVetorPortaMalas

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnAcabAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnAcabRisco.Visible = True
                        FrmNovoStudioAvaliacao.BtnRasgos.Visible = True
                        FrmNovoStudioAvaliacao.BtnManchas.Visible = True

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Acessórios" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessóriosAces

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Amortecedores" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosAmortecedores

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Partes elétricas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosEletricidade

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPEAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPEQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPESubstituição.Visible = True

                    ElseIf Cat = "Sis. Exaustão" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosExaustão

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Sis. Frenagem" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosFreios

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Tracionamento e aliment." Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosMotor

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Estepe" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosStep

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Sis. Lubrificação" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosFluidos

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    ElseIf Cat = "Partes mecânicas" Then
                        FrmNovoStudioAvaliacao.PicSel = My.Resources.VAcessoriosParteMecanica1

                        'desabilita campos

                        FrmNovoStudioAvaliacao.DesabilitaCampos()

                        'habilita campos

                        FrmNovoStudioAvaliacao.BtnPMAusente.Visible = True
                        FrmNovoStudioAvaliacao.BtnPMFalha.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmQuebrado.Visible = True
                        FrmNovoStudioAvaliacao.BtnPmSubst.Visible = True

                    End If


                    FrmNovoStudioAvaliacao.TrParentSel = TrRespostashecklist.Nodes.Count - 1

                Next

                'busca dados já avaliados

                FrmNovoStudioAvaliacao.Show(FrmPrincipal)

                FrmNovoStudioAvaliacao.HabilitaCampos()

                FrmNovoStudioAvaliacao.PintaMk()

                FrmNovoStudioAvaliacao.TrRespostashecklist.Visible = True

                Me.Cursor = Cursors.Arrow

            End If

        End If

        Dim BuscaultimaSol = From conc In LqOficina.Vistorias
                             Where conc.Concluido = False And conc.NivelReq = 2 And conc.IdVeiculo = _IdVeiculo
                             Select conc.IdVistoria, conc.IdCliente
                             Order By IdVistoria Descending

        If BuscaultimaSol.Count = 0 Then

            LqOficina.InsereNovaVistoriaVeiculo(_IdVeiculo, _idCliente, "1111-11-11", Today.TimeOfDay, FrmPrincipal.IdUsuario, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, False, 2, Today.TimeOfDay, "1111-11-11")

            Dim BuscaultimaSol2 = From conc In LqOficina.Vistorias
                                  Where conc.Concluido = False And conc.NivelReq = 2 And conc.IdVeiculo = _IdVeiculo
                                  Select conc.IdVistoria, conc.IdCliente
                                  Order By IdVistoria Descending

            FrmNovoStudioAvaliacao.LblNumSoluçãoN.Text = BuscaultimaSol2.First.IdVistoria

        Else

            FrmNovoStudioAvaliacao.LblNumSoluçãoN.Text = BuscaultimaSol.First.IdVistoria

        End If

    End Sub

    Private Sub DtLiberações_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellContentClick

        'If DtLiberações.Columns(e.ColumnIndex).Name = "ClmSolicitar" Then

        '    If DtLiberações.Rows(e.RowIndex).Cells(e.ColumnIndex - 2).Value.ToString = "Item disponivel para solicitar." Then

        '        If MsgBox("Item solicitado ao estoque.", vbOKOnly) = MsgBoxResult.Ok Then

        '            DtLiberações.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = My.Resources.check_ok_accept_apply_1582
        '            DtLiberações.Rows(e.RowIndex).Cells(e.ColumnIndex - 2).Value = "Item solicitado ao estoque."

        '        End If

        '    End If

        'End If

    End Sub

    Private Sub BttIniciarServiços_Click(sender As Object, e As EventArgs) Handles BttIniciarServiços.Click

        'carrega os itens vendidos

        CarregaInicioServico()

        'finaliza 

        FrmReparoIniciado.Show(FrmPrincipal)

        Me.Close()

    End Sub
End Class