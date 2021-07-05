Public Class FrmSST
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor

        FrmAcidenteTrab.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub
End Class