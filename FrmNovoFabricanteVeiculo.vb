Public Class FrmNovoFabricanteVeiculo
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

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim arrImage() As Byte
        Dim strImage As String
        Dim myMs As New IO.MemoryStream
        '
        If Not IsNothing(Me.PictureBox1.BackgroundImage) Then
            Me.PictureBox1.BackgroundImage.Save(myMs, Me.PictureBox1.BackgroundImage.RawFormat)
            arrImage = myMs.GetBuffer
            strImage = "?"
        Else
            arrImage = Nothing
            strImage = "NULL"
        End If

        LqOficina.InsereFabricanteModelo(TxtDescrição.Text, arrImage)

        'busca fabricantes

        Dim BuscaFabricantes = From fab In LqOficina.FabricantesVeiculo
                               Where fab.Idfabricante Like "*"
                               Select fab.Fabricante, fab.Idfabricante

        'popula combobox

        FrmVeiculo.LstIdFabricantes.Items.Clear()
        FrmVeiculo.CmbFabricantes.Items.Clear()

        For Each row In BuscaFabricantes.ToList

            FrmVeiculo.LstIdFabricantes.Items.Add(row.Idfabricante)
            FrmVeiculo.CmbFabricantes.Items.Add(row.Fabricante)

        Next

        FrmVeiculo.CmbFabricantes.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

End Class