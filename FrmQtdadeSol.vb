Public Class FrmQtdadeSol

    Public _IdProduto As String
    Public _Categoria As String
    Public _SubCategoria As String
    Public _descricao As String
    Public _Fabricante As String

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NmQtdade.ValueChanged

        If NmQtdade.Value > 0 Then

            BttSalvar.Enabled = True

        Else

            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'insere no form de solução

        FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add(_IdProduto, _Categoria, _SubCategoria, _descricao, _Fabricante, NmQtdade.Value, False, CkPeça.CheckState)

        'FrmSoluçãoAplicada.CmbCategorias.Text = ""

        FrmSoluçãoAplicada.DtProdutos.Rows.Clear()

        Me.Close()

    End Sub
End Class