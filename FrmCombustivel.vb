Public Class FrmCombustivel
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If

    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public IdVersão As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'salva

        LqOficina.InsereCombustivelVeiculo(TxtDescrição.Text)

        'popula no campo de versão

        Dim Buscaversão = From vers In LqOficina.CombustivelVeiculo
                          Where vers.IdCombustivel Like "*"
                          Select vers.Combustivel, vers.IdCombustivel

        FrmNovaVersaoModelo.LstIdCombustivel.Items.Clear()
        FrmNovaVersaoModelo.CmbCombustivel.Items.Clear()

        For Each row In Buscaversão.ToList

            FrmNovaVersaoModelo.LstIdCombustivel.Items.Add(row.IdCombustivel)
            FrmNovaVersaoModelo.CmbCombustivel.Items.Add(row.Combustivel)

        Next

        FrmNovaVersaoModelo.CmbCombustivel.SelectedItem = TxtDescrição.Text

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub FrmCombustivel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtDescrição_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDescrição.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            Button2.PerformClick()

        End If

    End Sub
End Class