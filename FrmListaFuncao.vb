Public Class FrmListaFuncao
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public Sub CarregaInicio()

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaFuncoes = From fun In LqBase.Cargos
                           Where fun.IdCargo Like "*"
                           Select fun.IdCargo, fun.Descricao, fun.RemuneracaoBase, fun.IdExterno

        DtFornecedores.Rows.Clear()

        For Each row In BuscaFuncoes.ToList

            DtFornecedores.Rows.Add(row.IdCargo, row.Descricao, FormatCurrency(row.RemuneracaoBase, NumDigitsAfterDecimal:=2), row.IdExterno)

        Next

    End Sub

    Private Sub FrmListaFuncao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

    End Sub

    Private Sub DtFornecedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellDoubleClick

        FrmNovaFuncao._IdFuncao = DtFornecedores.SelectedCells(3).Value
        FrmNovaFuncao._IdInterno = DtFornecedores.SelectedCells(0).Value

        FrmNovaFuncao.Show(Me)

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        FrmNovaFuncao.Show(Me)

    End Sub
End Class