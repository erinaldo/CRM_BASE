Imports System.Net

Public Class FrmDespachoSolicitações
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Dim LqEstoque As New LqEstoqueLocalDataContext
    Dim LqBase As New DtCadastroDataContext

    Private Sub FrmDespachoSolicitações_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaSolicitações = From sol In LqEstoque.SolicitacaoProdutosEstoque
                                Where sol.Status = False
                                Select sol.IdProduto, sol.Qtdade, sol.DataSol, sol.Destino, sol.IdSolicitacao, sol.IdSolicitacaoCad

        For Each row In BuscaSolicitações.ToList

            If row.IdProduto > 0 Then

                'busca descricao do item

                Dim Buscadescricao = From prod In LqBase.Produtos
                                     Where prod.IdProduto = row.IdProduto
                                     Select prod.Descricao

                'busca qtdade no estoque

                Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                   Where est.IdProduto = row.IdProduto
                                   Select est.Qt, est.Endereco

                Dim QtEstoque As Integer = 0

                For Each item In BuscaEstoque.ToList

                    'busca saidas deste lote

                    Dim ProcuraIdEndereco = From ende In LqEstoque.EnderecoEstoqueLocal
                                            Where ende.NomeEndereco Like item.Endereco
                                            Select ende.IdEndereco

                    If ProcuraIdEndereco.Count > 0 Then

                        Dim BuscaSaidas = From est In LqEstoque.BaixaEndereco
                                          Where est.IdEndereco = ProcuraIdEndereco.First
                                          Select est.Qt

                        For Each qt_it In BuscaSaidas.ToList

                            QtEstoque -= qt_it

                        Next

                        QtEstoque += item.Qt

                    Else

                        Dim BuscaSaidas = From est In LqEstoque.BaixaEndereco
                                          Where est.IdEndereco = item.Endereco
                                          Select est.Qt

                        For Each qt_it In BuscaSaidas.ToList

                            QtEstoque -= qt_it

                        Next

                        QtEstoque += item.Qt

                    End If

                Next


                DtLiberações.Rows.Add(row.IdProduto, Buscadescricao.First, row.Destino, FormatDateTime(row.DataSol, DateFormat.ShortDate), row.Qtdade, QtEstoque, My.Resources.delivery, row.IdSolicitacao, QtEstoque)

            Else

                Dim LqOficina As New LqOficinaDataContext

                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                Dim buscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                               Where sol.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                               Select sol.IdCodCad, sol.Descricao

                If buscaSol.Count > 0 Then
                    'busca descricao do item

                    Dim Buscadescricao = From prod In LqBase.Produtos
                                         Where prod.IdProduto = buscaSol.First.IdCodCad
                                         Select prod.Descricao

                    If Buscadescricao.Count > 0 Then
                        'busca qtdade no estoque


                        Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                           Where est.IdProduto = buscaSol.First.IdCodCad
                                           Select est.Qt, est.Endereco

                        Dim QtEstoque As Integer = 0

                        For Each item In BuscaEstoque.ToList

                            'busca saidas deste lote

                            Dim ProcuraIdEndereco = From ende In LqEstoque.EnderecoEstoqueLocal
                                                    Where ende.NomeEndereco Like item.Endereco
                                                    Select ende.IdEndereco

                            Dim BuscaSaidas = From est In LqEstoque.BaixaEndereco
                                              Where est.IdEndereco = ProcuraIdEndereco.First
                                              Select est.Qt

                            For Each qt_it In BuscaSaidas.ToList

                                QtEstoque -= qt_it

                            Next

                            QtEstoque += item.Qt

                        Next

                        DtLiberações.Rows.Add(buscaSol.First.IdCodCad, Buscadescricao.First, row.Destino, FormatDateTime(row.DataSol, DateFormat.ShortDate), row.Qtdade, QtEstoque, My.Resources.delivery, row.IdSolicitacao, QtEstoque)

                    Else

                        DtLiberações.Rows.Add(buscaSol.First.IdCodCad, buscaSol.First.Descricao, row.Destino, FormatDateTime(row.DataSol, DateFormat.ShortDate), row.Qtdade, 0, My.Resources.delivery, row.IdSolicitacao, 0)

                    End If

                End If

            End If

        Next

        'carrega itens liberados pelo sistema

        Dim BuscaLiberados = From sol In LqEstoque.SolicitacaoProdutosEstoque
                             Where sol.Status = True And sol.Ret = False
                             Select sol.Ret, sol.IdProduto, sol.Qtdade, sol.DataSol, sol.Destino, sol.IdSolicitacao, sol.IdSolicitacaoCad, sol.IdSolicitante

        DtRetirada.Rows.Clear()

        For Each row In BuscaLiberados.ToList

            If row.IdProduto > 0 Then

                'busca descricao do item

                Dim Buscadescricao = From prod In LqBase.Produtos
                                     Where prod.IdProduto = row.IdProduto
                                     Select prod.Descricao

                'busca qtdade no estoque

                Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                   Where est.IdProduto = row.IdProduto
                                   Select est.Qt

                Dim QtEstoque As Integer = 0

                For Each item In BuscaEstoque.ToList

                    QtEstoque += item

                Next

                Dim Retirado As String = ""
                Dim Imagem As Image = Nothing

                If row.Ret = False Then
                    Retirado = "Aguardando retirada"
                    Imagem = My.Resources.alert_icon_icons_com_52395
                Else
                    Retirado = "Retirado"
                    Imagem = My.Resources.check_ok_accept_apply_1582
                End If

                'Busca nome do solicitante

                Dim BuscaNome = From nome In LqBase.Funcionarios
                                Where nome.IdFuncionario = row.IdSolicitante
                                Select nome.NomeCompleto

                DtRetirada.Rows.Add(FormatDateTime(row.DataSol, DateFormat.ShortDate), row.IdSolicitacao, FrmPrincipal.LblNomeUsuario.Text, row.Qtdade, Retirado, Imagem, row.IdSolicitante, row.IdProduto, "", My.Resources.arrow_right_16742)

            Else

                Dim LqOficina As New LqOficinaDataContext

                LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                Dim buscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                               Where sol.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                               Select sol.IdCodCad

                'busca descricao do item

                Dim Buscadescricao = From prod In LqBase.Produtos
                                     Where prod.IdProduto = buscaSol.First
                                     Select prod.Descricao

                'busca qtdade no estoque

                Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                   Where est.IdProduto = buscaSol.First
                                   Select est.Qt

                Dim QtEstoque As Integer = 0

                For Each item In BuscaEstoque.ToList

                    QtEstoque += item

                Next

                Dim Retirado As String = ""
                Dim Imagem As Image = Nothing

                If row.Ret = False Then
                    Retirado = "Aguardando retirada"
                    Imagem = My.Resources.alert_icon_icons_com_52395
                Else
                    Retirado = "Retirado"
                    Imagem = My.Resources.check_ok_accept_apply_1582
                End If

                'Busca nome do solicitante

                DtRetirada.Rows.Add(FormatDateTime(row.DataSol, DateFormat.ShortDate), row.IdSolicitacao, FrmPrincipal.LblNomeUsuario.Text, row.Qtdade, Retirado, Imagem, row.IdSolicitante, buscaSol.First, "", My.Resources.arrow_right_16742)

            End If

        Next

        For Each row As DataGridViewRow In DtLiberações.Rows
            Dim Qtdade As Integer = 0
            For Each row0 As DataGridViewRow In DtRetirada.Rows
                If row.Cells(0).Value = row0.Cells(7).Value Then

                    Qtdade += row.Cells(4).Value

                End If
            Next
            For Each row0 As DataGridViewRow In DtRetirada.Rows
                If row.Cells(0).Value = row0.Cells(7).Value Then

                    Dim QtRes As Integer = row.Cells(8).Value - Qtdade
                    row.Cells(5).Value = QtRes

                End If
            Next
        Next

    End Sub

    Public Sub VerificaEstoque()

    End Sub

    Private Sub DtLiberações_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellContentClick

        If DtLiberações.Columns(e.ColumnIndex).Name = "ClmLiberar" Then

            Me.Cursor = Cursors.WaitCursor

            'verifica se item possui qtdade suficiente

            Dim QtSol As Integer = DtLiberações.Rows(e.RowIndex).Cells(4).Value
            Dim QtEst As Integer = DtLiberações.Rows(e.RowIndex).Cells(5).Value
            Dim IdSl As Integer = DtLiberações.Rows(e.RowIndex).Cells(7).Value

            If QtSol <= QtEst Then

                'abre aba de liberação

                If MsgBox("Deseja liberar este item?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    LqEstoque.AtualizaSolicitacaoProdutosEstoque(IdSl, True, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay)


                    'carrega itens liberados pelo sistema

                    Dim BuscaLiberados = From sol In LqEstoque.SolicitacaoProdutosEstoque
                                         Where sol.Status = True And sol.Ret = False
                                         Select sol.Ret, sol.IdProduto, sol.Qtdade, sol.DataSol, sol.Destino, sol.IdSolicitacao, sol.IdSolicitacaoCad, sol.IdSolicitante

                    DtRetirada.Rows.Clear()

                    For Each row In BuscaLiberados.ToList

                        If row.IdProduto > 0 Then

                            'busca descricao do item

                            Dim Buscadescricao = From prod In LqBase.Produtos
                                                 Where prod.IdProduto = row.IdProduto
                                                 Select prod.Descricao

                            'busca qtdade no estoque

                            Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                               Where est.IdProduto = row.IdProduto
                                               Select est.Qt

                            Dim QtEstoque As Integer = 0

                            For Each item In BuscaEstoque.ToList

                                QtEstoque += item

                            Next

                            Dim Retirado As String = ""
                            Dim Imagem As Image = Nothing

                            If row.Ret = False Then
                                Retirado = "Aguardando retirada"
                                Imagem = My.Resources.alert_icon_icons_com_52395
                            Else
                                Retirado = "Retirado"
                                Imagem = My.Resources.check_ok_accept_apply_1582
                            End If

                            'Busca nome do solicitante

                            Dim BuscaNome = From nome In LqBase.Funcionarios
                                            Where nome.IdFuncionario = row.IdSolicitante
                                            Select nome.NomeCompleto

                            DtRetirada.Rows.Add(FormatDateTime(row.DataSol, DateFormat.ShortDate), row.IdSolicitacao, FrmPrincipal.LblNomeUsuario.Text, row.Qtdade, Retirado, Imagem, row.IdSolicitante, row.IdProduto, "", My.Resources.arrow_right_16742)

                        Else

                            Dim LqOficina As New LqOficinaDataContext

                            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                            Dim buscaSol = From sol In LqOficina.SolicitacaoCadastroPeca
                                           Where sol.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                                           Select sol.IdCodCad

                            'busca descricao do item

                            Dim Buscadescricao = From prod In LqBase.Produtos
                                                 Where prod.IdProduto = buscaSol.First
                                                 Select prod.Descricao

                            'busca qtdade no estoque

                            Dim BuscaEstoque = From est In LqEstoque.Armazenagem
                                               Where est.IdProduto = buscaSol.First
                                               Select est.Qt

                            Dim QtEstoque As Integer = 0

                            For Each item In BuscaEstoque.ToList

                                QtEstoque += item

                            Next

                            Dim Retirado As String = ""
                            Dim Imagem As Image = Nothing

                            If row.Ret = False Then
                                Retirado = "Aguardando retirada"
                                Imagem = My.Resources.alert_icon_icons_com_52395
                            Else
                                Retirado = "Retirado"
                                Imagem = My.Resources.check_ok_accept_apply_1582
                            End If

                            'Busca nome do solicitante

                            DtRetirada.Rows.Add(FormatDateTime(row.DataSol, DateFormat.ShortDate), row.IdSolicitacao, FrmPrincipal.LblNomeUsuario.Text, row.Qtdade, Retirado, Imagem, row.IdSolicitante, buscaSol.First, "", My.Resources.arrow_right_16742)

                        End If

                    Next

                    'remove da lista

                    DtLiberações.Rows.RemoveAt(e.RowIndex)

                    For Each row As DataGridViewRow In DtLiberações.Rows
                        Dim Qtdade As Integer = 0
                        For Each row0 As DataGridViewRow In DtRetirada.Rows
                            If row.Cells(0).Value = row0.Cells(7).Value Then

                                Qtdade += row.Cells(4).Value

                            End If
                        Next
                        For Each row0 As DataGridViewRow In DtRetirada.Rows
                            If row.Cells(0).Value = row0.Cells(7).Value Then

                                Dim QtRes As Integer = row.Cells(8).Value - Qtdade
                                row.Cells(5).Value = QtRes

                            End If
                        Next
                    Next

                End If

            Else

                MsgBox("Não há quantidade suficiente em estoque para liberar esta solicitação.", MsgBoxStyle.OkOnly)

            End If

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub DtLiberações_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellDoubleClick

    End Sub

    Private Sub DtRetirada_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtRetirada.CellContentClick

        If DtRetirada.Columns(e.ColumnIndex).Name = "ClmEntregar" Then
            If DtRetirada.Rows(e.RowIndex).Cells(4).Value.ToString = "Aguardando retirada" Then

                If MsgBox("Você esta prestes a liberar itens do estoque, deseja prosseguir com a operação?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

                    'carrega solicitaões para o solicitante

                    Dim BuscaSoliciatçõesNaoRetirada = From ret In LqEstoque.SolicitacaoProdutosEstoque
                                                       Where ret.IdSolicitacao = DtRetirada.Rows(e.RowIndex).Cells(1).Value.ToString And ret.Ret = False
                                                       Select ret.Qtdade, ret.IdProduto, ret.IdSolicitacaoCad, ret.IdSolicitacao, ret.Destino

                    Dim LstInseridos As New ListBox

                    For Each row In BuscaSoliciatçõesNaoRetirada.ToList

                        Dim DestinoOrcamento As Integer = row.Destino.Remove(0, 4)

                        Dim LqComercial As New LqComercialDataContext
                        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                        If row.IdProduto > 0 Then

                            Dim BuscaOrcamento = From orc In LqComercial.ProdutosOrcamento
                                                 Where orc.IdOrcamento = DestinoOrcamento And orc.IdProduto = row.IdProduto
                                                 Select orc.IdImagemAval

                            If BuscaOrcamento.Count > 0 Then

                                Dim BuscaIdProduto = From orc In LqBase.Produtos
                                                     Where orc.IdProduto = row.IdProduto
                                                     Select orc.IdProdutoExt

                                'busca id do orçamento ext

                                Dim BuscaOrc = From orc In LqComercial.Orcamentos
                                               Where orc.IdOrcamento = DestinoOrcamento
                                               Select orc.IdCorOrcamentoExt

                                'atualiza pra inicio

                                Dim baseUrlStatus As String = "http://www.iarasoftware.com.br/atualiza_solicitacao_3_0.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdOrcamento=" & BuscaOrc.First & "&IdItem=" & BuscaIdProduto.First

                                'carrega informações no site

                                ' Chamada sincrona
                                Dim syncClientStatus = New WebClient()
                                Dim contentStatus = syncClientStatus.DownloadString(baseUrlStatus)
                                'verifica endereço

                                Dim BuscaEndereco = From ende In LqEstoque.Armazenagem
                                                    Where ende.IdProduto = row.IdProduto
                                                    Select ende.Qt, ende.Endereco, ende.IdArmazenagem

                                'procura endereços possiveis para baixa

                                For Each linha In BuscaEndereco.ToList

                                    Dim BuscaBaixa = From ende In LqEstoque.BaixaEndereco
                                                     Where ende.IdEndereco = linha.IdArmazenagem
                                                     Select ende.Qt

                                    Dim QtBaixa As Integer = linha.Qt

                                    For Each row2 In BuscaBaixa.ToList
                                        QtBaixa -= row2
                                    Next

                                    If QtBaixa > 0 Then
                                        If Not LstInseridos.Items.Contains(linha.Endereco) Then
                                            LstInseridos.Items.Add(linha.Endereco)
                                            FrmSepararProduto.DtEndereco.Rows.Add(row.IdProduto, linha.Qt, 0, linha.Endereco)
                                        End If
                                    End If

                                Next

                                Dim Separados As Integer = row.Qtdade
                                Dim Encerra As Boolean = False

                                For Each item In BuscaEndereco.ToList

                                    Dim BuscaBaixa = From ende In LqEstoque.BaixaEndereco
                                                     Where ende.IdEndereco = item.IdArmazenagem
                                                     Select ende.Qt

                                    Dim QtBaixa As Integer = 0

                                    For Each row2 In BuscaBaixa.ToList
                                        QtBaixa += row2
                                    Next

                                    If QtBaixa < item.Qt Then

                                        Dim BUscaEnderecoDesc = From desc In LqEstoque.EnderecoEstoqueLocal
                                                                Where desc.NomeEndereco Like item.Endereco
                                                                Select desc.IdEstoque, desc.NomeEndereco, desc.IdAndar

                                        If Encerra = False Then

                                            If item.Qt >= Separados Then

                                                'subtrai qtdade do estoque

                                                'busca a descrição do item

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row.IdProduto
                                                                   Select prod.Descricao

                                                If Not item.Endereco.StartsWith("temp") Then

                                                    Dim BUscaEnderecoDesc0 = From desc In LqEstoque.EnderecoEstoqueLocal
                                                                             Where desc.IdEndereco = item.Endereco
                                                                             Select desc.IdEstoque, desc.NomeEndereco, desc.IdAndar

                                                    Dim BuscaAndarEnde = From andar In LqEstoque.AndarEstoqueLocal
                                                                         Where andar.IdAndar = BUscaEnderecoDesc0.First.IdAndar
                                                                         Select andar.IdPredio, andar.NomeAndar

                                                    Dim BuscaPredioAndar = From pred In LqEstoque.PredioEstoqueLocal
                                                                           Where pred.IdPredio = BuscaAndarEnde.First.IdPredio
                                                                           Select pred.NomePredio, pred.IdRua

                                                    Dim BuscaRuaPredio = From pred In LqEstoque.RuasEstoqueLocal
                                                                         Where pred.IdRua = BuscaPredioAndar.First.IdRua
                                                                         Select pred.IdQuadra, pred.NomeRua

                                                    Dim BuscaQuadra = From quad In LqEstoque.QuadrasEstoqueLocal
                                                                      Where quad.IdQuadra - BuscaRuaPredio.First.IdQuadra
                                                                      Select quad.NomeQuadra, quad.IdEstoque

                                                    Dim BuscaEstoque = From est In LqEstoque.EstoquesLocais
                                                                       Where est.IdEstoque = BUscaEnderecoDesc0.First.IdEstoque
                                                                       Select est.NomeEstoque

                                                    FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First, Separados, BuscaEstoque.First, BuscaQuadra.First.NomeQuadra, BuscaRuaPredio.First.NomeRua, BuscaPredioAndar.First.NomePredio, BuscaAndarEnde.First.NomeAndar, BUscaEnderecoDesc0.First.NomeEndereco, My.Resources.antipatia, row.IdSolicitacao, 0, "", row.IdProduto, row.Destino)
                                                Else
                                                    FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First, Separados, "", "", "", "", "", "", My.Resources.antipatia, row.IdSolicitacao, 0, "", row.IdProduto, row.Destino)
                                                End If

                                                Separados -= row.Qtdade
                                                Encerra = True

                                            Else

                                                'remove do estoque


                                                'subtrai qtdade do estoque


                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = row.IdProduto
                                                                   Select prod.Descricao

                                                If Not item.Endereco.StartsWith("temp") Then

                                                    Dim BUscaEnderecoDesc0 = From desc In LqEstoque.EnderecoEstoqueLocal
                                                                             Where desc.IdEndereco = item.Endereco
                                                                             Select desc.IdEstoque, desc.NomeEndereco, desc.IdAndar

                                                    Dim BuscaAndarEnde = From andar In LqEstoque.AndarEstoqueLocal
                                                                         Where andar.IdAndar = BUscaEnderecoDesc0.First.IdAndar
                                                                         Select andar.IdPredio, andar.NomeAndar

                                                    Dim BuscaPredioAndar = From pred In LqEstoque.PredioEstoqueLocal
                                                                           Where pred.IdPredio = BuscaAndarEnde.First.IdPredio
                                                                           Select pred.NomePredio, pred.IdRua

                                                    Dim BuscaRuaPredio = From pred In LqEstoque.RuasEstoqueLocal
                                                                         Where pred.IdRua = BuscaPredioAndar.First.IdRua
                                                                         Select pred.IdQuadra, pred.NomeRua

                                                    Dim BuscaQuadra = From quad In LqEstoque.QuadrasEstoqueLocal
                                                                      Where quad.IdQuadra - BuscaRuaPredio.First.IdQuadra
                                                                      Select quad.NomeQuadra, quad.IdEstoque

                                                    Dim BuscaEstoque = From est In LqEstoque.EstoquesLocais
                                                                       Where est.IdEstoque = BUscaEnderecoDesc0.First.IdEstoque
                                                                       Select est.NomeEstoque

                                                    FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First, Separados, BuscaEstoque.First, BuscaQuadra.First.NomeQuadra, BuscaRuaPredio.First.NomeRua, BuscaPredioAndar.First.NomePredio, BuscaAndarEnde.First.NomeAndar, BUscaEnderecoDesc0.First.NomeEndereco, My.Resources.antipatia, row.IdSolicitacao, 0, "", row.IdProduto, row.Destino)
                                                Else
                                                    FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First, Separados, "", "", "", "", "", "", My.Resources.antipatia, row.IdSolicitacao, 0, "", row.IdProduto, row.Destino)
                                                End If

                                                Separados -= item.Qt

                                            End If

                                        End If

                                    End If

                                Next

                            End If

                        Else

                            Dim Lqoficina As New LqOficinaDataContext
                            Lqoficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                            Dim BuscaSolic = From sol In Lqoficina.SolicitacaoCadastroPeca
                                             Where sol.IdSolicitacaoCadastro = row.IdSolicitacaoCad
                                             Select sol.IdCodCad

                            Dim BuscaProduto = From prod In LqBase.Produtos
                                               Where prod.IdProduto = BuscaSolic.First
                                               Select prod.Descricao, prod.IdProdutoExt

                            'verifica endereço

                            Dim BuscaEndereco = From ende In LqEstoque.Armazenagem
                                                Where ende.IdProduto = BuscaSolic.First
                                                Select ende.Qt, ende.Endereco

                            For Each linha In BuscaEndereco.ToList

                                If Not LstInseridos.Items.Contains(linha.Endereco) Then
                                    LstInseridos.Items.Add(linha.Endereco)
                                    FrmSepararProduto.DtEndereco.Rows.Add(BuscaSolic.First, linha.Qt, 0, linha.Endereco)
                                End If

                            Next

                            Dim Separados As Integer = row.Qtdade
                            Dim Encerra As Boolean = False

                            If BuscaEndereco.First.Endereco.ToString.StartsWith("temp") Then

                                Dim C As Integer = 0

                                For Each it As DataGridViewRow In FrmSepararProduto.DtLiberações.Rows
                                    If it.Cells(0).Value.ToString = BuscaProduto.First.Descricao Then
                                        Dim QtEnc As Integer = it.Cells(1).Value
                                        Dim QtSoma As Integer = Separados + QtEnc
                                        it.Cells(1).Value = QtSoma
                                        C += 1
                                    End If
                                Next

                                If C = 0 Then
                                    FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First.Descricao, Separados, "Temporário", "", "", "", "", "", My.Resources.antipatia, row.IdSolicitacao, 0, "", BuscaSolic.First, row.Destino)
                                End If

                            Else

                                Dim C As Integer = 0

                                For Each it As DataGridViewRow In FrmSepararProduto.DtLiberações.Rows
                                    If it.Cells(0).Value.ToString = BuscaProduto.First.Descricao Then
                                        Dim QtEnc As Integer = it.Cells(1).Value
                                        Dim QtSoma As Integer = Separados + QtEnc
                                        it.Cells(1).Value = QtSoma
                                        C += 1
                                    End If
                                Next

                                If C = 0 Then

                                    FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First.Descricao, Separados, "Fixo", "", "", "", "", "", My.Resources.antipatia, row.IdSolicitacao, 0, "", BuscaSolic.First, row.Destino)

                                End If

                            End If

                            For Each item In BuscaEndereco.ToList

                                Dim BUscaEnderecoDesc = From desc In LqEstoque.EnderecoEstoqueLocal
                                                        Where desc.IdEndereco = item.Endereco
                                                        Select desc.IdEstoque, desc.NomeEndereco, desc.IdAndar

                                Dim BuscaAndarEnde = From andar In LqEstoque.AndarEstoqueLocal
                                                     Where andar.IdAndar = BUscaEnderecoDesc.First.IdAndar
                                                     Select andar.IdPredio, andar.NomeAndar

                                Dim BuscaPredioAndar = From pred In LqEstoque.PredioEstoqueLocal
                                                       Where pred.IdPredio = BuscaAndarEnde.First.IdPredio
                                                       Select pred.NomePredio, pred.IdRua

                                Dim BuscaRuaPredio = From pred In LqEstoque.RuasEstoqueLocal
                                                     Where pred.IdRua = BuscaPredioAndar.First.IdRua
                                                     Select pred.IdQuadra, pred.NomeRua

                                Dim BuscaQuadra = From quad In LqEstoque.QuadrasEstoqueLocal
                                                  Where quad.IdQuadra - BuscaRuaPredio.First.IdQuadra
                                                  Select quad.NomeQuadra, quad.IdEstoque

                                Dim BuscaEstoque = From est In LqEstoque.EstoquesLocais
                                                   Where est.IdEstoque = BUscaEnderecoDesc.First.IdEstoque
                                                   Select est.NomeEstoque

                                If Encerra = False Then

                                    If item.Qt >= Separados Then

                                        'subtrai qtdade do estoque

                                        'busca a descrição do item


                                        Separados -= row.Qtdade
                                        Encerra = True

                                    Else

                                        'remove do estoque


                                        FrmSepararProduto.DtLiberações.Rows.Add(BuscaProduto.First.Descricao, item.Qt, BuscaEstoque.First, BuscaQuadra.First.NomeQuadra, BuscaRuaPredio.First.NomeRua, BuscaPredioAndar.First.NomePredio, BuscaAndarEnde.First.NomeAndar, BUscaEnderecoDesc.First.NomeEndereco, My.Resources.antipatia, row.IdSolicitacao, 0, item.Endereco)

                                        Separados -= item.Qt

                                    End If

                                End If

                            Next

                        End If

                    Next

                    FrmSepararProduto.DtLiberações.Enabled = True

                    FrmSepararProduto.Show(Me)

                End If

            Else

                MsgBox("Solicitação encerrada!")

            End If
        End If

    End Sub

    Private Sub DtRetirada_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtRetirada.CellDoubleClick


    End Sub

    Private Sub DtLiberações_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtLiberações.CellContentDoubleClick

    End Sub
End Class