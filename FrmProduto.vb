Imports System.IO
Imports System.Net
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Public Class FrmProduto

    Dim _ChaveTemporaria As Integer
    Dim Lqgeral As New DtCadastroDataContext

    Public IdProdutoCARR As Integer = 0

    Private Sub BttAddColaborador_Click(sender As Object, e As EventArgs) Handles BttAddProduto.Click

        _ChaveTemporaria = 9 & TimeOfDay.Hour & TimeOfDay.Minute & TimeOfDay.Second

        CmbColaboradores.Text = ""

        BttAddProduto.Enabled = False
        BttEditColaborador.Enabled = False
        BttSalvarColaborador.Enabled = False
        BttCancelar.Enabled = True
        BttDesligar.Enabled = False
        CmbColaboradores.Enabled = False

        GpDadosPessoais.Enabled = True

        TxtDescrição.Enabled = True

        'carrega categorias de produtos

        'manda dados para o frmcadcolaboradores
        'carrega todos os estados
        Dim BuscaEstados = From est In Lqgeral.CategoriasProdutos
                           Where est.IdCategoriaProduto Like "*"
                           Select est.IdCategoriaProduto, est.Descricao

        CmbCategoria.Items.Clear()
        LstIdCategoria.Items.Clear()

        For Each row In BuscaEstados.ToList
            LstIdCategoria.Items.Add(row.IdCategoriaProduto)
            CmbCategoria.Items.Add(row.Descricao)
        Next

        'busca unidades
        Dim BuscaUnidades = From est In Lqgeral.UnidadeParametro
                            Where est.IdUnidade Like "*"
                            Select est.IdUnidade, est.Sigla, est.Descricao

        'LstIdUnidade.Items.Clear()
        'LstSigla.Items.Clear()
        'CmbUnidadeCompra.Items.Clear()

        'For Each row In BuscaUnidades.ToList
        '    LstIdUnidade.Items.Add(row.IdUnidade)
        '    LstSigla.Items.Add(row.Sigla)
        '    CmbUnidadeCompra.Items.Add(row.Sigla & " - " & row.Descricao)
        'Next


        'busca fabricante
        Dim BuscaFabricante = From est In Lqgeral.Fabricantes
                              Where est.IdFabricante Like "*"
                              Select est.IdFabricante, est.Fabricante

        LstIdFabricante.Items.Clear()
        CmbFabricante.Items.Clear()

        For Each row In BuscaFabricante.ToList
            LstIdFabricante.Items.Add(row.IdFabricante)
            CmbFabricante.Items.Add(row.Fabricante)
        Next

        TabControl2.SelectedIndex = 0

    End Sub

    Public LstIdCategoria As New ListBox

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If IdProdutoCARR = 0 Then
            If CmbCategoria.Enabled = True Then
                If CmbCategoria.Text = "" Then
                    If TxtDescrição.Text <> "" Then
                        CmbFabricante.Enabled = True
                        BttAddFabricante.Enabled = True
                    Else
                        CmbFabricante.Enabled = False
                        BttAddFabricante.Enabled = False

                        CmbFabricante.Text = Nothing
                    End If
                End If
            Else
                If TxtDescrição.Text <> "" Then
                    CmbFabricante.Enabled = True
                    BttAddFabricante.Enabled = True
                Else
                    CmbFabricante.Enabled = False
                    BttAddFabricante.Enabled = False

                    CmbFabricante.Text = Nothing
                End If
            End If
        End If

    End Sub

    Private Sub BttAddCategoria_Click(sender As Object, e As EventArgs) Handles BttAddCategoria.Click
        FrmNovaCategoraProduto.Show(Me)
    End Sub

    Public LstIdSubCategorias As New ListBox

    Private Sub CmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoria.SelectedIndexChanged

        If CmbCategoria.Enabled = True Then

            If CmbCategoria.Items.Contains(CmbCategoria.Text) Then

                CmbSubcategoria.Enabled = True
                BttAddSubcategoria.Enabled = True

                'busca subcategoria

                Lqgeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaSubCategorias = From cat In Lqgeral.SubCategoriasProduto
                                         Where cat.IdCategoria = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString
                                         Select cat.Descricao, cat.IdSubCategoria

                LstIdSubCategorias.Items.Clear()
                CmbSubcategoria.Items.Clear()

                For Each row In BuscaSubCategorias.ToList

                    LstIdSubCategorias.Items.Add(row.IdSubCategoria)
                    CmbSubcategoria.Items.Add(row.Descricao)

                Next

                If CmbSubcategoria.Text <> "" Then
                    CmbSubcategoria.SelectedItem = CmbSubcategoria.Text
                End If

            Else
                CmbSubcategoria.Enabled = True
                BttAddSubcategoria.Enabled = True
                CmbSubcategoria.Text = Nothing
            End If

        End If

    End Sub

    Private Sub BttAddSubcategoria_Click(sender As Object, e As EventArgs) Handles BttAddSubcategoria.Click
        FrmNovaSubCategoria.IdCategoria = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString
        FrmNovaSubCategoria.Show(Me)
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TxtNCM.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub CmbSubcategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSubcategoria.SelectedIndexChanged

        If CmbSubcategoria.Enabled = True Then
            If CmbFabricante.Items.Contains(CmbFabricante.Text) Then

                If CmbSubcategoria.Items.Contains(CmbSubcategoria.Text) Then
                    TxtNCM.Enabled = True
                    GpFotos.Enabled = True
                    CmbUnidadeCompra.Enabled = True
                    BttAddUnidade.Enabled = True
                Else
                    TxtNCM.Enabled = False
                    GpFotos.Enabled = False
                    CmbUnidadeCompra.Enabled = False
                    BttAddUnidade.Enabled = False

                    If Not CmbUnidadeCompra.Items.Contains(CmbUnidadeCompra.Text) Then
                        CmbUnidadeCompra.Text = ""
                    End If

                    TxtNCM.Text = ""
                End If

            End If
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        'configura o controle OpenFileDialog
        ofd1.Multiselect = False
        ofd1.Filter = "Jpeg|*.jpg|Gif|*.gif|Jpeg|*.jpeg|Bitmap|*.bmp|*|*"
        ofd1.RestoreDirectory = True
        ofd1.Title = "Procurar"

        'se não cancelou então atribui o nome selecionado a caixa de texto
        If ofd1.ShowDialog <> DialogResult.Cancel Then

            ImageList1.Images.Add(ImageList1.Images.Count - 1, Image.FromFile(ofd1.FileName))

            LstFotoProdutos.Items.Clear()

            For i As Integer = ImageList1.Images.Count - 1 To 0 Step -1
                LstFotoProdutos.Items.Add(i.ToString, ImageList1.Images.Keys(i))
            Next

        End If

    End Sub

    Public LstSigla As New ListBox
    Public LstIdUnidade As New ListBox

    Private Sub BttAddUnidade_Click(sender As Object, e As EventArgs) Handles BttAddUnidade.Click
        FrmUnidade.FormOri = 0

        If Application.OpenForms.OfType(Of FrmUnidade)().Count() = 0 Then

            FrmUnidade.Show(Me)

        End If

    End Sub

    Private Sub CkVendaDireta_CheckedChanged(sender As Object, e As EventArgs) Handles CkVendaDireta.CheckedChanged

        If CkVendaDireta.Checked = True Or CkUsoInterno.Checked = True Or CkReaproveitamento.Checked = True Or CkInsumo.Checked = True Then

            NmQtMaxima.Enabled = True
            NmQtMinima.Enabled = True
            CkDisponibilzarIARA.Enabled = True

            NmProfundidade.Enabled = True
            NmLargura.Enabled = True
            NmAltura.Enabled = True
            NmPesoT.Enabled = True

            CkValidade.Enabled = True

            BttSalvarProduto.Enabled = True

            BtnAddFornecedor.Enabled = True
            BtnProdutosVinculados.Enabled = True
            BtnServicosVindulados.Enabled = True
            BtnVinculoModelo.Enabled = True

        ElseIf CkVendaDireta.Checked = False And CkUsoInterno.Checked = False And CkReaproveitamento.Checked = False And CkInsumo.Checked = False Then

            NmQtMaxima.Enabled = False
            NmQtMinima.Enabled = False
            CkDisponibilzarIARA.Enabled = False

            NmQtMaxima.Value = 0
            NmQtMinima.Value = 1
            CkDisponibilzarIARA.Checked = False

            CkValidade.Enabled = False

            NmProfundidade.Value = 0
            NmLargura.Value = 0
            NmAltura.Value = 0
            NmPesoT.Value = 0
            CkValidade.Checked = False

            BttSalvarProduto.Enabled = False

            BtnAddFornecedor.Enabled = False
            BtnProdutosVinculados.Enabled = False
            BtnServicosVindulados.Enabled = False
            BtnVinculoModelo.Enabled = False

        End If

    End Sub

    Public LstIdUnidadeFtx As New ListBox
    Public LstDivisor As New ListBox
    Public LstChavealidada As New ListBox

    Private Sub CmbUnidadeCompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUnidadeCompra.SelectedIndexChanged

        If CmbUnidadeCompra.Enabled = True Then
            If CmbUnidadeCompra.Items.Contains(CmbUnidadeCompra.Text) Then
                CmbUnidadeVenda.Enabled = True
                BttAddUnidadeVEnda.Enabled = True
                'busca divisor
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaValor = From div In LqBase.UnidadesGeral
                                 Where div.IdUnidade = LstIdUnidade.Items(CmbUnidadeCompra.SelectedIndex).ToString
                                 Select div.ft_X, div.ChaveValidada, div.IdUnidadeX

                LstIdUnidadeFtx.Items.Clear()
                LstDivisor.Items.Clear()
                LstChavealidada.Items.Clear()
                CmbUnidadeVenda.Items.Clear()

                For Each row In BuscaValor.ToList
                    LstIdUnidadeFtx.Items.Add(row.IdUnidadeX)
                    LstDivisor.Items.Add(row.ft_X)
                    LstChavealidada.Items.Add(row.ChaveValidada)
                    'busca descricao chave
                    Dim BuscaChave = From chave In Lqgeral.UnidadeParametro
                                     Where chave.IdUnidade = row.ChaveValidada
                                     Select chave.Descricao, chave.Sigla

                    CmbUnidadeVenda.Items.Add(BuscaChave.First.Sigla & " - " & BuscaChave.First.Descricao)
                Next

            Else
                CmbUnidadeVenda.Enabled = False
                BttAddUnidadeVEnda.Enabled = False
                CmbUnidadeVenda.Text = ""
            End If
        End If
    End Sub

    Private Sub BttAddUnidadeVEnda_Click(sender As Object, e As EventArgs) Handles BttAddUnidadeVEnda.Click
        'manda dados para o frmcadcolaboradores
        'carrega todos os estados
        Dim BuscaEstados = From est In Lqgeral.UnidadeParametro
                           Where est.IdUnidade Like "*"
                           Select est.IdUnidade, est.Sigla, est.Descricao

        FrmUnidadeVenda.LstIdUnidade.Items.Clear()
        FrmUnidadeVenda.LstSigla.Items.Clear()
        FrmUnidadeVenda.CmbUnidadeCompra.Items.Clear()

        For Each row In BuscaEstados.ToList
            FrmUnidadeVenda.LstIdUnidade.Items.Add(row.IdUnidade)
            FrmUnidadeVenda.LstSigla.Items.Add(row.Sigla)
            FrmUnidadeVenda.CmbUnidadeCompra.Items.Add(row.Sigla & " - " & row.Descricao)
        Next

        FrmUnidadeVenda._IdUnidadeOrigem = LstIdUnidade.Items(CmbUnidadeCompra.SelectedIndex).ToString
        FrmUnidadeVenda.Show(Me)

    End Sub

    Private Sub CmbUnidadeVenda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUnidadeVenda.SelectedIndexChanged

        If CmbUnidadeVenda.Items.Contains(CmbUnidadeVenda.Text) Then
            CmbTrib.Enabled = True
        Else
            CmbTrib.Enabled = False
            CmbTrib.Text = ""
        End If

    End Sub

    Dim LstIdProduto As New ListBox
    Public LstIdFabricante As New ListBox
    Dim Lqoficina As New LqOficinaDataContext
    Dim LqEstoqueOnLine As New LqEstoqueIaraDataContext
    Dim LqFinaneiro As New LqFinanceiroDataContext

    Private Sub BttSalvarColaborador_Click(sender As Object, e As EventArgs) Handles BttSalvarColaborador.Click

    End Sub

    Public Markup As String

    Public _IdTrib As Integer = -1

    Private Sub FrmProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Lqgeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If CmbFabricante.Items.Count = 0 Then

            'busca fabricante
            Dim BuscaFabricante = From est In Lqgeral.Fabricantes
                                  Where est.IdFabricante Like "*"
                                  Select est.IdFabricante, est.Fabricante

            LstIdFabricante.Items.Clear()
            CmbFabricante.Items.Clear()

            For Each row In BuscaFabricante.ToList
                LstIdFabricante.Items.Add(row.IdFabricante)
                CmbFabricante.Items.Add(row.Fabricante)
            Next

        End If

        'busca unidades

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If CmbUnidadeCompra.Items.Count = 0 Then

            Dim BuscaUnidades = From uni In LqBase.UnidadeParametro
                                Where uni.IdUnidade Like "*"
                                Select uni.Descricao, uni.IdUnidade, uni.Sigla

            Dim _IndexSel As Integer = -1

            For Each uni In BuscaUnidades.ToList

                LstIdUnidade.Items.Add(uni.IdUnidade)
                CmbUnidadeCompra.Items.Add(uni.Sigla & " - " & uni.Descricao)

                If Application.OpenForms.OfType(Of FrmProdutosNfRecebimento)().Count() > 0 Then

                    If uni.Sigla = FrmProdutosNfRecebimento.DtEsperados.SelectedCells(6).Value.ToString Then

                        _IndexSel = CmbUnidadeCompra.Items.Count - 1

                    End If

                End If

            Next

            CmbUnidadeCompra.SelectedIndex = _IndexSel

        End If

        If CmbCategoria.Items.Count = 0 Then

            Dim BuscaUnidades = From uni In LqBase.CategoriasProdutos
                                Where uni.IdCategoriaProduto Like "*"
                                Select uni.Descricao, uni.IdCategoriaProduto

            For Each uni In BuscaUnidades.ToList

                LstIdCategoria.Items.Add(uni.IdCategoriaProduto)
                CmbCategoria.Items.Add(uni.Descricao)

            Next

        End If

        If IdProdutoCARR > 0 Then

            'busca o id trib e seleciona a lista

            Dim BuscaProduto = From prod In LqBase.Produtos
                               Where prod.IdProduto = IdProdutoCARR
                               Select prod.IdTrib

            _IdTrib = BuscaProduto.First

        End If

        'carrega tributos

        LqFinaneiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaTrib = From trib In LqFinaneiro.CFOP_PDR
                        Where trib.Tipo Like "Vendas"
                        Select trib.CFOP, trib.ICMS, trib.IdTrib, trib.IPI, trib.Padrao, trib.Tipo

        LstIdTrib.Items.Clear()
        CmbTrib.Items.Clear()

        Dim IndexSel As Integer = -1

        For Each row In BuscaTrib.ToList

            LstIdTrib.Items.Add(row.IdTrib)
            CmbTrib.Items.Add(row.CFOP & " - ICMS: " & row.ICMS & " - IPI: " & row.IPI)

            If row.IdTrib = _IdTrib Then
                IndexSel = LstIdTrib.Items.Count - 1
            End If

        Next

        If IndexSel > -1 Then
            CmbTrib.SelectedIndex = IndexSel
        End If

    End Sub

    Dim LstIdTrib As New ListBox

    Private Sub CmbCategoria_TextChanged(sender As Object, e As EventArgs) Handles CmbCategoria.TextChanged
        If CmbCategoria.Text = "" Then
            CmbSubcategoria.Enabled = False
            CmbSubcategoria.Text = ""
        End If
    End Sub

    Private Sub CmbUnidadeCompra_TextChanged(sender As Object, e As EventArgs) Handles CmbUnidadeCompra.TextChanged
        If CmbUnidadeCompra.Text = "" Then
            CmbUnidadeVenda.Enabled = False
            CmbUnidadeVenda.Text = ""
        End If
    End Sub

    Public SemSolicitação As Boolean = False

    Private Sub CmbFabricante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFabricante.SelectedIndexChanged

        If CmbFabricante.Enabled = True Then
            If CmbFabricante.Items.Contains(CmbFabricante.Text) Then

                If CmbCategoria.Text = "" Then
                    'habilita próximos campos

                    If CodFabricante = "0" Then
                        TxtCodFabricante.Enabled = True
                    Else
                        TxtCodFabricante.Enabled = False
                        TxtCodFabricante.Text = CodFabricante
                    End If

                    TxtCodBarras.Enabled = True
                    TxtNCM.Enabled = False
                    CmbUnidadeCompra.Enabled = False
                    BttAddUnidade.Enabled = False

                    CmbCategoria.Enabled = True
                    BttAddCategoria.Enabled = True

                    If CmbSubcategoria.Items.Contains(CmbSubcategoria.Text) Then

                        If TxtNCM.Text = "" Then
                            TxtNCM.Enabled = True
                        End If

                        CmbUnidadeCompra.Enabled = True
                        BttAddUnidade.Enabled = True
                    Else

                        TxtNCM.Enabled = False
                        GpFotos.Enabled = False
                        CmbUnidadeCompra.Enabled = False
                        BttAddUnidade.Enabled = False

                        If Not CmbUnidadeCompra.Items.Contains(CmbUnidadeCompra.Text) Then
                            CmbUnidadeCompra.Text = ""
                        End If

                    End If

                Else

                    TxtCodFabricante.Enabled = True
                    TxtCodBarras.Enabled = True
                    TxtNCM.Enabled = True
                    CmbUnidadeCompra.Enabled = True
                    BttAddUnidade.Enabled = True

                End If

            Else

                TxtCodFabricante.Enabled = False
                TxtCodBarras.Enabled = False
                CmbCategoria.Enabled = False
                BttAddCategoria.Enabled = False

                TxtCodFabricante.Text = Nothing
                TxtCodBarras.Text = Nothing
                CmbCategoria.Text = Nothing

            End If
        End If

    End Sub

    Private Sub CmbFabricante_TextChanged(sender As Object, e As EventArgs) Handles CmbFabricante.TextChanged
        If CmbFabricante.Text = "" Then
            TxtCodFabricante.Enabled = False
            TxtCodBarras.Enabled = False
            CmbCategoria.Enabled = False
            BttAddCategoria.Enabled = False

            TxtCodFabricante.Text = Nothing
            TxtCodBarras.Text = Nothing
            CmbCategoria.Text = Nothing
        End If
    End Sub

    Private Sub BttAddFabricante_Click(sender As Object, e As EventArgs) Handles BttAddFabricante.Click
        FrmNovoFabricante.FormOri = 0
        FrmNovoFabricante.Show(Me)
    End Sub

    Private Sub CmbColaboradores_Click(sender As Object, e As EventArgs) Handles CmbColaboradores.Click

    End Sub

    Private Sub CmbColaboradores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbColaboradores.SelectedIndexChanged

        If CmbColaboradores.Items.Contains(CmbColaboradores.Text) Then
            BttEditColaborador.Enabled = True
            BttDesligar.Enabled = True
        Else
            BttEditColaborador.Enabled = False
            BttDesligar.Enabled = False
        End If

    End Sub

    Private Sub BttEditColaborador_Click(sender As Object, e As EventArgs) Handles BttEditColaborador.Click

        _ChaveTemporaria = LstIdProduto.Items(CmbColaboradores.SelectedIndex).ToString

        'busca colaborador selecionado

        BttAddProduto.Enabled = False
        BttEditColaborador.Enabled = False
        BttSalvarColaborador.Enabled = True
        BttCancelar.Enabled = True
        BttDesligar.Enabled = False
        CmbColaboradores.Enabled = False

        GpDadosPessoais.Enabled = True
        TxtDescrição.Enabled = True

        'carrega todos os estados
        Dim BuscaEstados = From est In Lqgeral.CategoriasProdutos
                           Where est.IdCategoriaProduto Like "*"
                           Select est.IdCategoriaProduto, est.Descricao

        CmbCategoria.Items.Clear()
        LstIdCategoria.Items.Clear()

        For Each row In BuscaEstados.ToList
            LstIdCategoria.Items.Add(row.IdCategoriaProduto)
            CmbCategoria.Items.Add(row.Descricao)
        Next

        'busca unidades
        Dim BuscaUnidades = From est In Lqgeral.UnidadeParametro
                            Where est.IdUnidade Like "*"
                            Select est.IdUnidade, est.Sigla, est.Descricao

        LstIdUnidade.Items.Clear()
        LstSigla.Items.Clear()
        CmbUnidadeCompra.Items.Clear()

        For Each row In BuscaUnidades.ToList
            LstIdUnidade.Items.Add(row.IdUnidade)
            LstSigla.Items.Add(row.Sigla)
            CmbUnidadeCompra.Items.Add(row.Sigla & " - " & row.Descricao)
        Next


        'busca fabricante
        Dim BuscaFabricante = From est In Lqgeral.Fabricantes
                              Where est.IdFabricante Like "*"
                              Select est.IdFabricante, est.Fabricante

        LstIdFabricante.Items.Clear()
        CmbFabricante.Items.Clear()

        For Each row In BuscaFabricante.ToList
            LstIdFabricante.Items.Add(row.IdFabricante)
            CmbFabricante.Items.Add(row.Fabricante)
        Next

        'busca produto

        Dim BuscaProdutoCadastrado = From prod In Lqgeral.Produtos
                                     Where prod.IdProduto = _ChaveTemporaria
                                     Select prod.Altura, prod.Largura, prod.Profundidade, prod.Peso, prod.Descricao, prod.Fabricante, prod.CodBarras, prod.CodFabricante, prod.Categoria, prod.SubCategoria, prod.UnCompra, prod.UnVenda, prod.UsoInterno, prod.VendaDireta, prod.Insumo, prod.NCM, prod.Reaproveitamento

        TxtDescrição.Text = BuscaProdutoCadastrado.First.Descricao
        TxtCodFabricante.Text = BuscaProdutoCadastrado.First.CodFabricante
        CmbFabricante.SelectedItem = BuscaProdutoCadastrado.First.Fabricante
        CmbCategoria.SelectedItem = BuscaProdutoCadastrado.First.Categoria
        CmbSubcategoria.SelectedItem = BuscaProdutoCadastrado.First.SubCategoria
        TxtNCM.Text = BuscaProdutoCadastrado.First.NCM

        TxtCodBarras.Text = BuscaProdutoCadastrado.First.CodBarras

        CkInsumo.Checked = BuscaProdutoCadastrado.First.Insumo
        CkVendaDireta.Checked = BuscaProdutoCadastrado.First.VendaDireta
        CkReaproveitamento.Checked = BuscaProdutoCadastrado.First.Reaproveitamento
        CkUsoInterno.Checked = BuscaProdutoCadastrado.First.UsoInterno

        CmbUnidadeCompra.SelectedItem = BuscaProdutoCadastrado.First.UnCompra
        CmbUnidadeVenda.SelectedItem = BuscaProdutoCadastrado.First.UnVenda

        NmAltura.Value = BuscaProdutoCadastrado.First.Altura
        NmLargura.Value = BuscaProdutoCadastrado.First.Largura
        NmProfundidade.Value = BuscaProdutoCadastrado.First.Profundidade
        NmPeso.Value = BuscaProdutoCadastrado.First.Peso

        'busca se item é disponivel na iara

        Dim BuscaItensIara = From cat In LqEstoqueOnLine.CardapioIProdutosARA
                             Where cat.IdCodProdInterno = LstIdProduto.Items(CmbColaboradores.SelectedIndex).ToString And cat.IdClienteIARA = FrmPrincipal.IdCliente
                             Select cat.IdItemEstoqueIARA, cat.Status, cat.TTEstoque, cat.MaximoPorVenda, cat.MInimoPorVenda

        If BuscaItensIara.Count > 0 Then

            If BuscaItensIara.First.Status = True Then

                CodProdIara = BuscaItensIara.First.IdItemEstoqueIARA

                CkDisponibilzarIARA.Checked = BuscaItensIara.First.Status

                NmDpIara.Value = BuscaItensIara.First.TTEstoque

                NmQtMinima.Value = BuscaItensIara.First.MInimoPorVenda

                NmQtMaxima.Value = BuscaItensIara.First.MaximoPorVenda

            Else

                CodProdIara = BuscaItensIara.First.IdItemEstoqueIARA

                CkDisponibilzarIARA.Checked = BuscaItensIara.First.Status

                NmDpIara.Value = BuscaItensIara.First.TTEstoque

                NmQtMinima.Value = BuscaItensIara.First.MInimoPorVenda

                NmQtMaxima.Value = BuscaItensIara.First.MaximoPorVenda

            End If

        Else

            CodProdIara = 0

        End If

    End Sub

    Dim CodProdIara As Integer

    Private Sub BttCancelar_Click(sender As Object, e As EventArgs) Handles BttCancelar.Click

        'limpa campos

        TxtDescrição.Text = Nothing
        GpDadosPessoais.Enabled = False

        'habilita campos

        BttSalvarColaborador.Enabled = False
        BttCancelar.Enabled = False
        BttAddProduto.Enabled = True

        CmbColaboradores.Enabled = True
        CmbColaboradores.Text = ""

    End Sub

    Public CodSol As Integer = 0
    Public CodFabricante As String = 0

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub CkDisponibilzarIARA_CheckedChanged(sender As Object, e As EventArgs) Handles CkDisponibilzarIARA.CheckedChanged

        If CkDisponibilzarIARA.Checked = True Then

            NmDpIara.Enabled = True
            BttSalvarProduto.Enabled = False

        Else

            NmDpIara.Enabled = False
            NmDpIara.Value = 0
            BttSalvarProduto.Enabled = True

        End If

    End Sub

    Private Sub NmQtMaxima_ValueChanged(sender As Object, e As EventArgs) Handles NmQtMaxima.ValueChanged

        If NmQtMaxima.Value > 0 Then

            LblInd.Visible = False

        Else

            LblInd.Visible = True

        End If

    End Sub

    Private Sub Panel17_Paint(sender As Object, e As PaintEventArgs) Handles Panel17.Paint

    End Sub

    Public _idVeiculo As Integer
    Public Receb As Boolean = False
    Public Index As Integer = -1

    Dim LqBase As New DtCadastroDataContext

    Dim CodExt As Integer = 0

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Me.Cursor = Cursors.WaitCursor

        'Try

        'insere produto na base
        Dim _IdCategoria As Integer = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString
        Dim _IdSubCategoria As Integer = LstIdSubCategorias.Items(CmbSubcategoria.SelectedIndex).ToString
        Dim _IdUnidade As Integer = LstIdUnidade.Items(CmbUnidadeCompra.SelectedIndex).ToString
        Dim _IdUnidadeVenda As Integer = LstChavealidada.Items(CmbUnidadeVenda.SelectedIndex).ToString
        Dim _IdFabricante As Integer = LstIdFabricante.Items(CmbFabricante.SelectedIndex).ToString

        Dim _idProduto As String = IdProdutoCARR
        Dim _idProdutoSalvo As String = "*"
        Dim IdProdutoOriginal As String = ""

        'atualiza codigo externo

        If LblCodExterno.Text <> "0" Then

            Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_produtos_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                & "&IdProdutoEst=" & LblCodExterno.Text & "&Descricao=" & TxtDescrição.Text & "&Categoria=" & CmbCategoria.Text _
                & "&SubCAtegoria=" & CmbSubcategoria.Text & "&Fabricante=" & CmbFabricante.Text & "&IdProdutoINterno=" & _idProduto

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim CapturaTexto As String = baseUrl

        ElseIf LblCodExterno.Text = "0" Then

            'If CkDisponibilzarIARA.Checked = True Then

            Dim baseUrl As String = "http://www.iarasoftware.com.br/cria_produtos_online_local.php?CodFabricante=" & TxtCodFabricante.Text & "&Descricao=" & TxtDescrição.Text _
                        & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&FabricanteVeic=ND&ModeloVeic=ND&AnoMod=0&AnoFab=0" _
                        & "&Categoria=" & CmbCategoria.Text _
                        & "&SubCAtegoria=" & CmbSubcategoria.Text & "&Fabricante=" & CmbFabricante.Text & "&IdProdutoINterno=" & _idProduto

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            'End If

            Dim CapturaTexto As String = baseUrl

            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            'atualiza codexterno produto

            LblCodExterno.Text = read.Item(0).Id

            'insere os vinculos do modelo

        End If


        _idProduto = "*"

        Dim IdTribEnc As Integer = 0

        Try
            IdTribEnc = LstIdTrib.Items(CmbTrib.SelectedIndex).ToString
        Catch ex As Exception
            IdTribEnc = 0
        End Try

        If IdProdutoCARR = 0 Then


            Lqgeral.InsereNovoProduto(TxtDescrição.Text, _IdFabricante, CmbFabricante.Text, TxtCodFabricante.Text, TxtCodBarras.Text, _IdCategoria, CmbCategoria.Text, _IdSubCategoria,
                       CmbSubcategoria.Text, TxtNCM.Text, _IdUnidade, CmbUnidadeCompra.Text, _IdUnidadeVenda _
                                                , CmbUnidadeVenda.Text, CkVendaDireta.CheckState, CkInsumo.CheckState, CkUsoInterno.CheckState, CkReaproveitamento.CheckState, NmAltura.Value,
                                                  NmLargura.Value, NmProfundidade.Value, NmPesoT.Value, CkValidade.CheckState, 0, Markup, CkDisponibilzarIARA.CheckState,
                                                  NmDpIara.Value, NmQtMinima.Value, NmQtMaxima.Value, LblCodExterno.Text, IdTribEnc)

            Dim BuscaIdProdutoCad = From buscaProd In LqBase.Produtos
                                    Where buscaProd.Descricao Like TxtDescrição.Text
                                    Select buscaProd.IdProduto
                                    Order By IdProduto Descending

            _idProduto = BuscaIdProdutoCad.First
            _idProdutoSalvo = _idProduto

            IdProdutoOriginal = "*"

            'solicita cotação para o item recem caastrado

            If Receb = False Then
                LqFinaneiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                LqFinaneiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, _idProdutoSalvo, CodSol, 0, Now.Date, Today.TimeOfDay, 0, 0, 0, 0, False, 0, Now.Date, Now.TimeOfDay, 0, 0, 0)
            End If

        ElseIf IdProdutoCARR > 0 Then

            Lqgeral.AtualizaProduto(IdProdutoCARR, TxtDescrição.Text, _IdFabricante, CmbFabricante.Text, TxtCodFabricante.Text, TxtCodBarras.Text, _IdCategoria, CmbCategoria.Text, _IdSubCategoria,
                   CmbSubcategoria.Text, TxtNCM.Text, _IdUnidade, CmbUnidadeCompra.Text, _IdUnidadeVenda _
                                            , CmbUnidadeVenda.Text, CkVendaDireta.CheckState, CkInsumo.CheckState, CkUsoInterno.CheckState,
                                              CkReaproveitamento.CheckState, NmAltura.Value, NmLargura.Value, NmProfundidade.Value, NmPesoT.Value,
                                              CkValidade.CheckState, 0, 0, CkDisponibilzarIARA.CheckState, NmDpIara.Value, NmQtMinima.Value, NmQtMaxima.Value, LblCodExterno.Text, IdTribEnc)

            _idProduto = IdProdutoCARR
            _idProdutoSalvo = _idProduto

        End If

        'insere caracteristicas
        If LblCodExterno.Text <> "0" Then

            Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_produtos_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                & "&IdProdutoEst=" & LblCodExterno.Text & "&Descricao=" & TxtDescrição.Text & "&Categoria=" & CmbCategoria.Text _
                & "&SubCAtegoria=" & CmbSubcategoria.Text & "&Fabricante=" & CmbFabricante.Text & "&IdProdutoINterno=" & _idProduto

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim CapturaTexto As String = baseUrl

        ElseIf LblCodExterno.Text = "0" Then

            'If CkDisponibilzarIARA.Checked = True Then

            Dim baseUrl As String = "http://www.iarasoftware.com.br/cria_produtos_online_local.php?CodFabricante=" & TxtCodFabricante.Text & "&Descricao=" & TxtDescrição.Text _
                        & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&FabricanteVeic=ND&ModeloVeic=ND&AnoMod=0&AnoFab=0" _
                        & "&Categoria=" & CmbCategoria.Text _
                        & "&SubCAtegoria=" & CmbSubcategoria.Text & "&Fabricante=" & CmbFabricante.Text & "&IdProdutoINterno=" & _idProduto

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            'End If

            Dim CapturaTexto As String = baseUrl

            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(content)

            'atualiza codexterno produto

            LblCodExterno.Text = read.Item(0).Id

        End If

        Lqgeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If IdProdutoOriginal = "*" Then

            _idProduto = "*"

        End If

        'busca item recem cadastrado

        Dim BuscaProduto = From prod In Lqgeral.Produtos
                           Where prod.IdProduto Like _idProduto
                           Select prod.IdProduto
                           Order By IdProduto Descending

        For i As Integer = 0 To ImageList3.Images.Count - 1

            If Not ListaImagens.Items(i).ToString.StartsWith("CdLc.") Then

                Dim Pic As Image = Image.FromFile(ListaImagens.Items(i).ToString)

                Dim arrImage() As Byte
                Dim strImage As String
                Dim myMs As New IO.MemoryStream

                '5rt3w6e5,gq6KL
                If Not IsNothing(Pic) Then
                    Pic.Save(myMs, Pic.RawFormat)
                    arrImage = myMs.GetBuffer
                    strImage = "?"
                Else
                    arrImage = Nothing
                    strImage = "NULL"
                End If

                Lqgeral.InsereImagemProduto(BuscaProduto.First, arrImage)

                myMs.Dispose()

            End If

        Next


        'atualiza links
        Lqoficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
        LqFinaneiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        If CodSol > 0 Then

            Lqoficina.AtualizaSolicitacaoPeca(CodSol, BuscaProduto.First, TxtCodFabricante.Text)
            Lqoficina.AtualizaItemSolucaoN(CodSol, BuscaProduto.First)
            Lqoficina.AtualizaSolicitacaoVinculoProduto(CodSol, BuscaProduto.First, 0)
            LqFinaneiro.AtualizaSolicitacaoProdutoIara(CodSol, BuscaProduto.First, 0)
            LqFinaneiro.AtualizaSolicitacaoCad_SolicitacaoCompra(CodSol, BuscaProduto.First)
            Lqoficina.AtualizaSolicitacaoAssociacaoPecaProduto(BuscaProduto.First, CodSol)
            'atualiza solicitacao ao estoque
            Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
            LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

            LqEstoqueLocal.AtualizaSolicitacaoEstoque_cadProd(CodSol, BuscaProduto.First)

        End If

        'popula valores no combobox

        Dim BuscaProdutoCadastrado = From prod In Lqgeral.Produtos
                                     Where prod.IdProduto Like "*"
                                     Select prod.Descricao, prod.IdProduto

        LstIdProduto.Items.Clear()

        CmbColaboradores.Items.Clear()

        For Each row In BuscaProdutoCadastrado.ToList
            LstIdProduto.Items.Add(row.IdProduto)
            CmbColaboradores.Items.Add(row.Descricao)
        Next

        'verifica se produto esta hospedado na IARA

        LqEstoqueOnLine.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueDistribuidorOnLine


        Dim IdProdutoIara As Integer = 0

        Dim IdExternoSlv As Integer = 0

        If CkDisponibilzarIARA.Checked = True Then

            If CodProdIara = 0 Then

                'insereprodutoIARA
                'API verifica se insere ou se atualiza

                Dim PtNumber As String = "ND"

                If TxtCodFabricante.Text <> "" Then
                    PtNumber = TxtCodFabricante.Text
                End If

                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_catalogo_cliente.php?IdProdutoInterno=" & BuscaProduto.First &
                    "&Tipo=0&Descricao=" & TxtDescrição.Text & "&Fabricante=" & CmbFabricante.Text & "&DataInclusao=" & Now.Date & "&Validade=0&IdPromocaoVinc=0&ValorUnit=0&Status=0&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&QtDisponivel=0" & "&PartNumber=" & PtNumber & "&Prazo=0"

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)
                'End If

                Dim CapturaTexto As String = baseUrl

                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

                CodProdIara = read.Item(0).Id

                LqBase.AtualizaProduto(BuscaProduto.First, TxtDescrição.Text, _IdFabricante, CmbFabricante.Text, TxtCodFabricante.Text, TxtCodBarras.Text, _IdCategoria, CmbCategoria.Text, _IdSubCategoria,
                   CmbSubcategoria.Text, TxtNCM.Text, _IdUnidade, CmbUnidadeCompra.Text, _IdUnidadeVenda _
                                            , CmbUnidadeVenda.Text, CkVendaDireta.CheckState, CkInsumo.CheckState, CkUsoInterno.CheckState,
                                              CkReaproveitamento.CheckState, NmAltura.Value, NmLargura.Value, NmProfundidade.Value, NmPesoT.Value,
                                              CkValidade.CheckState, 0, 0, CkDisponibilzarIARA.CheckState, NmDpIara.Value, NmQtMinima.Value, NmQtMaxima.Value, LblCodExterno.Text, IdTribEnc)

            Else

                'AtualizaBaseIara

                Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_produto_venda_online.php?IdProdutoInterno=" & BuscaProduto.First &
                    "&Tipo=0&Descricao=" & TxtDescrição.Text & "&Fabricante=" & CmbFabricante.Text & "&DataInclusao=" & Now.Date & "&Validade=0&IdPromocaoVinc=0&ValorUnit=0&Status=0&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&QtDisponivel=0" & "&PartNumber=" & TxtCodFabricante.Text

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)
                'End If

                Dim CapturaTexto As String = baseUrl

                LqBase.AtualizaProduto(BuscaProduto.First, TxtDescrição.Text, _IdFabricante, CmbFabricante.Text, TxtCodFabricante.Text, TxtCodBarras.Text, _IdCategoria, CmbCategoria.Text, _IdSubCategoria,
                   CmbSubcategoria.Text, TxtNCM.Text, _IdUnidade, CmbUnidadeCompra.Text, _IdUnidadeVenda _
                                            , CmbUnidadeVenda.Text, CkVendaDireta.CheckState, CkInsumo.CheckState, CkUsoInterno.CheckState,
                                              CkReaproveitamento.CheckState, NmAltura.Value, NmLargura.Value, NmProfundidade.Value, NmPesoT.Value,
                                              CkValidade.CheckState, 0, 0, CkDisponibilzarIARA.CheckState, NmDpIara.Value, NmQtMinima.Value, NmQtMaxima.Value, CodProdIara, IdTribEnc)

            End If

        End If

        'cria vinculos com fornecedores

        For Each row As DataGridViewRow In DtVinculoFornec.Rows

            Dim IdFRNC As String = row.Cells(0).Value.ToString
            Dim CodFRNC As String = row.Cells(2).Value.ToString

            LqBase.InsereVinculoProdutoFornecedor(BuscaProduto.First, IdFRNC, CodFRNC)

        Next

        'cria vinculos com produtos

        For Each row As DataGridViewRow In DtProdutosVinculados.Rows

            If row.Cells(0).Value = 0 Then

                Dim IdProdFinal As String = row.Cells(1).Value.ToString
                Dim Qt As String = row.Cells(5).Value.ToString

                LqBase.InsereNovoVinculoProduto(BuscaProduto.First, IdProdFinal, Qt)

            End If

        Next

        'cria vinculos com servicos

        For Each row As DataGridViewRow In DtServicos.Rows

            If row.Cells(0).Value = 0 Then

                Dim IdServ As String = row.Cells(1).Value.ToString

                LqBase.InsereNovoVinculoServico(BuscaProduto.First, IdServ)

            End If

        Next

        'Vincula item externos

        For Each row As DataGridViewRow In DtVinculoExterno.Rows

            Dim CodFRNC As String = row.Cells(2).Value.ToString

            Dim Create As Boolean = row.Cells(3).Value

            Dim Description As String = row.Cells(1).Value

            Dim FabricanteString As String = row.Cells(5).Value
            Dim ModeloString As String = row.Cells(6).Value
            Dim AnoString As String = row.Cells(8).Value
            Dim CombustivelString As String = row.Cells(9).Value

            If Create = True Then

                'cria associação com o modelo 
                Lqoficina.InsereAssociacaoPecaModelo(_idProdutoSalvo, 0, CodFRNC)

                'cria na base on line
                Dim baseProdutoEstoqueAss As String = "http://www.iarasoftware.com.br/create_novo_produto_local_cad.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&CodFabricante=" & TxtCodFabricante.Text & "&Descricao=" & TxtDescrição.Text & "&FabricanteVeic=" & row.Cells(5).Value & "&ModeloVeic=" & row.Cells(6).Value & "&AnoFab=" & row.Cells(8).Value & "&AnoMod=" & row.Cells(9).Value & "&Categoria=" & CmbCategoria.Text & "&SubCAtegoria=" & CmbSubcategoria.SelectedItem & "&Fabricante=" & CmbFabricante.SelectedItem & "&IdProdutoINterno=" _
                        & _idProduto

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientProdutoEstoqueAss = New WebClient()
                Dim contentProdutoEstoqueAss = syncClientProdutoEstoqueAss.DownloadString(baseProdutoEstoqueAss)

            End If

            If CkDisponibilzarIARA.Checked = True Then

                'procura e resolve pela web

                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_vinculo_modelo_catalogo_online.php?Modelo=" & Description & "&Fabricante=" & FabricanteString & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdProduto=" & _idProduto

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)
                'End If

                Dim CapturaTexto As String = baseUrl

            End If
            'cria vinculos nao criados

        Next

        'envia informção do cadastro s possivel

        If SemSolicitação = True Then

            FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(1).Value = BuscaProduto.First

            FrmReceberMercadoria.TxtAltura.Value = NmAltura.Value
            FrmReceberMercadoria.TxtLargura.Value = NmLargura.Value
            FrmReceberMercadoria.TxtProfundidade.Value = NmProfundidade.Value
            FrmReceberMercadoria.TxtPeso.Value = NmPesoT.Value


            FrmReceberMercadoria.LblCategoria.Text = CmbCategoria.Text
            FrmReceberMercadoria.LblSubCategoria.Text = CmbSubcategoria.Text
            FrmReceberMercadoria.LblFabricante.Text = CmbFabricante.Text

            Dim Cm As String = ""

            If CkVendaDireta.Checked = True Then
                Cm = "Venda direta"
            End If

            If CkInsumo.Checked = True Then

                If Cm = "" Then
                    Cm = "Insumo"
                Else
                    Cm &= " / Insumo"
                End If

            End If

            If CkUsoInterno.Checked = True Then

                If Cm = "" Then
                    Cm = "Uso interno"
                Else
                    Cm &= " / Uso interno"
                End If

            End If

            If CkReaproveitamento.Checked = True Then

                If Cm = "" Then
                    Cm = "Reaproveitamento"
                Else
                    Cm &= " / Reaproveitamento"
                End If

            End If

            'FrmReceberMercadoria.LblComercializaçao.Text = Cm

            FrmReceberMercadoria.NumericUpDown1.Maximum = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(7).Value

        End If

        'verifica se há solicitação de cadastro de peça

        If Receb = False Then

            Dim Oficina = From ofc In Lqoficina.SolicitacaoCadastroPeca
                          Where ofc.IdCodCad = 0
                          Select ofc.DataSol, ofc.HoraSol, ofc.IdSolicitante, ofc.Descricao, ofc.IdSolicitacaoCadastro, ofc.PartNumber

            FrmSolicitaçõesCadastro.DtProdutos.Rows.Clear()

            For Each row In Oficina.ToList

                'busca associação

                Dim BuscaAssociação = From ass In Lqoficina.VinculoProdutoModelo
                                      Where ass.IdSolicitacaoCad = row.IdSolicitacaoCadastro
                                      Select ass.IdModeloVeic, ass.IdVersaoVeiculo

                If BuscaAssociação.Count > 0 Then

                    'busca associação ao modelo do veiculo

                    Dim BuscaMOdelo = From mode In Lqoficina.Modelos
                                      Where mode.IdModelo = BuscaAssociação.First.IdModeloVeic
                                      Select mode.Modelo, mode.IdFabricante

                    Dim BuscaVersão = From ver In Lqoficina.VersaoModelos
                                      Where ver.Idversao = BuscaAssociação.First.IdModeloVeic
                                      Select ver.Versao, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Combustivel

                    Dim BUscaFabricante = From fab In Lqoficina.FabricantesVeiculo
                                          Where fab.Idfabricante = BuscaMOdelo.First.IdFabricante
                                          Select fab.Fabricante

                    FrmSolicitaçõesCadastro.DtProdutos.Rows.Add(row.IdSolicitacaoCadastro, row.PartNumber, row.Descricao, BUscaFabricante.First & " " & BuscaMOdelo.First.Modelo & " - " & BuscaVersão.First.Versao & " " & FormatNumber(BuscaVersão.First.Potencia, NumDigitsAfterDecimal:=1) & ", " & BuscaVersão.First.Combustivel & " (" & BuscaVersão.First.Cambio & ")", FormatDateTime(row.DataSol, DateFormat.ShortDate), FormatDateTime(row.HoraSol.ToString, DateFormat.ShortTime))

                End If

            Next

            If FrmSolicitaçõesCadastro.DtProdutos.Rows.Count > 0 Then

                FrmSolicitaçõesCadastro.LblCódigo.Text = FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(0).Value

                FrmSolicitaçõesCadastro.LblDescrição.Text = FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(2).Value

                FrmSolicitaçõesCadastro.LblVinculo.Text = FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(3).Value

                FrmSolicitaçõesCadastro.LblDataSol.Text = FormatDateTime(FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(4).Value, DateFormat.ShortDate)

                FrmSolicitaçõesCadastro.LblHoraSol.Text = FormatDateTime(FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(5).Value, DateFormat.ShortTime)

                FrmSolicitaçõesCadastro.LblPn.Text = FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(1).Value

                'busca imagem

                Dim _Codass As Integer = FrmSolicitaçõesCadastro.DtProdutos.Rows(0).Cells(0).Value

                'busca categoria e subcategoria

                Dim BuscaCatSubCat = From cat In Lqoficina.ItensSoluçãoN
                                     Where cat.IdSolicitacao = _Codass
                                     Select cat.IdSolucao

                'busca solucao

                Dim BuscaSolucao = From cat In Lqoficina.SoluçõesVistoria
                                   Where cat.IdSolucoes = BuscaCatSubCat.First
                                   Select cat.IdProcesso

                'busca vistoria

                Dim buscaVistoria = From vst In Lqoficina.Vistorias
                                    Where vst.IdVistoria = BuscaSolucao.First
                                    Select vst.IdVeiculo

                'busca trilha 0

                Dim buscaVistoria0 = From vst In Lqoficina.Vistorias
                                     Where vst.IdVeiculo = buscaVistoria.First And vst.NivelReq = 0
                                     Select vst.IdVeiculo, vst.IdVistoria
                                     Order By IdVistoria Descending

                'busca imagem

                Dim BuscaImagem = From img In Lqoficina.ImagemRespostaCklist
                                  Where img.IdProcesso = buscaVistoria0.First.IdVistoria
                                  Select img.Titulo, img.Imagem, img.IdImagemProcesso

                'busca marcas

                Dim BuscaMkImagem = From img In Lqoficina.MarcasImagens
                                    Where img.IdImagem = BuscaImagem.First.IdImagemProcesso
                                    Select img.IdMarcaImagem, img.X, img.Y, img.Cor, img.Descricao

                Dim PintarBitmap = New Bitmap(FrmSolicitaçõesCadastro.PIcImagem.Width, FrmSolicitaçõesCadastro.PIcImagem.Height)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                'varre imagens

                Dim arrImage() As Byte
                Dim myMS As New IO.MemoryStream
                arrImage = BuscaImagem.First.Imagem.ToArray

                For Each ar As Byte In arrImage
                    myMS.WriteByte(ar)
                Next

                'define o tamanho da imagem 

                'publica login sugerido

                Dim Contexto As String = BuscaImagem.First.Titulo

                Dim str As String = Contexto
                Dim separador As String = ","
                Dim palavras As String() = str.Split(separador)
                Dim LstPalavras As New ListBox
                Dim palavra As String

                For Each palavra In palavras
                    LstPalavras.Items.Add(palavra)
                Next

                FrmSolicitaçõesCadastro.LblCategoria.Text = LstPalavras.Items(0).ToString
                FrmSolicitaçõesCadastro.LblSubcategoria.Text = LstPalavras.Items(1).ToString

                Pintura.DrawImage(System.Drawing.Image.FromStream(myMS), 0, 0, PintarBitmap.Width, PintarBitmap.Height)

                Dim _X As Integer = (BuscaMkImagem.First.X * 60 / 100) - 5
                Dim _Y As Integer = (BuscaMkImagem.First.Y * 60 / 100) - 5

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(155, Color.WhiteSmoke)), _X + 15, _Y, 100, 20)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(155, Color.Lime)), 1), _X + 15, _Y, 100, 20)
                Pintura.DrawString(BuscaMkImagem.First.Descricao, New Font("Calibri", 8), New SolidBrush(Color.DarkSlateGray), _X + 17, _Y + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(155, Color.Lime)), 1), _X + 5, _Y + 5, _X + 15, _Y + 5)
                Pintura.FillEllipse(New SolidBrush(Color.FromArgb(155, Color.Lime)), _X, _Y, 10, 10)

                myMS.Dispose()

                FrmSolicitaçõesCadastro.PIcImagem.BackgroundImage = PintarBitmap

                FrmSolicitaçõesCadastro.Show(Me)

            Else

                If Receb = True Then
                    FrmProdutosNfRecebimento.DtEsperados.FirstDisplayedCell = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(0)
                End If

                Me.Close()

            End If

            FrmTodosProdutos.Verifica_Inicio()
            FrmTodosProdutos.Focus()

        Else

            'altera no grid

            FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(1).Value = _idProdutoSalvo
            FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(3).Value = TxtDescrição.Text
            FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(4).Value = TxtNCM.Text
            FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(5).Value = TxtCodBarras.Text

        End If

        'limpa campos

        TxtDescrição.Text = Nothing
        GpDadosPessoais.Enabled = False

        'habilita campos

        CkDisponibilzarIARA.Enabled = False

        NmAltura.Enabled = False
        NmLargura.Enabled = False
        NmProfundidade.Enabled = False
        NmPeso.Enabled = False

        NmDpIara.Enabled = False

        NmQtMaxima.Enabled = False
        NmQtMinima.Enabled = False

        BttSalvarColaborador.Enabled = False
        BttCancelar.Enabled = False
        BttAddProduto.Enabled = True

        CkDisponibilzarIARA.Checked = False

        NmAltura.Value = 0
        NmLargura.Value = 0
        NmProfundidade.Value = 0
        NmPeso.Value = 0

        NmDpIara.Value = 0

        NmQtMaxima.Value = 0
        NmQtMinima.Value = 1

        If Receb = True Then

            FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Selected = True
            FrmProdutosNfRecebimento.DtEsperados.FirstDisplayedCell = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(0)

            Me.Cursor = Cursors.WaitCursor

            'verifica itens não vinculads

            FrmReceberMercadoria.LblTitulo.Text = "Lista de items"

            FrmReceberMercadoria.CmbItensSolicitados.Visible = True
            FrmReceberMercadoria.LblItemSel.Visible = False

            FrmReceberMercadoria.LblCodFornec.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(2).Value
            FrmReceberMercadoria.LblDescriçãoItem.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(3).Value
            FrmReceberMercadoria.LblNCM.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(4).Value
            FrmReceberMercadoria.LblEan.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(5).Value
            FrmReceberMercadoria.LblValorUnitário.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(8).Value

            FrmReceberMercadoria.NumericUpDown1.Maximum = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(7).Value

            'valida controle de validade

            Dim BuscaControle = From controle In LqBase.Produtos
                                Where controle.IdProduto = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(1).Value.ToString
                                Select controle.ControleValidade

            'liga solicitaçãoes

            FrmReceberMercadoria.Show(FrmProdutosNfRecebimento)

            FrmReceberMercadoria._IdProduto = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(1).Value.ToString

            FrmReceberMercadoria.RdbNovo.Enabled = True
            FrmReceberMercadoria.RdbRecon.Enabled = True
            FrmReceberMercadoria.RdbUsado.Enabled = True

            If FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(1).Value.ToString <> "" Then

                'seleciona o item no combobox

                For i As Integer = 0 To FrmReceberMercadoria.LstIdItens.Items.Count - 1 Step 1

                    If FrmReceberMercadoria.LstIdItens.Items(i).ToString = FrmProdutosNfRecebimento.DtEsperados.Rows(Index).Cells(1).Value Then

                        FrmReceberMercadoria.CmbItensSolicitados.SelectedIndex = i

                        FrmReceberMercadoria.LblTitulo.Text = "Item vinculado"
                        FrmReceberMercadoria.CmbItensSolicitados.Visible = False
                        FrmReceberMercadoria.LblItemSel.Visible = True
                        FrmReceberMercadoria.LblItemSel.Text = FrmReceberMercadoria.CmbItensSolicitados.Items(i).ToString
                        FrmProdutosNfRecebimento.LstIgnorar.Items.Add(FrmReceberMercadoria.LstIdItens.Items(i).ToString)

                    End If

                Next

            Else

                If FrmReceberMercadoria.CmbItensSolicitados.Items.Count = 0 Then

                    FrmReceberMercadoria.LblTitulo.Text = "descricao"

                    FrmReceberMercadoria.CmbItensSolicitados.Visible = False
                    FrmReceberMercadoria.LblItemSel.Visible = True

                End If

            End If

            Me.Cursor = Cursors.Arrow

        End If

        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub

    Dim conn As New MySqlConnection
    Dim myCommand As New MySqlCommand
    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim SQL As String

    Private Sub NmDpIara_ValueChanged(sender As Object, e As EventArgs) Handles NmDpIara.ValueChanged

        If NmDpIara.Value > 0 Then

            BttSalvarProduto.Enabled = True

        Else

            BttSalvarProduto.Enabled = False

        End If

    End Sub

    Private Sub CkInsumo_CheckedChanged(sender As Object, e As EventArgs) Handles CkInsumo.CheckedChanged

        If CkVendaDireta.Checked = True Or CkUsoInterno.Checked = True Or CkReaproveitamento.Checked = True Or CkInsumo.Checked = True Then

            NmQtMaxima.Enabled = True
            NmQtMinima.Enabled = True
            CkDisponibilzarIARA.Enabled = True

            NmProfundidade.Enabled = True
            NmLargura.Enabled = True
            NmAltura.Enabled = True
            NmPesoT.Enabled = True

            CkValidade.Enabled = True

            BttSalvarProduto.Enabled = True

            BtnAddFornecedor.Enabled = True
            BtnProdutosVinculados.Enabled = True
            BtnServicosVindulados.Enabled = True
            BtnVinculoModelo.Enabled = True

        ElseIf CkVendaDireta.Checked = False And CkUsoInterno.Checked = False And CkReaproveitamento.Checked = False And CkInsumo.Checked = False Then

            NmQtMaxima.Enabled = False
            NmQtMinima.Enabled = False
            CkDisponibilzarIARA.Enabled = False

            NmQtMaxima.Value = 0
            NmQtMinima.Value = 1
            CkDisponibilzarIARA.Checked = False

            CkValidade.Enabled = False

            NmProfundidade.Value = 0
            NmLargura.Value = 0
            NmAltura.Value = 0
            NmPesoT.Value = 0
            CkValidade.Checked = False

            BttSalvarProduto.Enabled = False

            BtnAddFornecedor.Enabled = False
            BtnProdutosVinculados.Enabled = False
            BtnServicosVindulados.Enabled = False
            BtnVinculoModelo.Enabled = False

        End If

    End Sub

    Private Sub CkUsoInterno_CheckedChanged(sender As Object, e As EventArgs) Handles CkUsoInterno.CheckedChanged
        If CkVendaDireta.Checked = True Or CkUsoInterno.Checked = True Or CkReaproveitamento.Checked = True Or CkInsumo.Checked = True Then

            NmQtMaxima.Enabled = True
            NmQtMinima.Enabled = True
            CkDisponibilzarIARA.Enabled = True

            NmProfundidade.Enabled = True
            NmLargura.Enabled = True
            NmAltura.Enabled = True
            NmPesoT.Enabled = True

            CkValidade.Enabled = True

            BttSalvarProduto.Enabled = True

            BtnAddFornecedor.Enabled = True
            BtnProdutosVinculados.Enabled = True
            BtnServicosVindulados.Enabled = True
            BtnVinculoModelo.Enabled = True

        ElseIf CkVendaDireta.Checked = False And CkUsoInterno.Checked = False And CkReaproveitamento.Checked = False And CkInsumo.Checked = False Then

            NmQtMaxima.Enabled = False
            NmQtMinima.Enabled = False
            CkDisponibilzarIARA.Enabled = False

            NmQtMaxima.Value = 0
            NmQtMinima.Value = 1
            CkDisponibilzarIARA.Checked = False

            CkValidade.Enabled = False

            NmProfundidade.Value = 0
            NmLargura.Value = 0
            NmAltura.Value = 0
            NmPesoT.Value = 0
            CkValidade.Checked = False

            BttSalvarProduto.Enabled = False

            BtnAddFornecedor.Enabled = False
            BtnProdutosVinculados.Enabled = False
            BtnServicosVindulados.Enabled = False
            BtnVinculoModelo.Enabled = False

        End If

    End Sub

    Private Sub CkReaproveitamento_CheckedChanged(sender As Object, e As EventArgs) Handles CkReaproveitamento.CheckedChanged
        If CkVendaDireta.Checked = True Or CkUsoInterno.Checked = True Or CkReaproveitamento.Checked = True Or CkInsumo.Checked = True Then

            NmQtMaxima.Enabled = True
            NmQtMinima.Enabled = True
            CkDisponibilzarIARA.Enabled = True

            NmProfundidade.Enabled = True
            NmLargura.Enabled = True
            NmAltura.Enabled = True
            NmPesoT.Enabled = True

            CkValidade.Enabled = True

            BttSalvarProduto.Enabled = True

            BtnAddFornecedor.Enabled = True
            BtnProdutosVinculados.Enabled = True
            BtnServicosVindulados.Enabled = True
            BtnVinculoModelo.Enabled = True

        ElseIf CkVendaDireta.Checked = False And CkUsoInterno.Checked = False And CkReaproveitamento.Checked = False And CkInsumo.Checked = False Then

            NmQtMaxima.Enabled = False
            NmQtMinima.Enabled = False
            CkDisponibilzarIARA.Enabled = False

            NmQtMaxima.Value = 0
            NmQtMinima.Value = 1
            CkDisponibilzarIARA.Checked = False

            CkValidade.Enabled = False

            NmProfundidade.Value = 0
            NmLargura.Value = 0
            NmAltura.Value = 0
            NmPesoT.Value = 0
            CkValidade.Checked = False

            BttSalvarProduto.Enabled = False

            BtnAddFornecedor.Enabled = False
            BtnProdutosVinculados.Enabled = False
            BtnServicosVindulados.Enabled = False
            BtnVinculoModelo.Enabled = False

        End If

    End Sub

    Private Sub CmbSubcategoria_TextChanged(sender As Object, e As EventArgs) Handles CmbSubcategoria.TextChanged

        If CmbSubcategoria.Enabled = True Then

            If CmbFabricante.Items.Contains(CmbFabricante.Text) And CmbFabricante.Text <> "" Then

                If CmbSubcategoria.Items.Contains(CmbSubcategoria.Text) And CmbSubcategoria.Text <> "" Then
                    TxtNCM.Enabled = True
                    GpFotos.Enabled = True
                    CmbUnidadeCompra.Enabled = True
                    BttAddUnidade.Enabled = True
                Else
                    TxtNCM.Enabled = False
                    GpFotos.Enabled = False
                    CmbUnidadeCompra.Enabled = False
                    BttAddUnidade.Enabled = False

                    CmbUnidadeCompra.Text = ""
                    TxtNCM.Text = ""
                End If

            End If

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles BtnServicosVindulados.Click

        'abre o form de vinculo a servicos

        Me.Cursor = Cursors.WaitCursor

        FrmVincularServicos.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub NmProfundidade_ValueChanged(sender As Object, e As EventArgs) Handles NmProfundidade.ValueChanged

    End Sub

    Private Sub NmLargura_ValueChanged(sender As Object, e As EventArgs) Handles NmLargura.ValueChanged

    End Sub

    Public ListaImagens As New ListBox
    Public PosLstImg As New ListBox

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click

        'TrRespostashecklist.Visible = False
        'OpenFileDialog
        Me.ofd1.Multiselect = True
        Me.ofd1.Title = "Selecionar Arquivos"
        ofd1.InitialDirectory = "C:\"
        'filtra para exibir somente arquivos de imagens
        'ofd1.Filter = "Imagens (*.png | *.jpg)|*.png, *.jpg"
        ofd1.CheckFileExists = True
        ofd1.CheckPathExists = True
        ofd1.FilterIndex = 1
        ofd1.RestoreDirectory = True
        ofd1.ReadOnlyChecked = True
        ofd1.ShowReadOnly = True

        Dim dr As DialogResult = Me.ofd1.ShowDialog()

        If dr = System.Windows.Forms.DialogResult.OK Then

            ImageList3.Images.Add(Image.FromFile(ofd1.FileName))
            ListaImagens.Items.Add(ofd1.FileName)

            Dim H As Integer = 85 * ImageList3.Images.Count
            Dim V As Integer = PictureBox1.Height

            Dim PintarBitmap = New Bitmap(H, V)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim Add As Integer = 0

            PosLstImg.Items.Clear()

            For Each row As Image In ImageList3.Images
                Pintura.DrawImage(row, Add, 0, 80, V)
                PosLstImg.Items.Add(Add)
                Add += 85
            Next

            Dim H_i As Integer = 85 * ImageList3.Images.Count
            Dim V_i As Integer = PictureBox1.Height

            Dim PintarBitmap_i = New Bitmap(H_i, V_i)

            Dim Pintura_i = Graphics.FromImage(PintarBitmap_i)

            Pintura_i.FillRectangle(New SolidBrush(Color.FromArgb(60, Color.SlateGray)), Add - 85, 0, 80, V - 2)

            PictureBox1.Image = PintarBitmap_i

            PictureBox1.Size = New Size(H, V)

            PictureBox1.BackgroundImage = PintarBitmap
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch

            BttRemoverImagem.Enabled = True

            IndexImagemRemove = ImageList3.Images.Count - 1

        End If

    End Sub

    Public Sub PintaInicio()

        Dim H As Integer = 85 * ImageList3.Images.Count
        Dim V As Integer = PictureBox1.Height

        Dim PintarBitmap = New Bitmap(H, V)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Add As Integer = 0

        PosLstImg.Items.Clear()

        For Each row As Image In ImageList3.Images
            Pintura.DrawImage(row, Add, 0, 80, V)
            PosLstImg.Items.Add(Add)
            Add += 85
        Next

        Dim H_i As Integer = 85 * ImageList3.Images.Count
        Dim V_i As Integer = PictureBox1.Height

        Dim PintarBitmap_i = New Bitmap(H_i, V_i)

        Dim Pintura_i = Graphics.FromImage(PintarBitmap_i)

        Pintura_i.FillRectangle(New SolidBrush(Color.FromArgb(60, Color.SlateGray)), Add - 85, 0, 80, V - 2)

        PictureBox1.Image = PintarBitmap_i

        PictureBox1.Size = New Size(H, V)

        PictureBox1.BackgroundImage = PintarBitmap
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch

        BttRemoverImagem.Enabled = True

        IndexImagemRemove = ImageList3.Images.Count - 1

    End Sub
    Private Sub BtnVinculoModelo_Click(sender As Object, e As EventArgs) Handles BtnVinculoModelo.Click

        Me.Cursor = Cursors.WaitCursor

        FrmVinculoModeloProduto.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub NmAltura_ValueChanged(sender As Object, e As EventArgs) Handles NmAltura.ValueChanged

    End Sub

    Private Sub CmbTrib_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTrib.SelectedIndexChanged
        If CmbTrib.Items.Contains(CmbTrib.Text) Then
            CkInsumo.Enabled = True
            CkVendaDireta.Enabled = True
            CkUsoInterno.Enabled = True
            CkReaproveitamento.Enabled = True
            BtnProdutosVinculados.Enabled = True

        Else
            CkInsumo.Enabled = True
            CkVendaDireta.Enabled = True
            CkUsoInterno.Enabled = True
            CkReaproveitamento.Enabled = True

            CkInsumo.Checked = False
            CkVendaDireta.Checked = False
            CkUsoInterno.Checked = False
            CkReaproveitamento.Checked = False
            BtnProdutosVinculados.Enabled = False

        End If
    End Sub

    Private Sub DtVinculoExterno_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtVinculoExterno.CellContentClick

        'faz a funçao de remover de acordo com a posição do create

        If DtVinculoExterno.Columns(e.ColumnIndex).Name = "ClmExcluirVinculoExterno" Then

            If MsgBox("Tem certeza que deseja remover este item?", vbInformation + MsgBoxStyle.YesNo, "Remoção da lista de vinculos") = MsgBoxResult.Yes Then

                If DtVinculoExterno.Rows(e.RowIndex).Cells(3).Value = True Then

                    DtVinculoExterno.Rows.RemoveAt(e.RowIndex)

                Else

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim IdAssociacao As Integer = DtVinculoExterno.Rows(e.RowIndex).Cells(7).Value

                    LqOficina.DeletaAssociacaoPecaModelo(IdAssociacao)

                    'remove da base web

                    Dim baseUrl As String = "http://www.iarasoftware.com.br/deleta_vinculo_modelo_peca.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&FabricanteVeic=" & DtVinculoExterno.Rows(e.RowIndex).Cells(5).Value & "&ModeloVeic=" & DtVinculoExterno.Rows(e.RowIndex).Cells(6).Value &
                         "&Categoria=" & CmbCategoria.Text & "&SubCAtegoria=" & CmbSubcategoria.Text & "&IdProdutoINterno=" & IdProdutoCARR

                    ' Chamada sincrona
                    Dim syncClient = New WebClient()
                    Dim content = syncClient.DownloadString(baseUrl)

                    DtVinculoExterno.Rows.RemoveAt(e.RowIndex)

                End If

            End If

        End If


    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Dim IndexImagemRemove As Integer = -1

    Private Sub PictureBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick

        'verifica posição do mouse 

        For i As Integer = 0 To PosLstImg.Items.Count - 1

            'verifica se lista é compativel

            If PosLstImg.Items(i).ToString <= e.X And PosLstImg.Items(i).ToString + 80 >= e.X Then

                IndexImagemRemove = i

                Dim H As Integer = 85 * ImageList3.Images.Count
                Dim V As Integer = PictureBox1.Height

                Dim PintarBitmap = New Bitmap(H, V)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                Dim Add As Integer = PosLstImg.Items(i).ToString

                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(60, Color.SlateGray)), Add, 0, 80, V - 2)

                PictureBox1.Size = New Size(H, V)

                PictureBox1.Image = PintarBitmap

            End If

        Next

    End Sub

    Private Sub BttRemoverImagem_Click(sender As Object, e As EventArgs) Handles BttRemoverImagem.Click

        Me.Cursor = Cursors.WaitCursor

        'verifica se deve apagar do banco local

        If ListaImagens.Items(IndexImagemRemove).ToString.StartsWith("CdLc.") Then
            Dim CodApagar As Integer = ListaImagens.Items(IndexImagemRemove).ToString.Remove(0, 5)
            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
            LqBase.DeletaImagemProduto(CodApagar)
        End If

        ImageList3.Images.RemoveAt(IndexImagemRemove)
        PosLstImg.Items.RemoveAt(IndexImagemRemove)
        ListaImagens.Items.RemoveAt(IndexImagemRemove)

        If ImageList3.Images.Count > 0 Then

            'pinta imagem novamente

            Dim H As Integer = 85 * ImageList3.Images.Count
            Dim V As Integer = PictureBox1.Height

            Dim PintarBitmap = New Bitmap(H, V)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim Add As Integer = 0

            PosLstImg.Items.Clear()

            For Each row As Image In ImageList3.Images
                Pintura.DrawImage(row, Add, 0, 80, V)
                PosLstImg.Items.Add(Add)
                Add += 85
            Next

            Dim H_i As Integer = 85 * ImageList3.Images.Count
            Dim V_i As Integer = PictureBox1.Height

            Dim PintarBitmap_i = New Bitmap(H_i, V_i)

            Dim Pintura_i = Graphics.FromImage(PintarBitmap_i)

            Pintura_i.FillRectangle(New SolidBrush(Color.FromArgb(60, Color.SlateGray)), Add - 85, 0, 80, V - 2)

            PictureBox1.Image = PintarBitmap_i

            PictureBox1.Size = New Size(H, V)

            PictureBox1.BackgroundImage = PintarBitmap
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch

        Else

            BttRemoverImagem.Enabled = False
            PictureBox1.Image = Nothing
            PictureBox1.BackgroundImage = Nothing

        End If

        IndexImagemRemove = ImageList3.Images.Count - 1

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub DtServicos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServicos.CellContentClick

        'faz a funçao de remover de acordo com a posição do create

        If DtServicos.Columns(e.ColumnIndex).Name = "ClmExcluirVinculoServico" Then

            If MsgBox("Tem certeza que deseja remover este item?", vbInformation + MsgBoxStyle.YesNo, "Remoção da lista de vinculos") = MsgBoxResult.Yes Then

                If DtServicos.Rows(e.RowIndex).Cells(0).Value = 0 Then

                    DtServicos.Rows.RemoveAt(e.RowIndex)

                Else

                    Dim LqBase As New DtCadastroDataContext
                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim IdAssociacao As Integer = DtServicos.Rows(e.RowIndex).Cells(0).Value

                    LqBase.DeletaVinculoServico(IdAssociacao)

                    DtServicos.Rows.RemoveAt(e.RowIndex)

                End If

            End If

        End If
    End Sub

    Private Sub BtnProdutosVinculados_Click(sender As Object, e As EventArgs) Handles BtnProdutosVinculados.Click

        Me.Cursor = Cursors.WaitCursor

        FrmVinculaProdutos.IdProduto = IdProdutoCARR
        FrmVinculaProdutos.show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub DtProdutosVinculados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutosVinculados.CellContentClick

        'faz a funçao de remover de acordo com a posição do create

        If DtProdutosVinculados.Columns(e.ColumnIndex).Name = "ClmExcluirVinculoProduto" Then

            If MsgBox("Tem certeza que deseja remover este item?", vbInformation + MsgBoxStyle.YesNo, "Remoção da lista de vinculos") = MsgBoxResult.Yes Then

                If DtProdutosVinculados.Rows(e.RowIndex).Cells(0).Value = 0 Then

                    DtProdutosVinculados.Rows.RemoveAt(e.RowIndex)

                Else

                    Dim LqBase As New DtCadastroDataContext
                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim IdAssociacao As Integer = DtProdutosVinculados.Rows(e.RowIndex).Cells(0).Value

                    LqBase.DeletaVinculoProduto(IdAssociacao)

                    DtProdutosVinculados.Rows.RemoveAt(e.RowIndex)

                End If

            End If

        End If
    End Sub

    Private Sub BtnAddFornecedor_Click(sender As Object, e As EventArgs) Handles BtnAddFornecedor.Click

        Me.Cursor = Cursors.WaitCursor

        FrmVinculoFornecedor.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub PictureBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDoubleClick

        Me.Cursor = Cursors.WaitCursor

        For i As Integer = 0 To PosLstImg.Items.Count - 1

            'verifica se lista é compativel

            If PosLstImg.Items(i).ToString <= e.X And PosLstImg.Items(i).ToString + 80 >= e.X Then

                If Not ListaImagens.Items(i).ToString.StartsWith("CdLc.") Then

                    IndexImagemRemove = i

                    FrmMiniatura.PictureBox1.BackgroundImage = Image.FromFile(ListaImagens.Items(i).ToString)

                Else

                    Dim CodApagar As Integer = ListaImagens.Items(IndexImagemRemove).ToString.Remove(0, 5)

                    IndexImagemRemove = i

                    'busca imagens do produto

                    Dim BuscaImagens = From img In LqBase.ImagemProduto
                                       Where img.IdProduto = CodApagar
                                       Select img.Imagem, img.IdImagem

                    For Each it In BuscaImagens.ToList

                        Dim arrImage() As Byte
                        Dim myMS As New IO.MemoryStream
                        arrImage = it.Imagem.ToArray

                        For Each ar As Byte In arrImage
                            myMS.WriteByte(ar)
                        Next

                        FrmMiniatura.PictureBox1.BackgroundImage = (Image.FromStream(myMS))

                    Next

                End If

                FrmMiniatura.Show(Me)

            End If

        Next

        Me.Cursor = Cursors.Arrow

    End Sub
End Class