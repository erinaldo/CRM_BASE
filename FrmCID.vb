Public Class FrmCID
    Private Sub FrmCID_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca cids

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaCIDS = From cid In LqTrabalhista.CID_FIND
                        Where cid.CODIGO Like "*"
                        Select cid.CODIGO, cid.DESCRICAO

        DtCIDS.Rows.Clear()

        For Each row In BuscaCIDS.ToList

            DtCIDS.Rows.Add(row.CODIGO, row.DESCRICAO)

        Next

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

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Form2210.TxtCodCid.Text = DtCIDS.SelectedCells(0).Value

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

        BttSalvarProduto.PerformClick()

    End Sub
End Class