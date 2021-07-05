Public Class FrmNovoEnderecoEstoqueLocal

    Dim LqEstoque As New LqEstoqueLocalDataContext

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtNomeEstoque_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeEstoque.TextChanged

        If TxtNomeEstoque.Text <> "" Then

            NmQtInserir.Enabled = True

            TxtAltura.Enabled = True

        Else

            NmQtInserir.Enabled = False
            NmQtInserir.Value = 1

            TxtAltura.Enabled = False
            TxtAltura.Value = 0

        End If

    End Sub

    Public IdEstoque As Integer
    Public IdAndar As Integer

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'insere quadras

        For i As Integer = 1 To NmQtInserir.Value

            LqEstoque.InsereNovaEndereoEstoqueLocal(IdAndar, IdEstoque, "Endereco_" & i + FrmEndereciEstoqueLocal.ListView2.Items.Count, False, TxtAltura.Value, TxtLargura.Value, TxtProfundidade.Value, TxtPeso.Value)

        Next

        FrmEndereciEstoqueLocal.carregaInicio()

        Me.Close()

    End Sub

    Private Sub TxtPeso_ValueChanged(sender As Object, e As EventArgs) Handles TxtPeso.ValueChanged

        If TxtPeso.Value > 0 Then

            BttBuscarCliente.Enabled = True

        Else

            BttBuscarCliente.Enabled = False

        End If

    End Sub

    Private Sub TxtAltura_ValueChanged(sender As Object, e As EventArgs) Handles TxtAltura.ValueChanged

        If TxtAltura.Value > 0 Then

            TxtLargura.Enabled = True

        Else

            TxtLargura.Value = 0

            TxtLargura.Enabled = False

        End If

    End Sub

    Private Sub TxtLargura_ValueChanged(sender As Object, e As EventArgs) Handles TxtLargura.ValueChanged

        If TxtLargura.Value > 0 Then

            TxtProfundidade.Enabled = True

        Else

            TxtProfundidade.Value = 0

            TxtProfundidade.Enabled = False

        End If

    End Sub

    Private Sub TxtProfundidade_ValueChanged(sender As Object, e As EventArgs) Handles TxtProfundidade.ValueChanged

        If TxtProfundidade.Value > 0 Then

            TxtPeso.Enabled = True

        Else

            TxtPeso.Value = 0

            TxtPeso.Enabled = False

        End If

    End Sub

    Private Sub NmQtInserir_ValueChanged(sender As Object, e As EventArgs) Handles NmQtInserir.ValueChanged

    End Sub

    Private Sub TxtProfundidade_TextChanged(sender As Object, e As EventArgs) Handles TxtProfundidade.TextChanged

        If TxtProfundidade.Value > 0 Then

            TxtPeso.Enabled = True

        Else

            TxtPeso.Value = 0

            TxtPeso.Enabled = False

        End If

    End Sub

    Private Sub TxtLargura_TextChanged(sender As Object, e As EventArgs) Handles TxtLargura.TextChanged

        If TxtLargura.Value > 0 Then

            TxtProfundidade.Enabled = True

        Else

            TxtProfundidade.Value = 0

            TxtProfundidade.Enabled = False

        End If

    End Sub

    Private Sub TxtAltura_TextChanged(sender As Object, e As EventArgs) Handles TxtAltura.TextChanged

        If TxtAltura.Value > 0 Then

            TxtLargura.Enabled = True

        Else

            TxtLargura.Value = 0

            TxtLargura.Enabled = False

        End If

    End Sub

    Private Sub TxtPeso_TextChanged(sender As Object, e As EventArgs) Handles TxtPeso.TextChanged

        If TxtPeso.Value > 0 Then

            BttBuscarCliente.Enabled = True

        Else

            BttBuscarCliente.Enabled = False

        End If

    End Sub
End Class