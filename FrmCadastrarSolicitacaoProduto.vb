Imports System.Net

Public Class FrmCadastrarSolicitacaoProduto
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'carrega solicitados


        Me.Close()

    End Sub

    Public FabricanteVeic As String
    Public ModeloVeic As String
    Public AnoFab As String
    Public AnoMod As String
    Public Categoria As String

    Public LstIdItemSelecionado As New ListBox
    Public LstQtSel As New ListBox

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

        Me.Cursor = Cursors.WaitCursor

        'salva no externi 

        'limpa_itens_orcamento_local

        Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/create_novo_produto_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&CodFabricante=" & TxtPartNumber.Text & "&Descricao=" & TxtDescricao.Text & "&FabricanteVeic=" & FrmNovoStudioAvaliacao.FabricanteVeic & "&ModeloVeic=" & FrmNovoStudioAvaliacao.ModeloVeic & "&AnoFab=" & FrmNovoStudioAvaliacao.AnoFab & "&AnoMod=" & FrmNovoStudioAvaliacao.AnoMod & "&Categoria=" & FrmNovoStudioAvaliacao.SelPrincipal & "&SubCAtegoria=" & CmbCategria.SelectedItem & "&Fabricante=" & CmbFabricante.SelectedItem

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientImagemUsuario = New WebClient()
        Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

        FrmPrincipal.ProcuraProdutosNaoCadastrados()

        If Application.OpenForms.OfType(Of FrmAnalisarveiculo)().Count() > 0 Then

            FrmAnalisarveiculo.CarregaProdutos()

            'insere na lista de selecionados
            Dim LstRemover As New ListBox

            For Each row As DataGridViewRow In FrmAnalisarveiculo.DtProduto.Rows

                Dim IndexSel As Integer = -1

                For i = 0 To LstIdItemSelecionado.Items.Count - 1
                    If LstIdItemSelecionado.Items(i).ToString = row.Cells(0).Value.ToString Then
                        IndexSel = i
                    End If
                Next

                If LstIdItemSelecionado.Items.Contains(row.Cells(0).Value) Then
                    FrmAnalisarveiculo.DtProdutoSel.Rows.Add(row.Cells(0).Value,
                                      row.Cells(1).Value,
                                      row.Cells(2).Value,
                                      row.Cells(3).Value, LstQtSel.Items(IndexSel).ToString,
                                      FrmAnalisarveiculo.ImageList1.Images(1), False)

                    LstRemover.Items.Add(row.Index)
                End If

            Next

            For i = 0 To LstRemover.Items.Count - 1

                FrmAnalisarveiculo.DtProduto.Rows.RemoveAt(LstRemover.Items(i).ToString)

            Next

            Dim _Index As Integer = FrmAnalisarveiculo.DtProduto.Rows.Count - 1

            FrmAnalisarveiculo.DtProdutoSel.Rows.Add(FrmAnalisarveiculo.DtProduto.Rows(_Index).Cells(0).Value,
                                  FrmAnalisarveiculo.DtProduto.Rows(_Index).Cells(1).Value,
                                  FrmAnalisarveiculo.DtProduto.Rows(_Index).Cells(2).Value,
                                  FrmAnalisarveiculo.DtProduto.Rows(_Index).Cells(3).Value, 0,
                                  FrmAnalisarveiculo.ImageList1.Images(1), False)

            FrmAnalisarveiculo.DtProduto.Rows.RemoveAt(_Index)

            'procura id na lista, remove e insere na outra

            FrmAnalisarveiculo.DtProdutoSel.Rows(FrmAnalisarveiculo.DtProdutoSel.Rows.Count - 1).Selected = True
            FrmAnalisarveiculo.DtProdutoSel.FirstDisplayedCell = FrmAnalisarveiculo.DtProdutoSel.Rows(FrmAnalisarveiculo.DtProdutoSel.Rows.Count - 1).Cells(0)

        ElseIf Application.OpenForms.OfType(Of FrmOrdemDeCompra)().Count() > 0 Then

            FrmOrdemDeCompra.CarregaProdutos()

        End If


        Me.Close()

    End Sub

    Dim LstIdSubCategoria As New ListBox
    Dim LstIdFabricante As New ListBox
    Private Sub FrmCadastrarSolicitacaoProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Application.OpenForms.OfType(Of FrmAnalisarveiculo)().Count() > 0 Then

            'procura subcategorias

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaIdCategoria = From cat In LqBase.CategoriasProdutos
                                   Where cat.Descricao Like FrmNovoStudioAvaliacao.SelPrincipal
                                   Select cat.IdCategoriaProduto

            Dim _IdCategoria As Integer = 0

            If BuscaIdCategoria.Count > 0 Then
                _IdCategoria = BuscaIdCategoria.First
            Else
                'insere nova categoria
                LqBase.InsereCategoriaProduto(FrmNovoStudioAvaliacao.SelPrincipal)
                _IdCategoria = LqBase.CategoriasProdutos.ToList.Last.IdCategoriaProduto
            End If

            Dim BuscaSubCategoria = From bas In LqBase.SubCategoriasProduto
                                    Where bas.IdCategoria = _IdCategoria
                                    Select bas.IdSubCategoria, bas.Descricao

            For Each row In BuscaSubCategoria.ToList

                LstIdSubCategoria.Items.Add(row.IdSubCategoria)
                CmbCategria.Items.Add(row.Descricao)

            Next

            'busca fabricante

            Dim busacFabricante = From fab In LqBase.Fabricantes
                                  Where fab.IdFabricante Like "*"
                                  Select fab.Fabricante, fab.IdFabricante

            For Each row In busacFabricante.ToList

                CmbFabricante.Items.Add(row.Fabricante)

            Next

        Else

            'procura subcategorias

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaIdCategoria = From cat In LqBase.CategoriasProdutos
                                   Where cat.Descricao Like FrmOtasOrdensCompra.Categoria
                                   Select cat.IdCategoriaProduto

            Dim _IdCategoria As Integer = 0

            If BuscaIdCategoria.Count > 0 Then
                _IdCategoria = BuscaIdCategoria.First
            Else
                'insere nova categoria
                LqBase.InsereCategoriaProduto(FrmOtasOrdensCompra.Categoria)
                _IdCategoria = LqBase.CategoriasProdutos.ToList.Last.IdCategoriaProduto
            End If

            Dim BuscaSubCategoria = From bas In LqBase.SubCategoriasProduto
                                    Where bas.IdCategoria = _IdCategoria
                                    Select bas.IdSubCategoria, bas.Descricao

            For Each row In BuscaSubCategoria.ToList

                LstIdSubCategoria.Items.Add(row.IdSubCategoria)
                CmbCategria.Items.Add(row.Descricao)

            Next

            'busca fabricante

            Dim busacFabricante = From fab In LqBase.Fabricantes
                                  Where fab.IdFabricante Like "*"
                                  Select fab.Fabricante, fab.IdFabricante

            For Each row In busacFabricante.ToList

                CmbFabricante.Items.Add(row.Fabricante)

            Next

        End If

    End Sub

    Private Sub BttAddSubcategoria_Click(sender As Object, e As EventArgs) Handles BttAddSubcategoria.Click

        FrmNovaSubCategoria.Show(Me)

    End Sub

    Private Sub BttFabricante_Click(sender As Object, e As EventArgs) Handles BttFabricante.Click

        FrmNovoFabricante.Show(Me)

    End Sub
End Class