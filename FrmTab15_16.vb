Public Class FrmTab15_16
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub FrmTab15_16_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Form2210.RdbTipico.Checked = True Then

            'busca tabela 15
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaTabela = From tab In LqTrabalhista.Tabela15
                              Where tab.Codigo Like "*"
                              Select tab.Codigo, tab.Descricao

            DtCIDS.Rows.Clear()

            For Each row In BuscaTabela.ToList

                DtCIDS.Rows.Add(row.Codigo, row.Descricao)

            Next

        ElseIf Form2210.RdbDoenca.Checked = True Then

            'busca tabela 16

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaTabela = From tab In LqTrabalhista.Tabela16
                              Where tab.Codigo Like "*"
                              Select tab.Codigo, tab.Descricao

            DtCIDS.Rows.Clear()

            For Each row In BuscaTabela.ToList

                DtCIDS.Rows.Add(row.Codigo, row.Descricao)

            Next

        ElseIf Form2210.RdbTrajeto.Checked = True Then

            'busca tabela 15
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaTabela = From tab In LqTrabalhista.Tabela15
                              Where tab.Codigo Like "*"
                              Select tab.Codigo, tab.Descricao

            DtCIDS.Rows.Clear()

            For Each row In BuscaTabela.ToList

                DtCIDS.Rows.Add(row.Codigo, row.Descricao)

            Next

        End If

    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Form2210.TxtCodSitGeradora.Text = DtCIDS.SelectedCells(0).Value

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

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

    End Sub

    Private Sub DtCIDS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellDoubleClick

        BttSalvarProduto.PerformClick()

    End Sub
End Class