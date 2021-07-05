Public Class FrmNovoPredioEstoqueLocal

    Dim LqEstoque As New LqEstoqueLocalDataContext

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtNomeEstoque_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeEstoque.TextChanged

        If TxtNomeEstoque.Text <> "" Then

            NmQtInserir.Enabled = True

            BttBuscarCliente.Enabled = True

        Else

            NmQtInserir.Enabled = False
            NmQtInserir.Value = 1

            BttBuscarCliente.Enabled = False

        End If

    End Sub

    Public IdEstoque As Integer
    Public IdRua As Integer

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'insere quadras

        For i As Integer = 1 To NmQtInserir.Value

            LqEstoque.InsereNovoPredioEstoqueLocal(IdRua, IdEstoque, "Predio_" & i)

        Next

        FrmPrediosEstoqueLocal.CarregaInicio()

        Me.Close()

    End Sub
End Class