Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports Newtonsoft.Json

Public Class FrmComercial
    Private Sub PicNovoOrçamento_Click(sender As Object, e As EventArgs)

        FrmNovoORçamento.Show(Me)

    End Sub

    Dim LqComercial As New LqComercialDataContext

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'gera cave ddo oramento

        LqComercial.InsereNovoOrcamento(FrmPrincipal.IdUsuario, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, FrmPrincipal.IdCliente, 0, False, "11-11-1111", Today.TimeOfDay, 0, 0, 0, 0, False, False, 0, "1111-11-11")

        'ubsca ultimo valor

        Dim BuscaUlttimoID = From Cod In LqComercial.Orcamentos
                             Where Cod.IdOrcamento Like "*" And Cod.IdSolicitante = FrmPrincipal.IdUsuario
                             Select Cod.IdOrcamento
                             Order By IdOrcamento Descending

        FrmNovoORçamento.LblNumOrcamento.Text = BuscaUlttimoID.First

        FrmNovoORçamento.Show(Me)

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Dim LqOficina As New LqOficinaDataContext

    Private Sub FrmComercial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        VerificaInicio()

    End Sub

    Public Sub VerificaInicio()

        'busca orcamentos abertos 

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_orcamento_aberto_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Try

            'Dim arquivoJson = JObject.Parse(content)

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(Classe_Veiculos_Oficina.Orcamentos))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), Classe_Veiculos_Oficina.Orcamentos)

                'Return weatherData
            End Using
        Catch ex As Exception
            Throw ex
        End Try

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Orcamentos))(content)

        Dim Aprovados As Integer = 0
        Dim Perdido As Integer = 0
        Dim Aberto As Integer = 0

        Dim OrcFin As Integer
        Dim OrcPen As Integer
        Dim OrcPer As Integer

        For Each row In read.ToList

            Dim Aprovacao As String

            Dim DateFormated As Date
            Dim IncioMes As Date = "01/" & Today.Month & "/" & Today.Year

            Try
                DateFormated = row.DataOrcamento

                If row.Aprovacao = 1 Then
                    Aprovacao = "Aguardando posição do cliente"
                    Aberto += 1
                ElseIf row.Aprovacao = 0 Then
                    If DateFormated >= IncioMes Then
                        Aprovacao = "Orçamento aprovado"
                        Aprovados += 1
                    End If
                ElseIf row.Aprovacao = 2 Then
                    Aprovacao = "Orçamento recusado"
                    Perdido += 1
                End If

            Catch ex As Exception
                DateFormated = "11/11/1111"
            End Try

            Dim DataControle As Date = "11/11/1111"

            If DateFormated > DataControle Then

                If DateFormated >= IncioMes Then
                    DtCotFinal.Rows.Add(row.IdOrcamento, "", "Veículo.: " & row.Placa.ToUpper & " / Nome do cliente.: " & row.NomeCliente, FormatDateTime(DateFormated.ToShortDateString, DateFormat.ShortDate), Aprovacao, FormatCurrency(row.ValorTotal.Replace(".", ","), NumDigitsAfterDecimal:=2))
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen

                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Visible = False

                End If

            End If

        Next

        Dim SemMarkup As Integer = 0

        'insere no grid

        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                             Where orc.IdOrcamento Like "*"
                             Select orc.IdOrcamento, orc.IdCliente, orc.DataOrc, orc.Aprovado, orc.DataAprov, orc.DataSol, orc.IdVeiculo

        For Each row In BuscaOrçamento.ToList

            Dim HJ As Date = Today

            Dim Cotado As Integer = 0
            Dim NCotado As Integer = 0
            Dim Estoque As Integer = 0

            'busca cliente

            Dim BuscaCLiente = From cli In LqBase.Clientes
                               Where cli.IdCliente = row.IdCliente
                               Select cli.RazaoSocial_nome

            Dim ValorORc As Decimal = 0
            Dim _Versao As Integer = 0
            Dim _DataOrc As Date = "1111-11-11"

            Dim BuscaProdutos = From orc In LqComercial.ProdutosOrcamento
                                Where orc.IdOrcamento = row.IdOrcamento
                                Select orc.Tipo, orc.IdProduto, orc.IdSolicitacao, orc.ValorUnit, orc.DescontoUnit, orc.IdProdutoOrcamento, orc.Qtdade, orc.Versao, orc.DataVersao
                                Order By Versao Ascending

            Dim _ClienteCarr As String = 0

            If BuscaCLiente.Count > 0 Then
                _ClienteCarr = BuscaCLiente.First
            Else
                _ClienteCarr = "Não identificado"
            End If

            'BuscaUltimaVersao

            For Each row1 In BuscaProdutos.ToList

                If _Versao <> row1.Versao Then

                    ValorORc = 0
                    _Versao = row1.Versao
                    _DataOrc = row1.DataVersao

                    Cotado = 0
                    NCotado = 0
                    Estoque = 0

                End If

            Next

            Dim BuscaProdutosV = From orc In LqComercial.ProdutosOrcamento
                                 Where orc.IdOrcamento = row.IdOrcamento And orc.Versao = _Versao
                                 Select orc.Tipo, orc.IdProduto, orc.IdSolicitacao, orc.ValorUnit, orc.DescontoUnit, orc.IdProdutoOrcamento, orc.Qtdade, orc.Versao, orc.DataVersao

            Dim Produtos_0 As Integer = 0
            Dim Servicos_0 As Integer = 0

            Dim NenhumProduto As String = "Sem Produtos"

            If BuscaProdutos.Count > 0 Then
                NenhumProduto = "CC"
            End If

            For Each row1 In BuscaProdutosV.ToList

                If row1.Tipo = True Then

                    'Verifica se não existem outras cotaçoes mais recentes

                    Produtos_0 += 1

                    If row1.ValorUnit = 0 Then

                        'busca cotação

                        If row1.IdSolicitacao <> 0 Then

                            'verifica se item foi cotado

                            Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                                   Where sol.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                   Select sol.IdCodCad, sol.Markup

                            Dim IdProduto As Integer

                            If BuscaSolicitação.Count > 0 Then

                                If BuscaSolicitação.First.IdCodCad > 0 Then

                                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                        Where cot.IdProduto = BuscaSolicitação.First.IdCodCad
                                                        Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                        Order By DataCotacao Descending

                                    If BuscaCotações.Count > 0 Then

                                        If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                                            Dim _Markup As Decimal = BuscaCotações.First.Markup
                                            'verifica se o produto possui markup

                                            If _Markup = 0 Then
                                                Dim BuscaMarkup = From mkp In LqBase.Produtos
                                                                  Where mkp.IdProduto = BuscaSolicitação.First.IdCodCad
                                                                  Select mkp.Markup

                                                If BuscaMarkup.First > 0 Then

                                                    _Markup = BuscaMarkup.First

                                                    'atualiza markup da cotaçao

                                                    LqFinanceiro.AtualizaMarkupCotacaoProdutos(BuscaSolicitação.First.IdCodCad, 0, _Markup)

                                                End If
                                            End If

                                            'atualiza valor do orçamento

                                            LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, BuscaSolicitação.First.IdCodCad, row1.IdSolicitacao, BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * _Markup))

                                            '

                                            Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (_Markup / 100))

                                            If BuscaCotações.First.Markup = 0 Then

                                                SemMarkup += 1
                                                VlrVenda = 0

                                            End If

                                            ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                            If BuscaCotações.First.Markup = 0 Then

                                                SemMarkup += 1

                                            End If

                                            Cotado += 1

                                        Else

                                            NCotado += 1

                                        End If

                                    Else

                                        NCotado += 1

                                    End If

                                Else

                                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                        Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                        Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                        Order By DataCotacao Descending

                                    If BuscaCotações.Count > 0 Then

                                        If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                                            Dim _Markup As Decimal = BuscaCotações.First.Markup
                                            'verifica se o produto possui markup

                                            If _Markup = 0 Then
                                                Dim BuscaMarkup = From mkp In LqOficina.SolicitacaoCadastroPeca
                                                                  Where mkp.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                  Select mkp.Markup

                                                If BuscaMarkup.First > 0 Then

                                                    _Markup = BuscaMarkup.First

                                                    'atualiza markup da cotaçao

                                                    LqFinanceiro.AtualizaMarkupCotacaoProdutos(0, row1.IdSolicitacao, _Markup)

                                                End If

                                            End If

                                            'atualiza valor do orçamento

                                            LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, BuscaSolicitação.First.IdCodCad, row1.IdSolicitacao, BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * BuscaCotações.First.Markup))

                                            '
                                            Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                            If BuscaCotações.First.Markup = 0 Then

                                                SemMarkup += 1
                                                VlrVenda = 0

                                            End If

                                            ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                            Cotado += 1

                                        Else

                                            NCotado += 1

                                        End If

                                    Else

                                        NCotado += 1

                                    End If

                                End If

                            Else

                                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                    Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                    Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                    Order By DataCotacao Descending

                                If BuscaCotações.Count > 0 Then

                                    Dim buscaValidade As Date = BuscaCotações.First.DataCotacao.Value.Date.AddDays(7)

                                    If buscaValidade >= HJ Then

                                        'atualiza valor do orçamento

                                        Dim _Markup As Decimal = BuscaCotações.First.Markup
                                        'verifica se o produto possui markup

                                        If _Markup = 0 Then
                                            Dim BuscaMarkup = From mkp In LqOficina.SolicitacaoCadastroPeca
                                                              Where mkp.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                              Select mkp.Markup

                                            If BuscaMarkup.First > 0 Then

                                                _Markup = BuscaMarkup.First

                                                'atualiza markup da cotaçao

                                                LqFinanceiro.AtualizaMarkupCotacaoProdutos(0, row1.IdSolicitacao, _Markup)

                                            End If

                                        End If

                                        LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, row1.IdProduto, row1.IdSolicitacao, BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * _Markup))

                                        '
                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (_Markup / 100))

                                        If _Markup = 0 Then

                                            SemMarkup += 1

                                            VlrVenda = 0

                                        End If

                                        ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                        Cotado += 1

                                    Else

                                        NCotado += 1

                                    End If

                                Else

                                    NCotado += 1

                                End If

                            End If

                        Else

                            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                Where cot.IdProduto = row1.IdProduto
                                                Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                Order By DataCotacao Descending

                            If BuscaCotações.Count > 0 Then

                                Dim _Markup As Decimal = BuscaCotações.First.Markup
                                'verifica se o produto possui markup

                                If _Markup = 0 Then
                                    Dim BuscaMarkup = From mkp In LqBase.Produtos
                                                      Where mkp.IdProduto = row1.IdProduto
                                                      Select mkp.Markup

                                    If BuscaMarkup.First > 0 Then

                                        _Markup = BuscaMarkup.First

                                        'atualiza markup da cotaçao

                                        LqFinanceiro.AtualizaMarkupCotacaoProdutos(row1.IdProduto, 0, _Markup)

                                    End If
                                End If

                                If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                                    'atualiza valor do orçamento

                                    LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, row1.IdProduto, row1.IdSolicitacao, BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (_Markup / 100)))

                                    '
                                    Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (_Markup / 100))

                                    If _Markup = 0 Then

                                        SemMarkup += 1
                                        VlrVenda = 0

                                    End If

                                    ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                    Cotado += 1

                                Else

                                    NCotado += 1

                                End If

                            Else

                                NCotado += 1

                            End If

                        End If

                    Else

                        Dim VlrNew As Decimal = 0

                        If row1.IdSolicitacao <> 0 Then

                            'verifica se item foi cotado

                            Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                                   Where sol.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                   Select sol.IdCodCad, sol.Markup

                            Dim IdProduto As Integer

                            If BuscaSolicitação.Count > 0 Then

                                If BuscaSolicitação.First.IdCodCad <> 0 Then

                                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                        Where cot.IdProduto = BuscaSolicitação.First.IdCodCad
                                                        Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                        Order By DataCotacao Descending

                                    If BuscaCotações.Count > 0 Then

                                        'atualiza valor do orçamento
                                        '
                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                        Cotado += 1

                                        If BuscaCotações.First.Markup = 0 Then

                                            SemMarkup += 1
                                            VlrVenda = 0

                                        End If

                                        VlrNew = (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                    End If

                                Else

                                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                        Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                        Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                        Order By DataCotacao Descending

                                    If BuscaCotações.Count > 0 Then

                                        'atualiza valor do orçamento
                                        '

                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                        Cotado += 1

                                        If BuscaCotações.First.Markup = 0 Then

                                            SemMarkup += 1
                                            VlrVenda = 0

                                        End If

                                        VlrNew = (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                    End If

                                End If

                            Else

                                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                    Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                    Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                    Order By DataCotacao Descending

                                If BuscaCotações.Count > 0 Then

                                    Dim buscaValidade As Date = BuscaCotações.First.DataCotacao.Value.Date.AddDays(7)

                                    If buscaValidade >= HJ Then

                                        'atualiza valor do orçamento

                                        '
                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                        Cotado += 1

                                        If BuscaCotações.First.Markup = 0 Then

                                            SemMarkup += 1
                                            VlrVenda = 0

                                        End If

                                        VlrNew = (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                    End If

                                End If

                            End If

                        Else

                            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                Where cot.IdProduto = row1.IdProduto
                                                Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                Order By DataCotacao Descending

                            If BuscaCotações.Count > 0 Then

                                If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                                    'atualiza valor do orçamento
                                    '

                                    Cotado += 1

                                    Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                    If BuscaCotações.First.Markup = 0 Then

                                        SemMarkup += 1
                                        VlrVenda = 0

                                    End If

                                    VlrNew = (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                End If

                            End If

                        End If

                        'atualiza valor do orçamento

                        If VlrNew <= row1.ValorUnit Then

                            ValorORc += (VlrNew * row1.Qtdade) - ((VlrNew * (row1.DescontoUnit / 100)) * row1.Qtdade)

                        Else

                            ValorORc += (row1.ValorUnit * row1.Qtdade) - ((row1.ValorUnit * (row1.DescontoUnit / 100)) * row1.Qtdade)

                        End If

                    End If

                Else

                    If row1.ValorUnit = 0 Then

                        Servicos_0 += 1

                        'Verifica 

                        'busca valor do serviço

                        Dim BuscaServico = From serv In LqBase.Servicos
                                           Where serv.IdServico = row1.IdProduto 'And serv.Markup > 0
                                           Select serv.VlrVeda, serv.TME

                        If BuscaServico.Count > 0 Then

                            ValorORc += ((BuscaServico.First.VlrVeda / 220) * row1.Qtdade) - (((BuscaServico.First.VlrVeda / 220) * (row1.DescontoUnit / 100)) * row1.Qtdade)

                        Else

                            'solicita ao financeiro

                            LqFinanceiro.InsereNovaSolicitacaoMarkup(row1.IdProduto, row1.Tipo, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, "1111-11-11", Today.TimeOfDay, False)

                        End If

                    Else


                        Servicos_0 += 1

                        'busca valor do serviço

                        Dim BuscaServico = From serv In LqBase.Servicos
                                           Where serv.IdServico = row1.IdProduto
                                           Select serv.VlrVeda, serv.TME

                        If BuscaServico.Count > 0 Then

                            ValorORc += ((BuscaServico.First.VlrVeda / 220) * row1.Qtdade) - (((BuscaServico.First.VlrVeda / 220) * (row1.DescontoUnit / 100)) * row1.Qtdade)

                        End If

                    End If

                End If

            Next

            If row.Aprovado = False Then

                If Produtos_0 > 0 Or Servicos_0 > 0 Then

                    If row.DataAprov = "1111-11-11" Then
                        If NCotado > 0 Then
                            DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando cotações de itens na lista.", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                        Else
                            If Servicos_0 = 0 Then
                                If Cotado = 0 Then

                                    'apaga orçamento

                                    LqComercial.DeletaOrcamento(row.IdOrcamento)

                                    'DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Sem itens na lista de orçamento", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Visible = False

                                Else
                                    DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando aprovação do cliente", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                                End If
                            Else
                                DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando aprovação do cliente", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                            End If

                        End If
                        OrcPen += 1
                    Else
                        DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Orçamento perdido", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                        OrcPer += 1
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                        'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Visible = False

                    End If

                ElseIf Produtos_0 = 0 And Servicos_0 = 0 Then

                    If row.DataAprov <> "1111-11-11" Then
                        DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(row.DataSol, DateFormat.ShortDate), "Orçamento perdido", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                        OrcPen += 1
                    Else
                        If NenhumProduto = "CC" Then

                            DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(row.DataSol, DateFormat.ShortDate), "Orçamento pendente de cotações do setor de compras.", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                            OrcPen += 1

                        Else

                            'apaga orçamento

                            LqComercial.DeletaOrcamento(row.IdOrcamento)

                            'DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(row.DataSol, DateFormat.ShortDate), "Sem itens na lista.", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                            'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                            'OrcPen += 1

                        End If

                    End If

                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Visible = False

                End If

            Else

                If Produtos_0 > 0 Or Servicos_0 > 0 Then

                    If row.DataAprov = "1111-11-11" Then
                        If NCotado > 0 Then
                            DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando cotações de itens na lista.", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                            DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                        Else
                            If Cotado = 0 Then
                                DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Sem itens na lista de orçamento", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                            Else
                                DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando aprovação do cliente", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                            End If

                        End If

                        OrcPen += 1

                    Else
                        DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Orçamento aprovado", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                        OrcFin += 1

                        'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Visible = False

                        ValorORc = 0

                    End If

                ElseIf Produtos_0 = 0 And Servicos_0 = 0 Then

                    DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, _ClienteCarr, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Orçamento aprovado", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.BackColor = Color.WhiteSmoke
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.ForeColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.WhiteSmoke

                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.BackColor = Color.WhiteSmoke
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.ForeColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                    DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke
                    OrcFin += 1

                    'DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Visible = False

                End If

            End If

            If SemMarkup > 0 Then

                DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(4).Value = "Aguardando precificação de itens na lista"

            End If

            Cotado = 0
            NCotado = 0
            Estoque = 0
            ValorORc = 0
            _Versao = 0
            _DataOrc = "1111-11-11"

        Next

        Label6.Text = Perdido
        Label7.Text = Aprovados
        Label8.Text = Aberto

    End Sub
    Private Sub DtCotFinal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellContentClick

        'abre o form e popula os dados

    End Sub

    Dim LqEstoqueLocal As New LqEstoqueLocalDataContext

    Private Sub DtCotFinal_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellDoubleClick

        If DtCotFinal.SelectedCells(4).Value <> "Aprovado" Then
            If DtCotFinal.SelectedCells(4).Value = "Aguardando aprovação do cliente" Then
                LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                FrmNovoORçamento.LblNumOrcamento.Text = DtCotFinal.SelectedCells(0).Value

                FrmNovoORçamento.Edita = True

                FrmNovoORçamento.TabControl1.SelectedIndex = 2

                FrmNovoORçamento.Show(Me)

                Dim _IdOrçamento As Integer = DtCotFinal.SelectedCells(0).Value

                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                     Where orc.IdOrcamento = _IdOrçamento
                                     Select orc.IdOrcamento, orc.IdCliente, orc.DataOrc, orc.Aprovado, orc.DataAprov, orc.IdVeiculo

                Dim _Versao As Integer = 0

                Dim _TotalVersap As Decimal
                Dim LstValoresVErsao As New ListBox
                Dim LstDataVersao As New ListBox

                'busca dados do orcamento

                Dim BuscaRazaoCliente = From cli In LqBase.Clientes
                                        Where cli.IdCliente = BuscaOrçamento.First.IdCliente
                                        Select cli.CPF_CNPJ, cli.RazaoSocial_nome

                If BuscaOrçamento.First.IdCliente > 0 Then
                    FrmNovoORçamento.LblRazãoSocial.Text = BuscaRazaoCliente.First.RazaoSocial_nome
                    FrmNovoORçamento.TxtCNPJ.Text = BuscaRazaoCliente.First.CPF_CNPJ
                Else
                    FrmNovoORçamento.LblRazãoSocial.Text = "Não identificado"
                End If

                'popula dados para o grafico de time line

                Dim LstDataChange As New ListBox
                Dim LstValorChange As New ListBox

                For Each row In BuscaOrçamento.ToList

                    'declara o id do veiculo

                    FrmNovoORçamento._IdVeiculo = BuscaOrçamento.First.IdVeiculo

                    Dim BuscaProdutos = From orc In LqComercial.ProdutosOrcamento
                                        Where orc.IdOrcamento = row.IdOrcamento
                                        Select orc.Tipo, orc.IdProduto, orc.IdSolicitacao, orc.ValorUnit, orc.DescontoUnit, orc.IdProdutoOrcamento, orc.Qtdade, orc.Versao, orc.DataVersao
                                        Order By Versao Ascending

                    Dim Versao2 As Integer = 0
                    Dim TotalAtVersao As Decimal = 0

                    For Each row1 In BuscaProdutos.ToList

                        If LstDataChange.Items.Count = 0 Then
                            LstDataChange.Items.Add(0)
                            LstValorChange.Items.Add(0)
                        End If

                        If Versao2 <> row1.Versao Then

                            Versao2 = row1.Versao
                            FrmNovoORçamento.LblVersão.Text = row1.Versao
                            FrmNovoORçamento.VerOrc = row1.Versao

                            LstDataChange.Items.Add(Versao2)
                            LstValorChange.Items.Add(0)

                        End If

                        If row1.Tipo = True Then

                            'busca codigo interno

                            Dim BuscaIdProduto = From prod In LqBase.Produtos
                                                 Where prod.IdProdutoExt = row1.IdProduto
                                                 Select prod.IdProduto

                            If BuscaIdProduto.Count > 0 Then

                                'edita o parent

                                If row1.ValorUnit = 0 Then

                                    'busca cotação

                                    If row1.IdSolicitacao = 0 Then

                                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                            Where cot.IdProduto = row1.IdProduto
                                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                            Order By DataCotacao Descending

                                        If _Versao <> row1.Versao Then

                                            'FrmNovoORçamento.VerOrc = row1.Versao

                                            _Versao = row1.Versao

                                            FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                            FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                            'apaga todos os selecionados anteriormente

                                            For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                rowLimpa.Cells(0).Value = False
                                                rowLimpa.Cells(9).Value = 0
                                                rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                            Next

                                            _TotalVersap = 0

                                            'atualiza selecionado

                                        End If

                                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                        If BuscaCotações.Count > 0 Then

                                            'insere no treeview

                                            If row1.IdProduto <> 0 Then

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value.ToString = row1.IdProduto.ToString And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            Else


                                                Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                   Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add("S" & row1.IdSolicitacao & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        End If

                                    Else

                                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                            Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                            Order By DataCotacao Descending

                                        If _Versao <> row1.Versao Then

                                            'FrmNovoORçamento.VerOrc = row1.Versao

                                            _Versao = row1.Versao

                                            FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                            FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                            'apaga todos os selecionados anteriormente

                                            For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                rowLimpa.Cells(0).Value = False
                                                rowLimpa.Cells(9).Value = 0
                                                rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                            Next

                                            _TotalVersap = 0

                                            'atualiza selecionado

                                        End If

                                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                        If BuscaCotações.Count > 0 Then

                                            'insere no treeview

                                            If row1.IdProduto <> 0 Then

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            Else

                                                Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                   Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add("S" & row1.IdSolicitacao & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value.ToString = "S" & row1.IdSolicitacao.ToString And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        Else

                                            If row1.IdProduto <> 0 Then

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = 0 '+ (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            Else

                                                Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                   Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add("S" & row1.IdSolicitacao & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = 0 'BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value.ToString = "S" & row1.IdSolicitacao.ToString And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        End If

                                    End If


                                Else

                                    If row1.IdSolicitacao = 0 Then

                                        'busca estoque

                                        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                        Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                                               Where arm.IdProduto = row1.IdProduto
                                                               Select arm.Qt, arm.ValorUnit

                                        If BuscaArmazenagem.Count = 0 Then

                                            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                                Where cot.IdProduto = row1.IdProduto
                                                                Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                                Order By DataCotacao Descending

                                            If _Versao <> row1.Versao Then

                                                'FrmNovoORçamento.VerOrc = row1.Versao

                                                _Versao = row1.Versao

                                                FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                                'apaga todos os selecionados anteriormente

                                                For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    rowLimpa.Cells(0).Value = False

                                                Next

                                                _TotalVersap = 0

                                                'atualiza selecionado

                                            End If

                                            Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                            If BuscaCotações.Count > 0 Then

                                                'insere no treeview

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        Else

                                            'BuscaPreço do estoque

                                        End If

                                    Else

                                        'busca solicitacoes de cadastro

                                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
                                        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
                                        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro


                                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                            Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                            Order By DataCotacao Descending

                                        If _Versao <> row1.Versao Then

                                            'FrmNovoORçamento.VerOrc = row1.Versao

                                            _Versao = row1.Versao

                                            FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                            FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                            'apaga todos os selecionados anteriormente

                                            For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                rowLimpa.Cells(0).Value = False

                                            Next

                                            _TotalVersap = 0

                                            'atualiza selecionado

                                        End If

                                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                        If BuscaCotações.Count > 0 Then

                                            'insere no treeview

                                            Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                               Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                               Select prod.Descricao

                                            TrProdutos.Nodes.Add(row1.IdSolicitacao & " - " & BuscaProduto.First)
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                            For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                If rowProduto.Cells(1).Value = "S" & row1.IdSolicitacao And row1.Versao = _Versao Then

                                                    rowProduto.Cells(0).Value = True

                                                    rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                    rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                    rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                    Dim Desconto As String = rowProduto.Cells(11).Value
                                                    Desconto = Desconto.Replace("%", "")

                                                    Dim Vl_Desconto As Decimal = Desconto

                                                    rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                    _TotalVersap += rowProduto.Cells(12).Value

                                                    LstValoresVErsao.Items.Add(_TotalVersap)
                                                    LstDataVersao.Items.Add(row1.DataVersao)

                                                End If

                                            Next

                                        End If


                                    End If

                                End If

                            Else

                                If row1.ValorUnit = 0 Then

                                    'busca cotação

                                    If row1.IdSolicitacao = 0 Then

                                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                            Where cot.IdProduto = row1.IdProduto
                                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                            Order By DataCotacao Descending

                                        If _Versao <> row1.Versao Then

                                            'FrmNovoORçamento.VerOrc = row1.Versao

                                            _Versao = row1.Versao

                                            FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                            FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                            'apaga todos os selecionados anteriormente

                                            For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                rowLimpa.Cells(0).Value = False
                                                rowLimpa.Cells(9).Value = 0
                                                rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                            Next

                                            _TotalVersap = 0

                                            'atualiza selecionado

                                        End If

                                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                        If BuscaCotações.Count > 0 Then

                                            'insere no treeview

                                            If row1.IdProduto <> 0 Then

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100)), NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency((BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))) * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value.ToString = row1.IdProduto.ToString And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            Else


                                                Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                   Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add("S" & row1.IdSolicitacao & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(BuscaCotações.First.ValorCotado * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        End If

                                    Else

                                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                            Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                            Order By DataCotacao Descending

                                        If _Versao <> row1.Versao Then

                                            'FrmNovoORçamento.VerOrc = row1.Versao

                                            _Versao = row1.Versao

                                            FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                            FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                            'apaga todos os selecionados anteriormente

                                            For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                rowLimpa.Cells(0).Value = False
                                                rowLimpa.Cells(9).Value = 0
                                                rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                                rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                            Next

                                            _TotalVersap = 0

                                            'atualiza selecionado

                                        End If

                                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                        If BuscaCotações.Count > 0 Then

                                            'insere no treeview

                                            If row1.IdProduto <> 0 Then

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            Else

                                                Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                   Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add("S" & row1.IdSolicitacao & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value.ToString = "S" & row1.IdSolicitacao.ToString And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        Else

                                            If row1.IdProduto <> 0 Then

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = 0 '+ (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            Else

                                                Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                   Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add("S" & row1.IdSolicitacao & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = 0 'BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value.ToString = "S" & row1.IdSolicitacao.ToString And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        End If

                                    End If


                                Else

                                    If row1.IdSolicitacao = 0 Then

                                        'busca estoque

                                        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                        Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                                               Where arm.IdProduto = row1.IdProduto And arm.Qt > 0
                                                               Select arm.Qt, arm.ValorUnit

                                        If BuscaArmazenagem.Count = 0 Then

                                            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                                Where cot.IdProduto = row1.IdProduto
                                                                Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                                Order By DataCotacao Descending

                                            If _Versao <> row1.Versao Then

                                                'FrmNovoORçamento.VerOrc = row1.Versao

                                                _Versao = row1.Versao

                                                FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                                'apaga todos os selecionados anteriormente

                                                For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    rowLimpa.Cells(0).Value = False

                                                Next

                                                _TotalVersap = 0

                                                'atualiza selecionado

                                            End If

                                            Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                            If BuscaCotações.Count > 0 Then

                                                'insere no treeview

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row1.IdProduto
                                                                   Select prod.Descricao

                                                TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                                TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                                For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        rowProduto.Cells(0).Value = True

                                                        rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                        rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                        rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                        Dim Desconto As String = rowProduto.Cells(11).Value
                                                        Desconto = Desconto.Replace("%", "")

                                                        Dim Vl_Desconto As Decimal = Desconto

                                                        rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                        _TotalVersap += rowProduto.Cells(12).Value

                                                        LstValoresVErsao.Items.Add(_TotalVersap)
                                                        LstDataVersao.Items.Add(row1.DataVersao)

                                                    End If

                                                Next

                                            End If

                                        Else

                                            'BuscaPreço do estoque

                                            If _Versao <> row1.Versao Then

                                                'FrmNovoORçamento.VerOrc = row1.Versao

                                                _Versao = row1.Versao

                                                FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                                FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                                'apaga todos os selecionados anteriormente

                                                For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                    rowLimpa.Cells(0).Value = False

                                                Next

                                                _TotalVersap = 0

                                                'atualiza selecionado

                                            End If

                                            Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                            Dim Qt As Integer = 0

                                            For Each rowArm In BuscaArmazenagem.ToList

                                                Qt += rowArm.Qt

                                            Next

                                            Dim BuscaProduto = From prod In LqBase.Produtos
                                                               Where prod.IdProduto = row1.IdProduto
                                                               Select prod.Descricao

                                            TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First)
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            Dim VlrVenda As Decimal = row1.ValorUnit
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                            For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                    rowProduto.Cells(0).Value = True

                                                    rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                    rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                    rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                    Dim Desconto As String = rowProduto.Cells(11).Value
                                                    Desconto = Desconto.Replace("%", "")

                                                    Dim Vl_Desconto As Decimal = Desconto

                                                    rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                    _TotalVersap += rowProduto.Cells(12).Value

                                                    LstValoresVErsao.Items.Add(_TotalVersap)
                                                    LstDataVersao.Items.Add(row1.DataVersao)

                                                End If

                                            Next

                                        End If

                                    Else

                                        'busca solicitacoes de cadastro

                                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
                                        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
                                        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro


                                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                            Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                            Order By DataCotacao Descending

                                        If _Versao <> row1.Versao Then

                                            'FrmNovoORçamento.VerOrc = row1.Versao

                                            _Versao = row1.Versao

                                            FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                            FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                            'apaga todos os selecionados anteriormente

                                            For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                rowLimpa.Cells(0).Value = False

                                            Next

                                            _TotalVersap = 0

                                            'atualiza selecionado

                                        End If

                                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                        If BuscaCotações.Count > 0 Then

                                            'insere no treeview

                                            Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                                               Where prod.IdSolicitacaoCadastro = row1.IdSolicitacao
                                                               Select prod.Descricao

                                            TrProdutos.Nodes.Add(row1.IdSolicitacao & " - " & BuscaProduto.First)
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(VlrVenda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                            For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                                                Dim VlrString As String = rowProduto.Cells(1).Value

                                                If VlrString = "S" & row1.IdSolicitacao And row1.Versao = _Versao Then

                                                    rowProduto.Cells(0).Value = True

                                                    rowProduto.Cells(7).Value = FormatCurrency((VlrVenda), NumDigitsAfterDecimal:=2)

                                                    rowProduto.Cells(9).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                    rowProduto.Cells(11).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                    Dim Desconto As String = rowProduto.Cells(11).Value
                                                    Desconto = Desconto.Replace("%", "")

                                                    Dim Vl_Desconto As Decimal = Desconto

                                                    rowProduto.Cells(12).Value = FormatCurrency(((VlrVenda - (VlrVenda * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                    _TotalVersap += rowProduto.Cells(12).Value

                                                    LstValoresVErsao.Items.Add(_TotalVersap)
                                                    LstDataVersao.Items.Add(row1.DataVersao)

                                                End If

                                            Next

                                        End If


                                    End If

                                End If

                            End If

                        Else

                            Dim BuscaIdProduto = From prod In LqBase.Servicos
                                                 Where prod.IdServico = row1.IdProduto
                                                 Select prod.IdServico

                            If BuscaIdProduto.Count > 0 Then

                                If row1.ValorUnit = 0 Then

                                    'busca cotação

                                    Dim BuscaProduto = From prod In LqBase.Servicos
                                                       Where prod.IdServico = row1.IdProduto
                                                       Select prod.Descricao, prod.VlrVeda

                                    If _Versao <> row1.Versao Then

                                        'FrmNovoORçamento.VerOrc = row1.Versao

                                        _Versao = row1.Versao

                                        FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                        FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                        FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                        'apaga todos os selecionados anteriormente

                                        For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                                            rowLimpa.Cells(0).Value = False
                                            rowLimpa.Cells(9).Value = 0
                                            rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                            rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                        Next

                                        _TotalVersap = 0

                                        'atualiza selecionado

                                    End If

                                    Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                    'insere no treeview

                                    If row1.IdProduto <> 0 Then

                                        TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First.Descricao & " (Serviço)")
                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency((BuscaProduto.First.VlrVeda / 220), NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(BuscaProduto.First.VlrVeda * row1.Qtdade, NumDigitsAfterDecimal:=2))

                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                                            If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                rowProduto.Cells(0).Value = True

                                                rowProduto.Cells(3).Value = FormatCurrency((BuscaProduto.First.VlrVeda / 220), NumDigitsAfterDecimal:=2)

                                                rowProduto.Cells(5).Value = FormatNumber(row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                rowProduto.Cells(7).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                Dim Desconto As String = rowProduto.Cells(7).Value
                                                Desconto = Desconto.Replace("%", "")

                                                Dim Vl_Desconto As Decimal = Desconto

                                                rowProduto.Cells(8).Value = FormatCurrency((((BuscaProduto.First.VlrVeda / 220) - ((BuscaProduto.First.VlrVeda / 220) * (Vl_Desconto / 100))) * row1.Qtdade), NumDigitsAfterDecimal:=2)

                                                _TotalVersap += rowProduto.Cells(8).Value

                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                LstDataVersao.Items.Add(row1.DataVersao)

                                            End If

                                        Next

                                    End If

                                Else

                                    'busca estoque

                                    'busca cotação

                                    Dim BuscaProduto = From prod In LqBase.Servicos
                                                       Where prod.IdServico = row1.IdProduto
                                                       Select prod.Descricao, prod.VlrVeda, prod.Markup

                                    If _Versao <> row1.Versao Then

                                        'FrmNovoORçamento.VerOrc = row1.Versao

                                        _Versao = row1.Versao

                                        FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & _Versao)
                                        FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray
                                        FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(row1.DataVersao, DateFormat.ShortDate)

                                        'apaga todos os selecionados anteriormente

                                        For Each rowLimpa As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                                            rowLimpa.Cells(0).Value = False
                                            rowLimpa.Cells(9).Value = 0
                                            rowLimpa.Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                                            rowLimpa.Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                                        Next

                                        _TotalVersap = 0

                                        'atualiza selecionado

                                    End If

                                    Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                                    'insere no treeview

                                    If row1.IdProduto <> 0 Then

                                        'verifica se item já se encontra na lista

                                        Dim IdTreeView As Integer = -1

                                        Dim QtAchada As Integer = 0
                                        For Each node As TreeNode In TrProdutos.Nodes

                                            If node.Text = row1.IdProduto & " - " & BuscaProduto.First.Descricao & " (Serviço)" Then

                                                IdTreeView = node.Index
                                                'procura quantidade
                                                For Each row2 As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                                                    If row2.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                        QtAchada = row2.Cells(5).Value

                                                    End If

                                                Next

                                            End If

                                        Next

                                        If IdTreeView = -1 Then
                                            TrProdutos.Nodes.Add(row1.IdProduto & " - " & BuscaProduto.First.Descricao & " (Serviço)")
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                                            TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency((BuscaProduto.First.VlrVeda + (BuscaProduto.First.VlrVeda * (BuscaProduto.First.Markup / 100))) / 60, NumDigitsAfterDecimal:=2) & " x " & row1.Qtdade & " = " & FormatCurrency(((BuscaProduto.First.VlrVeda + (BuscaProduto.First.VlrVeda * (BuscaProduto.First.Markup / 100))) / 60) * row1.Qtdade, NumDigitsAfterDecimal:=2))
                                            FrmNovoORçamento.BttEnviarEmail.Enabled = True
                                        Else
                                            TrProdutos.Nodes(IdTreeView).ForeColor = Color.SlateGray
                                            TrProdutos.Nodes(IdTreeView).Nodes(0).Text = (FormatCurrency((BuscaProduto.First.VlrVeda + (BuscaProduto.First.VlrVeda * (BuscaProduto.First.Markup / 100))) / 60, NumDigitsAfterDecimal:=2) & " x " & (row1.Qtdade + QtAchada) & " = " & FormatCurrency(((BuscaProduto.First.VlrVeda + (BuscaProduto.First.VlrVeda * (BuscaProduto.First.Markup / 100))) / 60) * (row1.Qtdade + QtAchada), NumDigitsAfterDecimal:=2))
                                            FrmNovoORçamento.BttEnviarEmail.Enabled = True
                                        End If

                                        For Each rowProduto As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                                            If rowProduto.Cells(1).Value = row1.IdProduto And row1.Versao = _Versao Then

                                                Dim ValorVenda As Decimal = (BuscaProduto.First.VlrVeda + (BuscaProduto.First.VlrVeda * (BuscaProduto.First.Markup / 100))) / 60

                                                rowProduto.Cells(0).Value = True

                                                rowProduto.Cells(3).Value = FormatCurrency(ValorVenda, NumDigitsAfterDecimal:=2)

                                                rowProduto.Cells(5).Value = FormatNumber(QtAchada + row1.Qtdade, NumDigitsAfterDecimal:=0)

                                                rowProduto.Cells(7).Value = FormatPercent(row1.DescontoUnit / 100, NumDigitsAfterDecimal:=2)

                                                Dim Desconto As String = rowProduto.Cells(7).Value
                                                Desconto = Desconto.Replace("%", "")

                                                Dim Vl_Desconto As Decimal = Desconto

                                                rowProduto.Cells(8).Value = FormatCurrency(((ValorVenda - (ValorVenda * (Vl_Desconto / 100))) * (QtAchada + row1.Qtdade)), NumDigitsAfterDecimal:=2)

                                                _TotalVersap += rowProduto.Cells(8).Value

                                                LstValoresVErsao.Items.Add(_TotalVersap)
                                                LstDataVersao.Items.Add(row1.DataVersao)

                                            End If

                                        Next

                                    End If

                                End If

                            End If

                        End If

                        If Versao2 = row1.Versao Then

                            Dim ItemSel As Integer = LstDataChange.Items.Count - 1

                            LstValorChange.Items(ItemSel) = (_TotalVersap)

                        End If

                    Next

                Next

                'ChTimeline
                FrmNovoORçamento.ChTimeline.Series(0).Points.DataBindXY(LstDataChange.Items, LstValorChange.Items)
                FrmNovoORçamento.ChTimeline.Series(1).Points.DataBindXY(LstDataChange.Items, LstValorChange.Items)

                If FrmNovoORçamento.TrResumo.Nodes.Count > 0 Then
                    FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ExpandAll()
                Else
                    'FrmNovoORçamento.LblVersão.Text = 1

                    FrmNovoORçamento.TrResumo.Nodes.Add("Versão " & FrmNovoORçamento.VerOrc)
                End If

                Dim Total As Decimal = 0
                Dim DescontoTotal As Decimal = 0
                Dim ValorFInal As Decimal = 0

                Dim C As Integer = 0

                For Each row As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                    Dim valorUnit As Decimal = row.Cells(7).Value
                    Dim Qt As Decimal = row.Cells(9).Value
                    Dim Desconto As String = row.Cells(11).Value
                    Desconto = Desconto.Replace("%", "")

                    Dim Vl_Desconto As Decimal = Desconto

                    If row.Cells(0).Value = True Then
                        Total += valorUnit * Qt
                    End If

                    DescontoTotal += (valorUnit * (Desconto / 100)) * Qt

                    ValorFInal += (valorUnit - (valorUnit * (Desconto / 100))) * Qt

                    If row.Cells(0).Value = True And row.Cells(7).Value = 0 Then
                        C += 1
                    End If

                Next
                For Each row As DataGridViewRow In FrmNovoORçamento.DtServiços.Rows

                    Dim valorUnit As Decimal = row.Cells(3).Value
                    Dim Qt As Decimal = row.Cells(5).Value
                    Dim Desconto As String = row.Cells(7).Value
                    Desconto = Desconto.Replace("%", "")

                    Dim Vl_Desconto As Decimal = Desconto

                    If row.Cells(0).Value = True Then
                        Total += valorUnit * Qt
                    End If

                    DescontoTotal += (valorUnit * (Desconto / 100)) * Qt

                    ValorFInal += (valorUnit - (valorUnit * (Desconto / 100))) * Qt

                    If row.Cells(0).Value = True And row.Cells(3).Value = 0 Then
                        C += 1
                    End If

                Next

                FrmNovoORçamento.LblSubtotal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                FrmNovoORçamento.LblDescontos.Text = FormatCurrency(DescontoTotal, NumDigitsAfterDecimal:=2)
                FrmNovoORçamento.LblValorTotal.Text = FormatCurrency(ValorFInal, NumDigitsAfterDecimal:=2)

                'popula chart

                Dim LstX As New ListBox
                Dim LstY As New ListBox

                For i As Integer = 0 To LstDataVersao.Items.Count - 1

                    If Not LstY.Items.Contains(LstDataVersao.Items(i).ToString) Then

                        Dim Para As Boolean = False

                        For i1 As Integer = i To (LstDataVersao.Items.Count - 1)

                            If LstDataVersao.Items(i).ToString <> LstDataVersao.Items(i1).ToString Then

                                If Para = False Then

                                    Para = True

                                    If i1 < LstDataVersao.Items.Count - 1 Then
                                        LstX.Items.Add(LstValoresVErsao.Items(i1 - 1).ToString)
                                        LstY.Items.Add(FormatDateTime(LstDataVersao.Items(i1).ToString, DateFormat.ShortDate))

                                    ElseIf i1 = LstDataVersao.Items.Count - 1 Then
                                        LstX.Items.Add(LstValoresVErsao.Items(i1).ToString)
                                        LstY.Items.Add(FormatDateTime(LstDataVersao.Items(i1).ToString, DateFormat.ShortDate))

                                    End If

                                End If

                            End If

                        Next

                    End If

                Next

                FrmNovoORçamento.LblVersão.Text = FrmNovoORçamento.VerOrc

                'Busca formas de pagamento

                Dim _Contatotal As Decimal = 0
                Dim BuscaFormasPg = From orc In LqComercial.FormasPGOrcamento
                                    Where orc.IdOrcamento = FrmNovoORçamento.LblNumOrcamento.Text And orc.IdVersao = FrmNovoORçamento.LblVersão.Text
                                    Select orc.IdForma, orc.Pc, orc.Valor, orc.Vencimento

                For Each row In BuscaFormasPg.ToList

                    Dim BuscaDescricao = From orc In LqFinanceiro.FormasPgEntrada
                                         Where orc.IdFormasPgEntrada = row.IdForma
                                         Select orc.Descricao

                    FrmNovoORçamento.DtFormas.Rows.Add(row.IdForma, BuscaDescricao.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), My.Resources.Delete_80_icon_icons_com_57340)
                    _Contatotal += row.Valor

                Next

                If C = 0 Then
                    FrmNovoORçamento.BttDeclinarOrc.Enabled = True
                Else
                    FrmNovoORçamento.BttDeclinarOrc.Enabled = False
                End If

                If _Contatotal >= ValorFInal And ValorFInal > 0 Then
                    FrmNovoORçamento.BttAprovarOrc.Enabled = True
                    FrmNovoORçamento.CmbFormasPgEntrada.Enabled = False
                ElseIf _Contatotal <= ValorFInal Or ValorFInal = 0 Then
                    FrmNovoORçamento.BttAprovarOrc.Enabled = False
                    FrmNovoORçamento.CmbFormasPgEntrada.Enabled = True
                End If

                'FrmNovoORçamento.ChTimeline.Series(0).Points.DataBindXY(LstY.Items, LstX.Items)

                'carrega dados finais do cliente e data do orçamento

                Dim BuscaDadosOrcamento = From orc In LqComercial.Orcamentos
                                          Where orc.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString
                                          Select orc.DataOrc, orc.IdVeiculo, orc.DataSol

                If BuscaDadosOrcamento.Count > 0 Then

                    FrmNovoORçamento.LblDataOrcamento.Text = FormatDateTime(BuscaDadosOrcamento.First.DataSol, DateFormat.ShortDate)

                    ' busca modelo do veiculo

                    Dim BuscaModeloVeic = From modv In LqOficina.Veiculos
                                          Where modv.IdVeiculo = BuscaDadosOrcamento.First.IdVeiculo
                                          Select modv.Modelo, modv.Fabricante, modv.AnoFab, modv.AnoMod, modv.Versao

                    If BuscaModeloVeic.Count > 0 Then

                        FrmNovoORçamento.LblModelo.Text = BuscaModeloVeic.First.Fabricante & " - " & BuscaModeloVeic.First.Modelo
                        FrmNovoORçamento.LblVersao.Text = BuscaModeloVeic.First.Versao
                        FrmNovoORçamento.IdModeloVeiculo = BuscaDadosOrcamento.First.IdVeiculo

                    End If

                End If

                FrmNovoORçamento.BttAprovarOrc.Enabled = True
                FrmNovoORçamento.BttDeclinarOrc.Enabled = True

            Else

                MsgBox("Não é possível abrir este orçamento no momento.", MsgBoxStyle.OkOnly)

            End If

        End If

    End Sub

    Private Sub FrmComercial_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        FrmPrincipal.Timer1.Enabled = True

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub
End Class