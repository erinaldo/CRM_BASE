Public Class FrmReparoIniciado
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Public Fecha As Boolean = False

    Private Sub FrmReparoIniciado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Fecha = True Then

            FrmNotificacaoSServico.Show(Me)

        End If

    End Sub
End Class