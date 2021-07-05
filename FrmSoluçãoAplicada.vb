Public Class FrmSoluçãoAplicada

    Dim LqBase As New DtCadastroDataContext

    Dim LstIdCategorias As New ListBox

    Private Sub FrmSoluçãoAplicada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblIdmarca.Text = _IdMarca
        LblIdSolução.Text = IdSoluções
        LblIdVistoria.Text = _IdProcesso

    End Sub

    Dim LstIdSubCategorias As New ListBox
    Public IdCategoria As Integer

    Private Sub CmbCategorias_SelectedIndexChanged(sender As Object, e As EventArgs)

        'busca produtos para esta categoria

        Dim BuscaProduto = From prod In LqBase.Produtos
                           Where prod.IdCategoria = IdCategoria
                           Select prod.Fabricante, prod.Categoria, prod.SubCategoria, prod.descricao, prod.IdProduto, prod.CodFabricante, prod.ImagemProduto

        DtProdutos.Rows.Clear()

        For Each row In BuscaProduto.ToList

            DtProdutos.Rows.Add(row.IdProduto, row.Categoria, row.SubCategoria, row.descricao, row.Fabricante, False)

        Next

        If DtProdutos.Rows.Count > 0 Then
            BttAddProduto.Enabled = True
        End If

    End Sub

    Private Sub BtnSolcitarCadastro_Click(sender As Object, e As EventArgs) Handles BtnSolcitarCadastro.Click

        FrmUsarSolitaçõesCadatroPeça.Show(Me)

    End Sub


    Private Sub BttAddProduto_Click(sender As Object, e As EventArgs) Handles BttAddProduto.Click

        FrmQtdadeSol._IdProduto = DtProdutos.SelectedCells(0).Value
        FrmQtdadeSol._Categoria = DtProdutos.SelectedCells(1).Value
        FrmQtdadeSol._SubCategoria = DtProdutos.SelectedCells(2).Value
        FrmQtdadeSol._descricao = DtProdutos.SelectedCells(3).Value
        FrmQtdadeSol._Fabricante = DtProdutos.SelectedCells(4).Value

        FrmQtdadeSol.Show(Me)

    End Sub

    Public IdSoluções As Integer = 0
    Public IdModeloVeic As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        If IdSoluções = 0 Then

            LqOficina.InsereSolucaoVistoria(_IdResposta, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, False, _IdProcesso, _IdMarca)

            Dim BuscaSoluçãoVistoria = From vist In LqOficina.SoluçõesVistoria
                                       Where vist.IdProcesso = _IdProcesso
                                       Select vist.IdSolucoes
                                       Order By IdSoluções Descending

            'insere items assciados

            For Each row As DataGridViewRow In DtrodutosSolução.Rows

                Dim _ExigeInicio As Boolean = row.Cells(7).Value
                Dim _Qt As Integer = row.Cells(5).Value

                If row.Cells(0).Value.ToString.StartsWith("S") Then

                    Dim _CodProduto As String = row.Cells(0).Value.ToString.Remove(0, 1)

                    'verifica se item já esta no banco de dados

                    Dim BuscaIten = From it In LqOficina.ItensSoluçãoN
                                    Where it.IdSolicitacao = _CodProduto And it.IdSolucao = BuscaSoluçãoVistoria.First
                                    Select it.IdItemSolucao

                    If BuscaIten.Count = 0 Then
                        LqOficina.InsereItemSolucao(0, True, _CodProduto, _Qt, _ExigeInicio, BuscaSoluçãoVistoria.First)
                    End If

                Else

                    Dim _IdProduto As Integer = row.Cells(0).Value

                    Dim BuscaIten = From it In LqOficina.ItensSoluçãoN
                                    Where it.IdProduto = _IdProduto And it.IdSolucao = BuscaSoluçãoVistoria.First
                                    Select it.IdItemSolucao
                    If BuscaIten.Count = 0 Then
                        LqOficina.InsereItemSolucao(_IdProduto, True, 0, _Qt, _ExigeInicio, BuscaSoluçãoVistoria.First)
                    End If

                End If

            Next

        Else

            'insere items assciados

            For Each row As DataGridViewRow In DtrodutosSolução.Rows

                Dim _ExigeInicio As Boolean = row.Cells(7).Value
                Dim _Qt As Integer = row.Cells(5).Value

                If row.Cells(0).Value.ToString.StartsWith("S") Then

                    Dim _CodProduto As String = row.Cells(0).Value.ToString.Remove(0, 1)

                    'verifica se item já esta no banco de dados

                    Dim BuscaIten = From it In LqOficina.ItensSoluçãoN
                                    Where it.IdSolicitacao = _CodProduto And it.IdSolucao = IdSoluções
                                    Select it.IdItemSolucao

                    If BuscaIten.Count = 0 Then
                        LqOficina.InsereItemSolucao(0, True, _CodProduto, _Qt, _ExigeInicio, IdSoluções)
                    End If

                Else

                    Dim _IdProduto As Integer = row.Cells(0).Value

                    Dim BuscaIten = From it In LqOficina.ItensSoluçãoN
                                    Where it.IdProduto = _IdProduto And it.IdSolucao = IdSoluções
                                    Select it.IdItemSolucao
                    If BuscaIten.Count = 0 Then
                        LqOficina.InsereItemSolucao(_IdProduto, True, 0, _Qt, _ExigeInicio, IdSoluções)
                    End If

                End If

            Next

        End If

        'busca item

        FrmDesmonte.PublicaTreeview()

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Public _IdResposta As Integer
    Public _IdMarca As Integer
    Public _IdProcesso As Integer

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        LqOficina.InsereSolucaoVistoria(_IdResposta, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, _IdProcesso, _IdMarca)

        Dim BuscaSoluçãoVistoria = From vist In LqOficina.SoluçõesVistoria
                                   Where vist.IdProcesso = _IdProcesso
                                   Select vist.IdSolucoes
                                   Order By IdSoluções Descending

        'busca item

        FrmDesmonte.PublicaTreeview()

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttRemover_Click(sender As Object, e As EventArgs) Handles BttRemover.Click

        'verifica ponto de partida

        If DtrodutosSolução.SelectedCells(0).Value.ToString.StartsWith("S") Then

            'apaga solicitação ao setor de compras

            Dim _CodProduto As String = DtrodutosSolução.SelectedCells(0).Value.ToString.Remove(0, 1)

            LqOficina.DeletaSolucaoItemMarcaDesmonte(_CodProduto, IdSoluções)

        Else

            'apaga produt da solução


            'apaga solicitação ao setor de compras

            Dim _CodProduto As String = DtrodutosSolução.SelectedCells(0).Value

            LqOficina.DeletaSolucaoProdutomMarcaDesmonte(_CodProduto, IdSoluções)

        End If

        'busca itens

        DtrodutosSolução.Rows.Remove(DtrodutosSolução.Rows(DtrodutosSolução.SelectedCells(0).RowIndex))

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

    End Sub

    Private Sub DtProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellDoubleClick

        BttAddProduto.PerformClick()

    End Sub

    Private Sub DtrodutosSolução_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtrodutosSolução.CellContentClick

    End Sub

    Private Sub DtrodutosSolução_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DtrodutosSolução.RowsAdded

        If DtProdutos.Rows.Count > 0 Then

            Button4.Enabled = False
            BttRemover.Enabled = True

        End If

    End Sub

    Private Sub DtrodutosSolução_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DtrodutosSolução.RowsRemoved

        If DtProdutos.Rows.Count = 0 Then

            Button4.Enabled = True
            BttRemover.Enabled = False

        End If

    End Sub
End Class