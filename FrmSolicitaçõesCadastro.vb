Public Class FrmSolicitaçõesCadastro
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'abre form de ins
        'busca associação

        Dim _Codass As Integer = DtProdutos.Rows(0).Cells(0).Value

        FrmProduto.CodSol = _Codass

        FrmProduto.DtVinculoExterno.Rows.Clear()

        'busca associação ao modelo do veiculo

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaAssociação = From ass In LqOficina.VinculoProdutoModelo
                              Where ass.IdSolicitacaoCad = _Codass
                              Select ass.IdModeloVeic, ass.IdVersaoVeiculo, ass.AnoFab, ass.AnoMod

        For Each row In BuscaAssociação.ToList

            Dim BuscaMOdelo = From mode In LqOficina.Modelos
                              Where mode.IdModelo = row.IdModeloVeic
                              Select mode.Modelo, mode.IdFabricante

            Dim BuscaVersão = From ver In LqOficina.VersaoModelos
                              Where ver.Idversao = row.IdModeloVeic
                              Select ver.Versao, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Combustivel

            Dim BUscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                  Where fab.Idfabricante = BuscaMOdelo.First.IdFabricante
                                  Select fab.Fabricante

            FrmProduto.DtVinculoExterno.Rows.Add("Oficina", BUscaFabricante.First, BuscaMOdelo.First.Modelo, BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1) & ", " & BuscaVersão.First.Combustivel & " (" & BuscaVersão.First.Cambio & ")", row.AnoFab, row.AnoMod)

        Next

        FrmProduto.txtdescrição.Text = DtProdutos.Rows(0).Cells(2).Value & " - " & DtProdutos.Rows(0).Cells(3).Value

        'busca categorias e subcategorias

        Dim LqBase As New DtCadastroDataContext

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCategoras = From cat In LqBase.CategoriasProdutos
                             Where cat.descricao Like LblCategoria.Text
                             Select cat.descricao, cat.IdCategoriaProduto

        For Each row In BuscaCategoras.ToList

            FrmProduto.CmbCategoria.Items.Add(row.descricao)
            FrmProduto.LstIdCategoria.Items.Add(row.IdCategoriaProduto)

        Next

        FrmProduto.CmbCategoria.SelectedIndex = 0

        Dim BuscaSubCategorias = From cat In LqBase.SubCategoriasProduto
                                 Where cat.IdCategoria = BuscaCategoras.First.IdCategoriaProduto And cat.descricao Like LblSubcategoria.Text
                                 Select cat.descricao, cat.IdSubCategoria

        For Each row In BuscaSubCategorias.ToList

            FrmProduto.CmbSubcategoria.Items.Add(row.descricao)
            FrmProduto.LstIdSubCategorias.Items.Add(row.IdSubCategoria)

        Next

        If DtProdutos.Rows(0).Cells(1).Value <> "" Then
            FrmProduto.CodFabricante = DtProdutos.Rows(0).Cells(1).Value
        End If

        FrmProduto.CmbSubcategoria.SelectedIndex = 0

        If Application.OpenForms.OfType(Of FrmProduto)().Count() = 0 Then

            FrmProduto.Show(FrmPrincipal)

        End If

        Me.Close()

    End Sub

    Private Sub FrmSolicitaçõesCadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub BttAddnovo_Click(sender As Object, e As EventArgs) Handles BttAddnovo.Click

        FrmProduto.Show(Me)

    End Sub

End Class