Public Class FrmNovoLancamentoBalancete
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmApontamentosFinanceiros.ValidaInicio()

        Me.Close()

    End Sub

    Public DataEnc As Date

    Public Sub LeIncio()

        TrFluxo.Nodes.Clear()
        DataGridView1.Rows.Clear()

        LblNomedoBeneficiario.Text = ""
        LblDataDaBaixa.Text = ""
        LblValorOriginal.Text = ""
        LblAcrescimo.Text = ""
        LblDesconto.Text = ""
        LblDescricaoComprovante.Text = ""
        LblStatus.Text = ""

        Dim DataInicio As Date = "01/" & Today.Month & "/" & Today.Year
        Dim DataFim As Date = DataInicio.AddMonths(1)
        DataFim = DataFim.AddDays(-1)

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaFinanceiro = From fin In LqFinanceiro.BalanceteFinanceiro
                              Where fin.Vencimento.Value = DataEnc
                              Select fin.Descricao, fin.IdFormaPg, fin.Identificador, fin.Vencimento, fin.Tipo, fin.IdItemBalancete, fin.Valor, fin.IdOrcamento, fin.IdVinculo, fin.DataEntradaBalanco, fin.HoraEntradaBalanco, fin.DataBaixa, fin.HoraBaixa, fin.Acrescimo, fin.Desconto
                              Order By DataEntradaBalanco Descending

        Dim LstData As New ListBox
        Dim LstIds As New ListBox

        Dim TotalCaixa As Decimal = 0
        Dim Entrada As Decimal = 0
        Dim Saida As Decimal = 0

        For Each row In BuscaFinanceiro.ToList

            Dim BuscaDescrção = From desc In LqFinanceiro.FormasPgSaida
                                Where desc.IdFormasPgSaida = row.IdFormaPg
                                Select desc.A_Vista, desc.Descricao

            If Not LstData.Items.Contains(DataEnc) Then

                TrFluxo.Nodes.Add(FormatDateTime(DataEnc, DateFormat.ShortDate))

                Dim TrFluxo2 As TreeNode = TrFluxo.Nodes(TrFluxo.Nodes.Count - 1)

                TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).ImageIndex = 4
                TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).SelectedImageIndex = 4

                'Add Entrada e saída
                TrFluxo2.Nodes.Add("Entradas - " & FormatCurrency(0, NumDigitsAfterDecimal:=2))

                TrFluxo2.Nodes(TrFluxo2.Nodes.Count - 1).ImageIndex = 2
                TrFluxo2.Nodes(TrFluxo2.Nodes.Count - 1).SelectedImageIndex = 2

                TrFluxo2.Nodes.Add("Saídas - " & FormatCurrency(0, NumDigitsAfterDecimal:=2))

                TrFluxo2.Nodes(TrFluxo2.Nodes.Count - 1).ImageIndex = 1
                TrFluxo2.Nodes(TrFluxo2.Nodes.Count - 1).SelectedImageIndex = 1

                LstData.Items.Add(DataEnc)
                LstIds.Items.Add(TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Index)

                Dim TrItens As TreeNode = TrFluxo2.Nodes(TrFluxo2.Nodes.Count - 1)
                Dim TrItens0 As TreeNode = TrFluxo2.Nodes(TrFluxo2.Nodes.Count - 2)

                If row.IdOrcamento = 0 And row.IdVinculo <> 0 Then

                    If row.Tipo = True Then

                        TrItens0.Nodes.Add("Compra.: " & row.IdVinculo _
                                      & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text &= " (pendente)"

                        End If

                        If row.IdVinculo <> row.IdOrcamento Then
                            Dim BuscaCompra = From comp In LqFinanceiro.SolicitacoesCompraFinanceiro
                                              Where comp.IdSolicitacaoCompra = row.IdVinculo
                                              Select comp.IdCotacao

                            Dim BuscaFornecCot = From comp In LqFinanceiro.Cotacoes
                                                 Where comp.IdCotacao = BuscaCompra.First
                                                 Select comp.IdFornecedor

                            Dim LqBase As New DtCadastroDataContext
                            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                            Dim BuscaFornec = From comp In LqBase.Fornecedores
                                              Where comp.IdFornecedor = BuscaFornecCot.First.Remove(0, 2)
                                              Select comp.Nome

                            DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                      BuscaFornec.First, row.Valor, False, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg,
                                      BuscaDescrção.First.Descricao)

                        Else

                            'busca categorias


                            DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                      "outros", row.Valor, False, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg,
                                      BuscaDescrção.First.Descricao)

                        End If

                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ForeColor = Color.DarkGreen

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ImageIndex = 6
                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).SelectedImageIndex = 6

                    Else

                        TrItens.Nodes.Add("Compra.: " & row.IdVinculo _
                                      & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        Dim Baixado As Boolean = True

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens.Nodes(TrItens.Nodes.Count - 1).Text &= " (pendente)"
                            Baixado = False

                        End If

                        If row.IdVinculo <> row.IdOrcamento Then

                            Dim BuscaCompra = From comp In LqFinanceiro.SolicitacoesCompraFinanceiro
                                              Where comp.IdSolicitacaoCompra = row.IdVinculo
                                              Select comp.IdCotacao

                            Dim BuscaFornecCot = From comp In LqFinanceiro.Cotacoes
                                                 Where comp.IdCotacao = BuscaCompra.First
                                                 Select comp.IdFornecedor

                            Dim LqBase As New DtCadastroDataContext
                            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                            Dim BuscaFornec = From comp In LqBase.Fornecedores
                                              Where comp.IdFornecedor = BuscaFornecCot.First.Remove(0, 2)
                                              Select comp.Nome

                            DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                          BuscaFornec.First, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)

                        Else

                            DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                          "Outros", row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, "")

                        End If

                        TotalCaixa -= row.Valor
                        Saida -= row.Valor

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ForeColor = Color.DarkRed
                        TrItens.Nodes(TrItens.Nodes.Count - 1).ImageIndex = 7
                        TrItens.Nodes(TrItens.Nodes.Count - 1).SelectedImageIndex = 7

                    End If

                ElseIf row.IdOrcamento > 0 And row.IdVinculo = 0 Then

                    If row.Tipo = True Then

                        TrItens0.Nodes.Add("ORC_ " & row.IdOrcamento _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        Dim Baixado As Boolean = True

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text &= " (pendente)"
                            Baixado = False

                        End If

                        If row.IdVinculo <> row.IdOrcamento Then

                            DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)

                        Else

                            DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)

                        End If

                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ForeColor = Color.DarkGreen

                        Dim BuscaFormas = From frm In LqFinanceiro.FormaRecebimentoBalancete
                                          Where frm.IdOrcamento = row.IdOrcamento
                                          Select frm.IdFormaOrcamento, frm.Valor, frm.ValorREcebido, frm.ValorTroco

                        Dim TrFormas As TreeNode = TrItens0.Nodes(TrItens0.Nodes.Count - 1)

                        For Each it In BuscaFormas.ToList

                            Dim BuscaFormaPg = From frm In LqFinanceiro.FormasPgEntrada
                                               Where frm.IdFormasPgEntrada = it.IdFormaOrcamento
                                               Select frm.Descricao

                            TrFormas.Nodes.Add(BuscaFormaPg.First & " - " & FormatCurrency(it.Valor, NumDigitsAfterDecimal:=2))

                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).ImageIndex = 5
                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).SelectedImageIndex = 5

                        Next

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ImageIndex = 6
                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).SelectedImageIndex = 6

                    End If

                ElseIf row.IdOrcamento = row.IdVinculo Then

                    If row.Tipo = True Then

                        TrItens0.Nodes.Add(row.Descricao _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        Dim Baixado As Boolean = True

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text &= " (pendente)"
                            Baixado = False

                        End If

                        If row.IdVinculo <> row.IdOrcamento Then

                            DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)

                        Else

                            DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, "")

                        End If

                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ForeColor = Color.DarkGreen

                        Dim BuscaFormas = From frm In LqFinanceiro.FormaRecebimentoBalancete
                                          Where frm.IdOrcamento = row.IdOrcamento
                                          Select frm.IdFormaOrcamento, frm.Valor, frm.ValorREcebido, frm.ValorTroco

                        Dim TrFormas As TreeNode = TrItens0.Nodes(TrItens0.Nodes.Count - 1)

                        For Each it In BuscaFormas.ToList

                            Dim BuscaFormaPg = From frm In LqFinanceiro.FormasPgEntrada
                                               Where frm.IdFormasPgEntrada = it.IdFormaOrcamento
                                               Select frm.Descricao

                            TrFormas.Nodes.Add(BuscaFormaPg.First & " - " & FormatCurrency(it.Valor, NumDigitsAfterDecimal:=2))

                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).ImageIndex = 5
                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).SelectedImageIndex = 5

                        Next

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ImageIndex = 6
                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).SelectedImageIndex = 6

                    Else

                        TrItens.Nodes.Add(row.Descricao _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        Dim Baixado As Boolean = True

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens.Nodes(TrItens.Nodes.Count - 1).Text &= " (pendente)"
                            Baixado = False

                        End If

                        If row.IdVinculo <> row.IdOrcamento Then

                            DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)

                        Else

                            If BuscaDescrção.Count > 0 Then
                                DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)
                            Else
                                DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                          row.IdVinculo, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, "")

                            End If

                        End If

                        TotalCaixa -= row.Valor
                        Saida += row.Valor

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ForeColor = Color.DarkRed

                        Dim BuscaFormas = From frm In LqFinanceiro.FormaRecebimentoBalancete
                                          Where frm.IdOrcamento = row.IdOrcamento
                                          Select frm.IdFormaOrcamento, frm.Valor, frm.ValorREcebido, frm.ValorTroco

                        Dim TrFormas As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)

                        For Each it In BuscaFormas.ToList

                            Dim BuscaFormaPg = From frm In LqFinanceiro.FormasPgEntrada
                                               Where frm.IdFormasPgEntrada = it.IdFormaOrcamento
                                               Select frm.Descricao

                            TrFormas.Nodes.Add(BuscaFormaPg.First & " - " & FormatCurrency(it.Valor, NumDigitsAfterDecimal:=2))

                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).ImageIndex = 5
                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).SelectedImageIndex = 5

                        Next

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ImageIndex = 7
                        TrItens.Nodes(TrItens.Nodes.Count - 1).SelectedImageIndex = 7

                    End If

                End If

                TrFluxo2.Nodes(0).Text = "Entradas " & FormatCurrency(Entrada, NumDigitsAfterDecimal:=2)

                TrFluxo2.Nodes(1).Text = "Saídas " & FormatCurrency(Saida, NumDigitsAfterDecimal:=2)

            Else

                Dim _Index As Integer = 0

                For i As Integer = 0 To LstData.Items.Count - 1

                    If LstData.Items(i).ToString = row.DataEntradaBalanco Then

                        _Index = LstIds.Items(i).ToString

                    End If

                Next

                Dim TrItens As TreeNode = TrFluxo.Nodes(_Index).Nodes(0)
                Dim TrItens0 As TreeNode = TrFluxo.Nodes(_Index).Nodes(1)

                If row.IdOrcamento = 0 And row.IdVinculo <> 0 Then

                    TrItens.Nodes.Add("Compra.: " & row.IdVinculo _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                    Dim Baixado As Boolean = True

                    If row.DataBaixa = "1111-11-11" Then

                        TrItens.Nodes(TrItens.Nodes.Count - 1).Text &= " (pendente)"
                        Baixado = False

                    End If

                    If row.IdOrcamento <> row.IdVinculo Then
                        DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                      row.IdVinculo, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, BuscaDescrção.First.Descricao)
                    Else
                        DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                      row.IdVinculo, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, "")
                    End If

                    If row.Tipo = True Then

                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ForeColor = Color.DarkGreen

                    Else

                        TotalCaixa -= row.Valor
                        Saida += row.Valor

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ForeColor = Color.DarkRed
                        TrItens.Nodes(TrItens.Nodes.Count - 1).ImageIndex = 1
                        TrItens.Nodes(TrItens.Nodes.Count - 1).SelectedImageIndex = 1

                    End If

                ElseIf row.IdOrcamento <> 0 And row.IdVinculo = 0 Then

                    If row.Tipo = True Then

                        TrItens0.Nodes.Add("ORC_ " & row.IdOrcamento _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ForeColor = Color.DarkGreen

                        Dim BuscaFormas = From frm In LqFinanceiro.FormaRecebimentoBalancete
                                          Where frm.IdOrcamento = row.IdOrcamento
                                          Select frm.IdFormaOrcamento, frm.Valor, frm.ValorREcebido, frm.ValorTroco

                        Dim TrFormas As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)

                        For Each it In BuscaFormas.ToList

                            Dim BuscaFormaPg = From frm In LqFinanceiro.FormasPgEntrada
                                               Where frm.IdFormasPgEntrada = it.IdFormaOrcamento
                                               Select frm.Descricao

                            TrFormas.Nodes.Add(BuscaFormaPg.First & " - " & FormatCurrency(it.Valor, NumDigitsAfterDecimal:=2))

                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).ImageIndex = 5
                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).SelectedImageIndex = 5

                        Next

                    End If

                    TrItens.Nodes(TrItens.Nodes.Count - 1).ImageIndex = 2
                    TrItens.Nodes(TrItens.Nodes.Count - 1).SelectedImageIndex = 2

                ElseIf row.IdOrcamento = row.IdVinculo Then

                    If row.Tipo = True Then

                        TrItens.Nodes.Add(row.Descricao _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        Dim Baixado As Boolean = True

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens.Nodes(TrItens.Nodes.Count - 1).Text &= " (pendente)"
                            Baixado = False

                        End If

                        DataGridView1.Rows.Add(TrItens.Nodes(TrItens.Nodes.Count - 1).Text,
                                  row.IdVinculo, row.Valor, Baixado, True, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, "")


                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ForeColor = Color.DarkGreen

                        Dim BuscaFormas = From frm In LqFinanceiro.FormaRecebimentoBalancete
                                          Where frm.IdOrcamento = row.IdOrcamento
                                          Select frm.IdFormaOrcamento, frm.Valor, frm.ValorREcebido, frm.ValorTroco

                        Dim TrFormas As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)

                        For Each it In BuscaFormas.ToList

                            Dim BuscaFormaPg = From frm In LqFinanceiro.FormasPgEntrada
                                               Where frm.IdFormasPgEntrada = it.IdFormaOrcamento
                                               Select frm.Descricao

                            TrFormas.Nodes.Add(BuscaFormaPg.First & " - " & FormatCurrency(it.Valor, NumDigitsAfterDecimal:=2))

                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).ImageIndex = 5
                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).SelectedImageIndex = 5

                        Next

                        TrItens.Nodes(TrItens.Nodes.Count - 1).ImageIndex = 6
                        TrItens.Nodes(TrItens.Nodes.Count - 1).SelectedImageIndex = 6

                    Else

                        TrItens0.Nodes.Add(row.Descricao _
                                  & " - " & FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2))

                        Dim Baixado As Boolean = True

                        If row.DataBaixa = "1111-11-11" Then

                            TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text &= " (pendente)"
                            Baixado = False

                        End If

                        DataGridView1.Rows.Add(TrItens0.Nodes(TrItens0.Nodes.Count - 1).Text,
                                  row.IdVinculo, row.Valor, Baixado, False, row.Acrescimo, row.Desconto, row.Identificador, row.IdItemBalancete, row.IdFormaPg, "")

                        TotalCaixa += row.Valor
                        Entrada += row.Valor

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ForeColor = Color.DarkRed

                        Dim BuscaFormas = From frm In LqFinanceiro.FormaRecebimentoBalancete
                                          Where frm.IdOrcamento = row.IdOrcamento
                                          Select frm.IdFormaOrcamento, frm.Valor, frm.ValorREcebido, frm.ValorTroco

                        Dim TrFormas As TreeNode = TrItens0.Nodes(TrItens0.Nodes.Count - 1)

                        For Each it In BuscaFormas.ToList

                            Dim BuscaFormaPg = From frm In LqFinanceiro.FormasPgEntrada
                                               Where frm.IdFormasPgEntrada = it.IdFormaOrcamento
                                               Select frm.Descricao

                            TrFormas.Nodes.Add(BuscaFormaPg.First & " - " & FormatCurrency(it.Valor, NumDigitsAfterDecimal:=2))

                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).ImageIndex = 5
                            TrFormas.Nodes(TrFormas.Nodes.Count - 1).SelectedImageIndex = 5

                        Next

                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).ImageIndex = 7
                        TrItens0.Nodes(TrItens0.Nodes.Count - 1).SelectedImageIndex = 7

                    End If

                End If

            End If

        Next

        If TrFluxo.Nodes.Count = 0 Then
            TrFluxo.Nodes.Add(DataEnc)
        End If
        TrFluxo.ExpandAll()

    End Sub
    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TrFluxo_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrFluxo.AfterSelect

        LblNomedoBeneficiario.Text = ""
        LblDataDaBaixa.Text = ""
        LblValorOriginal.Text = ""
        LblAcrescimo.Text = ""
        LblDesconto.Text = ""
        LblDescricaoComprovante.Text = ""
        LblStatus.Text = ""
        LblFormaPg.Text = ""

        'procura no datagridview

        For Each row As DataGridViewRow In DataGridView1.Rows

            If row.Cells(0).Value = TrFluxo.SelectedNode.Text Then

                LblNomedoBeneficiario.Text = row.Cells(1).Value
                LblValorOriginal.Text = FormatCurrency(row.Cells(2).Value, NumDigitsAfterDecimal:=2)
                LblAcrescimo.Text = FormatCurrency(row.Cells(5).Value, NumDigitsAfterDecimal:=2)
                LblDesconto.Text = FormatCurrency(row.Cells(6).Value, NumDigitsAfterDecimal:=2)
                LblDescricaoComprovante.Text = row.Cells(7).Value
                LblFormaPg.Text = row.Cells(10).Value
                LblIdItem.Text = row.Cells(8).Value

                If row.Cells(3).Value = True Then

                    LblDataDaBaixa.Text = "pagamento realizado"

                    BtnBaixarPagamento.Enabled = False

                Else

                    LblDataDaBaixa.Text = "aguardando pagamento"

                    If DataEnc < Today.Date Then

                        LblDataDaBaixa.Text = "pagamento fora da data"

                    End If

                    BtnBaixarPagamento.Enabled = True

                End If

                If row.Cells(4).Value = True Then

                    LblStatus.Text = "Entrada de valores"
                    LblStatus.ForeColor = Color.DarkGreen

                Else

                    LblStatus.Text = "Saída de valores"
                    LblStatus.ForeColor = Color.DarkRed


                End If

            End If

        Next

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        FrmNovoLancamento.DataEnc = DataEnc
        FrmNovoLancamento.Show(Me)

    End Sub

    Private Sub FrmNovoLancamentoBalancete_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnBaixarPagamento_Click(sender As Object, e As EventArgs) Handles BtnBaixarPagamento.Click

        If TrFluxo.SelectedNode.Parent.Index = 0 Then
            FrmBaixarLançamento.LblValorOriginal.Text = LblValorOriginal.Text
            FrmBaixarLançamento.LblFormaPG.Text = LblFormaPg.Text
            FrmBaixarLançamento.IdItemBalancete = LblIdItem.Text
            FrmBaixarLançamento._Tipo = True
            FrmBaixarLançamento.DataEnc = TrFluxo.Nodes(0).Text

            FrmBaixarLançamento.Show(Me)
        Else
            FrmBaixarLançamento.LblValorOriginal.Text = LblValorOriginal.Text
            FrmBaixarLançamento.LblFormaPG.Text = LblFormaPg.Text
            FrmBaixarLançamento.IdItemBalancete = LblIdItem.Text
            FrmBaixarLançamento._Tipo = False
            FrmBaixarLançamento.DataEnc = TrFluxo.Nodes(0).Text

            FrmBaixarLançamento.Show(Me)
        End If
    End Sub
End Class