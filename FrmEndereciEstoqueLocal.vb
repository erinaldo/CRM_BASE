Public Class FrmEndereciEstoqueLocal

    Public IdAndar As Integer
    Public IdEstoque As Integer

    Private Sub FrmEndereciEstoqueLocal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Dim SelectIndex As Integer = -1

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick

        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

            'verifica qual item esta selecionado

            If SelectIndex > -1 Then

                Dim _IdEstoque As Integer = TrEstoque.Nodes(0).Nodes(SelectIndex).Text

                FrmDetalheEndereço.IdEndereco = _IdEstoque

                FrmDetalheEndereço.LblNomeEndereco.Text = FrmAdminEstoqueNovo.ListView2.SelectedItems.Item(0).Text & "." & FrmQuadrasEstoqueLocal.ListView2.SelectedItems.Item(0).Text & "." & FrmRuasEstoqueLocalvb.ListView2.SelectedItems.Item(0).Text & "." & FrmPrediosEstoqueLocal.ListView2.SelectedItems.Item(0).Text & "." & FrmAndarEstoqueLocal.ListView2.SelectedItems.Item(0).Text & "." & ListView2.SelectedItems.Item(0).Text

                If TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(0).Text > 0 Then

                    FrmDetalheEndereço.LblStatus.Text = "Endereço em uso"

                    FrmDetalheEndereço.LblCod.Text = TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(0).Text

                    'busca descriçao do produto

                    Dim LqBase As New DtCadastroDataContext
                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim BuscaProduto = From prod In LqBase.Produtos
                                       Where prod.IdProduto = TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(0).Text
                                       Select prod.Descricao, prod.Fabricante

                    FrmDetalheEndereço.LblDEscrição.Text = BuscaProduto.First.Descricao & " - " & BuscaProduto.First.Fabricante
                    FrmDetalheEndereço.TxtQtdade.Text = TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(3).Text
                    FrmDetalheEndereço.TxtQtdadeDisponivel.Text = TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(3).Text
                    FrmDetalheEndereço.LblDataEntrada.Text = TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(4).Text & " " & FormatDateTime(TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(5).Text, DateFormat.LongTime)
                    FrmDetalheEndereço.LblNumNf.Text = TrEstoque.Nodes(0).Nodes(SelectIndex).Nodes(6).Text

                    FrmDetalheEndereço.Show(Me)

                Else

                    FrmDetalheEndereço.LblStatus.Text = "Endereço disponível"

                    FrmDetalheEndereço.LblCod.Text = ""

                    FrmDetalheEndereço.LblDEscrição.Text = ""
                    FrmDetalheEndereço.TxtQtdade.Text = ""
                    FrmDetalheEndereço.TxtQtdadeDisponivel.Text = ""
                    FrmDetalheEndereço.LblDataEntrada.Text = ""
                    FrmDetalheEndereço.LblNumNf.Text = ""

                    FrmDetalheEndereço.DtBaixas.Rows.Clear()

                    FrmDetalheEndereço.Show(Me)

                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub
    Public Sub CarregaInicio()

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        TrEstoque.Nodes.Clear()

        ListView2.Items.Clear()

        'busca estoques locais

        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.EnderecoEstoqueLocal
                                Where est.IdAndar = IdAndar And est.IdEstoque = IdEstoque
                                Select est.NomeEndereco, est.IdEndereco

        TrEstoque.Nodes.Add("Endereços")

        For Each row In BuscaEstoqueLocal.ToList

            TrEstoque.Nodes(0).Nodes.Add(row.IdEndereco)
            ListView2.Items.Add(row.NomeEndereco.ToString)
            ListView2.Items(ListView2.Items.Count - 1).ImageIndex = 0

            'busca detalhes da armazenagem

            Dim TrArm As TreeNode = TrEstoque.Nodes(0).Nodes(TrEstoque.Nodes(0).Nodes.Count - 1)

            Dim BuscaDadosAramzenagem = From arm In LqEstoqueLocal.Armazenagem
                                        Where arm.Endereco Like row.NomeEndereco
                                        Select arm.NF, arm.IdProduto, arm.Qt, arm.TipoProduto, arm.Validade, arm.DataEntrada, arm.HoraEntrada

            Dim Estocados As Integer = 0

            For Each row0 In BuscaDadosAramzenagem.ToList

                TrArm.Nodes.Add(row0.IdProduto)
                TrArm.Nodes.Add(row0.TipoProduto)
                TrArm.Nodes.Add(row0.Validade)
                TrArm.Nodes.Add(row0.Qt)
                Estocados += row0.Qt

                TrArm.Nodes.Add(row0.DataEntrada)
                TrArm.Nodes.Add(row0.HoraEntrada.ToString)
                TrArm.Nodes.Add(row0.NF)

            Next

            If BuscaDadosAramzenagem.Count = 0 Then

                Dim BuscaDadosAramzenagemPeloId = From arm In LqEstoqueLocal.Armazenagem
                                                  Where arm.Endereco Like row.IdEndereco
                                                  Select arm.NF, arm.IdProduto, arm.Qt, arm.TipoProduto, arm.Validade, arm.DataEntrada, arm.HoraEntrada

                For Each row0 In BuscaDadosAramzenagemPeloId.ToList

                    TrArm.Nodes.Add(row0.IdProduto)
                    TrArm.Nodes.Add(row0.TipoProduto)
                    TrArm.Nodes.Add(row0.Validade)
                    TrArm.Nodes.Add(row0.Qt)
                    Estocados += row0.Qt

                    TrArm.Nodes.Add(row0.DataEntrada)
                    TrArm.Nodes.Add(row0.HoraEntrada.ToString)
                    TrArm.Nodes.Add(row0.NF)

                Next

                If BuscaDadosAramzenagemPeloId.Count = 0 Then
                    TrArm.Nodes.Add(0)
                    TrArm.Nodes.Add(0)
                    TrArm.Nodes.Add(0)
                    TrArm.Nodes.Add(0)
                    TrArm.Nodes.Add(0)
                    TrArm.Nodes.Add(0)
                    TrArm.Nodes.Add(0)
                End If

            End If

                Dim LqEstoque As New LqEstoqueLocalDataContext
            LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

            Dim BuscaBaixas = From bai In LqEstoque.BaixaEndereco
                              Where bai.IdEndereco = row.IdEndereco
                              Select bai.Qt, bai.DataBaixa, bai.HoraBaixa, bai.IdEnderecoBaixa, bai.IdUsuarioBaixa

            Dim Baixados As Integer = 0

            For Each row_baixa In BuscaBaixas.ToList

                Baixados += row_baixa.Qt

            Next

            TrEstoque.Nodes(0).Nodes(TrEstoque.Nodes(0).Nodes.Count - 1).Nodes(4).Text = Estocados - Baixados

        Next

    End Sub

    Private Sub BtnNovo_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click

        FrmNovoEnderecoEstoqueLocal.IdAndar = IdAndar
        FrmNovoEnderecoEstoqueLocal.IdEstoque = IdEstoque
        FrmNovoEnderecoEstoqueLocal.Show(Me)

    End Sub
End Class