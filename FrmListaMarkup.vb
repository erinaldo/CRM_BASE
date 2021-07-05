Public Class FrmListaMarkup
    Private Sub FrmListaMarkup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaProdutos = From prod In LqBase.Produtos
                            Where prod.IdProduto Like "*"
                            Select prod.IdProduto, prod.Descricao, prod.Fabricante, prod.Markup

        For Each row In BuscaProdutos.ToList

            If row.Markup = 0 Then
                DtEsperados.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=4), ImageList1.Images(0), ImageList1.Images(2))
            Else
                DtEsperados.Rows.Add(row.IdProduto, row.Descricao, row.Fabricante, FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=4), ImageList1.Images(1), ImageList1.Images(2))
            End If

        Next

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim BuscaSolicitacoes = From prod In LqOficina.SolicitacaoCadastroPeca
                                Where prod.IdCodCad = 0
                                Select prod.IdSolicitacaoCadastro, prod.Descricao, prod.Markup, prod.Fabricante

        For Each row In BuscaSolicitacoes.ToList

            If row.Markup = 0 Then
                DtEsperados.Rows.Add("Sol. " & row.IdSolicitacaoCadastro, row.Descricao, row.Fabricante, FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=4), ImageList1.Images(0), ImageList1.Images(2))
            Else
                DtEsperados.Rows.Add("Sol. " & row.IdSolicitacaoCadastro, row.Descricao, row.Fabricante, FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=4), ImageList1.Images(1), ImageList1.Images(2))
            End If

        Next

        Dim BuscaServico = From serv In LqBase.Servicos
                           Where serv.IdServico Like "*"
                           Select serv.IdServico, serv.Descricao, serv.TME, serv.VlrVeda, serv.Markup

        For Each row In BuscaServico.ToList

            If row.Markup = 0 Then
                DtServicos.Rows.Add(row.IdServico, row.Descricao, FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=4), ImageList1.Images(0), ImageList1.Images(2))
            Else
                DtServicos.Rows.Add(row.IdServico, row.Descricao, FormatPercent(row.Markup / 100, NumDigitsAfterDecimal:=4), ImageList1.Images(1), ImageList1.Images(2))
            End If

        Next

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()
        Me.Close()

    End Sub

    Private Sub DtEsperados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtEsperados.CellContentClick

        If DtEsperados.Columns(e.ColumnIndex).Name = "ClmEditar" Then

            FrmMarkupInserir.LblCodigo.Text = DtEsperados.Rows(e.RowIndex).Cells(0).Value
            FrmMarkupInserir.LblDescrição.Text = DtEsperados.Rows(e.RowIndex).Cells(1).Value

            Dim CodStr As String = DtEsperados.Rows(e.RowIndex).Cells(0).Value

            If Not CodStr.StartsWith("S") Then

                Dim Cod As Integer = CodStr

                'Busca dimensões

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaDimensões = From dime In LqBase.Produtos
                                     Where dime.IdProduto = Cod
                                     Select dime.Largura, dime.Altura, dime.Profundidade, dime.Peso

                Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
                LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                Dim BuscaArmazenagem = From arm In LqEstoqueLocal.Armazenagem
                                       Where arm.IdProduto = Cod
                                       Select arm.Qt, arm.ValorUnit, arm.DataEntrada
                                       Order By DataEntrada Descending

                FrmMarkupInserir.LblTamamnho.Text = "A.:" & FormatNumber(BuscaDimensões.First.Altura, NumDigitsAfterDecimal:=0) & "mm - L.:" & FormatNumber(BuscaDimensões.First.Largura, NumDigitsAfterDecimal:=0) & "mm - P.:" & FormatNumber(BuscaDimensões.First.Profundidade, NumDigitsAfterDecimal:=0) & "mm - Kg.:" & FormatNumber(BuscaDimensões.First.Peso, NumDigitsAfterDecimal:=3)
                FrmMarkupInserir.BttSalvarMarkupCot.Visible = False
                FrmMarkupInserir.BttPular.Visible = False

                If BuscaArmazenagem.Count > 0 Then

                    FrmMarkupInserir.LblAquisicao.Text = FormatCurrency(BuscaArmazenagem.First.ValorUnit, NumDigitsAfterDecimal:=2)

                End If

            Else

                CodStr = CodStr.Remove(0, 5)

                Dim Cod As Integer = CodStr

                'Busca cotações

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaCotação = From arm In LqFinanceiro.Cotacoes
                                   Where arm.IdSolicitacaoCad = Cod
                                   Select arm.Qt, arm.ValorCotado, arm.DataCotacao
                                   Order By DataCotacao Descending

                FrmMarkupInserir.LblTamamnho.Text = "Não definido"
                FrmMarkupInserir.BttSalvarMarkupCot.Visible = False
                FrmMarkupInserir.BttPular.Visible = False

                If BuscaCotação.Count > 0 Then

                    FrmMarkupInserir.LblAquisicao.Text = FormatCurrency(BuscaCotação.First.ValorCotado, NumDigitsAfterDecimal:=2)

                End If


            End If

            Dim MArkup As String = DtEsperados.Rows(e.RowIndex).Cells(3).Value
            MArkup = MArkup.Replace("%", "")

            FrmMarkupInserir.TxtMarkup.Value = MArkup
            FrmMarkupInserir.BttSalvarMarkup.Visible = True

            FrmMarkupInserir.Show(Me)

        End If

    End Sub

    Private Sub DtServicos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtServicos.CellContentClick

        If DtServicos.Columns(e.ColumnIndex).Name = "ClmEditarServico" Then

            FrmMarkupInserirServiço.LblCodigo.Text = DtServicos.Rows(e.RowIndex).Cells(0).Value
            FrmMarkupInserirServiço.LblDescrição.Text = DtServicos.Rows(e.RowIndex).Cells(1).Value
            FrmMarkupInserirServiço._IdInterno = DtServicos.Rows(e.RowIndex).Cells(0).Value

            Dim Cod As Integer = DtServicos.Rows(e.RowIndex).Cells(0).Value

            'Busca cotações

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            FrmMarkupInserirServiço.LblTamamnho.Text = "Não definido"

            Dim MArkup As String = DtServicos.Rows(e.RowIndex).Cells(2).Value
            MArkup = MArkup.Replace("%", "")

            FrmMarkupInserirServiço.TxtMarkup.Value = MArkup
            FrmMarkupInserirServiço.BttSalvarMarkup.Visible = True

            FrmMarkupInserirServiço.Show(Me)

        End If



    End Sub
End Class