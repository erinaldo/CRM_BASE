Public Class Nf_Recebidas
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub Nf_Recebidas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaNf = From nf In LqFinanceiro.NF_Entrada
                      Where nf.IdFornecedor Like "*"
                      Select nf.HoraEntrada, nf.DataEntrada, nf.IdFornecedor, nf.NumNF, nf.IdNF

        For Each row In BuscaNf.ToList

            Dim BuscaFornecedor = From fornec In LqBase.Fornecedores
                                  Where fornec.IdFornecedor = row.IdFornecedor.Remove(0, 2)
                                  Select fornec.Nome

            Dim LqEstoque As New LqEstoqueLocalDataContext
            LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

            Dim BuscaItensNf = From nf In LqEstoque.Armazenagem
                               Where nf.NF = row.NumNF
                               Select nf.ValorUnit

            Dim ValorNF As Decimal = 0

            For Each item In BuscaItensNf.ToList

                ValorNF += item

            Next

            DtProdutos.Rows.Add(row.IdNF, BuscaFornecedor.First, FormatNumber(row.NumNF, NumDigitsAfterDecimal:=0), FormatDateTime(row.DataEntrada, DateFormat.ShortDate) & " " & FormatDateTime(row.HoraEntrada.ToString, DateFormat.ShortTime), FormatCurrency(ValorNF, NumDigitsAfterDecimal:=2))

        Next

    End Sub
End Class