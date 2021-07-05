Public Class FrmUsarSolitaçõesCadatroPeça
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        FrmQtdadeSol._IdProduto = "S" & DtProdutos.SelectedCells(0).Value
        FrmQtdadeSol._Categoria = ""
        FrmQtdadeSol._SubCategoria = ""
        FrmQtdadeSol._descricao = DtProdutos.SelectedCells(2).Value

        FrmQtdadeSol.Show(FrmSoluçãoAplicada)

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public IdModeloveic As Integer

    Dim _IdVErsão As Integer
    Dim _IdModelo As Integer

    Public _IdVeiculo As Integer

    Public Invoc As Integer = 0

    Private Sub FrmUsarSolitaçõesCadatroPeça_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Application.OpenForms.OfType(Of FrmNovoStudioAvaliacao)().Count() > 0 Then

            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'carrega dados do veiculo

            If Invoc = 0 Then
                _IdVeiculo = FrmSoluçãoNovoStudio._IdVeiculo
            Else
                _IdVeiculo = FrmEntradaVeiculo._IdVeiculo
            End If

            Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                               Where veic.IdVeiculo = _IdVeiculo
                               Select veic.IdVersao, veic.IdModelo, veic.AnoFab, veic.AnoMod, veic.IdFabricante

            Dim BuscaFabricante = From ver In LqOficina.FabricantesVeiculo
                                  Where ver.Idfabricante = BuscaVeiculo.First.IdFabricante
                                  Select ver.Fabricante

            _IdVErsão = BuscaVeiculo.First.IdVersao

            Dim BuscaVersão = From ver In LqOficina.VersaoModelos
                              Where ver.Idversao = _IdVErsão
                              Select ver.Versao, ver.Potencia, ver.Cilindrada

            _IdModelo = BuscaVeiculo.First.IdModelo


            Dim Oficina = From ofc In LqOficina.SolicitacaoCadastroPeca
                          Where ofc.IdCodCad = 0 And ofc.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria And ofc.IdSubCategoria = FrmSoluçãoNovoStudio._IdSubCategoria
                          Select ofc.DataSol, ofc.HoraSol, ofc.IdSolicitante, ofc.Descricao, ofc.IdSolicitacaoCadastro, ofc.PartNumber

            DtProdutos.Rows.Clear()

            For Each row In Oficina.ToList

                'busca associação

                Dim BuscaAssociação = From ass In LqOficina.VinculoProdutoModelo
                                      Where ass.IdSolicitacaoCad = row.IdSolicitacaoCadastro And ass.IdModeloVeic = _IdModelo And ass.IdVersaoVeiculo = _IdVErsão
                                      Select ass.IdVinculoProdutoVeiculo

                If BuscaAssociação.Count > 0 Then
                    'busca associação ao modelo do veiculo

                    'DtProdutos.Rows.Add(row.idsolicitacaoCadastro, row.PartNumber, row.descricao, FormatDateTime(row.DataSol, DateFormat.ShortDate), FormatDateTime(row.HoraSol.ToString, DateFormat.ShortTime))
                End If

            Next

            FrmSolicitarCadastro._Categoria = FrmSoluçãoNovoStudio.LblCategoria.Text
            FrmSolicitarCadastro._SubCategoria = FrmSoluçãoNovoStudio.LblSubCategoria.Text

            If DtProdutos.Rows.Count = 0 Then
                BttFechar.PerformClick()
            End If

        Else

            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            _IdVeiculo = FrmNovoORçamento.IdModeloVeiculo

            Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                               Where veic.IdVeiculo = _IdVeiculo
                               Select veic.IdVersao, veic.IdModelo, veic.AnoFab, veic.AnoMod, veic.IdFabricante

            Dim BuscaFabricante = From ver In LqOficina.FabricantesVeiculo
                                  Where ver.Idfabricante = BuscaVeiculo.First.IdFabricante
                                  Select ver.Fabricante

            _IdVErsão = BuscaVeiculo.First.IdVersao

            Dim BuscaVersão = From ver In LqOficina.VersaoModelos
                              Where ver.Idversao = _IdVErsão
                              Select ver.Versao, ver.Potencia, ver.Cilindrada

            _IdModelo = BuscaVeiculo.First.IdModelo


            Dim Oficina = From ofc In LqOficina.SolicitacaoCadastroPeca
                          Where ofc.IdCodCad = 0 And ofc.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria And ofc.IdSubCategoria = FrmSoluçãoNovoStudio._IdSubCategoria
                          Select ofc.DataSol, ofc.HoraSol, ofc.IdSolicitante, ofc.Descricao, ofc.IdSolicitacaoCadastro, ofc.PartNumber

            DtProdutos.Rows.Clear()

            For Each row In Oficina.ToList

                'busca associação

                Dim BuscaAssociação = From ass In LqOficina.VinculoProdutoModelo
                                      Where ass.IdSolicitacaoCad = row.IdSolicitacaoCadastro And ass.IdModeloVeic = _IdModelo And ass.IdVersaoVeiculo = _IdVErsão
                                      Select ass.IdVinculoProdutoVeiculo

                If BuscaAssociação.Count > 0 Then
                    'busca associação ao modelo do veiculo

                    'DtProdutos.Rows.Add(row.idsolicitacaoCadastro, row.PartNumber, row.descricao, FormatDateTime(row.DataSol, DateFormat.ShortDate), FormatDateTime(row.HoraSol.ToString, DateFormat.ShortTime))
                End If

            Next

            If DtProdutos.Rows.Count = 0 Then
                BttFechar.PerformClick()
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmSolicitarCadastro.TopMost = True

        FrmSolicitarCadastro.Show(FrmSoluçãoAplicada)

        Me.Close()

    End Sub
End Class