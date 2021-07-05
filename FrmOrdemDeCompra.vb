Imports System.Net
Imports Newtonsoft.Json

Public Class FrmOrdemDeCompra
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        Me.Close()

    End Sub

    Private Sub FrmOrdemDeCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If FrmOtasOrdensCompra.Categoria <> "Estoque" Then
            Dim BuscaProdutos = From serv In LqBase.Produtos
                                Where serv.IdProduto Like "*" And serv.Categoria Like FrmOtasOrdensCompra.Categoria
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

                DtProduto.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), EstoqueDisp, ImageList1.Images(0))

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

                DtProduto.Rows.Add("S" & row.IdSolicitacaoCadastro, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), 0, ImageList1.Images(0))

            Next

        Else
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

                DtProduto.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), EstoqueDisp, ImageList1.Images(0))

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

                DtProduto.Rows.Add("S" & row.IdSolicitacaoCadastro, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), 0, ImageList1.Images(0))

            Next

        End If

    End Sub

    Private Sub BtnSeparar_Click(sender As Object, e As EventArgs) Handles BtnSeparar.Click

        'solicita cadastro de produtos

        FrmCadastrarSolicitacaoProduto.Show(Me)

    End Sub

    Public Sub CarregaProdutos()

        DtProduto.Rows.Clear()

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

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

            DtProduto.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), EstoqueDisp, ImageList1.Images(0))

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

            DtProduto.Rows.Add("S" & row.IdSolicitacaoCadastro, row.Descricao, row.Fabricante, FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2), 0, ImageList1.Images(0))

        Next

    End Sub

    Private Sub DtProduto_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProduto.CellContentClick

        If DtProduto.Columns(e.ColumnIndex).Name = "ClmInsereProduto" Then

            DtProdutoSel.Rows.Add(DtProduto.Rows(e.RowIndex).Cells(0).Value,
                                  DtProduto.Rows(e.RowIndex).Cells(1).Value,
                                  DtProduto.Rows(e.RowIndex).Cells(2).Value,
                                  DtProduto.Rows(e.RowIndex).Cells(3).Value, 0,
                                  ImageList1.Images(1))

            DtProduto.Rows.RemoveAt(e.RowIndex)

        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutoSel.CellContentClick

        If DtProdutoSel.Columns(e.ColumnIndex).Name = "ClmExcluirProduto_n" Then

            Me.Cursor = Cursors.WaitCursor

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

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

            DtProdutoSel.Rows.RemoveAt(e.RowIndex)

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'insere ordens de compra

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        For Each row As DataGridViewRow In DtProdutoSel.Rows

            Dim IdSel As String = row.Cells(0).Value

            If IdSel.StartsWith("S") Then
                Dim Qt As Integer = row.Cells(4).Value

                'busca cotaçoes ativas
                IdSel = IdSel.Remove(0, 1)

                Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = IdSel And cot.DataCotacao.Value.Date <= Today.Date.AddDays(-7)
                                   Select cot.IdCotacao

                If BuscaCotacao.Count > 0 Then
                    LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(0, Qt, BuscaCotacao.First, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, IdSel.Remove(0, 1))
                Else

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim _Markup As Decimal = 0

                    'busca markup do produto
                    Dim BuscaDados = From dad In LqOficina.SolicitacaoCadastroPeca
                                     Where dad.IdSolicitacaoCadastro = IdSel
                                     Select dad.Markup

                    If BuscaDados.Count > 0 Then

                        _Markup = BuscaDados.First

                    End If

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, IdSel, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qt, _Markup, 0)

                    LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(0, Qt, BuscaCotacao.First, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, IdSel.Remove(0, 1))

                End If

            Else

                Dim Qt As Integer = row.Cells(4).Value

                Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = IdSel And cot.DataCotacao.Value.Date <= Today.Date.AddDays(-7)
                                   Select cot.IdCotacao

                If BuscaCotacao.Count > 0 Then
                    LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(IdSel, Qt, BuscaCotacao.First, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)
                Else

                    Dim LqBase As New DtCadastroDataContext
                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim _Markup As Decimal = 0

                    'busca markup do produto
                    Dim BuscaDados = From dad In LqBase.Produtos
                                     Where dad.IdProduto = IdSel
                                     Select dad.Markup

                    If BuscaDados.Count > 0 Then

                        _Markup = BuscaDados.First

                    End If

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdSel, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qt, _Markup, 0)

                    LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(0, Qt, BuscaCotacao.First, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)

                End If

            End If

        Next

        FrmOtasOrdensCompra.CarregaInicio()

        Me.Close()

    End Sub
End Class