Public Class FrmNovaCidade
    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged
        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Public FormOri As Integer
    Public IdEstado As Integer
    Dim LqGeral As New DtCadastroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click
        'salva cidade
        LqGeral.InsereCidade(IdEstado, txtdescrição.Text)

        If FormOri = 0 Then

        End If

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub
End Class