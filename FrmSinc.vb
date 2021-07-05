Public Class FrmSinc
    Private Sub FrmSinc_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

    End Sub

    Private Sub DtProdutos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellEndEdit

        DtProdutos.FirstDisplayedCell = DtProdutos.Rows(e.RowIndex).Cells(0)

        Me.Refresh()

    End Sub

    Private Sub DtProdutos_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DtProdutos.RowsAdded

        DtProdutos.FirstDisplayedCell = DtProdutos.Rows(e.RowIndex).Cells(0)

        Me.Refresh()

    End Sub
End Class