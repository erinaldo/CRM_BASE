Public Class FrmTodosProdutos
    Private Sub FrmTodosProdutos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Verifica_Inicio()
    End Sub

    Public Sub Verifica_Inicio()

        DtBddIARA.Rows.Clear()
        DtSolicitacoesCadastro.Rows.Clear()

        'Carrega todos os produtos

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'carrega solicitacoes para cadastro

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaSolicitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                Where sol.IdCodCad = 0
                                Select sol.Descricao, sol.IdSolicitacaoCadastro, sol.IdCodExt, sol.PartNumber, sol.IdSubCategoria, sol.IdCategoria

        For Each row In BuscaSolicitacoes.ToList

            Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                                 Where cat.IdCategoriaProduto = row.IdCategoria
                                 Select cat.Descricao

            Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                    Where cat.IdSubCategoria = row.IdSubCategoria
                                    Select cat.Descricao

            DtSolicitacoesCadastro.Rows.Add(row.IdSolicitacaoCadastro, row.PartNumber, row.Descricao, BuscaCategoria.First, BuscaSubCategoria.First, row.IdCategoria, row.IdSubCategoria, row.IdCodExt)

        Next

        Dim BuscaProdutos = From Prod In LqBase.Produtos
                            Where Prod.IdProduto Like "*"
                            Select Prod.Descricao, Prod.Categoria, Prod.SubCategoria, Prod.Fabricante, Prod.IdProduto, Prod.CodFabricante, Prod.DisponivelOnLine, Prod.ControleValidade

        For Each row In BuscaProdutos.ToList

            'Busca dados no estoque

            Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                   Where arm.IdProduto = row.IdProduto
                                   Select arm.Qt

            Dim _Qt As Integer = 0

            For Each it In BuscaArmazenagem.ToList

                _Qt += it

            Next

            Dim IARA As String = ""

            If row.DisponivelOnLine = True Then

                IARA = "Sim"

            Else

                IARA = "Não"

            End If

            Dim Validade As String = ""

            If row.ControleValidade = True Then

                Validade = "Sim"

            Else

                Validade = "Não"

            End If

            Dim BuscaImagens = From Img In LqBase.ImagemProduto
                               Where Img.IdProduto = row.IdProduto
                               Select Img.Imagem

            Dim ImgProduto As Image = My.Resources.untitled_n

            'Poipula primeira imagem encontrada

            If BuscaImagens.Count > 0 Then

                Dim arrImage() As Byte
                Dim myMS As New IO.MemoryStream
                arrImage = BuscaImagens.First.ToArray

                For Each ar As Byte In arrImage
                    myMS.WriteByte(ar)
                Next

                ImgProduto = Image.FromStream(myMS)

            End If

            DtBddIARA.Rows.Add(ImgProduto, row.IdProduto, row.CodFabricante, row.Descricao, _Qt, IARA, Validade)

        Next

    End Sub
    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        FrmProduto.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        FrmLogin.Timer3.Enabled = True
        FrmPrincipal.Timer1.Enabled = True

        Me.Close()

    End Sub

    Private Sub FrmTodosProdutos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        FrmPrincipal.Timer1.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'abre form de ins
        'busca associação

        Dim LqOficina As New LqOficinaDataContext

        Dim _Codass As Integer = DtSolicitacoesCadastro.SelectedCells(0).Value

        FrmProduto.CodSol = _Codass

        FrmProduto.DtVinculoExterno.Rows.Clear()

        'busca associação ao modelo do veiculo

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaAssociação = From ass In LqOficina.AssociaçãoPeçaModelo
                              Where ass.IdSolicitaçãoCad = _Codass
                              Select ass.IdModeloVeic, ass.IdAssociacaoPecaModelo

        For Each row In BuscaAssociação.ToList

            Dim BuscaMOdelo = From mode In LqOficina.Modelos
                              Where mode.IdModelo = row.IdModeloVeic
                              Select mode.Modelo, mode.IdFabricante

            Dim BUscaFabricante = From fab In LqOficina.FabricantesVeiculo
                                  Where fab.Idfabricante = BuscaMOdelo.First.IdFabricante
                                  Select fab.Fabricante

            FrmProduto.DtVinculoExterno.Rows.Add("Oficina", BUscaFabricante.First & " - " & BuscaMOdelo.First.Modelo, row.IdModeloVeic, False, FrmProduto.ImageList1.Images(1), BUscaFabricante.First, BuscaMOdelo.First.Modelo, row.IdAssociacaoPecaModelo)

        Next

        FrmProduto.TxtCodFabricante.Text = DtSolicitacoesCadastro.SelectedCells(1).Value
        FrmProduto.TxtDescrição.Text = DtSolicitacoesCadastro.SelectedCells(2).Value

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCategorias = From cat In LqBase.CategoriasProdutos
                              Where cat.IdCategoriaProduto Like "*"
                              Select cat.Descricao, cat.IdCategoriaProduto

        FrmProduto.LstIdCategoria.Items.Clear()

        For Each item In BuscaCategorias.ToList

            FrmProduto.LstIdCategoria.Items.Add(item.IdCategoriaProduto)
            FrmProduto.CmbCategoria.Items.Add(item.Descricao)

        Next

        FrmProduto.CmbCategoria.Enabled = False
        FrmProduto.CmbCategoria.SelectedItem = DtSolicitacoesCadastro.SelectedCells(3).Value

        Dim BuscaSubCategorias = From cat In LqBase.SubCategoriasProduto
                                 Where cat.IdCategoria = Val(DtSolicitacoesCadastro.SelectedCells(5).Value)
                                 Select cat.Descricao, cat.IdSubCategoria

        FrmProduto.LstIdSubCategorias.Items.Clear()

        For Each item In BuscaSubCategorias.ToList

            FrmProduto.LstIdSubCategorias.Items.Add(item.IdSubCategoria)
            FrmProduto.CmbSubcategoria.Items.Add(item.Descricao)

        Next

        FrmProduto.CmbSubcategoria.Enabled = False
        FrmProduto.CmbSubcategoria.SelectedItem = DtSolicitacoesCadastro.SelectedCells(4).Value

        FrmProduto.LblCodExterno.Text = DtSolicitacoesCadastro.SelectedCells(7).Value

        FrmProduto.CmbFabricante.Enabled = True
        FrmProduto.BttAddFabricante.Enabled = True

        'busca categorias e subcategorias

        If Application.OpenForms.OfType(Of FrmProduto)().Count() = 0 Then

            FrmProduto.Show(Me)

        End If

    End Sub

    Private Sub DtBddIARA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellContentClick

    End Sub

    Private Sub DtBddIARA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellDoubleClick

        Me.Cursor = Cursors.WaitCursor

        'carrega os dados para o produto

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaProduto = From prod In LqBase.Produtos
                           Where prod.IdProduto = Val(DtBddIARA.SelectedCells(1).Value)
                           Select prod.IdProduto, prod.IdProdutoExt, prod.QtMin, prod.QtMax, prod.DisponivelOnLine, prod.ControleValidade, prod.Altura, prod.Largura, prod.Peso, prod.Profundidade, prod.Pctge, prod.Descricao, prod.CodBarras, prod.CodFabricante, prod.NCM, prod.Fabricante, prod.Categoria, prod.SubCategoria, prod.UnVenda, prod.UnCompra, prod.IdCategoria, prod.IdUnComp, prod.VendaDireta, prod.Insumo, prod.UsoInterno, prod.Reaproveitamento

        For Each row In BuscaProduto.ToList

            FrmProduto.IdProdutoCARR = row.IdProduto
            FrmProduto.TxtDescrição.Text = row.Descricao

            FrmProduto.TxtCodBarras.Text = row.CodBarras
            FrmProduto.TxtCodFabricante.Text = row.CodFabricante
            FrmProduto.TxtNCM.Text = row.NCM

            'busca fabricantes

            Dim BuscaFabricantes = From fab In LqBase.Fabricantes
                                   Where fab.IdFabricante Like "*"
                                   Select fab.Fabricante, fab.IdFabricante

            For Each row_fab In BuscaFabricantes.ToList

                FrmProduto.LstIdFabricante.Items.Add(row_fab.IdFabricante)
                FrmProduto.CmbFabricante.Items.Add(row_fab.Fabricante)

            Next

            FrmProduto.CmbFabricante.Enabled = False
            FrmProduto.CmbFabricante.SelectedItem = row.Fabricante

            'busca Categorias

            Dim BuscaCategorias = From fab In LqBase.CategoriasProdutos
                                  Where fab.IdCategoriaProduto Like "*"
                                  Select fab.Descricao, fab.IdCategoriaProduto

            For Each row_fab In BuscaCategorias.ToList

                FrmProduto.LstIdCategoria.Items.Add(row_fab.IdCategoriaProduto)
                FrmProduto.CmbCategoria.Items.Add(row_fab.Descricao)

            Next

            FrmProduto.CmbCategoria.Enabled = False
            FrmProduto.CmbCategoria.SelectedItem = row.Categoria

            'busca Categorias

            Dim BuscaSubCategorias = From fab In LqBase.SubCategoriasProduto
                                     Where fab.IdCategoria = row.IdCategoria
                                     Select fab.Descricao, fab.IdSubCategoria

            For Each row_fab In BuscaSubCategorias.ToList

                FrmProduto.LstIdSubCategorias.Items.Add(row_fab.IdSubCategoria)
                FrmProduto.CmbSubcategoria.Items.Add(row_fab.Descricao)

            Next

            FrmProduto.CmbSubcategoria.Enabled = False
            FrmProduto.CmbSubcategoria.SelectedItem = row.SubCategoria

            'busca Categorias

            'busca unidades
            Dim BuscaUnidades = From est In LqBase.UnidadeParametro
                                Where est.IdUnidade Like "*"
                                Select est.IdUnidade, est.Sigla, est.Descricao

            FrmProduto.LstIdUnidade.Items.Clear()
            FrmProduto.LstSigla.Items.Clear()
            FrmProduto.CmbUnidadeCompra.Items.Clear()

            For Each row_uni In BuscaUnidades.ToList
                FrmProduto.LstIdUnidade.Items.Add(row_uni.IdUnidade)
                FrmProduto.LstSigla.Items.Add(row_uni.Sigla)
                FrmProduto.CmbUnidadeCompra.Items.Add(row_uni.Sigla & " - " & row_uni.Descricao)
            Next

            FrmProduto.CmbUnidadeCompra.Enabled = False
            FrmProduto.CmbUnidadeCompra.SelectedItem = row.UnCompra

            'busca divisor
            Dim BuscaValor = From div In LqBase.UnidadesGeral
                             Where div.IdUnidade = row.IdUnComp
                             Select div.ft_X, div.ChaveValidada, div.IdUnidadeX

            FrmProduto.LstIdUnidadeFtx.Items.Clear()
            FrmProduto.LstDivisor.Items.Clear()
            FrmProduto.LstChavealidada.Items.Clear()
            FrmProduto.CmbUnidadeVenda.Items.Clear()

            For Each row_vlr In BuscaValor.ToList
                FrmProduto.LstIdUnidadeFtx.Items.Add(row_vlr.IdUnidadeX)
                FrmProduto.LstDivisor.Items.Add(row_vlr.ft_X)
                FrmProduto.LstChavealidada.Items.Add(row_vlr.ChaveValidada)
                'busca descricao chave
                Dim BuscaChave = From chave In LqBase.UnidadeParametro
                                 Where chave.IdUnidade = row_vlr.ChaveValidada
                                 Select chave.Descricao, chave.Sigla

                FrmProduto.CmbUnidadeVenda.Items.Add(BuscaChave.First.Sigla & " - " & BuscaChave.First.Descricao)
            Next

            FrmProduto.CmbUnidadeVenda.Enabled = False
            FrmProduto.CmbUnidadeVenda.SelectedItem = row.UnVenda

            'define os detalhes da forma de comercialização

            If row.UsoInterno = True Then
                FrmProduto.CkUsoInterno.Checked = True
            End If

            If row.Reaproveitamento = True Then
                FrmProduto.CkReaproveitamento.Checked = True
            End If

            If row.Insumo = True Then
                FrmProduto.CkInsumo.Checked = True
            End If

            If row.VendaDireta = True Then
                FrmProduto.CkVendaDireta.Checked = True
            End If

            If row.DisponivelOnLine = True Then
                FrmProduto.CkDisponibilzarIARA.Checked = True
            End If

            If row.ControleValidade = True Then
                FrmProduto.CkValidade.Checked = True
            End If

            If row.DisponivelOnLine = True Then
                FrmProduto.CkDisponibilzarIARA.Checked = True
            End If

            FrmProduto.NmQtMinima.Value = row.qtMin
            FrmProduto.NmQtMaxima.Value = row.QtMax

            FrmProduto.NmDpIara.Value = row.Pctge

            FrmProduto.NmAltura.Value = row.Altura
            FrmProduto.NmLargura.Value = row.Largura
            FrmProduto.NmProfundidade.Value = row.Profundidade

            FrmProduto.NmPesoT.Value = row.Peso

            FrmProduto.LblCodExterno.Text = row.IdProdutoExt

            'busca fornecedores vinculados

            Dim BuscaVinculosFornecedores = From model In LqBase.VinculoProdutoFornecedor
                                            Where model.IdProduto = row.IdProduto
                                            Select model.IdVinculoProdutoFornecedor, model.CodFornecedor, model.IdForncedor


            For Each row_veic In BuscaVinculosFornecedores.ToList

                Dim BuscaFornecedor = From model In LqBase.Fornecedores
                                      Where model.IdFornecedor = row_veic.IdForncedor
                                      Select model.Nome

                FrmProduto.DtVinculoExterno.Rows.Add(row_veic.IdForncedor, BuscaFornecedor.First, row_veic.CodFornecedor)

            Next

            'Busca produtos vinculados

            Dim BuscaVinculosProduto = From model In LqBase.VinculoProdutoProduto
                                       Where model.IdProduto = row.IdProduto
                                       Select model.IdProdutoFinal, model.Qt, model.IdVinculoProdutoProduto

            For Each row_veic In BuscaVinculosProduto.ToList

                Dim BuscaServico = From model In LqBase.Produtos
                                   Where model.IdProduto = row_veic.IdProdutoFinal
                                   Select model.Descricao, model.Categoria, model.SubCategoria

                Dim DescricaoServico As String = ""

                If BuscaServico.Count > 0 Then
                    DescricaoServico = BuscaServico.First.Descricao
                Else
                    DescricaoServico = "Erro"
                End If

                FrmProduto.DtProdutosVinculados.Rows.Add(row_veic.IdVinculoProdutoProduto, row_veic.IdProdutoFinal, DescricaoServico, BuscaServico.First.Categoria, BuscaServico.First.SubCategoria, row_veic.Qt, FrmProduto.ImageList1.Images(1))

            Next

            'Busca servicos 

            Dim BuscaVinculosServicos = From model In LqBase.VinculoProdutoServico
                                        Where model.IdProduto = row.IdProduto
                                        Select model.IdVinculoProdutoServico, model.IdServico


            For Each row_veic In BuscaVinculosServicos.ToList

                Dim BuscaServico = From model In LqBase.Servicos
                                   Where model.IdServico = row_veic.IdServico
                                   Select model.Descricao

                Dim DescricaoServico As String = ""

                If BuscaServico.Count > 0 Then
                    DescricaoServico = BuscaServico.First
                Else
                    DescricaoServico = "Erro"
                End If

                FrmProduto.DtServicos.Rows.Add(row_veic.IdVinculoProdutoServico, row_veic.IdServico, DescricaoServico, FrmProduto.ImageList1.Images(1))

            Next

            'BuscaModelos vinculados

            Dim Lqoficina As New LqOficinaDataContext
            Lqoficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim BuscaVinculosModelos = From model In Lqoficina.AssociaçãoPeçaModelo
                                       Where model.IdCodProd = row.IdProduto
                                       Select model.IdModeloVeic, model.IdAssociacaoPecaModelo


            For Each row_veic In BuscaVinculosModelos.ToList

                Dim BuscaModelos = From model In Lqoficina.Modelos
                                   Where model.IdModelo = row_veic.IdModeloVeic
                                   Select model.Modelo, model.IdFabricante, model.AnoModelo, model.Combustivel

                Dim BuscaFabricante = From model In Lqoficina.FabricantesVeiculo
                                      Where model.Idfabricante = BuscaModelos.First.IdFabricante
                                      Select model.Fabricante

                FrmProduto.DtVinculoExterno.Rows.Add("Oficina", BuscaFabricante.First & " - " & BuscaModelos.First.Modelo & " (" & BuscaModelos.First.AnoModelo & " - " & BuscaModelos.First.Combustivel & ")", row_veic.IdModeloVeic, False, FrmProduto.ImageList1.Images(1), BuscaFabricante.First, BuscaModelos.First.Modelo, row_veic.IdAssociacaoPecaModelo, BuscaModelos.First.AnoModelo, BuscaModelos.First.Combustivel)

            Next

            'busca imagens do produto

            Dim BuscaImagens = From img In LqBase.ImagemProduto
                               Where img.IdProduto = row.IdProduto
                               Select img.Imagem, img.IdImagem

            For Each it In BuscaImagens.ToList

                FrmProduto.ListaImagens.Items.Add("CdLc." & it.IdImagem)

                Dim arrImage() As Byte
                Dim myMS As New IO.MemoryStream
                arrImage = it.Imagem.ToArray

                For Each ar As Byte In arrImage
                    myMS.WriteByte(ar)
                Next

                FrmProduto.ImageList3.Images.Add(Image.FromStream(myMS))

            Next

            If FrmProduto.ImageList3.Images.Count > 0 Then
                FrmProduto.PintaInicio()
            End If

            'habilita campos de edição

            FrmProduto.CmbFabricante.Enabled = True
            FrmProduto.TxtCodBarras.Enabled = True
            FrmProduto.TxtNCM.Enabled = True
            FrmProduto.TxtCodFabricante.Enabled = True
            FrmProduto.CmbCategoria.Enabled = True
            FrmProduto.CmbSubcategoria.Enabled = True
            FrmProduto.CmbUnidadeCompra.Enabled = True
            FrmProduto.CmbUnidadeVenda.Enabled = True

        Next

        FrmProduto.BttAddCategoria.Enabled = True
        FrmProduto.BttAddFabricante.Enabled = True
        FrmProduto.BttAddSubcategoria.Enabled = True
        FrmProduto.BttAddUnidade.Enabled = True
        FrmProduto.BttAddUnidadeVEnda.Enabled = True

        Me.Cursor = Cursors.Arrow

        FrmProduto.Show(Me)

    End Sub
End Class