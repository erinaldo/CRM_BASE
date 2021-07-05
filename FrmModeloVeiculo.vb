Public Class FrmModeloVeiculo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public IdFabricante As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        LqOficina.InsereModeloVeiculo(IdFabricante, TxtDescrição.Text, "", "")

        Dim BuscaModelos = From fab In LqOficina.Modelos
                           Where fab.IdFabricante = IdFabricante
                           Select fab.Modelo, fab.IdModelo

        'popula combobox

        FrmVeiculo.LstIdModelos.Items.Clear()
        FrmVeiculo.CmbModelo.Items.Clear()

        For Each row In BuscaModelos.ToList

            FrmVeiculo.LstIdModelos.Items.Add(row.IdModelo)
            FrmVeiculo.CmbModelo.Items.Add(row.Modelo)

        Next

        FrmVeiculo.CmbModelo.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub
End Class