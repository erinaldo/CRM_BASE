Public Class FrmNovoPrédio
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Dim Lqgeral As New DtCadastroDataContext
    Public Chave As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        Dim Total As Integer = NumericUpDown1.Value
        Dim _C As Integer = 1

        While _C <= Total
            'insere novo bairro

            Lqgeral.InserePredioEstoque(Chave, txtdescrição.Text & "." & _C)

            _C += 1

        End While

        FrmNovoEstoque.PopulaTreeview1()

        Me.Close()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged
        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub
End Class