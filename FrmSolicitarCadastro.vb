Public Class FrmSolicitarCadastro
    Private Sub TxtPartNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtPartNumber.TextChanged

    End Sub

    Public Sub VerificaText()

        If TxtPartNumber.Text <> "" Or txtdescrição.Text <> "" Then

            BttSalvar.Enabled = True

        ElseIf TxtPartNumber.Text = "" And txtdescrição.Text = "" Then

            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public IdModeloVeiculo As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        If Application.OpenForms.OfType(Of FrmSoluçãoNovoStudio)().Count() > 0 Then

            IdModeloVeiculo = FrmSoluçãoNovoStudio._IdModVeic

            LqOficina.InsereSolicitacaoCadastroPeca(TxtPartNumber.Text, TxtDescrição.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, FrmSoluçãoNovoStudio._IdCategoria, FrmSoluçãoNovoStudio._IdSubCategoria, _IdModelo, _IdVersão, 0, 0, "")

            'busca ultima solicitação

            Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                   Where sol.IdCodCad = 0
                                   Select sol.IdSolicitacaoCadastro
                                   Order By IdSolicitacaoCadastro Descending

            LqOficina.InsereAssociacaoPecaModelo(0, BuscaSolicitação.First, IdModeloVeiculo)

            'insere vinculo ao veiculo

            LqOficina.InsereNovoVinculoProdutoModelo(0, BuscaSolicitação.First, _IdModelo, _IdVersão, LblAnoMod.Text, LblAnoFab.Text, LblMotor.Text, LblPotencia.Text)

            FrmSoluçãoNovoStudio.LstIdProduto.Items.Add("S" & BuscaSolicitação.First)
            FrmSoluçãoNovoStudio.LstSN.Items.Add(TxtPartNumber.Text)
            FrmSoluçãoNovoStudio.CmbProdutos.Items.Add(TxtDescrição.Text)

            FrmSoluçãoNovoStudio.CmbProdutos.SelectedIndex = FrmSoluçãoNovoStudio.CmbProdutos.Items.Count - 1

        Else

            FrmNovoORçamento.CmbCategoria.SelectedItem = FrmNovoORçamento.CmbCategoria.Text
            FrmNovoORçamento.CmbSubCategoria.SelectedItem = FrmNovoORçamento.CmbSubCategoria.Text
            FrmNovoORçamento.CmbSubCategoria.Enabled = False

            IdModeloVeiculo = FrmSoluçãoNovoStudio._IdModVeic

            LqOficina.InsereSolicitacaoCadastroPeca(TxtPartNumber.Text, TxtDescrição.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, FrmNovoORçamento.LstIdCategoria.Items(FrmNovoORçamento.CmbCategoria.SelectedIndex).ToString, FrmNovoORçamento.LstIdSubCategoria.Items(FrmNovoORçamento.CmbSubCategoria.SelectedIndex).ToString, _IdModelo, _IdVersão, 0, 0, "")

            'busca ultima solicitação

            Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                   Where sol.IdCodCad = 0
                                   Select sol.IdSolicitacaoCadastro
                                   Order By IdSolicitacaoCadastro Descending

            LqOficina.InsereAssociacaoPecaModelo(0, BuscaSolicitação.First, IdModeloVeiculo)

            'insere vinculo ao veiculo

            LqOficina.InsereNovoVinculoProdutoModelo(0, BuscaSolicitação.First, _IdModelo, _IdVersão, LblAnoMod.Text, LblAnoFab.Text, LblMotor.Text, LblPotencia.Text)

            'manda informações

            'popula na lista de itens cadastrados

            FrmNovoORçamento.DtProdutos.Rows.Add(False, "S" & BuscaSolicitação.First, TxtDescrição.Text, "", FrmNovoORçamento.CmbCategoria.Text, FrmNovoORçamento.CmbSubCategoria.Text, TxtPartNumber.Text, "R$ 0,00", My.Resources.icons8_menos_16, "0", My.Resources.icons8_mais_16, "0,00%", "R$0,00", "Sol. de cadastro")

            'seleciona o ultimo 

            If FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(0).Value = True Then

                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(0).Value = False
                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(11).Value = FormatPercent(0, NumDigitsAfterDecimal:=2)
                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(9).Value = FormatNumber(0, NumDigitsAfterDecimal:=0)
                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(12).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

            Else

                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(0).Value = True

                'calcula final

                Dim valorUnit As Decimal = FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(7).Value
                Dim Qt As Decimal = FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(9).Value
                Dim Desconto As String = FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(11).Value
                Desconto = Desconto.Replace("%", "")

                Dim Vl_Desconto As Decimal = Desconto

                Qt += 1

                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(9).Value = Qt

                FrmNovoORçamento.DtProdutos.Rows(FrmNovoORçamento.DtProdutos.Rows.Count - 1).Cells(12).Value = FormatCurrency(((valorUnit - (valorUnit * (Vl_Desconto / 100))) * Qt), NumDigitsAfterDecimal:=2)

            End If

            If FrmNovoORçamento.TrResumo.Nodes.Count > 0 Then

                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).Nodes.Clear()

                For Each row As DataGridViewRow In FrmNovoORçamento.DtProdutos.Rows

                    If row.Cells(0).Value = True Then

                        'insere no banco de dados

                        Dim TrProdutos As TreeNode = FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1)

                        TrProdutos.Nodes.Add(row.Cells(1).Value & " - " & row.Cells(2).Value)
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).ForeColor = Color.SlateGray
                        TrProdutos.Nodes(TrProdutos.Nodes.Count - 1).Nodes.Add(FormatCurrency(row.Cells(7).Value, NumDigitsAfterDecimal:=2) & " x " & row.Cells(9).Value & " = " & FormatCurrency(row.Cells(12).Value, NumDigitsAfterDecimal:=2))

                    End If

                Next

                FrmNovoORçamento.TrResumo.Nodes(FrmNovoORçamento.TrResumo.Nodes.Count - 1).ExpandAll()

            End If

        End If

        Me.Close()

    End Sub

    Public _IdVeiculo As Integer
    Public _IdVersão As Integer
    Public _IdModelo As Integer

    Dim LstIdCategoria As New ListBox
    Dim LstIdSubCategoria As New ListBox

    Public _Categoria As String = ""
    Public _SubCategoria As String = ""

    Private Sub FrmSolicitarCadastro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        _IdVeiculo = FrmUsarSolitaçõesCadatroPeça._IdVeiculo

        Dim LqBase As New DtCadastroDataContext

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                             Where cat.IdCategoriaProduto Like "*"
                             Select cat.Descricao, cat.IdCategoriaProduto

        For Each row In BuscaCategoria.ToList

            CmbCategoria.Items.Add(row.Descricao)
            LstIdCategoria.Items.Add(row.IdCategoriaProduto)

        Next

        CmbCategoria.SelectedItem = _Categoria

        If _Categoria <> "" Then

            CmbCategoria.Enabled = False

            Dim IdCat As Integer = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString

            Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                    Where cat.IdCategoria = IdCat
                                    Select cat.Descricao, cat.IdSubCategoria

            For Each row In BuscaSubCategoria.ToList

                CmbSubCategoria.Items.Add(row.Descricao)
                LstIdSubCategoria.Items.Add(row.IdSubCategoria)

            Next

            CmbSubCategoria.SelectedItem = _SubCategoria

            If _SubCategoria <> "" Then

                CmbSubCategoria.Enabled = False

            Else

                CmbSubCategoria.Enabled = True

            End If

        Else

            CmbCategoria.Enabled = True

        End If

        If _IdVeiculo > 0 Then

            'carrega dados do veiculo

            Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                               Where veic.IdVeiculo = _IdVeiculo
                               Select veic.IdVersao, veic.IdModelo, veic.AnoFab, veic.AnoMod, veic.IdFabricante

            Dim BuscaFabricante = From ver In LqOficina.FabricantesVeiculo
                                  Where ver.Idfabricante = BuscaVeiculo.First.IdFabricante
                                  Select ver.Fabricante

            LblFabricante.Text = BuscaFabricante.First

            _IdVersão = BuscaVeiculo.First.IdVersao

            Dim BuscaVersão = From ver In LqOficina.VersaoModelos
                              Where ver.Idversao = _IdVersão
                              Select ver.Versao, ver.Potencia, ver.Cilindrada

            LblVersão.Text = BuscaVersão.First.Versao

            _IdModelo = BuscaVeiculo.First.IdModelo

            Dim BuscaModelo = From ver In LqOficina.Modelos
                              Where ver.IdModelo = _IdModelo
                              Select ver.Modelo

            LblModelo.Text = BuscaModelo.First

            LblAnoFab.Text = BuscaVeiculo.First.AnoFab
            LblAnoMod.Text = BuscaVeiculo.First.AnoMod
            LblMotor.Text = BuscaVersão.First.Potencia
            LblPotencia.Text = BuscaVersão.First.Cilindrada

        End If

    End Sub

    Private Sub CmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoria.SelectedIndexChanged

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim IdCat As Integer = LstIdCategoria.Items(CmbCategoria.SelectedIndex).ToString

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = IdCat
                                Select cat.Descricao, cat.IdSubCategoria

        For Each row In BuscaSubCategoria.ToList

            CmbSubCategoria.Items.Add(row.Descricao)
            LstIdSubCategoria.Items.Add(row.IdSubCategoria)

        Next

    End Sub
End Class