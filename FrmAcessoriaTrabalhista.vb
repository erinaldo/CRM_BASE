Public Class FrmAcessoriaTrabalhista
    Public Sub CarregaInicio()

    End Sub

    Private Sub FrmAcessoriaTrabalhista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovoMapa.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub
End Class