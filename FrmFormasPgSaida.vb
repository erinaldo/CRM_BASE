Public Class FrmFormasPgSaida
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then

            CkModoPg.Enabled = True

        Else

            CkModoPg.Enabled = False
            CkModoPg.Checked = True
            CmbContaVinculada.Text = ""
            CmbContaVinculada.Items.Clear()

        End If

    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Public IdOrientador As Integer = 0

    Private Sub BttSalvarFormaDePgSaida_Click(sender As Object, e As EventArgs) Handles BttSalvarFormaDePgSaida.Click

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim Dias As Boolean = True

        If RdbMeses.Checked = True Then
            Dias = False
        End If

        LqFinanceiro.InsereNovaFormaPgSaida(TxtDescrição.Text, CkModoPg.CheckState, 0, NmIntervalo.Value, Dias, NmParcelas.Value, LstIdCarteira.Items(CmbContaVinculada.SelectedIndex).ToString, False, "", 0, "", 0, 0, "", 0, 0, False, False)

        'carrega fornecedores na lista

        If IdOrientador = 0 Then

            Dim BuscaFormas = From fm In LqFinanceiro.FormasPgSaida
                              Where fm.IdFormasPgSaida Like "*" And fm.UsoInterno = False
                              Select fm.Descricao, fm.A_Vista, fm.IdFormasPgSaida

            FrmNovoFornecedor.LstAvista.Items.Clear()
            FrmNovoFornecedor.LstIdFormas.Items.Clear()
            FrmNovoFornecedor.CmbFormaPagamento.Items.Clear()

            For Each row In BuscaFormas.ToList

                FrmNovoFornecedor.LstAvista.Items.Add(row.A_Vista)
                FrmNovoFornecedor.LstIdFormas.Items.Add(row.IdFormasPgSaida)
                FrmNovoFornecedor.CmbFormaPagamento.Items.Add(row.Descricao)

            Next

            FrmNovoFornecedor.CmbFormaPagamento.SelectedItem = txtdescrição.Text

        End If

        'carrega no foco de origem

        Me.Close()

    End Sub

    Private Sub TxtDescrição_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDescrição.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttSalvarFormaDePgSaida.PerformClick()

        End If

    End Sub

    Private Sub FrmFormasPgSaida_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtDescrição.Focus()

    End Sub

    Dim LstIdCarteira As New ListBox

    Private Sub CkModoPg_CheckedChanged(sender As Object, e As EventArgs) Handles CkModoPg.CheckedChanged

        If CkModoPg.Checked = False Then

            NmIntervalo.Enabled = True

            RdbDias.Enabled = True
            RdbMeses.Checked = True
            RdbMeses.Enabled = True

            NmParcelas.Enabled = True

            'busca carteiras

            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
            Dim BuscaCarteira = From cart In LqFinanceiro.Carteira
                                Where cart.IdCarteira Like "*"
                                Select cart.Descricao, cart.IdCarteira

            CmbContaVinculada.Items.Clear()
            LstIdCarteira.Items.Clear()

            For Each it In BuscaCarteira.ToList
                CmbContaVinculada.Items.Add(it.Descricao)
                LstIdCarteira.Items.Add(it.IdCarteira)
            Next

        Else
            NmIntervalo.Enabled = False
            NmIntervalo.Value = 1

            RdbDias.Enabled = False
            RdbMeses.Checked = False
            RdbMeses.Enabled = False

            NmParcelas.Enabled = False
            NmParcelas.Value = 1
        End If

    End Sub

    Private Sub TxtDescrição_LostFocus(sender As Object, e As EventArgs) Handles TxtDescrição.LostFocus

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        Dim BuscaCarteira = From cart In LqFinanceiro.Carteira
                            Where cart.IdCarteira Like "*"
                            Select cart.Descricao, cart.IdCarteira

        CmbContaVinculada.Items.Clear()
        LstIdCarteira.Items.Clear()

        For Each it In BuscaCarteira.ToList
            CmbContaVinculada.Items.Add(it.Descricao)
            LstIdCarteira.Items.Add(it.IdCarteira)
        Next

    End Sub

    Private Sub CmbContaVinculada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbContaVinculada.SelectedIndexChanged

        If CmbContaVinculada.Items.Contains(CmbContaVinculada.Text) Then
            BttSalvarFormaDePgSaida.Enabled = True
        Else
            BttSalvarFormaDePgSaida.Enabled = False
        End If
    End Sub
End Class