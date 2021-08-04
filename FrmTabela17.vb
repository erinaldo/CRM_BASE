Public Class FrmTabela17
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub FrmTabela17_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTabela17 = From t In LqTrabalhista.Tabela17
                            Where t.Codigo Like "*"
                            Select t.Codigo, t.Descricao

        DtCIDS.Rows.Clear()

        For Each t In BuscaTabela17.ToList
            DtCIDS.Rows.Add(t.Codigo, t.Descricao)
        Next

    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

        BttSalvarProduto.PerformClick()

    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Form2210.TxtCodLesao.Text = DtCIDS.SelectedCells(0).Value

        Me.Close()

    End Sub

    Private Sub TxtDescricao_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricao.TextChanged

        For Each row As DataGridViewRow In DtCIDS.Rows

            If row.Cells(1).Value.ToString.Contains(TxtDescricao.Text) Then
                row.Visible = True
            Else
                row.Visible = False
            End If

        Next
    End Sub
End Class