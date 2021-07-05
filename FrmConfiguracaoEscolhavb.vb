Public Class FrmConfiguracaoEscolhavb
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttEncerra.Click

        End

    End Sub

    Private Sub BttLogout_Click(sender As Object, e As EventArgs) Handles BttLogout.Click

        FrmLogin.TxtPassword.Text = ""
        FrmLogin.TxtNick.Text = ""

        FrmLogin.Visible = True
        FrmLogin.Opacity = 97

        FrmLogin.Timer1.Enabled = True

        FrmPrincipal.Visible = False

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub
End Class