Public Class FrmOtasOrdensCompra
    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        FrmOrdemDeCompra.Show(Me)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public Sub CarregaInicio()

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaSolicitacaoes = From sol In LqFinanceiro.SolicitacoesCompraFinanceiro
                                 Where sol.IdSolicitante = FrmPrincipal.IdUsuario
                                 Select sol.IdSolicitacaoCompra, sol.IdProduto, sol.IdSolicitacaoCad, sol.DataSol, sol.Qt, sol.Recebido, sol.DataAutorizacao

        If Categoria <> "Estoque" Then

            DtProdutoSel.Rows.Clear()

            For Each it In BuscaSolicitacaoes.ToList

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                If it.IdProduto > 0 Then
                    Dim BuscaProduto = From prod In LqBase.Produtos
                                       Where prod.IdProduto = it.IdProduto And prod.Categoria Like Categoria
                                       Select prod.Descricao, prod.CodFabricante

                    If BuscaProduto.Count > 0 Then
                        If it.Recebido = True Then
                            DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.CodFabricante, it.Qt, ImageList1.Images(0))
                        Else
                            If it.DataAutorizacao <> "1111-11-11" Then
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.CodFabricante, it.Qt, ImageList1.Images(2))
                            Else
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.CodFabricante, it.Qt, ImageList1.Images(1))
                            End If
                        End If
                    End If

                Else

                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim BuscaCategoria = From bas In LqBase.CategoriasProdutos
                                         Where bas.Descricao Like Categoria
                                         Select bas.IdCategoriaProduto

                    Dim _IdCategoria As Integer = 0

                    If BuscaCategoria.Count > 0 Then
                        _IdCategoria = BuscaCategoria.First
                    Else
                        'insere nova categoria
                        LqBase.InsereCategoriaProduto(Categoria)
                        _IdCategoria = LqBase.CategoriasProdutos.ToList.Last.IdCategoriaProduto
                    End If

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                       Where prod.IdSolicitacaoCadastro = it.IdSolicitacaoCad And prod.IdCategoria = _IdCategoria
                                       Select prod.Descricao, prod.PartNumber

                    If BuscaProduto.Count > 0 Then

                        If it.Recebido = True Then
                            DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.PartNumber, it.Qt, ImageList1.Images(0))
                        Else
                            If it.DataAutorizacao <> "1111-11-11" Then
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.PartNumber, it.Qt, ImageList1.Images(2))
                            Else
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.PartNumber, it.Qt, ImageList1.Images(1))
                            End If
                        End If
                    End If

                End If

            Next

        Else

            DtProdutoSel.Rows.Clear()

            For Each it In BuscaSolicitacaoes.ToList

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                If it.IdProduto > 0 Then
                    Dim BuscaProduto = From prod In LqBase.Produtos
                                       Where prod.IdProduto = it.IdProduto And prod.Categoria Like "*"
                                       Select prod.Descricao, prod.CodFabricante

                    If BuscaProduto.Count > 0 Then
                        If it.Recebido = True Then
                            DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.CodFabricante, it.Qt, ImageList1.Images(0))
                        Else
                            If it.DataAutorizacao <> "1111-11-11" Then
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.CodFabricante, it.Qt, ImageList1.Images(2))
                            Else
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.CodFabricante, it.Qt, ImageList1.Images(1))
                            End If
                        End If
                    End If

                Else

                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    Dim LqOficina As New LqOficinaDataContext
                    LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

                    Dim BuscaProduto = From prod In LqOficina.SolicitacaoCadastroPeca
                                       Where prod.IdSolicitacaoCadastro = it.IdSolicitacaoCad
                                       Select prod.Descricao, prod.PartNumber

                    If BuscaProduto.Count > 0 Then

                        If it.Recebido = True Then
                            DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.PartNumber, it.Qt, ImageList1.Images(0))
                        Else
                            If it.DataAutorizacao <> "1111-11-11" Then
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.PartNumber, it.Qt, ImageList1.Images(2))
                            Else
                                DtProdutoSel.Rows.Add(it.IdSolicitacaoCompra, FormatDateTime(it.DataSol, DateFormat.ShortDate), BuscaProduto.First.Descricao, BuscaProduto.First.PartNumber, it.Qt, ImageList1.Images(1))
                            End If
                        End If
                    End If

                End If

            Next

        End If

    End Sub

    Public Categoria As String

    Private Sub FrmOtasOrdensCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub
End Class