Public Class FrmNovaVersaoModelo

    Dim LqOficina As New LqOficinaDataContext

    Private Sub BttFechar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Public IdModelo As Integer

    Private Sub FrmNovaVersaoModelo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'popula no campo de versão

        Dim Buscaversão = From vers In LqOficina.Cambio
                          Where vers.IdCambio Like "*"
                          Select vers.Cambio, vers.IdCambio

        LstIdCambio.Items.Clear()
        CmbCambio.Items.Clear()

        For Each row In Buscaversão.ToList

            LstIdCambio.Items.Add(row.IdCambio)
            CmbCambio.Items.Add(row.Cambio)

        Next

        'popula no campo de versão

        Dim BusaCombustivel = From vers In LqOficina.CombustivelVeiculo
                              Where vers.IdCombustivel Like "*"
                              Select vers.Combustivel, vers.IdCombustivel

        LstIdCombustivel.Items.Clear()
        CmbCombustivel.Items.Clear()

        For Each row In BusaCombustivel.ToList

            LstIdCombustivel.Items.Add(row.IdCombustivel)
            CmbCombustivel.Items.Add(row.Combustivel)

        Next

    End Sub

    Private Sub BttAddModelo_Click(sender As Object, e As EventArgs) Handles BttAddCombustivel.Click

        FrmCombustivel.Show(Me)

    End Sub

    Public LstIdCombustivel As New ListBox
    Public LstIdCambio As New ListBox

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmbCombustivel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCombustivel.SelectedIndexChanged

        If CmbCombustivel.Items.Contains(CmbCombustivel.Text) Then

            'busca cambios

            If CmbCambio.Items.Count = 0 Then

                If MsgBox("Vi que ainda não possuo nenhum tipo de câmbio cadastrado, vou direcioná-lo para realizar o primeiro cadastro.") Then

                    BttAddCambio.PerformClick()

                End If

            End If

        End If

    End Sub

    Private Sub BttAddCambio_Click(sender As Object, e As EventArgs) Handles BttAddCambio.Click

        FrmCambioVeiculo.Show(Me)

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then

            CmbCombustivel.Enabled = True
            BttAddCombustivel.Enabled = True
            CmbCambio.Enabled = True
            BttAddCambio.Enabled = True

            TxtPotencia.Enabled = True
            TxtCilindrada.Enabled = True

            BttSalvar.Enabled = True

        Else

            CmbCombustivel.Text = Nothing
            CmbCambio.Text = Nothing

            TxtPotencia.Value = 1
            TxtCilindrada.Value = 1000

            CmbCombustivel.Enabled = False
            BttAddCombustivel.Enabled = False
            CmbCambio.Enabled = False
            BttAddCambio.Enabled = False

            TxtPotencia.Enabled = False
            TxtCilindrada.Enabled = False

            BttSalvar.Enabled = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'Salva versão

        Dim IdCombustivel As Integer

        If CmbCombustivel.Items.Count > 0 Then
            IdCombustivel = LstIdCombustivel.Items(CmbCombustivel.SelectedIndex).ToString
        End If

        Dim IdCambio As Integer

        If CmbCambio.Items.Count > 0 Then
            IdCambio = LstIdCambio.Items(CmbCambio.SelectedIndex).ToString
        End If

        LqOficina.InsereVersaoModeloVeiculo(IdModelo, TxtDescrição.Text, TxtPotencia.Value, TxtCilindrada.Value, IdCombustivel, CmbCombustivel.Text, FrmVeiculo.TxtAnoMod.Value, FrmVeiculo.TxtAnoFab.Value, IdCambio, CmbCambio.Text)

        'popula versão

        Dim buscaVersao = From vers In LqOficina.VersaoModelos
                          Where vers.IdModelo = IdModelo
                          Select vers.Idversao, vers.Veiculos, vers.Potencia, vers.Cilindrada, vers.Combustivel, vers.Versao, vers.Cambio

        FrmVeiculo.LstIdVersão.Items.Clear()
        FrmVeiculo.CmbVersão.Items.Clear()

        For Each row In buscaVersao.ToList

            FrmVeiculo.LstIdVersão.Items.Add(row.Idversao)
            FrmVeiculo.CmbVersão.Items.Add(row.Versao & " - " & FormatNumber(row.Potencia, NumDigitsAfterDecimal:=1) & " - " & row.Combustivel & " (" & row.Cambio & ")")

        Next

        FrmVeiculo.CmbVersão.SelectedItem = TxtDescrição.Text & " - " & FormatNumber(TxtPotencia.Value, NumDigitsAfterDecimal:=1) & " - " & CmbCombustivel.Text & " (" & CmbCambio.Text & ")"

        Me.Close()


    End Sub

    Private Sub TxtDescrição_LostFocus(sender As Object, e As EventArgs) Handles TxtDescrição.LostFocus

        If TxtDescrição.Text <> "" Then

            If CmbCombustivel.Items.Count = 0 Then

                If MsgBox("Vi que ainda não possuo nenhum tipo de combustível cadastrado, vou direcioná-lo para realizar o primeiro cadastro.") Then

                    BttAddCombustivel.PerformClick()

                End If

            End If

        End If

    End Sub

    Private Sub CmbCambio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCambio.SelectedIndexChanged

    End Sub

    Private Sub BttSalvar_Click_1(sender As Object, e As EventArgs) Handles BttSalvar.Click

    End Sub
End Class