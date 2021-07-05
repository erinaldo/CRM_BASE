Public Class FrmInteraçãoInicio
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        FrmVistoria.ProcuraValoresInciais()

        FrmVistoria.Opacity = 0.95
        Me.Close()

    End Sub
End Class