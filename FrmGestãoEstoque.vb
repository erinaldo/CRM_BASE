Public Class FrmGestãoEstoque
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmGerenciarEstoque.Show(FrmPrincipal)
        Me.Hide()
    End Sub
End Class