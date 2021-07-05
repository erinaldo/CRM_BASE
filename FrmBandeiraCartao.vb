Public Class FrmBandeiraCartao
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        LqFinanceiro.InsereNovaBandeira(0, 0, 0, 0, 0, TxtDescrição.Text, False)

        'busca bandeiras de cartões

        Dim BuscaBandeiras = From ban In LqFinanceiro.BandeirasFormaPG
                             Where ban.IdBandeira Like "*" And ban.IdForma = 0
                             Select ban.Descricao

        FrmNovaFormaPgSaida.CmbBandeira.Items.Clear()

        For Each it In BuscaBandeiras.ToList
            If it <> "Pagamento a vista" Then
                FrmNovaFormaPgSaida.CmbBandeira.Items.Add(it)
            End If
        Next

        FrmNovaFormaPgSaida.CmbBandeira.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub

    Private Sub TxtDescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub
End Class