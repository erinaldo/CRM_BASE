Public Class Frmvalidar
    Private Sub TxtRg_TextChanged(sender As Object, e As EventArgs) Handles TxtRg.TextChanged

        If TxtRg.Text.Length > 5 Then

            BttBuscarCliente.Enabled = True

        Else

            BttBuscarCliente.Enabled = False

        End If

    End Sub

    Dim LqBase As New DtCadastroDataContext
    Dim LqPrestador As New LqPrestadorDataContext
    Dim LqOficina As New LqOficinaDataContext

    Public _IdPrestador As Integer
    Public _IdVeiculo As Integer
    Public _IdCliente As Integer
    Public _Placa As String
    Public _IdProcesso As Integer

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        Try

            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
            LqPrestador.Connection.ConnectionString = FrmPrincipal.ConnectionStringTransportePrestadorOnline
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim _IdUsuario As Integer = FrmPrincipal.IdUsuario

            'verifica se a senha corresponde ao usuario logado

            Dim BuscaSenha = From sen In LqBase.Login
                             Where sen.IdColaborador = _IdUsuario And sen.Pass Like TxtRg.Text
                             Select sen.Nick

            If BuscaSenha.Count > 0 Then

                'libera prestador

                Dim BuscaUsuario = From sus In LqBase.Funcionarios
                                   Where sus.IdFuncionario = FrmPrincipal.IdUsuario
                                   Select sus.NomeCompleto, sus.RG

                If FrmEntradaVeiculo.RdbPrestador.Checked = True Then
                    LqPrestador.LiberaPrestador(FrmEntradaVeiculo._IdPrestador, BuscaUsuario.First.RG, BuscaUsuario.First.NomeCompleto, True, FrmPrincipal.IdUsuario)
                End If

                'da entrada do veiculo na oficina

                LqOficina.InsereEntradaVeiculo(_IdVeiculo, _IdCliente, _Placa, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 1, _IdPrestador, _IdProcesso)

                    FrmEntradaVeiculo.Close()

                    FrmPrincipal.CarregaDashboard()

                    FrmPrincipal.Cursor = Cursors.Arrow

                    Me.Close()

                Else

                    MsgBox("Senha incorreta.", vbOKOnly)

                TxtRg.Text = Nothing

            End If

                    Catch ex As Exception

        End Try

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtRg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtRg.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True
            BttBuscarCliente.PerformClick()

        End If

    End Sub

    Private Sub Frmvalidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblUsuario.Text = FrmPrincipal.LblNomeUsuario.Text

    End Sub
End Class