Public Class FrmCheckList
    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles PnnDianteira.Paint

    End Sub

    Private Sub Panel8_Click(sender As Object, e As EventArgs) Handles PnnDianteira.Click

        GuardaInfo()

        _IdCategoria = 1

        PnnDianteira.BackColor = Color.WhiteSmoke
        PnnTraseira.BackColor = Color.WhiteSmoke
        PnnLateralDireita.BackColor = Color.WhiteSmoke
        PnnLateralEsquerda.BackColor = Color.WhiteSmoke
        PnnMecanicos.BackColor = Color.WhiteSmoke
        PnnInterior.BackColor = Color.WhiteSmoke

        PnnDianteira.BackColor = Color.SlateGray

        'Busca categorias dianteira

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = 1
                                Select cat.Descricao, cat.IdSubCategoria

        TrItens.Nodes.Clear()
        TrEspelho.Nodes.Clear()

        For Each it In BuscaSubCategoria.ToList

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'Busca Detalhamento dos itens

            Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                Where det.IdCategoria = 1 And det.IdSubCategoria = it.IdSubCategoria
                                Select det.Item, det.IdItemCatOficina

            TrItens.Nodes.Add(it.Descricao)
            TrEspelho.Nodes.Add(it.IdSubCategoria)

            For Each it0 In BuscaDetalhes.ToList

                TrItens.Nodes(TrItens.Nodes.Count - 1).Nodes.Add(it0.Item)
                TrEspelho.Nodes(TrEspelho.Nodes.Count - 1).Nodes.Add(it0.IdItemCatOficina)

                'Busca subitens

                Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                   Where det.IdItem = it0.IdItemCatOficina
                                   Select det.Descricao, det.IdSubItem

                Dim TrSub As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)
                Dim TrSub_E As TreeNode = TrEspelho.Nodes(TrEspelho.Nodes.Count - 1)

                For Each it1 In BuscaSubItem.ToList

                    TrSub.Nodes(TrSub.Nodes.Count - 1).Nodes.Add(it1.Descricao)
                    TrSub_E.Nodes(TrSub_E.Nodes.Count - 1).Nodes.Add(it1.IdSubItem)

                Next

            Next

        Next

        PopulaLista()

        TrItens.ExpandAll()

    End Sub

    Public ItemsSel As New ListBox

    Private Sub PnnTraseira_Paint(sender As Object, e As PaintEventArgs) Handles PnnTraseira.Paint

    End Sub

    Private Sub PnnLateralDireita_Paint(sender As Object, e As PaintEventArgs) Handles PnnLateralDireita.Paint

    End Sub

    Private Sub PnnLateralEsquerda_Paint(sender As Object, e As PaintEventArgs) Handles PnnLateralEsquerda.Paint

    End Sub

    Private Sub PnnInterior_Paint(sender As Object, e As PaintEventArgs) Handles PnnInterior.Paint

    End Sub

    Private Sub Panel19_Paint(sender As Object, e As PaintEventArgs) Handles PnnMecanicos.Paint

    End Sub

    Private Sub PnnTraseira_Click(sender As Object, e As EventArgs) Handles PnnTraseira.Click

        GuardaInfo()

        _IdCategoria = 2

        PnnDianteira.BackColor = Color.WhiteSmoke
        PnnTraseira.BackColor = Color.WhiteSmoke
        PnnLateralDireita.BackColor = Color.WhiteSmoke
        PnnLateralEsquerda.BackColor = Color.WhiteSmoke
        PnnMecanicos.BackColor = Color.WhiteSmoke
        PnnInterior.BackColor = Color.WhiteSmoke

        PnnTraseira.BackColor = Color.SlateGray

        'Busca categorias dianteira

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = 2
                                Select cat.Descricao, cat.IdSubCategoria

        TrItens.Nodes.Clear()
        TrEspelho.Nodes.Clear()

        For Each it In BuscaSubCategoria.ToList

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'Busca Detalhamento dos itens

            Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                Where det.IdCategoria = 2 And det.IdSubCategoria = it.IdSubCategoria
                                Select det.Item, det.IdItemCatOficina

            TrItens.Nodes.Add(it.Descricao)
            TrEspelho.Nodes.Add(it.IdSubCategoria)

            For Each it0 In BuscaDetalhes.ToList

                TrItens.Nodes(TrItens.Nodes.Count - 1).Nodes.Add(it0.Item)
                TrEspelho.Nodes(TrEspelho.Nodes.Count - 1).Nodes.Add(it0.IdItemCatOficina)

                'Busca subitens

                Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                   Where det.IdItem = it0.IdItemCatOficina
                                   Select det.Descricao, det.IdSubItem

                Dim TrSub As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)
                Dim TrSub_E As TreeNode = TrEspelho.Nodes(TrEspelho.Nodes.Count - 1)

                For Each it1 In BuscaSubItem.ToList

                    TrSub.Nodes(TrSub.Nodes.Count - 1).Nodes.Add(it1.Descricao)
                    TrSub_E.Nodes(TrSub_E.Nodes.Count - 1).Nodes.Add(it1.IdSubItem)

                Next

            Next

        Next

        PopulaLista()

        TrItens.ExpandAll()

    End Sub

    Private Sub PnnLateralDireita_Click(sender As Object, e As EventArgs) Handles PnnLateralDireita.Click

        GuardaInfo()

        _IdCategoria = 4

        PnnDianteira.BackColor = Color.WhiteSmoke
        PnnTraseira.BackColor = Color.WhiteSmoke
        PnnLateralDireita.BackColor = Color.WhiteSmoke
        PnnLateralEsquerda.BackColor = Color.WhiteSmoke
        PnnMecanicos.BackColor = Color.WhiteSmoke
        PnnInterior.BackColor = Color.WhiteSmoke

        PnnLateralDireita.BackColor = Color.SlateGray

        'Busca categorias dianteira

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = 4
                                Select cat.Descricao, cat.IdSubCategoria

        TrItens.Nodes.Clear()
        TrEspelho.Nodes.Clear()

        For Each it In BuscaSubCategoria.ToList


            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'Busca Detalhamento dos itens

            Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                Where det.IdCategoria = 4 And det.IdSubCategoria = it.IdSubCategoria
                                Select det.Item, det.IdItemCatOficina

            TrItens.Nodes.Add(it.Descricao)
            TrEspelho.Nodes.Add(it.IdSubCategoria)

            For Each it0 In BuscaDetalhes.ToList

                TrItens.Nodes(TrItens.Nodes.Count - 1).Nodes.Add(it0.Item)
                TrEspelho.Nodes(TrEspelho.Nodes.Count - 1).Nodes.Add(it0.IdItemCatOficina)

                'Busca subitens

                Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                   Where det.IdItem = it0.IdItemCatOficina
                                   Select det.Descricao, det.IdSubItem

                Dim TrSub As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)
                Dim TrSub_E As TreeNode = TrEspelho.Nodes(TrEspelho.Nodes.Count - 1)

                For Each it1 In BuscaSubItem.ToList

                    TrSub.Nodes(TrSub.Nodes.Count - 1).Nodes.Add(it1.Descricao)
                    TrSub_E.Nodes(TrSub_E.Nodes.Count - 1).Nodes.Add(it1.IdSubItem)

                Next

            Next

        Next

        PopulaLista()

        TrItens.ExpandAll()


    End Sub

    Private Sub PnnLateralEsquerda_Click(sender As Object, e As EventArgs) Handles PnnLateralEsquerda.Click

        GuardaInfo()

        _IdCategoria = 3

        PnnDianteira.BackColor = Color.WhiteSmoke
        PnnTraseira.BackColor = Color.WhiteSmoke
        PnnLateralDireita.BackColor = Color.WhiteSmoke
        PnnLateralEsquerda.BackColor = Color.WhiteSmoke
        PnnMecanicos.BackColor = Color.WhiteSmoke
        PnnInterior.BackColor = Color.WhiteSmoke

        PnnLateralEsquerda.BackColor = Color.SlateGray

        'Busca categorias dianteira

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = 3
                                Select cat.Descricao, cat.IdSubCategoria

        TrItens.Nodes.Clear()
        TrEspelho.Nodes.Clear()

        For Each it In BuscaSubCategoria.ToList


            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'Busca Detalhamento dos itens

            Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                Where det.IdCategoria = 3 And det.IdSubCategoria = it.IdSubCategoria
                                Select det.Item, det.IdItemCatOficina

            TrItens.Nodes.Add(it.Descricao)
            TrEspelho.Nodes.Add(it.IdSubCategoria)

            For Each it0 In BuscaDetalhes.ToList

                TrItens.Nodes(TrItens.Nodes.Count - 1).Nodes.Add(it0.Item)
                TrEspelho.Nodes(TrEspelho.Nodes.Count - 1).Nodes.Add(it0.IdItemCatOficina)

                'Busca subitens

                Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                   Where det.IdItem = it0.IdItemCatOficina
                                   Select det.Descricao, det.IdSubItem

                Dim TrSub As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)
                Dim TrSub_E As TreeNode = TrEspelho.Nodes(TrEspelho.Nodes.Count - 1)

                For Each it1 In BuscaSubItem.ToList

                    TrSub.Nodes(TrSub.Nodes.Count - 1).Nodes.Add(it1.Descricao)
                    TrSub_E.Nodes(TrSub_E.Nodes.Count - 1).Nodes.Add(it1.IdSubItem)

                Next

            Next

        Next

        PopulaLista()

        TrItens.ExpandAll()


    End Sub

    Private Sub PnnInterior_Click(sender As Object, e As EventArgs) Handles PnnInterior.Click

        GuardaInfo()

        _IdCategoria = 5

        PnnDianteira.BackColor = Color.WhiteSmoke
        PnnTraseira.BackColor = Color.WhiteSmoke
        PnnLateralDireita.BackColor = Color.WhiteSmoke
        PnnLateralEsquerda.BackColor = Color.WhiteSmoke
        PnnMecanicos.BackColor = Color.WhiteSmoke
        PnnInterior.BackColor = Color.WhiteSmoke

        PnnInterior.BackColor = Color.SlateGray

        'Busca categorias dianteira

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = 5
                                Select cat.Descricao, cat.IdSubCategoria

        TrItens.Nodes.Clear()
        TrEspelho.Nodes.Clear()

        For Each it In BuscaSubCategoria.ToList


            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'Busca Detalhamento dos itens

            Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                Where det.IdCategoria = 5 And det.IdSubCategoria = it.IdSubCategoria
                                Select det.Item, det.IdItemCatOficina

            TrItens.Nodes.Add(it.Descricao)
            TrEspelho.Nodes.Add(it.IdSubCategoria)

            For Each it0 In BuscaDetalhes.ToList

                TrItens.Nodes(TrItens.Nodes.Count - 1).Nodes.Add(it0.Item)
                TrEspelho.Nodes(TrEspelho.Nodes.Count - 1).Nodes.Add(it0.IdItemCatOficina)

                'Busca subitens

                Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                   Where det.IdItem = it0.IdItemCatOficina
                                   Select det.Descricao, det.IdSubItem

                Dim TrSub As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)
                Dim TrSub_E As TreeNode = TrEspelho.Nodes(TrEspelho.Nodes.Count - 1)

                For Each it1 In BuscaSubItem.ToList

                    TrSub.Nodes(TrSub.Nodes.Count - 1).Nodes.Add(it1.Descricao)
                    TrSub_E.Nodes(TrSub_E.Nodes.Count - 1).Nodes.Add(it1.IdSubItem)

                Next

            Next

        Next

        PopulaLista()

        TrItens.ExpandAll()


    End Sub

    Private Sub PnnMecanicos_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles PnnMecanicos.ChangeUICues

    End Sub

    Private Sub PnnMecanicos_Click(sender As Object, e As EventArgs) Handles PnnMecanicos.Click

        GuardaInfo()

        _IdCategoria = 6

        PnnDianteira.BackColor = Color.WhiteSmoke
        PnnTraseira.BackColor = Color.WhiteSmoke
        PnnLateralDireita.BackColor = Color.WhiteSmoke
        PnnLateralEsquerda.BackColor = Color.WhiteSmoke
        PnnMecanicos.BackColor = Color.WhiteSmoke
        PnnInterior.BackColor = Color.WhiteSmoke

        PnnMecanicos.BackColor = Color.SlateGray

        'Busca categorias dianteira

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                Where cat.IdCategoria = 6
                                Select cat.Descricao, cat.IdSubCategoria

        TrItens.Nodes.Clear()
        TrEspelho.Nodes.Clear()

        For Each it In BuscaSubCategoria.ToList

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            'Busca Detalhamento dos itens

            Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                Where det.IdCategoria = 6 And det.IdSubCategoria = it.IdSubCategoria
                                Select det.Item, det.IdItemCatOficina

            TrItens.Nodes.Add(it.Descricao)
            TrEspelho.Nodes.Add(it.IdSubCategoria)

            For Each it0 In BuscaDetalhes.ToList

                TrItens.Nodes(TrItens.Nodes.Count - 1).Nodes.Add(it0.Item)
                TrEspelho.Nodes(TrEspelho.Nodes.Count - 1).Nodes.Add(it0.IdItemCatOficina)

                'Busca subitens

                Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                   Where det.IdItem = it0.IdItemCatOficina
                                   Select det.Descricao, det.IdSubItem

                Dim TrSub As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)
                Dim TrSub_E As TreeNode = TrEspelho.Nodes(TrEspelho.Nodes.Count - 1)

                For Each it1 In BuscaSubItem.ToList

                    TrSub.Nodes(TrSub.Nodes.Count - 1).Nodes.Add(it1.Descricao)
                    TrSub_E.Nodes(TrSub_E.Nodes.Count - 1).Nodes.Add(it1.IdSubItem)

                Next

            Next

        Next

        PopulaLista()

        TrItens.ExpandAll()


    End Sub

    Public _Placa As String

    Dim _IdVersao As Integer
    Dim _IdVeiculo As Integer
    Dim _IdModVeic As Integer

    Private Sub FrmCheckList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'busca dados do veiculo

        Dim NPlaca As String

        NPlaca = _Placa.Replace("-", "")

        Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                           Where veic.Placa Like NPlaca
                           Select veic.Modelo, veic.Versao, veic.Fabricante, veic.IdVersao, veic.Cor, veic.AnoFab, veic.AnoMod, veic.IdModelo, veic.IdVeiculo

        _IdVersao = BuscaVeiculo.First.IdVersao
        _IdVeiculo = BuscaVeiculo.First.IdVeiculo
        _IdModVeic = BuscaVeiculo.First.IdModelo

        LblFabricante.Text = BuscaVeiculo.First.Fabricante
        LblModelo.Text = BuscaVeiculo.First.Modelo
        LblCor.Text = BuscaVeiculo.First.Cor
        LblAnoFab.Text = BuscaVeiculo.First.AnoFab
        LblAnoMod.Text = BuscaVeiculo.First.AnoMod

        'bsca versao

        Dim buscaVersao = From ver In LqOficina.VersaoModelos
                          Where ver.Idversao = _IdVersao
                          Select ver.Combustivel, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Versao

        LblMotor.Text = FormatNumber(buscaVersao.First.Potencia, NumDigitsAfterDecimal:=1)
        LblCombustível.Text = buscaVersao.First.Combustivel
        LblCilindrada.Text = buscaVersao.First.Cilindrada
        LblVersao.Text = buscaVersao.First.Versao
        LblCambio.Text = buscaVersao.First.Cambio

        'carrega todas as ferramentos

    End Sub

    Dim LstFerramentas As New ListBox

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.Timer1.Enabled = True
        Me.Close()

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Dim MouseY As Decimal
    Dim Index As Integer

    Dim LstItemSelecionado As New ListBox

    Private Sub TrItens_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrItens.AfterSelect


    End Sub

    Private Sub TrItens_MouseClick(sender As Object, e As MouseEventArgs) Handles TrItens.MouseClick

        MouseY = e.Y

        'busca servicós para este item


    End Sub

    Dim _IdCategoria As Integer

    Public Sub GuardaInfo()

        If _IdCategoria = 1 Then

            LstFrontal.Items.Clear()
            LstFrontal_index.Items.Clear()

            For Each it As TreeNode In TrItens.Nodes

                If it.Checked = True Then
                    LstFrontal.Items.Add(it.Text)
                    LstFrontal_index.Items.Add(TrEspelho.Nodes(it.Index).Text)

                    'varre os servicos

                    For Each it0 As TreeNode In it.Nodes(0).Nodes

                        LstFrontal_Serv.Items.Add(TrEspelho.Nodes(it.Index).Nodes(0).Nodes(it0.Index).Text)

                    Next

                End If

            Next

        ElseIf _IdCategoria = 2 Then

            LstTraseira.Items.Clear()
            LstTraseira_index.Items.Clear()

            For Each it As TreeNode In TrItens.Nodes

                If it.Checked = True Then

                    LstTraseira.Items.Add(it.Text)
                    LstTraseira_index.Items.Add(TrEspelho.Nodes(it.Index).Text)

                    'varre os servicos

                    For Each it0 As TreeNode In it.Nodes(0).Nodes

                        LstTraseira_Serv.Items.Add(TrEspelho.Nodes(it.Index).Nodes(0).Nodes(it0.Index).Text)

                    Next

                End If

            Next

        ElseIf _IdCategoria = 3 Then

            LstLatEsq.Items.Clear()
            LstLatEsq_index.Items.Clear()

            For Each it As TreeNode In TrItens.Nodes

                If it.Checked = True Then

                    LstLatEsq.Items.Add(it.Text)
                    LstLatEsq_index.Items.Add(TrEspelho.Nodes(it.Index).Text)

                    'varre os servicos

                    For Each it0 As TreeNode In it.Nodes(0).Nodes

                        LstLatEsq_Serv.Items.Add(TrEspelho.Nodes(it.Index).Nodes(0).Nodes(it0.Index).Text)

                    Next

                End If

            Next

        ElseIf _IdCategoria = 4 Then

            LstLatDir.Items.Clear()
            LstLatDir_index.Items.Clear()

            For Each it As TreeNode In TrItens.Nodes

                If it.Checked = True Then

                    LstLatDir.Items.Add(it.Text)
                    LstLatDir_index.Items.Add(TrEspelho.Nodes(it.Index).Text)

                    'varre os servicos

                    For Each it0 As TreeNode In it.Nodes(0).Nodes

                        LstLatDir_serv.Items.Add(TrEspelho.Nodes(it.Index).Nodes(0).Nodes(it0.Index).Text)

                    Next

                End If

            Next

        ElseIf _IdCategoria = 5 Then

            LstInterior.Items.Clear()
            LstInterior_index.Items.Clear()

            For Each it As TreeNode In TrItens.Nodes

                If it.Checked = True Then

                    LstInterior.Items.Add(it.Text)
                    LstInterior_index.Items.Add(TrEspelho.Nodes(it.Index).Text)

                    'varre os servicos

                    For Each it0 As TreeNode In it.Nodes(0).Nodes

                        LstInterior_serv.Items.Add(TrEspelho.Nodes(it.Index).Nodes(0).Nodes(it0.Index).Text)

                    Next

                End If

            Next

        ElseIf _IdCategoria = 6 Then

            LstMecanico.Items.Clear()
            LstMecanico_index.Items.Clear()

            For Each it As TreeNode In TrItens.Nodes

                If it.Checked = True Then

                    LstMecanico.Items.Add(it.Text)
                    LstMecanico_index.Items.Add(TrEspelho.Nodes(it.Index).Text)

                    'varre os servicos

                    For Each it0 As TreeNode In it.Nodes(0).Nodes

                        LstMecanico_serv.Items.Add(TrEspelho.Nodes(it.Index).Nodes(0).Nodes(it0.Index).Text)

                    Next

                End If

            Next

        End If

    End Sub
    Private Sub TrItens_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TrItens.AfterCheck

        If e.Node.Checked = True And e.Node.Text <> "Serviços" And e.Node.Text <> "Danos" Then

            If e.Node.Level = 0 Then

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaVinculos = From vinc In LqBase.Servicos
                                    Where vinc.IdServico Like "*" And vinc.IdCategoria = _IdCategoria And vinc.IdSubCategoria = TrEspelho.Nodes(e.Node.Index).Text
                                    Select vinc.Descricao, vinc.IdServico

                e.Node.Nodes.Add("Serviços")
                TrEspelho.Nodes(e.Node.Index).Nodes.Add("Serviços")

                Dim TrUlt As TreeNode = e.Node.Nodes(e.Node.Nodes.Count - 1)

                For Each it In BuscaVinculos.ToList
                    TrUlt.Nodes.Add(it.Descricao)
                    TrEspelho.Nodes(e.Node.Index).Nodes(TrUlt.Index).Nodes.Add(it.IdServico)
                Next

                e.Node.Nodes.Add("Danos")
                TrEspelho.Nodes(e.Node.Index).Nodes.Add("Danos")

                Dim LqOficina As New LqOficinaDataContext
                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                Dim BuscaDanos = From dan In LqOficina.VinculoAvariaSubCat
                                 Where dan.IdSubCategoria = TrEspelho.Nodes(e.Node.Index).Text
                                 Select dan.IdAvaria

                Dim TrUltD As TreeNode = e.Node.Nodes(e.Node.Nodes.Count - 1)

                For Each it In BuscaDanos.ToList

                    Dim BuscaAvaria = From ofi In LqOficina.AvariasFerramentas
                                      Where ofi.IdAvaria = it
                                      Select ofi.Descricao

                    TrUltD.Nodes.Add(BuscaAvaria.First)
                    TrEspelho.Nodes(e.Node.Index).Nodes(TrUlt.Index).Nodes.Add(it)
                Next

                e.Node.ExpandAll()

            Else

                If e.Node.Parent.Text <> "Serviços" And e.Node.Parent.Text <> "Danos" Then

                    Dim LqBase As New DtCadastroDataContext
                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim BuscaVinculos = From vinc In LqBase.Servicos
                                        Where vinc.IdServico Like "*" And vinc.IdCategoria = _IdCategoria And vinc.IdSubCategoria = TrEspelho.Nodes(e.Node.Index).Text
                                        Select vinc.Descricao, vinc.IdServico

                    e.Node.Nodes.Add("Serviços")
                    TrEspelho.Nodes(e.Node.Index).Nodes.Add("Serviços")

                    Dim TrUlt As TreeNode = e.Node.Nodes(e.Node.Nodes.Count - 1)

                    For Each it In BuscaVinculos.ToList
                        TrUlt.Nodes.Add(it.Descricao)
                        TrEspelho.Nodes(e.Node.Index).Nodes(TrUlt.Index).Nodes.Add(it.IdServico)
                    Next

                    e.Node.Nodes.Add("Danos")
                    TrEspelho.Nodes(e.Node.Index).Nodes.Add("Danos")

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaDanos = From dan In LqOficina.VinculoAvariaSubCat
                                     Where dan.IdSubCategoria = TrEspelho.Nodes(e.Node.Index).Text
                                     Select dan.IdAvaria

                    Dim TrUltD As TreeNode = e.Node.Nodes(e.Node.Nodes.Count - 1)

                    For Each it In BuscaDanos.ToList

                        Dim BuscaAvaria = From ofi In LqOficina.AvariasFerramentas
                                          Where ofi.IdAvaria = it
                                          Select ofi.Descricao

                        TrUltD.Nodes.Add(BuscaAvaria.First)
                        TrEspelho.Nodes(e.Node.Index).Nodes(TrUlt.Index).Nodes.Add(it)
                    Next

                    e.Node.ExpandAll()

                ElseIf e.Node.Parent.Text = "Serviços" Then

                    Todos = False

                    e.Node.Parent.Checked = True

                ElseIf e.Node.Parent.Text = "Danos" Then

                    Todos0 = False

                    e.Node.Parent.Checked = True

                End If

            End If

        ElseIf e.Node.Checked = True And e.Node.Text = "Serviços" Then

            If Todos = True Then
                'seleciona os itens abaixo

                For Each it As TreeNode In e.Node.Nodes

                    it.Checked = True

                Next

            Else

                Todos = True

            End If

        ElseIf e.Node.Checked = True And e.Node.Text = "Danos" Then

            If Todos0 = True Then
                'seleciona os itens abaixo

                For Each it As TreeNode In e.Node.Nodes

                    it.Checked = True

                Next

            Else

                Todos0 = True

            End If

        End If

    End Sub

    Private Sub TrItens_Click(sender As Object, e As EventArgs) Handles TrItens.Click

    End Sub

    Dim Todos As Boolean = True
    Dim Todos0 As Boolean = True

    Dim LstFrontal As New ListBox
    Dim LstTraseira As New ListBox
    Dim LstLatEsq As New ListBox
    Dim LstLatDir As New ListBox
    Dim LstInterior As New ListBox
    Dim LstMecanico As New ListBox

    Dim LstFrontal_index As New ListBox
    Dim LstTraseira_index As New ListBox
    Dim LstLatEsq_index As New ListBox
    Dim LstLatDir_index As New ListBox
    Dim LstInterior_index As New ListBox
    Dim LstMecanico_index As New ListBox

    Dim LstFrontal_Serv As New ListBox
    Dim LstTraseira_Serv As New ListBox
    Dim LstLatEsq_Serv As New ListBox
    Dim LstLatDir_serv As New ListBox
    Dim LstInterior_serv As New ListBox
    Dim LstMecanico_serv As New ListBox

    Dim Varre As Boolean = False

    Public Sub PopulaLista()

        If _IdCategoria = 1 Then

            For Each it As TreeNode In TrItens.Nodes
                For Each linha In LstFrontal.Items
                    If it.Text = linha Then
                        it.Checked = True
                    End If
                Next
            Next

        ElseIf _IdCategoria = 2 Then

            For Each it As TreeNode In TrItens.Nodes
                For Each linha In LstTraseira.Items
                    If it.Text = linha Then
                        it.Checked = True
                    End If
                Next
            Next

        ElseIf _IdCategoria = 3 Then

            For Each it As TreeNode In TrItens.Nodes
                For Each linha In LstLatEsq.Items
                    If it.Text = linha Then
                        it.Checked = True
                    End If
                Next
            Next

        ElseIf _IdCategoria = 4 Then

            For Each it As TreeNode In TrItens.Nodes
                For Each linha In LstLatDir.Items
                    If it.Text = linha Then
                        it.Checked = True
                    End If
                Next
            Next

        ElseIf _IdCategoria = 5 Then

            For Each it As TreeNode In TrItens.Nodes
                For Each linha In LstInterior.Items
                    If it.Text = linha Then
                        it.Checked = True
                    End If
                Next
            Next

        ElseIf _IdCategoria = 6 Then

            For Each it As TreeNode In TrItens.Nodes
                For Each linha In LstMecanico.Items
                    If it.Text = linha Then
                        it.Checked = True
                    End If
                Next
            Next

        End If

    End Sub

    Private Sub TrItens_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles TrItens.BeforeCheck

        If e.Node.Level = 0 Then
            e.Node.Nodes.Clear()
            TrEspelho.Nodes(e.Node.Index).Nodes.Clear()
        Else

            If e.Node.Parent.Text <> "Serviços" And e.Node.Text <> "Serviços" And e.Node.Parent.Text <> "Danos" And e.Node.Text <> "Danos" Then
                e.Node.Nodes.Clear()
                TrEspelho.Nodes(e.Node.Index).Nodes.Clear()
            ElseIf e.Node.Text = "Serviços" Then

                If Todos = True Then
                    'seleciona os itens abaixo

                    For Each it As TreeNode In e.Node.Nodes

                        it.Checked = False

                    Next

                    Todos = True

                End If

            ElseIf e.Node.Text = "Danos" Then

                If Todos0 = True Then
                    'seleciona os itens abaixo

                    For Each it As TreeNode In e.Node.Nodes

                        it.Checked = False

                    Next

                    Todos0 = True

                End If

            End If

        End If

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        GuardaInfo()

        FrmPrincipal.Timer1.Enabled = True

        'Cria vinculos a orçamentos

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'cria orámento

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        'gera produtos para o orçamento
        Dim BuscaOrcN = From orc In LqComercial.Orcamentos
                        Where orc.IdVeiculo = _IdVeiculo And orc.Aprovado = False
                        Select orc.IdOrcamento
        If BuscaOrcN.Count = 0 Then
            Dim CodExterno As Integer = 0

            LqComercial.InsereNovoOrcamento(FrmPrincipal.IdUsuario, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, 0, _IdVeiculo, False, "1111-11-11", Today.TimeOfDay, 0, LblIdVistoria.Text, 0, CodExterno, False, False, 0, "1111-11-11")
        Else
            LqComercial.DeletaItensOrcamento(BuscaOrcN.First, 1)
        End If

        'gera produtos para o orçamento
        Dim BuscaOrc = From orc In LqComercial.Orcamentos
                       Where orc.IdVeiculo = _IdVeiculo And orc.Aprovado = False
                       Select orc.IdOrcamento

        For it As Integer = 0 To LstFrontal.Items.Count - 1

            Dim BuscaSolicitacoesCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                       Where cad.IdCategoria = 1 And cad.IdSubCategoria = LstFrontal_index.Items(it).ToString
                                       Select cad.IdCodCad, cad.IdSolicitacaoCadastro, cad.Markup

            If BuscaSolicitacoesCad.Count = 0 Then

                'Solicita cadastro de produto para o item desejado

                LqOficina.InsereSolicitacaoCadastroPeca("", LstFrontal.Items(it).ToString & " " & LblFabricante.Text & " " & LblModelo.Text & " " & LblAnoMod.Text & "/" & LblAnoFab.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, 1, LstFrontal_index.Items(it).ToString, _IdModVeic, _IdVersao, 0, 0, "")

                Dim BuscaUlt = From cad In LqOficina.SolicitacaoCadastroPeca
                               Where cad.IdCategoria = 1 And cad.IdSubCategoria = LstFrontal_index.Items(it).ToString
                               Select cad.IdSolicitacaoCadastro

                'Verifica se existe cotacao pendente

                Dim LqFinanceiro As New LqFinanceiroDataContext

                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = BuscaUlt.First
                               Select cot.ValorCotado, cot.Markup

                If BuscaCot.Count > 0 Then

                    Dim Mkp As Decimal = 0
                    Dim VlrCot As Decimal = 0
                    Dim VlrRevenda As Decimal = 0

                    If BuscaCot.Count > 0 Then
                        VlrRevenda += BuscaCot.First.ValorCotado
                        VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                        Mkp = BuscaCot.First.Markup / 100
                        VlrCot = BuscaCot.First.ValorCotado
                    End If

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)
                Else

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    'insere solicitacao de cotacao

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaUlt.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                End If

            Else

                'insere novo orçamento para o item

                If BuscaSolicitacoesCad.First.IdCodCad = 0 Then

                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)
                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = BuscaSolicitacoesCad.First.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                Else

                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = BuscaSolicitacoesCad.First.IdCodCad
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaSolicitacoesCad.First.IdCodCad, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                End If

            End If

        Next
        For it As Integer = 0 To LstTraseira.Items.Count - 1

            Dim BuscaSolicitacoesCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                       Where cad.IdCategoria = 2 And cad.IdSubCategoria = LstTraseira_index.Items(it).ToString
                                       Select cad.IdCodCad, cad.IdSolicitacaoCadastro, cad.Markup

            If BuscaSolicitacoesCad.Count = 0 Then

                'Solicita cadastro de produto para o item desejado

                LqOficina.InsereSolicitacaoCadastroPeca("", LstTraseira.Items(it).ToString & " " & LblFabricante.Text & " " & LblModelo.Text & " " & LblAnoMod.Text & "/" & LblAnoFab.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, 2, LstTraseira_index.Items(it).ToString, _IdModVeic, _IdVersao, 0, 0, "")

                Dim BuscaUlt = From cad In LqOficina.SolicitacaoCadastroPeca
                               Where cad.IdCategoria = 2 And cad.IdSubCategoria = LstTraseira_index.Items(it).ToString
                               Select cad.IdSolicitacaoCadastro

                'Verifica se existe cotacao pendente

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = BuscaUlt.First
                               Select cot.ValorCotado, cot.Markup

                If BuscaCot.Count > 0 Then

                    Dim Mkp As Decimal = 0
                    Dim VlrCot As Decimal = 0
                    Dim VlrRevenda As Decimal = 0

                    If BuscaCot.Count > 0 Then
                        VlrRevenda += BuscaCot.First.ValorCotado
                        VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                        Mkp = BuscaCot.First.Markup / 100
                        VlrCot = BuscaCot.First.ValorCotado
                    End If

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)
                Else

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    'insere solicitacao de cotacao

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaUlt.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                End If

            Else

                'insere novo orçamento para o item

                If BuscaSolicitacoesCad.First.IdCodCad = 0 Then

                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)
                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = BuscaSolicitacoesCad.First.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                Else

                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = BuscaSolicitacoesCad.First.IdCodCad
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaSolicitacoesCad.First.IdCodCad, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                End If

            End If

        Next
        For it As Integer = 0 To LstLatEsq.Items.Count - 1

            Dim BuscaSolicitacoesCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                       Where cad.IdCategoria = 3 And cad.IdSubCategoria = LstLatEsq_index.Items(it).ToString
                                       Select cad.IdCodCad, cad.IdSolicitacaoCadastro, cad.Markup

            If BuscaSolicitacoesCad.Count = 0 Then

                'Solicita cadastro de produto para o item desejado

                LqOficina.InsereSolicitacaoCadastroPeca("", LstLatEsq.Items(it).ToString & " " & LblFabricante.Text & " " & LblModelo.Text & " " & LblAnoMod.Text & "/" & LblAnoFab.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, 3, LstLatEsq_index.Items(it).ToString, _IdModVeic, _IdVersao, 0, 0, "")

                Dim BuscaUlt = From cad In LqOficina.SolicitacaoCadastroPeca
                               Where cad.IdCategoria = 3 And cad.IdSubCategoria = LstLatEsq_index.Items(it).ToString
                               Select cad.IdSolicitacaoCadastro

                'Verifica se existe cotacao pendente

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = BuscaUlt.First
                               Select cot.ValorCotado, cot.Markup

                If BuscaCot.Count > 0 Then

                    Dim Mkp As Decimal = 0
                    Dim VlrCot As Decimal = 0
                    Dim VlrRevenda As Decimal = 0

                    If BuscaCot.Count > 0 Then
                        VlrRevenda += BuscaCot.First.ValorCotado
                        VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                        Mkp = BuscaCot.First.Markup / 100
                        VlrCot = BuscaCot.First.ValorCotado
                    End If

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)
                Else

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    'insere solicitacao de cotacao

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaUlt.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                End If

            Else

                'insere novo orçamento para o item

                If BuscaSolicitacoesCad.First.IdCodCad = 0 Then

                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)
                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = BuscaSolicitacoesCad.First.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                Else

                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = BuscaSolicitacoesCad.First.IdCodCad
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaSolicitacoesCad.First.IdCodCad, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                End If

            End If

        Next
        For it As Integer = 0 To LstLatDir.Items.Count - 1

            Dim BuscaSolicitacoesCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                       Where cad.IdCategoria = 4 And cad.IdSubCategoria = LstLatDir_index.Items(it).ToString
                                       Select cad.IdCodCad, cad.IdSolicitacaoCadastro, cad.Markup

            If BuscaSolicitacoesCad.Count = 0 Then

                'Solicita cadastro de produto para o item desejado

                LqOficina.InsereSolicitacaoCadastroPeca("", LstLatDir.Items(it).ToString & " " & LblFabricante.Text & " " & LblModelo.Text & " " & LblAnoMod.Text & "/" & LblAnoFab.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, 4, LstLatDir_index.Items(it).ToString, _IdModVeic, _IdVersao, 0, 0, "")

                Dim BuscaUlt = From cad In LqOficina.SolicitacaoCadastroPeca
                               Where cad.IdCategoria = 4 And cad.IdSubCategoria = LstLatDir_index.Items(it).ToString
                               Select cad.IdSolicitacaoCadastro

                'Verifica se existe cotacao pendente

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = BuscaUlt.First
                               Select cot.ValorCotado, cot.Markup

                If BuscaCot.Count > 0 Then

                    Dim Mkp As Decimal = 0
                    Dim VlrCot As Decimal = 0
                    Dim VlrRevenda As Decimal = 0

                    If BuscaCot.Count > 0 Then
                        VlrRevenda += BuscaCot.First.ValorCotado
                        VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                        Mkp = BuscaCot.First.Markup / 100
                        VlrCot = BuscaCot.First.ValorCotado
                    End If

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)
                Else

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    'insere solicitacao de cotacao

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaUlt.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                End If

            Else

                'insere novo orçamento para o item

                If BuscaSolicitacoesCad.First.IdCodCad = 0 Then

                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)
                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = BuscaSolicitacoesCad.First.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                Else

                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = BuscaSolicitacoesCad.First.IdCodCad
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaSolicitacoesCad.First.IdCodCad, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                End If

            End If


        Next
        For it As Integer = 0 To LstInterior.Items.Count - 1

            Dim BuscaSolicitacoesCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                       Where cad.IdCategoria = 5 And cad.IdSubCategoria = LstInterior_index.Items(it).ToString
                                       Select cad.IdCodCad, cad.IdSolicitacaoCadastro, cad.Markup

            If BuscaSolicitacoesCad.Count = 0 Then

                'Solicita cadastro de produto para o item desejado

                LqOficina.InsereSolicitacaoCadastroPeca("", LstInterior.Items(it).ToString & " " & LblFabricante.Text & " " & LblModelo.Text & " " & LblAnoMod.Text & "/" & LblAnoFab.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, 5, LstInterior_index.Items(it).ToString, _IdModVeic, _IdVersao, 0, 0, "")

                Dim BuscaUlt = From cad In LqOficina.SolicitacaoCadastroPeca
                               Where cad.IdCategoria = 5 And cad.IdSubCategoria = LstInterior_index.Items(it).ToString
                               Select cad.IdSolicitacaoCadastro

                'Verifica se existe cotacao pendente

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = BuscaUlt.First
                               Select cot.ValorCotado, cot.Markup

                If BuscaCot.Count > 0 Then

                    Dim Mkp As Decimal = 0
                    Dim VlrCot As Decimal = 0
                    Dim VlrRevenda As Decimal = 0

                    If BuscaCot.Count > 0 Then
                        VlrRevenda += BuscaCot.First.ValorCotado
                        VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                        Mkp = BuscaCot.First.Markup / 100
                        VlrCot = BuscaCot.First.ValorCotado
                    End If

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)
                Else

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    'insere solicitacao de cotacao

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaUlt.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                End If

            Else

                'insere novo orçamento para o item

                If BuscaSolicitacoesCad.First.IdCodCad = 0 Then

                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)
                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = BuscaSolicitacoesCad.First.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                Else

                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = BuscaSolicitacoesCad.First.IdCodCad
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaSolicitacoesCad.First.IdCodCad, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                End If

            End If

        Next
        For it As Integer = 0 To LstMecanico.Items.Count - 1

            Dim BuscaSolicitacoesCad = From cad In LqOficina.SolicitacaoCadastroPeca
                                       Where cad.IdCategoria = 6 And cad.IdSubCategoria = LstMecanico_index.Items(it).ToString
                                       Select cad.IdCodCad, cad.IdSolicitacaoCadastro, cad.Markup

            If BuscaSolicitacoesCad.Count = 0 Then

                'Solicita cadastro de produto para o item desejado

                LqOficina.InsereSolicitacaoCadastroPeca("", LstMecanico.Items(it).ToString & " " & LblFabricante.Text & " " & LblModelo.Text & " " & LblAnoMod.Text & "/" & LblAnoFab.Text, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, False, 0, "1111-11-11", Today.TimeOfDay, 0, 6, LstMecanico_index.Items(it).ToString, _IdModVeic, _IdVersao, 0, 0, "")

                Dim BuscaUlt = From cad In LqOficina.SolicitacaoCadastroPeca
                               Where cad.IdCategoria = 6 And cad.IdSubCategoria = LstMecanico_index.Items(it).ToString
                               Select cad.IdSolicitacaoCadastro

                'Verifica se existe cotacao pendente

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                               Where cot.IdSolicitacaoCad = BuscaUlt.First
                               Select cot.ValorCotado, cot.Markup

                If BuscaCot.Count > 0 Then

                    Dim Mkp As Decimal = 0
                    Dim VlrCot As Decimal = 0
                    Dim VlrRevenda As Decimal = 0

                    If BuscaCot.Count > 0 Then
                        VlrRevenda += BuscaCot.First.ValorCotado
                        VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                        Mkp = BuscaCot.First.Markup / 100
                        VlrCot = BuscaCot.First.ValorCotado
                    End If

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)
                Else

                    LqComercial.InsereNovoItemOrcamento(BuscaUlt.First, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    'insere solicitacao de cotacao

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaUlt.First, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                End If

            Else

                'insere novo orçamento para o item

                If BuscaSolicitacoesCad.First.IdCodCad = 0 Then

                    LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)
                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdSolicitacaoCad = BuscaSolicitacoesCad.First.IdSolicitacaoCadastro
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, BuscaSolicitacoesCad.First.IdSolicitacaoCadastro, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                Else

                    'Verifica cotacao

                    Dim LqFinanceiro As New LqFinanceiroDataContext
                    LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                    Dim BuscaCot = From cot In LqFinanceiro.Cotacoes
                                   Where cot.IdProduto = BuscaSolicitacoesCad.First.IdCodCad
                                   Select cot.ValorCotado, cot.Markup

                    If BuscaCot.Count > 0 Then

                        Dim Mkp As Decimal = 0
                        Dim VlrCot As Decimal = 0
                        Dim VlrRevenda As Decimal = 0

                        If BuscaCot.Count > 0 Then
                            VlrRevenda += BuscaCot.First.ValorCotado
                            VlrRevenda += (BuscaCot.First.ValorCotado * (BuscaCot.First.Markup / 100))

                            Mkp = BuscaCot.First.Markup / 100
                            VlrCot = BuscaCot.First.ValorCotado
                        End If

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, VlrRevenda, 0, Today.Date, True, LblIdVistoria.Text, 0)

                    Else

                        LqComercial.InsereNovoItemOrcamento(0, BuscaSolicitacoesCad.First.IdCodCad, BuscaOrc.First, 1, 1, 0, 0, Today.Date, True, LblIdVistoria.Text, 0)

                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, BuscaSolicitacoesCad.First.IdCodCad, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, 1, 0, 0)

                    End If

                End If

            End If

        Next

        For it As Integer = 0 To LstFrontal_Serv.Items.Count - 1

            LqComercial.InsereNovoItemOrcamento(0, LstFrontal_Serv.Items(it).ToString, BuscaOrc.First, 1, 1, 0, 0, Today.Date, False, LblIdVistoria.Text, 0)

        Next
        For it As Integer = 0 To LstTraseira_Serv.Items.Count - 1

            LqComercial.InsereNovoItemOrcamento(0, LstTraseira_Serv.Items(it).ToString, BuscaOrc.First, 1, 1, 0, 0, Today.Date, False, LblIdVistoria.Text, 0)

        Next
        For it As Integer = 0 To LstLatEsq_Serv.Items.Count - 1

            LqComercial.InsereNovoItemOrcamento(0, LstLatEsq_Serv.Items(it).ToString, BuscaOrc.First, 1, 1, 0, 0, Today.Date, False, LblIdVistoria.Text, 0)

        Next
        For it As Integer = 0 To LstLatDir_serv.Items.Count - 1

            LqComercial.InsereNovoItemOrcamento(0, LstLatDir_serv.Items(it).ToString, BuscaOrc.First, 1, 1, 0, 0, Today.Date, False, LblIdVistoria.Text, 0)

        Next
        For it As Integer = 0 To LstInterior_serv.Items.Count - 1

            LqComercial.InsereNovoItemOrcamento(0, LstInterior_serv.Items(it).ToString, BuscaOrc.First, 1, 1, 0, 0, Today.Date, False, LblIdVistoria.Text, 0)

        Next
        For it As Integer = 0 To LstMecanico_serv.Items.Count - 1

            LqComercial.InsereNovoItemOrcamento(0, LstMecanico_serv.Items(it).ToString, BuscaOrc.First, 1, 1, 0, 0, Today.Date, False, LblIdVistoria.Text, 0)

        Next

        'atualiza termino

        LqOficina.AtualizaVistoriaPeloTecnico_NovaVistoriaVeiculo(_IdVeiculo, True, Now.TimeOfDay, Today.Date)

        Me.Close()

    End Sub
End Class