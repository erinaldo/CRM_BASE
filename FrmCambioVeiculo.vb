Public Class FrmCambioVeiculo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public IdVersão As Integer


    Private Sub FrmCambioVeiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'salva

        LqOficina.InsereCambioVeiculo(TxtDescrição.Text)

        'popula no campo de versão

        Dim Buscaversão = From vers In LqOficina.Cambio
                          Where vers.IdCambio Like "*"
                          Select vers.Cambio, vers.IdCambio

        FrmNovaVersaoModelo.LstIdCambio.Items.Clear()
        FrmNovaVersaoModelo.CmbCambio.Items.Clear()

        For Each row In Buscaversão.ToList

            FrmNovaVersaoModelo.LstIdCambio.Items.Add(row.IdCambio)
            FrmNovaVersaoModelo.CmbCambio.Items.Add(row.Cambio)

        Next

        FrmNovaVersaoModelo.CmbCambio.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub
End Class