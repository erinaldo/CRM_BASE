Public Class FrmAdminEstoqueNovo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public Sub CarregaInicio()

        TrEstoque.Nodes.Clear()
        ListView1.Items.Clear()

        ListView2.Items.Clear()

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        Dim BuscaEstoque = From est In LqEstoqueLocal.EnderecoEstoqueLocal
                           Where est.NomeEndereco.ToString.StartsWith("temp")
                           Select est.IdEndereco, est.NomeEndereco

        'popula temporarios no treeview

        TrEstoque.Nodes.Add("Temporários")

        For Each row In BuscaEstoque.ToList

            TrEstoque.Nodes(0).Nodes.Add(row.IdEndereco)

            ListView1.Items.Add(row.NomeEndereco)
            ListView1.Items(ListView1.Items.Count - 1).ImageIndex = 0

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

            Dim LqEstoque As New LqEstoqueLocalDataContext
            LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

            Dim BuscaBaixas = From bai In LqEstoque.BaixaEndereco
                              Where bai.IdEndereco = row.IdEndereco
                              Select bai.Qt, bai.DataBaixa, bai.HoraBaixa, bai.IdEnderecoBaixa, bai.IdUsuarioBaixa

            Dim Baixados As Integer = 0

            For Each row_baixa In BuscaBaixas.ToList

                Baixados += row_baixa.Qt

            Next

            If Estocados - Baixados = 0 Then
                TrEstoque.Nodes(0).Nodes.RemoveAt(TrEstoque.Nodes(0).Nodes.Count - 1)
                ListView1.Items.RemoveAt(ListView1.Items(ListView1.Items.Count - 1).Index)
            End If

        Next

        'busca estoques locais

        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.EstoquesLocais
                                Where est.IdEstoque Like "*"
                                Select est.NomeEstoque, est.IdEstoque

        TrEstoque.Nodes.Add("Estoques")

        For Each row In BuscaEstoqueLocal.ToList

            TrEstoque.Nodes(1).Nodes.Add(row.IdEstoque)
            ListView2.Items.Add(row.NomeEstoque.ToString)

            ListView2.Items(ListView2.Items.Count - 1).ImageIndex = 0

        Next

    End Sub
    Private Sub FrmAdminEstoqueNovo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregaInicio()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FrmNovoEstoqueLocal.Show(Me)

    End Sub

    Dim SelectIndex As Integer = -1

    Private Sub BtnNovoPredio_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        SelectIndex = ListView2.SelectedItems.Item(0).Index

        'verifica qual item esta selecionado

        If SelectIndex > -1 Then

            Dim _IdEstoque As Integer = TrEstoque.Nodes(1).Nodes(SelectIndex).Text

            FrmNovaRua.IdEstoque = _IdEstoque

            FrmNovaRua.Show(Me)

        End If

    End Sub

    Private Sub BtnNovaQuadra_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick

        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

            'verifica qual item esta selecionado

            If SelectIndex > -1 Then

                Dim _IdEstoque As Integer = TrEstoque.Nodes(1).Nodes(SelectIndex).Text

                FrmQuadrasEstoqueLocal._IdEstoque = _IdEstoque

                FrmQuadrasEstoqueLocal.Show(Me)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListView2_MouseEnter(sender As Object, e As EventArgs) Handles ListView2.MouseEnter

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged


    End Sub

    Dim SelectIndex1 As Integer = -1

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick

        Try

            SelectIndex1 = ListView1.SelectedItems.Item(0).Index

            'verifica qual item esta selecionado

            If SelectIndex1 > -1 Then

                Dim _IdEstoque As Integer = TrEstoque.Nodes(0).Nodes(SelectIndex1).Text

                FrmDetalheEndereço.IdEndereco = _IdEstoque

                FrmDetalheEndereço.LblNomeEndereco.Text = ListView1.SelectedItems.Item(0).Text
                FrmDetalheEndereço.LblStatus.Text = "Enderéço temporário"

                FrmDetalheEndereço.LblCod.Text = TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(0).Text

                'busca descriçao do produto

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaProduto = From prod In LqBase.Produtos
                                   Where prod.IdProduto = TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(0).Text
                                   Select prod.Descricao, prod.Fabricante

                FrmDetalheEndereço.LblDEscrição.Text = BuscaProduto.First.Descricao & " - " & BuscaProduto.First.Fabricante
                FrmDetalheEndereço.TxtQtdade.Text = TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(3).Text
                FrmDetalheEndereço.TxtQtdadeDisponivel.Text = TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(3).Text
                FrmDetalheEndereço.LblDataEntrada.Text = TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(4).Text & " " & FormatDateTime(TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(5).Text, DateFormat.LongTime)
                FrmDetalheEndereço.LblNumNf.Text = TrEstoque.Nodes(0).Nodes(SelectIndex1).Nodes(6).Text

                FrmDetalheEndereço.Show(Me)

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

End Class