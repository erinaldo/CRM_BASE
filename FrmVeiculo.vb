Public Class FrmVeiculo

    Dim LqOficina As New LqOficinaDataContext
    Public LstIdFabricantes As New ListBox
    Public LstIdModelos As New ListBox
    Public LstIdVersão As New ListBox

    Public _Fabricante As String
    Private Sub FrmVeiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        TxtAnoFab.Maximum = Today.Year + 1
        TxtAnoMod.Maximum = Today.Year + 1

        TxtAnoFab.Value = Today.Year
        TxtAnoMod.Value = Today.Year

        'busca fabricantes

        Dim BuscaFabricantes = From fab In LqOficina.FabricantesVeiculo
                               Where fab.Idfabricante Like "*"
                               Select fab.Fabricante, fab.Idfabricante

        'popula combobox

        LstIdFabricantes.Items.Clear()
        CmbFabricantes.Items.Clear()

        For Each row In BuscaFabricantes.ToList

            LstIdFabricantes.Items.Add(row.Idfabricante)
            CmbFabricantes.Items.Add(row.Fabricante)

        Next

        CmbFabricantes.SelectedItem = _Fabricante

        'verifica se fabricante é diferente de ""

        'busca fabricantes

        If _Fabricante <> "" Then
            Dim BuscaModelos = From fab In LqOficina.Modelos
                               Where fab.IdFabricante = LstIdFabricantes.Items(CmbFabricantes.SelectedIndex).ToString
                               Select fab.Modelo, fab.IdModelo

            'popula combobox

            LstIdModelos.Items.Clear()
            CmbModelo.Items.Clear()

            For Each row In BuscaModelos.ToList

                LstIdModelos.Items.Add(row.IdModelo)
                CmbModelo.Items.Add(row.Modelo)

            Next
        End If

    End Sub

    Private Sub BttAddEndereço_Click(sender As Object, e As EventArgs) Handles BttAddFabricante.Click

        FrmNovoFabricanteVeiculo.Show(Me)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttAddModelo.Click

        FrmModeloVeiculo.IdFabricante = LstIdFabricantes.Items(CmbFabricantes.SelectedIndex).ToString
        FrmModeloVeiculo.Show(Me)

    End Sub

    Private Sub CmbFabricantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFabricantes.SelectedIndexChanged

        If CmbFabricantes.Items.Contains(CmbFabricantes.Text) Then

            Me.Cursor = Cursors.AppStarting

            Dim BuscaModelos = From fab In LqOficina.Modelos
                               Where fab.IdFabricante = LstIdFabricantes.Items(CmbFabricantes.SelectedIndex).ToString
                               Select fab.Modelo, fab.IdModelo

            'popula combobox

            LstIdModelos.Items.Clear()
            CmbModelo.Items.Clear()

            For Each row In BuscaModelos.ToList

                LstIdModelos.Items.Add(row.IdModelo)
                CmbModelo.Items.Add(row.Modelo)

            Next

            CmbModelo.Enabled = True
            BttAddModelo.Enabled = True
            Me.Cursor = Cursors.Arrow

            If CmbModelo.Items.Count = 0 Then

                If MsgBox("Ainda não encontrei nenhum modelo para este fabricante, vou direcioná-lo para o primeiro cadastro.") Then

                    BttAddModelo.PerformClick()

                End If

            End If

        Else

            CmbModelo.Text = ""
            CmbModelo.Enabled = False
            BttAddModelo.Enabled = False

        End If
    End Sub

    Private Sub CmbModelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbModelo.SelectedIndexChanged

        If CmbModelo.Items.Contains(CmbModelo.Text) Then

            Me.Cursor = Cursors.AppStarting

            'popula versão

            Dim buscaVersao = From vers In LqOficina.VersaoModelos
                              Where vers.IdModelo = LstIdModelos.Items(CmbModelo.SelectedIndex).ToString
                              Select vers.Idversao, vers.Veiculos, vers.Potencia, vers.Cilindrada, vers.Combustivel, vers.Versao, vers.Cambio

            LstIdVersão.Items.Clear()
            CmbVersão.Items.Clear()

            For Each row In buscaVersao.ToList

                LstIdVersão.Items.Add(row.Idversao)
                CmbVersão.Items.Add(row.Versao & " - " & FormatNumber(row.Potencia, NumDigitsAfterDecimal:=1) & " - " & row.Combustivel & " (" & row.Cambio & ")")

            Next

            CmbVersão.Enabled = True
            BttAddVersão.Enabled = True

            Me.Cursor = Cursors.Arrow

            If CmbVersão.Items.Count = 0 Then

                If MsgBox("Ainda não encontrei nenhuma versão cadastrada para este modelo, vou direcioná-lo para realizar o primeiro cadastro.") Then

                    BttAddVersão.PerformClick()

                End If

            End If

        Else

            CmbVersão.Text = ""
            CmbVersão.Enabled = False
            BttAddVersão.Enabled = False

        End If

    End Sub

    Private Sub BttAddVersão_Click(sender As Object, e As EventArgs) Handles BttAddVersão.Click

        FrmNovaVersaoModelo.IdModelo = LstIdModelos.Items(CmbModelo.SelectedIndex).ToString
        FrmNovaVersaoModelo.Show(Me)

    End Sub

    Private Sub TxtAnoFab_ValueChanged(sender As Object, e As EventArgs) Handles TxtAnoFab.ValueChanged

        TxtAnoMod.Value = TxtAnoFab.Value
        TxtAnoMod.Maximum = TxtAnoMod.Value + 1

    End Sub

    Public LstIdCor As New ListBox

    Private Sub CmbVersão_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbVersão.SelectedIndexChanged

        If CmbVersão.Items.Contains(CmbVersão.Text) Then

            Me.Cursor = Cursors.AppStarting

            'popula versão

            Dim buscaVersao = From vers In LqOficina.CorModelo
                              Where vers.IdModelo = LstIdFabricantes.Items(CmbFabricantes.SelectedIndex).ToString
                              Select vers.IdCor, vers.Cor

            LstIdCor.Items.Clear()
            CmbCor.Items.Clear()

            For Each row In buscaVersao.ToList

                LstIdCor.Items.Add(row.IdCor)
                CmbCor.Items.Add(row.Cor)

            Next

            CmbCor.Enabled = True
            BttAddCor.Enabled = True

            Me.Cursor = Cursors.Arrow

            If CmbCor.Items.Count = 0 Then

                If MsgBox("Ainda não possuo nenhuma cor associada a este modelo de veiculo, vou direcioná-lo para realizar o primeiro cadastro.") Then

                    BttAddCor.PerformClick()

                End If

            End If

        Else

                CmbCor.Text = ""
            CmbCor.Enabled = False
            BttAddCor.Enabled = False

        End If
    End Sub

    Private Sub BttAddCor_Click(sender As Object, e As EventArgs) Handles BttAddCor.Click

        FrmCorFabricante.IdFabricante = LstIdFabricantes.Items(CmbFabricantes.SelectedIndex).ToString
        FrmCorFabricante.Show(Me)

    End Sub

    Private Sub CmbCor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCor.SelectedIndexChanged

        If CmbCor.Items.Contains(CmbCor.Text) Then

            BttSalvar.Enabled = True

        Else

            BttSalvar.Enabled = False

        End If

    End Sub

    Dim lqgeral As New DtCadastroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        Dim _IdFabricante As Integer = LstIdFabricantes.Items(CmbFabricantes.SelectedIndex).ToString
        Dim _IdModelo As Integer = LstIdModelos.Items(CmbModelo.SelectedIndex).ToString
        Dim _IdVersao As Integer = LstIdVersão.Items(CmbVersão.SelectedIndex).ToString
        Dim _Idcor As Integer = LstIdCor.Items(CmbCor.SelectedIndex).ToString

        LqOficina.InsereNovoVeiculo(FrmEntradaVeículo._IdCliente, FrmEntradaVeículo.TxtPlaca.Text, _IdFabricante, CmbFabricantes.Text, _IdModelo, CmbModelo.Text, _IdVersao, CmbVersão.Text, TxtRenavan.Text, TxtChassi.Text, TxtAnoFab.Value, TxtAnoMod.Value, _Idcor, CmbCor.Text, 0)

        'busca os dados do veiculo

        Dim BuscaPlaca = From cli In LqOficina.Veiculos
                         Where cli.Placa Like FrmEntradaVeículo.TxtPlaca.Text
                         Select cli.AnoFab, cli.AnoMod, cli.Fabricante, cli.Modelo, cli.Versao, cli.Renavan, cli.Chassi, cli.IdVeiculo

        If BuscaPlaca.Count > 0 Then

            FrmEntradaVeículo.LblChassi.Text = BuscaPlaca.First.Chassi
            FrmEntradaVeículo.LblAno.Text = BuscaPlaca.First.AnoFab & "/" & BuscaPlaca.First.AnoMod

            FrmEntradaVeículo.LblFabricante.Text = BuscaPlaca.First.Fabricante
            FrmEntradaVeículo.LblModelo.Text = BuscaPlaca.First.Modelo
            FrmEntradaVeículo.LblVersão.Text = BuscaPlaca.First.Versao
            FrmEntradaVeículo.IdVeiculo = BuscaPlaca.First.IdVeiculo

        End If


        If FrmEntradaVeículo.RdbSeguradora.Checked = True Then
            Dim BuscaParceiro = From seg In lqgeral.ParceirosComerciais
                                Where seg.TipoParceiro = 1
                                Select seg.IdParceiro, seg.RazaoSocial_nome

            FrmEntradaVeículo.LstSeguradoras.Items.Clear()
            FrmEntradaVeículo.CmbSeguradoras.Items.Clear()

            For Each row In BuscaParceiro.ToList

                FrmEntradaVeículo.LstSeguradoras.Items.Add(row.IdParceiro)
                FrmEntradaVeículo.CmbSeguradoras.Items.Add(row.RazaoSocial_nome)

            Next

            FrmEntradaVeículo.BttSalvar.Enabled = False

        ElseIf FrmEntradaVeículo.RdbParticular.Checked = True Then

            FrmEntradaVeículo.BttSalvar.Enabled = True

        ElseIf FrmEntradaVeículo.RdbParceiro.Checked = True Then

            FrmEntradaVeículo.BttSalvar.Enabled = False

        End If
        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub TxtRenavan_TextChanged(sender As Object, e As EventArgs) Handles TxtRenavan.TextChanged

        If TxtRenavan.Text.Length = 11 Then

            TxtChassi.Enabled = True
            TxtChassi.Focus()

        Else

            TxtChassi.Enabled = False
            TxtChassi.Text = ""

        End If

    End Sub

    Private Sub TxtChassi_TextChanged(sender As Object, e As EventArgs) Handles TxtChassi.TextChanged

        If TxtChassi.Text.Length = 17 Then

            TxtAnoFab.Enabled = True
            TxtAnoMod.Enabled = True

            CmbFabricantes.Enabled = True
            BttAddFabricante.Enabled = True

            'verfica se ja possui algum fabricaante

            If CmbFabricantes.Items.Count = 0 Then

                If MsgBox("Ainda não encontrei fabricantes cadastrados, vou direcioná-lo para você realizar o primeiro registro.", MsgBoxStyle.OkOnly + vbInformation) Then

                    BttAddFabricante.PerformClick()

                End If

            End If

        Else

            TxtAnoFab.Enabled = False
            TxtAnoMod.Enabled = False

            CmbFabricantes.Enabled = False
            BttAddFabricante.Enabled = False

            CmbFabricantes.Text = ""

        End If

    End Sub
End Class