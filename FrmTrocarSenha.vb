Imports System.Net

Public Class FrmTrocarSenha
    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtPassword.TextChanged

        If TxtPassword.Text <> "" Then

            If TxtPassword.Text.Length >= 6 Then

                TxtRepeteSenha.Enabled = True

            Else

                TxtRepeteSenha.Text = ""
                TxtRepeteSenha.Enabled = False

            End If

        End If

    End Sub

    Public _IdLogin As Integer
    Public _IdColaborador As Integer

    Public NomeUsuario As String
    Public ChaveEnc As String

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'atualiza senha on line

        Dim baseUrl_insere As String = "http://www.iarasoftware.com.br/reset_senha_usuario_local.php?ChaveOficina=" & ChaveEnc & "&User=" & NomeUsuario & "&Pass=" & TxtRepeteSenha.Text

        Dim syncClient_insere = New WebClient()
        Dim content_insere = syncClient_insere.DownloadString(baseUrl_insere)

        FrmLogin.TxtPassword.Text = ""

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        End

    End Sub

    Public _Chave As String

    Private Sub TxtRepeteSenha_TextChanged(sender As Object, e As EventArgs) Handles TxtRepeteSenha.TextChanged

        If TxtPassword.Text = TxtRepeteSenha.Text Then

            If TxtCODE.Text = _Chave Then
                LblCodInvalido.Visible = False
                BttSalvar.Visible = True
            Else
                LblCodInvalido.Visible = True
            End If

        Else

            BttSalvar.Visible = False

        End If

    End Sub

    Private Sub FrmTrocarSenha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtPassword.Focus()

    End Sub

    Private Sub TxtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPassword.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            TxtRepeteSenha.Focus()

        End If

    End Sub

    Private Sub TxtRepeteSenha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRepeteSenha.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttSalvar.PerformClick()

        End If
    End Sub
End Class