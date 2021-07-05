Public Class FrmSoluçãoNovoStudio

    Public Invoc As Integer = 0

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        If Invoc = 0 Then
            'apaga trnode

            Dim TrRespostashecklist As TreeView = FrmNovoStudioAvaliacao.TrRespostashecklist

            'TrRespostashecklist.Nodes(FrmNovoStudioAvaliacao.TrParentSel).Nodes(2).Nodes.RemoveAt(TrRespostashecklist.Nodes(FrmNovoStudioAvaliacao.TrParentSel).Nodes(2).Nodes.Count - 1)

            FrmNovoStudioAvaliacao.PintaMk()

        End If

        Me.Close()

    End Sub

    Dim TrParentSel As Integer = FrmNovoStudioAvaliacao.TrParentSel

    Private Sub BttConcluirAnalise_Click(sender As Object, e As EventArgs) Handles BttConcluirAnalise.Click

        'avaliar como sem solução

        Dim TrRespostashecklist As TreeView = FrmNovoStudioAvaliacao.TrRespostashecklist

        'expande lista e mdifica ultimo item

        Dim TrPrincipal As TreeNode = TrRespostashecklist.Nodes(TrParentSel).Nodes(2)

        Dim TrAvanço1 As TreeNode = TrPrincipal.Nodes(TrPrincipal.Nodes.Count - 1)

        Dim TrAvanço2 As TreeNode = TrAvanço1.Nodes(1)

        TrAvanço2.Nodes(2).Text = "ND"

        FrmNovoStudioAvaliacao.PintaMk()

        Me.Close()

    End Sub

    Dim LqBase As New DtCadastroDataContext
    Dim LqOficina As New LqOficinaDataContext

    Public _IdCategoria As Integer
    Public _IdSubCategoria As Integer
    Public _IdModVeic As Integer
    Public _IdVeiculo As Integer
    Public _IdVersao As Integer

    Public Sub CarregaLoad()

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'busca produtos

        Dim BuscaProdutos = From prod In LqBase.Produtos
                            Where prod.IdCategoria = _IdCategoria And prod.IDSubCategoria = _IdSubCategoria
                            Select prod.descricao, prod.CodFabricante, prod.IdProduto

        For Each row In BuscaProdutos.ToList

            'procura vinculo com o modelo do veiculo

            Dim buscaVinc = From vinc In LqOficina.AssociaçãoPeçaModelo
                            Where vinc.IdModeloVeic = _IdModVeic And vinc.IdCodProd = row.IdProduto
                            Select vinc.IdAssociacaoPecaModelo

            If BuscaProdutos.Count > 0 Then

                LstIdProduto.Items.Add(row.IdProduto)
                LstSN.Items.Add(row.CodFabricante)

                CmbProdutos.Items.Add(row.descricao)

            End If

        Next

        Dim Oficina = From ofc In LqOficina.SolicitacaoCadastroPeca
                      Where ofc.IdCodCad = 0 And ofc.IdCategoria = _IdCategoria And ofc.IdSubCategoria = _IdSubCategoria
                      Select ofc.DataSol, ofc.HoraSol, ofc.IdSolicitante, ofc.Descricao, ofc.IdSolicitacaoCadastro, ofc.PartNumber

        For Each row In Oficina.ToList

            'busca associação

            Dim BuscaAssociação = From ass In LqOficina.VinculoProdutoModelo
                                  Where ass.IdSolicitacaoCad = row.idsolicitacaoCadastro And ass.IdModeloVeic = _IdModVeic And ass.IdVersaoVeiculo = _IdVersao
                                  Select ass.IdVinculoProdutoVeiculo

            If BuscaAssociação.Count > 0 Then
                'busca associação ao modelo do veiculo

                LstIdProduto.Items.Add("S" & row.idsolicitacaoCadastro)
                LstSN.Items.Add(row.PartNumber)

                CmbProdutos.Items.Add(row.descricao)

            End If

        Next

        'busca serviços

        Dim BuscaServiços = From serv In LqBase.Servicos
                            Where serv.IdServico Like "*" And serv.Ferramenta Like FrmNovoStudioAvaliacao.Ferramenta And serv.IdCategoria = _IdCategoria And serv.IdSubCategoria = _IdSubCategoria
                            Select serv.IdServico, serv.Descricao

        For Each row In BuscaServiços.ToList

            LstIdServicos.Items.Add(row.IdServico)
            CmbServicos.Items.Add(row.Descricao)

        Next

    End Sub

    Public LstIdServicos As New ListBox

    Private Sub FrmSoluçãoNovoStudio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public LstIdProduto As New ListBox
    Public LstSN As New ListBox
    Public LstDescricao As New ListBox

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'solicita cadastro de item ao estoque

        FrmUsarSolitaçõesCadatroPeça.Show(Me)

    End Sub

    Private Sub CmbProdutos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProdutos.SelectedIndexChanged

        If CmbProdutos.Items.Contains(CmbProdutos.Text) Then

            TxtNumSerie.Text = LstSN.Items(CmbProdutos.SelectedIndex).ToString

            NmQtPeças.Value = 1

            NmQtPeças.Enabled = True

        Else

            TxtNumSerie.Text = ""

            NmQtPeças.Value = 0
            NmQtPeças.Enabled = False

        End If

    End Sub

    Private Sub NmQtPeças_ValueChanged(sender As Object, e As EventArgs) Handles NmQtPeças.ValueChanged

        If NmQtPeças.Value > 0 Then

            CkPeça.Enabled = True

            BttVincularProduto.Enabled = True

        Else

            CkPeça.Enabled = False
            CkPeça.Checked = False

            BttVincularProduto.Enabled = False

        End If

    End Sub

    Private Sub BttVincularProduto_Click(sender As Object, e As EventArgs) Handles BttVincularProduto.Click

        'adciona no datagrid

        If CkPeça.Checked = False Then

            If CmbFaricannte.SelectedItem.ToString.StartsWith("-") Then

                DtProdutos.Rows.Add(LstIdProduto.Items(CmbProdutos.SelectedIndex).ToString, CmbProdutos.Text, LstSN.Items(CmbProdutos.SelectedIndex).ToString, My.Resources.icons8_menos_16, NmQtPeças.Value, My.Resources.icons8_mais_16, False, My.Resources.Delete_80_icon_icons_com_57340)

            Else

                DtProdutos.Rows.Add(LstIdProduto.Items(CmbProdutos.SelectedIndex).ToString, CmbFaricannte.Text & " - " & CmbProdutos.Text, LstSN.Items(CmbProdutos.SelectedIndex).ToString, My.Resources.icons8_menos_16, NmQtPeças.Value, My.Resources.icons8_mais_16, False, My.Resources.Delete_80_icon_icons_com_57340)

            End If

        Else

            If CmbFaricannte.SelectedItem.ToString.StartsWith("-") Then

                DtProdutos.Rows.Add(LstIdProduto.Items(CmbProdutos.SelectedIndex).ToString, CmbProdutos.Text, LstSN.Items(CmbProdutos.SelectedIndex).ToString, My.Resources.icons8_menos_16, NmQtPeças.Value, My.Resources.icons8_mais_16, True, My.Resources.Delete_80_icon_icons_com_57340)

            Else

                DtProdutos.Rows.Add(LstIdProduto.Items(CmbProdutos.SelectedIndex).ToString, CmbFaricannte.Text & " - " & CmbProdutos.Text, LstSN.Items(CmbProdutos.SelectedIndex).ToString, My.Resources.icons8_menos_16, NmQtPeças.Value, My.Resources.icons8_mais_16, True, My.Resources.Delete_80_icon_icons_com_57340)

            End If

        End If

            CmbProdutos.Text = ""

    End Sub

    Private Sub CmbProdutos_TextChanged(sender As Object, e As EventArgs) Handles CmbProdutos.TextChanged

        If CmbProdutos.Items.Contains(CmbProdutos.Text) Then

            CmbProdutos.SelectedItem = CmbProdutos.Text

            TxtNumSerie.Text = LstSN.Items(CmbProdutos.SelectedIndex).ToString

            NmQtPeças.Value = 1

            NmQtPeças.Enabled = True

        Else

            TxtNumSerie.Text = ""

            NmQtPeças.Value = 0
            NmQtPeças.Enabled = False

        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        FrmCadSeviçosvb.Show(Me)

    End Sub

    Private Sub CmbServicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbServicos.SelectedIndexChanged

        If CmbServicos.Items.Contains(CmbServicos.Text) Then

            NmQtServico.Enabled = True
            NmQtServico.Value = 1

        Else

            NmQtServico.Enabled = False
            NmQtServico.Value = 0

        End If

    End Sub

    Private Sub CmbServicos_TextChanged(sender As Object, e As EventArgs) Handles CmbServicos.TextChanged

        If CmbServicos.Items.Contains(CmbServicos.Text) Then

            NmQtServico.Enabled = True
            NmQtServico.Value = 1

        Else

            NmQtServico.Enabled = False
            NmQtServico.Value = 0

        End If

    End Sub

    Private Sub NmQtServico_ValueChanged(sender As Object, e As EventArgs) Handles NmQtServico.ValueChanged

        If NmQtServico.Value > 0 Then

            BttVincularServico.Enabled = True

        Else

            BttVincularServico.Enabled = False

        End If

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            If MsgBox("Deseja realmente remover este item da lista?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Remover item") = MsgBoxResult.Yes Then

                DtProdutos.Rows.RemoveAt(e.RowIndex)

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmNecIni" Then

            If DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False Then
                DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            Else
                DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmMnnProd" Then

            'edita quantidade

            If DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value.ToString > 0 Then

                DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value - 1

                If DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value.ToString = 0 Then
                    If MsgBox("Deseja realmente remover este item da lista?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Remover item") = MsgBoxResult.Yes Then

                        DtProdutos.Rows.RemoveAt(e.RowIndex)

                    Else

                        DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value + 1

                    End If
                End If
            End If

            ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmMoreProd" Then

                DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value = DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value + 1

        End If

    End Sub

    Private Sub BttVincularServico_Click(sender As Object, e As EventArgs) Handles BttVincularServico.Click

        'adciona no datagrid

        DtServiços.Rows.Add(LstIdServicos.Items(CmbServicos.SelectedIndex).ToString, CmbServicos.Text, My.Resources.icons8_menos_16, NmQtServico.Value, My.Resources.icons8_mais_16, My.Resources.Cancel_40972)

        CmbServicos.Text = ""

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'insere o mapeamento

        'avaliar como sem solução

        Dim TrRespostashecklist0 As TreeView = FrmNovoStudioAvaliacao.TrRespostashecklist

        'expande lista e mdifica ultimo item

        Dim TrPrincipal0 As TreeNode = TrRespostashecklist0.Nodes(TrParentSel).Nodes(2)

        Dim TrAvanço10 As TreeNode = TrPrincipal0.Nodes(TrPrincipal0.Nodes.Count - 1)

        Dim TrAvanço20 As TreeNode = TrAvanço10.Nodes(1).Nodes(0)

        'apaga 

        TrAvanço20.Nodes.Clear()

        For Each row As TreeNode In TrItens.Nodes

            If row.Checked = True Then
                'insere produtos no treeview

                'avaliar como sem solução

                Dim TrRespostashecklist As TreeView = FrmNovoStudioAvaliacao.TrRespostashecklist

                'expande lista e mdifica ultimo item

                Dim TrPrincipal As TreeNode = TrRespostashecklist.Nodes(TrParentSel).Nodes(2)

                Dim TrAvanço1 As TreeNode = TrPrincipal.Nodes(TrPrincipal.Nodes.Count - 1)

                Dim TrAvanço2 As TreeNode = TrAvanço1.Nodes(1)

                TrAvanço2.Nodes(0).Nodes.Add(row.Text)

                For Each row0 As TreeNode In row.Nodes

                    If row0.Checked = True Then

                        TrAvanço2.Nodes(0).Nodes.Add(row0.Text)

                    End If

                Next

            End If

        Next

        Me.Close()

    End Sub

    Public _IdModeloVeic As Integer = 0

    Private Sub CmbFaricannte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFaricannte.SelectedIndexChanged

        If CmbFaricannte.Items.Contains(CmbFaricannte.Text) And Not CmbFaricannte.Text.StartsWith("-") Then

            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            'busca produtos

            Dim BuscaProdutosAssociados = From mode In LqOficina.AssociaçãoPeçaModelo
                                          Where mode.IdModeloVeic = _IdModeloVeic
                                          Select mode.IdCodProd, mode.IdSolicitaçãoCad

            For Each row1 In BuscaProdutosAssociados.ToList

                If row1.IdCodProd <> 0 Then

                    Dim BuscaProdutos = From prod In LqBase.Produtos
                                        Where prod.IdProduto = row1.IdCodProd And prod.IdCategoria = _IdCategoria And prod.IDSubCategoria = _IdSubCategoria And prod.Fabricante Like CmbFaricannte.Text
                                        Select prod.Descricao, prod.IdProduto, prod.CodFabricante, prod.Fabricante

                    For Each row2 In BuscaProdutos.ToList

                        CmbProdutos.Items.Add(row2.Descricao & " - (Fab.: " & row2.Fabricante & ") - (SN.: " & row2.CodFabricante & ")")
                        LstIdProduto.Items.Add(row2.IdProduto)
                        LstSN.Items.Add(row2.CodFabricante)
                        LstDescricao.Items.Add(row2.Descricao)

                    Next

                End If

            Next

            Dim BuscaProdutosT = From prod In LqBase.Produtos
                                 Where prod.IdProduto Like "*" And prod.IdCategoria = _IdCategoria And prod.IDSubCategoria = _IdSubCategoria Like CmbFaricannte.Text
                                 Select prod.Descricao, prod.IdProduto, prod.CodFabricante, prod.Fabricante

            If BuscaProdutosT.Count > 0 Then
                If CmbProdutos.Items.Count > 0 Then
                    CmbProdutos.Items.Add(" ")
                    LstIdProduto.Items.Add("-")
                    LstSN.Items.Add("-")
                    LstDescricao.Items.Add("-")

                End If

                CmbProdutos.Items.Add("----- Produtos sem associação -----")
                LstIdProduto.Items.Add("-")
                LstSN.Items.Add("-")
                LstDescricao.Items.Add("-")

                CmbProdutos.Items.Add(" ")
                LstIdProduto.Items.Add("-")
                LstSN.Items.Add("-")
                LstDescricao.Items.Add("-")

            End If

            For Each row2 In BuscaProdutosT.ToList

                If Not CmbProdutos.Items.Contains(row2.Descricao & " - (SN.: " & row2.CodFabricante & ")") Then
                    CmbProdutos.Items.Add(row2.Descricao & " - (SN.: " & row2.CodFabricante & ")")
                    LstIdProduto.Items.Add(row2.IdProduto)
                    LstSN.Items.Add(row2.CodFabricante)
                    LstDescricao.Items.Add(row2.Descricao)

                End If

            Next

            Dim BuscaProdutosTT = From prod In LqBase.Produtos
                                  Where prod.IdProduto Like "*" And prod.Fabricante Like CmbFaricannte.Text
                                  Select prod.Descricao, prod.IdProduto, prod.CodFabricante, prod.Fabricante

            If BuscaProdutosTT.Count > 0 Then
                If CmbProdutos.Items.Count > 0 Then
                    CmbProdutos.Items.Add(" ")
                    LstIdProduto.Items.Add("-")
                    LstSN.Items.Add("-")
                    LstDescricao.Items.Add("-")

                End If

                CmbProdutos.Items.Add("----- Produtos de outras categorias -----")
                LstIdProduto.Items.Add("-")
                LstSN.Items.Add("-")
                LstDescricao.Items.Add("-")

                CmbProdutos.Items.Add(" ")
                LstIdProduto.Items.Add("-")
                LstSN.Items.Add("-")
                LstDescricao.Items.Add("-")

            End If

            For Each row2 In BuscaProdutosTT.ToList

                If Not CmbProdutos.Items.Contains(row2.Descricao & " - (SN.: " & row2.CodFabricante & ")") Then
                    CmbProdutos.Items.Add(row2.Descricao & " - (SN.: " & row2.CodFabricante & ")")
                    LstIdProduto.Items.Add(row2.IdProduto)
                    LstSN.Items.Add(row2.CodFabricante)
                    LstDescricao.Items.Add(row2.Descricao)

                End If

            Next

        Else

            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim BuscaProdutosAssociados = From mode In LqOficina.AssociaçãoPeçaModelo
                                          Where mode.IdModeloVeic = _IdModeloVeic
                                          Select mode.IdCodProd, mode.IdSolicitaçãoCad

            For Each row1 In BuscaProdutosAssociados.ToList

                If row1.IdCodProd = 0 Then
                    Dim BuscaProdutos = From prod In LqOficina.SolicitacaoCadastroPeca
                                        Where prod.IdSolicitacaoCadastro = row1.IdSolicitaçãoCad And prod.IdCategoria = _IdCategoria And prod.IdSubCategoria = _IdSubCategoria
                                        Select prod.Descricao, prod.IdSolicitacaoCadastro, prod.PartNumber

                    For Each row2 In BuscaProdutos.ToList

                        LstIdProduto.Items.Add("S" & row2.IdSolicitacaoCadastro)
                        LstSN.Items.Add(row2.PartNumber)
                        LstDescricao.Items.Add(row2.Descricao)
                        CmbProdutos.Items.Add(row2.Descricao & " (SN.: " & row2.PartNumber & ")")
                    Next

                End If

            Next

        End If

    End Sub

    Private Sub DtServiços_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServiços.CellContentClick

        If DtServiços.Columns(e.ColumnIndex).Name = "ClmExcluirServ" Then

            If MsgBox("Deseja realmente remover este item da lista?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Remover item") = MsgBoxResult.Yes Then

                DtServiços.Rows.RemoveAt(e.RowIndex)

            End If

        ElseIf DtServiços.Columns(e.ColumnIndex).Name = "ClmMnnServ" Then

            'edita quantidade

            If DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value.ToString > 0 Then

                DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value - 1

                If DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value.ToString = 0 Then
                    If MsgBox("Deseja realmente remover este item da lista?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Remover item") = MsgBoxResult.Yes Then

                        DtServiços.Rows.RemoveAt(e.RowIndex)

                    Else

                        DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value = DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value + 1

                    End If
                End If
            End If

        ElseIf DtServiços.Columns(e.ColumnIndex).Name = "ClmMoreServ" Then

            DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value = DtServiços.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value + 1

        End If

    End Sub
End Class