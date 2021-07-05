Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text

Public Class FrmReceberMercadoria
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext
    Dim LqBase As New DtCadastroDataContext
    Dim LqEstoque As New LqEstoqueLocalDataContext

    Public LstIdItens As New ListBox

    Public LStCadastrosProdutos As New ListBox

    Private Sub FrmReceberMercadoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'verifica quem da lista nao possui associação

        CmbItensSolicitados.Items.Clear()
        LstIdItens.Items.Clear()

        Dim LqOficina As New LqOficinaDataContext

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        For Each row As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

            Dim BuscaSolicitacoes = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                    Where sol.NF = 0 And sol.IdAutorizador > 0
                                    Select sol.IdProduto, sol.IdCotacao, sol.IdSolicitacaoCad

            'verifica itens para este fornecedor

            For Each row1 In BuscaSolicitacoes.ToList

                'busca a cotação

                Dim BuscaCt = From ct In LqFinanceiro.Cotacoes
                              Where ct.IdCotacao = row1.IdCotacao And ct.IdFornecedor Like FrmProdutosNfRecebimento.LblCodFornec.Text
                              Select ct.IdProduto, ct.IdSolicitacaoCad

                If BuscaCt.Count > 0 Then

                    If BuscaCt.First.IdProduto <> 0 Then

                        'busca itens

                        Dim BuscaProduto = From prod In LqBase.Produtos
                                           Where prod.IdProduto = BuscaCt.First.IdProduto
                                           Select prod.Descricao

                        If Not CmbItensSolicitados.Items.Contains(BuscaProduto.First) Then

                            'verifica se ja foi inserido 

                            Dim _C As Integer = 0

                            For Each rowEsp As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

                                If rowEsp.Cells(1).Value.ToString = BuscaCt.First.IdProduto.ToString Then
                                    _C += 1

                                    LstIdItens.Items.Add(BuscaCt.First.IdProduto)
                                    CmbItensSolicitados.Items.Add(BuscaProduto.First)

                                End If

                            Next

                            If _C = 0 Then

                                LstIdItens.Items.Add(BuscaCt.First.IdProduto)
                                CmbItensSolicitados.Items.Add(BuscaProduto.First)

                            End If

                        End If

                    Else

                        'verfica se já foi cadastrado no sistem

                        Dim buscaCodCad = From cod In LqOficina.SolicitacaoCadastroPeca
                                          Where cod.IdSolicitacaoCadastro = row1.IdSolicitacaoCad
                                          Select cod.IdCodCad

                        If buscaCodCad.First = 0 Then
                            LStCadastrosProdutos.Items.Add(row1.IdSolicitacaoCad)
                        End If

                    End If

                End If

            Next

        Next

    End Sub

    Private Sub CmbItensSolicitados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbItensSolicitados.SelectedIndexChanged

        If CmbItensSolicitados.Items.Contains(CmbItensSolicitados.Text) Then

            Dim BuscaProduto = From prod In LqBase.Produtos
                               Where prod.IdProduto = LstIdItens.Items(CmbItensSolicitados.SelectedIndex).ToString
                               Select prod.VendaDireta, prod.UsoInterno, prod.Insumo, prod.Reaproveitamento, prod.ControleValidade, prod.UnCompra, prod.UnVenda, prod.CodFabricante, prod.Altura, prod.Largura, prod.Profundidade, prod.Peso, prod.Categoria, prod.SubCategoria, prod.Fabricante

            LblUnidadeEntrada.Text = BuscaProduto.First.UnCompra
            LblUnidadeSaida.Text = BuscaProduto.First.UnVenda
            LblCodFabricante.Text = BuscaProduto.First.CodFabricante
            LblCategoria.Text = BuscaProduto.First.Categoria
            LblSubCategoria.Text = BuscaProduto.First.SubCategoria
            LblFabricante.Text = BuscaProduto.First.Fabricante

            Dim Cm As String = ""

            If BuscaProduto.First.VendaDireta = True Then
                Cm = "Venda direta"
            End If

            If BuscaProduto.First.Insumo = True Then

                If Cm = "" Then
                    Cm = "Insumo"
                Else
                    Cm &= " / Insumo"
                End If

            End If

            If BuscaProduto.First.UsoInterno = True Then

                If Cm = "" Then
                    Cm = "Uso interno"
                Else
                    Cm &= " / Uso interno"
                End If

            End If

            If BuscaProduto.First.Reaproveitamento = True Then

                If Cm = "" Then
                    Cm = "Reaproveitamento"
                Else
                    Cm &= " / Reaproveitamento"
                End If

            End If

            'vincula ao forncedor

            TxtAltura.Value = BuscaProduto.First.Altura
            TxtLargura.Value = BuscaProduto.First.Largura
            TxtProfundidade.Value = BuscaProduto.First.Profundidade
            TxtPeso.Value = BuscaProduto.First.Peso

            'varre os enderecos que cabem o produto

            Dim M3Nec As Decimal = ((BuscaProduto.First.Altura * BuscaProduto.First.Largura) * BuscaProduto.First.Profundidade)

            Dim MenorTamanhoIndex As Integer
            Dim MenorTamanhoEnc As Decimal

            For Each row As DataGridViewRow In DtEsperados.Rows

                'verifica tamamnho

                If MenorTamanhoEnc > row.Cells(2).Value Then

                    If row.Cells(2).Value >= M3Nec Then

                        If row.Cells(3).Value >= BuscaProduto.First.Peso Then

                            'row.Visible = True

                            MenorTamanhoEnc = row.Cells(2).Value
                            MenorTamanhoIndex = row.Index

                        End If

                    End If

                End If

            Next

            'habilita campo

            If NumericUpDown1.Value > 0 Then
                TxtAltura.Enabled = True
            End If

        End If

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged

        If NumericUpDown1.Value > 0 Then

            CmbItensSolicitados.Enabled = True

            CalculaM3()

            If CmbItensSolicitados.Visible = True Then

                Dim LstRemover As New ListBox

                For i As Integer = 0 To LstIdItens.Items.Count - 1

                    If FrmProdutosNfRecebimento.LstIgnorar.Items.Contains(LstIdItens.Items(i).ToString) Then

                        LstRemover.Items.Add(i)
                        CmbItensSolicitados.Items.RemoveAt(i)

                    End If

                Next

                For i As Integer = 0 To LstRemover.Items.Count - 1
                    LstIdItens.Items.RemoveAt(LstRemover.Items(i).ToString)
                Next

            End If

            'verifica se valores foram preenhidos

            If CmbItensSolicitados.Visible = False Then

                TxtAltura.Enabled = True

            End If

            If TxtLargura.Value > 0 Then

                TxtLargura.Enabled = True

            End If

            If TxtProfundidade.Value > 0 Then

                TxtProfundidade.Enabled = True
                TxtPeso.Enabled = True

            End If


        Else

            BtnProcurarEnderecos.Enabled = False

            DtEsperados.Rows.Clear()

        End If

    End Sub

    Public Sub CalculaM3()

        DtEsperados.Rows.Clear()

        'verifica se tem sobra
        Dim Qt As Decimal = NumericUpDown1.Value

        Dim LimiteAltura As Decimal = 200
        Dim LimiteLargura As Decimal = 100
        Dim LimiteProfundidade As Decimal = 100
        Dim LimitePeso As Decimal = 1000

        Dim LimiteCm3 As Decimal = LimiteAltura * LimiteLargura * LimiteProfundidade

        Dim Armazenado As Integer = 0
        Dim PesoArmazenado As Decimal = 0

        If TxtAltura.Value > 0 And TxtLargura.Value > 0 And TxtProfundidade.Value > 0 And TxtPeso.Value Then

            While Armazenado < Qt

                Dim ValorAltura As Decimal = TxtAltura.Value / 10
                Dim ValorLargura As Decimal = TxtLargura.Value / 10
                Dim ValorProfundidade As Decimal = TxtProfundidade.Value / 10
                Dim ValorPeso As Decimal = TxtPeso.Value

                'verifica arrumaçao possivel

                Dim m2 As Decimal = (ValorProfundidade * ValorLargura) * ValorAltura

                'Busca um endereço que caiba o lote

                LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                Dim BuscaLimite = From lim In LqEstoque.EnderecoEstoqueLocal
                                  Where lim.IdEndereco Like "*" And lim.Usado = False
                                  Select lim.IdEndereco, lim.Altura, lim.Largura, lim.Profundidade, lim.Peso, lim.NomeEndereco, lim.IdEstoque

                Dim LimiteM2 As Decimal

                Dim _NomeEndereco As String = ""
                Dim _NomeEstoque As String = ""
                Dim _idEnderecoEstoque As Integer = 0

                If BuscaLimite.Count > 0 Then

                    LimiteM2 = (BuscaLimite.First.Profundidade * BuscaLimite.First.Largura) * BuscaLimite.First.Altura
                    _NomeEndereco = BuscaLimite.First.NomeEndereco
                    _NomeEstoque = ""
                    _idEnderecoEstoque = BuscaLimite.First.IdEndereco

                Else

                    LimiteM2 = (LimiteProfundidade * LimiteLargura) * LimiteAltura
                    _NomeEndereco = "temp_" & Today.Date.Day & Today.Date.Month & Today.Date.Year & Now.TimeOfDay.TotalMilliseconds.ToString
                    _NomeEstoque = "temporário"
                    _idEnderecoEstoque = 0

                End If

                'verifica a quantidade que cabe na pilha
                Dim QtM2 As Integer = LimiteM2 / m2

                Dim ValorCm3 As Decimal = ValorAltura * ValorLargura * ValorProfundidade

                Dim QtLimiteLote As Decimal = (LimiteCm3 / ValorCm3)

                'cria estoque temporario para armazenamento

                Dim QtArm As Integer = 0
                Dim PesoArm As Integer = 0

                While QtArm < QtM2 And PesoArm < LimitePeso
                    QtArm += 1
                    PesoArm += ValorPeso
                End While

                If Armazenado + QtArm > Qt Then
                    QtArm = Qt - Armazenado
                    Armazenado = Qt
                End If

                DtEsperados.Rows.Add(_NomeEstoque, _NomeEndereco, LimiteM2, 0, QtArm, _idEnderecoEstoque, My.Resources.alert_icon_icons_com_52395)
                DtEsperados.Columns(6).Width = 15

                Armazenado += QtArm

            End While

        End If

    End Sub
    Private Sub TxtAltura_ValueChanged(sender As Object, e As EventArgs) Handles TxtAltura.ValueChanged

        If TxtAltura.Value > 0 Then

            CalculaM3()

            If NumericUpDown1.Value > 0 Then
                TxtLargura.Enabled = True
            End If

        Else

            TxtLargura.Value = 0
            TxtLargura.Enabled = False

        End If

    End Sub

    Private Sub TxtLargura_ValueChanged(sender As Object, e As EventArgs) Handles TxtLargura.ValueChanged

        If TxtLargura.Value > 0 Then

            CalculaM3()

            If NumericUpDown1.Value > 0 Then
                TxtProfundidade.Enabled = True
            End If

        Else

            TxtProfundidade.Value = 0
            TxtProfundidade.Enabled = False

        End If

    End Sub

    Private Sub TxtProfundidade_ValueChanged(sender As Object, e As EventArgs) Handles TxtProfundidade.ValueChanged

        If TxtProfundidade.Value > 0 Then

            CalculaM3()

            If NumericUpDown1.Value > 0 Then
                TxtPeso.Enabled = True
            End If

        Else

            TxtPeso.Value = 0
            TxtPeso.Enabled = False

        End If

    End Sub

    Private Sub TxtPeso_ValueChanged(sender As Object, e As EventArgs) Handles TxtPeso.ValueChanged

        If TxtPeso.Value > 0 Then

            CalculaM3()

            BttAprovarOrc.Enabled = True

        Else

            BttAprovarOrc.Enabled = False

        End If

    End Sub

    Dim LqCadastro As New DtCadastroDataContext
    Public _IdProduto As Integer
    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        LqCadastro.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'insere NF
        Dim _NumNf As String = ""

        If FrmProdutosNfRecebimento.TxtNf.Visible = True Then
            _NumNf = FrmProdutosNfRecebimento.TxtNf.Text
        Else
            _NumNf = FrmProdutosNfRecebimento.LblNumNf.Text
        End If

        'atualiza dados do item

        If CmbItensSolicitados.Visible = True Then
            LqCadastro.AtualizaDadosNFProduto(LstIdItens.Items(CmbItensSolicitados.SelectedIndex).ToString, LblEan.Text, LblNCM.Text, TxtAltura.Value, TxtLargura.Value, TxtProfundidade.Value, TxtPeso.Value)
        Else
            LqCadastro.AtualizaDadosNFProduto(_IdProduto, LblEan.Text, LblNCM.Text, TxtAltura.Value, TxtLargura.Value, TxtProfundidade.Value, TxtPeso.Value)
        End If

        'atualiza dados do fornecedor

        'insere vinculo do item ao fornecedor
        If CmbItensSolicitados.Visible = True Then

            LqCadastro.InsereVinculoProdutoFornecedor(LstIdItens.Items(CmbItensSolicitados.SelectedIndex).ToString, FrmProdutosNfRecebimento.LblCodFornec.Text, LblCodFornec.Text)

        End If


        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim _IdProdutoString As String = _IdProduto

        Dim BuscaSolicitacao = From sol In LqOficina.SolicitacaoCadastroPeca
                               Where sol.IdCodCad = _IdProduto
                               Select sol.IdSolicitacaoCadastro

        If BuscaSolicitacao.Count > 0 Then
            Dim baseUrlProdSolCad As String = "http://www.iarasoftware.com.br/create_solicitacao_nf.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&NumNf=" & _NumNf & "&IdFornecedor=" & FrmProdutosNfRecebimento.LblCodFornec.Text & "&DescricaoString=" _
                    & _NumNf & " - S" & BuscaSolicitacao.First & "&ImgDoc=ND"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientProdSolCad = New WebClient()
            Dim contentProdSolCad = syncClientProdSolCad.DownloadString(baseUrlProdSolCad)
            _IdProdutoString = "S" & BuscaSolicitacao.First

            Dim baseUrlAtualizaNf As String = "http://www.iarasoftware.com.br/atualiza_dados_nf.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                    & "&NumNf=" & _NumNf & "&IdProdutoOrcamento=" & _IdProdutoString

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientAtualizaNf = New WebClient()
            Dim contentAtualizaNf = syncClientAtualizaNf.DownloadString(baseUrlAtualizaNf)

        End If

        'atualiza recebimento

        Dim Res As Integer = NumericUpDown1.Maximum - NumericUpDown1.Value

        'busca próximo item

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        If Res = 0 Then

            LqFinanceiro.AtualizaRecebimentoCompraProdutos(_IdProduto, True, NumericUpDown1.Value, FrmProdutosNfRecebimento.TxtNf.Text)

        Else

            If CmbItensSolicitados.Items.Count > 0 Then

                LqFinanceiro.AtualizaRecebimentoCompraProdutos(LstIdItens.Items(CmbItensSolicitados.SelectedIndex).ToString, True, Res, FrmProdutosNfRecebimento.LblNumNf.Text)
                LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(LstIdItens.Items(CmbItensSolicitados.SelectedIndex).ToString, Res, 0, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)

            Else

                LqFinanceiro.AtualizaRecebimentoCompraProdutos(_IdProduto, True, Res, FrmProdutosNfRecebimento.LblNumNf.Text)
                LqFinanceiro.InsereNovaSolicitacaoCompraFinanceiro(_IdProduto, Res, 0, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, "1111-11-11", 0, 0)

            End If

        End If

        'insere no endereço encontrado

        'le o endereço

        Dim IdProduto0 As Integer

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        For Each row As DataGridViewRow In DtEsperados.Rows

            Dim str As String = row.Cells(1).Value
            Dim separador As String = "."

            ' Separa string baseado no delimitador
            Dim palavras As String() = str.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
            Next

            'cria soliitações de acordo com a solicitação de entrada

            'busca solicitações da peça

            'separa ou cria endereócs temporários

            Dim TipoProd As Integer

            If RdbNovo.Checked = True Then
                TipoProd = 0
            ElseIf RdbUsado.Checked = True Then
                TipoProd = 1
            ElseIf RdbRecon.Checked = True Then
                TipoProd = 2
            End If

            For Each rowEst As DataGridViewRow In DtEsperados.Rows

                'insere armazenamento para o endereço

                Dim ValorUnitário As Decimal = LblValorUnitário.Text

                Dim Qt As Integer = row.Cells(4).Value

                If row.Cells(5).Value = 0 Then

                    Dim NomeEndereco As String = "temp_" & Today.Date.Day & Today.Date.Month & Today.Date.Year & Now.TimeOfDay.TotalMilliseconds.ToString
                    LqEstoque.InsereNovaEndereoEstoqueLocal(0, 0, NomeEndereco, True, 200, 100, 100, 500)

                    Dim BuscaEndereco = From ende In LqEstoque.EnderecoEstoqueLocal
                                        Where ende.NomeEndereco Like NomeEndereco
                                        Select ende.IdEndereco

                    Dim CodFornec As String = FrmProdutosNfRecebimento.LblCodFornec.Text
                    Dim NumNf As Integer = FrmProdutosNfRecebimento.LblNumNf.Text

                    FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProdutosNfRecebimento.DtEsperados.SelectedCells(0).RowIndex).Cells(14).Value = NomeEndereco
                    LqEstoque.InsereNovArmazenagem(Today.Date.AddDays(0), NomeEndereco, _IdProduto, NumNf, CodFornec, Qt, Today.Date, Now.TimeOfDay, ValorUnitário, 0, ValorUnitário + (ValorUnitário * 0), FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, TipoProd)

                Else

                    Dim _IdEndereço As Integer = row.Cells(5).Value

                    Dim NomeEndereco As String = row.Cells(1).Value

                    'atualiza status do endereço
                    FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProdutosNfRecebimento.DtEsperados.SelectedCells(0).RowIndex).Cells(14).Value = NomeEndereco
                    LqEstoque.InsereNovArmazenagem(Today.Date.AddDays(0), _IdEndereço, _IdProduto, FrmProdutosNfRecebimento.LblNumNf.Text, FrmProdutosNfRecebimento.LblCodFornec.Text, Qt, Today.Date, Now.TimeOfDay, ValorUnitário, 0, ValorUnitário + (ValorUnitário * 0), FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, TipoProd)

                    LqEstoque.AtualizaStatusEndereco(_IdEndereço, True)

                End If

            Next

            row.Cells(6).Value = My.Resources.check_ok_accept_apply_1582

            Me.Refresh()

            DtEsperados.FirstDisplayedCell = row.Cells(6)

        Next

        'atualiza a linha

        FrmProdutosNfRecebimento.DtEsperados.SelectedCells(0).Value = My.Resources.check_ok_accept_apply_1582
        FrmProdutosNfRecebimento.DtEsperados.SelectedCells(14).Value = "Armazenado"

        'verifica se item esta disponivel na iara

        Dim EstoqueOnLine As New LqEstoqueIaraDataContext
        EstoqueOnLine.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueDistribuidorOnLine

        Dim BuscaProdutoStatus = From prod In LqBase.Produtos
                                 Where prod.IdProduto = _IdProduto
                                 Select prod.DisponivelOnLine, prod.Pctge, prod.Markup

        If BuscaProdutoStatus.Count > 0 Then

            If BuscaProdutoStatus.First.DisponivelOnLine = True Then

                'insere caracteristicas items

            End If

        End If

        'verifica armazenagem

        Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                               Where arm.IdProduto = _IdProduto
                               Select arm.Qt, arm.ValorRevenda

        If BuscaProdutoStatus.First.Markup > 0 Then

            Dim qt As Integer = 0

            For Each rows In BuscaArmazenagem.ToList

                qt += rows.Qt

            Next

            'atualiza preço na base de dados

            Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_preco_mkp.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdProdutoEst=" & _IdProduto & "&VlrUnit=" & BuscaArmazenagem.First.ValorRevenda.ToString.Replace(",", ".") & "&QtdadeEstoque=" & qt

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

        End If

        'procura próximo

        NumericUpDown1.Value = 0

        Dim Trava As Boolean = False
        For Each row As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

            If row.Cells(14).Value = "" Then

                If Trava = False Then

                    Trava = True

                    LblCodFornec.Text = row.Cells(2).Value
                    LblDescriçãoItem.Text = row.Cells(3).Value
                    LblNCM.Text = row.Cells(4).Value
                    LblEan.Text = row.Cells(5).Value
                    LblValorUnitário.Text = row.Cells(8).Value

                    NumericUpDown1.Maximum = row.Cells(7).Value

                    CmbItensSolicitados.Visible = True
                    LblItemSel.Visible = False

                    If row.Cells(1).Value.ToString <> "" Then

                        'seleciona o item no combobox

                        For i As Integer = 0 To LstIdItens.Items.Count - 1 Step 1

                            If LstIdItens.Items(i).ToString = row.Cells(1).Value Then

                                CmbItensSolicitados.SelectedIndex = i

                                LblTitulo.Text = "Item vinculado"
                                CmbItensSolicitados.Visible = False
                                LblItemSel.Visible = True
                                LblItemSel.Text = CmbItensSolicitados.Items(i).ToString

                                FrmProdutosNfRecebimento.LstIgnorar.Items.Add(LstIdItens.Items(i).ToString)

                            End If

                        Next

                    End If

                End If

            End If

        Next

        If FrmProdutosNfRecebimento.DtEsperados.SelectedCells(0).RowIndex + 1 <= FrmProdutosNfRecebimento.DtEsperados.Rows.Count - 1 Then

            FrmProduto.Index = FrmProdutosNfRecebimento.DtEsperados.SelectedCells(0).RowIndex + 1

            Dim INdexLocal As Integer = FrmProduto.Index

            CmbItensSolicitados.Visible = True
            LblItemSel.Visible = False

            If FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(1).Value <> "" Then
                If Not FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(1).Value.ToString.StartsWith("S") Then
                    _IdProduto = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(1).Value

                    LblCodFornec.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(2).Value
                    LblDescriçãoItem.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(3).Value
                    LblNCM.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(4).Value
                    LblEan.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(5).Value
                    LblValorUnitário.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(8).Value

                    NumericUpDown1.Maximum = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(7).Value

                    FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Selected = True

                    'liga solicitaçãoes

                    If FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(1).Value <> "" Then

                        'seleciona o item no combobox

                        For i As Integer = 0 To LstIdItens.Items.Count - 1 Step 1

                            If LstIdItens.Items(i).ToString = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(1).Value Then

                                CmbItensSolicitados.SelectedIndex = i

                                LblTitulo.Text = "Item vinculado"
                                CmbItensSolicitados.Visible = False
                                LblItemSel.Visible = True
                                LblItemSel.Text = CmbItensSolicitados.Items(i).ToString
                                FrmProdutosNfRecebimento.LstIgnorar.Items.Add(LstIdItens.Items(i).ToString)

                            End If

                        Next

                        If CmbItensSolicitados.Items.Count = 0 Then

                            Dim _IdProduto As Integer = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(1).Value

                            Dim BuscaProduto = From prod In LqBase.Produtos
                                               Where prod.IdProduto = _IdProduto
                                               Select prod.NCM, prod.CodBarras, prod.Descricao, prod.Altura, prod.Largura, prod.Profundidade, prod.Peso

                            LblTitulo.Text = "Item vinculado"
                            LblItemSel.Visible = True
                            LblItemSel.Text = BuscaProduto.First.Descricao
                            CmbItensSolicitados.Visible = False
                            FrmProdutosNfRecebimento.LstIgnorar.Items.Add(_IdProduto)

                            TxtAltura.Value = BuscaProduto.First.Altura
                            TxtLargura.Value = BuscaProduto.First.Largura
                            TxtProfundidade.Value = BuscaProduto.First.Profundidade
                            TxtPeso.Value = BuscaProduto.First.Peso

                        End If

                    Else

                        If CmbItensSolicitados.Items.Count = 0 Then

                            LblTitulo.Text = "descricao"

                            CmbItensSolicitados.Visible = False
                            LblItemSel.Visible = True

                        End If

                    End If

                    'popula NCM

                    FrmProduto.TxtNCM.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(4).Value
                    FrmProduto.TxtCodBarras.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(INdexLocal).Cells(5).Value

                    'verifica quem da lista nao possui associação

                    CmbItensSolicitados.Items.Clear()
                    LstIdItens.Items.Clear()

                    For Each row As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

                        If row.Cells(14).Value = Nothing Then

                            Dim BuscaSolicitacoes = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                                    Where sol.NF = 0 And sol.IdAutorizador > 0
                                                    Select sol.IdProduto, sol.IdCotacao, sol.IdSolicitacaoCad

                            'verifica itens para este fornecedor

                            For Each row1 In BuscaSolicitacoes.ToList

                                'busca a cotação

                                Dim BuscaCt = From ct In LqFinanceiro.Cotacoes
                                              Where ct.IdCotacao = row1.IdCotacao And ct.IdFornecedor Like FrmProdutosNfRecebimento.LblCodFornec.Text
                                              Select ct.IdProduto, ct.IdSolicitacaoCad

                                If BuscaCt.Count > 0 Then

                                    If BuscaCt.First.IdProduto <> 0 Then

                                        'busca itens

                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                           Where prod.IdProduto = BuscaCt.First.IdProduto
                                                           Select prod.Descricao

                                        If Not CmbItensSolicitados.Items.Contains(BuscaProduto.First) Then

                                            'verifica se ja foi inserido 

                                            Dim _C As Integer = 0

                                            For Each rowEsp As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

                                                If rowEsp.Cells(1).Value.ToString = BuscaCt.First.IdProduto.ToString Then
                                                    _C += 1
                                                End If

                                            Next

                                            If _C = 0 Then

                                                LstIdItens.Items.Add(BuscaCt.First.IdProduto)
                                                CmbItensSolicitados.Items.Add(BuscaProduto.First)

                                            End If

                                        End If

                                    Else

                                        'verfica se já foi cadastrado no sistem


                                        Dim buscaCodCad = From cod In LqOficina.SolicitacaoCadastroPeca
                                                          Where cod.IdSolicitacaoCadastro = row1.IdSolicitacaoCad
                                                          Select cod.IdCodCad

                                        If buscaCodCad.First = 0 Then
                                            LStCadastrosProdutos.Items.Add(row1.IdSolicitacaoCad)
                                        End If

                                    End If

                                End If

                            Next
                        End If

                    Next

                Else

                    If MsgBox("O item """ & FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProduto.Index).Cells(3).Value.ToString & """ ainda não teve seu cadastro finalizado, irei direcioná-lo para o término do registro.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                        Dim IdSolString As String = FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProduto.Index).Cells(1).Value
                        Dim IdSol As Integer = IdSolString.Remove(0, 1)

                        'busca partnumber

                        Dim LqOficina0 As New LqOficinaDataContext
                        LqOficina0.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                        Dim BuscaSolicitacoes = From sol In LqOficina0.SolicitacaoCadastroPeca
                                                Where sol.IdSolicitacaoCadastro = IdSol
                                                Select sol.PartNumber, sol.IdCodExt, sol.IdCategoria, sol.IdSubCategoria

                        FrmProduto.Receb = True

                        FrmProduto.CodSol = IdSol

                        'popula NCM

                        FrmProduto.TxtNCM.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProduto.Index).Cells(4).Value
                        FrmProduto.TxtCodBarras.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProduto.Index).Cells(5).Value
                        FrmProduto.TxtDescrição.Text = FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProduto.Index).Cells(3).Value
                        FrmProduto.TxtCodFabricante.Text = BuscaSolicitacoes.First.PartNumber
                        FrmProduto.LblCodExterno.Text = BuscaSolicitacoes.First.IdCodExt

                        Dim BuscaCategorias = From cat In LqBase.CategoriasProdutos
                                              Where cat.IdCategoriaProduto Like "*"
                                              Select cat.Descricao, cat.IdCategoriaProduto

                        FrmProduto.LstIdCategoria.Items.Clear()

                        For Each item In BuscaCategorias.ToList

                            FrmProduto.LstIdCategoria.Items.Add(item.IdCategoriaProduto)
                            FrmProduto.CmbCategoria.Items.Add(item.Descricao)

                        Next

                        Dim BuscaCategoriaPorId = From cat In LqBase.CategoriasProdutos
                                                  Where cat.IdCategoriaProduto = BuscaSolicitacoes.First.IdCategoria
                                                  Select cat.Descricao, cat.IdCategoriaProduto

                        FrmProduto.CmbCategoria.Enabled = False
                        FrmProduto.CmbCategoria.SelectedItem = BuscaCategoriaPorId.First

                        Dim BuscaSubCategorias = From cat In LqBase.SubCategoriasProduto
                                                 Where cat.IdCategoria = BuscaSolicitacoes.First.IdCategoria
                                                 Select cat.Descricao, cat.IdSubCategoria

                        FrmProduto.LstIdSubCategorias.Items.Clear()

                        For Each item In BuscaSubCategorias.ToList

                            FrmProduto.LstIdSubCategorias.Items.Add(item.IdSubCategoria)
                            FrmProduto.CmbSubcategoria.Items.Add(item.Descricao)

                        Next

                        Dim BuscaSubCategoriaPorId = From cat In LqBase.SubCategoriasProduto
                                                     Where cat.IdCategoria = BuscaSolicitacoes.First.IdCategoria
                                                     Select cat.Descricao, cat.IdSubCategoria

                        FrmProduto.CmbSubcategoria.Enabled = False
                        FrmProduto.CmbSubcategoria.SelectedItem = BuscaSubCategoriaPorId.First.Descricao

                        FrmProduto.CmbFabricante.Enabled = True
                        FrmProduto.BttAddFabricante.Enabled = True

                        'cria vinculos com o fornecedor que esta vinculando

                        FrmProduto.DtVinculoFornec.Rows.Add(LblCodFornec.Text.Remove(0, 2), FrmProdutosNfRecebimento.LblRazaoSocial.Text, FrmProdutosNfRecebimento.DtEsperados.Rows(FrmProduto.Index).Cells(2).Value)

                        'Busca vinculos

                        Dim BuscaVinculoModelo = From modelo In LqOficina0.AssociaçãoPeçaModelo
                                                 Where modelo.IdSolicitaçãoCad = IdSol
                                                 Select modelo.IdModeloVeic

                        For Each item In BuscaVinculoModelo.ToList

                            Dim BuscaModelo = From modelo In LqOficina0.Modelos
                                              Where modelo.IdModelo = item
                                              Select modelo.Modelo, modelo.IdFabricante

                            Dim BuscaFabricante = From fab In LqOficina0.FabricantesVeiculo
                                                  Where fab.Idfabricante = BuscaModelo.First.IdFabricante
                                                  Select fab.Fabricante

                            FrmProduto.DtVinculoExterno.Rows.Add("Oficina", BuscaModelo.First.Modelo, 0, True, My.Resources.Cancel_40972, BuscaFabricante.First)

                        Next

                        Me.Cursor = Cursors.Arrow

                        FrmProduto.Show(FrmProdutosNfRecebimento)

                        Me.Close()

                    End If

                End If

                'conta quantos não foram inseridos
            End If

            'verifica se pode encerrar 
        End If

        Dim QtRest As Integer = 0

        For Each rows As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

            If rows.Cells(14).Value = "" Then

                QtRest += 1

            End If

        Next

        If QtRest = 0 Then

            If MsgBox("Todos os itens da nota foram inseridos no estoque, a nota se encontra no sistema e pode ser consultada a qualquer momento.", MsgBoxStyle.OkOnly) Then

                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_solicitacao_nf.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&NumNf=" & _NumNf & "&IdFornecedor=" & FrmProdutosNfRecebimento.LblCodFornec.Text & "&DescricaoString=" _
                    & "Princ_" & _NumNf & " - " & FrmProdutosNfRecebimento.LblRazaoSocial.Text & "&ImgDoc=ND&IdFornecedor=" & FrmProdutosNfRecebimento.LblCodFornec.Text.Remove(0, 2)

                'cria itens da nota fiscal

                For Each rows As DataGridViewRow In FrmProdutosNfRecebimento.DtEsperados.Rows

                Next

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                'cria referencia para o produto 

                Dim baseUrlProd As String = "http://www.iarasoftware.com.br/create_solicitacao_nf.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&NumNf=" & _NumNf & "&IdFornecedor=" & FrmProdutosNfRecebimento.LblCodFornec.Text & "&DescricaoString=" _
                    & _NumNf & " - " & _IdProduto & "&ImgDoc=ND"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientProd = New WebClient()
                Dim contentProd = syncClientProd.DownloadString(baseUrlProd)

                'verifica se há solicitação de cadastro

                'atualiza numnf para os laudos que estiverem em aberto até a quantidade máxima

                LqFinanceiro.InsereNovaNf_Entrada(FrmProdutosNfRecebimento.LblNumNf.Text, FrmProdutosNfRecebimento.CkNaoEnota.CheckState, FrmProdutosNfRecebimento.LblCodFornec.Text, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, FrmProdutosNfRecebimento.docXML.InnerText)
                FrmProdutosNfRecebimento.Close()

                FrmRecebimentoCarga.CarregaInicio()

                If FrmRecebimentoEsperado.DtEsperados.Rows.Count = 0 Then

                    FrmRecebimentoEsperado.Close()

                End If

                Me.Close()

            End If

        End If


        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles LblValorUnitário.Click

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles LblSubCategoria.Click


    End Sub

    Private Sub BtnProcurarEnderecos_Click(sender As Object, e As EventArgs) Handles BtnProcurarEnderecos.Click

    End Sub
End Class