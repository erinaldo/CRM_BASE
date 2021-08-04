Public Class FrmTabela14
    Private Sub FrmTabela14_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        If Form2210.RdbTipico.Checked = True Or Form2210.RdbTrajeto.Checked = True Then

            Dim BuscaLog = From l In LqTrabalhista.Tabela14
                           Where l.Codigo Like "*"
                           Select l.Codigo, l.Descricao

            DtCIDS.Rows.Clear()

            For Each l In BuscaLog.ToList

                DtCIDS.Rows.Add(l.Codigo, l.Descricao)

            Next

        End If

        If Form2210.RdbDoenca.Checked = True Then

            Dim BuscaLog = From l In LqTrabalhista.Tabela15
                           Where l.Codigo Like "*"
                           Select l.Codigo, l.Descricao

            DtCIDS.Rows.Clear()

            For Each l In BuscaLog.ToList

                DtCIDS.Rows.Add(l.Codigo, l.Descricao)

            Next

        End If

    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Form2210.TxtCodAgenteCAusador.Text = DtCIDS.SelectedCells(0).Value

        Me.Close()

    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

        BttSalvarProduto.PerformClick()

    End Sub
End Class