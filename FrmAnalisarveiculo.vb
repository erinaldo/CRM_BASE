Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmAnalisarveiculo

    Public UrlImagem As String = ""

    Public Sub CarregaServicos()

        DtServicoSel.Rows.Clear()
        DtServico.Rows.Clear()

        For Each lst In LstOrcamento.Items

            Dim _IdOrcamento As Integer = lst.ToString

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaServicos = From serv In LqBase.Servicos
                                Where serv.IdServico Like "*"
                                Select serv.IdServico, serv.Descricao, serv.TME, serv.VlrVeda, serv.IdServicoInt

            For Each row In BuscaServicos.ToList

                'verifica se o serviço consta na lista

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_produtos_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & IdImagem & "&IdOrcamento=" & _IdOrcamento & "&IdItem=" & row.IdServicoInt & "&TipoDoItem=servico"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Servicos))(contentOrcamento)

                DtServico.Rows.Add(row.IdServico, row.Descricao, row.TME, row.VlrVeda, ImageList1.Images(0))

                If readOrcamento.Count > 0 Then

                    DtServicoSel.Rows.Add(DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(0).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(1).Value,
                                       readOrcamento.Item(0).TMA, readOrcamento.Item(0).VlrSugerido,
                                      ImageList1.Images(1))

                    DtServico.Rows.RemoveAt(DtProduto.Rows.Count - 1)

                End If

            Next

        Next

    End Sub

    Public Sub CarregaProdutos()

        Me.Cursor = Cursors.AppStarting

        DtProdutoSel.Rows.Clear()

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        For Each lst In LstOrcamento.Items

            Dim _IdOrcamento As Integer = lst.ToString

            Dim Aprovado As Boolean = False

            Dim BuscaOrcamento = From orc In LqComercial.Orcamentos
                                 Where orc.IdOrcamento = _IdOrcamento And orc.Aprovado = True
                                 Select orc.IdOrcamento

            Dim LstIdAprovados As New ListBox
            Dim LstCodAprovados As New ListBox

            If BuscaOrcamento.Count > 0 Then
                Aprovado = True
            End If

            'desenha a imagem de fundo
            Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim Diminuir As Decimal = (PicImagem.Height * (1 / 100))

            'busca Url da imagem

            If UrlImagem <> "" Then

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & UrlImagem

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > PicImagem.Width Or img.Height - (img.Height * (Pctg / 100)) > PicImagem.Height

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((PicImagem.Width - X) / 2)
                Dim PosY As Decimal = 0 + ((PicImagem.Height - Y) / 2)

                Pintura.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                Pintura.DrawImage(img, PosX, PosY, X, Y)

                PicImagem.BackgroundImage = PintarBitmap

            End If

            'busca serviços

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaServicos = From serv In LqBase.Servicos
                                Where serv.IdServico Like "*"
                                Select serv.IdServico, serv.Descricao, serv.TME, serv.VlrVeda, serv.IdServicoInt

            For Each row In BuscaServicos.ToList

                'verifica se o serviço consta na lista

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_produtos_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & IdImagem & "&IdOrcamento=" & _IdOrcamento & "&IdItem=" & row.IdServicoInt & "&TipoDoItem=servico"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItensEncontrados))(contentOrcamento)

                Dim Valida As Boolean = True

                For Each linhas As DataGridViewRow In DtServico.Rows
                    If linhas.Cells(0).Value = "S" & row.IdServico Then
                        Valida = False
                    End If
                Next

                If Valida = True Then

                    DtServico.Rows.Add(row.IdServico, row.Descricao, row.TME, row.VlrVeda, ImageList1.Images(0))

                    If readOrcamento.Count > 0 Then

                        Dim TMASEL As Date = Today.Date & " 00:00:00"
                        Dim ValorVenda As Decimal = DtServico.Rows(DtServico.Rows.Count - 1).Cells(3).Value
                        ValorVenda = ValorVenda / 60

                        Dim Time As Date = Today.Date & " 00:00:00"

                        DtServicoSel.Rows.Add(DtServico.Rows(DtServico.Rows.Count - 1).Cells(0).Value,
                                      DtServico.Rows(DtServico.Rows.Count - 1).Cells(1).Value,
                                      DtServico.Rows(DtServico.Rows.Count - 1).Cells(2).Value, FormatCurrency(ValorVenda * readOrcamento.Item(0).Qt, NumDigitsAfterDecimal:=2), Time.AddMinutes(readOrcamento.Item(0).Qt).TimeOfDay.ToString,
                                      ImageList1.Images(1), Aprovado)

                        DtServico.Rows.RemoveAt(DtServico.Rows.Count - 1)

                    End If

                    CalculaServicos()

                End If

            Next

            Dim BuscaProdutos = From serv In LqBase.Produtos
                                Where serv.IdProduto Like "*"
                                Select serv.IdProduto, serv.Descricao, serv.Fabricante, serv.IdProdutoExt

            For Each row In BuscaProdutos.ToList

                Dim LqEstoque As New LqEstoqueLocalDataContext
                LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                   Where est.IdProduto = row.IdProduto
                                   Select est.NF, est.Qt, est.ValorRevenda, est.Validade, est.DataEntrada, est.Endereco

                Dim ValorUnit As Decimal = 0
                Dim Estoque As Decimal = 0
                Dim EstoqueDisp As String = "I"

                Dim ValorGuardado As Decimal = 0

                For Each item In BuscaEstoque.ToList

                    If ValorUnit < item.ValorRevenda Then
                        ValorGuardado = ValorUnit
                        ValorUnit = item.ValorRevenda
                    End If

                    Estoque += item.Qt

                    If Not item.Endereco.StartsWith("temp") Then

                        'busca baixa do endereco 

                        Dim BuscaBaixa = From bai In LqEstoque.BaixaEndereco
                                         Where bai.IdEndereco = item.Endereco And bai.NumNf Like item.NF
                                         Select bai.Qt

                        For Each itemB In BuscaBaixa.ToList

                            Estoque -= itemB

                        Next

                        If Estoque = 0 Then

                            ValorUnit = ValorGuardado

                            EstoqueDisp = "I"

                        Else

                            EstoqueDisp = "D"

                        End If

                    End If

                Next

                If EstoqueDisp = "I" Then
                    ValorUnit = 0
                End If

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_produtos_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & IdImagem & "&IdOrcamento=" & _IdOrcamento & "&IdItem=" & row.IdProdutoExt & "&TipoDoItem=produto"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItensEncontrados))(contentOrcamento)


                Dim Valida As Boolean = True

                For Each linhas As DataGridViewRow In DtProduto.Rows
                    If Not linhas.Cells(0).Value.ToString.StartsWith("S") Then
                        If linhas.Cells(0).Value = row.IdProduto Then
                            Valida = False
                        End If
                    End If
                Next

                If Valida = True Then

                    DtProduto.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), EstoqueDisp, ImageList1.Images(0))

                    If readOrcamento.Count > 0 Then

                        DtProdutoSel.Rows.Add(DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(0).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(1).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(2).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(3).Value, readOrcamento.Item(0).Qt,
                                      ImageList1.Images(1), Aprovado)

                        DtProduto.Rows.RemoveAt(DtProduto.Rows.Count - 1)

                    End If

                    'verifica se o item ja foi selecionado para esta imagem

                    CalculaProdutos()

                End If

            Next

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim BuscaSolicitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                    Where sol.IdCodCad = 0
                                    Select sol.IdSolicitacaoCadastro, sol.Descricao, sol.IdCodExt, sol.Fabricante

            For Each row In BuscaSolicitacoes.ToList

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = row.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup, cot.DataCotacao

                Dim ValorUnit As Decimal = 0

                If BuscaCotacao.Count > 0 Then

                    If BuscaCotacao.First.DataCotacao.Value.AddDays(15) >= Today.Date Then

                        ValorUnit = BuscaCotacao.First.ValorCotado + (BuscaCotacao.First.ValorCotado * (BuscaCotacao.First.Markup / 100))

                    End If

                End If

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_produtos_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & IdImagem & "&IdOrcamento=" & _IdOrcamento & "&IdItem=" & row.IdCodExt & "&TipoDoItem=produto"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItensEncontrados))(contentOrcamento)

                Dim Valida As Boolean = True

                For Each linhas As DataGridViewRow In DtProduto.Rows
                    If linhas.Cells(0).Value.ToString.StartsWith("S") Then
                        If linhas.Cells(0).Value = "S" & row.IdSolicitacaoCadastro Then
                            Valida = False
                        End If
                    End If
                Next

                If Valida = True Then

                    DtProduto.Rows.Add("S" & row.IdSolicitacaoCadastro, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), 0, ImageList1.Images(0))

                    If readOrcamento.Count > 0 Then

                        DtProdutoSel.Rows.Add(DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(0).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(1).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(2).Value,
                                      DtProduto.Rows(DtProduto.Rows.Count - 1).Cells(3).Value, readOrcamento.Item(0).Qt,
                                      ImageList1.Images(1), Aprovado)

                        DtProduto.Rows.RemoveAt(DtProduto.Rows.Count - 1)

                    End If

                    'verifica se o item ja foi selecionado para esta imagem

                    CalculaProdutos()

                End If

            Next

            Me.Cursor = Cursors.Arrow

        Next

        'busca outros orcaentos para esta imagem

        Dim BuscaOrcamentoAprov = From aprov In LqComercial.Orcamentos
                                  Where aprov.DataNf = "1111-11-11" And aprov.Aprovado = True And aprov.IdVeiculo = IdVeiculo
                                  Select aprov.IdOrcamento

        For Each row In BuscaOrcamentoAprov.ToList

            'busca itens para a imagem 

            Dim BuscaItens = From it In LqComercial.ProdutosOrcamento
                             Where it.IdOrcamento = row And it.IdImagemAval = IdImagem
                             Select it.Tipo, it.IdProduto, it.IdSolicitacao, it.Qtdade

            For Each it In BuscaItens.ToList

                If it.Tipo = True Then

                    If it.IdProduto = 0 Then
                        'busca na lista

                        Dim IndexRemove As Integer = -1

                        For Each rowIt As DataGridViewRow In DtProduto.Rows

                            If rowIt.Cells(0).Value.ToString = "S" & it.IdSolicitacao Then

                                DtProdutoSel.Rows.Add(rowIt.Cells(0).Value,
                                  rowIt.Cells(1).Value,
                                  rowIt.Cells(2).Value,
                                  rowIt.Cells(3).Value, it.Qtdade,
                                  ImageList1.Images(2), True)

                                IndexRemove = rowIt.Index

                            End If

                        Next

                        If IndexRemove >= 0 Then
                            DtProduto.Rows.RemoveAt(IndexRemove)
                        End If

                    Else

                        Dim IndexRemove As Integer = -1

                        For Each rowIt As DataGridViewRow In DtProduto.Rows

                            If rowIt.Cells(0).Value.ToString = it.IdProduto.ToString Then

                                DtProdutoSel.Rows.Add(rowIt.Cells(0).Value,
                                  rowIt.Cells(1).Value,
                                  rowIt.Cells(2).Value,
                                  rowIt.Cells(3).Value, it.Qtdade,
                                  ImageList1.Images(2), True)

                                IndexRemove = rowIt.Index

                            End If

                        Next

                        If IndexRemove >= 0 Then
                            DtProduto.Rows.RemoveAt(IndexRemove)
                        End If

                    End If

                End If

            Next

        Next

        Me.Cursor = Cursors.Arrow

    End Sub
    Private Sub FrmAnalisarveiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaProdutos()

    End Sub

    Private Sub DtProduto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProduto.CellContentClick

        If DtProduto.Columns(e.ColumnIndex).Name = "ClmInsereProduto" Then

            DtProdutoSel.Rows.Add(DtProduto.Rows(e.RowIndex).Cells(0).Value,
                                  DtProduto.Rows(e.RowIndex).Cells(1).Value,
                                  DtProduto.Rows(e.RowIndex).Cells(2).Value,
                                  DtProduto.Rows(e.RowIndex).Cells(3).Value, 0,
                                  ImageList1.Images(1), False)

            DtProduto.Rows.RemoveAt(e.RowIndex)

            DtProdutoSel.FirstDisplayedCell = DtProdutoSel.Rows(DtProdutoSel.Rows.Count - 1).Cells(0)

        End If

    End Sub

    Private Sub DtProdutoSel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutoSel.CellContentClick

        If DtProdutoSel.Columns(e.ColumnIndex).Name = "ClmExcluirProduto" Then

            Me.Cursor = Cursors.WaitCursor

            If DtProdutoSel.Rows(e.RowIndex).Cells(6).Value <> "True" Then
                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                If Not DtProdutoSel.Rows(e.RowIndex).Cells(0).Value.ToString.StartsWith("S") Then

                    Dim _IdProdutoSel As Integer = DtProdutoSel.Rows(e.RowIndex).Cells(0).Value

                    Dim BuscaProdutos = From serv In LqBase.Produtos
                                        Where serv.IdProduto = _IdProdutoSel
                                        Select serv.IdProduto, serv.Descricao, serv.Fabricante

                    For Each row In BuscaProdutos.ToList

                        Dim LqEstoque As New LqEstoqueLocalDataContext
                        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                        Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                           Where est.IdProduto = row.IdProduto
                                           Select est.NF, est.Qt, est.ValorRevenda, est.Validade, est.DataEntrada, est.Endereco

                        Dim ValorUnit As Decimal = 0
                        Dim Estoque As Decimal = 0
                        Dim EstoqueDisp As String = "I"

                        Dim ValorGuardado As Decimal = 0

                        For Each item In BuscaEstoque.ToList

                            If ValorUnit < item.ValorRevenda Then
                                ValorGuardado = ValorUnit
                                ValorUnit = item.ValorRevenda
                            End If

                            Estoque += item.Qt

                            If Not item.Endereco.StartsWith("temp") Then

                                'busca baixa do endereco 

                                Dim BuscaBaixa = From bai In LqEstoque.BaixaEndereco
                                                 Where bai.IdEndereco = item.Endereco And bai.NumNf Like item.NF
                                                 Select bai.Qt

                                For Each itemB In BuscaBaixa.ToList

                                    Estoque -= itemB

                                Next

                                If Estoque = 0 Then

                                    ValorUnit = ValorGuardado

                                    EstoqueDisp = "I"

                                Else

                                    EstoqueDisp = "D"

                                End If

                            End If

                        Next

                        If EstoqueDisp = "I" Then
                            ValorUnit = 0
                        End If

                        DtProduto.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), EstoqueDisp, ImageList1.Images(0))

                        'verifica se o item ja foi selecionado para esta imagem


                    Next

                Else

                    Dim _IdProdutoSel As Integer = DtProdutoSel.Rows(e.RowIndex).Cells(0).Value.ToString.Remove(0, 1)

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaProdutos = From serv In LqOficina.SolicitacaoCadastroPeca
                                        Where serv.IdSolicitacaoCadastro = _IdProdutoSel
                                        Select serv.IdCodExt, serv.Descricao, serv.Fabricante

                    For Each row In BuscaProdutos.ToList

                        Dim ValorUnit As Decimal = 0
                        Dim Estoque As Decimal = 0
                        Dim EstoqueDisp As String = "I"

                        Dim ValorGuardado As Decimal = 0

                        If EstoqueDisp = "I" Then
                            ValorUnit = 0
                        End If

                        DtProduto.Rows.Add("S" & _IdProdutoSel, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), EstoqueDisp, ImageList1.Images(0))

                        'verifica se o item ja foi selecionado para esta imagem

                    Next

                End If

                DtProdutoSel.Rows.RemoveAt(e.RowIndex)

                CalculaProdutos()

                Me.Cursor = Cursors.Arrow

            Else

                If MsgBox("Este item já foi aprovado pelo cliente.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information) = MsgBoxResult.Ok Then

                    CalculaProdutos()

                    Me.Cursor = Cursors.Arrow

                End If

            End If

        End If

    End Sub

    Private Sub DtProdutoSel_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutoSel.CellEndEdit

        CalculaProdutos()

    End Sub

    Public Sub CalculaProdutos()

        'calcula fianis

        Dim Subtotal As Decimal = 0

        For Each row As DataGridViewRow In DtProdutoSel.Rows

            Dim Qtdade As Integer = row.Cells(4).Value
            Dim ValorUnit As Decimal = row.Cells(3).Value

            Subtotal += ValorUnit * Qtdade

        Next

        LblSubtotalProdutos.Text = FormatCurrency(Subtotal, NumDigitsAfterDecimal:=2)

    End Sub
    Public Sub CalculaServicos()

        'calcula fianis

        Dim Subtotal As Decimal = 0
        Dim Tma_Total As Integer

        For Each row As DataGridViewRow In DtServicoSel.Rows

            Dim Time As Date = Today.Date & " " & row.Cells(2).Value.ToString

            Tma_Total += (((Time.TimeOfDay.Hours) * 60) + Time.TimeOfDay.Minutes)

            Dim TimeSel As Date = Today.Date & " " & row.Cells(4).Value
            Dim Qtdade As Integer = (TimeSel.TimeOfDay.Hours * 60) + TimeSel.TimeOfDay.Minutes
            Dim ValorUnit As Decimal = row.Cells(3).Value

            row.Cells(4).Value = FormatDateTime(TimeSel.TimeOfDay.ToString, DateFormat.LongTime)

            Subtotal += ValorUnit * Qtdade

        Next

        Dim Tma_final As Date = Today.Date & " 00:00:00"

        LblSubtotalServicos.Text = FormatCurrency(Subtotal, NumDigitsAfterDecimal:=2)
        LblTempoMediodeReparo.Text = Tma_final.AddMinutes(Tma_Total.ToString).TimeOfDay.ToString

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Public LstOrcamento As New ListBox
    Public IdImagem As Integer
    Public IdCliente As Integer
    Public IdVeiculo As Integer

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BtnConcluir.Click

        'verifica se orcamento apontado ja foi aprovado

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        For Each lst In LstOrcamento.Items

            Dim IdOrcamento As Integer = lst.ToString

            Dim BuscaOrcamento = From com In LqComercial.Orcamentos
                                 Where com.IdCorOrcamentoExt = IdOrcamento And com.Aprovado = False And com.DataAprov = "1111-11-11"
                                 Select com.DataSol

            If BuscaOrcamento.Count > 0 Then

                Me.Cursor = Cursors.WaitCursor

                'apenas serviços on line, a sincronia sera realizada após o fechamento do form

                If IdOrcamento > 0 Then

                    'limpa_itens_orcamento_local

                    Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/limpa_itens_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & IdOrcamento & "&IdImagemAval=" & IdImagem

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientImagemUsuario = New WebClient()
                    Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

                Else

                    'cria orçamento

                    Dim BuscaCLiente = From cli In LqBase.Clientes
                                       Where cli.IdCliente = IdCliente
                                       Select cli.IdClienteExt

                    Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/create_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdCliente=" & BuscaCLiente.First & "&IdVeiculo=" & IdVeiculo & "&VlrTotal=" & FormatNumber(LblTotal.Text, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&DataOrcamento=" & Today.Date & "&IdAvaliadorTerceiro=0" & "&Aprovacao=1" & "&DataAprovacao=1111-11-11" & "&HoraAprovacao=00:00:00"

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientImagemUsuario = New WebClient()
                    Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

                    Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentImagemUsuario & "]")

                    IdOrcamento = readImagemUsuario.Item(0).Id

                End If

                For Each item As DataGridViewRow In DtProdutoSel.Rows

                    If Not item.Cells(0).Value.ToString.StartsWith("S") Then

                        Dim _IdProduto As Integer = item.Cells(0).Value

                        Dim BuscaIdExterno = From ext In LqBase.Produtos
                                             Where ext.IdProduto = _IdProduto
                                             Select ext.IdProdutoExt

                        'insere novos items 

                        Dim VlrUnit As Decimal = item.Cells(3).Value
                        Dim _QtEnc As Integer = item.Cells(4).Value

                        Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_item_produto_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdItem=" & BuscaIdExterno.First & "&IdOrcamento=" & IdOrcamento & "&Descricao=" & item.Cells(1).Value & "&Qt=" & _QtEnc & "&VlrUnit=" & FormatNumber(VlrUnit, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&VlrDesconto=0&SubTotal=" & FormatNumber(VlrUnit * _QtEnc, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&Aprovado=0&TipoDoItem=produto&ImgProduto=sem imagem&TipoDaAquisicao=0&IdImagemAval=" & IdImagem

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientInsereTodos = New WebClient()
                        Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

                    Else

                        Dim _IdSolicitacao As Integer = item.Cells(0).Value.ToString.Remove(0, 1)

                        Dim LqOficina As New LqOficinaDataContext
                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        Dim BuscaIdExterno = From sol In LqOficina.SolicitacaoCadastroPeca
                                             Where sol.IdSolicitacaoCadastro = _IdSolicitacao
                                             Select sol.IdCodExt

                        'insere novos items 

                        Dim VlrUnit As Decimal = item.Cells(3).Value
                        Dim _QtEnc As Integer = item.Cells(4).Value

                        Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_item_produto_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdItem=" & BuscaIdExterno.First & "&IdOrcamento=" & IdOrcamento & "&Descricao=" & item.Cells(1).Value & "&Qt=" & _QtEnc & "&VlrUnit=" & FormatNumber(VlrUnit, NumDigitsAfterDecimal:=2).ToString.Replace(",", ".") & "&VlrDesconto=0&SubTotal=" & FormatNumber(VlrUnit * _QtEnc, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&Aprovado=0&TipoDoItem=produto&ImgProduto=sem imagem&TipoDaAquisicao=0&IdImagemAval=" & IdImagem

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientInsereTodos = New WebClient()
                        Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

                    End If

                Next

                For Each item As DataGridViewRow In DtServicoSel.Rows

                    Dim _IdSolicitacao As Integer = item.Cells(0).Value.ToString

                    Dim BuscaIdExterno = From sol In LqBase.Servicos
                                         Where sol.IdServico = _IdSolicitacao
                                         Select sol.IdServicoInt

                    'insere novos items 

                    Dim Time As Date = Today.Date & " " & item.Cells(4).Value
                    Dim Qt As Integer = (Time.Hour * 60) + Time.Minute
                    Dim ValorUnit As Decimal = item.Cells(3).Value

                    Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_item_produto_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdItem=" & BuscaIdExterno.First & "&IdOrcamento=" & IdOrcamento & "&Descricao=" & item.Cells(1).Value & "&Qt=" & Qt & "&VlrUnit=" & FormatNumber(ValorUnit, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&VlrDesconto=0&SubTotal=" & FormatNumber(ValorUnit * Qt, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&Aprovado=0&TipoDoItem=servico&ImgProduto=sem imagem&TipoDaAquisicao=0&IdImagemAval=" & IdImagem

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientInsereTodos = New WebClient()
                    Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

                Next

                FrmNovoStudioAvaliacao.ToolStripDropDownButton1.PerformClick()

            Else

                'cria novo orcamento removendo os itens q ja foram aprovados

                'cria orçamento

                Dim BuscaCLiente = From cli In LqBase.Clientes
                                   Where cli.IdCliente = IdCliente
                                   Select cli.IdClienteExt

                Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/create_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdCliente=" & BuscaCLiente.First & "&IdVeiculo=" & IdVeiculo & "&VlrTotal=" & FormatNumber(LblTotal.Text, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&DataOrcamento=" & Today.Date & "&IdAvaliadorTerceiro=0" & "&Aprovacao=1" & "&DataAprovacao=1111-11-11" & "&HoraAprovacao=00:00:00"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagemUsuario = New WebClient()
                Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

                Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentImagemUsuario & "]")

                IdOrcamento = readImagemUsuario.Item(0).Id

                For Each item As DataGridViewRow In DtProdutoSel.Rows

                    If item.Cells(6).Value = "False" Then
                        If Not item.Cells(0).Value.ToString.StartsWith("S") Then

                            Dim _IdProduto As Integer = item.Cells(0).Value

                            Dim BuscaIdExterno = From ext In LqBase.Produtos
                                                 Where ext.IdProduto = _IdProduto
                                                 Select ext.IdProdutoExt

                            'insere novos items 

                            Dim VlrUnit As Decimal = item.Cells(3).Value
                            Dim _QtEnc As Integer = item.Cells(4).Value

                            Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_item_produto_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdItem=" & BuscaIdExterno.First & "&IdOrcamento=" & IdOrcamento & "&Descricao=" & item.Cells(1).Value & "&Qt=" & _QtEnc & "&VlrUnit=" & FormatNumber(VlrUnit, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&VlrDesconto=0&SubTotal=" & FormatNumber(VlrUnit * _QtEnc, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&Aprovado=0&TipoDoItem=produto&ImgProduto=sem imagem&TipoDaAquisicao=0&IdImagemAval=" & IdImagem

                            'carrega informações no site

                            ' Chamada sincrona
                            Dim syncClientInsereTodos = New WebClient()
                            Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

                        Else

                            Dim _IdSolicitacao As Integer = item.Cells(0).Value.ToString.Remove(0, 1)

                            Dim LqOficina As New LqOficinaDataContext
                            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                            Dim BuscaIdExterno = From sol In LqOficina.SolicitacaoCadastroPeca
                                                 Where sol.IdSolicitacaoCadastro = _IdSolicitacao
                                                 Select sol.IdCodExt

                            'insere novos items 

                            Dim VlrUnit As Decimal = item.Cells(3).Value
                            Dim _QtEnc As Integer = item.Cells(4).Value

                            Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_item_produto_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdItem=" & BuscaIdExterno.First & "&IdOrcamento=" & IdOrcamento & "&Descricao=" & item.Cells(1).Value & "&Qt=" & _QtEnc & "&VlrUnit=" & FormatNumber(VlrUnit, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&VlrDesconto=0&SubTotal=" & FormatNumber(LblSubtotalProdutos.Text, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&Aprovado=0&TipoDoItem=produto&ImgProduto=sem imagem&TipoDaAquisicao=0&IdImagemAval=" & IdImagem

                            'carrega informações no site

                            ' Chamada sincrona
                            Dim syncClientInsereTodos = New WebClient()
                            Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

                        End If
                    End If

                Next

                For Each item As DataGridViewRow In DtServicoSel.Rows

                    If item.Cells(6).Value = "false" Then

                        Dim _IdSolicitacao As Integer = item.Cells(0).Value.ToString

                        Dim BuscaIdExterno = From sol In LqBase.Servicos
                                             Where sol.IdServico = _IdSolicitacao
                                             Select sol.IdServicoInt

                        'insere novos items 

                        Dim Time As Date = Today.Date & " " & item.Cells(4).Value
                        Dim Qt As Integer = (Time.Hour * 60) + Time.Minute
                        Dim VlrUnit As Decimal = item.Cells(3).Value

                        Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_item_produto_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdItem=" & BuscaIdExterno.First & "&IdOrcamento=" & IdOrcamento & "&Descricao=" & item.Cells(1).Value & "&Qt=" & Qt & "&VlrUnit=" & FormatNumber(VlrUnit, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&VlrDesconto=0&SubTotal=" & FormatNumber(VlrUnit * Qt, NumDigitsAfterDecimal:=2).Replace(",", ".") & "&Aprovado=0&TipoDoItem=servico&ImgProduto=sem imagem&TipoDaAquisicao=0&IdImagemAval=" & IdImagem

                        'carrega informações no site

                        ' Chamada sincrona
                        Dim syncClientInsereTodos = New WebClient()
                        Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

                    End If

                Next


            End If

        Next

        'fecha o form
        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub

    Private Sub DtServico_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServico.CellContentClick

        If DtServico.Columns(e.ColumnIndex).Name = "Column5" Then

            DtServicoSel.Rows.Add(DtServico.Rows(e.RowIndex).Cells(0).Value,
                                  DtServico.Rows(e.RowIndex).Cells(1).Value,
                                  DtServico.Rows(e.RowIndex).Cells(2).Value,
                                  DtServico.Rows(e.RowIndex).Cells(3).Value, 0,
                                  ImageList1.Images(1), False)

            DtServico.Rows.RemoveAt(e.RowIndex)

        End If

    End Sub

    Private Sub DtProduto_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtProduto.CellEndEdit

    End Sub

    Public DescricaoCategoria As String

    Private Sub BtnSeparar_Click(sender As Object, e As EventArgs) Handles BtnSeparar.Click

        'popula lista de item nao aprovado
        For Each row As DataGridViewRow In DtProdutoSel.Rows
            FrmCadastrarSolicitacaoProduto.LstIdItemSelecionado.Items.Add(row.Cells(0).Value)
            FrmCadastrarSolicitacaoProduto.LstQtSel.Items.Add(row.Cells(4).Value)
        Next

        'solicita cadastro de produtos

        FrmCadastrarSolicitacaoProduto.Show(Me)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FrmCadSeviçosvb.Show(Me)

    End Sub

    Private Sub DtServicoSel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServicoSel.CellContentClick

        If DtServicoSel.Columns(e.ColumnIndex).Name = "ClmExcluirServico" Then

            Me.Cursor = Cursors.WaitCursor

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim _IdProdutoSel As Integer = DtServicoSel.Rows(e.RowIndex).Cells(0).Value

            Dim BuscaProdutos = From serv In LqBase.Servicos
                                Where serv.IdServico = _IdProdutoSel
                                Select serv.IdServico, serv.Descricao, serv.TME, serv.VlrVeda

            For Each row In BuscaProdutos.ToList

                DtServico.Rows.Add(row.IdServico, row.Descricao, row.TME, FormatCurrency(BuscaProdutos.First.VlrVeda, NumDigitsAfterDecimal:=2), ImageList1.Images(0))

                'verifica se o item ja foi selecionado para esta imagem

            Next

            CalculaServicos()

            DtServicoSel.Rows.RemoveAt(e.RowIndex)

            Me.Cursor = Cursors.Arrow

        End If
    End Sub

    Private Sub DtServicoSel_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtServicoSel.CellEndEdit
        CalculaServicos()
    End Sub
End Class