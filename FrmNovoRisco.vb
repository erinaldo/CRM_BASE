Public Class FrmNovoRisco
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Public Red As Integer = 255
    Public Green As Integer = 0
    Public Blue As Integer = 255

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        'insere 

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        LqTrabalhista.InsereRisco(TxtNomeSetor.Text, Red, Green, Blue)
        'chama lista e finaliza

        FrmRiscos.CarregaInicio()

        Me.Close()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub FrmNovoRisco_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

    End Sub
End Class