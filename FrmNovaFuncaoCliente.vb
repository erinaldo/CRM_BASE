Public Class FrmNovaFuncaoCliente
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public IdCliente As Integer
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        'salva nova funcao

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        LqTrabalhista.InsereFuncaoCliente(IdCliente, TxtNomeSetor.Text)

        If Application.OpenForms.OfType(Of FrmFuncoesClientes)().Count() > 0 Then

            FrmFuncoesClientes.CarregaInicio()

        ElseIf Application.OpenForms.OfType(Of FrmNovoColaboradorCliente)().Count() > 0 Then

            FrmNovoColaboradorCliente.NomeFuncao = TxtNomeSetor.Text

            FrmNovoColaboradorCliente.CarregaFuncoes()

        End If

        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub
End Class