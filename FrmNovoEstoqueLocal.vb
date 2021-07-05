Public Class FrmNovoEstoqueLocal
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqEstoque As New LqEstoqueLocalDataContext

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'cadastra novo estoque

        LqEstoque.InsereNovoEstoqueLocal(TxtNomeEstoque.Text, True, CmbTipoEstoque.Text)

        FrmAdminEstoqueNovo.CarregaInicio()

        Me.Close()

    End Sub

    Private Sub TxtNomeEstoque_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeEstoque.TextChanged

        If TxtNomeEstoque.Text <> "" Then

            CmbTipoEstoque.Enabled = True

        Else

            CmbTipoEstoque.Text = ""
            CmbTipoEstoque.Enabled = False

        End If
    End Sub

    Private Sub CmbTipoEstoque_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoEstoque.SelectedIndexChanged

        If CmbTipoEstoque.Items.Contains(CmbTipoEstoque.Text) Then
            BttBuscarCliente.Enabled = True
        Else
            BttBuscarCliente.Enabled = False
        End If
    End Sub
End Class