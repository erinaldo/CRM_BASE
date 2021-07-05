Public Class FrmMovimentarFluxo

    Dim LstIdCOnta01 As New ListBox
    Dim LstIdCOnta02 As New ListBox

    Public Sub LeIncio()

        'busca caixas

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaCaixa = From caix In LqFinanceiro.Carteira
                         Where caix.IdCarteira Like "*"
                         Select caix.Descricao, caix.IdCarteira

        LstIdCOnta01.Items.Clear()
        CmbContaDestino.Items.Clear()

        For Each row In BuscaCaixa.ToList
            LstIdCOnta01.Items.Add(row.IdCarteira)
            CmbContaVinculada.Items.Add(row.Descricao)
        Next

        CmbContaVinculada.Enabled = True

    End Sub

    Public _Tipo As Boolean = False

    Private Sub FrmMovimentarFluxo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LeIncio()

    End Sub

    Private Sub CmbContaVinculada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbContaVinculada.SelectedIndexChanged

        'busca total no cofre

        If CmbContaVinculada.Items.Contains(CmbContaVinculada.Text) Then

            'busca saldo
            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaFormasParaConta = From frmpg In LqFinanceiro.FormasPgSaida
                                       Where frmpg.IdCarteira = LstIdCOnta01.Items(CmbContaVinculada.SelectedIndex).ToString
                                       Select frmpg.IdFormasPgSaida
            Dim Saldo As Decimal = 0

                For Each it0 In BuscaFormasParaConta.ToList

                    'conta os balancetes com essa forma

                    Dim BuscaBalancete = From bal In LqFinanceiro.BalanceteFinanceiro
                                         Where bal.IdFormaPg = it0 And bal.Tipo = False And bal.Status = True
                                         Select bal.Valor

                    For Each it In BuscaBalancete.ToList

                        Saldo -= it

                    Next

                Next

                Dim BuscaFormasParaContaEnt = From frmpg In LqFinanceiro.FormasPgEntrada
                                              Where frmpg.IdCarteira = LstIdCOnta01.Items(CmbContaVinculada.SelectedIndex).ToString
                                              Select frmpg.IdFormasPgEntrada

                For Each it0 In BuscaFormasParaContaEnt.ToList

                    'conta os balancetes com essa forma

                    Dim BuscaBalanceteEnt = From bal In LqFinanceiro.BalanceteFinanceiro
                                            Where bal.IdFormaPg = it0 And bal.Tipo = True And bal.Status = True
                                            Select bal.Valor

                    For Each it In BuscaBalanceteEnt.ToList

                        Saldo += it

                    Next

                Next


                LblSaldoOrigem.Text = FormatCurrency(Saldo, NumDigitsAfterDecimal:=2)

                'busca caixas menos esse

                Dim BuscaCaixa02 = From caix In LqFinanceiro.Carteira
                                   Where caix.IdCarteira <> LstIdCOnta01.Items(CmbContaVinculada.SelectedIndex).ToString
                                   Select caix.IdCarteira, caix.Descricao

                LstIdCOnta02.Items.Clear()
                CmbContaDestino.Items.Clear()

                For Each it In BuscaCaixa02.ToList
                    LstIdCOnta02.Items.Add(it.IdCarteira)
                    CmbContaDestino.Items.Add(it.Descricao)
                Next

                CmbContaDestino.Enabled = True

            End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmBalancete.ValidaInicio()

        Me.Close()

    End Sub

    Private Sub CmbContaDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbContaDestino.SelectedIndexChanged

        If CmbContaDestino.Items.Contains(CmbContaDestino.Text) Then

            'busca saldo
            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaFormasParaConta = From frmpg In LqFinanceiro.FormasPgSaida
                                       Where frmpg.IdCarteira = LstIdCOnta02.Items(CmbContaDestino.SelectedIndex).ToString
                                       Select frmpg.IdFormasPgSaida

            'conta os balancetes com essa forma

            Dim BuscaBalancete = From bal In LqFinanceiro.BalanceteFinanceiro
                                 Where bal.IdFormaPg = BuscaFormasParaConta.First And bal.Tipo = False And bal.Status = True
                                 Select bal.Valor

            Dim Saldo As Decimal = 0

            For Each it In BuscaBalancete.ToList

                Saldo -= it

            Next

            Dim BuscaFormasParaContaEnt = From frmpg In LqFinanceiro.FormasPgEntrada
                                          Where frmpg.IdCarteira = LstIdCOnta02.Items(CmbContaDestino.SelectedIndex).ToString
                                          Select frmpg.IdFormasPgEntrada

            If BuscaFormasParaConta.Count > 0 Then

                'conta os balancetes com essa forma

                Dim BuscaBalanceteEnt = From bal In LqFinanceiro.BalanceteFinanceiro
                                        Where bal.IdFormaPg = BuscaFormasParaContaEnt.First And bal.Tipo = True And bal.Status = True
                                        Select bal.Valor

                For Each it In BuscaBalanceteEnt.ToList

                    Saldo += it

                Next

            End If

            LblSaldoConta02.Text = FormatCurrency(Saldo)

            TxtDesconto.Enabled = True

        End If

    End Sub

    Private Sub TxtDesconto_TextChanged(sender As Object, e As EventArgs) Handles TxtDesconto.TextChanged

        If TxtDesconto.Text = "" Then
            TxtDesconto.Text = 0
            TxtDesconto.SelectAll()
        End If

        If TxtDesconto.Text <> "" Then

            Dim Vlr As Decimal = TxtDesconto.Text
            Dim Sld As Decimal = LblSaldoOrigem.Text

            If Vlr <= Sld Then
                BttSalvarFormaDePgSaida.Enabled = True
            Else

                TxtDesconto.Text = Sld

            End If

        Else

            BttSalvarFormaDePgSaida.Enabled = False

        End If

    End Sub

    Private Sub TxtDesconto_GotFocus(sender As Object, e As EventArgs) Handles TxtDesconto.GotFocus

        TxtDesconto.Text = FormatNumber(TxtDesconto.Text, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub TxtDesconto_LostFocus(sender As Object, e As EventArgs) Handles TxtDesconto.LostFocus

        Try

            Dim _ValorINserido As Decimal = TxtDesconto.Text

            TxtDesconto.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtDesconto.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub BttSalvarFormaDePgSaida_Click(sender As Object, e As EventArgs) Handles BttSalvarFormaDePgSaida.Click

        'busca forma pg em dinheiro

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaForm01 = From frm In LqFinanceiro.FormasPgSaida
                          Where frm.IdCarteira = LstIdCOnta01.Items(CmbContaVinculada.SelectedIndex).ToString And frm.Descricao Like "transferencia"
                          Select frm.IdFormasPgSaida

        'insere saida no balancete

        LqFinanceiro.InsereNovaEntradaBalancete(0, TxtDesconto.Text, 0, 0, Today.Date, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, False, BuscaForm01.First, "Transferencias de valores", "Transf. destino: " & CmbContaDestino.Text, "Transferências internas")

        Dim BuscaForm02 = From frm In LqFinanceiro.FormasPgEntrada
                          Where frm.IdCarteira = LstIdCOnta02.Items(CmbContaDestino.SelectedIndex).ToString And frm.Descricao Like "transferencia"
                          Select frm.IdFormasPgEntrada

        'insere saida no balancete

        LqFinanceiro.InsereNovaEntradaBalancete(0, TxtDesconto.Text, 0, 0, Today.Date, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, True, BuscaForm02.First, "Transferencias de valores", "Transf. origem: " & CmbContaVinculada.Text, "Transferências internas")

        FrmBalancete.ValidaInicio()

        Me.Close()

    End Sub

    Private Sub BttNovaConta_Click(sender As Object, e As EventArgs) Handles BttNovaConta.Click

        FrmNovaConta.Show(Me)

    End Sub
End Class