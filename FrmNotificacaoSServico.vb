Public Class FrmNotificacaoSServico
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'insere atualização de serviços e avança para o estagio final


        FrmReparoIniciado.Close()

        Me.Close()

    End Sub
End Class