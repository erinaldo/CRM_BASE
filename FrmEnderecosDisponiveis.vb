Public Class FrmEnderecosDisponiveis
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub FrmEnderecosDisponiveis_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        'busca estoques locais

        Dim BuscaTodosEstoqueLocal = From est In LqEstoqueLocal.EstoquesLocais
                                     Where est.IdEstoque Like "*"
                                     Select est.NomeEstoque, est.IdEstoque


        For Each item In BuscaTodosEstoqueLocal

            LStEstoques.Items.Add(item.NomeEstoque)
            LStEstoques.Items(LStEstoques.Items.Count - 1).Checked = True
            LStEstoques.Items(LStEstoques.Items.Count - 1).ImageIndex = 0

            Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.EnderecoEstoqueLocal
                                    Where est.IdEndereco Like "*" And Not est.NomeEndereco.StartsWith("temp") And est.Usado = False And est.IdEstoque = item.IdEstoque
                                    Select est.NomeEndereco, est.IdEndereco, est.IdEstoque

            TrEstoque.Nodes.Add(item.IdEstoque)

        Next

        CarregaInicio()

    End Sub

    Public Sub CarregaInicio()

        ListView2.Items.Clear()

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        For Each item As TreeNode In TrEstoque.Nodes

            If LStEstoques.Items(item.Index).Checked = True Then

                Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.EnderecoEstoqueLocal
                                        Where est.IdEndereco Like "*" And Not est.NomeEndereco.StartsWith("temp") And est.Usado = False And est.IdEstoque = item.Text
                                        Select est.NomeEndereco, est.IdEndereco, est.IdEstoque, est.IdAndar, est.Altura, est.Largura, est.Profundidade, est.Peso

                For Each row In BuscaEstoqueLocal.ToList

                    Dim BuscaNomeEstoque = From est In LqEstoqueLocal.EstoquesLocais
                                           Where est.IdEstoque = item.Text
                                           Select est.NomeEstoque

                    Dim BuscaAndarEstoque = From est In LqEstoqueLocal.AndarEstoqueLocal
                                            Where est.IdAndar = row.IdAndar
                                            Select est.NomeAndar, est.IdPredio

                    Dim BuscaPredioEstoque = From est In LqEstoqueLocal.PredioEstoqueLocal
                                             Where est.IdPredio = BuscaAndarEstoque.First.IdPredio
                                             Select est.NomePredio, est.IdRua

                    Dim BuscaRuaEstoque = From est In LqEstoqueLocal.RuasEstoqueLocal
                                          Where est.IdRua = BuscaPredioEstoque.First.IdRua
                                          Select est.NomeRua, est.IdQuadra

                    Dim BuscaQuadraEstoque = From est In LqEstoqueLocal.QuadrasEstoqueLocal
                                             Where est.IdQuadra = BuscaRuaEstoque.First.IdQuadra
                                             Select est.NomeQuadra

                    item.Nodes.Add(row.IdEndereco)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(row.Altura)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(row.Largura)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(row.Profundidade)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(row.Peso)

                    'busca detalhes do armazenamento do item

                    Dim BuscaArmazenagem = From est In LqEstoqueLocal.Armazenagem
                                           Where est.Endereco Like IdEndereco
                                           Select est.TipoProduto, est.Validade, est.ValorRevenda, est.ValorUnit, est.Markup, est.IdFornecedor

                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(BuscaArmazenagem.First.Validade)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(BuscaArmazenagem.First.IdFornecedor)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(BuscaArmazenagem.First.ValorUnit)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(BuscaArmazenagem.First.Markup)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(BuscaArmazenagem.First.ValorRevenda)
                    item.Nodes(item.Nodes.Count - 1).Nodes.Add(BuscaArmazenagem.First.TipoProduto)

                    ListView2.Items.Add(BuscaNomeEstoque.First & "." & BuscaQuadraEstoque.First & "." & BuscaRuaEstoque.First.NomeRua & "." & BuscaPredioEstoque.First.NomePredio & "." & BuscaAndarEstoque.First.NomeAndar & "." & row.NomeEndereco.ToString)
                    ListView2.Items(ListView2.Items.Count - 1).ImageIndex = 1

                Next

            End If

        Next

        LStEstoques.Enabled = True

    End Sub

    Private Sub BttDeclinarOrc_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub LStEstoques_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LStEstoques.SelectedIndexChanged

    End Sub

    Private Sub LStEstoques_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles LStEstoques.ItemCheck

        If LStEstoques.Enabled = True Then
            CarregaInicio()
        End If

    End Sub

    Private Sub LStEstoques_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles LStEstoques.ItemChecked

        If LStEstoques.Enabled = True Then
            CarregaInicio()
        End If

    End Sub

    Dim Capacidade_m3 As Decimal = 0

    Public IdProduto As Integer = 0
    Public IdEndereco As Integer = 0

    Public Sub Calculam3_total()

        Capacidade_m3 = 0

        Dim Selecionados As Integer = 0
        Dim Armazenado As Integer = 0

        For Each item As ListViewItem In ListView2.Items

            If item.Checked = True Then

                Selecionados += 1

                Dim _indice As Integer = -1

                'verifica o começo do titulo
                For Each item0 As ListViewItem In LStEstoques.Items

                    If item.Text.StartsWith(item0.Text) Then

                        _indice = item0.Index

                    End If

                Next

                'busca produtos

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaProdutos = From prod In LqBase.Produtos
                                    Where prod.IdProduto = IdProduto
                                    Select prod.Altura, prod.Largura, prod.Profundidade, prod.Peso

                Dim TamanhoM3 As Decimal = ((BuscaProdutos.First.Altura * BuscaProdutos.First.Largura) * BuscaProdutos.First.Profundidade)

                'busca qual o indice do estoque correpondente

                Dim _Altura As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(0).Text
                Dim _Largura As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(1).Text
                Dim _Profundidade As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(2).Text
                Dim _Peso As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(3).Text

                Dim CapacidadeM3 As Decimal = (_Altura * _Largura) * _Profundidade

                'busca dados do item a ser armazenado

                While CapacidadeM3 > TamanhoM3

                    CapacidadeM3 -= TamanhoM3
                    Armazenado += 1

                End While

            End If

        Next

        If Armazenado < TxtQtdadeMovimentar.Value Then

            If MsgBox("Os endereços escolhidos não são capazes de armazenar a quantidade solicitada, por favor selecione mais endereços para movimentar o estoque.", vbOKOnly) = MsgBoxResult.Ok Then

                TxtQtdadeMovimentar.Value = Armazenado

            End If

        End If

        If Selecionados = 0 And TxtQtdadeMovimentar.Value > 0 Then

            If MsgBox("Não há endereços escolhidos para armazenar a quantidade solicitada, por favor selecione endereços para movimentar o estoque.", vbOKOnly) = MsgBoxResult.Ok Then

                TxtQtdadeMovimentar.Value = 0

            End If

        End If
    End Sub

    Private Sub ListView2_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListView2.ItemCheck

        'verifica se endereço consegue armazenar 

        Calculam3_total()

    End Sub

    Private Sub ListView2_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles ListView2.ItemChecked

        Calculam3_total()

    End Sub

    Private Sub TxtQtdadeMovimentar_ValueChanged(sender As Object, e As EventArgs) Handles TxtQtdadeMovimentar.ValueChanged

        Calculam3_total()

    End Sub

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        Capacidade_m3 = 0

        Dim Selecionados As Integer = 0
        Dim Armazenado As Integer = 0

        For Each item As ListViewItem In ListView2.Items

            If item.Checked = True Then

                Selecionados += 1

                Dim _indice As Integer = -1

                'verifica o começo do titulo
                For Each item0 As ListViewItem In LStEstoques.Items

                    If item.Text.StartsWith(item0.Text) Then

                        _indice = item0.Index

                    End If

                Next

                'busca produtos

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaProdutos = From prod In LqBase.Produtos
                                    Where prod.IdProduto = IdProduto
                                    Select prod.Altura, prod.Largura, prod.Profundidade, prod.Peso

                Dim TamanhoM3 As Decimal = ((BuscaProdutos.First.Altura * BuscaProdutos.First.Largura) * BuscaProdutos.First.Profundidade)

                'busca qual o indice do estoque correpondente

                Dim _Altura As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(0).Text
                Dim _Largura As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(1).Text
                Dim _Profundidade As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(2).Text
                Dim _Peso As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(3).Text

                Dim CapacidadeM3 As Decimal = (_Altura * _Largura) * _Profundidade

                'busca dados do item a ser armazenado

                Dim ArmColet As Integer = 0

                While CapacidadeM3 > TamanhoM3

                    CapacidadeM3 -= TamanhoM3
                    Armazenado += 1
                    ArmColet += 1

                End While

                'insere movimento no banco de dados

                Dim LqEstoque As New LqEstoqueLocalDataContext
                LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                Dim Validade As Date = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(4).Text
                Dim Fornecedor As Integer = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(5).Text.Remove(0, 2)
                Dim ValorUnit As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(6).Text
                Dim Mqrkup As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(7).Text
                Dim ValorRevenda As Decimal = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(8).Text
                Dim TipoProduto As Integer = TrEstoque.Nodes(_indice).Nodes(item.Index).Nodes(9).Text


                If TxtQtdadeMovimentar.Value > 0 Then

                    'insere a armazenagem
                    LqEstoque.InsereNovArmazenagem(Validade, TrEstoque.Nodes(_indice).Nodes(item.Index).Text, IdProduto, FrmDetalheEndereço.LblNumNf.Text, Fornecedor _
                                               , ArmColet, Today.Date, Now.TimeOfDay, ValorUnit, Mqrkup, ValorRevenda _
                                               , FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, TipoProduto)
                    'usa o endereco

                    LqEstoque.AtualizaStatusEndereco(TrEstoque.Nodes(_indice).Nodes(item.Index).Text, True)

                    'baixa item do endereço anterior

                    LqEstoque.InsereBaixaEstoque(IdEndereco, ArmColet, 0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmDetalheEndereço.LblNumNf.Text, IdProduto)

                    'verifica se o estoque esta zerado

                    If Armazenado = TxtQtdadeDisponivel.Text Then

                        LqEstoque.AtualizaStatusEndereco(IdEndereco, False)

                    End If

                End If

            End If

        Next

        FrmEndereciEstoqueLocal.CarregaInicio()

        FrmDetalheEndereço.Close()


    End Sub
End Class