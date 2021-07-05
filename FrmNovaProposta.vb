Public Class FrmNovaProposta
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FrmNovoCliente.Show(Me)
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FrmComercial.Show(FrmPrincipal)
        Me.Close()

    End Sub

    Dim Lqgeral As New DtCadastroDataContext
    Dim LstIdprodutoPesquisa As New ListBox
    Dim LstIdFabricante As New ListBox

    Private Sub BttAddColaborador_Click(sender As Object, e As EventArgs) Handles BttAddColaborador.Click
        TabControl1.Enabled = True
        'busca produtos
        Dim BuscaProdutos = From prod In Lqgeral.Produtos
                            Where prod.IdProduto Like "*"
                            Select prod.descricao, prod.IdProduto

        CmbProdutos.Items.Clear()
        LstIdprodutoPesquisa.Items.Clear()

        For Each row In BuscaProdutos.ToList
            CmbProdutos.Items.Add(row.descricao)
            LstIdprodutoPesquisa.Items.Add(row.IdProduto)
        Next

        'busca fabricantes
        Dim buscaFabricantes = From fab In Lqgeral.Fabricantes
                               Where fab.IdFabricante Like "*"
                               Select fab.Fabricante, fab.IdFabricante

        CmbFabricantes.Items.Clear()
        LstIdFabricante.Items.Clear()

        For Each row In buscaFabricantes.ToList
            CmbFabricantes.Items.Add(row.Fabricante)
            LstIdFabricante.Items.Add(row.IdFabricante)
        Next


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CmbProdutos.Text <> "" Then
            'busca produto

            Dim BuscaProduto = From prod In Lqgeral.Produtos
                               Where prod.IdProduto = LstIdprodutoPesquisa.Items(CmbProdutos.SelectedIndex).ToString
                               Select prod.Descricao

            LblDescrição.Text = BuscaProduto.First

            'busca estoque


        End If
    End Sub
End Class