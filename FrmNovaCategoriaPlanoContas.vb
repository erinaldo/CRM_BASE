Public Class FrmNovaCategoriaPlanoContas
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtDescricao_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricao.TextChanged
        If TxtDescricao.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca categorias

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim _Tipo As Boolean = False

        If FrmNovoLancamento.RdbValorReceber.Checked = True Then
            _Tipo = True
        End If

        LqFinanceiro.InsereCategoriaPlanoContas(TxtDescricao.Text, _Tipo)

        Dim BuscaCategorias = From cat In LqFinanceiro.CategoriaPlanoContas
                              Where cat.IdCategoriaPlano Like "*" And cat.Tipo = _Tipo
                              Select cat.Categoria

        FrmNovoLancamento.CmbCategoria.Items.Clear()

        For Each row In BuscaCategorias.ToList
            FrmNovoLancamento.CmbCategoria.Items.Add(row)
        Next

        FrmNovoLancamento.CmbCategoria.SelectedItem = TxtDescricao.Text

        Me.Close()

    End Sub

    Private Sub TxtDescricao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDescricao.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttSalvar.PerformClick()
        End If
    End Sub
End Class