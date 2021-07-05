Public Class FrmConfirmacaoValor
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmConfirmacaoValor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca solicitacoes de averiguacao

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim FimMes As Date = "01/" & Today.Month & "/" & Today.Year

        FimMes = FimMes.AddMonths(1)
        FimMes = FimMes.AddDays(-1)

        Dim BuscaAveriguacao = From aver In LqFinanceiro.AferirPagamentos
                               Where aver.Aferido = False And aver.DataInicioAlerta < FimMes
                               Select aver.IdAferir, aver.IdBalanecete

        For Each row In BuscaAveriguacao.ToList

            Dim BuscaBalancete = From bal In LqFinanceiro.BalanceteFinanceiro
                                 Where bal.IdItemBalancete = row.IdBalanecete And bal.Status = False And bal.Valor = 0
                                 Select bal.Descricao, bal.Vencimento

            If BuscaBalancete.Count > 0 Then
                DtFormas.Rows.Add(row.IdAferir, BuscaBalancete.First.Descricao, FormatCurrency(0, NumDigitsAfterDecimal:=2))
            End If

        Next

    End Sub
End Class