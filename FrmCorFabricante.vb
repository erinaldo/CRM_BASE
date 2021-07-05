Public Class FrmCorFabricante
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub

    Public IdFabricante As Integer
    Dim LqOficina As New LqOficinaDataContext

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        LqOficina.InsereCorFabricante(IdFabricante, TxtDescrição.Text)
        'popula versão

        Dim buscaVersao = From vers In LqOficina.CorModelo
                          Where vers.IdModelo = IdFabricante
                          Select vers.IdCor, vers.Cor

        FrmVeiculo.LstIdCor.Items.Clear()
        FrmVeiculo.CmbCor.Items.Clear()

        For Each row In buscaVersao.ToList

            FrmVeiculo.LstIdCor.Items.Add(row.IdCor)
            FrmVeiculo.CmbCor.Items.Add(row.Cor)

        Next

        FrmVeiculo.CmbCor.SelectedItem = TxtDescrição.Text
        FrmVeiculo.CmbCor.Enabled = True
        FrmVeiculo.BttAddCor.Enabled = True

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub
End Class