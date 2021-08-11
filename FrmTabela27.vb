Public Class FrmTabela27
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub FrmTabela27_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'carrega dados da tabela 27

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTrab = From T In LqTrabalhista.Tabela27
                        Where T.Codigo Like "*"
                        Select T.Codigo, T.Descricao

        For Each l In BuscaTrab.ToList

            DtCIDS.Rows.Add(l.Codigo, l.Descricao)

        Next

    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

    End Sub

    Private Sub DtCIDS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellDoubleClick

        BttSalvarProduto.PerformClick()

    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Frm2220.TxtCodProcedimento.Text = DtCIDS.SelectedCells(0).Value

        Me.Close()

    End Sub
End Class