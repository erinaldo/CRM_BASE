Public Class FrmRecebimentoEsperado
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub DtEsperados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellContentClick

        If DtEsperados.Columns(e.ColumnIndex).Name = "ClmSelecionado" Then

            If CType(DtEsperados.Item("ClmSelecionado", e.RowIndex).Value, Boolean) = True Then
                DtEsperados.Item(e.ColumnIndex, e.RowIndex).Value = False
            Else
                DtEsperados.Item(e.ColumnIndex, e.RowIndex).Value = True
            End If

            BttFechar.Enabled = False

            For Each linha As DataGridViewRow In DtEsperados.Rows

                Dim ValorEnc As Boolean = linha.Cells(0).Value

                If ValorEnc = True Then
                    BttFechar.Enabled = True
                End If

            Next

            If DtEsperados.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                BttFechar.Enabled = True
            Else
                BttFechar.Enabled = False
            End If

        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        'envia os itens para o grid principal

        For Each row As DataGridViewRow In DtEsperados.Rows

            If row.Cells(1).Value.ToString.StartsWith("S") Then

                If row.Cells(0).Value = True Then

                    Dim _idSolicitacao As Integer = row.Cells(1).Value.ToString.Remove(0, 1)
                    Dim _idCompra As Integer = row.Cells(4).Value

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaSolicitacaoCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                              Where cad.IdSolicitacaoCadastro = _idSolicitacao
                                              Select cad.Descricao, cad.PartNumber

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaSolicitacaoCompra = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                                 Where sol.IdSolicitacaoCompra = _idCompra
                                                 Select sol.Qt, sol.IdCotacao

                    Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                       Where cot.IdCotacao = BuscaSolicitacaoCompra.First.IdCotacao
                                       Select cot.ValorCotado, cot.PrazoEntrega, cot.CodReferencia

                    Dim _ValorTrans As Decimal = BuscaCotacao.First.ValorCotado
                    Dim CodFornec As String = BuscaCotacao.First.CodReferencia


                    FrmProdutosNfRecebimento.DtEsperados.Rows.Add(Nothing, row.Cells(1).Value.ToString, CodFornec, BuscaSolicitacaoCad.First.Descricao, "", "", "",
                                                              BuscaSolicitacaoCompra.First.Qt, FormatCurrency(BuscaCotacao.First.ValorCotado, NumDigitsAfterDecimal:=2),
                                                              FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(BuscaCotacao.First.ValorCotado * BuscaSolicitacaoCompra.First.Qt, NumDigitsAfterDecimal:=2),
                                                              FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", My.Resources.Cancel_40972, My.Resources.estoque_terceirizado)

                End If

            Else

                If row.Cells(0).Value = True Then

                    Dim _idSolicitacao As Integer = row.Cells(1).Value.ToString
                    Dim _idCompra As Integer = row.Cells(4).Value
                    Dim _idFornecedor As String = FrmProdutosNfRecebimento.LblCodFornec.Text.Remove(0, 2)

                    Dim LqBase As New DtCadastroDataContext
                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim BuscaSolicitacaoCad = From cad In LqBase.Produtos
                                              Where cad.IdProduto = _idSolicitacao
                                              Select cad.Descricao, cad.CodFabricante, cad.NCM, cad.CodBarras

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaSolicitacaoCompra = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                                 Where sol.IdSolicitacaoCompra = _idCompra
                                                 Select sol.Qt, sol.IdCotacao

                    Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                       Where cot.IdCotacao = BuscaSolicitacaoCompra.First.IdCotacao
                                       Select cot.ValorCotado, cot.PrazoEntrega, cot.CodReferencia

                    Dim _ValorTrans As Decimal = BuscaCotacao.First.ValorCotado.ToString.Replace(".", ",")

                    'busca vinculo com o fornecedor

                    Dim BuscaFornecedor = From fornec In LqBase.VinculoProdutoFornecedor
                                          Where fornec.IdProduto = _idSolicitacao And fornec.IdForncedor Like _idFornecedor
                                          Select fornec.CodFornecedor

                    Dim CodFornec As String = ""

                    If BuscaFornecedor.Count > 0 Then
                        CodFornec = BuscaFornecedor.First
                    Else
                        CodFornec = BuscaCotacao.First.CodReferencia
                    End If

                    FrmProdutosNfRecebimento.DtEsperados.Rows.Add(Nothing, row.Cells(1).Value, CodFornec, BuscaSolicitacaoCad.First.Descricao, BuscaSolicitacaoCad.First.NCM, BuscaSolicitacaoCad.First.CodBarras, "",
                                                              BuscaSolicitacaoCompra.First.Qt, FormatCurrency(BuscaCotacao.First.ValorCotado, NumDigitsAfterDecimal:=2),
                                                              FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(BuscaCotacao.First.ValorCotado * BuscaSolicitacaoCompra.First.Qt, NumDigitsAfterDecimal:=2),
                                                              FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", My.Resources.Cancel_40972, My.Resources.estoque_terceirizado)

                End If

            End If

        Next

        'calcula totais

        Dim TotalProd As Decimal = 0

        For Each rows As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

            TotalProd += rows.Cells(10).Value

        Next

        FrmProdutosNfRecebimento.LblProdutos.Text = FormatCurrency(TotalProd, NumDigitsAfterDecimal:=2)

        Me.Close()

    End Sub

    Private Sub FrmRecebimentoEsperado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DtEsperados_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellEndEdit

        For Each linha As DataGridViewRow In DtEsperados.Rows

            If linha.Cells(0).Value = True Then
                BttFechar.Enabled = True
            End If

        Next

    End Sub


End Class