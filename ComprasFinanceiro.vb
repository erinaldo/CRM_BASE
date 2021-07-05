Imports System.Net
Imports Newtonsoft.Json

Public Class ComprasFinanceiro
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext
    Dim LqBase As New DtCadastroDataContext
    Dim LqIara As New LqJarbesDataContext
    Dim LqComercial As New LqComercialDataContext

    Dim LstIdFornecedores As New ListBox
    Dim LstIdFormaPg As New ListBox
    Dim LstPcMax As New ListBox
    Dim LstIntervalo As New ListBox
    Dim LstD_M As New ListBox
    Dim LstAVista As New ListBox

    Dim LstIdProduto As New ListBox
    Dim LstIdSolCadProduto As New ListBox

    Dim LqOficina As New LqOficinaDataContext

    Public Sub PopulaTreeview()

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        'Busca fornecedores para os quais  foi designado compra

        Dim BuscaSolicitacoesCompra = From ot In LqFinanceiro.SolicitacoesCompraFinanceiro
                                      Where ot.IdAutorizador = 0
                                      Select ot.IdCotacao, ot.IdProduto, ot.IdSolicitacaoCad, ot.Qt, ot.IdSolicitacaoCompra, ot.IdSolicitante, ot.DataSol, ot.HoraSol

        'popula numero da cotação

        Dim ValorTotal As Decimal = 0
        Dim TotalCot As Integer = 0

        Dim CotacoesPendentes As Integer = 0

        For Each itens In BuscaSolicitacoesCompra.ToList

            Dim HailitaFormsPg As Boolean = False

            'busca cot~ções ativas

            Dim BuscaCotações = From cot In LqFinanceiro.Cotacoes
                                Where cot.IdCotacao = itens.IdCotacao And cot.IdCotador <> 0
                                Select cot.IdFornecedor, cot.ValorCotado, cot.Qt

            If BuscaCotações.Count > 0 Then

                Dim BuscaNomeFornecedor = From fornec In LqBase.Fornecedores
                                          Where fornec.IdFornecedor = BuscaCotações.First.IdFornecedor.Remove(0, 2)
                                          Select fornec.Nome

                If BuscaNomeFornecedor.Count > 0 Then

                    Dim IdFornec As Integer = -1

                    For Each rowPr As TreeNode In TrItens.Nodes

                        If rowPr.Text = BuscaCotações.First.IdFornecedor & " - " & BuscaNomeFornecedor.First Then

                            IdFornec = rowPr.Index

                        End If

                    Next

                    If IdFornec = -1 Then

                        TrItens.Nodes.Add(BuscaCotações.First.IdFornecedor & " - " & BuscaNomeFornecedor.First)
                        'TrItens.ExpandAll()

                        'adiciona o numero da cotação

                        Dim TrCta As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)

                        TrCta.Nodes.Add("Cotação. " & itens.IdCotacao)

                        Dim TrProdutos As TreeNode = TrCta.Nodes(TrCta.Nodes.Count - 1)

                        Dim _IdPopula As String = ""

                        If itens.IdProduto = 0 Then

                            Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                   Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                   Select sol.Descricao

                            TrProdutos.Nodes.Add("S" & itens.IdSolicitacaoCad & " - " & BuscaSolcitacoes.First)
                            _IdPopula = "S" & itens.IdSolicitacaoCad

                        Else

                            Dim BuscaProduto = From prod In LqBase.Produtos
                                               Where prod.IdProduto = itens.IdProduto
                                               Select prod.Descricao

                            TrProdutos.Nodes.Add(itens.IdProduto & " - " & BuscaProduto.First)
                            _IdPopula = itens.IdProduto

                        End If

                        Dim TrValores As TreeNode = TrProdutos.Nodes(TrProdutos.Nodes.Count - 1)

                        TrValores.Nodes.Add("Qtdade aut. " & itens.Qt)

                        TrValores.Nodes.Add("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * BuscaCotações.First.Qt, NumDigitsAfterDecimal:=2))

                        TrValores.Nodes.Add("Solicitações.")

                        TrValores.Nodes.Add("Qtdade Min. " & BuscaCotações.First.Qt)

                        'TrCta.ExpandAll()

                        Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                        TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                        Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                        'busca solicitante

                        Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                           Where usu.IdFuncionario = itens.IdSolicitante
                                           Select usu.NomeCompleto

                        TrSolicitante.Nodes.Add(itens.IdSolicitante)

                        TrSolicitante.Nodes.Add(itens.Qt)
                        TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                        TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                        TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                        TrSolicitante.Nodes.Add(itens.Qt)

                        TrSolicit.Collapse()

                    Else

                        'adiciona o numero da cotação

                        Dim TrCta As TreeNode = TrItens.Nodes(IdFornec)

                        Dim IdCot As Integer = -1

                        For Each row0 As TreeNode In TrCta.Nodes

                            If row0.Text = "Cotação. " & itens.IdCotacao Then

                                IdCot = row0.Index

                            End If

                        Next

                        If IdCot = -1 Then

                            TrCta.Nodes.Add("Cotação. " & itens.IdCotacao)

                            Dim TrProdutos As TreeNode = TrCta.Nodes(TrCta.Nodes.Count - 1)

                            Dim _IdPopula As String = ""

                            If itens.IdProduto = 0 Then

                                Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                       Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                       Select sol.Descricao

                                TrProdutos.Nodes.Add("S" & itens.IdSolicitacaoCad & " - " & BuscaSolcitacoes.First)

                                _IdPopula = "S" & itens.IdSolicitacaoCad

                            Else

                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                   Where prod.IdProduto = itens.IdProduto
                                                   Select prod.Descricao

                                TrProdutos.Nodes.Add(itens.IdProduto & " - " & BuscaProduto.First)

                                _IdPopula = itens.IdProduto

                            End If

                            Dim TrValores As TreeNode = TrProdutos.Nodes(TrProdutos.Nodes.Count - 1)

                            TrValores.Nodes.Add("Qtdade. " & itens.Qt)

                            TrValores.Nodes.Add("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * itens.Qt, NumDigitsAfterDecimal:=2))

                            TrValores.Nodes.Add("Solicitações.")

                            TrValores.Nodes.Add("Qtdade Min. " & BuscaCotações.First.Qt)

                            'TrCta.ExpandAll()

                            Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                            TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                            Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                            'busca solicitante

                            Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                               Where usu.IdFuncionario = itens.IdSolicitante
                                               Select usu.NomeCompleto

                            TrSolicitante.Nodes.Add(itens.IdSolicitante)

                            TrSolicitante.Nodes.Add(itens.Qt)
                            TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                            TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                            TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                            TrSolicitante.Nodes.Add(itens.Qt)

                            TrSolicit.Collapse()

                        Else

                            Dim TrProdutos As TreeNode = TrCta.Nodes(IdCot)

                            Dim IdProd As Integer = -1

                            Dim Qt_Acresc As Integer = 0

                            For Each row1 As TreeNode In TrProdutos.Nodes

                                If itens.IdProduto = 0 Then

                                    Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                           Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                           Select sol.Descricao

                                    If "S" & itens.IdSolicitacaoCad.ToString & " - " & BuscaSolcitacoes.First = row1.Text Then

                                        IdProd = row1.Index
                                        Qt_Acresc += row1.Nodes(0).Text.Remove(0, 8)

                                    End If

                                Else

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProduto = itens.IdProduto
                                                       Select prod.Descricao

                                    If itens.IdProduto & " - " & BuscaProduto.First = row1.Text Then

                                        IdProd = row1.Index

                                    End If

                                End If

                            Next

                            If IdProd = -1 Then

                                Dim _IdPopula As String = ""

                                If itens.IdProduto = 0 Then

                                    Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                           Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                           Select sol.Descricao

                                    TrProdutos.Nodes.Add("S" & itens.IdSolicitacaoCad & " - " & BuscaSolcitacoes.First)
                                    _IdPopula = "S" & itens.IdSolicitacaoCad

                                Else

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProduto = itens.IdProduto
                                                       Select prod.Descricao

                                    TrProdutos.Nodes.Add(itens.IdProduto & " - " & BuscaProduto.First)
                                    _IdPopula = itens.IdProduto

                                End If

                                Dim TrValores As TreeNode = TrProdutos.Nodes(TrProdutos.Nodes.Count - 1)

                                TrValores.Nodes.Add("Qtdade. " & itens.Qt)

                                TrValores.Nodes.Add("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * itens.Qt, NumDigitsAfterDecimal:=2))

                                'TrValores.ExpandAll()

                                Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                                TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                                Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                                'busca solicitante

                                Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                                   Where usu.IdFuncionario = itens.IdSolicitante
                                                   Select usu.NomeCompleto

                                TrSolicitante.Nodes.Add(itens.IdSolicitante & " - " & BuscaUsuario.First)

                                TrSolicitante.Nodes.Add(itens.Qt)
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                                TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                                TrSolicitante.Nodes.Add(itens.Qt)

                                TrSolicit.Collapse()

                            Else

                                Dim TrValores As TreeNode = TrProdutos.Nodes(IdProd)

                                TrValores.Nodes(0).Text = ("Qtdade. " & itens.Qt + Qt_Acresc)

                                TrValores.Nodes(1).Text = ("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * (itens.Qt + Qt_Acresc), NumDigitsAfterDecimal:=2))

                                'TrValores.ExpandAll()

                                Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                                TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                                Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                                'busca solicitante

                                Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                                   Where usu.IdFuncionario = itens.IdSolicitante
                                                   Select usu.NomeCompleto

                                TrSolicitante.Nodes.Add(itens.IdSolicitante & " - " & BuscaUsuario.First)

                                TrSolicitante.Nodes.Add(itens.Qt)
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                                TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                                TrSolicitante.Nodes.Add(itens.Qt)

                                TrSolicit.Collapse()

                            End If

                        End If

                    End If

                Else

                    'busca na base on line

                    Dim IdFornec As Integer = -1

                    For Each rowPr As TreeNode In TrItens.Nodes

                        If BuscaCotações.First.IdFornecedor.ToString.StartsWith("I_") Then
                            If rowPr.Text = BuscaCotações.First.IdFornecedor & " - " & BuscaNomeFornecedor.First Then

                                IdFornec = rowPr.Index

                            End If
                        Else
                            If rowPr.Text = BuscaCotações.First.IdFornecedor Then

                                IdFornec = rowPr.Index

                            End If
                        End If

                    Next

                    If IdFornec = -1 Then

                        TrItens.Nodes.Add(BuscaCotações.First.IdFornecedor & " - ")
                        'TrItens.ExpandAll()

                        'adiciona o numero da cotação

                        Dim TrCta As TreeNode = TrItens.Nodes(TrItens.Nodes.Count - 1)

                        TrCta.Nodes.Add("Cotação. " & itens.IdCotacao)

                        Dim TrProdutos As TreeNode = TrCta.Nodes(TrCta.Nodes.Count - 1)

                        Dim _IdPopula As String = ""

                        If itens.IdProduto = 0 Then

                            Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                   Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                   Select sol.Descricao

                            TrProdutos.Nodes.Add("S" & itens.IdSolicitacaoCad & " - " & BuscaSolcitacoes.First)
                            _IdPopula = "S" & itens.IdSolicitacaoCad

                        Else

                            Dim BuscaProduto = From prod In LqBase.Produtos
                                               Where prod.IdProduto = itens.IdProduto
                                               Select prod.Descricao

                            TrProdutos.Nodes.Add(itens.IdProduto & " - " & BuscaProduto.First)
                            _IdPopula = itens.IdProduto

                        End If

                        Dim TrValores As TreeNode = TrProdutos.Nodes(TrProdutos.Nodes.Count - 1)

                        TrValores.Nodes.Add("Qtdade aut. " & itens.Qt)

                        TrValores.Nodes.Add("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * BuscaCotações.First.Qt, NumDigitsAfterDecimal:=2))

                        TrValores.Nodes.Add("Solicitações.")

                        TrValores.Nodes.Add("Qtdade Min. " & BuscaCotações.First.Qt)

                        'TrCta.ExpandAll()

                        Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                        TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                        Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                        'busca solicitante

                        Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                           Where usu.IdFuncionario = itens.IdSolicitante
                                           Select usu.NomeCompleto

                        TrSolicitante.Nodes.Add(itens.IdSolicitante)

                        TrSolicitante.Nodes.Add(itens.Qt)
                        TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                        TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                        TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                        TrSolicitante.Nodes.Add(itens.Qt)

                        TrSolicit.Collapse()

                    Else

                        'adiciona o numero da cotação

                        Dim TrCta As TreeNode = TrItens.Nodes(IdFornec)

                        Dim IdCot As Integer = -1

                        For Each row0 As TreeNode In TrCta.Nodes

                            If row0.Text = "Cotação. " & itens.IdCotacao Then

                                IdCot = row0.Index

                            End If

                        Next

                        If IdCot = -1 Then

                            TrCta.Nodes.Add("Cotação. " & itens.IdCotacao)

                            Dim TrProdutos As TreeNode = TrCta.Nodes(TrCta.Nodes.Count - 1)

                            Dim _IdPopula As String = ""

                            If itens.IdProduto = 0 Then

                                Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                       Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                       Select sol.Descricao

                                TrProdutos.Nodes.Add("S" & itens.IdSolicitacaoCad & " - " & BuscaSolcitacoes.First)

                                _IdPopula = "S" & itens.IdSolicitacaoCad

                            Else

                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                   Where prod.IdProduto = itens.IdProduto
                                                   Select prod.Descricao

                                TrProdutos.Nodes.Add(itens.IdProduto & " - " & BuscaProduto.First)

                                _IdPopula = itens.IdProduto

                            End If

                            Dim TrValores As TreeNode = TrProdutos.Nodes(TrProdutos.Nodes.Count - 1)

                            TrValores.Nodes.Add("Qtdade. " & itens.Qt)

                            TrValores.Nodes.Add("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * itens.Qt, NumDigitsAfterDecimal:=2))

                            TrValores.Nodes.Add("Solicitações.")

                            TrValores.Nodes.Add("Qtdade Min. " & BuscaCotações.First.Qt)

                            'TrCta.ExpandAll()

                            Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                            TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                            Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                            'busca solicitante

                            Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                               Where usu.IdFuncionario = itens.IdSolicitante
                                               Select usu.NomeCompleto

                            TrSolicitante.Nodes.Add(itens.IdSolicitante)

                            TrSolicitante.Nodes.Add(itens.Qt)
                            TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                            TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                            TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                            TrSolicitante.Nodes.Add(itens.Qt)

                            TrSolicit.Collapse()

                        Else

                            Dim TrProdutos As TreeNode = TrCta.Nodes(IdCot)

                            Dim IdProd As Integer = -1

                            Dim Qt_Acresc As Integer = 0

                            For Each row1 As TreeNode In TrProdutos.Nodes

                                If itens.IdProduto = 0 Then

                                    Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                           Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                           Select sol.Descricao

                                    If "S" & itens.IdSolicitacaoCad.ToString & " - " & BuscaSolcitacoes.First = row1.Text Then

                                        IdProd = row1.Index
                                        Qt_Acresc += row1.Nodes(0).Text.Remove(0, 8)

                                    End If

                                Else

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProduto = itens.IdProduto
                                                       Select prod.Descricao

                                    If itens.IdProduto & " - " & BuscaProduto.First = row1.Text Then

                                        IdProd = row1.Index

                                    End If

                                End If

                            Next

                            If IdProd = -1 Then

                                Dim _IdPopula As String = ""

                                If itens.IdProduto = 0 Then

                                    Dim BuscaSolcitacoes = From sol In LqOficina.SolicitacaoCadastroPeca
                                                           Where sol.IdSolicitacaoCadastro = itens.IdSolicitacaoCad
                                                           Select sol.Descricao

                                    TrProdutos.Nodes.Add("S" & itens.IdSolicitacaoCad & " - " & BuscaSolcitacoes.First)
                                    _IdPopula = "S" & itens.IdSolicitacaoCad

                                Else

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProduto = itens.IdProduto
                                                       Select prod.Descricao

                                    TrProdutos.Nodes.Add(itens.IdProduto & " - " & BuscaProduto.First)
                                    _IdPopula = itens.IdProduto

                                End If

                                Dim TrValores As TreeNode = TrProdutos.Nodes(TrProdutos.Nodes.Count - 1)

                                TrValores.Nodes.Add("Qtdade. " & itens.Qt)

                                TrValores.Nodes.Add("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * itens.Qt, NumDigitsAfterDecimal:=2))

                                'TrValores.ExpandAll()

                                Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                                TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                                Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                                'busca solicitante

                                Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                                   Where usu.IdFuncionario = itens.IdSolicitante
                                                   Select usu.NomeCompleto

                                TrSolicitante.Nodes.Add(itens.IdSolicitante & " - " & BuscaUsuario.First)

                                TrSolicitante.Nodes.Add(itens.Qt)
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                                TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                                TrSolicitante.Nodes.Add(itens.Qt)

                                TrSolicit.Collapse()

                            Else

                                Dim TrValores As TreeNode = TrProdutos.Nodes(IdProd)

                                TrValores.Nodes(0).Text = ("Qtdade. " & itens.Qt + Qt_Acresc)

                                TrValores.Nodes(1).Text = ("Subtotal. " & FormatCurrency(BuscaCotações.First.ValorCotado * (itens.Qt + Qt_Acresc), NumDigitsAfterDecimal:=2))

                                'TrValores.ExpandAll()

                                Dim TrSolicit As TreeNode = TrValores.Nodes(2)

                                TrSolicit.Nodes.Add("Solicitação. " & itens.IdSolicitacaoCompra & " - " & FormatDateTime(itens.DataSol, DateFormat.LongDate) & ",as " & FormatDateTime(itens.HoraSol.ToString, DateFormat.LongTime))

                                Dim TrSolicitante As TreeNode = TrSolicit.Nodes(TrSolicit.Nodes.Count - 1)

                                'busca solicitante

                                Dim BuscaUsuario = From usu In LqBase.Funcionarios
                                                   Where usu.IdFuncionario = itens.IdSolicitante
                                                   Select usu.NomeCompleto

                                TrSolicitante.Nodes.Add(itens.IdSolicitante & " - " & BuscaUsuario.First)

                                TrSolicitante.Nodes.Add(itens.Qt)
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2))
                                TrSolicitante.Nodes.Add(FormatCurrency(BuscaCotações.First.ValorCotado, NumDigitsAfterDecimal:=2) * itens.Qt)

                                TrSolicitante.Nodes.Add(BuscaCotações.First.Qt)

                                TrSolicitante.Nodes.Add(itens.Qt)

                                TrSolicit.Collapse()

                            End If

                        End If

                    End If

                End If

            Else

                'manda para a cotação do produto

                CotacoesPendentes += 1

            End If

        Next

        'expande o primeiro nivel

        For Each it As TreeNode In TrItens.Nodes

            it.Expand()

            For Each it0 As TreeNode In it.Nodes

                it0.Expand()

            Next

        Next

        If CotacoesPendentes = 0 Then

            For Each fornecedor As TreeNode In TrItens.Nodes

                Dim _Total As Decimal

                For Each Cotacoes As TreeNode In fornecedor.Nodes

                    If Cotacoes.Index < Cotacoes.Nodes.Count Then

                        For Each Produtos As TreeNode In Cotacoes.Nodes

                            _Total += Produtos.Nodes(1).Text.Remove(0, 10)

                        Next

                    End If

                Next

                'popula datagrid

                DtFornecedores.Rows.Add(fornecedor.Text, FormatCurrency(_Total, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(_Total, NumDigitsAfterDecimal:=2), My.Resources.alert_icon_icons_com_52395)

            Next

            'popula formas de pg

            Dim Desconto As Decimal

            LblSubTotal.Text = FormatCurrency(ValorTotal, NumDigitsAfterDecimal:=2)
            LblTotal.Text = FormatCurrency(ValorTotal - Desconto, NumDigitsAfterDecimal:=2)

        Else

            If MsgBox("Existem cotações pendentes no sistema, deseja inseri-las agora?" & Chr(13) & "Posso direcionar você para lá agora?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                FrmPrincipal.CotaçõesToolStripMenuItem.PerformClick()

                Me.Close()

            Else

                For Each fornecedor As TreeNode In TrItens.Nodes

                    Dim _Total As Decimal

                    For Each Cotacoes As TreeNode In fornecedor.Nodes

                        If Cotacoes.Index < Cotacoes.Nodes.Count Then

                            For Each Produtos As TreeNode In Cotacoes.Nodes

                                _Total += Produtos.Nodes(1).Text.Remove(0, 10)

                            Next

                        End If

                    Next

                    'popula datagrid

                    DtFornecedores.Rows.Add(fornecedor.Text, FormatCurrency(_Total, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(_Total, NumDigitsAfterDecimal:=2), My.Resources.alert_icon_icons_com_52395)

                Next

                'popula formas de pg

                Dim Desconto As Decimal

                LblSubTotal.Text = FormatCurrency(ValorTotal, NumDigitsAfterDecimal:=2)
                LblTotal.Text = FormatCurrency(ValorTotal - Desconto, NumDigitsAfterDecimal:=2)

            End If

        End If

    End Sub

    Dim AbreForm As Boolean = False
    Dim LstValor As New ListBox

    Private Sub ComprasFinanceiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulaTreeview()

        VerificaValores()

    End Sub

    Private Sub CmbFormasPgEntrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFormasPgEntrada.SelectedIndexChanged

        If CmbFormasPgEntrada.Items.Contains(CmbFormasPgEntrada.Text) Then

            NmParcelas.Maximum = LstPcMax.Items(CmbFormasPgEntrada.SelectedIndex).ToString

            If LstAVista.Items(CmbFormasPgEntrada.SelectedIndex).ToString = "True" Then

                NmParcelas.Enabled = False

                NmParcelas.Value = 1
                NmParcelas.Maximum = LstPcMax.Items(CmbFormasPgEntrada.SelectedIndex).ToString

                TxtValor.Enabled = True

                TxtValor.Focus()

            Else

                NmParcelas.Value = 1
                NmParcelas.Maximum = LstPcMax.Items(CmbFormasPgEntrada.SelectedIndex).ToString

                TxtValor.Enabled = True

                If LstPcMax.Items(CmbFormasPgEntrada.SelectedIndex).ToString > 1 Then
                    NmParcelas.Enabled = True
                    NmParcelas.Focus()

                Else
                    NmParcelas.Enabled = False
                    TxtValor.Focus()

                End If

            End If

        End If

    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

        If TxtValor.Text = "" Then
            TxtValor.Text = 0
        End If

        If TxtValor.Text <> "" Then

            BttInsere.Enabled = True

        End If

    End Sub


    Private Sub TxtValor_GotFocus(sender As Object, e As EventArgs) Handles TxtValor.GotFocus

        TxtValor.Text = FormatNumber(TxtValor.Text, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtValor.LostFocus

        Try

            Dim _total As Decimal

            For Each row As DataGridViewRow In DtFormas.Rows
                _total += row.Cells(3).Value
            Next

            Dim _ValorINserido As Decimal = TxtValor.Text

            If _ValorINserido + _total <= LblTotal.Text Then
                TxtValor.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)
            Else
                Dim ValorTotal As Decimal = LblTotal.Text
                TxtValor.Text = FormatCurrency(ValorTotal - _total, NumDigitsAfterDecimal:=2)
            End If

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub BttInsere_Click(sender As Object, e As EventArgs) Handles BttInsere.Click

        Dim Intervalo As Integer = LstIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString

        Dim NumParcela As Integer = NmParcelas.Value
        Dim Valor As Decimal = TxtValor.Text

        Dim C As Integer = 1

        If LstAVista.Items(CmbFormasPgEntrada.SelectedIndex).ToString = False Then
            While NumParcela >= C

                If LstD_M.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                    DtFormas.Rows.Add(LstIdFormaPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * Intervalo), DateFormat.ShortDate), ImageList1.Images(3), ImageList1.Images(2), LstIdPgExt.Items(CmbFormasPgEntrada.SelectedIndex).ToString)

                Else

                    DtFormas.Rows.Add(LstIdFormaPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddMonths(C * Intervalo), DateFormat.ShortDate), ImageList1.Images(3), ImageList1.Images(2), LstIdPgExt.Items(CmbFormasPgEntrada.SelectedIndex).ToString)

                End If

                C += 1

            End While
        Else
            DtFormas.Rows.Add(LstIdFormaPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * 0), DateFormat.ShortDate), ImageList1.Images(3), ImageList1.Images(2), LstIdPgExt.Items(CmbFormasPgEntrada.SelectedIndex).ToString)
        End If

        CmbFormasPgEntrada.Text = ""

        NmParcelas.Enabled = False
        TxtValor.Enabled = False

        NmParcelas.Value = 1
        TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        Dim _ValorPg As Decimal

        For Each row As DataGridViewRow In DtFormas.Rows
            _ValorPg += row.Cells(3).Value
        Next

        Dim Total As Decimal = LblTotal.Text

        LblRestante.Text = FormatCurrency(Total - _ValorPg, NumDigitsAfterDecimal:=2)

        If _ValorPg >= LblTotal.Text Then
            BttAprovarCompra.Enabled = True
        Else
            BttAprovarCompra.Enabled = False
        End If

    End Sub


    Private Sub DtFormas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellContentClick

        Dim LstIndexApagar As New ListBox

        Dim Total As Decimal = LblTotal.Text

        If DtFormas.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            Dim IdSel As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value
            Dim SomaTotal As Decimal = 0

            'varre pra ver se tem mais

            For Each row As DataGridViewRow In DtFormas.Rows

                If row.Cells(0).Value = IdSel Then

                    LstIndexApagar.Items.Add(row.Index)

                Else

                    SomaTotal += row.Cells(3).Value

                End If

            Next

            If MsgBox("Você tem certeza que deseja remover esta forma de pagamento?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For i As Integer = LstIndexApagar.Items.Count - 1 To 0 Step -1

                    DtFormas.Rows.RemoveAt(LstIndexApagar.Items(i).ToString)

                    LblRestante.Text = FormatCurrency(Total - SomaTotal, NumDigitsAfterDecimal:=2)

                Next

            End If

        End If

    End Sub

    Dim DataGuard As Date

    Private Sub DtFormas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellEndEdit

        'verifica se valor é valido, e se deseja incorporar mudanças nos próximos vencimentos

        Try

            DtFormas.Rows(e.RowIndex).Cells(4).Value = FormatDateTime(DtFormas.Rows(e.RowIndex).Cells(4).Value, DateFormat.ShortDate)

            If MsgBox("Deseja atualizar as datas abaixo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim Data As Date = DtFormas.Rows(e.RowIndex).Cells(4).Value
                Dim _Cod As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value
                'busca intervalo

                Dim BuscaIntervalo = From inter In LqFinanceiro.FormasPgEntrada
                                     Where inter.IdFormasPgEntrada = _Cod
                                     Select inter.Intervalo, inter.TipoIntervalo

                Dim _intervalo As Integer = BuscaIntervalo.First.Intervalo
                Dim _TipoIntervalo As Boolean = BuscaIntervalo.First.TipoIntervalo

                Dim _C As Integer = 1

                For Each row As DataGridViewRow In DtFormas.Rows

                    If row.Index > e.RowIndex Then

                        If row.Cells(0).Value = DtFormas.Rows(e.RowIndex).Cells(0).Value Then

                            If _TipoIntervalo = True Then

                                Data = Data.AddDays(_C * _intervalo)

                                row.Cells(4).Value = FormatDateTime(Data, DateFormat.ShortDate)

                            Else

                                Data = Data.AddMonths(_C * _intervalo)

                                row.Cells(4).Value = FormatDateTime(Data, DateFormat.ShortDate)

                            End If

                            _C += 1

                        End If

                    End If

                Next

            End If

        Catch ex As Exception

            MsgBox("O valor não é uma data válida.", vbOKOnly)

            DtFormas.Rows(e.RowIndex).Cells(4).Value = FormatDateTime(DataGuard, DateFormat.ShortDate)

        End Try

    End Sub

    Private Sub DtFormas_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DtFormas.CellBeginEdit

        DataGuard = DtFormas.Rows(e.RowIndex).Cells(4).Value

    End Sub

    Private Sub BttRecusar_Click(sender As Object, e As EventArgs)

        TrItens.Nodes.Clear()
        DtFormas.Rows.Clear()
        CmbFormasPgEntrada.Items.Clear()
        LstIdFormaPg.Items.Clear()
        LstIntervalo.Items.Clear()
        LstD_M.Items.Clear()
        LstAVista.Items.Clear()
        LstPcMax.Items.Clear()

        PopulaTreeview()

        If TrItens.Nodes.Count = 0 Then
            MsgBox("As solicitações de compra foram encerradas.", MsgBoxStyle.OkOnly)
            Me.Close()
        End If

    End Sub

    Private Sub BttAprovarCompra_Click(sender As Object, e As EventArgs) Handles BttAprovarCompra.Click

        Dim LstFormas As New ListBox
        Dim LstValido As New ListBox

        For Each row As DataGridViewRow In DtFormas.Rows

            If Not LstFormas.Items.Contains(row.Cells(0).Value) Then

                LstFormas.Items.Add(row.Cells(0).Value)
                'varre a lista de pagamentos inseridos

                Dim _Valor As Decimal = 0

                'procura total de parcelas 

                Dim _Parcelas As Decimal = 0

                For Each row0 As DataGridViewRow In DtFormas.Rows

                    If row.Cells(0).Value = row0.Cells(0).Value Then
                        _Parcelas += 1
                        _Valor += row.Cells(3).Value
                    End If

                Next

                Dim IdFormaPg As Integer = row.Cells(0).Value

                Dim BuscaDadosParaPg = From pg In LqFinanceiro.FormasPgSaida
                                       Where pg.IdFormasPgSaida = IdFormaPg
                                       Select pg.NumCartao, pg.NomeTitular, pg.Cvv, pg.Bandeira, pg.Validade

                'valida 

                Dim baseUrlValidaTransacao As String = "http://www.iarasoftware.com.br/valida_transacao_cartao.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Valor=" & _Valor & "&NumCartao=" & BuscaDadosParaPg.First.NumCartao & "&Parcelas=" & _Parcelas & "&Validade=" & BuscaDadosParaPg.First.Validade & "&Cvv=" & BuscaDadosParaPg.First.Cvv & "&NomeTitular=" & BuscaDadosParaPg.First.NomeTitular & "&Bandeira=" & BuscaDadosParaPg.First.Bandeira

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientValidaTransacao = New WebClient()
                Dim contentValidaTransacao = syncClientValidaTransacao.DownloadString(baseUrlValidaTransacao)
                Dim readValidaTransacao = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.TransacaoCartao))("[" & contentValidaTransacao & "]")

                If readValidaTransacao.Item(0).CREATE = "OK" Then

                    LstValido.Items.Add("Ok")
                    row.Cells(6).Value = ImageList1.Images(0)

                    For Each row0 As DataGridViewRow In DtFormas.Rows

                        If row.Cells(0).Value = row0.Cells(0).Value Then
                            row0.Cells(6).Value = ImageList1.Images(0)
                            row0.Cells(8).Value = readValidaTransacao.Item(0).OP
                        End If

                    Next

                    'pedido

                Else

                    LstValido.Items.Add("Erro")
                    row.Cells(6).Value = ImageList1.Images(1)

                    For Each row0 As DataGridViewRow In DtFormas.Rows

                        If row.Cells(0).Value = row0.Cells(0).Value Then
                            row0.Cells(6).Value = ImageList1.Images(1)
                        End If

                    Next

                End If

            End If

        Next

        Dim PedidoOnLine As Boolean = False

        'LstValido.Items.Add("Erro")
        Dim IdPedido As Integer = 0

        If Not LstValido.Items.Contains("Erro") Then
            'aprova solicitação de compra 

            For Each fornecedor As TreeNode In TrItens.Nodes

                For Each Cotacoes As TreeNode In fornecedor.Nodes

                    For Each Produtos As TreeNode In Cotacoes.Nodes

                        For Each Solicitações As TreeNode In Produtos.Nodes(2).Nodes

                            Dim _ValorUnit As Decimal = Solicitações.Nodes(3).Text
                            Dim _ValorTotal As Decimal = Solicitações.Nodes(2).Text
                            Dim _Qt As Integer = Solicitações.Nodes(1).Text
                            Dim _QtAdq As Integer = Solicitações.Nodes(5).Text

                            'verifica o inicio e quebra texto ara achar o indice

                            Dim Contexto As String = Solicitações.Text

                            Dim str As String = Contexto
                            Dim separador As String = "-"
                            Dim palavras As String() = str.Split(separador)
                            Dim LstPalavras As New ListBox
                            Dim palavra As String

                            For Each palavra In palavras
                                LstPalavras.Items.Add(palavra)
                            Next

                            Dim Cod As Integer = LstPalavras.Items(0).ToString.Remove(0, 13)

                            LqFinanceiro.AtualizaSolicitacaoCompraProdutos(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Cod)

                            Dim CodCot As Integer = Cotacoes.Text.Remove(0, 9)

                            LqFinanceiro.AtualizaCompraCotacaoProdutos(CodCot, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, True)

                            'atualiza qtdade solicitada

                            LqFinanceiro.AtualizaSolicitacaoQtCompraProdutos(Cod, _QtAdq)

                            'se fornecedor = chave

                            If Not fornecedor.Text.StartsWith("I") Then

                                PedidoOnLine = True

                                Dim CodFornecAlt As String = fornecedor.Text.Remove(fornecedor.Text.Length - 3, 3)

                                'procura pedido web e local

                                Dim ValorEnc As String = CodFornecAlt

                                LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                                If LstPalavras.Items(0).ToString.StartsWith("Solicitação") Then

                                    Dim ContextoProd As String = Produtos.Text

                                    Dim strProd As String = ContextoProd
                                    Dim separadorProd As String = "-"
                                    Dim palavrasProd As String() = strProd.Split(separadorProd)
                                    Dim LstPalavrasProd As New ListBox
                                    Dim palavraProd As String

                                    For Each palavraProd In palavrasProd
                                        LstPalavrasProd.Items.Add(palavraProd)
                                    Next

                                    Dim CodProd As String = LstPalavrasProd.Items(0).ToString

                                    CodProd = CodProd.Replace("S", "S_")
                                    CodProd = CodProd.Replace(" ", "")

                                    Dim BuscaSolicitacao = From sol In LqComercial.PedidoOnLine
                                                           Where sol.ChaveFornecedor Like CodFornecAlt And sol.IdProdInt Like CodProd And sol.Entregue = 0
                                                           Select sol.IdPedidoOnLine, sol.Qtdade, sol.VlrComissao, sol.VlrCompra, sol.DataSol, sol.HoraSol, sol.ChaveFornecedor, sol.ChaveEntregador, sol.IdItemExterno

                                    If BuscaSolicitacao.Count > 0 Then

                                        If BuscaSolicitacao.Count > 1 Then

                                            'remove o mais antigo e permanece com o mais novo

                                            LqComercial.DeletaPedidoOnLine(BuscaSolicitacao.ToList.Last.IdPedidoOnLine)

                                            'atualiza o pedido

                                            LqComercial.AtualizaStatus1_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, _Qt, 1)

                                            'cria pedido on line
                                            Dim _qtEnc As Integer = _Qt
                                            Dim Comissao As Decimal = 0
                                            Dim Total As Decimal = _qtEnc * BuscaSolicitacao.First.VlrCompra
                                            Comissao = (Total * _qtEnc) * (0.99 / 100)

                                            Dim Frete As Decimal = 0
                                            Dim KmPercorrido As Decimal = 0
                                            Dim VlrKm As Decimal = 0
                                            Dim Multiplicador As Decimal = 0

                                            If IdPedido = 0 Then

                                                Dim ModoFrete As String = ""

                                                If CmbFrete.SelectedItem.ToString.Contains("Prestador I.A.R.A.") Then
                                                    ModoFrete = "ENT"
                                                Else
                                                    ModoFrete = "RET"
                                                End If

                                                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_pedido_online.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                                            & "&ChavePrestador=" & BuscaSolicitacao.First.ChaveFornecedor & "&ChaveEntregador=" & ModoFrete _
                                            & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString & "&Qtdade=" & _Qt & "&ValorUnit=" & BuscaSolicitacao.First.VlrCompra.ToString.Replace(",", ".") _
                                            & "&SubTotal=" & Total.ToString.Replace(",", ".") & "&Comissao=" & Comissao _
                                            & "&Frete=" & Frete & "&KmPercorrido=" & KmPercorrido & "&VlrKm=" & VlrKm & "&Multiplicador=" & Multiplicador _
                                            & "&Status=" & 0 & "&IdVoucher=0" & "&DataAceite=1111-11-11&HoraAceite=00:00:00&DataEstoqueValidado=1111-11-11&HoraEstoqueValidado=00:00:00" _
                                            & "&DataFinanceiroLib=1111-11-11&HoraFinanceiroLib=00:00:00&DataSeparacao=1111-11-11&HoraSeparacao=00:00:00&DataExpedicao=1111-11-11&HoraExpedicao=00:00:00" _
                                            & "DataColeta=1111-11-11&HoraColeta=00:00:00&DataEntrega=1111-11-11&HoraEntrega=00:00:00&NomeDoResponsavelEntrega=ND&IdUsuarioNomeDoResponsavel=0"

                                                'carrega informações no site

                                                ' Chamada sincrona
                                                Dim syncClient = New WebClient()
                                                Dim content = syncClient.DownloadString(baseUrl)

                                                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(content)

                                                IdPedido = read.Item(0).Id

                                                'atualiza o pedidoExt

                                                LqComercial.AtualizaIdExterno_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, read.Item(0).Id)
                                                'verifica frete 

                                            End If

                                            'cria na lista de itens no pedido

                                            Dim baseUrlItem As String = "http://www.iarasoftware.com.br/create_item_pedido.php?IdPedido=" & IdPedido & "&IdProdutoIntSol=" & "S_" & Cod & "&IdProdutoExt=" & BuscaSolicitacao.First.IdItemExterno & "&Qtdade=" & _Qt & "&VlrUnit=" & _ValorUnit.ToString.Replace(",", ".") & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChaveFornecedor=" & BuscaSolicitacao.First.ChaveFornecedor

                                            'carrega informações no site

                                            ' Chamada sincrona
                                            Dim syncClientItem = New WebClient()
                                            Dim contentItem = syncClientItem.DownloadString(baseUrlItem)

                                        Else

                                            'atualiza o pedido

                                            LqComercial.AtualizaStatus1_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, _Qt, 1)

                                            'cria pedido on line
                                            Dim _qtEnc As Integer = _Qt
                                            Dim Comissao As Decimal = 0
                                            Dim Total As Decimal = _qtEnc * BuscaSolicitacao.First.VlrCompra
                                            Comissao = (Total * _qtEnc) * (0.99 / 100)

                                            Dim Frete As Decimal = 0
                                            Dim KmPercorrido As Decimal = 0
                                            Dim VlrKm As Decimal = 0
                                            Dim Multiplicador As Decimal = 0

                                            If IdPedido = 0 Then

                                                Dim ModoFrete As String = ""

                                                If CmbFrete.SelectedItem.ToString.Contains("Prestador I.A.R.A.") Then
                                                    ModoFrete = "ENT"
                                                Else
                                                    ModoFrete = "RET"
                                                End If

                                                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_pedido_online.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                                            & "&ChavePrestador=" & BuscaSolicitacao.First.ChaveFornecedor & "&ChaveEntregador=" & ModoFrete _
                                            & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString & "&Qtdade=" & _Qt & "&ValorUnit=" & BuscaSolicitacao.First.VlrCompra.ToString.Replace(",", ".") _
                                            & "&SubTotal=" & Total.ToString.Replace(",", ".") & "&Comissao=" & Comissao _
                                            & "&Frete=" & Frete & "&KmPercorrido=" & KmPercorrido & "&VlrKm=" & VlrKm & "&Multiplicador=" & Multiplicador _
                                            & "&Status=" & 0 & "&IdVoucher=0" & "&DataAceite=1111-11-11&HoraAceite=00:00:00&DataEstoqueValidado=1111-11-11&HoraEstoqueValidado=00:00:00" _
                                            & "&DataFinanceiroLib=1111-11-11&HoraFinanceiroLib=00:00:00&DataSeparacao=1111-11-11&HoraSeparacao=00:00:00&DataExpedicao=1111-11-11&HoraExpedicao=00:00:00" _
                                            & "DataColeta=1111-11-11&HoraColeta=00:00:00&DataEntrega=1111-11-11&HoraEntrega=00:00:00&NomeDoResponsavelEntrega=ND&IdUsuarioNomeDoResponsavel=0"

                                                'carrega informações no site

                                                ' Chamada sincrona
                                                Dim syncClient = New WebClient()
                                                Dim content = syncClient.DownloadString(baseUrl)

                                                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

                                                'atualiza o pedidoExt

                                                LqComercial.AtualizaIdExterno_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, read.Item(0).Id)

                                                IdPedido = read.Item(0).Id

                                            End If

                                            'cria na lista de itens no pedido

                                            Dim baseUrlItem As String = "http://www.iarasoftware.com.br/create_item_pedido.php?IdPedido=" & IdPedido & "&IdProdutoIntSol=" & "S_" & Cod & "&IdProdutoExt=" & BuscaSolicitacao.First.IdItemExterno & "&Qtdade=" & _Qt & "&VlrUnit=" & _ValorUnit.ToString.Replace(",", ".") & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChaveFornecedor=" & BuscaSolicitacao.First.ChaveFornecedor

                                            'carrega informações no site

                                            ' Chamada sincrona
                                            Dim syncClientItem = New WebClient()
                                            Dim contentItem = syncClientItem.DownloadString(baseUrlItem)

                                        End If

                                    End If

                                Else

                                    'insere condiçoes de item com codigo cadastrado

                                    Dim ContextoProd As String = Produtos.Text

                                    Dim strProd As String = ContextoProd
                                    Dim separadorProd As String = "-"
                                    Dim palavrasProd As String() = strProd.Split(separadorProd)
                                    Dim LstPalavrasProd As New ListBox
                                    Dim palavraProd As String

                                    For Each palavraProd In palavrasProd
                                        LstPalavrasProd.Items.Add(palavraProd)
                                    Next

                                    Dim CodProd As Integer = LstPalavrasProd.Items(0).ToString

                                    Dim BuscaSolicitacao = From sol In LqComercial.PedidoOnLine
                                                           Where sol.ChaveFornecedor Like CodFornecAlt And sol.IdProdInt Like CodProd And sol.Entregue = False
                                                           Select sol.IdPedidoOnLine, sol.Qtdade, sol.VlrComissao, sol.VlrCompra, sol.DataSol, sol.HoraSol, sol.ChaveFornecedor, sol.ChaveEntregador, sol.IdItemExterno

                                    If BuscaSolicitacao.Count > 0 Then

                                        If BuscaSolicitacao.Count > 1 Then

                                            'remove o mais antigo e permanece com o mais novo

                                            LqComercial.DeletaPedidoOnLine(BuscaSolicitacao.ToList.Last.IdPedidoOnLine)

                                            'atualiza o pedido

                                            LqComercial.AtualizaStatus1_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, _Qt, 1)

                                            'cria pedido on line
                                            Dim _qtEnc As Integer = _Qt
                                            Dim Comissao As Decimal = 0
                                            Dim Total As Decimal = _qtEnc * BuscaSolicitacao.First.VlrCompra
                                            Comissao = (Total * _qtEnc) * (0.99 / 100)

                                            Dim Frete As Decimal = 0
                                            Dim KmPercorrido As Decimal = 0
                                            Dim VlrKm As Decimal = 0
                                            Dim Multiplicador As Decimal = 0

                                            If IdPedido = 0 Then

                                                Dim ModoFrete As String = ""

                                                If CmbFrete.SelectedItem.ToString.Contains("Prestador I.A.R.A.") Then
                                                    ModoFrete = "ENT"
                                                Else
                                                    ModoFrete = "RET"
                                                End If

                                                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_pedido_online.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                                            & "&ChavePrestador=" & BuscaSolicitacao.First.ChaveFornecedor & "&ChaveEntregador=" & ModoFrete _
                                            & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString & "&Qtdade=" & _Qt & "&ValorUnit=" & BuscaSolicitacao.First.VlrCompra.ToString.Replace(",", ".") _
                                            & "&SubTotal=" & Total.ToString.Replace(",", ".") & "&Comissao=" & Comissao _
                                            & "&Frete=" & Frete & "&KmPercorrido=" & KmPercorrido & "&VlrKm=" & VlrKm & "&Multiplicador=" & Multiplicador _
                                            & "&Status=" & 0 & "&IdVoucher=0" & "&DataAceite=1111-11-11&HoraAceite=00:00:00&DataEstoqueValidado=1111-11-11&HoraEstoqueValidado=00:00:00" _
                                            & "&DataFinanceiroLib=1111-11-11&HoraFinanceiroLib=00:00:00&DataSeparacao=1111-11-11&HoraSeparacao=00:00:00&DataExpedicao=1111-11-11&HoraExpedicao=00:00:00" _
                                            & "DataColeta=1111-11-11&HoraColeta=00:00:00&DataEntrega=1111-11-11&HoraEntrega=00:00:00&NomeDoResponsavelEntrega=ND&IdUsuarioNomeDoResponsavel=0"

                                                'carrega informações no site

                                                ' Chamada sincrona
                                                Dim syncClient = New WebClient()
                                                Dim content = syncClient.DownloadString(baseUrl)

                                                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(content)

                                                IdPedido = read.Item(0).Id

                                                'atualiza o pedidoExt

                                                LqComercial.AtualizaIdExterno_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, read.Item(0).Id)
                                                'verifica frete 

                                            End If

                                            'cria na lista de itens no pedido

                                            Dim baseUrlItem As String = "http://www.iarasoftware.com.br/create_item_pedido.php?IdPedido=" & IdPedido & "&IdProdutoIntSol=" & "S_" & Cod & "&IdProdutoExt=" & BuscaSolicitacao.First.IdItemExterno & "&Qtdade=" & _Qt & "&VlrUnit=" & _ValorUnit.ToString.Replace(",", ".") & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChaveFornecedor=" & BuscaSolicitacao.First.ChaveFornecedor

                                            'carrega informações no site

                                            ' Chamada sincrona
                                            Dim syncClientItem = New WebClient()
                                            Dim contentItem = syncClientItem.DownloadString(baseUrlItem)

                                        Else

                                            'atualiza o pedido

                                            LqComercial.AtualizaStatus1_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, _Qt, 1)

                                            'cria pedido on line
                                            Dim _qtEnc As Integer = _Qt
                                            Dim Comissao As Decimal = 0
                                            Dim Total As Decimal = _qtEnc * BuscaSolicitacao.First.VlrCompra
                                            Comissao = (Total * _qtEnc) * (0.99 / 100)

                                            Dim Frete As Decimal = 0
                                            Dim KmPercorrido As Decimal = 0
                                            Dim VlrKm As Decimal = 0
                                            Dim Multiplicador As Decimal = 0

                                            If IdPedido = 0 Then

                                                Dim ModoFrete As String = ""

                                                If CmbFrete.SelectedItem.ToString.Contains("Prestador I.A.R.A.") Then
                                                    ModoFrete = "ENT"
                                                Else
                                                    ModoFrete = "RET"
                                                End If

                                                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_pedido_online.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text _
                                            & "&ChavePrestador=" & BuscaSolicitacao.First.ChaveFornecedor & "&ChaveEntregador=" & ModoFrete _
                                            & "&DataSolicitacao=" & Today.Date & "&HoraSolicitacao=" & Now.TimeOfDay.ToString & "&Qtdade=" & _Qt & "&ValorUnit=" & BuscaSolicitacao.First.VlrCompra.ToString.Replace(",", ".") _
                                            & "&SubTotal=" & Total.ToString.Replace(",", ".") & "&Comissao=" & Comissao _
                                            & "&Frete=" & Frete & "&KmPercorrido=" & KmPercorrido & "&VlrKm=" & VlrKm & "&Multiplicador=" & Multiplicador _
                                            & "&Status=" & 0 & "&IdVoucher=0" & "&DataAceite=1111-11-11&HoraAceite=00:00:00&DataEstoqueValidado=1111-11-11&HoraEstoqueValidado=00:00:00" _
                                            & "&DataFinanceiroLib=1111-11-11&HoraFinanceiroLib=00:00:00&DataSeparacao=1111-11-11&HoraSeparacao=00:00:00&DataExpedicao=1111-11-11&HoraExpedicao=00:00:00" _
                                            & "DataColeta=1111-11-11&HoraColeta=00:00:00&DataEntrega=1111-11-11&HoraEntrega=00:00:00&NomeDoResponsavelEntrega=ND&IdUsuarioNomeDoResponsavel=0"

                                                'carrega informações no site

                                                ' Chamada sincrona
                                                Dim syncClient = New WebClient()
                                                Dim content = syncClient.DownloadString(baseUrl)

                                                Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

                                                'atualiza o pedidoExt

                                                LqComercial.AtualizaIdExterno_PedidoOnLine(BuscaSolicitacao.First.IdPedidoOnLine, read.Item(0).Id)

                                                IdPedido = read.Item(0).Id

                                            End If

                                            'cria na lista de itens no pedido

                                            Dim baseUrlItem As String = "http://www.iarasoftware.com.br/create_item_pedido.php?IdPedido=" & IdPedido & "&IdProdutoIntSol=" & "S_" & Cod & "&IdProdutoExt=" & BuscaSolicitacao.First.IdItemExterno & "&Qtdade=" & _Qt & "&VlrUnit=" & _ValorUnit.ToString.Replace(",", ".") & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&ChaveFornecedor=" & BuscaSolicitacao.First.ChaveFornecedor

                                            'carrega informações no site

                                            ' Chamada sincrona
                                            Dim syncClientItem = New WebClient()
                                            Dim contentItem = syncClientItem.DownloadString(baseUrlItem)

                                        End If

                                    End If

                                End If

                            End If

                        Next

                    Next

                Next

            Next

            'insere pagamentos no balanecete

            For Each row As DataGridViewRow In DtFormas.Rows

                If IdPedido > 0 Then

                    Dim _Valor As Decimal = 0

                    'procura total de parcelas 

                    Dim _Parcelas As Decimal = 0

                    For Each row0 As DataGridViewRow In DtFormas.Rows

                        If row.Cells(0).Value = row0.Cells(0).Value Then
                            _Parcelas += 1
                            _Valor += row.Cells(3).Value
                        End If

                    Next

                    'insere validação da compra

                    Dim baseUrlValidaPg As String = "http://www.iarasoftware.com.br/atualiza_validacao_pg_online.php?IdPedido=" & IdPedido & "&IdForma=" & row.Cells(7).Value _
                                        & "&VlrTransac=" & _Valor & "&NumOperacao=" & row.Cells(8).Value & "&DataFinanceiroLib=" & Today.Date & "&HoraFinanceiroLib=" & Now.TimeOfDay.ToString

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientValidaPg = New WebClient()
                    Dim contentValidaPg = syncClientValidaPg.DownloadString(baseUrlValidaPg)
                    Dim readValidaPg = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentValidaPg & "]")

                End If

            Next

            For Each row As DataGridViewRow In DtFormas.Rows

                Dim _valor As Decimal = row.Cells(3).Value
                Dim _Vencimento As Date = row.Cells(4).Value
                Dim _Id As Integer = row.Cells(0).Value

                LqFinanceiro.InsereNovaEntradaBalancete(0, _valor, 0, 0, _Vencimento, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 1, False, _Id, "", "Compra de insumos de produção", "Estoque")

            Next

            TrItens.Nodes.Clear()
            DtFormas.Rows.Clear()
            CmbFormasPgEntrada.Items.Clear()
            LstIdFormaPg.Items.Clear()
            LstIntervalo.Items.Clear()
            LstD_M.Items.Clear()
            LstAVista.Items.Clear()
            LstPcMax.Items.Clear()

            PopulaTreeview()

            If TrItens.Nodes.Count = 0 Then
                MsgBox("As solicitações de compra foram encerradas.", MsgBoxStyle.OkOnly)
                FrmPrincipal.CarregaDashboard()
                'verifica se existe aluma compra digital
                If PedidoOnLine = True Then
                    FrmCompraOnline.Show(FrmPrincipal)
                End If

                Me.Close()
            End If

        Else

            MsgBox("Erro na transação")

        End If

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick



    End Sub

    Private Sub DtItens_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItens.CellContentClick

        If DtItens.Columns(e.ColumnIndex).Name = "ClmQtAut" Then

            DtItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Silver
            DtItens.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.SlateGray
            DtItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke
            DtItens.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.SlateGray

        End If

    End Sub

    Private Sub DtFornecedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellClick

        'popula itens solicitados

        DtItens.Rows.Clear()
        VerificaValores()

    End Sub

    Public LstIdPgExt As New ListBox
    Dim LstPredefinido As New ListBox

    Public Sub VerificaValores()

        'popula itens solicitados

        DtItens.Rows.Clear()

        Dim _ValorTotalGeral As Decimal = 0

        For Each fornecedor As TreeNode In TrItens.Nodes

            For Each Cotacoes As TreeNode In fornecedor.Nodes

                For Each Produtos As TreeNode In Cotacoes.Nodes

                    For Each Solicitações As TreeNode In Produtos.Nodes(2).Nodes

                        Dim str As String = Produtos.Text
                        Dim separador As String = "-"
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        For Each palavra In palavras
                            LstPalavras.Items.Add(palavra)
                        Next

                        Dim ProdInt As String = LstPalavras.Items(0).ToString.Remove(LstPalavras.Items(0).ToString.Length - 1, 1)


                        Dim strF As String = fornecedor.Text
                        Dim separadorF As String = "-"
                        Dim palavrasF As String() = strF.Split(separadorF)
                        Dim LstPalavrasF As New ListBox
                        Dim palavraF As String

                        For Each palavraF In palavrasF
                            LstPalavrasF.Items.Add(palavraF)
                        Next

                        Dim ChaveFornecedor As String = LstPalavrasF.Items(0).ToString.Remove(LstPalavrasF.Items(0).ToString.Length - 1, 1)

                        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                        ProdInt = ProdInt.Replace("S", "S_")

                        'verifica se exite pedido que contemple pedido e produto
                        Dim BuscaPedido = From ped In LqComercial.PedidoOnLine
                                          Where ped.IdProdInt Like ProdInt And ped.ChaveFornecedor Like ChaveFornecedor
                                          Select ped.IdItemExterno

                        Dim IdPedido As Integer = 0

                        If BuscaPedido.Count > 0 Then
                            IdPedido = BuscaPedido.First
                        End If

                        Dim _ValorUnit As Decimal = Solicitações.Nodes(2).Text
                        Dim _ValorTotal As Decimal = Solicitações.Nodes(3).Text
                        Dim _Qt As Integer = Solicitações.Nodes(1).Text
                        Dim _MinCompra As Integer = Solicitações.Nodes(4).Text

                        _ValorTotalGeral += _ValorTotal

                        DtItens.Rows.Add(Produtos.Text, "", _Qt, FormatCurrency(_ValorUnit, NumDigitsAfterDecimal:=2), _MinCompra, FormatCurrency(_ValorTotal, NumDigitsAfterDecimal:=2), My.Resources.Cancel_40972, IdPedido)

                        DtItens.Rows(DtItens.Rows.Count - 1).DefaultCellStyle.BackColor = Color.WhiteSmoke
                        DtItens.Rows(DtItens.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.SlateGray
                        DtItens.Rows(DtItens.Rows.Count - 1).DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke
                        DtItens.Rows(DtItens.Rows.Count - 1).DefaultCellStyle.SelectionForeColor = Color.SlateGray

                        'verifica se quantodade é menor

                        If _Qt < _MinCompra Then

                            DtItens.Rows(DtItens.Rows.Count - 1).Cells(2).Style.BackColor = Color.OldLace
                            DtItens.Rows(DtItens.Rows.Count - 1).Cells(2).Style.ForeColor = Color.DarkRed
                            DtItens.Rows(DtItens.Rows.Count - 1).Cells(2).Style.SelectionBackColor = Color.OldLace
                            DtItens.Rows(DtItens.Rows.Count - 1).Cells(2).Style.SelectionForeColor = Color.DarkRed

                        End If

                        CmbFrete.Items.Clear()
                        LstValor.Items.Clear()

                        'Insere frete

                        CmbFrete.Items.Add("Retirar pedido")
                        LstValor.Items.Add(0)
                        LstPredefinido.Items.Add(True)

                        CmbFrete.Items.Add("Transportadora")
                        LstValor.Items.Add(0)
                        LstPredefinido.Items.Add(False)

                        If Not LstPalavrasF.Items(0).ToString.StartsWith("I") Then

                            CmbFrete.Items.Add("Entrega Express - Prestador I.A.R.A. (Distância: 0,00 Km, Valor: R$0,00)")
                            LstValor.Items.Add(0)
                            LstPredefinido.Items.Add(True)

                        End If

                    Next

                Next

            Next

        Next

        'busca formas de pg aceitas

        If DtFornecedores.Rows.Count > 0 Then
            'insere as formas de pagamento

            Dim Contexto As String = DtFornecedores.SelectedCells(0).Value.ToString

            Dim str As String = Contexto
            Dim separador As String = "-"
            Dim palavras As String() = str.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
            Next

            Dim CodFornec As String = LstPalavras.Items(0).ToString.Remove(0, 2)
            If LstPalavras.Items(0).ToString.StartsWith("I") Then

                BtnTrocar.Enabled = False

                CodFornec = CodFornec.Remove(CodFornec.Length - 1, 1)

                Dim BuscaFormasPg = From pg In LqBase.FormasPgFornecedores
                                    Where pg.IdFornecedor = CodFornec
                                    Select pg.D_M, pg.IdFormaPgFornec, pg.IdFormaPgSaída, pg.Intervalo, pg.MaximoPc

                LstPcMax.Items.Clear()
                LstIntervalo.Items.Clear()
                LstIdFormaPg.Items.Clear()
                LstD_M.Items.Clear()
                LstAVista.Items.Clear()
                LstIdPgExt.Items.Clear()

                For Each frmpg In BuscaFormasPg.ToList

                    LstPcMax.Items.Add(frmpg.MaximoPc)
                    LstIntervalo.Items.Add(frmpg.Intervalo)
                    LstIdFormaPg.Items.Add(frmpg.IdFormaPgFornec)
                    LstD_M.Items.Add(frmpg.D_M)
                    LstIdPgExt.Items.Add(0)

                    'busca descricao

                    Dim BuscaDescrção = From desc In LqFinanceiro.FormasPgSaida
                                        Where desc.IdFormasPgSaida = frmpg.IdFormaPgSaída
                                        Select desc.A_Vista, desc.Descricao

                    LstAVista.Items.Add(BuscaDescrção.First.A_Vista)
                    CmbFormasPgEntrada.Items.Add(BuscaDescrção.First.Descricao)

                Next

                'CmbFormasPgEntrada.Enabled = True

                LblSubTotal.Text = FormatCurrency(_ValorTotalGeral, NumDigitsAfterDecimal:=2)
                LblTotal.Text = FormatCurrency(_ValorTotalGeral, NumDigitsAfterDecimal:=2)
                LblRestante.Text = FormatCurrency(_ValorTotalGeral, NumDigitsAfterDecimal:=2)

                TxtDescontosTotais.Enabled = True
                TxtOutrosAcresc.Enabled = True
                TxtImpostos.Enabled = True

            Else

                BtnTrocar.Enabled = True

                'busca na web as formas e popula 

                'carrega imagem do ususario

                Dim baseUrlImagemUsuario As String = "http://www.iarasoftware.com.br/consulta_formas_pg_on_line.php?ChaveOficina=" & LstPalavras.Items(0).ToString

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagemUsuario = New WebClient()
                Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

                Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.FormasPgAceitaOnline))(contentImagemUsuario)

                LstPcMax.Items.Clear()
                LstIntervalo.Items.Clear()
                LstIdFormaPg.Items.Clear()
                LstD_M.Items.Clear()
                LstAVista.Items.Clear()
                CmbFormasPgEntrada.Items.Clear()
                LstIdPgExt.Items.Clear()

                For Each frmpg In readImagemUsuario.ToList

                    Dim Cartao As Boolean = True
                    If frmpg.Cartao = 0 Then
                        Cartao = True
                    Else
                        Cartao = False
                    End If

                    Dim TipoCartao As Boolean = True
                    If frmpg.TipoCartao = 0 Then
                        TipoCartao = True
                    Else
                        TipoCartao = False
                    End If

                    Dim D_M As Boolean = True
                    If frmpg.TipoIntervalo = 0 Then
                        D_M = True
                    Else
                        D_M = False
                    End If

                    Dim AVista As Boolean = True
                    If frmpg.A_Vista = 0 Then
                        AVista = True
                    Else
                        AVista = False
                    End If

                    'busca se forma é compativel com alguma cadastrada

                    Dim BuscaFormaSaida = From said In LqFinanceiro.FormasPgSaida
                                          Where said.Bandeira Like frmpg.Bandeira And said.Cartao = Cartao And said.TipoCartao = TipoCartao
                                          Select said.IdFormasPgSaida, said.NumCartao

                    If BuscaFormaSaida.Count > 0 Then
                        LstPcMax.Items.Add(frmpg.Parcela)
                        LstIntervalo.Items.Add(frmpg.Intervalo)
                        LstIdFormaPg.Items.Add(BuscaFormaSaida.First.IdFormasPgSaida)
                        LstIdPgExt.Items.Add(frmpg.IdFormaPgAceitaOnline)

                        If frmpg.TipoIntervalo = 0 Then
                            LstD_M.Items.Add("True")
                        Else
                            LstD_M.Items.Add("False")
                        End If

                        If frmpg.A_Vista = 0 Then
                            LstAVista.Items.Add("True")
                        Else
                            LstAVista.Items.Add("False")
                        End If

                        CmbFormasPgEntrada.Items.Add(frmpg.Descricao & " (****-****-****-" & BuscaFormaSaida.First.NumCartao.ToCharArray(BuscaFormaSaida.First.NumCartao.Length - 4, 4) & ")")

                    End If

                Next

                If CmbFormasPgEntrada.Items.Count = 0 Then
                    If MsgBox("Nenhuma forma de pagamento aceita pelo fornecedor é compatível com as formas de pagamento cadastradas." & Chr(13) & "Vou direciona-lo para os pagamentos aceitos pelo fornecedor.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information) = MsgBoxResult.Ok Then
                        FrmFormasPgAceitaOnLine.ChaveFornecedor = LstPalavras.Items(0).ToString
                        If Application.OpenForms.OfType(Of FrmFormasPgAceitaOnLine)().Count() = 0 Then
                            FrmFormasPgAceitaOnLine.Show(Me)
                        Else
                            FrmFormasPgAceitaOnLine.Close()
                            FrmFormasPgAceitaOnLine.ChaveFornecedor = LstPalavras.Items(0).ToString
                            FrmFormasPgAceitaOnLine.Show(Me)
                        End If
                    ElseIf MsgBoxResult.No Then
                        'seleciona o próximo da lista

                    ElseIf MsgBoxResult.Cancel Then

                        Me.Cursor = Cursors.WaitCursor

                        FrmPrincipal.CarregaDashboard()

                        Me.Close()

                    End If
                Else
                    'CmbFormasPgEntrada.Enabled = True

                    LblSubTotal.Text = FormatCurrency(_ValorTotalGeral, NumDigitsAfterDecimal:=2)
                    LblTotal.Text = FormatCurrency(_ValorTotalGeral, NumDigitsAfterDecimal:=2)
                    LblRestante.Text = FormatCurrency(_ValorTotalGeral, NumDigitsAfterDecimal:=2)

                    TxtDescontosTotais.Enabled = True
                    TxtOutrosAcresc.Enabled = True
                    TxtImpostos.Enabled = True
                End If

            End If

        Else

            If MsgBox("Não existem ordens de compra no momento.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then

                Me.Cursor = Cursors.WaitCursor

                FrmPrincipal.CarregaDashboard()

                Me.Close()

            End If

        End If

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttInsere.PerformClick()

        End If

    End Sub

    Private Sub TxtFrete_TextChanged(sender As Object, e As EventArgs) Handles TxtFrete.TextChanged

        If TxtFrete.Text = "" Then
            TxtFrete.Text = 0
        ElseIf TxtFrete.Text <> "" Then
            If TxtOutrosAcresc.Text <> "" And TxtFrete.Text <> "" And TxtImpostos.Text <> "" And LblAcrescimos.Text <> "" And LblSubTotal.Text <> "" And LblDescontos.Text <> "" Then
                Dim Valor As Decimal = TxtOutrosAcresc.Text
                Dim Impostos As Decimal = TxtImpostos.Text
                Dim Frete As Decimal = TxtFrete.Text

                If Frete > 0 And TxtFrete.Enabled = True Then

                    CmbFormasPgEntrada.Enabled = True

                End If

                LblAcrescimos.Text = FormatCurrency(Valor + Impostos + Frete, NumDigitsAfterDecimal:=2)

                Dim Desc As Decimal = LblDescontos.Text
                Dim VlrProd As Decimal = LblSubTotal.Text
                Dim Acres As Decimal = LblAcrescimos.Text
                Dim Total As Decimal = (VlrProd + Acres) - Desc

                LblTotal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                LblRestante.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
            End If
        End If

    End Sub

    Private Sub TxtDescontosTotais_TextChanged(sender As Object, e As EventArgs) Handles TxtDescontosTotais.TextChanged

        If TxtDescontosTotais.Text = "" Then
            TxtDescontosTotais.Text = 0
        ElseIf TxtDescontosTotais.Text <> "" Then
            If TxtOutrosAcresc.Text <> "" And TxtFrete.Text <> "" And TxtImpostos.Text <> "" And LblAcrescimos.Text <> "" And LblSubTotal.Text <> "" And LblDescontos.Text <> "" Then

                LblDescontos.Text = FormatCurrency(TxtDescontosTotais.Text, NumDigitsAfterDecimal:=2)
                Dim Valor As Decimal = TxtOutrosAcresc.Text
                Dim Impostos As Decimal = TxtImpostos.Text
                Dim Frete As Decimal = TxtFrete.Text

                LblAcrescimos.Text = FormatCurrency(Valor + Impostos + Frete, NumDigitsAfterDecimal:=2)

                Dim Desc As Decimal = LblDescontos.Text
                Dim VlrProd As Decimal = LblSubTotal.Text
                Dim Acres As Decimal = LblAcrescimos.Text
                Dim Total As Decimal = (VlrProd + Acres) - Desc

                LblTotal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                LblRestante.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
            End If
        End If

    End Sub

    Private Sub TxtImpostos_TextChanged(sender As Object, e As EventArgs) Handles TxtImpostos.TextChanged

        If TxtImpostos.Text = "" Then
            TxtImpostos.Text = 0
        ElseIf TxtImpostos.Text <> "" Then
            If TxtOutrosAcresc.Text <> "" And TxtFrete.Text <> "" And TxtImpostos.Text <> "" And LblAcrescimos.Text <> "" And LblSubTotal.Text <> "" And LblDescontos.Text <> "" Then
                Dim Valor As Decimal = TxtOutrosAcresc.Text
                Dim Impostos As Decimal = TxtImpostos.Text
                Dim Frete As Decimal = TxtFrete.Text

                LblAcrescimos.Text = FormatCurrency(Valor + Impostos + Frete, NumDigitsAfterDecimal:=2)

                Dim Desc As Decimal = LblDescontos.Text
                Dim VlrProd As Decimal = LblSubTotal.Text
                Dim Acres As Decimal = LblAcrescimos.Text
                Dim Total As Decimal = (VlrProd + Acres) - Desc

                LblTotal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                LblRestante.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
            End If
        End If

    End Sub

    Private Sub TxtOutrosAcresc_TextChanged(sender As Object, e As EventArgs) Handles TxtOutrosAcresc.TextChanged

        If TxtOutrosAcresc.Text = "" Then
            TxtOutrosAcresc.Text = 0
        ElseIf TxtOutrosAcresc.Text <> "" Then
            If TxtOutrosAcresc.Text <> "" And TxtFrete.Text <> "" And TxtImpostos.Text <> "" And LblAcrescimos.Text <> "" And LblSubTotal.Text <> "" And LblDescontos.Text <> "" Then
                Dim Valor As Decimal = TxtOutrosAcresc.Text
                Dim Impostos As Decimal = TxtImpostos.Text
                Dim Frete As Decimal = TxtFrete.Text

                LblAcrescimos.Text = FormatCurrency(Valor + Impostos + Frete, NumDigitsAfterDecimal:=2)

                Dim Desc As Decimal = LblDescontos.Text
                Dim VlrProd As Decimal = LblSubTotal.Text
                Dim Acres As Decimal = LblAcrescimos.Text
                Dim Total As Decimal = (VlrProd + Acres) - Desc

                LblTotal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
                LblRestante.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
            End If
        End If

    End Sub

    Private Sub TxtFrete_GotFocus(sender As Object, e As EventArgs) Handles TxtFrete.GotFocus

        TxtFrete.Text = FormatNumber(TxtFrete.Text, NumDigitsAfterDecimal:=2)

        TxtFrete.SelectAll()

    End Sub

    Private Sub TxtDescontosTotais_LostFocus(sender As Object, e As EventArgs) Handles TxtDescontosTotais.LostFocus

        Try

            TxtDescontosTotais.Text = FormatCurrency(TxtDescontosTotais.Text, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtDescontosTotais.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub TxtImpostos_LostFocus(sender As Object, e As EventArgs) Handles TxtImpostos.LostFocus

        Try

            TxtImpostos.Text = FormatCurrency(TxtImpostos.Text, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtImpostos.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub TxtOutrosAcresc_LostFocus(sender As Object, e As EventArgs) Handles TxtOutrosAcresc.LostFocus

        Try

            TxtOutrosAcresc.Text = FormatCurrency(TxtOutrosAcresc.Text, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtOutrosAcresc.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub TxtFrete_LostFocus(sender As Object, e As EventArgs) Handles TxtFrete.LostFocus

        Try

            TxtFrete.Text = FormatCurrency(TxtFrete.Text, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtFrete.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub TxtDescontosTotais_GotFocus(sender As Object, e As EventArgs) Handles TxtDescontosTotais.GotFocus

        TxtDescontosTotais.Text = FormatNumber(TxtDescontosTotais.Text, NumDigitsAfterDecimal:=2)

        TxtDescontosTotais.SelectAll()

    End Sub

    Private Sub TxtImpostos_GotFocus(sender As Object, e As EventArgs) Handles TxtImpostos.GotFocus

        TxtImpostos.Text = FormatNumber(TxtImpostos.Text, NumDigitsAfterDecimal:=2)

        TxtImpostos.SelectAll()

    End Sub

    Private Sub TxtOutrosAcresc_GotFocus(sender As Object, e As EventArgs) Handles TxtOutrosAcresc.GotFocus

        TxtOutrosAcresc.Text = FormatNumber(TxtOutrosAcresc.Text, NumDigitsAfterDecimal:=2)

        TxtOutrosAcresc.SelectAll()

    End Sub

    Private Sub DtItens_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtItens.CellEndEdit

        Try

            'verifica se valor é maior q zero

            Dim ValorUnitário As Decimal = DtItens.Rows(e.RowIndex).Cells(3).Value
            Dim _Qt As Decimal = DtItens.Rows(e.RowIndex).Cells(2).Value
            Dim _MinCompra As Decimal = DtItens.Rows(e.RowIndex).Cells(4).Value
            Dim Total As Decimal = 0

            If ValorUnitário > 0 Then

                Total = _Qt * ValorUnitário

                DtItens.Rows(e.RowIndex).Cells(5).Value = FormatCurrency(Total, NumDigitsAfterDecimal:=2)

                DtItens.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.WhiteSmoke
                DtItens.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.SlateGray
                DtItens.Rows(e.RowIndex).DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke
                DtItens.Rows(e.RowIndex).DefaultCellStyle.SelectionForeColor = Color.SlateGray

                'verifica se quantodade é menor

                If _Qt < _MinCompra Then

                    DtItens.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.OldLace
                    DtItens.Rows(e.RowIndex).Cells(2).Style.ForeColor = Color.DarkRed
                    DtItens.Rows(e.RowIndex).Cells(2).Style.SelectionBackColor = Color.OldLace
                    DtItens.Rows(e.RowIndex).Cells(2).Style.SelectionForeColor = Color.DarkRed

                Else

                    DtItens.Rows(e.RowIndex).Cells(2).Style.BackColor = Color.WhiteSmoke
                    DtItens.Rows(e.RowIndex).Cells(2).Style.ForeColor = Color.SlateGray
                    DtItens.Rows(e.RowIndex).Cells(2).Style.SelectionBackColor = Color.WhiteSmoke
                    DtItens.Rows(e.RowIndex).Cells(2).Style.SelectionForeColor = Color.SlateGray

                End If

                'procura no treeview

                For Each linhas As TreeNode In TrItens.Nodes(DtFornecedores.SelectedCells(0).RowIndex).Nodes

                    For Each Cotacoes As TreeNode In linhas.Nodes

                        If Cotacoes.Text = DtItens.SelectedCells(0).Value Then

                            For Each final As TreeNode In Cotacoes.Nodes(2).Nodes
                                final.Nodes(5).Text = DtItens.SelectedCells(2).Value
                            Next

                        End If

                    Next

                Next

            End If

            Dim TotalSoma As Decimal = 0
            Dim Frete As Decimal = TxtFrete.Text
            Dim Adicional As Decimal = TxtOutrosAcresc.Text
            Dim Desconto As Decimal = TxtDescontosTotais.Text
            Dim Impostos As Decimal = TxtImpostos.Text

            For Each row As DataGridViewRow In DtItens.Rows

                Dim ValorContado As Decimal = row.Cells(5).Value

                TotalSoma += ValorContado

            Next

            LblSubTotal.Text = FormatCurrency(TotalSoma, NumDigitsAfterDecimal:=2)

            LblAcrescimos.Text = FormatCurrency(Frete + Adicional + Impostos, NumDigitsAfterDecimal:=2)

            TotalSoma += Frete
            TotalSoma += Adicional
            TotalSoma += Impostos
            Total -= Desconto

            LblTotal.Text = FormatCurrency(TotalSoma, NumDigitsAfterDecimal:=2)
            LblRestante.Text = FormatCurrency(TotalSoma, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DtItens_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DtItens.CellBeginEdit

    End Sub

    Private Sub DtItens_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtItens.CellEnter

    End Sub

    Private Sub DtItens_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItens.CellClick

    End Sub

    Private Sub TxtFrete_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFrete.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            TxtImpostos.Focus()

        End If

    End Sub

    Private Sub TxtImpostos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtImpostos.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            TxtDescontosTotais.Focus()

        End If

    End Sub

    Private Sub TxtOutrosAcresc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtOutrosAcresc.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            CmbFormasPgEntrada.Focus()

        End If

    End Sub

    Private Sub TxtDescontosTotais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDescontosTotais.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            TxtOutrosAcresc.Focus()

        End If

    End Sub

    Private Sub DtFornecedores_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellEnter

    End Sub

    Private Sub BtnTrocar_Click(sender As Object, e As EventArgs) Handles BtnTrocar.Click

        FrmFormasPgAceitaOnLine.ChaveFornecedor = DtFornecedores.SelectedCells(0).Value.ToString.Remove(DtFornecedores.SelectedCells(0).Value.ToString.Length - 3, 3)

        FrmFormasPgAceitaOnLine.Show(Me)

    End Sub

    Private Sub CmbFrete_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFrete.SelectedIndexChanged

        If CmbFrete.Items.Contains(CmbFrete.Text) Then

            TxtFrete.Text = FormatCurrency(LstValor.Items(CmbFrete.SelectedIndex).ToString, NumDigitsAfterDecimal:=2)

            If LstPredefinido.Items(CmbFrete.SelectedIndex).ToString = "False" Then

                TxtFrete.Enabled = True
                CmbFormasPgEntrada.Enabled = False

            Else

                TxtFrete.Enabled = False
                CmbFormasPgEntrada.Enabled = True

            End If

        End If

    End Sub
End Class