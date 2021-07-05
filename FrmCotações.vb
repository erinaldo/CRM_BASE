Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Public Class FrmCotações
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub DtItensBDD_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensBDD.CellContentClick

    End Sub

    Dim LqEstoqueOnLine As New LqEstoqueIaraDataContext

    Private Sub DtItensBDD_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensBDD.CellClick

        If DtItensBDD.Enabled = True Then

            Me.Cursor = Cursors.WaitCursor

            If DtItensBDD.Enabled = True Then

                TempoPIng = 0
                Me.Cursor = Cursors.AppStarting

                '       

                Dim ValorPartNumber As String = DtItensBDD.SelectedCells(6).Value.ToString
                Dim ModeloVeiculoEncontrado As String = DtItensBDD.SelectedCells(4).Value.ToString

                Dim baseUrl As String = "http://www.iarasoftware.com.br/ExibebCatalogo_OnLine.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                    & "&Modelo=" & ModeloVeiculoEncontrado

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.CatalogoOnLine))(content)

                DtBddIARA.Rows.Clear()

                Dim Selecionados As Integer = 0

                For Each row In read.ToList

                    'If row.PartNumber <> Nothing Then

                    If row.PartNumber = ValorPartNumber Then

                        '

                        Dim ValorUnitarioEncontrado As String = row.ValorUnit.ToString.Replace(".", ",")

                        If ValorUnitarioEncontrado = 0 Then
                            '
                            ValorUnitarioEncontrado = "Sob consulta"

                            DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, "100,00%", row.PartNumber, ValorUnitarioEncontrado, row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                            Timer1.Enabled = True

                        Else

                            DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, "100,00%", row.PartNumber, FormatCurrency(ValorUnitarioEncontrado, NumDigitsAfterDecimal:=2), row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                        End If

                        'procura a quantidade de itens cotados para este forneedor

                        Dim C0 As Integer = 0
                        Dim C1 As Integer = 0

                        If C0 > 0 Then

                            DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(8).Value = C0

                            DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(9).Value = ImageList1.Images(4)

                            Selecionados += 1

                        End If

                        DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(8).Value = C1

                    Else

                        'verifica semelhança das descricoes

                        Dim str As String = DtItensBDD.SelectedCells(2).Value.ToString.ToLower
                        Dim separador As String = " "
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        Dim LstPalavraRejeitada As New ListBox

                        LstPalavraRejeitada.Items.Add("(Item")
                        LstPalavraRejeitada.Items.Add("não")
                        LstPalavraRejeitada.Items.Add("cadastrado)")

                        For Each palavra In palavras

                            If Not LstPalavraRejeitada.Items.Contains(palavra) Then
                                LstPalavras.Items.Add(palavra)
                            End If

                        Next

                        'Busca associação

                        Dim LqOficina As New LqOficinaDataContext
                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        Dim LstItensModelo As New ListBox

                        Dim ModeloString As String = ""

                        If DtItensBDD.SelectedCells(1).Value.ToString.StartsWith("S") Then

                            Dim CodS As String = DtItensBDD.SelectedCells(1).Value.ToString
                            CodS = CodS.Remove(0, 2)

                            Dim strModelo As String = row.Descricao.ToString.ToLower
                            Dim separadorModelo As String = " "
                            Dim palavrasModelo As String() = strModelo.Split(separadorModelo)
                            Dim palavraModelo As String

                            Dim BuscaAss = From ass In LqOficina.AssociaçãoPeçaModelo
                                           Where ass.IdSolicitaçãoCad = CodS
                                           Select ass.IdModeloVeic

                            If BuscaAss.Count > 0 Then

                                Dim BuscaModelos = From mode In LqOficina.Modelos
                                                   Where mode.IdModelo = BuscaAss.First
                                                   Select mode.IdFabricante, mode.Modelo

                                'Busca FAbricante

                                LstItensModelo.Items.Add(BuscaModelos.First.Modelo)
                                ModeloString = BuscaModelos.First.Modelo

                            End If

                        Else

                            Dim CodS As String = DtItensBDD.SelectedCells(1).Value.ToString

                            Dim BuscaAss = From ass In LqOficina.AssociaçãoPeçaModelo
                                           Where ass.IdCodProd = CodS
                                           Select ass.IdModeloVeic

                            If BuscaAss.Count > 0 Then

                                Dim BuscaModelos = From mode In LqOficina.Modelos
                                                   Where mode.IdModelo = BuscaAss.First
                                                   Select mode.IdFabricante, mode.Modelo

                                'Busca FAbricante

                                LstItensModelo.Items.Add(BuscaModelos.First.Modelo)
                                ModeloString = BuscaModelos.First.Modelo

                            End If

                        End If

                        'Compara

                        Dim str0 As String = row.Descricao.ToString.ToLower
                        Dim separador0 As String = " "
                        Dim palavras0 As String() = str0.Split(separador0)
                        Dim LstPalavras0 As New ListBox
                        Dim palavra0 As String

                        For Each palavra0 In palavras0
                            LstPalavras0.Items.Add(palavra0)
                        Next

                        'varre a lista

                        Dim C As Decimal = 0

                        Dim LstPalavraInserido As New ListBox

                        For Each linhas In LstPalavras.Items

                            If LstPalavras0.Items.Contains(linhas.ToString) Then

                                If Not LstItensModelo.Items.Contains(linhas.ToString) Then

                                    If Not LstPalavraInserido.Items.Contains(linhas.ToString) Then

                                        C += 1
                                        LstPalavraInserido.Items.Add(linhas.ToString)

                                    End If

                                Else

                                    If Not LstPalavraInserido.Items.Contains(linhas.ToString) Then

                                        C += 1
                                        LstPalavraInserido.Items.Add(linhas.ToString)

                                    End If

                                End If

                            End If

                        Next

                        If C > 0 Then

                            If (((100 * C) / LstPalavras0.Items.Count)) > 69 Then

                                Dim ValorUnitarioEncontrado As String = row.ValorUnit.ToString.Replace(".", ",")

                                If ValorUnitarioEncontrado = 0 Then
                                    '
                                    ValorUnitarioEncontrado = "Sob consulta"

                                    DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, FormatPercent(((100 * C) / LstPalavras0.Items.Count) / 100), row.PartNumber, ValorUnitarioEncontrado, row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                                    Timer1.Enabled = True

                                Else

                                    DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, FormatPercent(((100 * C) / LstPalavras0.Items.Count) / 100), row.PartNumber, FormatCurrency(ValorUnitarioEncontrado, NumDigitsAfterDecimal:=2), row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                                End If

                            End If

                        End If

                    End If


                Next

                If DtBddIARA.Rows.Count > 0 Then

                    LblOcorrencias.Text = DtBddIARA.Rows.Count & " correspondências encontradas."

                ElseIf DtBddIARA.Rows.Count = 0 Then

                    LblOcorrencias.Text = "Nenhuma correspondência encontrada."

                    'TabControl1.SelectedIndex = 1

                End If


            End If

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Dim LstQtSolicitada As New ListBox

    Public Sub CArregaDash()

        Me.Cursor = Cursors.AppStarting

        'popula fornecedores

        Dim LstIdfornecedoresPopulados As New ListBox

        Dim LstfornecedoresPopulados As New ListBox
        Dim LstValoresPopulados As New ListBox
        Dim LstValoresPopuladosPrazo As New ListBox

        Dim LstMenorPreço As New ListBox
        Dim LstMenorPrazo As New ListBox

        Dim MenorPreço As Decimal = 1000000000000000
        Dim MenorPrazo As Decimal = 1000000000000000

        'preenche concorrencia

        Dim _indexMenorPreço As Integer = 0
        Dim _indexMenorPrazo As Integer = 0

        CmbFornecedores.Items.Clear()
        _IdFornecedores.Items.Clear()
        LstQtSolicitada.Items.Clear()

        For Each row1 As DataGridViewRow In DtResumo.Rows

            'se codigo for externo
            Dim _indexRow As Integer = 0

            Try

                _indexRow = DtCotFinal.SelectedCells(1).RowIndex

            Catch ex As Exception
                _indexRow = 0
            End Try

            If Not row1.Cells(0).Value.ToString.StartsWith("I_") Then
                If DtCotFinal.Rows(_indexRow).Cells(1).Value.ToString = row1.Cells(3).Value.ToString Then

                    'Busca

                    Dim _NomeFornecedor As String = ""

                    For Each it As DataGridViewRow In DtFornecedores.Rows

                        If "I_" & it.Cells(0).Value.ToString = row1.Cells(0).Value.ToString Then

                            _NomeFornecedor = it.Cells(2).Value.ToString

                        End If

                    Next

                    If _NomeFornecedor = "" Then
                        'insere o nome
                        _NomeFornecedor = row1.Cells(1).Value.ToString
                    End If

                    LstfornecedoresPopulados.Items.Add(_NomeFornecedor)
                    CmbFornecedores.Items.Add(_NomeFornecedor)
                    LstIdfornecedoresPopulados.Items.Add(row1.Cells(0).Value)
                    _IdFornecedores.Items.Add(row1.Cells(0).Value)
                    LstValoresPopulados.Items.Add(FormatCurrency(row1.Cells(6).Value, NumDigitsAfterDecimal:=2))
                    LstValoresPopuladosPrazo.Items.Add(row1.Cells(7).Value)
                    LstQtSolicitada.Items.Add(row1.Cells(8).Value)

                    If MenorPreço > row1.Cells(6).Value Then

                        MenorPreço = row1.Cells(6).Value

                        'limpa lista

                        LstMenorPreço.Items.Clear()

                        For i As Integer = 0 To LstfornecedoresPopulados.Items.Count - 2

                            LstMenorPreço.Items.Add(0)

                        Next

                        LstMenorPreço.Items.Add(MenorPreço)
                        _indexMenorPreço = LstMenorPreço.Items.Count - 1

                    ElseIf MenorPreço <= row1.Cells(6).Value Then

                        LstMenorPreço.Items.Add(0)

                    End If

                    'verifica menor prazo

                    Dim Prazo As Integer = row1.Cells(7).Value

                    If MenorPrazo > Prazo Then

                        MenorPrazo = Prazo

                        'limpa lista

                        LstMenorPrazo.Items.Clear()

                        For i As Integer = 0 To LstfornecedoresPopulados.Items.Count - 2

                            LstMenorPrazo.Items.Add(0)

                        Next

                        LstMenorPrazo.Items.Add(MenorPrazo)
                        _indexMenorPrazo = LstMenorPrazo.Items.Count - 1

                    ElseIf MenorPrazo <= Prazo Then

                        LstMenorPrazo.Items.Add(0)
                        _indexMenorPrazo = LstMenorPrazo.Items.Count - 1

                    End If

                End If
            Else
                If DtCotFinal.Rows(_indexRow).Cells(1).Value.ToString = row1.Cells(2).Value.ToString Then

                    'Busca

                    Dim _NomeFornecedor As String = ""

                    For Each it As DataGridViewRow In DtFornecedores.Rows

                        If "I_" & it.Cells(0).Value.ToString = row1.Cells(0).Value.ToString Then

                            _NomeFornecedor = it.Cells(2).Value.ToString

                        End If

                    Next

                    If _NomeFornecedor = "" Then
                        'insere o nome
                        _NomeFornecedor = row1.Cells(1).Value.ToString
                    End If

                    LstfornecedoresPopulados.Items.Add(_NomeFornecedor)
                    CmbFornecedores.Items.Add(_NomeFornecedor)
                    LstIdfornecedoresPopulados.Items.Add(row1.Cells(0).Value)
                    _IdFornecedores.Items.Add(row1.Cells(0).Value)
                    LstValoresPopulados.Items.Add(FormatCurrency(row1.Cells(6).Value, NumDigitsAfterDecimal:=2))
                    LstValoresPopuladosPrazo.Items.Add(row1.Cells(7).Value)
                    LstQtSolicitada.Items.Add(row1.Cells(8).Value)

                    If MenorPreço > row1.Cells(6).Value Then

                        MenorPreço = row1.Cells(6).Value

                        'limpa lista

                        LstMenorPreço.Items.Clear()

                        For i As Integer = 0 To LstfornecedoresPopulados.Items.Count - 2

                            LstMenorPreço.Items.Add(0)

                        Next

                        LstMenorPreço.Items.Add(MenorPreço)
                        _indexMenorPreço = LstMenorPreço.Items.Count - 1

                    ElseIf MenorPreço <= row1.Cells(6).Value Then

                        LstMenorPreço.Items.Add(0)

                    End If

                    'verifica menor prazo

                    Dim Prazo As Integer = row1.Cells(7).Value

                    If MenorPrazo > Prazo Then

                        MenorPrazo = Prazo

                        'limpa lista

                        LstMenorPrazo.Items.Clear()

                        For i As Integer = 0 To LstfornecedoresPopulados.Items.Count - 2

                            LstMenorPrazo.Items.Add(0)

                        Next

                        LstMenorPrazo.Items.Add(MenorPrazo)
                        _indexMenorPrazo = LstMenorPrazo.Items.Count - 1

                    ElseIf MenorPrazo <= Prazo Then

                        LstMenorPrazo.Items.Add(0)
                        _indexMenorPrazo = LstMenorPrazo.Items.Count - 1

                    End If

                End If

            End If

        Next

        ChConcorrencia.Series(0).Points.DataBindXY(LstfornecedoresPopulados.Items, LstValoresPopulados.Items)
        ChConcorrencia.Series(1).Points.DataBindXY(LstfornecedoresPopulados.Items, LstMenorPreço.Items)


        ChPrazo.Series(0).Points.DataBindXY(LstfornecedoresPopulados.Items, LstValoresPopuladosPrazo.Items)
        ChPrazo.Series(1).Points.DataBindXY(LstfornecedoresPopulados.Items, LstMenorPrazo.Items)

        If CmbFornecedores.Items.Count > 0 Then
            CmbFornecedores.SelectedIndex = _indexMenorPreço
        Else

            LblValorUnitario.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0

        End If

        Dim MesesAtras As Date = Today.Date.AddYears(-1)

        Dim LstMesesFluxo As New ListBox
        Dim LstMesesEntradas As New ListBox

        While MesesAtras < Today.Date

            LstMesesFluxo.Items.Add(MesesAtras.Month & " / " & MesesAtras.Year)

            MesesAtras = MesesAtras.AddMonths(1)

        End While

        'busca financeiro

        'For i As Integer = 0 To LstMesesFluxo.Items.Count - 1

        Dim VlTeste As Decimal = 500
        Dim VlEstoque As Decimal = 500 * 14
        Dim Soma As Decimal = 0

        LstMesesEntradas.Items.Add(Soma + (0 * VlTeste))
        Soma += (0 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (0 * VlTeste))
        Soma += (0 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (2 * VlTeste))
        Soma += (2 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (0 * VlTeste))
        Soma += (0 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (1 * VlTeste))
        Soma += (1 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (5 * VlTeste))
        Soma += (5 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (0 * VlTeste))
        Soma += (0 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (1 * VlTeste))
        Soma += (1 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (1 * VlTeste))
        Soma += (1 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (3 * VlTeste))
        Soma += (3 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (1 * VlTeste))
        Soma += (1 * VlTeste)
        LstMesesEntradas.Items.Add(Soma + (0 * VlTeste))
        Soma += (0 * VlTeste)

        Dim LstSaidaMesesEntradas As New ListBox

        LstSaidaMesesEntradas.Items.Add(VlEstoque - (0 * VlTeste))
        VlEstoque -= (0 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (0 * VlTeste))
        VlEstoque -= (0 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (2 * VlTeste))
        VlEstoque -= (2 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (0 * VlTeste))
        VlEstoque -= (0 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (1 * VlTeste))
        VlEstoque -= (1 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (5 * VlTeste))
        VlEstoque -= (5 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (0 * VlTeste))
        VlEstoque -= (0 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (1 * VlTeste))
        VlEstoque -= (1 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (1 * VlTeste))
        VlEstoque -= (1 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (3 * VlTeste))
        VlEstoque -= (3 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (1 * VlTeste))
        VlEstoque -= (1 * VlTeste)
        LstSaidaMesesEntradas.Items.Add(VlEstoque - (0 * VlTeste))
        VlEstoque -= (0 * VlTeste)

        Dim LstRadar As New ListBox

        Dim LstDataCompra As New ListBox

        Try

            'desenha radar

            If Not DtCotFinal.SelectedCells(1).Value.ToString.StartsWith("S") Then

                Dim BuscaUltimos5Compras = From fin In LqFinanceiro.SolicitacoesCompraFinanceiro
                                           Where fin.IdProduto = DtCotFinal.SelectedCells(0).Value
                                           Select fin.NF, fin.DataPg

                For Each row In BuscaUltimos5Compras.ToList

                    Dim LqEstoque As New LqEstoqueLocalDataContext
                    LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                    Dim BuscaArm = From arm In LqEstoque.Armazenagem
                                   Where arm.NF Like row.NF
                                   Select arm.ValorUnit, arm.DataEntrada

                    LstRadar.Items.Add(BuscaArm.First.ValorUnit)
                    LstDataCompra.Items.Add(BuscaArm.First.DataEntrada)

                Next

                While LstRadar.Items.Count < 5
                    LstRadar.Items.Add("0,00")
                    LstDataCompra.Items.Add("00-00")
                End While

            Else

                LstRadar.Items.Add("0,00")
                LstRadar.Items.Add("0,00")
                LstRadar.Items.Add("0,00")
                LstRadar.Items.Add("0,00")
                LstRadar.Items.Add("0,00")

                LstDataCompra.Items.Add("00-00")
                LstDataCompra.Items.Add("00-00")
                LstDataCompra.Items.Add("00-00")
                LstDataCompra.Items.Add("00-00")
                LstDataCompra.Items.Add("00-00")

            End If

        Catch ex As Exception

            LstRadar.Items.Add("0,00")
            LstRadar.Items.Add("0,00")
            LstRadar.Items.Add("0,00")
            LstRadar.Items.Add("0,00")
            LstRadar.Items.Add("0,00")

            LstDataCompra.Items.Add("00-00")
            LstDataCompra.Items.Add("00-00")
            LstDataCompra.Items.Add("00-00")
            LstDataCompra.Items.Add("00-00")
            LstDataCompra.Items.Add("00-00")

        End Try

        ChAnalise.Series(0).Points.DataBindXY(LstDataCompra.Items, LstRadar.Items)

        DtItensBDD.Enabled = True

        Me.Cursor = Cursors.Arrow

    End Sub
    Private Sub DtBddIARA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellContentClick

        If DtBddIARA.Columns(e.ColumnIndex).Name = "ClmSelecionado" Then

            'procura no resumo

            Dim Cont As Integer = 0

            For Each row As DataGridViewRow In DtResumo.Rows

                If row.Cells(2).Value = DtBddIARA.Rows(e.RowIndex).Cells(2).Value Then

                    Cont += 1

                End If

            Next

            If Cont = 0 Then

                'verifica se o preó é sob consulta

                If DtBddIARA.Rows(e.RowIndex).Cells(6).Value <> "Sob consulta" And DtBddIARA.Rows(e.RowIndex).Cells(6).Value <> "Cotação solicitada" Then

                    Dim TaxaFornec As Decimal = 0.0099
                    Dim VlrVenda As Decimal = DtBddIARA.Rows(e.RowIndex).Cells(6).Value
                    Dim Comissao As Decimal = VlrVenda * TaxaFornec

                    DtBddIARA.Rows(e.RowIndex).Cells(9).Value = ImageList1.Images(4)

                    DtResumo.Rows.Add(DtBddIARA.Rows(e.RowIndex).Cells(11).Value, DtBddIARA.Rows(e.RowIndex).Cells(1).Value, DtBddIARA.Rows(e.RowIndex).Cells(2).Value, DtItensBDD.SelectedCells(1).Value, DtBddIARA.Rows(e.RowIndex).Cells(3).Value, DtBddIARA.Rows(e.RowIndex).Cells(5).Value, DtBddIARA.Rows(e.RowIndex).Cells(6).Value, DtBddIARA.Rows(e.RowIndex).Cells(7).Value, DtBddIARA.Rows(e.RowIndex).Cells(12).Value, Comissao)

                    'procura a quantidade de itens cotados para este forneedor

                    Dim C As Integer

                    For Each row As DataGridViewRow In DtResumo.Rows

                        If row.Cells(0).Value = DtBddIARA.Rows(e.RowIndex).Cells(2).Value Then

                            C += 1

                        End If

                    Next

                    DtBddIARA.Rows(e.RowIndex).Cells(8).Value = C

                    'varre iara e compara com resumo

                    Dim C1 As Integer

                    For Each row As DataGridViewRow In DtBddIARA.Rows

                        For Each row1 As DataGridViewRow In DtResumo.Rows

                            If row1.Cells(0).Value = row.Cells(1).Value Then

                                C1 += 1

                            End If

                        Next

                    Next

                Else

                    'solicita cotação do produto

                    DtBddIARA.Rows(e.RowIndex).Cells(6).Value = "Cotação solicitada"

                    Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_solicitacao_cotacao.php?ChaveOficina=" & DtBddIARA.Rows(e.RowIndex).Cells(11).Value & "&IdItem=" & DtBddIARA.Rows(e.RowIndex).Cells(2).Value
                    Dim sync = New WebClient()
                    Dim content_item = sync.DownloadString(baseUrl_item)

                    'Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ItemOrcamentos))(content_item)

                    Timer1.Enabled = True

                End If

            Else

                DtBddIARA.Rows(e.RowIndex).Cells(9).Value = ImageList1.Images(5)

                Dim LstRemover As New ListBox

                For Each row As DataGridViewRow In DtResumo.Rows

                    If row.Cells(2).Value = DtBddIARA.Rows(e.RowIndex).Cells(2).Value Then

                        LstRemover.Items.Add(row.Index)

                    End If

                Next

                For Each row In LstRemover.Items

                    Dim DtSel As DataGridViewRow = DtResumo.Rows(row.ToString)

                    DtResumo.Rows.Remove(DtSel)

                Next

                'procura a quantidade de itens cotados para este forneedor

                Dim C As Integer

                For Each row As DataGridViewRow In DtResumo.Rows

                    If row.Cells(0).Value = DtBddIARA.Rows(e.RowIndex).Cells(1).Value Then

                        C += 1

                    End If

                Next

                DtBddIARA.Rows(e.RowIndex).Cells(8).Value = C

            End If

            'insere no resumo

            Dim ContCot As Integer

            For Each row As DataGridViewRow In DtResumo.Rows

                If row.Cells(2).Value = DtItensBDD.Rows(DtItensBDD.SelectedCells(0).RowIndex).Cells(1).Value Then

                    ContCot += 1

                End If

            Next

            If ContCot > 0 Then

                DtItensBDD.Rows(DtItensBDD.SelectedCells(0).RowIndex).Cells(0).Value = ImageList1.Images(1)

                VerificaPossibilidadeAnalise()

            Else

                DtItensBDD.Rows(DtItensBDD.SelectedCells(0).RowIndex).Cells(0).Value = ImageList1.Images(0)

            End If

        End If

    End Sub

    Public Sub VerificaPossibilidadeAnalise()

        Dim C_Sim As Integer = 0

        Dim LstFind As New ListBox

        For Each row As DataGridViewRow In DtResumo.Rows

            For Each row1 As DataGridViewRow In DtItensBDD.Rows

                If row.Cells(2).Value = row1.Cells(1).Value Then

                    If Not LstFind.Items.Contains(row.Cells(2).Value) Then

                        LstFind.Items.Add(row.Cells(2).Value)

                        C_Sim += 1

                    End If

                End If

            Next

        Next

        If C_Sim = DtItensBDD.Rows.Count Then

            _Analisar = True

        Else

            _Analisar = False

        End If

    End Sub

    Private Sub DtBddIARA_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBddIARA.CellClick

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

        For Each row As DataGridViewRow In DtBddIARA.Rows

            'seleciona toodos os itens

            Dim LstRemover As New ListBox

            For Each row1 As DataGridViewRow In DtResumo.Rows

                If row1.Cells(1).Value = row.Cells(2).Value Then

                    LstRemover.Items.Add(row1.Index)

                End If

            Next

            For Each row1 In LstRemover.Items

                Dim DtSel As DataGridViewRow = DtResumo.Rows(row1.ToString)

                DtResumo.Rows.Remove(DtSel)

            Next

            row.Cells(9).Value = ImageList1.Images(4)

            DtResumo.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, DtItensBDD.SelectedCells(1).Value, DtItensBDD.SelectedCells(2).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, 0)

        Next

        DtItensBDD.Rows(DtItensBDD.SelectedCells(0).RowIndex).Cells(0).Value = ImageList1.Images(1)

        VerificaPossibilidadeAnalise()

    End Sub

    Public _Analisar As Boolean = False

    Public Sub SelecionatodasOpções()

    End Sub

    Private Sub ChConcorrencia_Click(sender As Object, e As EventArgs) Handles ChConcorrencia.Click

    End Sub

    Public _IdFornecedores As New ListBox

    Private Sub ChConcorrencia_MouseDown(sender As Object, e As MouseEventArgs) Handles ChConcorrencia.MouseDown

    End Sub

    Private Sub ChConcorrencia_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ChConcorrencia.MouseDoubleClick

    End Sub

    Dim ValorEncontrado As Decimal
    Dim IdEncontrado As String

    Private Sub CmbFornecedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFornecedores.SelectedIndexChanged

        If CmbFornecedores.Items.Count > 0 Then
            'preenche concorrencia

            DtCardapio.Rows.Clear()

            For Each row As DataGridViewRow In DtResumo.Rows

                If Not row.Cells(0).Value.ToString.StartsWith("I_") Then
                    If row.Cells(0).Value.ToString = _IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString And row.Cells(3).Value.ToString = DtCotFinal.SelectedCells(1).Value.ToString Then

                        LblQtSolicitada.Text = row.Cells(8).Value
                        'NmQtSolicitada.Value = row.Cells(7).Value

                        Dim ValorUnit As Decimal = row.Cells(6).Value

                        LblResultado.Text = FormatCurrency(ValorUnit * row.Cells(8).Value, NumDigitsAfterDecimal:=2)
                        LblValorUnitario.Text = FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2)

                        BttSolicitar.Enabled = True

                        If row.DefaultCellStyle.BackColor = Color.MintCream Then
                            DtCardapio.Rows.Add(row.Cells(3).Value, row.Cells(4).Value, row.Cells(6).Value)

                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.Font = New Font("Calibri", 10)
                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.ForeColor = Color.DarkGreen

                        Else
                            DtCardapio.Rows.Add(row.Cells(3).Value, row.Cells(4).Value, row.Cells(6).Value)

                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.Font = New Font("Calibri", 8.25)
                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.ForeColor = Color.DarkSlateGray

                        End If

                    ElseIf row.Cells(0).Value.ToString = _IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString And row.Cells(1).Value.ToString = DtCotFinal.SelectedCells(1).Value.ToString Then

                        LblQtSolicitada.Text = row.Cells(8).Value
                        'NmQtSolicitada.Value = row.Cells(7).Value

                        ValorEncontrado = row.Cells(6).Value

                        Dim ValorUnit As Decimal = row.Cells(6).Value

                        LblResultado.Text = FormatCurrency(ValorUnit * row.Cells(8).Value, NumDigitsAfterDecimal:=2)
                        BttSolicitar.Enabled = True

                        Dim _IdCorrigido As String = row.Cells(3).Value

                        If _IdCorrigido.StartsWith("S_") Then

                            _IdCorrigido = _IdCorrigido.Remove(0, 2)

                        End If

                        IdEncontrado = row.Cells(2).Value

                    End If
                Else
                    If row.Cells(0).Value.ToString = _IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString And row.Cells(2).Value.ToString = DtCotFinal.SelectedCells(1).Value.ToString Then

                        LblQtSolicitada.Text = row.Cells(8).Value
                        'NmQtSolicitada.Value = row.Cells(7).Value

                        Dim ValorUnit As Decimal = row.Cells(6).Value

                        LblResultado.Text = FormatCurrency(ValorUnit * row.Cells(8).Value, NumDigitsAfterDecimal:=2)
                        LblValorUnitario.Text = FormatCurrency(ValorUnit, NumDigitsAfterDecimal:=2)

                        BttSolicitar.Enabled = True

                        If row.DefaultCellStyle.BackColor = Color.MintCream Then
                            DtCardapio.Rows.Add(row.Cells(3).Value, row.Cells(4).Value, row.Cells(6).Value)

                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.Font = New Font("Calibri", 10)
                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.ForeColor = Color.DarkGreen

                        Else
                            DtCardapio.Rows.Add(row.Cells(3).Value, row.Cells(4).Value, row.Cells(6).Value)

                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.Font = New Font("Calibri", 8.25)
                            DtCardapio.Rows(DtCardapio.Rows.Count - 1).Cells(2).Style.ForeColor = Color.DarkSlateGray

                        End If

                    ElseIf row.Cells(0).Value.ToString = _IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString And row.Cells(1).Value.ToString = DtCotFinal.SelectedCells(1).Value.ToString Then

                        LblQtSolicitada.Text = row.Cells(8).Value
                        'NmQtSolicitada.Value = row.Cells(7).Value

                        ValorEncontrado = row.Cells(6).Value

                        Dim ValorUnit As Decimal = row.Cells(6).Value

                        LblResultado.Text = FormatCurrency(ValorUnit * row.Cells(8).Value, NumDigitsAfterDecimal:=2)
                        BttSolicitar.Enabled = True

                        Dim _IdCorrigido As String = row.Cells(3).Value

                        If _IdCorrigido.StartsWith("S_") Then

                            _IdCorrigido = _IdCorrigido.Remove(0, 2)

                        End If

                        IdEncontrado = row.Cells(2).Value

                    End If

                End If

            Next

            'carrega sacola

            Dim C As Integer
            Dim Total As Decimal

            For Each row As DataGridViewRow In DtResumoSolicitação.Rows

                If row.Cells(0).Value.ToString = _IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString Then

                    C += 1

                    Total += row.Cells(7).Value

                End If

            Next


            'retorna o valor da cotação para o fornecedor

            For Each row As DataGridViewRow In DtResumo.Rows

                If row.Cells(0).Value.ToString = _IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString Then

                    If row.Cells(3).Value.ToString = DtCotFinal.SelectedCells(1).Value.ToString Then

                        LblValorUnitario.Text = FormatCurrency(row.Cells(6).Value, NumDigitsAfterDecimal:=2)
                        LblQtSolicitada.Text = FormatNumber(row.Cells(8).Value, NumDigitsAfterDecimal:=2)

                        Dim ValorUnit As Decimal = row.Cells(6).Value
                        Dim Qt As Decimal = row.Cells(8).Value

                        LblResultado.Text = FormatCurrency(ValorUnit * Qt, NumDigitsAfterDecimal:=2)

                    End If

                End If

            Next

            LblISacola.Text = C

        End If

    End Sub

    Private Sub ChFlutuação_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NmQtSolicitada_ValueChanged(sender As Object, e As EventArgs) Handles NmQtSolicitada.ValueChanged

    End Sub

    Dim IdFornecedor01 As String = ""
    Dim IdFornecedor02 As String = ""
    Dim IdFornecedor03 As String = ""

    Private Sub BttSolicitar_Click(sender As Object, e As EventArgs) Handles BttSolicitar.Click

        Me.Cursor = Cursors.WaitCursor

        IdFornecedor01 = ""
        IdFornecedor02 = ""
        IdFornecedor03 = ""

        PnnSolicitação01.Visible = False
        PnnSolicitação02.Visible = False
        PnnSolicitação03.Visible = False

        ValorEncontrado = LblValorUnitario.Text
        DtResumoSolicitação.Rows.Add(_IdFornecedores.Items(CmbFornecedores.SelectedIndex).ToString, IdEncontrado, DtCotFinal.SelectedCells(1).Value, False, DtCotFinal.SelectedCells(2).Value, ValorEncontrado, LblQtSolicitada.Text, Val(LblQtSolicitada.Text) * ValorEncontrado, CmbFornecedores.Text)

        'preenche até 3 fornecedores

        Dim LstIdInserido As New ListBox

        For Each row As DataGridViewRow In DtResumoSolicitação.Rows

            If row.Cells(3).Value = False Then

                If IdFornecedor01 = "" Then

                    If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                        LstIdInserido.Items.Add(row.Cells(0).Value)

                        'popula o primeiro quadro

                        IdFornecedor01 = row.Cells(0).Value

                        LblSolicitação01.Text = row.Cells(8).Value

                        DtSolicitação01.Rows.Clear()

                        Dim Total As Decimal = 0

                        For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                            If row1.Cells(0).Value = row.Cells(0).Value Then

                                DtSolicitação01.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6), row1.Cells(1).Value)

                                Total += row1.Cells(7).Value

                            End If

                        Next

                        LBlTotal01.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                        PnnSolicitação01.Visible = True

                    End If

                Else

                    If IdFornecedor02 = "" Then

                        'popula o segundo quadro

                        If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                            LstIdInserido.Items.Add(row.Cells(0).Value)

                            'popula o primeiro quadro

                            IdFornecedor02 = row.Cells(0).Value

                            LblSolicitação02.Text = row.Cells(8).Value

                            DtSolicitação02.Rows.Clear()

                            Dim Total As Decimal = 0

                            For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                If row1.Cells(0).Value = row.Cells(0).Value Then

                                    DtSolicitação02.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6), row1.Cells(1).Value)

                                    Total += row1.Cells(7).Value

                                End If

                            Next

                            LBlTotal02.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                            PnnSolicitação02.Visible = True

                        End If
                    Else

                        If IdFornecedor03 = "" Then

                            'popula o terceiro quadro

                            If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                                LstIdInserido.Items.Add(row.Cells(0).Value)

                                'popula o primeiro quadro

                                IdFornecedor03 = row.Cells(0).Value

                                LblSolicitação03.Text = row.Cells(8).Value

                                DtSolicitação03.Rows.Clear()

                                Dim Total As Decimal = 0

                                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                    If row1.Cells(0).Value = row.Cells(0).Value Then

                                        DtSolicitação03.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6), row1.Cells(1).Value)

                                        Total += row.Cells(5).Value

                                    End If

                                Next

                                LBlTotal03.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                                PnnSolicitação03.Visible = True

                            End If
                        End If

                    End If

                End If

            End If

        Next

        'seleciona proximo da lista

        If DtCotFinal.SelectedCells(1).RowIndex + 1 <= DtCotFinal.Rows.Count - 1 Then
            DtCotFinal.Rows(DtCotFinal.SelectedCells(1).RowIndex).Cells(0).Value = ImageList1.Images(1)
            DtCotFinal.Rows(DtCotFinal.SelectedCells(1).RowIndex + 1).Selected = True
        Else
            DtCotFinal.Rows(DtCotFinal.SelectedCells(1).RowIndex).Cells(0).Value = ImageList1.Images(1)
            DtCotFinal.Rows(0).Selected = True
        End If

        NmQtSolicitada.Minimum = 0
        NmQtSolicitada.Value = 0
        LblISacola.Text = 0

        CArregaDash()

        If CmbFornecedores.Items.Count > 0 Then
            NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
            NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
        End If

        If TabControl1.SelectedIndex = 2 Then
            If TabControl2.SelectedIndex = 0 Then
                If CmbFornecedores.Items.Count = 0 Then

                    LblQtSolicitada.Text = FormatNumber(0, NumDigitsAfterDecimal:=2)
                    LblValorUnitario.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
                    LblResultado.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
                    LblISacola.Text = 0
                    CmbFornecedores.Enabled = False
                    BttSolicitar.Enabled = False

                    MsgBox("Nenhum valor encontrado na cotação para este item.", MsgBoxStyle.OkOnly)

                End If
            End If

        End If

        If DtCotFinal.Rows.Count = 0 Then
            BttSolicitar.Enabled = False
        End If

    End Sub

    Private Sub DtItensBDD_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensBDD.CellEnter

        If DtItensBDD.Enabled = True Then

            Me.Cursor = Cursors.WaitCursor

            If DtItensBDD.Rows.Count > 0 Then

                TempoPIng = 0
                Me.Cursor = Cursors.AppStarting

                '       

                Dim ValorPartNumber As String = DtItensBDD.SelectedCells(6).Value.ToString
                Dim ModeloVeiculoEncontrado As String = DtItensBDD.SelectedCells(4).Value.ToString

                Dim baseUrl As String = "http://www.iarasoftware.com.br/ExibebCatalogo_OnLine.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                    & "&Modelo=" & ModeloVeiculoEncontrado

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.CatalogoOnLine))(content)

                DtBddIARA.Rows.Clear()

                Dim Selecionados As Integer = 0

                For Each row In read.ToList

                    'If row.PartNumber <> Nothing Then

                    If row.PartNumber = ValorPartNumber Then

                        '

                        Dim ValorUnitarioEncontrado As String = row.ValorUnit.ToString.Replace(".", ",")

                        If ValorUnitarioEncontrado = 0 Then
                            '
                            ValorUnitarioEncontrado = "Sob consulta"

                            DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, "100,00%", row.PartNumber, ValorUnitarioEncontrado, row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                            Timer1.Enabled = True

                        Else

                            DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, "100,00%", row.PartNumber, FormatCurrency(ValorUnitarioEncontrado, NumDigitsAfterDecimal:=2), row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                        End If

                        'procura a quantidade de itens cotados para este forneedor

                        Dim C0 As Integer = 0
                        Dim C1 As Integer = 0

                        For Each row1 As DataGridViewRow In DtResumo.Rows

                        Next

                        If C0 > 0 Then

                            DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(8).Value = C0

                            DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(9).Value = ImageList1.Images(4)

                            Selecionados += 1

                        End If

                        DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(8).Value = C1

                    Else

                        'verifica semelhança das descricoes

                        Dim str As String = DtItensBDD.SelectedCells(2).Value.ToString.ToLower
                        Dim separador As String = " "
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        For Each palavra In palavras
                            LstPalavras.Items.Add(palavra)
                        Next

                        'Busca associação

                        Dim LqOficina As New LqOficinaDataContext
                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        Dim LstItensModelo As New ListBox

                        Dim ModeloString As String = ""

                        If DtItensBDD.SelectedCells(1).Value.ToString.StartsWith("S") Then

                            Dim CodS As String = DtItensBDD.SelectedCells(1).Value.ToString
                            CodS = CodS.Remove(0, 2)

                            Dim strModelo As String = row.Descricao.ToString.ToLower
                            Dim separadorModelo As String = " "
                            Dim palavrasModelo As String() = strModelo.Split(separadorModelo)
                            Dim palavraModelo As String

                            Dim BuscaAss = From ass In LqOficina.AssociaçãoPeçaModelo
                                           Where ass.IdSolicitaçãoCad = CodS
                                           Select ass.IdModeloVeic

                            If BuscaAss.Count > 0 Then

                                Dim BuscaModelos = From mode In LqOficina.Modelos
                                                   Where mode.IdModelo = BuscaAss.First
                                                   Select mode.IdFabricante, mode.Modelo

                                'Busca FAbricante

                                LstItensModelo.Items.Add(BuscaModelos.First.Modelo)
                                ModeloString = BuscaModelos.First.Modelo

                            End If

                        Else

                            Dim CodS As String = DtItensBDD.SelectedCells(1).Value.ToString

                            Dim BuscaAss = From ass In LqOficina.AssociaçãoPeçaModelo
                                           Where ass.IdCodProd = CodS
                                           Select ass.IdModeloVeic

                            If BuscaAss.Count > 0 Then

                                Dim BuscaModelos = From mode In LqOficina.Modelos
                                                   Where mode.IdModelo = BuscaAss.First
                                                   Select mode.IdFabricante, mode.Modelo

                                'Busca FAbricante

                                LstItensModelo.Items.Add(BuscaModelos.First.Modelo)
                                ModeloString = BuscaModelos.First.Modelo

                            End If

                        End If

                        'Compara

                        Dim str0 As String = row.Descricao.ToString.ToLower
                        Dim separador0 As String = " "
                        Dim palavras0 As String() = str0.Split(separador0)
                        Dim LstPalavras0 As New ListBox
                        Dim palavra0 As String

                        For Each palavra0 In palavras0
                            LstPalavras0.Items.Add(palavra0)
                        Next

                        'varre a lista

                        Dim C As Decimal = 0

                        Dim LstPalavraInserido As New ListBox

                        For Each linhas In LstPalavras.Items

                            If LstPalavras0.Items.Contains(linhas.ToString) Then

                                If Not LstItensModelo.Items.Contains(linhas.ToString) Then

                                    If Not LstPalavraInserido.Items.Contains(linhas.ToString) Then

                                        C += 1
                                        LstPalavraInserido.Items.Add(linhas.ToString)

                                    End If

                                Else

                                    If Not LstPalavraInserido.Items.Contains(linhas.ToString) Then

                                        C += 1
                                        LstPalavraInserido.Items.Add(linhas.ToString)

                                    End If

                                End If

                            End If

                        Next

                        If C > 0 Then

                            If (((100 * C) / LstPalavras0.Items.Count)) > 49 Then

                                Dim ValorUnitarioEncontrado As String = row.ValorUnit.ToString.Replace(".", ",")

                                If ValorUnitarioEncontrado = 0 Then
                                    '
                                    ValorUnitarioEncontrado = "Sob consulta"

                                    DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, FormatPercent(((100 * C) / LstPalavras0.Items.Count) / 100), row.PartNumber, ValorUnitarioEncontrado, row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                                    Timer1.Enabled = True

                                Else

                                    DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, FormatPercent(((100 * C) / LstPalavras0.Items.Count) / 100), row.PartNumber, FormatCurrency(ValorUnitarioEncontrado, NumDigitsAfterDecimal:=2), row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                                End If

                            End If

                        End If

                    End If


                Next

                If Selecionados = DtBddIARA.Rows.Count Then

                    'VerificaPossibilidadeAnalise()

                Else

                End If

                If DtBddIARA.Rows.Count > 0 Then

                    LblOcorrencias.Text = DtBddIARA.Rows.Count & " correspondências encontradas."

                ElseIf DtBddIARA.Rows.Count = 0 Then

                    LblOcorrencias.Text = "Nenhuma correspondência encontrada."

                    'TabControl1.SelectedIndex = 1

                End If


            End If

            Me.Cursor = Cursors.Arrow

        End If


    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged

        Dim C As Integer = 0

        For Each row As DataGridViewRow In DtItensBDD.Rows

            If row.Visible = True Then

                C += 1

            End If

        Next

        If C = 0 Then

            'TabControl2.SelectedIndex = 2

        End If

        If TabControl2.SelectedIndex = 0 Then
            'limpa datagrid

            CArregaDash()

        ElseIf TabControl2.SelectedIndex = 2 Then

            DtCotFinal.Rows(0).Selected = True

        End If

    End Sub

    Dim QtGuardado As New ListBox

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Dim C As Integer = 0

        For Each row As DataGridViewRow In DtItensBDD.Rows

            If row.Visible = True Then

                C += 1

            End If

        Next

        If C = 0 Then

            'TabControl1.SelectedIndex = 2

        End If

        If TabControl1.SelectedIndex = 1 Then
            'limpa datagrid

            DtItensCotação.Rows.Clear()

            For Each row As DataGridViewRow In DtItensBDD.Rows

                'procura no resumo

                DtItensCotação.Rows.Add(row.Cells(1).Value, "", row.Cells(2).Value, "R$ 0,00", "R$ 0,00", row.Cells(7).Value, FormatCurrency(0, NumDigitsAfterDecimal:=2), 0)
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionForeColor = Color.WhiteSmoke

                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionForeColor = Color.WhiteSmoke

                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionForeColor = Color.WhiteSmoke

                'busca valor inserido no resumo

                For Each row1 As DataGridViewRow In DtResumo.Rows

                    Dim Val1 As String = row1.Cells(2).Value
                    Dim Val2 As String = row.Cells(1).Value

                    If Val1 = Val2 Then
                        Dim ValorUNit As Decimal = row1.Cells(6).Value
                        Dim Qt As Integer = row1.Cells(8).Value

                        Dim SubTotal As Decimal = ValorUNit * Qt
                        DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Value = row1.Cells(6).Value
                        DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Value = row1.Cells(8).Value
                        DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(6).Value = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)
                        DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Value = row1.Cells(7).Value
                    End If

                Next

            Next

            'verifica se existe fornecedor

            If DtFornecedores.Rows.Count = 0 Then

                If DtBddIARA.Rows.Count = 0 Then
                    If MsgBox("Não encontrei nenhum fornecedor cadastrado, deseja ser direcionado para a tela de novo cadastro?", MsgBoxStyle.YesNo + vbInformation) = MsgBoxResult.Yes Then

                        BtnAddFornecedor.PerformClick()

                    Else

                        Me.Close()

                    End If

                End If

            End If

        ElseIf TabControl1.SelectedIndex = 2 Then

            'TabControl2.SelectedIndex = 0

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Enabled = True
            Else
                NmQtSolicitada.Minimum = 0
                NmQtSolicitada.Value = 0
                NmQtSolicitada.Enabled = False

            End If

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnAddFornecedor.Click

        FrmNovoFornecedor.CkPrestador.Enabled = False

        FrmNovoFornecedor.CkComissionado.Enabled = False

        FrmNovoFornecedor.CkTransportadora.Enabled = False

        FrmNovoFornecedor.Show(Me)

        FrmNovoFornecedor.Panel5.Focus()

        FrmNovoFornecedor.TxtDocumento.Focus()

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Private Sub FrmCotações_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.AppStarting

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        'popula no solicitador

        Dim BuscaFornecedores = From fornec In LqBase.Fornecedores
                                Where fornec.IdFornecedor Like "*"
                                Select fornec.IdFornecedor, fornec.Apelido, fornec.Doc, fornec.Nome
                                Order By IdFornecedor Descending

        DtFornecedores.Rows.Clear()

        For Each row In BuscaFornecedores.ToList

            Dim _CNPj As String = row.Doc.ToString.ToCharArray(0, 2) & "." & row.Doc.ToString.ToCharArray(2, 3) & "." & row.Doc.ToString.ToCharArray(5, 3) & "/" & row.Doc.ToString.ToCharArray(8, 4) & "-" & row.Doc.ToString.ToCharArray(12, 2)

            DtFornecedores.Rows.Add(row.IdFornecedor, _CNPj, row.Apelido, False)

        Next

        DtFornecedores.Enabled = True

        'marca primeira posiçao

        DtItensBDD.Enabled = True

        If DtItensBDD.Enabled = True Then

            Me.Cursor = Cursors.WaitCursor

            If DtItensBDD.Enabled = True Then

                TempoPIng = 0
                Me.Cursor = Cursors.AppStarting

                '       

                Dim ValorPartNumber As String = DtItensBDD.SelectedCells(6).Value.ToString
                Dim ModeloVeiculoEncontrado As String = DtItensBDD.SelectedCells(4).Value.ToString

                Dim baseUrl As String = "http://www.iarasoftware.com.br/ExibebCatalogo_OnLine.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                    & "&Modelo=" & ModeloVeiculoEncontrado

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.CatalogoOnLine))(content)

                DtBddIARA.Rows.Clear()

                Dim Selecionados As Integer = 0

                For Each row In read.ToList

                    'If row.PartNumber <> Nothing Then

                    If row.PartNumber = ValorPartNumber Then

                        '

                        Dim ValorUnitarioEncontrado As String = row.ValorUnit.ToString.Replace(".", ",")

                        If ValorUnitarioEncontrado = 0 Then
                            '
                            ValorUnitarioEncontrado = "Sob consulta"

                            DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, "100,00%", row.PartNumber, ValorUnitarioEncontrado, row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                            Timer1.Enabled = True

                        Else

                            DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, "100,00%", row.PartNumber, FormatCurrency(ValorUnitarioEncontrado, NumDigitsAfterDecimal:=2), row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                        End If

                        'procura a quantidade de itens cotados para este forneedor

                        Dim C0 As Integer = 0
                        Dim C1 As Integer = 0

                        For Each row1 As DataGridViewRow In DtResumo.Rows

                        Next

                        If C0 > 0 Then

                            DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(8).Value = C0

                            DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(9).Value = ImageList1.Images(4)

                            Selecionados += 1

                        End If

                        DtBddIARA.Rows(DtBddIARA.Rows.Count - 1).Cells(8).Value = C1

                    Else

                        'verifica semelhança das descricoes

                        Dim str As String = DtItensBDD.SelectedCells(2).Value.ToString.ToLower
                        Dim separador As String = " "
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        For Each palavra In palavras
                            LstPalavras.Items.Add(palavra)
                        Next

                        'Busca associação

                        Dim LqOficina As New LqOficinaDataContext
                        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        Dim LstItensModelo As New ListBox

                        Dim ModeloString As String = ""

                        If DtItensBDD.SelectedCells(1).Value.ToString.StartsWith("S") Then

                            Dim CodS As String = DtItensBDD.SelectedCells(1).Value.ToString
                            CodS = CodS.Remove(0, 2)

                            Dim strModelo As String = row.Descricao.ToString.ToLower
                            Dim separadorModelo As String = " "
                            Dim palavrasModelo As String() = strModelo.Split(separadorModelo)
                            Dim palavraModelo As String

                            Dim BuscaAss = From ass In LqOficina.AssociaçãoPeçaModelo
                                           Where ass.IdSolicitaçãoCad = CodS
                                           Select ass.IdModeloVeic

                            If BuscaAss.Count > 0 Then

                                Dim BuscaModelos = From mode In LqOficina.Modelos
                                                   Where mode.IdModelo = BuscaAss.First
                                                   Select mode.IdFabricante, mode.Modelo

                                'Busca FAbricante

                                LstItensModelo.Items.Add(BuscaModelos.First.Modelo)
                                ModeloString = BuscaModelos.First.Modelo

                            End If

                        Else

                            Dim CodS As String = DtItensBDD.SelectedCells(1).Value.ToString

                            Dim BuscaAss = From ass In LqOficina.AssociaçãoPeçaModelo
                                           Where ass.IdCodProd = CodS
                                           Select ass.IdModeloVeic

                            If BuscaAss.Count > 0 Then

                                Dim BuscaModelos = From mode In LqOficina.Modelos
                                                   Where mode.IdModelo = BuscaAss.First
                                                   Select mode.IdFabricante, mode.Modelo

                                'Busca FAbricante

                                LstItensModelo.Items.Add(BuscaModelos.First.Modelo)
                                ModeloString = BuscaModelos.First.Modelo

                            End If

                        End If

                        'Compara

                        Dim str0 As String = row.Descricao.ToString.ToLower
                        Dim separador0 As String = " "
                        Dim palavras0 As String() = str0.Split(separador0)
                        Dim LstPalavras0 As New ListBox
                        Dim palavra0 As String

                        For Each palavra0 In palavras0
                            LstPalavras0.Items.Add(palavra0)
                        Next

                        'varre a lista

                        Dim C As Decimal = 0

                        Dim LstPalavraInserido As New ListBox

                        For Each linhas In LstPalavras.Items

                            If LstPalavras0.Items.Contains(linhas.ToString) Then

                                If Not LstItensModelo.Items.Contains(linhas.ToString) Then

                                    If Not LstPalavraInserido.Items.Contains(linhas.ToString) Then

                                        C += 1
                                        LstPalavraInserido.Items.Add(linhas.ToString)

                                    End If

                                Else

                                    If Not LstPalavraInserido.Items.Contains(linhas.ToString) Then

                                        C += 1
                                        LstPalavraInserido.Items.Add(linhas.ToString)

                                    End If

                                End If

                            End If

                        Next

                        If C > 0 Then

                            If (((100 * C) / LstPalavras0.Items.Count)) > 49 Then

                                Dim ValorUnitarioEncontrado As String = row.ValorUnit.ToString.Replace(".", ",")

                                If ValorUnitarioEncontrado = 0 Then
                                    '
                                    ValorUnitarioEncontrado = "Sob consulta"

                                    DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, FormatPercent(((100 * C) / LstPalavras0.Items.Count) / 100), row.PartNumber, ValorUnitarioEncontrado, row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                                    Timer1.Enabled = True

                                Else

                                    DtBddIARA.Rows.Add(My.Resources.unavailable, row.Apelido, row.IdItem, row.Descricao, FormatPercent(((100 * C) / LstPalavras0.Items.Count) / 100), row.PartNumber, FormatCurrency(ValorUnitarioEncontrado, NumDigitsAfterDecimal:=2), row.Prazo, 0, ImageList1.Images(5), row.QtDisponivel, row.ChaveOficina, 1)

                                End If

                            End If

                        End If

                    End If


                Next

                If Selecionados = DtBddIARA.Rows.Count Then

                    'VerificaPossibilidadeAnalise()

                Else

                End If

                If DtBddIARA.Rows.Count > 0 Then

                    LblOcorrencias.Text = DtBddIARA.Rows.Count & " correspondências encontradas."

                ElseIf DtBddIARA.Rows.Count = 0 Then

                    LblOcorrencias.Text = "Nenhuma correspondência encontrada."

                    'TabControl1.SelectedIndex = 1

                End If


            End If

            Me.Cursor = Cursors.Arrow

        End If

        'TabControl1.SelectedIndex = 1

    End Sub

    Private Sub DtFornecedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellClick

        'limpa datagrid

        DtItensCotação.Rows.Clear()

        For Each row As DataGridViewRow In DtItensBDD.Rows

            DtItensCotação.Rows.Add(row.Cells(1).Value, "", row.Cells(2).Value, "R$ 0,00", "R$ 0,00", row.Cells(7).Value, FormatCurrency(row.Cells(7).Value * 0, NumDigitsAfterDecimal:=2), 0)
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.BackColor = Color.Gainsboro
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.ForeColor = Color.DarkSlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionBackColor = Color.SlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionForeColor = Color.WhiteSmoke

            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.BackColor = Color.Gainsboro
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.ForeColor = Color.DarkSlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.BackColor = Color.Gainsboro
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.ForeColor = Color.DarkSlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionBackColor = Color.SlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionForeColor = Color.WhiteSmoke

            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.BackColor = Color.Gainsboro
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.ForeColor = Color.DarkSlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionBackColor = Color.SlateGray
            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionForeColor = Color.WhiteSmoke

            'busca valor inserido no resumo

            For Each row1 As DataGridViewRow In DtResumo.Rows

                If row1.Cells(0).Value = "I_" & DtFornecedores.SelectedCells(0).Value Then

                    If row1.Cells(1).Value.ToString = row.Cells(1).Value.ToString Then
                        DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Value = row1.Cells(5).Value
                    End If
                End If

            Next

        Next

        For Each row As DataGridViewRow In DtResumo.Rows

            If row.Cells(0).Value = "I_" & DtFornecedores.SelectedCells(0).Value Then

                For Each rowa As DataGridViewRow In DtItensCotação.Rows

                    Dim Qt As Decimal = rowa.Cells(5).Value
                    Dim ValorUnit As Decimal = rowa.Cells(4).Value
                    Dim Total As Decimal = Qt * ValorUnit

                    rowa.Cells(6).Value = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                    If row.Cells(1).Value.ToString = rowa.Cells(0).Value.ToString Then
                        rowa.Cells(4).Style.ForeColor = Color.DarkSlateGray
                        rowa.Cells(4).Style.Font = New Font("Calibri", 8.25)
                        If row.DefaultCellStyle.BackColor = Color.MintCream Then
                            rowa.Cells(4).Style.ForeColor = Color.DarkGreen
                            rowa.Cells(4).Style.Font = New Font("Calibri", 10)
                        End If
                    End If

                Next

            End If
        Next


    End Sub

    Private Sub DtItensCotação_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensCotação.CellContentClick

        If DtItensCotação.Columns(e.ColumnIndex).Name = "ClmValorUnitario" Then

            DtItensCotação.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            DtItensCotação.BeginEdit(True)
            DtItensCotação.Rows(e.RowIndex).Cells(4).Value = FormatNumber(DtItensCotação.Rows(e.RowIndex).Cells(4).Value, NumDigitsAfterDecimal:=2)

        ElseIf DtItensCotação.Columns(e.ColumnIndex).Name = "ClmQtSol" Then

            DtItensCotação.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            DtItensCotação.BeginEdit(True)
            DtItensCotação.Rows(e.RowIndex).Cells(5).Value = FormatNumber(DtItensCotação.Rows(e.RowIndex).Cells(5).Value, NumDigitsAfterDecimal:=2)

        ElseIf DtItensCotação.Columns(e.ColumnIndex).Name = "ClmPrazoEntrega" Then

            DtItensCotação.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            DtItensCotação.BeginEdit(True)
            DtItensCotação.Rows(e.RowIndex).Cells(7).Value = FormatNumber(DtItensCotação.Rows(e.RowIndex).Cells(7).Value, NumDigitsAfterDecimal:=2)

        End If

    End Sub

    Private Sub DtItensCotação_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensCotação.CellEndEdit

        If DtItensCotação.Rows(e.RowIndex).Cells(4).Value = "" Then
            DtItensCotação.Rows(e.RowIndex).Cells(4).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)
            DtItensCotação.Rows(e.RowIndex).Cells(5).Value = FormatNumber(0, NumDigitsAfterDecimal:=2)
        Else

            Try

                DtItensCotação.Rows(e.RowIndex).Cells(4).Value = FormatCurrency(DtItensCotação.Rows(e.RowIndex).Cells(4).Value, NumDigitsAfterDecimal:=2)
                DtItensCotação.Rows(e.RowIndex).Cells(5).Value = FormatNumber(DtItensCotação.Rows(e.RowIndex).Cells(5).Value, NumDigitsAfterDecimal:=2)

                'verifica se valor é maior q zero

                Dim ValorUnitário As Decimal = DtItensCotação.Rows(e.RowIndex).Cells(4).Value
                Dim Qt As Decimal = DtItensCotação.Rows(e.RowIndex).Cells(5).Value
                Dim Total As Decimal = 0

                If ValorUnitário > 0 Then

                    Total = Qt * ValorUnitário

                    DtItensCotação.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.BackColor = Color.Gainsboro
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.ForeColor = Color.DarkSlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionBackColor = Color.SlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionForeColor = Color.WhiteSmoke

                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.BackColor = Color.Gainsboro
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.ForeColor = Color.DarkSlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.BackColor = Color.Gainsboro
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.ForeColor = Color.DarkSlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionBackColor = Color.SlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionForeColor = Color.WhiteSmoke

                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.BackColor = Color.Gainsboro
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.ForeColor = Color.DarkSlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionBackColor = Color.SlateGray
                    DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionForeColor = Color.WhiteSmoke

                    'procura item para este fornecedor no resumo

                    Dim C As Integer = -1

                    For Each row As DataGridViewRow In DtResumo.Rows

                        'procura fornecedor
                        If row.Cells(0).Value.ToString = "I_" & DtFornecedores.SelectedCells(0).Value.ToString Then
                            'procura produto
                            If row.Cells(2).Value.ToString = DtItensCotação.Rows(e.RowIndex).Cells(0).Value.ToString Then
                                C = row.Index
                            End If
                        End If

                    Next

                    If C = -1 Then

                        'adiciona no resumo

                        'busca PN as string

                        Dim PN As String = ""

                        For Each row As DataGridViewRow In DtItensBDD.Rows

                            If row.Cells(1).Value.ToString = DtItensCotação.Rows(e.RowIndex).Cells(0).Value.ToString Then

                                PN = row.Cells(6).Value

                            End If
                        Next

                        DtResumo.Rows.Add("I_" & DtFornecedores.SelectedCells(0).Value, DtFornecedores.SelectedCells(2).Value, DtItensCotação.Rows(e.RowIndex).Cells(0).Value, DtItensCotação.Rows(e.RowIndex).Cells(1).Value, DtItensCotação.Rows(e.RowIndex).Cells(2).Value, PN, DtItensCotação.Rows(e.RowIndex).Cells(4).Value, DtItensCotação.Rows(e.RowIndex).Cells(7).Value, DtItensCotação.Rows(e.RowIndex).Cells(5).Value, DtItensCotação.Rows(e.RowIndex).Cells(5).Value, DtItensCotação.Rows(e.RowIndex).Cells(1).Value)

                    Else

                        Dim PN As String = ""

                        For Each row As DataGridViewRow In DtItensBDD.Rows

                            If row.Cells(1).Value.ToString = DtItensCotação.Rows(e.RowIndex).Cells(0).Value.ToString Then

                                PN = row.Cells(6).Value

                            End If
                        Next

                        DtResumo.Rows(C).SetValues("I_" & DtFornecedores.SelectedCells(0).Value, DtFornecedores.SelectedCells(2).Value, DtItensCotação.Rows(e.RowIndex).Cells(0).Value, DtItensCotação.Rows(e.RowIndex).Cells(1).Value, DtItensCotação.Rows(e.RowIndex).Cells(2).Value, PN, DtItensCotação.Rows(e.RowIndex).Cells(4).Value, DtItensCotação.Rows(e.RowIndex).Cells(7).Value, DtItensCotação.Rows(e.RowIndex).Cells(5).Value)

                    End If

                Else

                    Dim C As Integer = -1

                    For Each row As DataGridViewRow In DtResumo.Rows

                        'procura fornecedor
                        If row.Cells(0).Value = "I_" & DtFornecedores.SelectedCells(0).Value Then
                            'procura produto
                            If row.Cells(2).Value.ToString = DtItensCotação.Rows(e.RowIndex).Cells(0).Value.ToString Then
                                C = row.Index
                            End If
                        End If

                    Next

                    DtItensCotação.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

                    DtResumo.Rows.RemoveAt(C)

                End If


                For Each rowini As DataGridViewRow In DtItensBDD.Rows

                    Dim R As Integer = 0

                    For Each row As DataGridViewRow In DtResumo.Rows

                        If row.Cells(3).Value.ToString = rowini.Cells(1).Value.ToString Then

                            R += 1

                        End If

                    Next

                    If R > 0 Then
                        rowini.Cells(0).Value = ImageList1.Images(1)
                    Else
                        rowini.Cells(0).Value = ImageList1.Images(0)
                    End If


                Next


                Dim _MelhorValor As Decimal = 1000000000000000
                Dim _MelhorEntrega As Decimal = 1000000000000000

                For Each rowini As DataGridViewRow In DtItensBDD.Rows

                    _MelhorValor = 1000000000000000
                    _MelhorEntrega = 1000000000000000

                    For Each row As DataGridViewRow In DtResumo.Rows

                        If rowini.Cells(1).Value.ToString = row.Cells(1).Value.ToString Then

                            Dim ValorEnc As Decimal = row.Cells(5).Value

                            If ValorEnc < _MelhorValor Then

                                'pinta os que forem para este perfil

                                For Each rowa As DataGridViewRow In DtResumo.Rows

                                    If rowini.Cells(1).Value.ToString = rowa.Cells(1).Value.ToString Then

                                        rowa.Cells(5).Style.Font = New Font("Calibri", 8.25)
                                        rowa.Cells(0).Style.Font = New Font("Calibri", 8.25)
                                        rowa.Cells(3).Style.Font = New Font("Calibri", 8.25)

                                        rowa.Cells(5).Style.ForeColor = Color.DarkSlateGray
                                        rowa.Cells(0).Style.ForeColor = Color.DarkSlateGray
                                        rowa.Cells(3).Style.ForeColor = Color.DarkSlateGray

                                        rowa.DefaultCellStyle.BackColor = Color.WhiteSmoke

                                    End If

                                Next

                                _MelhorValor = ValorEnc

                                row.Cells(5).Style.Font = New Font("Calibri", 10)
                                row.Cells(0).Style.Font = New Font("Calibri", 10)
                                row.Cells(3).Style.Font = New Font("Calibri", 10)

                                row.Cells(5).Style.ForeColor = Color.DarkGreen
                                row.Cells(0).Style.ForeColor = Color.DarkGreen
                                row.Cells(3).Style.ForeColor = Color.DarkGreen

                                row.DefaultCellStyle.BackColor = Color.MintCream

                            End If

                        End If

                    Next
                Next

                'verifica se esta pintado como verde

                For Each row As DataGridViewRow In DtResumo.Rows

                    If row.Cells(0).Value = "I_" & DtFornecedores.SelectedCells(0).Value Then
                        If row.Cells(1).Value.ToString = DtItensCotação.SelectedCells(0).Value.ToString Then
                            DtItensCotação.SelectedCells(4).Style.ForeColor = Color.DarkSlateGray
                            DtItensCotação.SelectedCells(4).Style.Font = New Font("Calibri", 8.25)
                            If row.DefaultCellStyle.BackColor = Color.MintCream Then
                                DtItensCotação.SelectedCells(4).Style.ForeColor = Color.DarkGreen
                                DtItensCotação.SelectedCells(4).Style.Font = New Font("Calibri", 10)
                            End If
                        End If
                    End If
                Next

            Catch ex As Exception

                'MsgBox(ex.Message)
                DtItensCotação.Rows(e.RowIndex).Cells(4).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)
                DtItensCotação.Rows(e.RowIndex).Cells(6).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)

            End Try

        End If

    End Sub

    Private Sub DtItensCotação_GotFocus(sender As Object, e As EventArgs) Handles DtItensCotação.GotFocus


    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

    End Sub

    Private Sub DtFornecedores_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellEnter

        If DtFornecedores.Enabled = True Then

            'limpa datagrid

            DtItensCotação.Rows.Clear()

            For Each row As DataGridViewRow In DtItensBDD.Rows

                'busca no grid de resumo as quantidades inseridas

                Dim QtEnc As Decimal = 0

                For Each rowP As DataGridViewRow In DtResumo.Rows

                Next

                DtItensCotação.Rows.Add(row.Cells(1).Value, "", row.Cells(2).Value, "R$ 0,00", "R$ 0,00", row.Cells(7).Value, FormatCurrency(row.Cells(7).Value * 0, NumDigitsAfterDecimal:=2), 0)
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Style.SelectionForeColor = Color.WhiteSmoke

                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Style.SelectionForeColor = Color.WhiteSmoke

                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(1).Style.SelectionForeColor = Color.WhiteSmoke

                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.BackColor = Color.Gainsboro
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.ForeColor = Color.DarkSlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionBackColor = Color.SlateGray
                DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(7).Style.SelectionForeColor = Color.WhiteSmoke

                'busca valor inserido no resumo

                For Each row1 As DataGridViewRow In DtResumo.Rows

                    If row1.Cells(0).Value = "I_" & DtFornecedores.SelectedCells(0).Value Then

                        If row1.Cells(1).Value.ToString = row.Cells(1).Value.ToString Then
                            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(4).Value = row1.Cells(5).Value
                            DtItensCotação.Rows(DtItensCotação.Rows.Count - 1).Cells(5).Value = row1.Cells(7).Value
                        End If
                    End If

                Next

            Next

            For Each row As DataGridViewRow In DtResumo.Rows

                If row.Cells(0).Value = "I_" & DtFornecedores.SelectedCells(0).Value Then

                    For Each rowa As DataGridViewRow In DtItensCotação.Rows

                        Dim Qt As Decimal = rowa.Cells(5).Value
                        Dim ValorUnit As Decimal = rowa.Cells(4).Value
                        Dim Total As Decimal = Qt * ValorUnit

                        rowa.Cells(6).Value = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                        If row.Cells(1).Value.ToString = rowa.Cells(0).Value.ToString Then
                            rowa.Cells(4).Style.ForeColor = Color.DarkSlateGray
                            rowa.Cells(4).Style.Font = New Font("Calibri", 8.25)
                            If row.DefaultCellStyle.BackColor = Color.MintCream Then
                                rowa.Cells(4).Style.ForeColor = Color.DarkGreen
                                rowa.Cells(4).Style.Font = New Font("Calibri", 10)
                            End If
                        End If

                    Next

                End If
            Next

        End If

    End Sub

    Private Sub DtCotFinal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellContentClick

    End Sub

    Private Sub DtCotFinal_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellClick

        Me.Cursor = Cursors.WaitCursor

        NmQtSolicitada.Minimum = 0
        NmQtSolicitada.Value = 0
        LblISacola.Text = 0

        CArregaDash()

        If CmbFornecedores.Items.Count > 0 Then
            NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(8).Value
            NmQtSolicitada.Value = DtCotFinal.SelectedCells(8).Value
            NmQtSolicitada.Enabled = True
            CmbFornecedores.Enabled = True
            BttSolicitar.Enabled = True

        Else
            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            NmQtSolicitada.Enabled = False

            If TabControl1.SelectedIndex = 2 Then
                If TabControl2.SelectedIndex = 0 Then
                    If CmbFornecedores.Items.Count = 0 Then

                        LblQtSolicitada.Text = FormatNumber(0, NumDigitsAfterDecimal:=2)
                        LblValorUnitario.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
                        LblResultado.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
                        LblISacola.Text = 0
                        CmbFornecedores.Enabled = False
                        BttSolicitar.Enabled = False

                        MsgBox("Nenhum valor encontrado na cotação para este item.", MsgBoxStyle.OkOnly)
                    End If
                End If

            End If

        End If



    End Sub

    Private Sub DtCotFinal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellEnter

        NmQtSolicitada.Minimum = 0
        NmQtSolicitada.Value = 0
        LblISacola.Text = 0

        CArregaDash()

        If CmbFornecedores.Items.Count > 0 Then
            NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
            NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            NmQtSolicitada.Enabled = True

        Else
            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            NmQtSolicitada.Enabled = False

        End If

    End Sub

    Private Sub DtItensCotação_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensCotação.CellEnter

    End Sub

    Private Sub DtSolicitação01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtSolicitação01.CellContentClick

        If DtSolicitação01.Columns(e.ColumnIndex).Name = "ClmExcluirPnn01" Then

            'habilita campo do itens cotação

            For Each row As DataGridViewRow In DtCotFinal.Rows

                If row.Cells(1).Value.ToString = DtSolicitação01.Rows(e.RowIndex).Cells(0).Value.ToString Then

                    row.Cells(0).Value = ImageList1.Images(0)

                End If
            Next

            'remove da lista de compra

            For Each row As DataGridViewRow In DtResumoSolicitação.Rows

                If row.Cells(2).Value.ToString = DtSolicitação01.Rows(e.RowIndex).Cells(0).Value.ToString Then

                    DtResumoSolicitação.Rows.Remove(row)

                End If

            Next

            DtSolicitação01.Rows.RemoveAt(e.RowIndex)

            'calcula total

            Dim TotalCar As Decimal

            For Each row As DataGridViewRow In DtSolicitação01.Rows

                TotalCar += row.Cells(4).Value

            Next

            LBlTotal01.Text = FormatCurrency(TotalCar, NumDigitsAfterDecimal:=2)

            If DtSolicitação01.Rows.Count = 0 Then

                PnnSolicitação01.Visible = False

            End If

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            End If

            If PnnSolicitação01.Visible = False And PnnSolicitação02.Visible = False And PnnSolicitação03.Visible = False Then

                TabControl2.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub DtSolicitação02_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtSolicitação02.CellContentClick

        If DtSolicitação02.Columns(e.ColumnIndex).Name = "ClmExcluirPnn02" Then

            'habilita campo do itens cotação

            For Each row As DataGridViewRow In DtCotFinal.Rows

                If row.Cells(1).Value.ToString = DtSolicitação02.Rows(e.RowIndex).Cells(0).Value.ToString Then

                    row.Cells(0).Value = ImageList1.Images(0)

                End If
            Next

            'remove da lista de compra

            For Each row As DataGridViewRow In DtResumoSolicitação.Rows

                If row.Cells(2).Value.ToString = DtSolicitação02.Rows(e.RowIndex).Cells(0).Value.ToString Then

                    DtResumoSolicitação.Rows.Remove(row)

                End If

            Next

            DtSolicitação02.Rows.RemoveAt(e.RowIndex)

            'calcula total

            Dim TotalCar As Decimal

            For Each row As DataGridViewRow In DtSolicitação02.Rows

                TotalCar += row.Cells(4).Value

            Next

            LBlTotal02.Text = FormatCurrency(TotalCar, NumDigitsAfterDecimal:=2)

            If DtSolicitação02.Rows.Count = 0 Then

                PnnSolicitação02.Visible = False

            End If

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            End If

            If PnnSolicitação01.Visible = False And PnnSolicitação02.Visible = False And PnnSolicitação03.Visible = False Then

                TabControl2.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub Panel13_Paint(sender As Object, e As PaintEventArgs) Handles Panel13.Paint


    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Private Sub Panel13_Click(sender As Object, e As EventArgs) Handles Panel13.Click

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqEstoqueOnLine.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueDistribuidorOnLine
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'solicita compra

        'varre datagrid

        For Each row As DataGridViewRow In DtSolicitação01.Rows

            If row.Cells(0).Value.ToString.StartsWith("S") Then

                'busca no sistema o markup definido

                Dim CodProd As Integer = row.Cells(0).Value.ToString.Remove(0, 2)

                Dim LqOficina As New LqOficinaDataContext
                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                Dim BuscaMkp = From _mkp In LqOficina.SolicitacaoCadastroPeca
                               Where _mkp.IdSolicitacaoCadastro = CodProd
                               Select _mkp.Markup, _mkp.IdCodExt

                If BuscaMkp.First.Markup > 0 Then

                    'atualiza markup do produto cotado

                    Dim VlrUnitario As Decimal = row.Cells(2).Value
                    Dim Mkp As Decimal = BuscaMkp.First.Markup
                    Dim Revenda As Decimal = VlrUnitario + (VlrUnitario * Mkp)

                    Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_preco_mkp.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdProdutoEst=" & BuscaMkp.First.IdCodExt & "&VlrUnit=" & Revenda & "&QtdadeEstoque=" & 0

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClient = New WebClient()
                    Dim content = syncClient.DownloadString(baseUrl)

                End If

                Dim _IdCorrigido As String = row.Cells(0).Value

                If _IdCorrigido.StartsWith("S_") Then

                    _IdCorrigido = _IdCorrigido.Remove(0, 2)

                End If

                'atualiza nas solicitaçoes de compra que estiverem abertas

                Dim BuscaSolicitacaoCompra = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                             Where sol.IdSolicitacaoCad = _IdCorrigido And sol.IdCotacao = 0
                                             Select sol.IdSolicitacaoCompra

                If BuscaSolicitacaoCompra.Count > 0 Then

                    'atualiza todas as solicitacoes de compra que nao foram identicadas

                    LqFinanceiro.AtualizaSolicitacaoCompraProdutosSol_Cotacao(BuscaSolicitacaoCompra.First, _IdCorrigido)

                End If

                Dim QtEnc As Decimal = row.Cells(3).Value
                Dim ValorUnit As Decimal = row.Cells(4).Value
                Dim CodFornec As String = row.Cells(6).Value

                'verifica se fornecedor é on line

                'busca o id externo no resumo
                Dim _IdExterno As Integer = 0
                Dim _qt As Integer = 0
                Dim _VlrCompra As Decimal = 0
                Dim _VlrComissao As Decimal = 0
                Dim _VlrFrete As Decimal = 0
                Dim _Prazo As Decimal = 0

                For Each row_c As DataGridViewRow In DtResumo.Rows

                    If row_c.Cells(3).Value = row.Cells(0).Value Then
                        _IdExterno = row_c.Cells(2).Value
                        _qt = row_c.Cells(8).Value
                        _VlrCompra = row_c.Cells(6).Value
                        _VlrComissao = row_c.Cells(9).Value
                        _Prazo = row_c.Cells(7).Value
                    ElseIf row_c.Cells(2).Value = row.Cells(0).Value Then
                        _IdExterno = 0
                        _qt = row_c.Cells(8).Value
                        _VlrCompra = row_c.Cells(6).Value
                        _VlrComissao = row_c.Cells(9).Value
                        _Prazo = row_c.Cells(7).Value
                    End If

                Next

                If IdFornecedor01.StartsWith("I_") Then
                    LqFinanceiro.AtualizaCotacaoProdutos(0, _IdCorrigido, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, _VlrCompra, 0, QtEnc, _Prazo, CodFornec)
                Else

                    LqFinanceiro.AtualizaCotacaoProdutos(0, _IdCorrigido, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, _VlrCompra, 0, QtEnc, _Prazo, CodFornec)

                    'gera pedido on line

                    Dim LqComercial As New LqComercialDataContext
                    LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                    Dim BuscaIdCotacao = From cot In LqFinanceiro.Cotacoes
                                         Where cot.IdSolicitacaoCad = _IdCorrigido
                                         Select cot.IdCotacao

                    LqComercial.InserePedidoOnLine(row.Cells(0).Value, _IdExterno, IdFornecedor01, FrmPrincipal.LblChaveEnc.Text, Today.Date, Now.TimeOfDay, True, Today.Date, BuscaIdCotacao.First, False, "1111-11-11", 0, False, "1111-11-11", 0, False, "1111-11-11", 0, False, "1111-11-11", 0, False, "1111-11-11", "", _qt, _VlrCompra, _VlrComissao, _VlrFrete, 0, 0)


                End If

                DtItensBDD.Enabled = False
                Dim LstIndexRemoverItens As New ListBox

                For Each row1 As DataGridViewRow In DtItensBDD.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverItens.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoverCotFinal As New ListBox

                For Each row1 As DataGridViewRow In DtCotFinal.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverCotFinal.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoversoliticaçõesFim As New ListBox

                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                    If row1.Cells(2).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoversoliticaçõesFim.Items.Add(row1.Index)

                    End If

                Next

                'remove encontrados

                For i As Integer = 0 To LstIndexRemoverItens.Items.Count - 1

                    DtItensBDD.Rows.RemoveAt(LstIndexRemoverItens.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoverCotFinal.Items.Count - 1

                    DtCotFinal.Rows.RemoveAt(LstIndexRemoverCotFinal.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoversoliticaçõesFim.Items.Count - 1

                    DtResumoSolicitação.Rows.RemoveAt(LstIndexRemoversoliticaçõesFim.Items(i).ToString)

                Next

                If DtItensBDD.Rows.Count > 0 Then
                    DtItensBDD.Enabled = True
                End If

            Else

                Dim IdProduto As Integer = row.Cells(0).Value

                Dim QtEnc As Decimal = row.Cells(3).Value
                Dim ValorUnit As Decimal = row.Cells(4).Value
                Dim CodFornec As Decimal = row.Cells(6).Value

                'atualiza nas solicitaçoes de compra que estiverem abertas

                Dim BuscaSolicitacaoCompra = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                             Where sol.IdProduto = IdProduto And sol.IdCotacao = 0
                                             Select sol.IdSolicitacaoCompra

                If BuscaSolicitacaoCompra.Count > 0 Then

                    'atualiza todas as solicitacoes de compra que nao foram identicadas

                    LqFinanceiro.AtualizaSolicitacaoCompraProdutos_cotacao(BuscaSolicitacaoCompra.First, IdProduto)

                    'atuliza o numero da solicitacao 

                    Dim BuscaCotacao = From cot In LqFinanceiro.Cotacoes
                                       Where cot.IdProduto = IdProduto And cot.DataCotacao.Value.Date <= Today.Date.AddDays(-7)
                                       Select cot.IdCotacao

                    LqFinanceiro.AtualizaCotacaoProdutosOrdemCompra(IdProduto, 0, BuscaSolicitacaoCompra.First, BuscaCotacao.First)

                End If

                LqFinanceiro.AtualizaCotacaoProdutos(IdProduto, 0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, row.Cells(2).Value, 0, QtEnc, 0, CodFornec)

                DtSolicitação01.Rows.Remove(row)

                Dim LstIndexRemoverItens As New ListBox

                For Each row1 As DataGridViewRow In DtItensBDD.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverItens.Items.Add(row1.Index)

                    End If

                Next

                DtItensBDD.Enabled = False

                Dim LstIndexRemoverCotFinal As New ListBox

                For Each row1 As DataGridViewRow In DtCotFinal.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverCotFinal.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoversoliticaçõesFim As New ListBox

                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                    If row1.Cells(2).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoversoliticaçõesFim.Items.Add(row1.Index)

                    End If

                Next

                'remove encontrados

                For i As Integer = 0 To LstIndexRemoverItens.Items.Count - 1

                    DtItensBDD.Rows.RemoveAt(LstIndexRemoverItens.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoverCotFinal.Items.Count - 1

                    DtItensCotação.Rows.RemoveAt(LstIndexRemoverCotFinal.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoversoliticaçõesFim.Items.Count - 1

                    DtResumoSolicitação.Rows.RemoveAt(LstIndexRemoversoliticaçõesFim.Items(i).ToString)

                Next

                If DtItensBDD.Rows.Count > 0 Then
                    DtItensBDD.Enabled = True
                End If

            End If

        Next

        DtSolicitação01.Rows.Clear()

        IdFornecedor01 = ""
        IdFornecedor02 = ""
        IdFornecedor03 = ""

        PnnSolicitação01.Visible = False
        PnnSolicitação02.Visible = False
        PnnSolicitação03.Visible = False

        'preenche até 3 fornecedores

        Dim LstIdInserido As New ListBox

        For Each row As DataGridViewRow In DtResumoSolicitação.Rows

            If row.Cells(3).Value = False Then

                If IdFornecedor01 = "" Then

                    If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                        LstIdInserido.Items.Add(row.Cells(0).Value)
                        LstIdCodProds.Items.Add(row.Cells(0).Value)

                        'popula o primeiro quadro

                        IdFornecedor01 = row.Cells(0).Value

                        LblSolicitação01.Text = IdFornecedor01

                        DtSolicitação01.Rows.Clear()

                        Dim Total As Decimal = 0

                        For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                            If row1.Cells(0).Value = row.Cells(0).Value Then

                                DtSolicitação01.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                Total += row1.Cells(7).Value

                            End If

                        Next

                        LBlTotal01.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                        PnnSolicitação01.Visible = True

                    End If

                Else

                    If IdFornecedor02 = "" Then

                        'popula o segundo quadro

                        If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                            LstIdInserido.Items.Add(row.Cells(0).Value)

                            'popula o primeiro quadro

                            IdFornecedor02 = row.Cells(0).Value

                            LblSolicitação02.Text = IdFornecedor02

                            DtSolicitação02.Rows.Clear()

                            Dim Total As Decimal = 0

                            For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                    DtSolicitação02.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                    Total += row1.Cells(7).Value

                                End If

                            Next

                            LBlTotal02.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                            PnnSolicitação02.Visible = True

                        End If
                    Else

                        If IdFornecedor03 = "" Then

                            'popula o terceiro quadro

                            If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                                LstIdInserido.Items.Add(row.Cells(0).Value)

                                'popula o primeiro quadro

                                IdFornecedor03 = row.Cells(0).Value

                                LblSolicitação03.Text = IdFornecedor03

                                DtSolicitação03.Rows.Clear()

                                Dim Total As Decimal = 0

                                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                    If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                        DtSolicitação03.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                        Total += row.Cells(5).Value

                                    End If

                                Next

                                LBlTotal03.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                                PnnSolicitação03.Visible = True

                            End If
                        End If

                    End If

                End If

            End If

        Next

        If DtCotFinal.Rows.Count > 0 Then

            DtCotFinal.Rows(0).Selected = True

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            End If

            TabControl2.SelectedIndex = 0

            Me.Cursor = Cursors.Arrow

        Else

            FrmPrincipal.CarregaDashboard()

            Me.Close()

        End If

        If PnnSolicitação01.Visible = False And PnnSolicitação02.Visible = False And PnnSolicitação03.Visible = False Then

            Dim LqOficinaN As New LqOficinaDataContext
            LqOficinaN.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'manda lista pra form de markup

            If DtResumo.Rows.Count = 0 Then

                Me.Close()

            End If

        End If

    End Sub

    Dim LstIdCodProds As New ListBox

    Private Sub Panel23_Paint(sender As Object, e As PaintEventArgs) Handles Panel23.Paint

    End Sub

    Private Sub Panel23_Click(sender As Object, e As EventArgs) Handles Panel23.Click

        'solicita compra

        'varre datagrid

        For Each row As DataGridViewRow In DtSolicitação03.Rows

            If row.Cells(0).Value.ToString.StartsWith("S") Then

                Dim _IdCorrigido As String = row.Cells(0).Value

                If _IdCorrigido.StartsWith("S_") Then

                    _IdCorrigido = _IdCorrigido.Remove(0, 2)

                End If


                Dim QtEnc As Decimal = row.Cells(3).Value
                Dim ValorUnit As Decimal = row.Cells(4).Value
                Dim CodFornec As Decimal = row.Cells(6).Value

                LqFinanceiro.AtualizaCotacaoProdutos(0, _IdCorrigido, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, row.Cells(2).Value, 0, QtEnc, 0, CodFornec)

                Dim LstIndexRemoverItens As New ListBox

                For Each row1 As DataGridViewRow In DtItensBDD.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverItens.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoverCotFinal As New ListBox

                For Each row1 As DataGridViewRow In DtCotFinal.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverCotFinal.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoversoliticaçõesFim As New ListBox

                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                    If row1.Cells(2).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoversoliticaçõesFim.Items.Add(row1.Index)

                    End If

                Next

                'remove encontrados

                For i As Integer = 0 To LstIndexRemoverItens.Items.Count - 1

                    DtItensBDD.Rows.RemoveAt(LstIndexRemoverItens.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoverCotFinal.Items.Count - 1

                    DtItensCotação.Rows.RemoveAt(LstIndexRemoverCotFinal.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoversoliticaçõesFim.Items.Count - 1

                    DtResumoSolicitação.Rows.RemoveAt(LstIndexRemoversoliticaçõesFim.Items(i).ToString)

                Next


            Else


                Dim QtEnc As Decimal = row.Cells(3).Value
                Dim ValorUnit As Decimal = row.Cells(4).Value
                Dim CodFornec As Decimal = row.Cells(6).Value

                LqFinanceiro.AtualizaCotacaoProdutos(row.Cells(0).Value, 0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, row.Cells(2).Value, 0, QtEnc, 0, CodFornec)

                DtSolicitação03.Rows.Remove(row)

                Dim LstIndexRemoverItens As New ListBox

                For Each row1 As DataGridViewRow In DtItensBDD.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverItens.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoverCotFinal As New ListBox

                For Each row1 As DataGridViewRow In DtCotFinal.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverCotFinal.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoversoliticaçõesFim As New ListBox

                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                    If row1.Cells(2).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoversoliticaçõesFim.Items.Add(row1.Index)

                    End If

                Next

                'remove encontrados

                For i As Integer = 0 To LstIndexRemoverItens.Items.Count - 1

                    DtItensBDD.Rows.RemoveAt(LstIndexRemoverItens.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoverCotFinal.Items.Count - 1

                    DtItensCotação.Rows.RemoveAt(LstIndexRemoverCotFinal.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoversoliticaçõesFim.Items.Count - 1

                    DtResumoSolicitação.Rows.RemoveAt(LstIndexRemoversoliticaçõesFim.Items(i).ToString)

                Next

            End If

        Next

        DtSolicitação01.Rows.Clear()

        IdFornecedor01 = ""
        IdFornecedor02 = ""
        IdFornecedor03 = ""

        PnnSolicitação01.Visible = False
        PnnSolicitação02.Visible = False
        PnnSolicitação03.Visible = False

        'preenche até 3 fornecedores

        Dim LstIdInserido As New ListBox

        For Each row As DataGridViewRow In DtResumoSolicitação.Rows

            If row.Cells(3).Value = False Then

                If IdFornecedor01 = "" Then

                    If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                        LstIdInserido.Items.Add(row.Cells(0).Value)
                        LstIdCodProds.Items.Add(row.Cells(0).Value)

                        'popula o primeiro quadro

                        IdFornecedor01 = row.Cells(0).Value

                        LblSolicitação01.Text = IdFornecedor01

                        DtSolicitação01.Rows.Clear()

                        Dim Total As Decimal = 0

                        For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                            If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                DtSolicitação01.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                Total += row1.Cells(7).Value

                            End If

                        Next

                        LBlTotal01.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                        PnnSolicitação01.Visible = True

                    End If

                Else

                    If IdFornecedor02 = "" Then

                        'popula o segundo quadro

                        If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                            LstIdInserido.Items.Add(row.Cells(0).Value)

                            'popula o primeiro quadro

                            IdFornecedor02 = row.Cells(0).Value

                            LblSolicitação02.Text = IdFornecedor02

                            DtSolicitação02.Rows.Clear()

                            Dim Total As Decimal = 0

                            For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                    DtSolicitação02.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                    Total += row1.Cells(7).Value

                                End If

                            Next

                            LBlTotal02.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                            PnnSolicitação02.Visible = True

                        End If
                    Else

                        If IdFornecedor03 = "" Then

                            'popula o terceiro quadro

                            If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                                LstIdInserido.Items.Add(row.Cells(0).Value)

                                'popula o primeiro quadro

                                IdFornecedor03 = row.Cells(0).Value

                                LblSolicitação03.Text = IdFornecedor03

                                DtSolicitação03.Rows.Clear()

                                Dim Total As Decimal = 0

                                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                    If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                        DtSolicitação03.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                        Total += row.Cells(5).Value

                                    End If

                                Next

                                LBlTotal03.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                                PnnSolicitação03.Visible = True

                            End If
                        End If

                    End If

                End If

            End If

        Next

        If DtCotFinal.Rows.Count > 0 Then

            DtCotFinal.Rows(0).Selected = True

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            End If

        Else

            Me.Close()

        End If

    End Sub

    Private Sub Panel18_Paint(sender As Object, e As PaintEventArgs) Handles Panel18.Paint

    End Sub

    Private Sub Panel18_Click(sender As Object, e As EventArgs) Handles Panel18.Click

        'solicita compra

        'varre datagrid

        For Each row As DataGridViewRow In DtSolicitação02.Rows

            If row.Cells(0).Value.ToString.StartsWith("S") Then

                Dim _IdCorrigido As String = row.Cells(0).Value

                If _IdCorrigido.StartsWith("S_") Then

                    _IdCorrigido = _IdCorrigido.Remove(0, 2)

                End If


                Dim QtEnc As Decimal = row.Cells(3).Value
                Dim ValorUnit As Decimal = row.Cells(4).Value
                Dim CodFornec As Decimal = row.Cells(6).Value

                LqFinanceiro.AtualizaCotacaoProdutos(0, _IdCorrigido, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, row.Cells(2).Value, 0, QtEnc, 0, CodFornec)

                Dim LstIndexRemoverItens As New ListBox

                For Each row1 As DataGridViewRow In DtItensBDD.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverItens.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoverCotFinal As New ListBox

                For Each row1 As DataGridViewRow In DtCotFinal.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverCotFinal.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoversoliticaçõesFim As New ListBox

                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                    If row1.Cells(2).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoversoliticaçõesFim.Items.Add(row1.Index)

                    End If

                Next

                'remove encontrados

                For i As Integer = 0 To LstIndexRemoverItens.Items.Count - 1

                    DtItensBDD.Rows.RemoveAt(LstIndexRemoverItens.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoverCotFinal.Items.Count - 1

                    DtItensCotação.Rows.RemoveAt(LstIndexRemoverCotFinal.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoversoliticaçõesFim.Items.Count - 1

                    DtResumoSolicitação.Rows.RemoveAt(LstIndexRemoversoliticaçõesFim.Items(i).ToString)

                Next


            Else

                Dim QtEnc As Decimal = row.Cells(3).Value
                Dim ValorUnit As Decimal = row.Cells(4).Value
                Dim CodFornec As Decimal = row.Cells(6).Value

                LqFinanceiro.AtualizaCotacaoProdutos(row.Cells(0).Value, 0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdFornecedor01, row.Cells(2).Value, 0, QtEnc, 0, CodFornec)

                DtSolicitação02.Rows.Remove(row)

                Dim LstIndexRemoverItens As New ListBox

                For Each row1 As DataGridViewRow In DtItensBDD.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverItens.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoverCotFinal As New ListBox

                For Each row1 As DataGridViewRow In DtCotFinal.Rows

                    If row1.Cells(1).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoverCotFinal.Items.Add(row1.Index)

                    End If

                Next

                Dim LstIndexRemoversoliticaçõesFim As New ListBox

                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                    If row1.Cells(2).Value.ToString = row.Cells(0).Value.ToString Then

                        LstIndexRemoversoliticaçõesFim.Items.Add(row1.Index)

                    End If

                Next

                'remove encontrados

                For i As Integer = 0 To LstIndexRemoverItens.Items.Count - 1

                    DtItensBDD.Rows.RemoveAt(LstIndexRemoverItens.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoverCotFinal.Items.Count - 1

                    DtItensCotação.Rows.RemoveAt(LstIndexRemoverCotFinal.Items(i).ToString)

                Next

                For i As Integer = 0 To LstIndexRemoversoliticaçõesFim.Items.Count - 1

                    DtResumoSolicitação.Rows.RemoveAt(LstIndexRemoversoliticaçõesFim.Items(i).ToString)

                Next

            End If

        Next

        DtSolicitação01.Rows.Clear()

        IdFornecedor01 = ""
        IdFornecedor02 = ""
        IdFornecedor03 = ""

        PnnSolicitação01.Visible = False
        PnnSolicitação02.Visible = False
        PnnSolicitação03.Visible = False

        'preenche até 3 fornecedores

        Dim LstIdInserido As New ListBox

        For Each row As DataGridViewRow In DtResumoSolicitação.Rows

            If row.Cells(3).Value = False Then

                If IdFornecedor01 = "" Then

                    If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                        LstIdInserido.Items.Add(row.Cells(0).Value)
                        LstIdCodProds.Items.Add(row.Cells(0).Value)

                        'popula o primeiro quadro

                        IdFornecedor01 = row.Cells(0).Value

                        LblSolicitação01.Text = IdFornecedor01

                        DtSolicitação01.Rows.Clear()

                        Dim Total As Decimal = 0

                        For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                            If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                DtSolicitação01.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                Total += row1.Cells(7).Value

                            End If

                        Next

                        LBlTotal01.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                        PnnSolicitação01.Visible = True

                    End If

                Else

                    If IdFornecedor02 = "" Then

                        'popula o segundo quadro

                        If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                            LstIdInserido.Items.Add(row.Cells(0).Value)

                            'popula o primeiro quadro

                            IdFornecedor02 = row.Cells(0).Value

                            LblSolicitação02.Text = IdFornecedor02

                            DtSolicitação02.Rows.Clear()

                            Dim Total As Decimal = 0

                            For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                    DtSolicitação02.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                    Total += row1.Cells(7).Value

                                End If

                            Next

                            LBlTotal02.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                            PnnSolicitação02.Visible = True

                        End If
                    Else

                        If IdFornecedor03 = "" Then

                            'popula o terceiro quadro

                            If Not LstIdInserido.Items.Contains(row.Cells(0).Value) Then

                                LstIdInserido.Items.Add(row.Cells(0).Value)

                                'popula o primeiro quadro

                                IdFornecedor03 = row.Cells(0).Value

                                LblSolicitação03.Text = IdFornecedor03

                                DtSolicitação03.Rows.Clear()

                                Dim Total As Decimal = 0

                                For Each row1 As DataGridViewRow In DtResumoSolicitação.Rows

                                    If row1.Cells(0).Value.ToString = row.Cells(0).Value.ToString Then

                                        DtSolicitação03.Rows.Add(row1.Cells(2).Value, row1.Cells(4).Value, row1.Cells(5).Value, row1.Cells(6).Value, row1.Cells(7).Value, ImageList1.Images(6))

                                        Total += row.Cells(5).Value

                                    End If

                                Next

                                LBlTotal03.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                                PnnSolicitação03.Visible = True

                            End If
                        End If

                    End If

                End If

            End If

        Next

        If DtCotFinal.Rows.Count > 0 Then

            DtCotFinal.Rows(0).Selected = True

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            End If

        Else

            Me.Close()

        End If

    End Sub

    Private Sub DtSolicitação03_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtSolicitação03.CellContentClick

        If DtSolicitação03.Columns(e.ColumnIndex).Name = "ClmExcluirPnn03" Then

            'habilita campo do itens cotação

            For Each row As DataGridViewRow In DtCotFinal.Rows

                If row.Cells(1).Value.ToString = DtSolicitação03.Rows(e.RowIndex).Cells(0).Value.ToString Then

                    row.Cells(0).Value = ImageList1.Images(0)

                End If
            Next

            'remove da lista de compra

            For Each row As DataGridViewRow In DtResumoSolicitação.Rows

                If row.Cells(2).Value.ToString = DtSolicitação03.Rows(e.RowIndex).Cells(0).Value.ToString Then

                    DtResumoSolicitação.Rows.Remove(row)

                End If

            Next

            DtSolicitação03.Rows.RemoveAt(e.RowIndex)

            'calcula total

            Dim TotalCar As Decimal

            For Each row As DataGridViewRow In DtSolicitação03.Rows

                TotalCar += row.Cells(4).Value

            Next

            LBlTotal03.Text = FormatCurrency(TotalCar, NumDigitsAfterDecimal:=2)

            If DtSolicitação03.Rows.Count = 0 Then

                PnnSolicitação03.Visible = False

            End If

            NmQtSolicitada.Minimum = 0
            NmQtSolicitada.Value = 0
            LblISacola.Text = 0

            CArregaDash()

            If CmbFornecedores.Items.Count > 0 Then
                NmQtSolicitada.Minimum = DtCotFinal.SelectedCells(7).Value
                NmQtSolicitada.Value = DtCotFinal.SelectedCells(7).Value
            End If

            If PnnSolicitação01.Visible = False And PnnSolicitação02.Visible = False And PnnSolicitação03.Visible = False Then

                TabControl2.SelectedIndex = 0

            End If

        End If

    End Sub

    Private Sub FrmCotações_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        FrmPrincipal.Timer1.Enabled = True

    End Sub

    Dim TempoPIng As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '

        If TempoPIng = 0 Then

            Me.Cursor = Cursors.AppStarting

            TempoPIng = 15

            If TabControl1.SelectedIndex = 0 Then
                Dim ListaCotada As Integer = 0

                For Each row As DataGridViewRow In DtBddIARA.Rows

                    If row.Cells(6).Value = "Sob consulta" Or row.Cells(6).Value = "Cotação solicitada" Then

                        'verifica se cotacao foi respondida

                        Dim Valido As Boolean = False

                        'varre o resumo

                        For Each res As DataGridViewRow In DtResumo.Rows

                            If row.Cells(2).Value = res.Cells(2).Value Then

                                Valido = True

                            End If

                        Next

                        If Valido = True Then
                            Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_solicitacao_cotacao.php?ChaveOficina=" & row.Cells(11).Value & "&IdItem=" & row.Cells(2).Value & "&Vencido=0"
                            Dim sync = New WebClient()
                            Dim content_item = sync.DownloadString(baseUrl_item)

                            Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.SolicitacaoCadExt))(content_item)

                            If read0.Item(0).DataCotacao <> "11-11-1111" Then

                                Dim DataCotacao As Date = read0.Item(0).DataCotacao

                                If Valido = True Then

                                    If DataCotacao.AddDays(7) < Today.Date Then

                                        'apaga a solicitacao do banco de dados

                                        Dim baseUrl_Apaga As String = "http://www.iarasoftware.com.br/apaga_solicitacao_cotacao.php?ChaveOficina=" & row.Cells(11).Value & "&IdItem=" & row.Cells(2).Value
                                        Dim syncApaga = New WebClient()
                                        Dim content_item_Apaga = sync.DownloadString(baseUrl_Apaga)

                                    Else

                                        row.Cells(6).Value = FormatCurrency(read0.Item(0).VlrUnit.Replace(".", ","), NumDigitsAfterDecimal:=2)

                                        'procura no resumo

                                    End If

                                End If

                            End If
                        Else
                            'verifica se existe solicitacao deste item

                            'se houver adiciona 
                            Dim baseUrl_item As String = "http://www.iarasoftware.com.br/consulta_simples_cotacao.php?ChaveOficina=" & row.Cells(11).Value & "&IdItem=" & row.Cells(2).Value
                            Dim sync = New WebClient()
                            Dim content_item = sync.DownloadString(baseUrl_item)

                            Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.SolicitacaoCadExt))(content_item)

                            If read0.Count > 0 Then

                                If read0.Item(0).DataCotacao <> "11-11-1111" Then

                                    Dim DataCotacao As Date = read0.Item(0).DataCotacao

                                    If DataCotacao.AddDays(7) < Today.Date Then

                                        'apaga a solicitacao do banco de dados

                                        Dim baseUrl_Apaga As String = "http://www.iarasoftware.com.br/apaga_solicitacao_cotacao.php?ChaveOficina=" & row.Cells(11).Value & "&IdItem=" & row.Cells(2).Value
                                        Dim syncApaga = New WebClient()
                                        Dim content_item_Apaga = sync.DownloadString(baseUrl_Apaga)

                                    Else

                                        row.Cells(6).Value = FormatCurrency(read0.Item(0).VlrUnit.Replace(".", ","), NumDigitsAfterDecimal:=2)

                                    End If

                                Else

                                    row.Cells(6).Value = "Cotação solicitada"

                                    ListaCotada += 1

                                End If

                            End If

                        End If

                    End If

                Next

                If ListaCotada = 0 Then

                    Timer1.Enabled = False

                End If

            End If

            Me.Cursor = Cursors.Arrow

            Else

                TempoPIng -= 1

        End If

    End Sub

    Private Sub NmQtSolicitada_TextChanged(sender As Object, e As EventArgs) Handles NmQtSolicitada.TextChanged

    End Sub

    Private Sub CmbFornecedores_TextChanged(sender As Object, e As EventArgs) Handles CmbFornecedores.TextChanged


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FrmNovoFornecedor.CkPrestador.Enabled = False

        FrmNovoFornecedor.CkComissionado.Enabled = False

        FrmNovoFornecedor.CkTransportadora.Enabled = False

        FrmNovoFornecedor.Show(Me)

        FrmNovoFornecedor.Panel5.Focus()

        FrmNovoFornecedor.TxtDocumento.Focus()

    End Sub

End Class