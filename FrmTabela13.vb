Public Class FrmTabela13
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub FrmTabela14_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaLog = From l In LqTrabalhista.Tabela13
                       Where l.Codigo Like "*"
                       Select l.Codigo, l.Descricao

        DtCIDS.Rows.Clear()

        For Each l In BuscaLog.ToList

            DtCIDS.Rows.Add(l.Codigo, l.Descricao)

        Next

    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

    End Sub

    Private Sub DtCIDS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellDoubleClick

        BttSalvarProduto.PerformClick()

    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Form2210.TxtCodParteCorpo.Text = DtCIDS.SelectedCells(0).Value

        Me.Close()

    End Sub
End Class