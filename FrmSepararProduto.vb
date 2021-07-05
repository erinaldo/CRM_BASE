Imports System.Net

Public Class FrmSepararProduto
    Private Sub DtLiberações_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellContentClick

    End Sub

    Private Sub DtLiberações_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellClick

        If DtLiberações.Rows(e.RowIndex).Cells(10).Value = 0 Then

            LblDescrição.Text = DtLiberações.SelectedCells(0).Value

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim IdProduto As Integer = DtLiberações.SelectedCells(DtLiberações.Columns.Count - 2).Value

            Dim BuscaDadosProduto = From prod In LqBase.Produtos
                                    Where prod.IdProduto = IdProduto
                                    Select prod.Fabricante, prod.CodFabricante

            LblFabricante.Text = BuscaDadosProduto.First.Fabricante
            LblPartNumber.Text = BuscaDadosProduto.First.CodFabricante
            LblQtdadeSeparada.Text = DtLiberações.SelectedCells(1).Value

            BtnSeparar.Enabled = True
            BtnDivergencia.Enabled = True

            'varre e direciona para o endereco onde possui qt disponivel

            Dim QtTot As Integer = DtLiberações.SelectedCells(1).Value

            LblEndereco.Text = ""

            DtEnderecosEncontrados.Rows.Clear()

            For Each linha As DataGridViewRow In DtEndereco.Rows

                If linha.Cells(0).Value.ToString = DtLiberações.Rows(e.RowIndex).Cells(12).Value.ToString Then

                    'varre 1 a 1

                    Dim Limite As Integer = 0
                    Dim LimiteEnd As Integer = linha.Cells(1).Value

                    Dim Encerra As Boolean = False

                    While QtTot > 0 And Encerra = False

                        Limite += 1
                        QtTot -= 1

                        'diminui 1 do item

                        If LimiteEnd >= Limite Then

                            Dim C As Integer = 0

                            For Each it As DataGridViewRow In DtEndereco.Rows
                                For Each it0 As DataGridViewRow In DtEnderecosEncontrados.Rows
                                    If it.Cells(3).Value.ToString = it0.Cells(0).Value.ToString Then
                                        'Dim QtEnc As Integer = it.Cells(1).Value
                                        Dim QtSoma As Integer = Limite
                                        it0.Cells(1).Value = QtSoma
                                        C += 1
                                    End If
                                Next
                            Next

                            If Not linha.Cells(3).Value.ToString.StartsWith("temp") Then

                                'busca dados da armazenagem

                                Dim LqEstoque As New LqEstoqueLocalDataContext
                                LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                Dim BuscaNomeEnd = From ende In LqEstoque.EnderecoEstoqueLocal
                                                   Where ende.IdEndereco = linha.Cells(3).Value
                                                   Select ende.NomeEndereco, ende.IdAndar

                                Dim BuscaAndar = From anda In LqEstoque.AndarEstoqueLocal
                                                 Where anda.IdAndar = BuscaNomeEnd.First.IdAndar
                                                 Select anda.NomeAndar, anda.IdPredio

                                Dim BuscaPredio = From pred In LqEstoque.PredioEstoqueLocal
                                                  Where pred.IdPredio = BuscaAndar.First.IdPredio
                                                  Select pred.NomePredio, pred.IdRua

                                Dim BuscaRua = From rua In LqEstoque.RuasEstoqueLocal
                                               Where rua.IdRua = BuscaPredio.First.IdRua
                                               Select rua.NomeRua, rua.IdQuadra

                                Dim BuscaQuadra = From quad In LqEstoque.QuadrasEstoqueLocal
                                                  Where quad.IdQuadra = BuscaRua.First.IdQuadra
                                                  Select quad.NomeQuadra, quad.IdEstoque

                                Dim BuscaEstoque = From est In LqEstoque.EstoquesLocais
                                                   Where est.IdEstoque = BuscaQuadra.First.IdEstoque
                                                   Select est.NomeEstoque

                                DtEnderecosEncontrados.Rows.Add(BuscaEstoque.First & "." & BuscaQuadra.First.NomeQuadra & "." & BuscaRua.First.NomeRua & "." & BuscaPredio.First.NomePredio & "." & BuscaAndar.First.NomeAndar & "." & BuscaNomeEnd.First.NomeEndereco, linha.Cells(3).Value, Limite)

                            Else

                                DtEnderecosEncontrados.Rows.Add(linha.Cells(3).Value, linha.Cells(3).Value, Limite)

                            End If


                        Else

                            Encerra = True

                        End If

                    End While

                End If

            Next

        Else

            MsgBox("Este item já foi separado.")

        End If

    End Sub

    Private Sub BtnSeparar_Click(sender As Object, e As EventArgs) Handles BtnSeparar.Click

        DtLiberações.Rows(DtLiberações.SelectedCells(0).RowIndex).Cells(8).Value = My.Resources.gostar
        DtLiberações.Rows(DtLiberações.SelectedCells(0).RowIndex).Cells(10).Value = 1

        For Each row As DataGridViewRow In DtEnderecosEncontrados.Rows
            DtEntregar.Rows.Add(DtLiberações.Rows(DtLiberações.SelectedCells(0).RowIndex).Cells(12).Value, row.Cells(1).Value, row.Cells(0).Value, LblDescrição.Text, row.Cells(1).Value)
        Next

        'baixa do endereco

        For Each row As DataGridViewRow In DtEnderecosEncontrados.Rows

            For Each row0 As DataGridViewRow In DtEndereco.Rows

                If row0.Cells(3).Value = row.Cells(0).Value Then

                    'qtdade a baixar do estoque

                    row0.Cells(2).Value += row.Cells(1).Value

                End If

            Next

        Next

        'limpa todos os campos

        BtnSeparar.Enabled = False
        BtnDivergencia.Enabled = False

        LblDescrição.Text = ""
        LblFabricante.Text = ""
        LblPartNumber.Text = ""
        LblQtdadeSeparada.Text = ""

        DtEnderecosEncontrados.Rows.Clear()

        'verifica se pode finalizar

        Dim Qt As Integer = 0

        For Each item As DataGridViewRow In DtLiberações.Rows

            If item.Cells(10).Value = 1 Then

                Qt += 1

            End If

        Next

        If Qt = DtLiberações.Rows.Count Then

            BtnEntregar.Enabled = True

        Else

            BtnEntregar.Enabled = False

        End If

        'verifica se existem abertas

        Dim Verifica As Boolean = True

        For Each linha As DataGridViewRow In DtLiberações.Rows
            If linha.Cells(10).Value = 0 Then
                Verifica = False
            End If
        Next


        Dim IdProduto As Integer = DtLiberações.SelectedCells(12).Value

        Dim DestinoOrcamento As Integer = DtLiberações.SelectedCells(13).Value.ToString.Remove(0, 4)


        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaOrcamento = From orc In LqComercial.ProdutosOrcamento
                             Where orc.IdOrcamento = DestinoOrcamento And orc.IdProduto = IdProduto
                             Select orc.IdImagemAval

        'busca numero de orçamento externo

        Dim BuscaORcamentoExt = From ext In LqComercial.Orcamentos
                                Where ext.IdOrcamento = DestinoOrcamento
                                Select ext.IdCorOrcamentoExt

        DestinoOrcamento = BuscaORcamentoExt.First

        If BuscaOrcamento.Count > 0 Then

            Dim BuscaIdProduto = From orc In LqBase.Produtos
                                 Where orc.IdProduto = IdProduto
                                 Select orc.IdProdutoExt

            'atualiza pra inicio

            Dim baseUrlStatus As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_3_0.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & DestinoOrcamento & "&IdItem=" & BuscaIdProduto.First

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientStatus = New WebClient()
            Dim contentStatus = syncClientStatus.DownloadString(baseUrlStatus)
            'verifica endereço

        Else

            'busca pela solicitacao de cadastro se houver

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim BuscaSolicitacaoCadastro = From sol In LqOficina.SolicitacaoCadastroPeca
                                           Where sol.IdSolicitacaoCadastro = IdProduto
                                           Select sol.IdCodExt

            If BuscaSolicitacaoCadastro.Count > 0 Then

                'busca id externo do orçamento

                'atualiza pra inicio

                Dim baseUrlStatus As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_3_0.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & DestinoOrcamento & "&IdItem=" & BuscaSolicitacaoCadastro.First

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientStatus = New WebClient()
                Dim contentStatus = syncClientStatus.DownloadString(baseUrlStatus)
                'verifica endereço

            End If
        End If

        If Verifica = False Then

            If DtLiberações.SelectedCells(0).RowIndex + 1 <= DtLiberações.Rows.Count - 1 Then
                DtLiberações.Rows(DtLiberações.SelectedCells(0).RowIndex + 1).Selected = True
                DtLiberações.FirstDisplayedCell = DtLiberações.Rows(DtLiberações.SelectedCells(0).RowIndex).Cells(0)
                Dim RowIndex As Integer = DtLiberações.SelectedCells(0).RowIndex

                If DtLiberações.Rows(RowIndex).Cells(10).Value = 0 Then

                    LblDescrição.Text = DtLiberações.Rows(RowIndex).Cells(0).Value

                    Dim _IdProduto As Integer = DtLiberações.Rows(RowIndex).Cells(DtLiberações.Columns.Count - 1).Value

                    Dim BuscaDadosProduto = From prod In LqBase.Produtos
                                            Where prod.IdProduto = _IdProduto
                                            Select prod.Fabricante, prod.CodFabricante

                    LblFabricante.Text = BuscaDadosProduto.First.Fabricante
                    LblPartNumber.Text = BuscaDadosProduto.First.CodFabricante
                    LblQtdadeSeparada.Text = DtLiberações.Rows(RowIndex).Cells(1).Value

                    BtnSeparar.Enabled = True
                    BtnDivergencia.Enabled = True

                    'varre e direciona para o endereco onde possui qt disponivel

                    Dim QtTot As Integer = DtLiberações.Rows(RowIndex).Cells(1).Value

                    LblEndereco.Text = ""

                    DtEnderecosEncontrados.Rows.Clear()

                    For Each linha As DataGridViewRow In DtEndereco.Rows

                        If linha.Cells(0).Value.ToString = DtLiberações.Rows(RowIndex).Cells(12).Value.ToString Then

                            'varre 1 a 1

                            Dim Limite As Integer = 0
                            Dim LimiteEnd As Integer = linha.Cells(1).Value

                            Dim Encerra As Boolean = False

                            While QtTot > 0 And Encerra = False

                                Limite += 1
                                QtTot -= 1

                                'diminui 1 do item

                                If LimiteEnd >= Limite Then

                                    Dim C As Integer = 0

                                    For Each it As DataGridViewRow In DtEndereco.Rows
                                        For Each it0 As DataGridViewRow In DtEnderecosEncontrados.Rows
                                            If it.Cells(3).Value.ToString = it0.Cells(0).Value.ToString Then
                                                'Dim QtEnc As Integer = it.Cells(1).Value
                                                Dim QtSoma As Integer = Limite
                                                it0.Cells(1).Value = QtSoma
                                                C += 1
                                            End If
                                        Next
                                    Next

                                    If C = 0 Then
                                        DtEnderecosEncontrados.Rows.Add(linha.Cells(3).Value, Limite)
                                    End If

                                Else

                                    Encerra = True

                                End If

                            End While

                        End If

                    Next

                Else

                    MsgBox("Este item já foi separado.")

                End If

            Else
                DtLiberações.Rows(0).Selected = True
                DtLiberações.FirstDisplayedCell = DtLiberações.Rows(0).Cells(0)
                Dim RowIndex As Integer = 0

                If DtLiberações.Rows(RowIndex).Cells(10).Value = 0 Then

                    LblDescrição.Text = DtLiberações.Rows(RowIndex).Cells(0).Value

                    Dim _IdProduto As Integer = DtLiberações.Rows(RowIndex).Cells(DtLiberações.Columns.Count - 1).Value

                    Dim BuscaDadosProduto = From prod In LqBase.Produtos
                                            Where prod.IdProduto = _IdProduto
                                            Select prod.Fabricante, prod.CodFabricante

                    LblFabricante.Text = BuscaDadosProduto.First.Fabricante
                    LblPartNumber.Text = BuscaDadosProduto.First.CodFabricante
                    LblQtdadeSeparada.Text = DtLiberações.Rows(RowIndex).Cells(1).Value

                    BtnSeparar.Enabled = True
                    BtnDivergencia.Enabled = True

                    'varre e direciona para o endereco onde possui qt disponivel

                    Dim QtTot As Integer = DtLiberações.Rows(RowIndex).Cells(1).Value

                    LblEndereco.Text = ""

                    DtEnderecosEncontrados.Rows.Clear()

                    For Each linha As DataGridViewRow In DtEndereco.Rows

                        If linha.Cells(0).Value.ToString = DtLiberações.Rows(RowIndex).Cells(12).Value.ToString Then

                            'varre 1 a 1

                            Dim Limite As Integer = 0
                            Dim LimiteEnd As Integer = linha.Cells(1).Value

                            Dim Encerra As Boolean = False

                            While QtTot > 0 And Encerra = False

                                Limite += 1
                                QtTot -= 1

                                'diminui 1 do item

                                If LimiteEnd >= Limite Then

                                    Dim C As Integer = 0

                                    For Each it As DataGridViewRow In DtEndereco.Rows
                                        For Each it0 As DataGridViewRow In DtEnderecosEncontrados.Rows
                                            If it.Cells(3).Value.ToString = it0.Cells(0).Value.ToString Then
                                                'Dim QtEnc As Integer = it.Cells(1).Value
                                                Dim QtSoma As Integer = Limite
                                                it0.Cells(1).Value = QtSoma
                                                C += 1
                                            End If
                                        Next
                                    Next

                                    If Not linha.Cells(3).Value.ToString.StartsWith("temp") Then

                                        'busca dados da armazenagem

                                        Dim LqEstoque As New LqEstoqueLocalDataContext
                                        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                        Dim BuscaNomeEnd = From ende In LqEstoque.EnderecoEstoqueLocal
                                                           Where ende.IdEndereco = linha.Cells(3).Value
                                                           Select ende.NomeEndereco, ende.IdAndar

                                        Dim BuscaAndar = From anda In LqEstoque.AndarEstoqueLocal
                                                         Where anda.IdAndar = BuscaNomeEnd.First.IdAndar
                                                         Select anda.NomeAndar, anda.IdPredio

                                        Dim BuscaPredio = From pred In LqEstoque.PredioEstoqueLocal
                                                          Where pred.IdPredio = BuscaAndar.First.IdPredio
                                                          Select pred.NomePredio, pred.IdRua

                                        Dim BuscaRua = From rua In LqEstoque.RuasEstoqueLocal
                                                       Where rua.IdRua = BuscaPredio.First.IdRua
                                                       Select rua.NomeRua, rua.IdQuadra

                                        Dim BuscaQuadra = From quad In LqEstoque.QuadrasEstoqueLocal
                                                          Where quad.IdQuadra = BuscaRua.First.IdQuadra
                                                          Select quad.NomeQuadra, quad.IdEstoque

                                        Dim BuscaEstoque = From est In LqEstoque.EstoquesLocais
                                                           Where est.IdEstoque = BuscaQuadra.First.IdEstoque
                                                           Select est.NomeEstoque

                                        DtEnderecosEncontrados.Rows.Add(BuscaEstoque.First & "." & BuscaQuadra.First.NomeQuadra & "." & BuscaRua.First.NomeRua & "." & BuscaPredio.First.NomePredio & "." & BuscaAndar.First.NomeAndar & "." & BuscaNomeEnd.First.NomeEndereco, linha.Cells(3).Value, Limite)

                                    Else

                                        DtEnderecosEncontrados.Rows.Add(linha.Cells(3).Value, linha.Cells(3).Value, Limite)

                                    End If


                                Else

                                    Encerra = True

                                End If

                            End While

                        End If

                    Next

                Else

                    MsgBox("Este item já foi separado.")

                End If
            End If

        Else

            BtnEntregar.PerformClick()

        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BtnEntregar_Click(sender As Object, e As EventArgs) Handles BtnEntregar.Click

        'popula grid

        Dim Qt As Integer = 0

        For Each row As DataGridViewRow In DtEntregar.Rows

            'monta as solicitaçoes de acordo com a origem

            Dim Contado As Boolean = False

            For Each row0 As DataGridViewRow In FrmDespachoSolicitações.DtRetirada.Rows

                Dim LqEstoque As New LqEstoqueLocalDataContext
                LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                'carrega solicitaões para o solicitante

                Dim BuscaSoliciatçõesNaoRetirada = From ret In LqEstoque.SolicitacaoProdutosEstoque
                                                   Where ret.IdSolicitacao = Val(row0.Cells(1).Value)
                                                   Select ret.Qtdade, ret.IdProduto, ret.IdSolicitacaoCad, ret.IdSolicitacao

                If BuscaSoliciatçõesNaoRetirada.First.IdProduto = 0 Then

                    If Contado = False Then
                        Qt += row.Cells(1).Value
                        Contado = True
                    End If

                    'verifica novamente, mas com código de solicitacao
                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaSolicitacaoCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                              Where cad.IdSolicitacaoCadastro = BuscaSoliciatçõesNaoRetirada.First.IdSolicitacaoCad
                                              Select cad.IdCodCad

                    If BuscaSolicitacaoCad.First = row.Cells(0).Value Then

                        'baixa a quantidade referida

                        Qt -= row0.Cells(3).Value

                        If row0.Cells(4).Value.ToString = "Aguardando retirada" Then
                            FrmEntregar.DtLiberações.Rows.Add(row.Cells(3).Value, BuscaSoliciatçõesNaoRetirada.First.Qtdade, row.Cells(2).Value, FrmPrincipal.LblNomeUsuario.Text, Val(row0.Cells(1).Value), My.Resources.delivery, 0, row.Cells(4).Value)
                        End If

                    End If

                Else

                    If Contado = False Then
                        Qt += row.Cells(1).Value
                        Contado = True
                    End If

                    If BuscaSoliciatçõesNaoRetirada.First.IdProduto = row.Cells(0).Value Then

                        'baixa a quantidade referida

                        Qt -= row0.Cells(3).Value

                        If row0.Cells(4).Value.ToString = "Aguardando retirada" Then
                            FrmEntregar.DtLiberações.Rows.Add(row.Cells(3).Value, BuscaSoliciatçõesNaoRetirada.First.Qtdade, row.Cells(2).Value, FrmPrincipal.LblNomeUsuario.Text, Val(row0.Cells(1).Value), FrmEntregar.ImageList1.Images(1), 0, row.Cells(4).Value)
                        End If

                    End If

                End If

            Next

        Next

        FrmEntregar.Show(Me)

    End Sub

    Private Sub FrmSepararProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DtLiberações_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellEnter

        If DtLiberações.Enabled = True Then

            If DtLiberações.Rows(e.RowIndex).Cells(10).Value = 0 Then

                LblDescrição.Text = DtLiberações.Rows(e.RowIndex).Cells(0).Value

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim IdProduto As Integer = DtLiberações.Rows(e.RowIndex).Cells(DtLiberações.Columns.Count - 2).Value

                Dim IdOrcamento As Integer = DtLiberações.Rows(e.RowIndex).Cells(DtLiberações.Columns.Count - 1).Value.remove(0, 4)

                Dim BuscaDadosProduto = From prod In LqBase.Produtos
                                            Where prod.IdProduto = IdProduto
                                            Select prod.Fabricante, prod.CodFabricante

                    If BuscaDadosProduto.Count > 0 Then
                        LblFabricante.Text = BuscaDadosProduto.First.Fabricante
                        LblPartNumber.Text = BuscaDadosProduto.First.CodFabricante
                    End If

                    LblQtdadeSeparada.Text = DtLiberações.Rows(e.RowIndex).Cells(1).Value

                    BtnSeparar.Enabled = True
                    BtnDivergencia.Enabled = True

                    'varre e direciona para o endereco onde possui qt disponivel

                    Dim QtTot As Integer = DtLiberações.Rows(e.RowIndex).Cells(1).Value

                    LblEndereco.Text = ""

                    DtEnderecosEncontrados.Rows.Clear()

                    For Each linha As DataGridViewRow In DtEndereco.Rows

                        If linha.Cells(0).Value.ToString = DtLiberações.Rows(e.RowIndex).Cells(12).Value.ToString Then

                            'varre 1 a 1

                            Dim Limite As Integer = 0
                            Dim LimiteEnd As Integer = linha.Cells(1).Value

                            Dim Encerra As Boolean = False

                            While QtTot > 0 And Encerra = False

                                Limite += 1
                                QtTot -= 1

                            'diminui 1 do item

                            If LimiteEnd >= Limite Then

                                Dim C As Integer = 0

                                For Each it As DataGridViewRow In DtEndereco.Rows
                                    For Each it0 As DataGridViewRow In DtEnderecosEncontrados.Rows
                                        If it.Cells(3).Value.ToString = it0.Cells(0).Value.ToString Then
                                            'Dim QtEnc As Integer = it.Cells(1).Value
                                            Dim QtSoma As Integer = Limite
                                            it0.Cells(1).Value = QtSoma
                                            C += 1
                                        End If
                                    Next
                                Next

                                If C = 0 Then
                                    'busca nome do endereco

                                    If Not linha.Cells(3).Value.ToString.StartsWith("temp") Then

                                        'busca dados da armazenagem

                                        Dim LqEstoque As New LqEstoqueLocalDataContext
                                        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                        Dim _IdEndereco As Integer = linha.Cells(3).Value

                                        Dim BuscaNomeEnd = From ende In LqEstoque.EnderecoEstoqueLocal
                                                           Where ende.IdEndereco = _IdEndereco
                                                           Select ende.NomeEndereco, ende.IdAndar

                                        Dim BuscaAndar = From anda In LqEstoque.AndarEstoqueLocal
                                                         Where anda.IdAndar = BuscaNomeEnd.First.IdAndar
                                                         Select anda.NomeAndar, anda.IdPredio

                                        Dim BuscaPredio = From pred In LqEstoque.PredioEstoqueLocal
                                                          Where pred.IdPredio = BuscaAndar.First.IdPredio
                                                          Select pred.NomePredio, pred.IdRua

                                        Dim BuscaRua = From rua In LqEstoque.RuasEstoqueLocal
                                                       Where rua.IdRua = BuscaPredio.First.IdRua
                                                       Select rua.NomeRua, rua.IdQuadra

                                        Dim BuscaQuadra = From quad In LqEstoque.QuadrasEstoqueLocal
                                                          Where quad.IdQuadra = BuscaRua.First.IdQuadra
                                                          Select quad.NomeQuadra, quad.IdEstoque

                                        Dim BuscaEstoque = From est In LqEstoque.EstoquesLocais
                                                           Where est.IdEstoque = BuscaQuadra.First.IdEstoque
                                                           Select est.NomeEstoque

                                        DtEnderecosEncontrados.Rows.Add(BuscaEstoque.First & "." & BuscaQuadra.First.NomeQuadra & "." & BuscaRua.First.NomeRua & "." & BuscaPredio.First.NomePredio & "." & BuscaAndar.First.NomeAndar & "." & BuscaNomeEnd.First.NomeEndereco, linha.Cells(3).Value, Limite)

                                    Else

                                        DtEnderecosEncontrados.Rows.Add(linha.Cells(3).Value, linha.Cells(3).Value, Limite)

                                    End If

                                End If

                            Else

                                Encerra = True

                                End If

                            End While

                        End If

                    Next

                Else

                    MsgBox("Este item já foi separado.")

            End If

        End If

    End Sub
End Class