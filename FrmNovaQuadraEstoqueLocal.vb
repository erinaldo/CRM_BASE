Public Class FrmNovaQuadraEstoqueLocal
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Public IdEstoque As Integer

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        Dim LqEstoque As New LqEstoqueLocalDataContext
        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'insere quadras

        For i As Integer = 1 To NmQtInserir.Value

            LqEstoque.InsereNovoQuadraEstoqueLocal(IdEstoque, "Quadra_" & i + FrmQuadrasEstoqueLocal.ListView2.Items.Count)

        Next

        FrmQuadrasEstoqueLocal.CarregaInicio()

        Me.Close()

    End Sub
End Class