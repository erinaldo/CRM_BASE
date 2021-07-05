Imports System.Net

Public Class FrmCadLoginUsuario
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        FrmCadColaboradores.NomeUsuario = TxtPlaca.Text
        FrmCadColaboradores.SenhaUsuario = "000000"

        'manda informação para o form anterior

        Me.Close()

    End Sub

    Public Pass As String

    Private Sub FrmCadLoginUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Pass <> "" Then
            BttResetar.Enabled = True
        End If

        'busca usuarios

        TrPermissoes.Nodes.Add("Recepção de clientes")
        TrPermissoes.Nodes.Add("Inspeção inicial")
        TrPermissoes.Nodes.Add("Análise técnica")
        TrPermissoes.Nodes.Add("Liberação de veículo")
        TrPermissoes.Nodes.Add("Orçamento")
        TrPermissoes.Nodes.Add("Gestor")
        TrPermissoes.Nodes.Add("Relatórios")

    End Sub

    Private Sub BttResetar_Click(sender As Object, e As EventArgs) Handles BttResetar.Click

        Try

            Dim baseUrl_insere As String = "http://www.iarasoftware.com.br/reset_senha_usuario_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&User=" & TxtPlaca.Text & "&Pass=000000"

            Dim syncClient_insere = New WebClient()
            Dim content_insere = syncClient_insere.DownloadString(baseUrl_insere)

            FrmCadColaboradores.SenhaUsuario = "000000"
            FrmListaColaboradores.DtFornecedores.SelectedCells(7).Value = "000000"

            BttResetar.Enabled = False

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            MsgBox("Senha resetada com sucesso!", vbOKOnly + MsgBoxStyle.Information)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TxtPlaca_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtPlaca.MaskInputRejected

    End Sub

    Private Sub TxtPlaca_TextChanged(sender As Object, e As EventArgs) Handles TxtPlaca.TextChanged

        If TxtPlaca.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub
End Class