Imports System.IO
Imports System.Net
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class FrmNovoORçamento

    Dim LqComercial As New LqComercialDataContext

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        If Edita = False Then
            LqComercial.DeletaOrcamento(LblNumOrcamento.Text)
        End If

        Me.Close()

    End Sub

    Private Sub DtBddIARA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmProdutoSelecionado" Then

            If DtProdutos.Rows(e.RowIndex).Cells(0).Value = True Then

                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False
                DtProdutos.Rows(e.RowIndex).Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                DtProdutos.Rows(e.RowIndex).Cells(9).Value = FormatNumber(0, NumDigitsAfterDecimal:=0)
                DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

            Else
                DtProdutos.SelectedCells(0).Value = True

                'calcula final

                Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
                Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
                Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
                Desconto = Desconto.Replace("%", "")

                Dim Vl_Desconto As Decimal = Desconto

                Qt += 1

                DtProdutos.Rows(e.RowIndex).Cells(9).Value = Qt

                DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            End If

            If TrResumo.Nodes.Count > 0 Then

                TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()

                For Each row As DataGridViewRow In DtProdutos.Rows

                    If row.Cells(0).Value = True Then

                        'insere no banco de dados

                        Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                        TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))


                    End If

                Next

                For Each row As DataGridViewRow In DtServiços.Rows

                    If row.Cells(0).Value = True Then

                        'insere no banco de dados

                        Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                        TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(3).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(5).Value & " = " & FormatCurrency(row.Cells(8).Value, NumDigitsAfterDecimal:=2))


                    End If

                Next

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmMinusProd" Then

            'calcula final

            Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
            Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
            Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
            Desconto = Desconto.Replace("%", "")

            Dim Vl_Desconto As Decimal = Desconto

            If Qt > 0 Then
                Qt -= 1

            End If

            If Qt = 0 Then

                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False

            End If

            DtProdutos.Rows(e.RowIndex).Cells(9).Value = Qt

            DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

            TrResumo.CollapseAll()

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmMoreProd" Then

            DtProdutos.Rows(e.RowIndex).Cells(0).Value = True

            'calcula final

            Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
            Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
            Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
            Desconto = Desconto.Replace("%", "")

            Dim Vl_Desconto As Decimal = Desconto

            Qt += 1

            DtProdutos.Rows(e.RowIndex).Cells(9).Value = Qt

            DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

        End If

        If TrResumo.Nodes.Count > 0 Then

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()

        End If

        'verifica se é possivel declinar ou aprovar o orçamento

        Dim C As Integer = 0

        Dim _DescontosTotais As Decimal
        Dim _ValorFinal As Decimal
        Dim _ValorSemDesconto As Decimal

        For Each row As DataGridViewRow In DtProdutos.Rows

            Dim ValorUnit As Decimal = row.Cells(7).Value
            Dim Qt As Integer = row.Cells(9).Value
            Dim Subtotal As Decimal = row.Cells(12).Value

            If row.Cells(0).Value = True And row.Cells(7).Value = 0 Then
                C += 1
            End If

            _ValorSemDesconto += (ValorUnit * Qt)

            _DescontosTotais += (ValorUnit * Qt) - Subtotal

            _ValorFinal += Subtotal

        Next

        'verifica formas de pagamento salva

        Dim _TotalFormas As Decimal

        For Each row As DataGridViewRow In DtFormas.Rows

            _TotalFormas += row.Cells(3).Value

        Next

        If C = 0 Then

            BttDeclinarOrc.Enabled = True

        Else

            BttDeclinarOrc.Enabled = False

        End If

        If C = 0 And _TotalFormas >= LblValorTotal.Text And LblValorTotal.Text > 0 Then

            BttAprovarOrc.Enabled = True

        Else

            BttAprovarOrc.Enabled = False

        End If

        LblSubtotal.Text = FormatCurrency(_ValorSemDesconto, NumDigitsAfterDecimal:=2)

        LblValorTotal.Text = FormatCurrency(_ValorFinal, NumDigitsAfterDecimal:=2)

        LblDescontos.Text = FormatCurrency(_DescontosTotais, NumDigitsAfterDecimal:=2)

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Public Edita As Boolean = False

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Dim LstIdFormasPg As New ListBox
    Dim LstA_vista As New ListBox
    Dim LstIntervalo As New ListBox
    Dim LstParcelas As New ListBox
    Dim LstTipoIntervalo As New ListBox

    Public LstIdCategoria As New ListBox
    Public LstIdSubCategoria As New ListBox
    Public lstIdFabricante As New ListBox

    Private Sub FrmNovoORçamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        'carrega todos os produtoss

        Dim BuscaProdutos = From prod In LqBase.Produtos
                            Where prod.IdProduto Like "*" And prod.VendaDireta = True
                            Select prod.IdProduto, prod.Descricao, prod.CodFabricante, prod.Fabricante, prod.Categoria, prod.SubCategoria

        For Each row In BuscaProdutos.ToList

            DtProdutos.Rows.Add(False, row.IdProduto, row.Descricao, row.Fabricante, row.Categoria, row.SubCategoria, row.CodFabricante, "R$0,00", My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00")

            'busca armazenagem

            Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                   Where arm.IdProduto = row.IdProduto And arm.Qt > 0
                                   Select arm.ValorUnit, arm.DataEntrada, arm.TipoProduto, arm.ValorRevenda
                                   Order By DataEntrada Descending

            If BuscaArmazenagem.Count > 0 Then

                Dim TipoProdutoString As String

                If BuscaArmazenagem.First.TipoProduto = 1 Then

                    TipoProdutoString = "Produto novo"
                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(7).Value = FormatCurrency(BuscaArmazenagem.First.ValorRevenda, NumDigitsAfterDecimal:=2)
                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(13).Value = TipoProdutoString

                ElseIf BuscaArmazenagem.First.TipoProduto = 2 Then

                    TipoProdutoString = "Produto usado"
                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(7).Value = FormatCurrency(BuscaArmazenagem.First.ValorRevenda, NumDigitsAfterDecimal:=2)
                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(13).Value = TipoProdutoString

                ElseIf BuscaArmazenagem.First.TipoProduto = 3 Then

                    TipoProdutoString = "Produto recondicionado"
                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(7).Value = FormatCurrency(BuscaArmazenagem.First.ValorRevenda, NumDigitsAfterDecimal:=2)
                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(13).Value = TipoProdutoString

                End If

            Else

                Dim Hoje As Date = Today.Date

                'busca cotações

                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                    Where cot.IdProduto = row.IdProduto
                                    Select cot.ValorCotado, cot.DataCotacao, cot.Markup

                If BuscaCotações.Count > 0 Then

                    If BuscaCotações.First.DataCotacao.Value.Date.AddDays(20) >= Hoje Then

                        Dim VlrNew As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                        DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(7).Value = FormatCurrency(VlrNew, NumDigitsAfterDecimal:=2)
                        DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(13).Value = "Sem estoque"

                    End If

                Else

                    DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(13).Value = "Sem estoque"

                End If

            End If

        Next

        Dim LqOficina As New LqOficinaDataContext

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim _IdCategoria As String = "*"
        Dim _IdSubCategoria As String = "*"

        If CmbCategoria.Text <> "" Then

            _IdCategoria = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString

            If CmbSubCategoria.Text <> "" Then

                _IdSubCategoria = LstIdSubCategoria.Items(CmbSubCategoria.SelectedIndex).ToString

            End If

        End If

        Dim BuscsaSolicitações = From rw In LqOficina.SolicitacaoCadastroPeca
                                 Where rw.IdCodCad = 0 And rw.IdCategoria Like _IdCategoria And rw.IdSubCategoria Like _IdSubCategoria
                                 Select rw.IdSolicitacaoCadastro, rw.Descricao, rw.PartNumber, rw.IdCategoria, rw.IdSubCategoria

        Dim LstItensINseridos As New ListBox

        For Each row In BuscsaSolicitações.ToList

            Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                                 Where cat.IdCategoriaProduto = row.IdCategoria
                                 Select cat.Descricao

            Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                    Where cat.IdSubCategoria = row.IdSubCategoria And cat.IdCategoria = row.IdCategoria
                                    Select cat.Descricao

            DtProdutos.Rows.Add(False, "S" & row.IdSolicitacaoCadastro, row.Descricao, "", BuscaCategoria.First, BuscaSubCategoria.First, row.PartNumber, "R$ 0,00", My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00", "Sol. de cadastro")

        Next

        'carrega formas de pg entrada

        Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                            Where cart.IdFormasPgEntrada Like "*" And cart.UsoInterno = False
                            Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

        For Each row In BuscaCarteira.ToList

            LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
            LstA_vista.Items.Add(row.A_Vista)
            LstIntervalo.Items.Add(row.Intervalo)
            LstParcelas.Items.Add(row.Parcelas)
            LstTipoIntervalo.Items.Add(row.TipoIntervalo)
            CmbFormasPgEntrada.Items.Add(row.Descricao)

        Next

        'busca fabricantes

        For Each rw As DataGridViewRow In DtProdutos.Rows

            If Not CmbFabricantes.Items.Contains(rw.Cells(3).Value) Then

                CmbFabricantes.Items.Add(rw.Cells(3).Value)

                Dim BuscaIDCat = From cat In LqBase.Fabricantes
                                 Where cat.Fabricante Like rw.Cells(3).Value.ToString
                                 Select cat.IdFabricante

                If BuscaIDCat.Count > 0 Then

                    lstIdFabricante.Items.Add(BuscaIDCat.First)

                End If

            End If

            If Not CmbCategoria.Items.Contains(rw.Cells(4).Value) Then

                CmbCategoria.Items.Add(rw.Cells(4).Value)

                Dim BuscaIDCat = From cat In LqBase.CategoriasProdutos
                                 Where cat.Descricao Like rw.Cells(4).Value.ToString
                                 Select cat.IdCategoriaProduto

                If BuscaIDCat.Count > 0 Then

                    LstIdCategoria.Items.Add(BuscaIDCat.First)

                End If

            End If

        Next

        If CmbFabricantes.Items.Count = 0 Then
            CmbFabricantes.Enabled = False
        Else
            CmbFabricantes.Enabled = True
        End If
        'carrega todos os produtoss

        Dim BuscaServiços = From prod In LqBase.Servicos
                            Where prod.IdServico Like "*"
                            Select prod.IdServico, prod.Descricao, prod.VlrVeda

        For Each row In BuscaServiços.ToList

            DtServiços.Rows.Add(False, row.IdServico, row.Descricao, FormatCurrency(row.VlrVeda, NumDigitsAfterDecimal:=2), My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00")

        Next

    End Sub

    Public UltimoIndex As Integer = -1
    Public Sub Atualiza_produtos()

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        TrResumo.Nodes.Clear()

        'carrega todos os produtoss

        Dim BuscaProdutos = From prod In LqBase.Produtos
                            Where prod.IdProduto Like "*" And prod.VendaDireta = True
                            Select prod.IdProduto, prod.Descricao, prod.CodFabricante, prod.Fabricante, prod.Categoria, prod.SubCategoria

        DtProdutos.Rows.Clear()

        For Each row In BuscaProdutos.ToList

            DtProdutos.Rows.Add(False, row.IdProduto, row.Descricao, row.Fabricante, row.Categoria, row.SubCategoria, row.CodFabricante, "R$0,00", My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00")

            'busca armazenagem

            Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                   Where arm.IdProduto = row.IdProduto
                                   Select arm.ValorUnit, arm.DataEntrada
                                   Order By DataEntrada Descending

            If BuscaArmazenagem.Count > 0 Then


            Else

                Dim Hoje As Date = Today.Date

                'busca cotações

                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                    Where cot.IdProduto = row.IdProduto
                                    Select cot.ValorCotado, cot.DataCotacao

                If BuscaCotações.Count > 0 Then

                    If BuscaCotações.First.DataCotacao.Value.Date.AddDays(20) >= Hoje Then
                        DtProdutos.Rows(DtProdutos.Rows.Count - 1).Cells(7).Value = FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2)
                    End If

                End If

            End If

        Next

        Dim LqOficina As New LqOficinaDataContext

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscsaSolicitações = From rw In LqOficina.SolicitacaoCadastroPeca
                                 Where rw.IdCodCad = 0 And rw.IdCategoria = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString And rw.IdSubCategoria = LstIdSubCategoria.Items(CmbSubCategoria.SelectedIndex).ToString
                                 Select rw.IdSolicitacaoCadastro, rw.Descricao, rw.PartNumber, rw.IdCategoria, rw.IdSubCategoria

        Dim LstItensINseridos As New ListBox

        For Each row In BuscsaSolicitações.ToList

            DtProdutos.Rows.Add(False, "S" & row.IdSolicitacaoCadastro, row.Descricao, "", CmbCategoria.Text, CmbSubCategoria.Text, row.PartNumber, "R$ 0,00", My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00", "Sol. de cadastro")

        Next

        'carrega formas de pg entrada

        Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                            Where cart.IdFormasPgEntrada Like "*"
                            Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

        LstIdFormasPg.Items.Clear()
        LstA_vista.Items.Clear()
        LstIntervalo.Items.Clear()
        LstParcelas.Items.Clear()
        LstTipoIntervalo.Items.Clear()
        CmbFormasPgEntrada.Items.Clear()

        For Each row In BuscaCarteira.ToList

            LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
            LstA_vista.Items.Add(row.A_Vista)
            LstIntervalo.Items.Add(row.Intervalo)
            LstParcelas.Items.Add(row.Parcelas)
            LstTipoIntervalo.Items.Add(row.TipoIntervalo)
            CmbFormasPgEntrada.Items.Add(row.Descricao)

        Next

        'busca fabricantes

        CmbFabricantes.Items.Clear()
        CmbCategoria.Items.Clear()

        For Each rw As DataGridViewRow In DtProdutos.Rows

            If Not CmbFabricantes.Items.Contains(rw.Cells(3).Value) Then

                CmbFabricantes.Items.Add(rw.Cells(3).Value)

            End If

            If Not CmbCategoria.Items.Contains(rw.Cells(4).Value) Then

                CmbCategoria.Items.Add(rw.Cells(4).Value)

            End If

        Next


        'carrega todos os produtoss

        Dim BuscaServiços = From prod In LqBase.Servicos
                            Where prod.IdServico Like "*"
                            Select prod.IdServico, prod.Descricao, prod.VlrVeda

        DtServiços.Rows.Clear()

        For Each row In BuscaServiços.ToList

            DtServiços.Rows.Add(False, row.IdServico, row.Descricao, FormatCurrency(row.VlrVeda, NumDigitsAfterDecimal:=2), My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00")

        Next

    End Sub

    Private Sub CmbFormasPgEntrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFormasPgEntrada.SelectedIndexChanged

        If CmbFormasPgEntrada.Items.Contains(CmbFormasPgEntrada.Text) Then

            If LstA_vista.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                NmParcelas.Value = LstParcelas.Items(CmbFormasPgEntrada.SelectedIndex).ToString

                NmParcelas.Enabled = False

                TxtValor.Enabled = True

            Else

                NmParcelas.Value = LstParcelas.Items(CmbFormasPgEntrada.SelectedIndex).ToString

                NmParcelas.Enabled = True

                TxtValor.Enabled = True

            End If

        Else

            NmParcelas.Enabled = False
            TxtValor.Enabled = False

            NmParcelas.Value = 1
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End If

        If CmbFormasPgEntrada.Text = "" Then

            NmParcelas.Enabled = False
            TxtValor.Enabled = False

            NmParcelas.Value = 1
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End If

    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

        If TxtValor.Text = "" Then
            TxtValor.Text = 0
            TxtValor.SelectAll()
        End If

        If TxtValor.Text <> "" Then

            BttInsere.Enabled = True

        End If

    End Sub

    Private Sub BttInsere_Click(sender As Object, e As EventArgs) Handles BttInsere.Click

        Dim Intervalo As Integer = LstIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString

        Dim NumParcela As Integer = NmParcelas.Value
        Dim Valor As Decimal = TxtValor.Text

        Dim C As Integer = 1

        While NumParcela >= C

            If LstTipoIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                If LstA_vista.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then
                    DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * 0), DateFormat.ShortDate), My.Resources.Delete_80_icon_icons_com_57340)
                Else
                    DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * Intervalo), DateFormat.ShortDate), My.Resources.Delete_80_icon_icons_com_57340)
                End If

            End If

            C += 1

        End While

        CmbFormasPgEntrada.Text = ""

        NmParcelas.Enabled = False
        TxtValor.Enabled = False

        NmParcelas.Value = 1
        TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        Dim _ValorPg As Decimal

        For Each row As DataGridViewRow In DtFormas.Rows
            _ValorPg += row.Cells(3).Value
        Next

        If _ValorPg >= LblValorTotal.Text And LblValorTotal.Text > 0 Then
            BttAprovarOrc.Enabled = True
        Else
            BttAprovarOrc.Enabled = False
        End If

    End Sub

    Private Sub TxtValor_GotFocus(sender As Object, e As EventArgs) Handles TxtValor.GotFocus

        TxtValor.Text = FormatNumber(TxtValor.Text, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtValor.LostFocus

        Try

            Dim _total As Decimal

            For Each row As DataGridViewRow In DtFormas.Rows
                _total += row.Cells(3).Value
            Next

            Dim _ValorINserido As Decimal = TxtValor.Text

            If _ValorINserido + _total <= LblValorTotal.Text Then
                TxtValor.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)
            Else
                Dim ValorTotal As Decimal = LblValorTotal.Text
                TxtValor.Text = FormatCurrency(ValorTotal - _total, NumDigitsAfterDecimal:=2)
            End If

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub DtFormas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellContentClick

        Dim LstIndexApagar As New ListBox

        If DtFormas.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            Dim IdSel As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value

            'varre pra ver se tem mais

            For Each row As DataGridViewRow In DtFormas.Rows

                If row.Cells(0).Value = IdSel Then

                    LstIndexApagar.Items.Add(row.Index)

                End If

            Next

            If MsgBox("Você tem certeza que deseja remover esta forma de pagamento?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For i As Integer = LstIndexApagar.Items.Count - 1 To 0 Step -1

                    DtFormas.Rows.RemoveAt(LstIndexApagar.Items(i).ToString)

                Next

            End If

        End If

    End Sub

    Dim DataGuard As Date

    Private Sub DtFormas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellEndEdit

        'verifica se valor é valido, e se deseja incorporar mudanças nos próximos vencimentos

        Try

            DtFormas.Rows(e.RowIndex).Cells(4).Value = FormatDateTime(DtFormas.Rows(e.RowIndex).Cells(4).Value, DateFormat.ShortDate)

            If MsgBox("Deseja atualizar as datas abaixo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim Data As Date = DtFormas.Rows(e.RowIndex).Cells(4).Value
                Dim _Cod As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value
                'busca intervalo

                Dim BuscaIntervalo = From inter In LqFinanceiro.FormasPgEntrada
                                     Where inter.IdFormasPgEntrada = _Cod
                                     Select inter.Intervalo, inter.TipoIntervalo

                Dim _intervalo As Integer = BuscaIntervalo.First.Intervalo
                Dim _TipoIntervalo As Boolean = BuscaIntervalo.First.TipoIntervalo

                Dim _C As Integer = 1

                For Each row As DataGridViewRow In DtFormas.Rows

                    If row.Index > e.RowIndex Then

                        If row.Cells(0).Value = DtFormas.Rows(e.RowIndex).Cells(0).Value Then

                            If _TipoIntervalo = True Then

                                Data = Data.AddDays(_C * _intervalo)

                                row.Cells(4).Value = FormatDateTime(Data, DateFormat.ShortDate)

                            Else

                                Data = Data.AddMonths(_C * _intervalo)

                                row.Cells(4).Value = FormatDateTime(Data, DateFormat.ShortDate)

                            End If

                            _C += 1

                        End If

                    End If

                Next

            End If

        Catch ex As Exception

            MsgBox("O valor não é uma data válida.", vbOKOnly)

            DtFormas.Rows(e.RowIndex).Cells(4).Value = FormatDateTime(DataGuard, DateFormat.ShortDate)

        End Try

    End Sub

    Private Sub DtFormas_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DtFormas.CellBeginEdit

        DataGuard = DtFormas.Rows(e.RowIndex).Cells(4).Value

    End Sub

    Public VerOrc As Integer
    Public IdSolucao As Integer
    Private Sub BttInsereVersão_Click(sender As Object, e As EventArgs) Handles BttInsereVersão.Click

        Dim VerAnterior As Integer = VerOrc

        VerOrc += 1

        LblVersão.Text = VerOrc

        'acrescenta nova versão

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                'insere no banco de dados

                Dim Cod As Integer = row.Cells(1).Value
                Dim Qt As Integer = row.Cells(1).Value

                LqComercial.InsereNovoItemOrcamento(0, Cod, LblNumOrcamento.Text, Qt, VerOrc, 0, 0, Today.Date, False, IdSolucao, 0)


                'edita o parent
                'busca cotação

                Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                    Where cot.IdProduto = Cod
                                    Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                    Order By DataCotacao Descending

                If VerAnterior <> VerOrc Then

                    VerAnterior = VerOrc

                    TrResumo.Nodes.Add("Versão " & VerOrc)
                    TrResumo.Nodes(TrResumo.Nodes.Count - 1).ForeColor = Color.SlateGray

                End If

                Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                If BuscaCotações.Count > 0 Then

                    'insere no treeview

                    Dim BuscaProduto = From prod In LqBase.Produtos
                                       Where prod.IdProduto = Cod
                                       Select prod.Descricao

                    TrProdutos.Nodes.Add(Cod & " - " & BuscaProduto.First)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray

                    Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(VlrVenda, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(VlrVenda * row.Cells(9).Value, NumDigitsAfterDecimal:=2))

                End If

            End If

        Next

        TrResumo.CollapseAll()

        If TrResumo.Nodes.Count > 0 Then
            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()
        End If

    End Sub

    Private Sub DtProdutos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellEndEdit

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmQt" Then

            DtProdutos.Rows(e.RowIndex).Cells(0).Value = True

            'calcula final

            Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
            Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
            Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
            Desconto = Desconto.Replace("%", "")

            Dim Vl_Desconto As Decimal = Desconto

            DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            If Qt = 0 Then

                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False

            End If

            If TrResumo.Nodes.Count > 0 Then
                TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()
            End If

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()


        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmDesconto" Then

            DtProdutos.Rows(e.RowIndex).Cells(0).Value = True

            'calcula final

            Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
            Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
            Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
            Desconto = Desconto.Replace("%", "")

            Dim Vl_Desconto As Decimal = Desconto

            DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)
            DtProdutos.Rows(e.RowIndex).Cells(11).Value = FormatPercent(Vl_Desconto / 100, NumDigitsAfterDecimal:=2)

            If Qt = 0 Then

                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False

            End If

            If TrResumo.Nodes.Count > 0 Then
                TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()
            End If

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()

        End If


        If DtProdutos.Rows(e.RowIndex).Cells(9).Value = 0 Then

            DtProdutos.Rows(e.RowIndex).Cells(0).Value = False


            If TrResumo.Nodes.Count > 0 Then
                TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()
            End If

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

            'TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()

        End If


        'verifica se é possivel declinar ou aprovar o orçamento

        Dim C As Integer = 0

        Dim _DescontosTotais As Decimal
        Dim _ValorFinal As Decimal
        Dim _ValorSemDesconto As Decimal

        For Each row As DataGridViewRow In DtProdutos.Rows

            Dim ValorUnit As Decimal = row.Cells(7).Value
            Dim Qt As Integer = row.Cells(9).Value
            Dim Subtotal As Decimal = row.Cells(12).Value

            If row.Cells(0).Value = True And row.Cells(7).Value = 0 Then
                C += 1
            End If

            _ValorSemDesconto += (ValorUnit * Qt)

            _DescontosTotais += (ValorUnit * Qt) - Subtotal

            _ValorFinal += Subtotal

        Next

        'verifica formas de pagamento salva

        Dim _TotalFormas As Decimal

        For Each row As DataGridViewRow In DtFormas.Rows

            _TotalFormas += row.Cells(3).Value

        Next


        If C = 0 Then

            BttDeclinarOrc.Enabled = True

        Else

            BttDeclinarOrc.Enabled = False

        End If

        If C = 0 And _TotalFormas >= LblValorTotal.Text And LblValorTotal.Text > 0 Then

            BttAprovarOrc.Enabled = True

        Else

            BttAprovarOrc.Enabled = False

        End If

        LblSubtotal.Text = FormatCurrency(_ValorSemDesconto, NumDigitsAfterDecimal:=2)

        LblValorTotal.Text = FormatCurrency(_ValorFinal, NumDigitsAfterDecimal:=2)

        LblDescontos.Text = FormatCurrency(_DescontosTotais, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub DtProdutos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellClick

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtCodProduto.TextChanged

        If TxtCodProduto.Text <> "" Then

            'desabilita outros camps de filtro por ser unico

            TxtPN.Enabled = False
            TxtDescrição.Enabled = False

            TxtPN.Text = ""
            TxtDescrição.Text = ""

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(1).Value = TxtCodProduto.Text Then

                    row.Visible = True

                Else

                    row.Visible = False

                End If

            Next

        Else

            TxtPN.Enabled = True
            TxtDescrição.Enabled = True

            FiltraProdutos()

        End If

    End Sub

    Public Sub FiltraProdutos()

        Dim LstItemProdutos As New ListBox

        If CkMostrarSemEstoque.Checked = True Then
            LstItemProdutos.Items.Add("Sem estoque")
        End If

        If CkNova.Checked = True Then
            LstItemProdutos.Items.Add("Produto novo")
        End If

        If CkUsado.Checked = True Then
            LstItemProdutos.Items.Add("Produto usado")
        End If

        If CkRecondicionado.Checked = True Then
            LstItemProdutos.Items.Add("Produto recondicionado")
        End If

        If CkSolicitacao.Checked = True Then
            LstItemProdutos.Items.Add("Sol. de cadastro")
        End If

        'filtra od produto

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(6).Value.contains(TxtPN.Text) And row.Cells(2).Value.ToString.ToUpper.Contains(TxtDescrição.Text.ToUpper) And row.Cells(3).Value.ToString.ToUpper.Contains(CmbFabricantes.Text.ToUpper) And row.Cells(4).Value.ToString.ToUpper.Contains(CmbCategoria.Text.ToUpper) And row.Cells(5).Value.ToString.ToUpper.Contains(CmbSubCategoria.Text.ToUpper) And LstItemProdutos.Items.Contains(row.Cells(13).Value.ToString) Then

                row.Visible = True

            Else

                row.Visible = False

            End If

        Next


    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TxtPN.TextChanged

        FiltraProdutos()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        FiltraProdutos()

    End Sub

    Public IdModeloVeiculo As Integer

    Private Sub CmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoria.SelectedIndexChanged

        If CmbCategoria.Text <> "" Then

            LstIdSubCategoria.Items.Clear()
            CmbSubCategoria.Items.Clear()

            'busca fabricantesloda

            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaSubcategoria = From cat In LqBase.SubCategoriasProduto
                                    Where cat.IdCategoria = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString
                                    Select cat.Descricao, cat.IdSubCategoria

            For Each row In BuscaSubcategoria.ToList

                LstIdSubCategoria.Items.Add(row.IdSubCategoria)
                CmbSubCategoria.Items.Add(row.Descricao)

            Next

            CmbSubCategoria.Enabled = True

        Else

            CmbSubCategoria.Enabled = False
            CmbSubCategoria.Text = ""

        End If

        FiltraProdutos()

    End Sub

    Private Sub CmbFabricantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFabricantes.SelectedIndexChanged

        FiltraProdutos()

    End Sub

    Private Sub CmbSubCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSubCategoria.SelectedIndexChanged

        FiltraProdutos()

    End Sub

    Private Sub CmbCategoria_TextChanged(sender As Object, e As EventArgs) Handles CmbCategoria.TextChanged

        CmbSubCategoria.Items.Clear()

        'busca fabricantesloda

        For Each rw As DataGridViewRow In DtProdutos.Rows

            If rw.Cells(4).Value = CmbCategoria.Text Then

                If Not CmbSubCategoria.Items.Contains(rw.Cells(5).Value) Then

                    CmbSubCategoria.Items.Add(rw.Cells(5).Value)

                End If

            End If

        Next

        If CmbCategoria.Text <> "" Then

            CmbSubCategoria.Enabled = True

        Else

            CmbSubCategoria.Enabled = False
            CmbSubCategoria.Text = ""

        End If

        FiltraProdutos()

    End Sub

    Dim LqEstoqueLocal As New LqEstoqueLocalDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        VerOrc += 1

        'salva valores do orçamento

        'incrementa solicitações necessárias

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                If row.Cells(7).Value = 0 Then
                    Dim Qt As Integer = row.Cells(9).Value
                    Dim Cod As Integer

                    If Not row.Cells(1).Value.ToString.StartsWith("S") Then

                        Cod = row.Cells(1).Value

                        'insere cotação de solicitação

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Cod, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qt, 0, 0)

                    Else

                        Dim CodS As String = row.Cells(1).Value
                        CodS = CodS.Remove(0, 1)

                        Cod = CodS

                        'insere cotação de solicitação

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qt, 0, 0)

                    End If

                End If

            End If

        Next

        'apaga cardapio da versão do orçamento

        'LqComercial.DeletaItensOrcamento(LblNumOrcamento.Text, VerOrc)

        'insere novamente os produtos encontrados

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                Dim valorUnit As Decimal = row.Cells(7).Value
                Dim Qt As Decimal = row.Cells(9).Value
                Dim Desconto As String = row.Cells(11).Value
                Desconto = Desconto.Replace("%", "")

                Dim Vl_Desconto As Decimal = Desconto

                If Not row.Cells(1).Value.ToString.StartsWith("S") Then

                    LqComercial.InsereNovoItemOrcamento(0, row.Cells(1).Value, LblNumOrcamento.Text, Qt, VerOrc, valorUnit, Vl_Desconto, Today.Date, True, IdSolucao, 0)

                Else

                    Dim CodS As String = row.Cells(1).Value

                    CodS = CodS.Remove(0, 1)

                    LqComercial.InsereNovoItemOrcamento(CodS, 0, LblNumOrcamento.Text, Qt, VerOrc, valorUnit, Vl_Desconto, Today.Date, True, IdSolucao, 0)

                End If

            End If

        Next

        'insere novamente os produtos encontrados

        For Each row As DataGridViewRow In DtServiços.Rows

            If row.Cells(0).Value = True Then
                Dim valorUnit As Decimal = row.Cells(3).Value
                Dim Qt As Decimal = row.Cells(5).Value
                Dim Desconto As String = row.Cells(7).Value
                Desconto = Desconto.Replace("%", "")

                Dim Vl_Desconto As Decimal = Desconto

                LqComercial.InsereNovoItemOrcamento(0, row.Cells(1).Value, LblNumOrcamento.Text, Qt, VerOrc, valorUnit, Vl_Desconto, Today.Date, False, IdSolucao, 0)

            End If

        Next

        'apaga formas de pagamento da versão do orçamento

        LqComercial.DeletaFormasPgOrcamentoOrcamento(LblNumOrcamento.Text, VerOrc)

        'insere novamente os produtos encontrados

        For Each row As DataGridViewRow In DtFormas.Rows

            Dim valorUnit As Decimal = row.Cells(3).Value
            Dim Cod As Decimal = row.Cells(0).Value
            Dim Data As Date = row.Cells(4).Value

            LqComercial.InsereNovaFormaPgOrcamento(Cod, LblNumOrcamento.Text, VerOrc, valorUnit, row.Cells(2).Value, Data)

        Next

        'verifica o item 

        If Application.OpenForms.OfType(Of FrmEntradaVeiculo)().Count() > 0 Then

            Dim Lqoficina As New LqOficinaDataContext
            Lqoficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'apaga solucao vistoria

            'busca solucao

            Dim BuscaSolucao = From sol In Lqoficina.SoluçõesVistoria
                               Where sol.IdProcesso = FrmEntradaVeiculo.LblProcesso.Text
                               Select sol.IdSolucoes

            If BuscaSolucao.Count = 0 Then

                'insere solução

                Lqoficina.InsereSolucaoVistoria(0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, FrmEntradaVeiculo.LblProcesso.Text, IdMarca)

                Dim BuscaSolucaoN = From sol In Lqoficina.SoluçõesVistoria
                                    Where sol.IdProcesso = FrmEntradaVeiculo.LblProcesso.Text
                                    Select sol.IdSolucoes
                                    Order By IdSolucoes Descending

                'varre os itens com seleção

                For Each row As DataGridViewRow In DtProdutos.Rows

                    If row.Cells(0).Value = True Then

                        If row.Cells(1).Value.ToString.StartsWith("S") Then
                            Dim CodS As String = row.Cells(1).Value
                            CodS = CodS.Remove(0, 1)
                            Lqoficina.InsereItemSolucao(0, True, CodS, row.Cells(9).Value, False, BuscaSolucaoN.First)
                        Else
                            Lqoficina.InsereItemSolucao(row.Cells(1).Value, True, 0, row.Cells(9).Value, False, BuscaSolucaoN.First)
                        End If

                    End If

                Next

            Else

                For Each row As DataGridViewRow In DtProdutos.Rows

                    If row.Cells(0).Value = True Then

                        If row.Cells(1).Value.ToString.StartsWith("S") Then
                            Dim CodS As String = row.Cells(1).Value
                            CodS = CodS.Remove(0, 1)
                            Dim Cod As Integer = CodS
                            Dim Qt As Integer = row.Cells(9).Value

                            Lqoficina.DeletaSolucaoItemMarcaDesmonte(Cod, BuscaSolucao.First)

                            Lqoficina.InsereItemSolucao(0, True, Cod, Qt, False, BuscaSolucao.First)
                        Else
                            Dim Qt As Integer = row.Cells(9).Value
                            Dim Cod As Integer = row.Cells(1).Value

                            Lqoficina.DeletaSolucaoProdutomMarcaDesmonte(Cod, BuscaSolucao.First)

                            Lqoficina.InsereItemSolucao(Cod, True, 0, Qt, False, BuscaSolucao.First)
                        End If

                    End If

                Next

            End If

        End If

        Me.Close()

    End Sub

    Public IdMarca As Integer = 0

    Private Sub CmbFabricantes_TextChanged(sender As Object, e As EventArgs) Handles CmbFabricantes.TextChanged

        FiltraProdutos()

    End Sub

    Public _IdVeiculo As Integer

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        VerOrc += 1

        'declina orçamento online

        Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_fim_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamentoVinc=" & LblNumOrcamento.Text & "&DataAprovacao=" & Today.Date.ToShortDateString.Replace("/", "-") & "&HoraAprovacao=" & Now.TimeOfDay.ToString & "&Aprovacao=0"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'atualiza o desmonte para 60 (aprovado o desmonte)

        For Each prod As DataGridViewRow In DtProdutos.Rows

            If prod.Cells(0).Value = True Then

                'procura o id externo 

                If prod.Cells(1).Value.ToString.StartsWith("S") Then
                    'procura soliticacoes

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                                   Where sol.IdSolicitacaoCadastro = prod.Cells(1).Value.ToString.Remove(0, 1)
                                   Select sol.IdCodExt

                    Dim BuscaOrcamentoExt = From orc In LqComercial.Orcamentos
                                            Where orc.IdOrcamento = LblNumOrcamento.Text
                                            Select orc.IdCorOrcamentoExt

                    Dim baseUrlStatus As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_3_60.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & BuscaOrcamentoExt.First & "&IdItem=" & BuscaSol.First

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientStatus = New WebClient()
                    Dim contentStatus = syncClientStatus.DownloadString(baseUrlStatus)

                    'atualiza o endereço externo com o valor correto

                    Dim baseUrlValor As String = "http://www.iarasoftware.com.br/atualiza_valor_produto_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & BuscaOrcamentoExt.First & "&IdItem=" & BuscaSol.First

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientValor = New WebClient()
                    Dim contentValor = syncClientValor.DownloadString(baseUrlValor)

                Else

                    'procura produtos

                    Dim BuscaSol = From sol In LqBase.Produtos
                                   Where sol.IdProduto = prod.Cells(1).Value.ToString
                                   Select sol.IdProdutoExt

                    Dim BuscaOrcamentoExt = From orc In LqComercial.Orcamentos
                                            Where orc.IdOrcamento = LblNumOrcamento.Text
                                            Select orc.IdCorOrcamentoExt

                    Dim baseUrlStatus As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_3_60.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & BuscaOrcamentoExt.First & "&IdItem=" & BuscaSol.First

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientStatus = New WebClient()
                    Dim contentStatus = syncClientStatus.DownloadString(baseUrlStatus)

                    'atualiza o endereço externo com o valor correto

                    Dim baseUrlValor As String = "http://www.iarasoftware.com.br/atualiza_valor_produto_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & BuscaOrcamentoExt.First & "&IdItem=" & BuscaSol.First

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientValor = New WebClient()
                    Dim contentValor = syncClientValor.DownloadString(baseUrlValor)

                End If

            End If

        Next
        'salva valores do orçamento

        'incrementa solicitações necessárias

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then
                If row.Cells(7).Value = 0 Then
                    Dim Qt As Integer = row.Cells(9).Value
                    Dim Cod As Integer = row.Cells(1).Value
                    If Not row.Cells(1).Value.ToString.StartsWith("S") Then
                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Cod, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qt, 0, 0)
                    Else
                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod.ToString.Remove(0, 1), 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qt, 0, 0)
                    End If
                End If
            End If

        Next

        'apaga cardapio da versão do orçamento

        'LqComercial.DeletaItensOrcamento(LblNumOrcamento.Text, VerOrc)

        'insere novamente os produtos encontrados

        Dim lqOficina_0 As New LqOficinaDataContext
        lqOficina_0.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                If Not row.Cells(1).Value.ToString.StartsWith("S") Then

                    Dim valorUnit As Decimal = row.Cells(7).Value
                    Dim Qt As Decimal = row.Cells(9).Value
                    Dim Desconto As String = row.Cells(11).Value
                    Desconto = Desconto.Replace("%", "")

                    Dim Vl_Desconto As Decimal = Desconto

                    LqComercial.InsereNovoItemOrcamento(0, row.Cells(1).Value, LblNumOrcamento.Text, Qt, VerOrc, valorUnit, Vl_Desconto, Today.Date, True, IdSolucao, 0)

                    'Dim BuscaSolucao

                    lqOficina_0.InsereNovoReparoVeiculo(_IdVeiculo, row.Cells(1).Value, 0, True, "1111-11-11", Today.TimeOfDay, "1111-11-11", Today.TimeOfDay, 0)

                Else

                    Dim CodString As String = row.Cells(1).Value.ToString.Remove(0, 1)

                    Dim valorUnit As Decimal = row.Cells(7).Value
                    Dim Qt As Decimal = row.Cells(9).Value
                    Dim Desconto As String = row.Cells(11).Value
                    Desconto = Desconto.Replace("%", "")

                    Dim Vl_Desconto As Decimal = Desconto

                    LqComercial.InsereNovoItemOrcamento(CodString, 0, LblNumOrcamento.Text, Qt, VerOrc, valorUnit, Vl_Desconto, Today.Date, True, IdSolucao, 0)

                    lqOficina_0.InsereNovoReparoVeiculo(_IdVeiculo, 0, CodString, True, "1111-11-11", Today.TimeOfDay, "1111-11-11", Today.TimeOfDay, 0)

                End If

            End If

        Next

        'Insere serviços


        'apaga formas de pagamento da versão do orçamento

        LqComercial.DeletaFormasPgOrcamentoOrcamento(LblNumOrcamento.Text, VerOrc)

        'insere novamente os produtos encontrados

        For Each row As DataGridViewRow In DtFormas.Rows

            Dim valorUnit As Decimal = row.Cells(3).Value
            Dim Cod As Decimal = row.Cells(0).Value
            Dim Data As Date = row.Cells(4).Value

            LqComercial.InsereNovaFormaPgOrcamento(Cod, LblNumOrcamento.Text, VerOrc, valorUnit, row.Cells(2).Value, Data)

        Next

        'declara solicitações ao estoque

        For Each row As DataGridViewRow In DtProdutos.Rows

            If row.Cells(0).Value = True Then

                'busca dataorc

                Dim BuscaOrca = From orc In LqComercial.Orcamentos
                                Where orc.IdOrcamento = LblNumOrcamento.Text
                                Select orc.DataOrc

                Dim Cod As String = row.Cells(1).Value
                Dim _Qt As Integer = row.Cells(9).Value

                If Not Cod.StartsWith("S") Then

                    'verifica codigo externo

                    Dim BuscaVinculoExterno = From ext In LqBase.Produtos
                                              Where ext.IdProduto = Cod
                                              Select ext.IdProdutoExt

                    If BuscaOrca.First = "1111-11-11" Then

                        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                Where est.Destino Like "ORC_" & LblNumOrcamento.Text And est.IdProduto = Cod
                                                Select est.IdCodExterno

                        If BuscaEstoqueLocal.Count = 0 Then
                            LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(Cod, _Qt, "ORC_" & LblNumOrcamento.Text, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, 0, "1111-11-11", Today.TimeOfDay, BuscaVinculoExterno.First)
                        End If

                    Else

                        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                Where est.Destino Like "ORC_" & LblNumOrcamento.Text And est.IdProduto = Cod
                                                Select est.IdCodExterno

                        If BuscaEstoqueLocal.Count = 0 Then
                            LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(Cod, _Qt, "ORC_" & LblNumOrcamento.Text, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, 0, "1111-11-11", Today.TimeOfDay, BuscaVinculoExterno.First)
                        End If

                    End If


                        'verifica se necessita de compra

                        Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                           Where arm.IdProduto = Cod
                                           Select arm.Qt, arm.Endereco

                    Dim _TotalArm As Integer

                    For Each item In BuscaArmazenagem.ToList

                        'busca saidas deste lote

                        Dim ProcuraIdEndereco = From ende In LqEstoqueLocal.EnderecoEstoqueLocal
                                                Where ende.NomeEndereco Like item.Endereco
                                                Select ende.IdEndereco

                        Dim BuscaSaidas = From est In LqEstoqueLocal.BaixaEndereco
                                          Where est.IdEndereco = ProcuraIdEndereco.First
                                          Select est.Qt

                        For Each qt_it In BuscaSaidas.ToList

                            _TotalArm -= qt_it

                        Next

                        _TotalArm += item.Qt

                    Next

                    If _TotalArm < _Qt Then

                        'insere solicitação de compra no sistema

                        Dim BuscaCotacaovalida = From cot In LqFinanceiro.Cotacoes
                                                 Where cot.IdProduto = Cod
                                                 Select cot.IdFornecedor, cot.IdCotacao, cot.DataCotacao
                                                 Order By DataCotacao Descending

                        If BuscaCotacaovalida.Count > 0 Then

                            If BuscaCotacaovalida.First.DataCotacao.Value.AddDays(7) >= Today.Date Then
                                LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(Cod, _Qt - _TotalArm, BuscaCotacaovalida.First.IdCotacao, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)
                            Else
                                LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(Cod, _Qt - _TotalArm, BuscaCotacaovalida.First.IdCotacao, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)
                                'insere solicitação de cotação

                                LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Cod, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Now.TimeOfDay, _Qt - _TotalArm, 0, 0)
                            End If

                        End If

                    Else

                        'solicita as baixas dos lotes correspondentes

                    End If

                Else

                    Cod = Cod.Remove(0, 1)

                    'insere solicitação de compra no sistema

                    Dim BuscaCotacaovalida = From cot In LqFinanceiro.Cotacoes
                                             Where cot.IdSolicitacaoCad = Cod
                                             Select cot.IdFornecedor, cot.IdCotacao, cot.DataCotacao
                                             Order By DataCotacao Descending

                    If BuscaCotacaovalida.Count > 0 Then

                        If BuscaCotacaovalida.First.DataCotacao.Value.AddDays(7) >= Today.Date Then
                            LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(0, _Qt, BuscaCotacaovalida.First.IdCotacao, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, Cod)
                        Else
                            LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(0, _Qt, BuscaCotacaovalida.First.IdCotacao, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, Cod)
                            'insere solicitação de cotação
                            LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Now.TimeOfDay, _Qt, 0, 0)
                        End If

                    End If

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaVinculo = From ext In LqOficina.SolicitacaoCadastroPeca
                                       Where ext.IdSolicitacaoCadastro = Cod
                                       Select ext.IdCodExt

                    If BuscaOrca.First = "1111-11-11" Then

                        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                Where est.Destino Like "ORC_" & LblNumOrcamento.Text And est.IdProduto = Cod
                                                Select est.IdCodExterno

                        If BuscaEstoqueLocal.Count = 0 Then

                            LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(0, _Qt, "ORC_" & LblNumOrcamento.Text, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, Cod, "1111-11-11", Today.TimeOfDay, BuscaVinculo.First)

                        End If

                    Else

                        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.SolicitacaoProdutosEstoque
                                                Where est.Destino Like "ORC_" & LblNumOrcamento.Text And est.IdProduto = Cod
                                                Select est.IdCodExterno

                        If BuscaEstoqueLocal.Count = 0 Then

                            LqEstoqueLocal.InsereNovaSolicitacaoProdutoEstoque(0, _Qt, "ORC_" & LblNumOrcamento.Text, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, False, False, Cod, "1111-11-11", Today.TimeOfDay, BuscaVinculo.First)

                        End If

                    End If

                    End If

            End If

        Next

        'aprova orçamento

        LqComercial.AtualizaAprovacaoOrçamento(LblNumOrcamento.Text, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario)

        'manda informações de recebimento ao financeiro

        For Each row As DataGridViewRow In DtFormas.Rows

            Dim _id As Integer = row.Cells(0).Value
            Dim _ValorForma As Decimal = row.Cells(3).Value
            Dim _Vencimento As Date = row.Cells(4).Value

            LqFinanceiro.InsereNovaEntradaBalancete(LblNumOrcamento.Text, _ValorForma, 0, 0, _Vencimento, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, _id, "", "Venda por orçamento", "Venda técnica")

        Next

        'feh o form
        FrmComercial.DtCotFinal.Rows.Clear()

        FrmComercial.VerificaInicio()

        Me.Close()

    End Sub

    Public Sub Populacliente()

        'atualiza todos os comerciais

        Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                             Where orc.IdOrcamento Like "*"
                             Select orc.IdOrcamento, orc.IdCliente, orc.DataOrc, orc.Aprovado, orc.DataAprov

        Dim BuscaCLiente = From cli In LqBase.Clientes
                           Where cli.IdCliente = BuscaOrçamento.First.IdCliente
                           Select cli.RazaoSocial_nome

        Dim OrcFin As Integer
        Dim OrcPen As Integer
        Dim OrcPer As Integer

        FrmComercial.DtCotFinal.Rows.Clear()

        For Each row In BuscaOrçamento.ToList

            Dim HJ As Date = Today

            Dim Cotado As Integer
            Dim NCotado As Integer
            Dim Estoque As Integer

            Dim ValorORc As Decimal = 0
            Dim _Versao As Integer = 0
            Dim _DataOrc As Date = "1111-11-11"

            Dim BuscaProdutos = From orc In LqComercial.ProdutosOrcamento
                                Where orc.IdOrcamento = row.IdOrcamento
                                Select orc.IdProduto, orc.IdSolicitacao, orc.ValorUnit, orc.DescontoUnit, orc.IdProdutoOrcamento, orc.Qtdade, orc.Versao, orc.DataVersao

            For Each row1 In BuscaProdutos.ToList

                If _Versao <> row1.Versao Then

                    ValorORc = 0
                    _Versao = row1.Versao
                    _DataOrc = row1.DataVersao

                    Cotado = 0
                    NCotado = 0
                    Estoque = 0

                End If

                If row1.ValorUnit = 0 Then

                    'busca cotação

                    If row1.IdSolicitacao <> 0 Then

                        Dim LqOficina As New LqOficinaDataContext

                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        'verifica se item foi cotado

                        Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                               Where sol.IdSolicitacaoCadastro = row1.IdSolicitacao And sol.IdCodCad > 0
                                               Select sol.IdCodCad

                        Dim IdProduto As Integer

                        If BuscaSolicitação.Count > 0 Then

                            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                Where cot.IdProduto = BuscaSolicitação.First
                                                Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                Order By DataCotacao Descending

                            If BuscaCotações.Count > 0 Then

                                If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                                    'atualiza valor do orçamento

                                    LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, BuscaSolicitação.First, row1.IdSolicitacao, BuscaCotações.First.ValorCotado)

                                    '


                                    Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                    ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                    Cotado += 1

                                Else

                                    NCotado += 1

                                End If

                            Else

                                NCotado += 1

                            End If

                        Else

                            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                                Where cot.IdSolicitacaoCad = row1.IdSolicitacao
                                                Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                                Order By DataCotacao Descending

                            If BuscaCotações.Count > 0 Then

                                Dim buscaValidade As Date = BuscaCotações.First.DataCotacao.Value.Date.AddDays(7)

                                If buscaValidade >= HJ Then

                                    'atualiza valor do orçamento

                                    LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, row1.IdProduto, row1.IdSolicitacao, BuscaCotações.First.ValorCotado)

                                    '


                                    Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                    ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                    Cotado += 1

                                Else

                                    NCotado += 1

                                End If

                            Else

                                NCotado += 1

                            End If

                        End If

                    Else

                        Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                            Where cot.IdProduto = row1.IdProduto
                                            Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                            Order By DataCotacao Descending

                        If BuscaCotações.Count > 0 Then

                            If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                                'atualiza valor do orçamento

                                LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, row1.IdProduto, row1.IdSolicitacao, BuscaCotações.First.ValorCotado)

                                '


                                Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                                ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                                Cotado += 1

                            Else

                                NCotado += 1

                            End If

                        Else

                            NCotado += 1

                        End If

                    End If

                Else

                    Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                        Where cot.IdProduto = row1.IdProduto
                                        Select cot.ValorCotado, cot.DataCotacao, cot.Markup
                                        Order By DataCotacao Descending

                    If BuscaCotações.Count > 0 Then
                        '
                        If BuscaCotações.First.DataCotacao.Value.Date.AddDays(7) >= HJ Then

                            'atualiza valor do orçamento

                            LqComercial.AtualizavalorItemOrcamento(row1.IdProdutoOrcamento, row1.IdProduto, row1.IdSolicitacao, BuscaCotações.First.ValorCotado)

                            Dim VlrVenda As Decimal = BuscaCotações.First.ValorCotado + (BuscaCotações.First.ValorCotado * (BuscaCotações.First.Markup / 100))

                            ValorORc += (VlrVenda * row1.Qtdade) - ((VlrVenda * (row1.DescontoUnit / 100)) * row1.Qtdade)

                            Cotado += 1

                        Else

                            NCotado += 1

                        End If

                    End If

                End If

            Next

            If row.Aprovado = False Then

                If row.DataAprov = "1111-11-11" Then
                    If NCotado > 0 Then
                        FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando cotações de itens na lista.", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                        FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGoldenrod
                    Else
                        If Cotado = 0 Then
                            FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Sem itens na lista de orçamento", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
                        Else
                            FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando aprovação do cliente", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray

                        End If
                    End If
                    OrcPen += 1
                Else
                    FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Reprovado", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                    OrcPer += 1
                    FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
                End If

            Else

                If row.DataAprov = "1111-11-11" Then
                    If NCotado > 0 Then
                        FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando cotações de itens na lista.", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                        FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGoldenrod
                    Else
                        If Cotado = 0 Then
                            FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Sem itens na lista de orçamento", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkRed
                        Else
                            FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aguardando aprovação do cliente", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                            FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkSlateGray
                        End If

                    End If

                    OrcPen += 1

                Else
                    FrmComercial.DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCLiente.First, FormatDateTime(_DataOrc, DateFormat.ShortDate), "Aprovado", FormatCurrency(ValorORc, NumDigitsAfterDecimal:=2))
                    FrmComercial.DtCotFinal.Rows(FrmComercial.DtCotFinal.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.DarkGreen
                    OrcFin += 1

                End If

            End If


            Cotado = 0
            NCotado = 0
            Estoque = 0

        Next

        FrmComercial.Label6.Text = OrcPer
        FrmComercial.Label7.Text = OrcFin
        FrmComercial.Label8.Text = OrcPen

        Me.Close()

    End Sub
    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FrmUsarSolitaçõesCadatroPeça.Invoc = 1

        FrmUsarSolitaçõesCadatroPeça.Show(Me)

    End Sub

    Private Sub CkNova_CheckedChanged(sender As Object, e As EventArgs) Handles CkNova.CheckedChanged

        FiltraProdutos()

    End Sub

    Private Sub CkUsado_CheckedChanged(sender As Object, e As EventArgs) Handles CkUsado.CheckedChanged

        FiltraProdutos()

    End Sub

    Private Sub CkRecondicionado_CheckedChanged(sender As Object, e As EventArgs) Handles CkRecondicionado.CheckedChanged

        FiltraProdutos()

    End Sub

    Private Sub CkSolicitacao_CheckedChanged(sender As Object, e As EventArgs) Handles CkSolicitacao.CheckedChanged

        FiltraProdutos()

    End Sub

    Private Sub CkMostrarSemEstoque_CheckedChanged(sender As Object, e As EventArgs) Handles CkMostrarSemEstoque.CheckedChanged

        FiltraProdutos()

    End Sub

    Private Sub DtServiços_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServiços.CellContentClick

        If DtServiços.Columns(e.ColumnIndex).Name = "ClmSelecionarServ" Then

            If DtServiços.Rows(e.RowIndex).Cells(0).Value = True Then

                DtServiços.Rows(e.RowIndex).Cells(0).Value = False
                DtServiços.Rows(e.RowIndex).Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                DtServiços.Rows(e.RowIndex).Cells(9).Value = FormatNumber(0, NumDigitsAfterDecimal:=0)
                DtServiços.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

            Else
                DtServiços.SelectedCells(0).Value = True

                'calcula final

                Dim valorUnit As Decimal = DtServiços.Rows(e.RowIndex).Cells(3).Value
                Dim Qt As Decimal = DtServiços.Rows(e.RowIndex).Cells(5).Value
                Dim Desconto As String = DtServiços.Rows(e.RowIndex).Cells(7).Value
                Desconto = Desconto.Replace("%", "")

                Dim Vl_Desconto As Decimal = Desconto

                Qt += 1

                DtServiços.Rows(e.RowIndex).Cells(5).Value = Qt

                DtServiços.Rows(e.RowIndex).Cells(8).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            End If

            If TrResumo.Nodes.Count > 0 Then

                TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()

                For Each row As DataGridViewRow In DtServiços.Rows

                    If row.Cells(0).Value = True Then

                        'insere no banco de dados

                        Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                        TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(3).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(5).Value & " = " & FormatCurrency(row.Cells(8).Value, NumDigitsAfterDecimal:=2))


                    End If

                Next

                For Each row As DataGridViewRow In DtProdutos.Rows

                    If row.Cells(0).Value = True Then

                        'insere no banco de dados

                        Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                        TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))


                    End If

                Next

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmMinusProd" Then

            'calcula final

            Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
            Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
            Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
            Desconto = Desconto.Replace("%", "")

            Dim Vl_Desconto As Decimal = Desconto

            If Qt > 0 Then
                Qt -= 1

            End If

            If Qt = 0 Then

                DtProdutos.Rows(e.RowIndex).Cells(0).Value = False

            End If

            DtProdutos.Rows(e.RowIndex).Cells(9).Value = Qt

            DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

            TrResumo.CollapseAll()

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmMoreProd" Then

            DtProdutos.Rows(e.RowIndex).Cells(0).Value = True

            'calcula final

            Dim valorUnit As Decimal = DtProdutos.Rows(e.RowIndex).Cells(7).Value
            Dim Qt As Decimal = DtProdutos.Rows(e.RowIndex).Cells(9).Value
            Dim Desconto As String = DtProdutos.Rows(e.RowIndex).Cells(11).Value
            Desconto = Desconto.Replace("%", "")

            Dim Vl_Desconto As Decimal = Desconto

            Qt += 1

            DtProdutos.Rows(e.RowIndex).Cells(9).Value = Qt

            DtProdutos.Rows(e.RowIndex).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).Nodes.Clear()

            For Each row As DataGridViewRow In DtProdutos.Rows

                If row.Cells(0).Value = True Then

                    'insere no banco de dados

                    Dim TrProdutos As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                    TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                    TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                End If

            Next

        End If

        If TrResumo.Nodes.Count > 0 Then

            TrResumo.Nodes(TrResumo.Nodes.Count - 1).ExpandAll()

        End If

        'verifica se é possivel declinar ou aprovar o orçamento

        Dim C As Integer = 0

        Dim _DescontosTotais As Decimal
        Dim _ValorFinal As Decimal
        Dim _ValorSemDesconto As Decimal

        For Each row As DataGridViewRow In DtProdutos.Rows

            Dim ValorUnit As Decimal = row.Cells(7).Value
            Dim Qt As Integer = row.Cells(9).Value
            Dim Subtotal As Decimal = row.Cells(12).Value

            If row.Cells(0).Value = True And row.Cells(7).Value = 0 Then
                C += 1
            End If

            _ValorSemDesconto += (ValorUnit * Qt)

            _DescontosTotais += (ValorUnit * Qt) - Subtotal

            _ValorFinal += Subtotal

        Next

        'verifica formas de pagamento salva

        Dim _TotalFormas As Decimal

        For Each row As DataGridViewRow In DtFormas.Rows

            _TotalFormas += row.Cells(3).Value

        Next

        If C = 0 Then

            BttDeclinarOrc.Enabled = True

        Else

            BttDeclinarOrc.Enabled = False

        End If

        If C = 0 And _TotalFormas >= LblValorTotal.Text And LblValorTotal.Text > 0 Then

            BttAprovarOrc.Enabled = True

        Else

            BttAprovarOrc.Enabled = False

        End If

        LblSubtotal.Text = FormatCurrency(_ValorSemDesconto, NumDigitsAfterDecimal:=2)

        LblValorTotal.Text = FormatCurrency(_ValorFinal, NumDigitsAfterDecimal:=2)

        LblDescontos.Text = FormatCurrency(_DescontosTotais, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub BttEnviarEmail_Click(sender As Object, e As EventArgs) Handles BttEnviarEmail.Click
        Try

            If File.Exists("C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf") Then

                File.Delete("C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf")

            End If

            Dim linha As Decimal = 15
            Dim MargemEsq As Decimal = 10

            'verifica se informou valores para as caixas de texto
            'verifica se o arquivo ou pasta de destino existe
            If Not File.Exists("C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf") Then
                'Cria um documento PDF
                Dim pdf As PdfDocument = New PdfDocument
                'definindo informações do autor e palavras chaves
                pdf.Info.Author = "I.A.R.A."
                pdf.Info.Keywords = "PdfSharp, Exemplos, VB .NET"
                'informando a data de criação do documento
                pdf.Info.CreationDate = DateTime.Now
                ' informando o assunto
                pdf.Info.Subject = "Orçamento número: " & LblNumOrcamento.Text & "v." & LblVersão.Text
                'cria uma página vazia
                Dim pdfPage As PdfPage = pdf.AddPage
                'Cria um objeto XGraphics
                Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
                ' Desenha linhas cruzadas
                Dim pen As XPen = New XPen(XColor.FromArgb(100, 173, 190, 201), 1)
                Dim penItem As XPen = New XPen(XColor.FromName("SlateGray"), 0.5)

                'linhas do cabeçalho
                Dim Pt0 As Double = pdfPage.Width.Point - 95
                Dim Pt1 As Double = linha - 15
                Dim Pt2 As Double = 100
                Dim Pt3 As Double = 85

                Dim img As Image = My.Resources.LogoIaraTrsnp
                Dim strm As MemoryStream = New MemoryStream()
                img.Save(strm, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfoto As XImage = XImage.FromStream(strm)

                Dim imgMcD As Image = My.Resources.whatsapp_image_2020_09_10_at_16_41_44
                Dim strmMcD As MemoryStream = New MemoryStream()
                imgMcD.Save(strmMcD, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoMcD As XImage = XImage.FromStream(strmMcD)

                Dim Pincel As New XSolidBrush
                Pincel.Color = XColor.FromArgb(100, 229, 229, 229)
                Dim PincelItemFoto As New XSolidBrush
                PincelItemFoto.Color = XColor.FromArgb(150, 0, 0, 0)

                graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                Dim Pt0_MC As Double = 90
                Dim Pt1_MC As Double = 160
                Dim Pt2_MC As Double = pdfPage.Width.Point - (90 * 2)
                Dim Pt3_MC As Double = pdfPage.Height.Point - (Pt1_MC * 2)

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)

                Dim PincelBrancoTransp As New XSolidBrush
                PincelBrancoTransp.Color = XColor.FromArgb(200, XColors.White)

                graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                'graph.DrawRectangle(New Brush(Color.FromArgb(0, 0, 0, 0), New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                'graph.DrawLine(pen, New XPoint(pdfPage.Width.Point, 0), New XPoint(0, pdfPage.Height.Point))
                'Desenha uma elipse
                'graph.DrawEllipse(pen, 3 * pdfPage.Width.Point / 10, 3 * pdfPage.Height.Point / 10, 2 * pdfPage.Width.Point / 5, 2 * pdfPage.Height.Point / 5)
                'Cria um objeto Font a partir de XFont
                Dim font As XFont = New XFont("Verdana", 8.25, XFontStyle.Regular)
                Dim fontItem As XFont = New XFont("Verdana", 6.25, XFontStyle.Regular)

                'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 20

                Dim FimCabec As Double = linha

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                linha += 15

                graph.DrawString("Itens no orçamento", fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                linha += 20

                linha += 5

                graph.DrawString("PRODUTOS", fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                linha += 10

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                'define os produtos no orçamento

                linha += 10

                graph.DrawRectangle(Pincel, New XRect(15, linha - 5, (pdfPage.Width.Point - 15) - 15, 15))

                graph.DrawString("Descrição do produto", fontItem, XBrushes.Black, New XRect(MargemEsq + 30, linha, +250, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Código", fontItem, XBrushes.Black, New XRect(MargemEsq + 15, linha, 30, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Qtdade", fontItem, XBrushes.Black, New XRect(MargemEsq + 250, linha, 30, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Valor unitário", fontItem, XBrushes.Black, New XRect(MargemEsq + 280, linha, 100, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Desconto %", fontItem, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.TopCenter)
                graph.DrawString("Subtotal", fontItem, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.TopCenter)

                graph.DrawLine(pen, New XPoint(15, linha - 2), New XPoint(pdfPage.Width.Point - 15, linha - 2))

                linha += 10
                graph.DrawLine(pen, New XPoint(15, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                graph.DrawLine(pen, New XPoint((15), linha - 10), New XPoint((15), linha + 5))
                graph.DrawLine(pen, New XPoint((pdfPage.Width.Point - 15), linha - 10), New XPoint((pdfPage.Width.Point - 15), linha + 5))

                linha += 5

                Dim CProd As Integer = 0
                Dim VlrTotalProd As Decimal = 0

                For Each row As DataGridViewRow In DtProdutos.Rows

                    If row.Cells(0).Value = True Then

                        If row.Cells(0).Value = True Then

                            graph.DrawString(row.Cells(2).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 30, linha, 250, 20), XStringFormats.Center)
                            graph.DrawString(row.Cells(1).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 15, linha, 30, 20), XStringFormats.Center)
                            graph.DrawString(row.Cells(5).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 250, linha, 30, 20), XStringFormats.Center)
                            graph.DrawString(row.Cells(3).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 280, linha, 100, 20), XStringFormats.Center)
                            graph.DrawString(row.Cells(7).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.Center)
                            graph.DrawString(row.Cells(8).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.Center)

                            CProd += 1

                            VlrTotalProd += row.Cells(8).Value

                            linha += 20
                            graph.DrawLine(pen, New XPoint(15, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                        End If
                        CProd += 1
                    End If

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15
                    End If

                Next

                graph.DrawLine(pen, New XPoint(15, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                linha += 10

                graph.DrawRectangle(Pincel, New XRect(MargemEsq + 380, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq + 380), 30))

                graph.DrawString("Total", font, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.TopCenter)
                graph.DrawString(FormatCurrency(VlrTotalProd, NumDigitsAfterDecimal:=2), font, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.TopCenter)

                linha += 20

                graph.DrawLine(pen, New XPoint((MargemEsq + 380), linha - 30), New XPoint((MargemEsq + 380), linha))
                graph.DrawLine(pen, New XPoint((pdfPage.Width.Point - 15), linha - 30), New XPoint((pdfPage.Width.Point - 15), linha))

                graph.DrawLine(pen, New XPoint(MargemEsq + 380, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                linha += 20
                'linha += 20

                'graph.DrawString("Itens na lista.: " & CProd, fontItem, XBrushes.Black, New XRect(MargemEsq, linha, pdfPage.Width.Point, linha), XStringFormats.TopLeft)

                'linha += 20

                'graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                'linha += 5

                graph.DrawString("SERVIÇOS", fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                linha += 10

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                'define os produtos no orçamento

                'define cabeçalho

                linha += 10

                graph.DrawRectangle(Pincel, New XRect(15, linha - 5, (pdfPage.Width.Point - 15) - 15, 15))

                graph.DrawString("Descrição do serviço", fontItem, XBrushes.Black, New XRect(MargemEsq + 30, linha, 250, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Código", fontItem, XBrushes.Black, New XRect(MargemEsq + 15, linha, 30, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Qtdade", fontItem, XBrushes.Black, New XRect(MargemEsq + 250, linha, 30, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Valor unitário", fontItem, XBrushes.Black, New XRect(MargemEsq + 280, linha, 100, linha + 20), XStringFormats.TopCenter)
                graph.DrawString("Desconto %", fontItem, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.TopCenter)
                graph.DrawString("Subtotal", fontItem, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.TopCenter)

                graph.DrawLine(pen, New XPoint(15, linha - 2), New XPoint(pdfPage.Width.Point - 15, linha - 2))

                linha += 10
                graph.DrawLine(pen, New XPoint(15, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                graph.DrawLine(pen, New XPoint((15), linha - 10), New XPoint((15), linha + 5))
                graph.DrawLine(pen, New XPoint((pdfPage.Width.Point - 15), linha - 10), New XPoint((pdfPage.Width.Point - 15), linha + 5))

                linha += 5

                Dim CServ As Integer = 0

                Dim VlrTotal As Decimal = 0

                For Each row As DataGridViewRow In DtServiços.Rows

                    If row.Cells(0).Value = True Then

                        graph.DrawString(row.Cells(2).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 30, linha, 250, 20), XStringFormats.Center)
                        graph.DrawString(row.Cells(1).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 15, linha, 30, 20), XStringFormats.Center)
                        graph.DrawString(row.Cells(5).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 250, linha, 30, 20), XStringFormats.Center)
                        graph.DrawString(row.Cells(3).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 280, linha, 100, 20), XStringFormats.Center)
                        graph.DrawString(row.Cells(7).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.Center)
                        graph.DrawString(row.Cells(8).Value.ToString, fontItem, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.Center)

                        VlrTotal += row.Cells(8).Value.ToString
                        CServ += 1

                        linha += 20
                        graph.DrawLine(pen, New XPoint(15, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                        graph.DrawLine(pen, New XPoint((15), linha - 20), New XPoint((15), linha))
                        graph.DrawLine(pen, New XPoint((pdfPage.Width.Point - 15), linha - 20), New XPoint((pdfPage.Width.Point - 15), linha))

                    End If

                    'verifica fim do rodapé

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15
                    End If


                Next

                graph.DrawLine(pen, New XPoint(15, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                linha += 10

                graph.DrawRectangle(Pincel, New XRect(MargemEsq + 380, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq + 380), 30))

                graph.DrawString("Total", font, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.TopCenter)
                graph.DrawString(FormatCurrency(VlrTotal, NumDigitsAfterDecimal:=2), font, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.TopCenter)

                linha += 20

                graph.DrawLine(pen, New XPoint((MargemEsq + 380), linha - 30), New XPoint((MargemEsq + 380), linha))
                graph.DrawLine(pen, New XPoint((pdfPage.Width.Point - 15), linha - 30), New XPoint((pdfPage.Width.Point - 15), linha))

                graph.DrawLine(pen, New XPoint(MargemEsq + 380, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                'graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                linha += 10

                'desenha rodapé

                linha = pdfPage.Height.Point - 60

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))
                linha += 10

                graph.DrawRectangle(Pincel, New XRect(MargemEsq + 380, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq + 380), 30))

                graph.DrawString("Valor total", font, XBrushes.Black, New XRect(MargemEsq + 380, linha, 70, 20), XStringFormats.TopCenter)
                graph.DrawString(FormatCurrency(VlrTotal + VlrTotalProd, NumDigitsAfterDecimal:=2), font, XBrushes.Black, New XRect(MargemEsq + 380 + 70, linha, (pdfPage.Width.Point - 15) - (MargemEsq + 380 + 70), 20), XStringFormats.TopCenter)

                linha += 20

                graph.DrawLine(pen, New XPoint((MargemEsq + 380), linha - 30), New XPoint((MargemEsq + 380), linha))
                graph.DrawLine(pen, New XPoint((pdfPage.Width.Point - 15), linha - 30), New XPoint((pdfPage.Width.Point - 15), linha))

                graph.DrawLine(pen, New XPoint(MargemEsq + 380, linha), New XPoint(pdfPage.Width.Point - 15, linha))

                'graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                'cria layout tecnico


                graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                linha = 15

                'pdf.AddPage()

                pdfPage = pdf.AddPage()

                graph = XGraphics.FromPdfPage(pdfPage)

                graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                linha += 20

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                linha += 15

                'graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)
                graph.DrawString("Análise técnica", fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                'insere imagem conforme a categoria frontal

                linha += 25

                Dim imgCat01 As Image = My.Resources.VFrenteVetor
                Dim strmCat01 As MemoryStream = New MemoryStream()
                imgCat01.Save(strmCat01, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat01 As XImage = XImage.FromStream(strmCat01)

                Dim Pt0_Cat01 As Double = MargemEsq + 50
                Dim Pt1_Cat01 As Double = linha
                Dim Pt2_Cat01 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 120
                Dim Pt3_Cat01 As Double = 130

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat01, Pt0_Cat01, Pt1_Cat01, Pt2_Cat01, Pt3_Cat01)

                'busca a imagem frontal para o veiculo

                Dim LqOficina As New LqOficinaDataContext
                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                Dim BuscaIdVeiculoInt = From idveic In LqOficina.Veiculos
                                        Where idveic.IdVeiculoExt = _IdVeiculo
                                        Select idveic.IdVeiculo

                Dim BuscaImagemFrontalVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                                Where veic.Descricao Like "Frontal - Principal" And veic.IdVeiculo = BuscaIdVeiculoInt.First
                                                Select veic.ImagemColetado, veic.IdVeiculo, veic.IdSolicitacao

                If BuscaImagemFrontalVeiculo.Count > 0 Then
                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemFrontalVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = (((pdfPage.Width.Point)) / 2) + 175
                    Dim Pt1_Frontal As Double = linha + 70
                    Dim Pt2_Frontal As Double = 110
                    Dim Pt3_Frontal As Double = 75

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15

                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucao = From sol In LqOficina.ImagemVeiculosColetado
                                   Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Frontal - Avaliacao"
                                   Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementar = From sol In LqOficina.ImagemVeiculosColetado
                                               Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Frontal - Complementar"
                                               Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucao.Count + buscaSolucaoComplementar.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15


                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                'procura solucoes asociadas a esta imagem

                If buscaSolucao.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucao.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 65, 2, 185))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 120, MargemEsq + 40, 2))

                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoComplementar.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementar.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 65, 2, 185))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 120, MargemEsq + 40, 2))

                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucao.Count = 0 And buscaSolucaoComplementar.Count = 0 Then

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    If linha + 175 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If

                Dim imgCat02 As Image = My.Resources.VtrasVetor
                Dim strmCat02 As MemoryStream = New MemoryStream()
                imgCat02.Save(strmCat02, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat02 As XImage = XImage.FromStream(strmCat02)

                Dim Pt0_Cat02 As Double = MargemEsq + 50
                Dim Pt1_Cat02 As Double = linha
                Dim Pt2_Cat02 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 120
                Dim Pt3_Cat02 As Double = 130

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat02, Pt0_Cat02, Pt1_Cat02, Pt2_Cat02, Pt3_Cat02)

                Dim BuscaImagemTraseiraVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                                 Where veic.Descricao Like "Traseira - Principal" And veic.IdVeiculo = BuscaIdVeiculoInt.First
                                                 Select veic.ImagemColetado, veic.IdVeiculo

                If BuscaImagemTraseiraVeiculo.Count > 0 Then
                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemTraseiraVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = (((pdfPage.Width.Point)) / 2) + 175
                    Dim Pt1_Frontal As Double = linha + 70
                    Dim Pt2_Frontal As Double = 110
                    Dim Pt3_Frontal As Double = 75

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoTras = From sol In LqOficina.ImagemVeiculosColetado
                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Traseira - Avaliacao"
                                       Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarTras = From sol In LqOficina.ImagemVeiculosColetado
                                                   Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Traseira - Complementar"
                                                   Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoTras.Count + buscaSolucaoComplementarTras.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 75

                If buscaSolucaoTras.Count > 0 Then

                    linha += 30

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoTras.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 65, 2, 185))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 120, MargemEsq + 40, 2))

                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoComplementarTras.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementarTras.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 131))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 65, 2, 185))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 120, MargemEsq + 40, 2))

                    'graph.DrawRectangle(Pincel, New XRect(MargemEsq + 30, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2), 130))
                    graph.DrawRectangle(PincelItemFoto, New XRect((((pdfPage.Width.Point)) / 2) + 102, linha - 1, ((pdfPage.Width.Point - 30) / 2) - 145, 100))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 105
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 100

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoTras.Count = 0 And buscaSolucaoComplementarTras.Count = 0 Then

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    If linha + 175 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                Dim imgCat03 As Image = My.Resources.VLateEsq
                Dim strmCat03 As MemoryStream = New MemoryStream()
                imgCat03.Save(strmCat03, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat03 As XImage = XImage.FromStream(strmCat03)

                Dim Pt0_Cat03 As Double = MargemEsq + 10
                Dim Pt1_Cat03 As Double = linha + 20
                Dim Pt2_Cat03 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat03 As Double = 100

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat03, Pt0_Cat03, Pt1_Cat03, Pt2_Cat03, Pt3_Cat03)

                Dim BuscaImagemLatEsqVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                               Where veic.Descricao Like "Lateral esqueda - Principal" And veic.IdVeiculo = BuscaIdVeiculoInt.First
                                               Select veic.ImagemColetado, veic.IdVeiculo

                If BuscaImagemLatEsqVeiculo.Count > 0 Then

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemLatEsqVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = (((pdfPage.Width.Point)) / 2) + 175
                    Dim Pt1_Frontal As Double = linha + 70
                    Dim Pt2_Frontal As Double = 110
                    Dim Pt3_Frontal As Double = 75

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoLatEsq = From sol In LqOficina.ImagemVeiculosColetado
                                         Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral esquerda - Avaliacao"
                                         Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarLatEsq = From sol In LqOficina.ImagemVeiculosColetado
                                                     Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral esquerda - Complementar"
                                                     Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoLatEsq.Count + buscaSolucaoComplementarLatEsq.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 75

                If buscaSolucaoLatEsq.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoLatEsq.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoComplementarLatEsq.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementarLatEsq.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoLatEsq.Count = 0 And buscaSolucaoComplementarLatEsq.Count = 0 Then

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    If linha + 175 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If

                Dim imgCat04 As Image = My.Resources.VLatDir
                Dim strmCat04 As MemoryStream = New MemoryStream()
                imgCat04.Save(strmCat04, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat04 As XImage = XImage.FromStream(strmCat04)

                Dim Pt0_Cat04 As Double = MargemEsq + 10
                Dim Pt1_Cat04 As Double = linha + 20
                Dim Pt2_Cat04 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat04 As Double = 100

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat04, Pt0_Cat04, Pt1_Cat04, Pt2_Cat04, Pt3_Cat04)

                Dim BuscaImagemLatDirVeiculo = From veic In LqOficina.ImagemVeiculosColetado
                                               Where veic.Descricao Like "Lateral direita - Principal" And veic.IdVeiculo = BuscaIdVeiculoInt.First
                                               Select veic.ImagemColetado, veic.IdVeiculo

                If BuscaImagemLatDirVeiculo.Count > 0 Then
                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = BuscaImagemLatDirVeiculo.First.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = (((pdfPage.Width.Point)) / 2) + 175
                    Dim Pt1_Frontal As Double = linha + 70
                    Dim Pt2_Frontal As Double = 110
                    Dim Pt3_Frontal As Double = 75

                    graph.DrawRectangle(PincelItemFoto, New XRect(Pt0_Frontal - 2, Pt1_Frontal - 2, Pt2_Frontal, Pt3_Frontal))
                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)

                End If

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoLatDir = From sol In LqOficina.ImagemVeiculosColetado
                                         Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral direita - Avaliacao"
                                         Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarLatDir = From sol In LqOficina.ImagemVeiculosColetado
                                                     Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Lateral direita - Complementar"
                                                     Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoLatDir.Count + buscaSolucaoComplementarLatDir.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 75

                If buscaSolucaoComplementarLatEsq.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                If buscaSolucaoLatDir.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoLatDir.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoComplementarLatDir.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementarLatDir.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoLatDir.Count = 0 And buscaSolucaoComplementarLatDir.Count = 0 Then

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    If linha + 175 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If

                Dim imgCat05 As Image = My.Resources.VAcessorios
                Dim strmCat05 As MemoryStream = New MemoryStream()
                imgCat05.Save(strmCat05, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat05 As XImage = XImage.FromStream(strmCat05)

                Dim Pt0_Cat05 As Double = MargemEsq + 10
                Dim Pt1_Cat05 As Double = linha + 5
                Dim Pt2_Cat05 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat05 As Double = 120

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat05, Pt0_Cat05, Pt1_Cat05, Pt2_Cat05, Pt3_Cat05)

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoMecanicas = From sol In LqOficina.ImagemVeiculosColetado
                                            Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Funcionamento - Avaliacao"
                                            Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarMecanica = From sol In LqOficina.ImagemVeiculosColetado
                                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Funcionamento - Complementar"
                                                       Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoMecanicas.Count + buscaSolucaoComplementarMecanica.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 75

                If buscaSolucaoMecanicas.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoMecanicas.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoComplementarMecanica.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementarMecanica.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoMecanicas.Count = 0 And buscaSolucaoComplementarMecanica.Count = 0 Then

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    If linha + 175 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If

                Dim imgCat06 As Image = My.Resources.VInteriorVetor1
                Dim strmCat06 As MemoryStream = New MemoryStream()
                imgCat06.Save(strmCat06, System.Drawing.Imaging.ImageFormat.Png)
                Dim xfotoCat06 As XImage = XImage.FromStream(strmCat06)

                Dim Pt0_Cat06 As Double = MargemEsq + 10
                Dim Pt1_Cat06 As Double = linha + 5
                Dim Pt2_Cat06 As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 20
                Dim Pt3_Cat06 As Double = 120

                'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)

                graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, ((pdfPage.Width.Point - 15) - (MargemEsq)) / 2, 150))
                graph.DrawRectangle(Pincel, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, (pdfPage.Width.Point - 30) / 2, 150))
                graph.DrawImage(xfotoCat06, Pt0_Cat06, Pt1_Cat06, Pt2_Cat06, Pt3_Cat06)

                graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(((pdfPage.Width.Point)) / 2, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopCenter)

                linha += 15
                graph.DrawLine(pen, New XPoint(((pdfPage.Width.Point) / 2) + 15, linha), New XPoint(pdfPage.Width.Point - 30, linha))

                linha += 35

                Dim buscaSolucaoInterior = From sol In LqOficina.ImagemVeiculosColetado
                                           Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Interior - Avaliacao"
                                           Select sol.ImagemColetado, sol.IdImagemColetada

                Dim buscaSolucaoComplementarInterior = From sol In LqOficina.ImagemVeiculosColetado
                                                       Where sol.IdSolicitacao = BuscaImagemFrontalVeiculo.First.IdSolicitacao And sol.Descricao Like "Interior - Complementar"
                                                       Select sol.ImagemColetado, sol.IdImagemColetada

                graph.DrawString("Danos identificados.: " & buscaSolucaoInterior.Count + buscaSolucaoComplementarInterior.Count, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 15

                graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect((((pdfPage.Width.Point)) / 2) + 25, linha, (pdfPage.Width.Point - 30) / 2, linha), XStringFormats.TopLeft)

                linha += 75

                If buscaSolucaoInterior.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoInterior.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoComplementarInterior.Count > 0 Then

                    linha += 105

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 45, 2, linha - 105))

                End If

                For Each row In buscaSolucaoComplementarInterior.ToList

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 39, linha - 10, (pdfPage.Width.Point) - (((MargemEsq + 39) * 2) - -5), 151))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 40, 2, 175))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha + 135, MargemEsq + 40, 2))

                    graph.DrawRectangle(Pincel, New XRect(MargemEsq + 40, linha - 10, (((pdfPage.Width.Point - 15) - (MargemEsq)) / 2) - 40, 150))
                    graph.DrawRectangle(PincelItemFoto, New XRect(((pdfPage.Width.Point)) / 2, linha - 10, ((pdfPage.Width.Point - 30) / 2) - 40, 150))

                    Dim arrImage() As Byte
                    Dim myMS As New System.IO.MemoryStream
                    arrImage = row.ImagemColetado.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    Dim imgFrontal As Image = Image.FromStream(myMS)
                    Dim strmFrontal As MemoryStream = New MemoryStream()
                    imgFrontal.Save(strmFrontal, System.Drawing.Imaging.ImageFormat.Png)
                    Dim xfotoFrontal As XImage = XImage.FromStream(strmFrontal)

                    Dim Pt0_Frontal As Double = ((pdfPage.Width.Point)) / 2 + 55
                    Dim Pt1_Frontal As Double = linha
                    Dim Pt2_Frontal As Double = (((((pdfPage.Width.Point - 15))) / 2) - 2) - 150
                    Dim Pt3_Frontal As Double = 130

                    graph.DrawImage(xfotoFrontal, Pt0_Frontal, Pt1_Frontal, Pt2_Frontal, Pt3_Frontal)


                    graph.DrawString("Detalhes", fontItem, XBrushes.Black, New XRect(MargemEsq + 10, linha, ((pdfPage.Width.Point)) / 2, linha), XStringFormats.TopCenter)

                    linha += 15

                    graph.DrawLine(pen, New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha))

                    linha += 35

                    graph.DrawString("Danos identificados.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Horas de trabalho previstas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 15

                    graph.DrawString("Peças avariadas.: " & 0, fontItem, XBrushes.Black, New XRect(New XPoint(MargemEsq + 70, linha), New XPoint((((pdfPage.Width.Point)) / 2) - 30, linha)), XStringFormats.TopLeft)

                    linha += 75

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    'If linha >= Limite_pagina Then

                    If linha >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    End If

                Next

                If buscaSolucaoInterior.Count = 0 And buscaSolucaoComplementarInterior.Count = 0 Then

                    Dim Limite_pagina As Double = pdfPage.Height.Point - 110

                    If linha + 175 >= Limite_pagina Then

                        linha = pdfPage.Height.Point - 30

                        graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha = 15

                        'pdf.AddPage()

                        pdfPage = pdf.AddPage()

                        graph = XGraphics.FromPdfPage(pdfPage)

                        graph.DrawLine(pen, New XPoint(0, 5), New XPoint(pdfPage.Width.Point, 5))
                        graph.DrawRectangle(Pincel, New XRect(MargemEsq, linha - 10, (pdfPage.Width.Point - 15) - (MargemEsq), 60))

                        'graph.DrawRectangle(XBrushes.WhiteSmoke, New XRect((pdfPage.Width.Point - 115), linha - 7, 97, 55))
                        'graph.DrawImage(xfoto, Pt0, Pt1, Pt2, Pt3)
                        graph.DrawImage(xfotoMcD, Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC)
                        graph.DrawRectangle(PincelBrancoTransp, New XRect(Pt0_MC, Pt1_MC, Pt2_MC, Pt3_MC))

                        'Incluir um  conteúdo no seu documento PDF ( se usar  XStringFormats.Center irá centralizar o conteúdo na página PDF )
                        graph.DrawString("Orçamento.: " & LblNumOrcamento.Text & " versão.: " & LblVersão.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Data do orçamento.: " & LblDataOrcamento.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 15

                        graph.DrawString("Nome do cliente.: " & LblRazãoSocial.Text, font, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 20

                        graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                        linha += 15

                        graph.DrawString("continuação da página " & pdf.PageCount - 1, fontItem, XBrushes.Black, New XRect(MargemEsq + 5, linha, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft)

                        linha += 45

                    Else

                        linha += 30

                    End If

                End If


                'VARRE TODOS OS ENCONTRADOS

                'Finaliza

                linha = pdfPage.Height.Point - 30

                graph.DrawString("página " & pdf.PageCount, fontItem, XBrushes.Black, New XRect(0, linha, pdfPage.Width.Point, linha), XStringFormats.TopCenter)

                graph.DrawLine(pen, New XPoint(0, linha), New XPoint(pdfPage.Width.Point, linha))

                'Salva o documento PDF

                pdf.Save("C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf")

                'MessageBox.Show("Arquivo   " + "C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf" + "   gerado com sucesso.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'abre o arquivo PDF e exibe 

                Process.Start("C:\Iara\Despejo\" & LblNumOrcamento.Text & "_" & LblVersão.Text & ".pdf")

            Else
                MessageBox.Show("O arquivo/diretório de destino não existe...", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            'captura erros
            MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BttDeclinarOrc_Click(sender As Object, e As EventArgs) Handles BttDeclinarOrc.Click

        'declina orçamento online

        Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_fim_orcamento_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamentoVinc=" & LblNumOrcamento.Text & "&DataAprovacao=" & Today.Date.ToShortDateString.Replace("/", "-") & "&HoraAprovacao=" & Now.TimeOfDay.ToString & "&Aprovacao=2"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        'atualiza no banco interno

        LqComercial.AtualizaAprovacaoOrçamento(LblNumOrcamento.Text, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario)

        'fecha esse form

        FrmComercial.DtCotFinal.Rows.Clear()

        FrmComercial.VerificaInicio()

        Me.Close()

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttInsere.PerformClick()

        End If

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub ChTimeline_Click(sender As Object, e As EventArgs) Handles ChTimeline.Click

    End Sub
End Class